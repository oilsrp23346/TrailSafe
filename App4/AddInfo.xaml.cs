using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Capture;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using App4.model;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace App4
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddInfo : Page
    {
        private StorageFile storeFile;
        private IRandomAccessStream stream;
        private string profile_pic = "";

        public AddInfo()
        {
            this.InitializeComponent();
            ResetButton.Visibility = Visibility.Collapsed;
        }

        private async void CapturePhoto_Click(object sender, RoutedEventArgs e)
        {
            CameraCaptureUI capture = new CameraCaptureUI();
            capture.PhotoSettings.Format = CameraCaptureUIPhotoFormat.Jpeg;
            capture.PhotoSettings.CroppedAspectRatio = new Size(3, 5);
            capture.PhotoSettings.MaxResolution = CameraCaptureUIMaxPhotoResolution.HighestAvailable;
            storeFile = await capture.CaptureFileAsync(CameraCaptureUIMode.Photo);
            if (storeFile != null)
            {
                BitmapImage bimage = new BitmapImage();
                stream = await storeFile.OpenAsync(FileAccessMode.Read);
                bimage.SetSource(stream);
                CapturedPhoto.Source = bimage;
                profile_pic = ImageConverter.ByteArrayToBase64(ImageConverter.BitmapToByteArray(stream));
            }
        }
        /* private async void CapturePhoto_Click(object sender, RoutedEventArgs e)
         {
             try
             {
                 CameraCaptureUI dialog = new CameraCaptureUI();
                 //create storage file in local app storge
                 StorageFile file = await dialog.CaptureFileAsync(CameraCaptureUIMode.Photo);
                 if (file != null)
                 {
                     //get photo as a BitmapImage
                     BitmapImage bitmapImage = new BitmapImage();
                     using (IRandomAccessStream fileStream = await file.OpenAsync(FileAccessMode.Read))
                     {
                         bitmapImage.SetSource(fileStream);
                     }
                     CapturedPhoto.Source = bitmapImage;
                     ResetButton.Visibility = Visibility.Visible;

                 }
                 else
                 {
                     var dialog1 = new MessageDialog("Error!");
                     await dialog1.ShowAsync();
                 }
             }
             catch (Exception ex)
             {
                 var dialog1 = new MessageDialog("Error!");
                 await dialog1.ShowAsync();
             }
         }
         */


        
        private byte[] GetPic(byte[] buffer)
        {
            return buffer;
        }

        private async Task loadPic(byte[] buffer)
        {
            //StorageFile inputFile = await m_futureAccess.GetFileAsync(m_fileToken);
            //using (IRandomAccessStream inputStream = await inputFile.OpenAsync(FileAccessMode.Read),
            //              outputStream = await buffer.OpenAsync(FileAccessMode.ReadWrite))
           // {
            //    MemoryStream ms = new MemoryStream(buffer);
           // Image returnImage = Image.FromStream(ms);
           // return returnImage;
        }

        private void loadBtn_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            ResetButton.Visibility = Visibility.Collapsed;
            CapturedPhoto.Source = new BitmapImage(new Uri(this.BaseUri, "Assets/placeholder-sdk.png"));
        }


        private void Next_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddInfo2), profile_pic);
        }


    }
}