using MouseKeyboardActivityMonitor;
using MouseKeyboardActivityMonitor.WinApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace ShareWindow
{
    class WindowPicker : IDisposable
    {
        private MouseHookListener listener;

        public event EventHandler<EventArgs> WindowSelected;

        public IntPtr SelectedWindowHandle { get; set; }

        [DllImport("user32.dll")]
        static extern IntPtr WindowFromPoint(int xPoint, int yPoint);

        public WindowPicker()
        {
        }

        public void Start()
        {
            ActivateListener();
        }

        private void ActivateListener()
        {
            listener = new MouseHookListener(new GlobalHooker());
            listener.MouseMoveExt += Listener_MouseMoveExt;
            listener.MouseDownExt += Listener_MouseDownExt;
            listener.Enabled = true;
        }

        void Listener_MouseDownExt(object sender, MouseEventExtArgs e)
        {
            if (WindowSelected != null)
                WindowSelected(this, e);
        }

        void Listener_MouseMoveExt(object sender, MouseEventExtArgs e)
        {
            SelectedWindowHandle = WindowFromPoint(e.X, e.Y);
        }

        private void DeactivateListener()
        {
            if (listener == null)
                return;
            listener.Dispose();
            listener = null;
        }

        public void Dispose()
        {
            DeactivateListener();
        }
    }
}
