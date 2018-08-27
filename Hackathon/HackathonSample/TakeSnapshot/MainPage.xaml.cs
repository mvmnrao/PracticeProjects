using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Imaging;
using Windows.Media.Capture;
using Windows.Media.MediaProperties;
using Windows.Storage;
using Windows.Storage.FileProperties;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TakeSnapshot
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private MediaCapture mediaCapture;
        private LowLagMediaRecording mediaRecording;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void startCameraBtn_Click(object sender, RoutedEventArgs e)
        {
            mediaCapture = new MediaCapture();
            //mediaRecording = new LowLagMediaRecording();
        }

        private async void takeSnapBtn_Click(object sender, RoutedEventArgs e)
        {
            if(mediaCapture == null)
            {
                MessageDialog messageDialog = new MessageDialog("Please start camera");
                await messageDialog.ShowAsync();
                return;
            }

            using (mediaCapture)
            {
                var myPictures = await StorageLibrary.GetLibraryAsync(KnownLibraryId.Pictures);
                StorageFile file = await myPictures.SaveFolder.CreateFileAsync("photo.jpg", CreationCollisionOption.GenerateUniqueName);

                using (var captureStream = new InMemoryRandomAccessStream())
                {
                    await mediaCapture.InitializeAsync();
                    await mediaCapture.CapturePhotoToStreamAsync(ImageEncodingProperties.CreateJpeg(), captureStream);

                    using (var fileStream = await file.OpenAsync(FileAccessMode.ReadWrite))
                    {
                        var decoder = await BitmapDecoder.CreateAsync(captureStream);
                        var encoder = await BitmapEncoder.CreateForTranscodingAsync(fileStream, decoder);

                        var properties = new BitmapPropertySet {
                        { "System.Photo.Orientation", new BitmapTypedValue(PhotoOrientation.Normal, PropertyType.UInt16) }
                    };
                        await encoder.BitmapProperties.SetPropertiesAsync(properties);

                        await encoder.FlushAsync();
                    }
                }
            }
        }

        private async void startVideoStreamBtn_Click(object sender, RoutedEventArgs e)
        {
            if (mediaCapture == null)
            {
                MessageDialog messageDialog = new MessageDialog("Please start camera");
                await messageDialog.ShowAsync();
                return;
            }

            var myVideos = await Windows.Storage.StorageLibrary.GetLibraryAsync(Windows.Storage.KnownLibraryId.Videos);
            StorageFile file = await myVideos.SaveFolder.CreateFileAsync("video.mp4", CreationCollisionOption.GenerateUniqueName);

            await mediaCapture.InitializeAsync();
            mediaRecording = await mediaCapture.PrepareLowLagRecordToStorageFileAsync(
                    MediaEncodingProfile.CreateMp4(VideoEncodingQuality.Auto), file);
            await mediaRecording.StartAsync();
        }

        private async void stopVideoStreamBtn_Click(object sender, RoutedEventArgs e)
        {
            await mediaRecording.StopAsync();
            await mediaRecording.FinishAsync();
        }
    }
}
