using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;

namespace Cybersecurity_AwarenessApplication
{
    internal class image_display
    {
        static readonly string asciiChars = "&=:* ";


        public image_display()
        {
            //file path for image used in directory
            string path_logo = AppDomain.CurrentDomain.BaseDirectory;


            //
            string new_path_logo = path_logo.Replace("bin\\Debug\\", "");




            string full_logo_path = Path.Combine(new_path_logo, "ASCI ART 2.jpeg");
            int width = 150;//width of the image
            int height = 60; // height of the image



            //Test if displaying the image will execute smoothly
            if (!File.Exists(full_logo_path))
            {
                Console.WriteLine("Error: Image file not found at " + full_logo_path);
                return;
            }

            try
            {
                using (Bitmap bitmap = new Bitmap(full_logo_path))
                {
                    Bitmap resized = ResizeImage(bitmap, width, height);
                    ConvertToAscii(resized);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading image: {ex.Message}");
            }
        }
        //Method for resizing image
        static Bitmap ResizeImage(Bitmap original, int width, int height)
        {
            Bitmap resized = new Bitmap(width, height);
            using (Graphics picture_graphics = Graphics.FromImage(resized))
            {
                //InterpolationMode to make the logo appear wider and clearer.
                picture_graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                picture_graphics.DrawImage(original, new Rectangle(0, 0, width, height));
            }
            return resized;
        }
        //
        static void ConvertToAscii(Bitmap image)
        {
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color pixelColor = image.GetPixel(x, y);
                    char asciiChar = MapPixelToChar(pixelColor);
                    Console.ForegroundColor = ClosestConsoleColor(pixelColor);
                    Console.Write(asciiChar);
                }
                Console.WriteLine();
            }
            Console.ResetColor();
        }

        static char MapPixelToChar(Color color)
        {
            //Enhance gray scale accuracy
            int gray = (int)(color.R * 0.3 + color.G * 0.59 + color.B * 0.11); // More accurate grayscale
            int index = gray * (asciiChars.Length - 1) / 255;
            return asciiChars[index];
        }

        //Colors used in the image 
        static ConsoleColor ClosestConsoleColor(Color color)
        {
            (ConsoleColor, Color)[] consoleColors = {

                (ConsoleColor.White, Color.White),
                (ConsoleColor.Blue,Color.Blue),
                 (ConsoleColor.Yellow,Color.Yellow)
            };

            ConsoleColor closestColor = ConsoleColor.White;
            double minDistance = double.MaxValue;

            foreach (var (consoleColor, c) in consoleColors)
            {
                double distance = Math.Pow(c.R - color.R, 2) + Math.Pow(c.G - color.G, 2) + Math.Pow(c.B - color.B, 2);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestColor = consoleColor;
                }
            }
            return closestColor;
        }
    }
}
