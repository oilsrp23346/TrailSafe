using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;

namespace App4.model
{
    public class ImageConverter
    {
        public static async Task<byte[]> BitmapToByteArray(IRandomAccessStream stream)
        {
            using (var dataReader = new DataReader(stream.GetInputStreamAt(0)))
            {
                await dataReader.LoadAsync((uint)stream.Size);
                byte[] buffer = new byte[(int)stream.Size];
                dataReader.ReadBytes(buffer);
                return buffer;
            }
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

        public static async Task<BitmapImage> byteArrayToBitmapImage(byte[] arr)
        {
            var randomAccessStream = new InMemoryRandomAccessStream();
            using (var writer = new DataWriter(randomAccessStream))
            {
                writer.WriteBytes(arr);
                await writer.StoreAsync();
                await writer.FlushAsync();
                writer.DetachStream();
            }
            randomAccessStream.Seek(0);
            BitmapImage bimage = new BitmapImage();
            bimage.SetSource(randomAccessStream);
            return bimage;
        }
    }
}
