using ShareWindow.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShareWindow
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            ReadSettings();
            if (!Directory.Exists("PermMan"))
                httpPermButton.Enabled = false;
        }

        private void ReadSettings()
        {
            updateTextBox.Text = Settings.Default.UpdateTime.ToString();
            portTextBox.Text = Settings.Default.Port.ToString();
            printWinRadioButton.Checked = Settings.Default.UsePrintWindow;
            gdiRadioButton.Checked = !printWinRadioButton.Checked;
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            Settings.Default.UpdateTime = int.Parse(updateTextBox.Text);
            Settings.Default.Port = int.Parse(portTextBox.Text);
            Settings.Default.UsePrintWindow = printWinRadioButton.Checked;
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {

        }

        private void httpPermButton_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists("PermMan"))
                return;
            ProcessStartInfo startInfo = new ProcessStartInfo("HttpNamespaceManager.exe");
            startInfo.WorkingDirectory = "PermMan";
            Process.Start(startInfo);
        }

        private void portHelpButton_Click(object sender, EventArgs e)
        {
            new HttpPortHelpForm().ShowDialog();
        }
    }
}
