using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;

namespace ShareWindow
{
    class BitmapComparer
    {
        private static bool AreFrameSame(Bitmap oldFrame, Bitmap newFrame)
        {
            if (oldFrame.Size != newFrame.Size)
                return false;

            Rectangle lockArea = new Rectangle(Point.Empty, oldFrame.Size);
            BitmapData oldData = oldFrame.LockBits(lockArea, ImageLockMode.ReadOnly, oldFrame.PixelFormat);
            BitmapData newData = newFrame.LockBits(lockArea, ImageLockMode.ReadOnly, newFrame.PixelFormat);

            var len = newData.Height * Math.Abs(newData.Stride);
            bool same = true;
            IntPtr pOld = oldData.Scan0;
            IntPtr pNew = newData.Scan0;
            byte[] rgbOldValues = new byte[len];
            byte[] rgbNewValues = new byte[len];

            System.Runtime.InteropServices.Marshal.Copy(pOld, rgbOldValues, 0, len);
            System.Runtime.InteropServices.Marshal.Copy(pNew, rgbNewValues, 0, len);
            for (long index = 0; index < len; index++)
                if (rgbOldValues[index] != rgbNewValues[index])
                {
                    same = false;
                    break;
                }

            oldFrame.UnlockBits(oldData);
            newFrame.UnlockBits(newData);
            return same;
        }

        public bool Compare(System.Drawing.Bitmap currentFrame, System.Drawing.Bitmap newFrame)
        {
            try
            {
                if (currentFrame.Size != newFrame.Size)
                    return false;

                return AreFrameSame(currentFrame, newFrame);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
