using System;
using System.Drawing;
using System.Net;

namespace RGBConverter
{
    public static class RGBConverter
    {
        public static Color GetColor(string imagePath)
        {
            var image = GetBitmap(imagePath);

            return GetColor(image);
        }

        private static Bitmap GetBitmap(string imagePath)
        {
            var request = WebRequest.Create(imagePath);
            var response = request.GetResponse();
            var stream = response.GetResponseStream();

            return new Bitmap(stream);
        }

        private static Color GetColor(Bitmap bitmap)
        {
            int width = bitmap.Width,
                height = bitmap.Height,
                rSum = 0,
                gSum = 0,
                bSum = 0,
                pixelsCount = width * height;

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    var color = bitmap.GetPixel(x, y);

                    rSum += color.R;
                    gSum += color.G;
                    bSum += color.B;
                }
            }

            int r = GetAvaragePixelValue(rSum, pixelsCount);
            int g = GetAvaragePixelValue(gSum, pixelsCount);
            int b = GetAvaragePixelValue(bSum, pixelsCount);

            return Color.FromArgb(r, g, b);
        }

        private static byte GetAvaragePixelValue(int sum, int pixelsCount)
        {
            return (byte)Math.Round((double)sum / pixelsCount);
        }
    }
}