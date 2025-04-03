using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;

namespace Cybersecurity_AwarenessApplication
{
    public class image_display
    {
        static readonly string asciiChars = "&=:* ";

       public image_display()
        {
            // Get the base directory of the application
            string logo_directory = AppDomain.CurrentDomain.BaseDirectory;

            // Path to the image, assuming it's in the same directory as the executable
            string logo_path = Path.Combine(logo_directory, "Cyber.jpg");

            // Width and height of the resized image
            int width = 150;
            int height = 60;

            // Check if the image exists
            if (!File.Exists(logo_path))
            {
                Console.WriteLine("Error: Image file not found at " + logo_path);
                return;
            }

            try
            {
                using (Bitmap bitmap = new Bitmap(logo_path))
                {
                    // Resize and convert the image to ASCII
                    Bitmap resized = ResizeImage(bitmap, width, height);
                    ConvertToAscii(resized);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading image: {ex.Message}");
            }
        }

        // Method to resize the image
        static Bitmap ResizeImage(Bitmap original, int width, int height)
        {
            Bitmap resized = new Bitmap(width, height);
            using (Graphics graphics = Graphics.FromImage(resized))
            {
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.DrawImage(original, new Rectangle(0, 0, width, height));
            }
            return resized;
        }

        // Method to convert the image to ASCII
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

        // Method to map a pixel to an ASCII character
        static char MapPixelToChar(Color color)
        {
            int gray = (int)(color.R * 0.3 + color.G * 0.59 + color.B * 0.11); // Grayscale calculation
            int index = gray * (asciiChars.Length - 1) / 255;
            return asciiChars[index];
        }

        // Method to get the closest console color to the pixel color
        static ConsoleColor ClosestConsoleColor(Color color)
        {
            (ConsoleColor, Color)[] consoleColors = {
                (ConsoleColor.White, Color.White),
                (ConsoleColor.Red, Color.Red),
                (ConsoleColor.Yellow, Color.Yellow)
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
