using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;

namespace App4.model
{
    public class ImageConverter
    {
        public static byte[] BitmapToByteArray(IRandomAccessStream stream)
        {
            byte[] buffer = new byte[(int)stream.Size];
            return buffer;
        }

        public static string ByteArrayToBase64(byte[] buffer)
        {
            string base64 = Convert.ToBase64String(buffer);
            return base64;
        }

        public static byte[] Base64ToByteArray(string base64)
        {
            byte[] buffer = Convert.FromBase64String(base64);
            return buffer;
        }
    }
}
