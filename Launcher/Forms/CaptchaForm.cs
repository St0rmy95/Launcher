using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Launcher
{
    public partial class CaptchaForm : Form
    {
        string CaptchaText;
        public CaptchaForm()
        {
            InitializeComponent();
            CaptchaText = GetText();
            pbCaptcha.Image = Captcha.GetImage(CaptchaText);
        }

        private string GetText()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();

            return new string(Enumerable.Repeat(chars, 6)
                  .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            if (tbValidate.Text.ToLower() == CaptchaText.ToLower())
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                CaptchaText = GetText();
                tbValidate.Text = "";
                pbCaptcha.Image = Captcha.GetImage(CaptchaText);
            }
        }
    }
}
