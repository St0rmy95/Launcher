using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Launcher
{
    public partial class MainForm : Form
    {
        struct Resolution
        {
            public int Width;
            public int Height;

            public Resolution(int Width, int Height)
            {
                this.Width = Width;
                this.Height = Height;
            }

            public override string ToString()
            {
                return String.Format("{0}x{1}", Width, Height);
            }
        }

        Launcher.Properties.Settings m_Settings = Launcher.Properties.Settings.Default;

        Resolution[] Resolutions = new Resolution[] 
        { 
            new Resolution(1024, 768),
            new Resolution(1200, 900),
            new Resolution(1280, 1024),
            new Resolution(1440, 900),
            new Resolution(1680, 1050),
            new Resolution(1600, 900),
            new Resolution(1600, 1200),
            new Resolution(1366, 768),
            new Resolution(1368, 768),
            new Resolution(1920, 1200),
            new Resolution(2560, 1600),
            new Resolution(1280, 720),
            new Resolution(1920, 1080),
            new Resolution(2560, 1440),
            new Resolution(2560, 1600)
        };

        private void ToggleSettingsPanel()
        {
            if (panelRegister.Visible)
                return;

            panelSettings.Visible = !panelSettings.Visible;

            if(panelSettings.Visible)
                LoadSettings();
        }

        private void HideSettingsPanel()
        {
            panelSettings.Visible = false;
            lbResolution.Items.Clear();
        }

        private void LoadSettings()
        {
            Rectangle CurrentResolution = Screen.PrimaryScreen.Bounds;

            lbResolution.Items.Add("Borderless (Native)");

            foreach (Resolution res in Resolutions)
            {
                if (res.Width > CurrentResolution.Width || res.Height > CurrentResolution.Height)
                    continue;

                int index = lbResolution.Items.Add(res.ToString());
                if (res.Width == m_Settings.Width && res.Height == m_Settings.Height)
                    lbResolution.SelectedIndex = index;
            }

            if (m_Settings.Borderless)
                lbResolution.SelectedIndex = 0;

            cbFullscreen.Checked = m_Settings.Fullscreen;
            cbVsync.Checked = m_Settings.UseVSync;
            cbLogins.Checked = m_Settings.StoreLogins;
        }

        private void SaveSettings()
        {
            m_Settings.Fullscreen = cbFullscreen.Checked;
            m_Settings.UseVSync = cbVsync.Checked;
            m_Settings.StoreLogins = cbLogins.Checked;

            string[] Splits = lbResolution.SelectedItem.ToString().Split('x');
            if (Splits.Length == 2)
            {
                m_Settings.Borderless = false;
                m_Settings.Width = int.Parse(Splits[0]);
                m_Settings.Height = int.Parse(Splits[1]);
            }
            else
            {
                m_Settings.Borderless = true;
                // get resolution
                m_Settings.Width = 0;
                m_Settings.Height = 0;
            }

            m_Settings.Save();
        }

        private void btnSettingsOk_MouseEnter(object sender, EventArgs e)
        {
            btnSettingsOk.Image = Properties.Resources.ok_hover;
        }

        private void btnSettingsOk_MouseLeave(object sender, EventArgs e)
        {
            btnSettingsOk.Image = Properties.Resources.ok_normal;
        }

        private void btnSettingsOk_MouseDown(object sender, MouseEventArgs e)
        {
            btnSettingsOk.Image = Properties.Resources.ok_click;
        }

        private void btnSettingsOk_MouseUp(object sender, MouseEventArgs e)
        {
            btnSettingsOk.Image = Properties.Resources.ok_normal;

            SaveSettings();

            HideSettingsPanel();
        }

        private void btnSettingsOk_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(btnSettingsOk, "Save Settings");
        }

        private void btnSettingsCancel_MouseEnter(object sender, EventArgs e)
        {
            btnSettingsCancel.Image = Properties.Resources.cancel_hover;
        }

        private void btnSettingsCancel_MouseLeave(object sender, EventArgs e)
        {
            btnSettingsCancel.Image = Properties.Resources.cancel_normal;
        }

        private void btnSettingsCancel_MouseDown(object sender, MouseEventArgs e)
        {
            btnSettingsCancel.Image = Properties.Resources.cancel_click;
        }

        private void btnSettingsCancel_MouseUp(object sender, MouseEventArgs e)
        {
            btnSettingsCancel.Image = Properties.Resources.cancel_normal;

            HideSettingsPanel();
        }

        private void btnSettingsCancel_MouseHover(object sender, EventArgs e)
        {
            toolTip.SetToolTip(btnSettingsCancel, "Cancel");
        }
    }
}
