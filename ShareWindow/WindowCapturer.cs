using ShareWindow.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace ShareWindow
{
    class WindowCapturer
    {
        private IntPtr windowHandle;

        #region Interop

        [DllImport("USER32.DLL")]
        private static extern bool PrintWindow(HandleRef hwnd, IntPtr hdcBlt, int nFlags);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);

        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool IsWindow(IntPtr hWnd);

        #endregion

        public WindowCapturer(IntPtr windowHandle)
        {
            this.windowHandle = windowHandle;
        }

        public bool IsWindowValid()
        {
            return IsWindow(windowHandle);
        }

        public Bitmap Capture()
        {
            if (Settings.Default.UsePrintWindow)
                return DrawToBitmap(windowHandle);
            var capture = new ScreenCapture();
            var img = capture.CaptureWindow(windowHandle);
            return new Bitmap(img);
        }

        private Bitmap DrawToBitmap(IntPtr handle)
        {
            RECT rect = new RECT();
            GetWindowRect(handle, ref rect);

            Bitmap image = new Bitmap(rect.Right - rect.Left, rect.Bottom - rect.Top);

            using (Graphics graphics = Graphics.FromImage(image))
            {
                IntPtr hDC = graphics.GetHdc();
                PrintWindow(new HandleRef(graphics, handle), hDC, 0);
                graphics.ReleaseHdc(hDC);
            }

            return image;
        }
    }
}
