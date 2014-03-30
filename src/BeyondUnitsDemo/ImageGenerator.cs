using System.Drawing;
using System.Drawing.Imaging;

namespace BeyondUnitsDemo
{
    public class ImageGenerator
    {
        public static void Create(string filePath, string text)
        {
            var font = new Font("Tahoma", 24);

            using (var tempImage = new Bitmap(1, 1))
            {
                using (var tempDrawing = Graphics.FromImage(tempImage))
                {
                    var textSize = tempDrawing.MeasureString(text, font);

                    using (var img = new Bitmap((int)textSize.Width, (int)textSize.Height))
                    {
                        using (var drawing = Graphics.FromImage(img))
                        {
                            drawing.Clear(Color.White);

                            using (var textBrush = new SolidBrush(Color.Black))
                            {
                                drawing.DrawString(text, font, textBrush, 0, 0);

                                drawing.Save();
                            }
                        }

                        img.Save(filePath, ImageFormat.Jpeg);
                    }
                }
            }
        }
    }
}