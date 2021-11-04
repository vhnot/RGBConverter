using System;

namespace RGBConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            // trykcloud image format
            string imagePathFormat = "https://scrl.img.trykcloudstatic.com/designs/{0}/colors/{1}/thumbnail?pixels={2}";

            string styleNumber = "C013W";
            string colorNumber = "05225";
            int size = 20;

            string imagePath = string.Format(imagePathFormat, styleNumber, colorNumber, size);
            var color = RGBConverter.GetColor(imagePath);

            Console.WriteLine($"R: {color.R} G: {color.G} B: {color.B}");
        }
    }
}