using ShareWindow.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShareWindow
{
    public partial class MainForm : Form
    {
        private IntPtr windowHandle;
        private Timer updateTimer;
        private WindowPicker picker;
        private Bitmap currentFrame;
        private WebServer webServer;
        private long imgIndex = 0;

        public MainForm()
        {
            InitializeComponent();
            Location = Settings.Default.Position;
            StartWebServer();
        }

        private void pickWindowToolStripButton_Click(object sender, EventArgs e)
        {
            DisposePicker();
            CreatePicker();
        }

        void Picker_WindowSelected(object sender, EventArgs e)
        {
            windowHandle = picker.SelectedWindowHandle;
            DisposePicker();
            startStopToolStripButton.Checked = true;
            StartBroadcast();
            UpdateWindowInfo();
        }

        private void CreatePicker()
        {
            picker = new WindowPicker();
            picker.WindowSelected += Picker_WindowSelected;
            picker.Start();
            pickWindowToolStripButton.Checked = true;
        }

        private void DisposePicker()
        {
            if (picker == null)
                return;
            picker.Dispose();
            picker = null;
            pickWindowToolStripButton.Checked = false;
        }

        private void UpdateWindowInfo(bool valid = true)
        {
            if (!valid)
            {
                toolStripStatusLabel.Text = "Window not selected";
                return;
            }
            var windowInfo = new WindowInfo(windowHandle);
            toolStripStatusLabel.Text = "Selected : " + windowInfo.WindowTitle;
        }

        private void startStopToolStripButton_Click(object sender, EventArgs e)
        {
            if (!ValidateWindow())
                return;
            if (startStopToolStripButton.Checked)
                StartBroadcast();
            else
                StopBroadcast();
        }

        private bool ValidateWindow()
        {
            if (windowHandle != IntPtr.Zero)
                return true;
            startStopToolStripButton.Checked = false;
            MessageBox.Show(this, "Please select a window before starting sharing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        private void StopBroadcast()
        {
            if (updateTimer == null)
                return;
            startStopToolStripButton.Checked = false;
            updateTimer.Stop();
            updateTimer.Dispose();
            updateTimer = null;
            InvalidateImage();
        }

        private void DisposeWebServer()
        {
            webServer.Dispose();
            webServer = null;
        }

        private void StartBroadcast()
        {
            if (updateTimer != null)
                return;
            updateTimer = new Timer();
            updateTimer.Interval = Settings.Default.UpdateTime;
            updateTimer.Tick += UpdateTimer_Tick;
            updateTimer.Start();
        }

        private void InvalidateImage()
        {
            imgIndex += 1;
        }

        private void StartWebServer()
        {
            webServer = new WebServer(ProcessRequest, "/", "index", "image", "peek", "refreshRate");
            webServer.Start();
        }

        private Response ProcessRequest(System.Net.HttpListenerRequest arg)
        {
            if (arg.RawUrl.TrimEnd('/') == "" || arg.RawUrl.TrimEnd('/') == "/index")
                return new Response { TextResponse = true, Text = File.ReadAllText("PreviewPage.html") };
            if (arg.RawUrl.StartsWith("/peek"))
                return new Response { TextResponse = true, Text = imgIndex.ToString() };
            if (arg.RawUrl.StartsWith("/refreshRate"))
                return new Response { TextResponse = true, Text = Settings.Default.UpdateTime.ToString() };
            return new Response { Binary = GetImage() };
        }

        private byte[] GetImage()
        {
            if (currentFrame == null)
                return File.ReadAllBytes("NoPreview.jpg");
            var mem = new MemoryStream();
            (currentFrame.Clone() as Bitmap).Save(mem, System.Drawing.Imaging.ImageFormat.Png);
            return mem.ToArray();
        }

        void UpdateTimer_Tick(object sender, EventArgs e)
        {
            updateTimer.Enabled = false;
            var capturer = new WindowCapturer(windowHandle);
            if (!capturer.IsWindowValid())
            {
                windowHandle = IntPtr.Zero;
                currentFrame = null;
                InvalidateImage();
                StopBroadcast();
                UpdateWindowInfo(false);
                return;
            }

            var newFrame = capturer.Capture();
            if (currentFrame == null)
            {
                InvalidateImage();
                currentFrame = newFrame;
                updateTimer.Enabled = true;
                return;
            }
            var comparer = new BitmapComparer();
            var start = DateTime.Now;
            var same = comparer.Compare(currentFrame, newFrame);
            var end = DateTime.Now;
            var diff = end - start;

            if (!same)
            {
                currentFrame = (Bitmap)newFrame.Clone();
                InvalidateImage();
            }

            updateTimer.Enabled = true;
        }

        private void propertiesToolStripButton_Click(object sender, EventArgs e)
        {
            new SettingsForm().ShowDialog();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            Settings.Default.Position = Location;
            Settings.Default.Save();
            DisposeWebServer();
            base.OnClosing(e);
        }

        private void MainForm_MouseEnter(object sender, EventArgs e)
        {
            Activate();
        }

        private void MainForm_MouseLeave(object sender, EventArgs e)
        {
        }

        private void MainForm_MouseHover(object sender, EventArgs e)
        {
        }
    }
}
