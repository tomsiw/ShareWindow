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
        public event EventHandler<EventArgs> WindowHoovered;

        public IntPtr WindowHandle { get; set; }

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;

            public POINT(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }

            public POINT(System.Drawing.Point pt) : this(pt.X, pt.Y) { }

            public static implicit operator System.Drawing.Point(POINT p)
            {
                return new System.Drawing.Point(p.X, p.Y);
            }

            public static implicit operator POINT(System.Drawing.Point p)
            {
                return new POINT(p.X, p.Y);
            }
        }

        [DllImport("user32.dll")]
        static extern IntPtr WindowFromPoint(POINT Point);

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
            WindowHandle = WindowFromPoint(new POINT(e.X, e.Y));
            if (WindowHoovered != null)
                WindowHoovered(this, e);
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
