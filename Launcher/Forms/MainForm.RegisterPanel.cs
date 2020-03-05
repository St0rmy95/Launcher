using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Launcher
{
    public partial class MainForm : Form
    {

        private void btnRegOk_MouseEnter(object sender, EventArgs e)
        {
            btnRegOk.Image = Properties.Resources.ok_hover;
        }

        private void btnRegOk_MouseLeave(object sender, EventArgs e)
        {
            btnRegOk.Image = Properties.Resources.ok_normal;
        }

        private void btnRegOk_MouseDown(object sender, MouseEventArgs e)
        {
            btnRegOk.Image = Properties.Resources.ok_click;
        }

        private void btnRegOk_MouseUp(object sender, MouseEventArgs e)
        {
            btnRegOk.Image = Properties.Resources.ok_normal;

            CaptchaForm form = new CaptchaForm();

            if (form.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show("Please enter the valid captcha!");
                return;
            }

            if (tbRegAccount.Text.Length < 4)
            {
                MessageBox.Show("Please enter a valid accountname! (4-20 chars)");
                return;
            }

            if (tbRegPassword.Text.Length < 6)
            {
                MessageBox.Show("Please enter a valid password! (6-14 chars)");
                return;
            }

            if (Regex.Matches(tbRegEmail.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Count == 0)
            {
                MessageBox.Show("Please enter a valid e-mail!");
                return;
            }

            int Birthyear;
            if (!int.TryParse(tbRegBirth.Text, out Birthyear) || Birthyear < 1900 || Birthyear > DateTime.Now.Year - 12)
            {
                MessageBox.Show("Please enter a valid birthyear!");
                return;
            }

            if (string.IsNullOrEmpty(cbRegGender.Text))
            {
                MessageBox.Show("Please select a valid gender!");
                return;
            }

            btnRegOk.Enabled = false;
            btnRegOk.Image = Properties.Resources.ok_disabled;

            // Post Web Request to register
            using (HttpClient client = new HttpClient())
            {
                var values = new Dictionary<string, string>
                {
                    { "reg_submit", "1" },
                    { "reg_type", "LauncherRegister" },
                    { "reg_accountname", tbRegAccount.Text },
                    { "reg_password", tbRegPassword.Text },
                    { "reg_repassword", tbRegPassword.Text },
                    { "reg_email", tbRegEmail.Text },
                    { "reg_birthyear", tbRegBirth.Text },
                    { "reg_gender", cbRegGender.Text },
                    { "reg_rules", "1" }
                };

                var content = new FormUrlEncodedContent(values);

                string responseString = client.PostAsync(Settings.RegisterWebsiteURL, content).Result.Content.ReadAsStringAsync().Result;

                int StartIndex = responseString.LastIndexOf("LAUNCHER_ERROR_START") + "LAUNCHER_ERROR_START".Length;
                int Length = responseString.LastIndexOf("LAUNCHER_ERROR_END") - StartIndex;

                string[] Messages = responseString.Substring(StartIndex, Length).Split(new string[] { "<br />" }, StringSplitOptions.RemoveEmptyEntries);

                string ErrorMessage = "An error occured during registration process:\n";

                foreach (string Msg in Messages)
                {
                    if (Msg == "LAUNCHER_REGISTER_SUCCESS")
                    {
                        MessageBox.Show("Account registered successfully!\nPlease check your e-mail to activate your account!");
                        tbRegAccount.Text = "";
                        tbRegPassword.Text = "";
                        tbRegEmail.Text = "";
                        tbRegBirth.Text = "";
                        cbRegGender.SelectedIndex = 0;

                        btnRegOk.Enabled = true;
                        btnRegOk.Image = Properties.Resources.ok_normal;

                        panelRegister.Visible = false;
                        return;
                    }
                    else
                    {
                        ErrorMessage += Msg + "\n";
                    }
                }

                MessageBox.Show(ErrorMessage);

                btnRegOk.Enabled = true;
                btnRegOk.Image = Properties.Resources.ok_normal;
            }
        }

        private void btnRegCancel_MouseEnter(object sender, EventArgs e)
        {
            btnRegCancel.Image = Properties.Resources.cancel_hover;
        }

        private void btnRegCancel_MouseLeave(object sender, EventArgs e)
        {
            btnRegCancel.Image = Properties.Resources.cancel_normal;
        }

        private void btnRegCancel_MouseDown(object sender, MouseEventArgs e)
        {
            btnRegCancel.Image = Properties.Resources.cancel_click;
        }

        private void btnRegCancel_MouseUp(object sender, MouseEventArgs e)
        {
            btnRegCancel.Image = Properties.Resources.cancel_normal;

            tbRegAccount.Text = "";
            tbRegPassword.Text = "";
            tbRegEmail.Text = "";
            tbRegBirth.Text = "";
            cbRegGender.SelectedIndex = 0;

            btnRegOk.Enabled = true;
            btnRegOk.Image = Properties.Resources.ok_normal;

            panelRegister.Visible = false;
        }

        private void btnRegOk_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(btnRegOk, "Register");
        }

        private void btnRegCancel_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(btnRegOk, "Cancel");
        }

        private void tbRegPassword_TextChanged(object sender, EventArgs e)
        {
            if (tbRegPassword.Text.Length > 20)
                tbRegPassword.Text = tbRegPassword.Text.Substring(0, 20);
        }

        private void lbRules_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(Settings.RuleWebsiteURL);
        }
    }
}
