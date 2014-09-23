using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace ShareWindow
{
    class WindowInfo
    {
        private IntPtr windowHandle;
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        public WindowInfo(IntPtr windowHandle)
        {
            this.windowHandle = windowHandle;
            UpdateWindowInfo();
        }

        private void UpdateWindowInfo()
        {
            var name = new StringBuilder(255);
            GetWindowText(windowHandle, name, 255);
            WindowTitle = name.ToString();
        }
        
        public string WindowTitle { get; set; }
    }
}
