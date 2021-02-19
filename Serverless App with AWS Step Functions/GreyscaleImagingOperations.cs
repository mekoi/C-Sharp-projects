using GrapeCity.Documents.Imaging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IrisiMekoLab4
{
    public class GreyscaleImagingOperations
    {
        public static string GetConvertedImage(byte[] stream)
        {
            using (var bmp = new GcBitmap())
            {
                bmp.Load(stream);

                bmp.ApplyEffect(GrayscaleEffect.Get(GrayscaleStandard.BT601));
                 
                var resizedImage = bmp.Resize(100, 100, InterpolationMode.NearestNeighbor);
                return GetBase64(resizedImage);
            }
        }

        private static string GetBase64(GcBitmap bmp)
        {
            using (MemoryStream m = new MemoryStream())
            {
                bmp.SaveAsPng(m);
                return Convert.ToBase64String(m.ToArray());
            }
        }
    }
}
