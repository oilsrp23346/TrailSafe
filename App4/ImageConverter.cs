using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Graphics.Imaging;
using Windows.Storage.Streams;

namespace App4.model
{
    public class ImageConverter
    {
        public static async Task<byte[]> BitmapToByteArray(IRandomAccessStream stream)
        {
            BitmapDecoder decoder =  await BitmapDecoder.CreateAsync(stream);
            PixelDataProvider pixelData = await decoder.GetPixelDataAsync();
            byte[] bytes = pixelData.DetachPixelData();
            return bytes;
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
