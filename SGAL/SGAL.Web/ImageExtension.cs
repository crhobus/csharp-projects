using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace SGAL.Web
{
    public static class ImageExtension
    {
        public static byte[] ToImage(this string base64String)
        {
            // Convert Base64 String to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);

            // Convert byte[] to Image
            ms.Write(imageBytes, 0, imageBytes.Length);
            return imageBytes;
        }

        public static string ToBase64String(this byte[] imageBytes)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }
    }
}