using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ShareWindow
{
    class BitmapInfo
    {
        public bool SameImage { get; set; }
        public bool FullFrame { get; set; }
        public Point DifferencePoint { get; set; }
        public Bitmap BifferenceBitmap { get; set; }
    }
}
