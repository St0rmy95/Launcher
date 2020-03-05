using AceNetworking;
using Launcher.Updater;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Launcher
{
    public delegate void UpdateProgressCallback(int Progress, string Work, bool EnableControls = false);

    public partial class MainForm : Form
    {
        AceClientSocket m_Sock;

        private Point mousePosition;
        private MEX_SERVER_GROUP_INFO_FOR_LAUNCHER m_ServerGroup;

        public MainForm()
        {
            InitializeComponent();

            if (Properties.Settings.Default.Width == -1 || Properties.Settings.Default.Height == -1)
            {
                Properties.Settings.Default.Width = Screen.PrimaryScreen.Bounds.Width;
                Properties.Settings.Default.Height = Screen.PrimaryScreen.Bounds.Height;

                Properties.Settings.Default.Save();
            }

            if (Properties.Settings.Default.StoreLogins)
            {
                tbAccount.Text = Properties.Settings.Default.AccountName;
                tbPassword.Text = Properties.Settings.Default.Password;
            }

            cbRegGender.SelectedIndex = 0;

            btnStart.Enabled = false;
            btnStart.Image = Properties.Resources.start_disabled;
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            // Init Socket
            m_Sock = new AceClientSocket(Settings.XORKey);

            // Add Event Listeners
            m_Sock.OnConnect += OnConnect;
            m_Sock.OnDisconnect += OnDisconnect;
            m_Sock.OnConnectFailed += OnConnectFailed;
            m_Sock.OnSendPacketError += OnSendPacketError;
            m_Sock.OnReceivedPacketError += OnReceivedPacketError;
            m_Sock.OnReceivedPacket += OnReceivedPacket;

            // Setup Alive System
            m_Sock.SetAliveMessageTypes(new ushort[] { Protocols.T_PC_CONNECT_ALIVE });

            // Connect to server
            m_Sock.Connect(Settings.ServerIP, Settings.ServerPort);
        }

        private void OnConnect(object sender, EventArgs e)
        {
            m_Sock.SendPacket(Protocols.T_PC_CONNECT_GET_SERVER_GROUP_LIST);
            UpdateProgress(0, "Fetching update manifest", false);
        }

        private void OnReceivedPacket(object sender, PacketEventArgs e)
        {
            int nBytesUsed = 0;
            ushort nRecvType = 0;
            while (nBytesUsed < e.Length)
            {
                nRecvType = BitConverter.ToUInt16(e.Data, nBytesUsed);
                nBytesUsed += 2;
                switch (nRecvType)
                {
                    case Protocols.T_PC_CONNECT_GET_SERVER_GROUP_LIST_OK:
                        {
                            MSG_PC_CONNECT_GET_SERVER_GROUP_LIST_OK Info = Operations.ByteArrayToStruct<MSG_PC_CONNECT_GET_SERVER_GROUP_LIST_OK>(e.Data, ref nBytesUsed);

                            if (Info.NumOfServerGroup == 0)
                            {
                                MessageBox.Show("Gameserver is offline!\nPlease check [http://ace.gaming-paradise.net] for further information!");
                                Exit();
                            }

                            if (Info.ServerGroup.Crowdedness <= 0)
                            {
                                UpdateProgress(0, "Gameserver offline", false);

                                System.Threading.Thread.Sleep(5000);

                                m_Sock.SendPacket(Protocols.T_PC_CONNECT_GET_SERVER_GROUP_LIST);

                                continue;
                            }

                            m_ServerGroup = Info.ServerGroup;

                            MSG_PC_CONNECT_SINGLE_FILE_VERSION_CHECK Msg = new MSG_PC_CONNECT_SINGLE_FILE_VERSION_CHECK();
                            Msg.DeleteFileListVersion = new ushort[] { 0, 0, 0, 0 };
                            Msg.NoticeVersion = new ushort[] { 0, 0, 0, 0 };

                            m_Sock.SendPacket(Protocols.T_PC_CONNECT_SINGLE_FILE_VERSION_CHECK, Msg);
                        }
                        break;
                    case Protocols.T_PC_CONNECT_SINGLE_FILE_UPDATE_INFO:
                        {
                            MSG_PC_CONNECT_SINGLE_FILE_UPDATE_INFO Msg = Operations.ByteArrayToStruct<MSG_PC_CONNECT_SINGLE_FILE_UPDATE_INFO>(e.Data, ref nBytesUsed);

                            MSG_PC_CONNECT_VERSION SendMsg = new MSG_PC_CONNECT_VERSION();
                            SendMsg.ClientVersion = new ushort[] { 0, 0, 0, 0 };

                            m_Sock.SendPacket(Protocols.T_PC_CONNECT_VERSION, SendMsg);
                        }
                        break;
                    case Protocols.T_PC_CONNECT_SINGLE_FILE_VERSION_CHECK_OK:
                        {
                            MSG_PC_CONNECT_VERSION SendMsg = new MSG_PC_CONNECT_VERSION();
                            SendMsg.ClientVersion = new ushort[] { 0, 0, 0, 0 };

                            m_Sock.SendPacket(Protocols.T_PC_CONNECT_VERSION, SendMsg);
                        }
                        break;
                    case Protocols.T_PC_CONNECT_REINSTALL_CLIENT:
                        {
                            MSG_PC_CONNECT_REINSTALL_CLIENT Msg = Operations.ByteArrayToStruct<MSG_PC_CONNECT_REINSTALL_CLIENT>(e.Data, ref nBytesUsed);

                            // Use current version, we don't need the update thingy
                            MSG_PC_CONNECT_VERSION SendMsg = new MSG_PC_CONNECT_VERSION();
                            SendMsg.ClientVersion = Msg.LatestVersion;

                            m_Sock.SendPacket(Protocols.T_PC_CONNECT_VERSION, SendMsg);
                        }
                        break;
                    case Protocols.T_PC_CONNECT_VERSION_OK:
                        {
                            UpdateProgressCallback callback = UpdateProgress;
                            FileCheck.GetHashList(callback);
                        }
                        break;

                    case Protocols.T_PC_CONNECT_LOGIN_OK:
                        {
                            MSG_PC_CONNECT_LOGIN_OK Msg = Operations.ByteArrayToStruct<MSG_PC_CONNECT_LOGIN_OK>(e.Data, ref nBytesUsed);

                            if (Properties.Settings.Default.StoreLogins)
                            {
                                Properties.Settings.Default.AccountName = tbAccount.Text;
                                Properties.Settings.Default.Password = tbPassword.Text;
                                Properties.Settings.Default.Save();
                            }

                            string Args = String.Format("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10} {11}"
                                , Msg.FieldServerIP.ToManagedString()
                                , Msg.FieldServerPort
                                , Msg.IMServerIP.ToManagedString()
                                , Msg.IMServerPort

                                , Msg.AccountName.ToManagedString()
                                , BitConverter.ToString(MD5Lib.GetPasswordMD5(tbPassword.Text)).Replace("-", "").ToLowerInvariant()

                                , (Properties.Settings.Default.Fullscreen) ? 1 : 0
                                , Properties.Settings.Default.Width
                                , Properties.Settings.Default.Height
                                , 2

                                , (Msg.ConnectToTestServer) ? 1 : 0

                                , (Properties.Settings.Default.UseVSync) ? 1 : 0);

                            ProcessStartInfo pInfo = new ProcessStartInfo();
                            pInfo.FileName = "ca.exe";
                            pInfo.Arguments = Args;

                            Process.Start(pInfo);

                            Environment.Exit(0);
                        }
                        break;
                    case Protocols.T_PC_CONNECT_LOGIN_BLOCKED:
                        {
                            MSG_PC_CONNECT_LOGIN_BLOCKED Msg = Operations.ByteArrayToStruct<MSG_PC_CONNECT_LOGIN_BLOCKED>(e.Data, ref nBytesUsed);

                            if (Msg.IsMacBlocked)
                            {
                                MessageBox.Show("Your account is blocked presently.\n If you believe this is an error please Contact Customer Support at [http://gaming-paradise.net/support/] for further details");
                            }
                            else
                            {
                                string BlockedMsg = String.Format("{0}\'s account is blocked presently.\n  Reason: {1}\n  Period: {2} ~ {3}\n\nContact Customer Support at [http://gaming-paradise.net/support/] for further details."
                                    , Msg.szAccountName.ToManagedString()
                                    , Msg.szBlockedReasonForUser.ToManagedString()
                                    , Msg.atimeStart.ToString()
                                    , Msg.atimeEnd.ToString());
                                MessageBox.Show(BlockedMsg);
                            }
                        }
                        break;
                    case Protocols.T_ERROR:
                        {
                            MSG_ERROR ErrorMsg = Operations.ByteArrayToStruct<MSG_ERROR>(e.Data, ref nBytesUsed);

                            string Msg =  Operations.GetChatMessageFromPacket(e.Data, ref nBytesUsed, ErrorMsg.StringLength);

                            ShowError(ErrorMsg, Msg);
                        }
                        break;
                    default:
                        {
                            MessageBox.Show("Got unknown data from server!");
                            Exit();
                        }
                        break;
                }
            }
        }

        private void OnDisconnect(object sender, DisconnectEventArgs e)
        {
            if (e.Reason != DisconnectReason.SOCKET_CLOSED_BY_CLIENT 
                && e.Reason != DisconnectReason.SOCKET_CLOSED_BY_CLIENT_ERROR)
            {
                MessageBox.Show("Connection to the server has been lost!\nReason: " + e.Reason.ToString(), "Connection lost", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(-1);
            }
        }

        private void OnConnectFailed(object sender, EventArgs e)
        {
            MessageBox.Show("Could not connect to server!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Environment.Exit(-1);
        }

        private void OnSendPacketError(object sender, EventArgs e)
        {
            if (Environment.TickCount < 0)
                if (MessageBox.Show("Computer running longer than 25 days!\nPlease restart your whole system or disable Fast Startup (Win8/10).\n\n\n\nWould you like to restart now?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == System.Windows.Forms.DialogResult.Yes)
                    PCController.ExitWindows(RestartOptions.Reboot, false);
            else
                MessageBox.Show("Could not send data to the server!\nIf this error persists, please contact the Staff-Team!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            Environment.Exit(-1);
        }

        private void OnReceivedPacketError(object sender, PacketErrorEventArgs e)
        {
            MessageBox.Show(String.Format("Could not decode incoming Data!\nErrorcode: {0}", e.errorCode), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Environment.Exit(-1);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_Sock != null)
                m_Sock.Disconnect();
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = (this.WindowState == FormWindowState.Minimized) ? FormWindowState.Normal : FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Exit();
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            mousePosition = new Point(-e.X, -e.Y);
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mousePosition.X, mousePosition.Y);
                Location = mousePos;
            }
        }

        private void UpdateProgress(int Percentage, string Status, bool EnableControls = false)
        {
            Percentage = Math.Max(0, Math.Min(Percentage, 100));

            try
            {
                this.Invoke((MethodInvoker)delegate { progressBar.Value = Percentage; });

                if(!String.IsNullOrEmpty(Status))
                    this.Invoke((MethodInvoker)delegate { lbStatus.Text = Status; });

                this.Invoke((MethodInvoker)delegate
                {
                    tbAccount.Enabled = EnableControls;
                    tbPassword.Enabled = EnableControls;
                    btnStart.Enabled = EnableControls;
                    btnStart.Image = (EnableControls) ? Properties.Resources.start_normal : Properties.Resources.start_disabled;

                    btnSync.Enabled = EnableControls;
                    btnSync.Image = (EnableControls) ? Properties.Resources.sync_normal : Properties.Resources.sync_disabled;
                });
            }
            catch (ObjectDisposedException)
            { }
        }

        private void FocusAccount()
        {
            this.Invoke((MethodInvoker)delegate
            {
                tbAccount.Focus();
            });
        }

        private void FocusPassword()
        {
            this.Invoke((MethodInvoker)delegate
            {
                tbPassword.Focus();
            });
        }

        private void Exit()
        {
            if (m_Sock != null)
                m_Sock.Disconnect();

            this.Close();
            Environment.Exit(0);
        }

        private void ShowError(MSG_ERROR Error, string Msg)
        {
            switch (Error.ErrorCode)
            {
                case ErrorCodes.ERR_COMMON_LOGIN_FAILED:
                    {
                        MessageBox.Show("ID and password do not match.");
                        UpdateProgress(100, "", true);
                        FocusPassword();
                    }
                    break;
                case ErrorCodes.ERR_PROTOCOL_INVALID_PRESERVER_CLIENT_STATE:
                    {
                        MessageBox.Show("Error in login process");
                        Exit();
                    }
                    break;
                case ErrorCodes.ERR_PROTOCOL_DUPLICATE_LOGIN:
                    {
                        MessageBox.Show("Double log in");
                        Exit();
                        FocusAccount();
                    }
                    break;
                case ErrorCodes.ERR_PROTOCOL_ALL_FIELD_SERVER_NOT_ALIVE:
                    {
                        MessageBox.Show("GameServer is offline!");
                        Exit();
                    }
                    break;
                case ErrorCodes.ERR_PROTOCOL_IM_SERVER_NOT_ALIVE:
                    {
                        MessageBox.Show("ChatServer is offline!");
                        Exit();
                    }
                    break;
                case ErrorCodes.ERR_COMMON_SERVICE_TEMPORARILY_PAUSED:
                    {
                        MessageBox.Show("Server is in pause mode!");
                        Exit();
                    }
                    break;
                case ErrorCodes.ERR_PROTOCOL_LIMIT_GROUP_USER_COUNT:
                    {
                        MessageBox.Show("There are too many users online.\n\nTry logging in later.");
                        UpdateProgress(100, "", true);
                    }
                    break;
                case ErrorCodes.ERR_PROTOCOL_ACCOUNT_BLOCKED:
                    {
                        MessageBox.Show(String.Format("Your account is currently blocked.\nPeriod : {0}\n\nContact Customer Support at [http://gaming-paradise.net/support/] for further details.", Msg));
                        UpdateProgress(100, "", true);
                        FocusAccount();
                    }
                    break;
                case ErrorCodes.ERR_COMMON_INVALID_CLIENT_VERSION:
                    {
                        MessageBox.Show("Game client version is not valid.\r\n  Please reinstall or download the patch file.");
                        Exit();
                    }
                    break;
                case ErrorCodes.ERR_DB_NO_SUCH_ACCOUNT:
                    {
                        MessageBox.Show("This account does not exist!");
                        UpdateProgress(100, "", true);
                        FocusAccount();
                    }
                    break;
                case ErrorCodes.ERR_PERMISSION_DENIED:
                    {
                        MessageBox.Show("The game server is currently offline for maintenance. Please check the official homepage (http://ace.gaming-paradise.net) for further information.");
                        Exit();
                    }
                    break;
                case ErrorCodes.ERR_NO_SEARCH_CHARACTER:
                case ErrorCodes.ERR_DB_EXECUTION_FAILED:
                    {
                        MessageBox.Show("The creation of characters is currently forbidden!");
                        Exit();
                    }
                    break;
                case ErrorCodes.ERR_PROTOCOL_SELECTIVE_SHUTDOWN_NOT_ALLOWED_TIME:
                    {
                        MessageBox.Show("Server is in shutdown state!");
                        Exit();
                    }
                    break;
                default:
                    {
                        MessageBox.Show(String.Format("Got unknown error: {0}", Error.ErrorCode));
                        Exit();
                    }
                    break;
            }
        }

        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            btnClose.Image = Properties.Resources.close_hover;
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.Image = Properties.Resources.close_normal;
        }

        private void btnClose_MouseDown(object sender, MouseEventArgs e)
        {
            btnClose.Image = Properties.Resources.close_click;
        }

        private void btnClose_MouseUp(object sender, MouseEventArgs e)
        {
            btnClose.Image = Properties.Resources.close_normal;
            Exit();
        }

        private void btnClose_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(btnClose, "Close");
        }

        private void btnSettings_MouseEnter(object sender, EventArgs e)
        {
            btnSettings.Image = Properties.Resources.settings_hover;
        }

        private void btnSettings_MouseLeave(object sender, EventArgs e)
        {
            btnSettings.Image = Properties.Resources.settings_normal;
        }

        private void btnSettings_MouseDown(object sender, MouseEventArgs e)
        {
            btnSettings.Image = Properties.Resources.settings_click;
        }

        private void btnSettings_MouseUp(object sender, MouseEventArgs e)
        {
            btnSettings.Image = Properties.Resources.settings_normal;

            ToggleSettingsPanel();
        }

        private void btnSettings_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(btnSettings, "Settings");
        }

        private void btnStart_MouseEnter(object sender, EventArgs e)
        {
            btnStart.Image = Properties.Resources.start_hover;
        }

        private void btnStart_MouseLeave(object sender, EventArgs e)
        {
            btnStart.Image = Properties.Resources.start_normal;
        }

        private void btnStart_MouseDown(object sender, MouseEventArgs e)
        {
            btnStart.Image = Properties.Resources.start_click;
        }

        private void btnStart_MouseUp(object sender, MouseEventArgs e)
        {
            btnStart.Image = Properties.Resources.start_normal;

            UpdateProgress(100, "", false);

            if (string.IsNullOrWhiteSpace(tbAccount.Text))
            {
                MessageBox.Show("Please fill in your accountname!");
                UpdateProgress(100, "", true);

                FocusAccount();
                return;
            }

            if (string.IsNullOrWhiteSpace(tbPassword.Text))
            {
                MessageBox.Show("Please fill in your password!");
                UpdateProgress(100, "", true);

                FocusPassword();
                return;
            }

            if (string.IsNullOrWhiteSpace(tbAccount.Text))
            {
                MessageBox.Show("Please fill in all fields!");
                UpdateProgress(100, "", true);

                FocusAccount();
                return;
            }

            if (m_ServerGroup.Crowdedness == 0)
            {
                MessageBox.Show("Server is under examination. Try logging in later.");
                UpdateProgress(100, "", true);
                return;
            }

            MSG_PC_CONNECT_LOGIN msgLogin = new MSG_PC_CONNECT_LOGIN();
            msgLogin.LoginType = 0; // Direct Login
            msgLogin.AccountName = tbAccount.Text.ToNativeString(20);
            msgLogin.Password = MD5Lib.GetPasswordMD5(tbPassword.Text);
            msgLogin.FieldServerGroupName = m_ServerGroup.ServerGroupName;
            msgLogin.PrivateIP = Operations.GetLocalIPAddress().ToNativeString(16);
            msgLogin.MGameSEX = 0;
            msgLogin.MGameYear = 0;
            msgLogin.WebLoginAuthKey = tbPassword.Text.ToNativeString(30);
            msgLogin.MACAddr = Operations.GetMacAddress().GetAddressBytes();

            m_Sock.SendPacket(Protocols.T_PC_CONNECT_LOGIN, msgLogin);
        }

        private void btnStart_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(btnStart, "Start");
        }

        private void btnRegister_MouseEnter(object sender, EventArgs e)
        {
            btnRegister.Image = Properties.Resources.register_hover;
        }

        private void btnRegister_MouseLeave(object sender, EventArgs e)
        {
            btnRegister.Image = Properties.Resources.register_normal;
        }

        private void btnRegister_MouseDown(object sender, MouseEventArgs e)
        {
            btnRegister.Image = Properties.Resources.register_click;
        }

        private void btnRegister_MouseUp(object sender, MouseEventArgs e)
        {
            btnRegister.Image = Properties.Resources.register_normal;
            panelRegister.Visible = true;
        }

        private void btnRegister_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(btnRegister, "Register");
        }

        private void tbPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return && btnStart.Enabled)
                btnStart_MouseUp(sender, null);
        }

        private void btnSync_MouseEnter(object sender, EventArgs e)
        {
            btnSync.Image = Properties.Resources.sync_hover;
        }

        private void btnSync_MouseLeave(object sender, EventArgs e)
        {
            btnSync.Image = Properties.Resources.sync_normal;
        }

        private void btnSync_MouseDown(object sender, MouseEventArgs e)
        {
            btnSync.Image = Properties.Resources.sync_click;
        }

        private void btnSync_MouseUp(object sender, MouseEventArgs e)
        {
            btnSync.Image = Properties.Resources.sync_normal;

            panelSettings.Visible = false;

            UpdateProgress(0, "Starting Re-Sync");

            UpdateProgressCallback callback = UpdateProgress;
            FileCheck.GetHashList(callback, true);
        }

        private void btnSync_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(btnSync, "Re-Sync Client files");
        }
    }
}
