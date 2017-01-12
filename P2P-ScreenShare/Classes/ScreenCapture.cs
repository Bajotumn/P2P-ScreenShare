using System;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Drawing.Imaging;

namespace P2P_ScreenShare {
    public class ScreenCapture {
        public static Image CaptureScreenArea(Rectangle captureArea) {
            try {
                Bitmap bitmap = new Bitmap(captureArea.Width, captureArea.Height, PixelFormat.Format32bppArgb);
                Graphics graphics = Graphics.FromImage(bitmap);
                graphics.CopyFromScreen(captureArea.X, captureArea.Y, 0, 0, captureArea.Size);
                return bitmap;
            } catch { }
            return SystemIcons.Error.ToBitmap();
        }
    }
}
