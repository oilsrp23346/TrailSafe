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
using Windows.Storage.AccessCache;
using Windows.ApplicationModel.Background;

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
        private byte[] b;

        public AddInfo()
        {
            this.InitializeComponent();
            ResetButton.Visibility = Visibility.Collapsed;
        }

        private async void CapturePhoto_Click(object sender, RoutedEventArgs e)
        {
            CameraCaptureUI capture = new CameraCaptureUI();
            capture.PhotoSettings.Format = CameraCaptureUIPhotoFormat.Jpeg;
            capture.PhotoSettings.CroppedAspectRatio = new Size(18, 13);
            capture.PhotoSettings.MaxResolution = CameraCaptureUIMaxPhotoResolution.HighestAvailable;
            storeFile = await capture.CaptureFileAsync(CameraCaptureUIMode.Photo);
            //show up picture
            if (storeFile != null)
            {
                BitmapImage bimage = new BitmapImage();
                stream = await storeFile.OpenAsync(FileAccessMode.Read);
                bimage.SetSource(stream);
                CapturedPhoto.Source = bimage;//CapturedPhoto is Image block
            }
            
            using (var dataReader = new DataReader(stream.GetInputStreamAt(0)))
            {
                await dataReader.LoadAsync((uint)stream.Size);
                byte[] buffer = new byte[(int)stream.Size];
                dataReader.ReadBytes(buffer);
                profile_pic = ImageConverter.ByteArrayToBase64(buffer);
                BitmapImage b = ImageConverter.byteArrayToBitmapImage(ImageConverter.Base64ToByteArray(profile_pic)).Result;
            }
        }

        //save
        private async void saveBtn_Click(object sender, RoutedEventArgs e)
        {

  
            /*try
            {
               FileSavePicker fs = new FileSavePicker();
               fs.FileTypeChoices.Add("Image", new List<string>() { ".png" });
               fs.DefaultFileExtension = ".png";
               
               fs.SuggestedFileName = "Image" + DateTime.Today.ToString(); //suggest fie name
                 // to PC
               fs.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
               fs.SuggestedSaveFile = storeFile;
                 //Saving the file
               var s = await fs.PickSaveFileAsync();

                // obtain permissions

               /* var fs = new StreamWriter(new FileStream(@"C:\\oil.png", FileMode.Create));
                fs.Write(b);
                

                var picker = new FolderPicker();
                picker.SuggestedStartLocation = PickerLocationId.Unspecified;
                var pfolder = await picker.PickSingleFolderAsync();
                StorageApplicationPermissions.FutureAccessList.Add(pfolder);
                //create file in desired folder
                var folder = await StorageFolder.GetFolderFromPathAsync("/UserPic");
                var file = await folder.CreateFileAsync("Pic1.png");
                using (var writer = await file.OpenStreamForWriteAsync())
                {
                    await writer.WriteAsync(new byte[100], 0, 0);
                }
                */
              /*  if (s != null)
                {
                //
                    using (var dataReader = new DataReader(stream.GetInputStreamAt(0)))
                    {
                        await dataReader.LoadAsync((uint)stream.Size);
                        byte[] buffer = new byte[(int)stream.Size];
                        dataReader.ReadBytes(buffer);
                    
                    }
                 }
            }
            catch (Exception ex)
            {
                var messageDialog = new MessageDialog(ex.ToString());
                await messageDialog.ShowAsync();
            }*/
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