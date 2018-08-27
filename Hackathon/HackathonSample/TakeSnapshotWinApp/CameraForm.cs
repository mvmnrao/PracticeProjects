using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Media.Capture;
using Windows.Storage;
using Windows.Foundation;
using Windows.Storage.Streams;
using Windows.Media.MediaProperties;
using Windows.Graphics.Imaging;
using Windows.Storage.FileProperties;

namespace TakeSnapshotWinApp
{
    public partial class CameraForm : Form
    {
        private MediaCapture mediaCapture;

        public CameraForm()
        {
            InitializeComponent();
        }

        private async void btnTakeSnap_Click(object sender, EventArgs e)
        {
            mediaCapture = new MediaCapture();


        //    var myPictures = await StorageLibrary.GetLibraryAsync(KnownLibraryId.Pictures);
        //    StorageFile file = await myPictures.SaveFolder.CreateFileAsync("photo.jpg", CreationCollisionOption.GenerateUniqueName);

        //    using (var captureStream = new InMemoryRandomAccessStream())
        //    {
        //        await mediaCapture.CapturePhotoToStreamAsync(ImageEncodingProperties.CreateJpeg(), captureStream);

        //        using (var fileStream = await file.OpenAsync(FileAccessMode.ReadWrite))
        //        {
        //            var decoder = await BitmapDecoder.CreateAsync(captureStream);
        //            var encoder = await BitmapEncoder.CreateForTranscodingAsync(fileStream, decoder);

        //            var properties = new BitmapPropertySet {
        //    { "System.Photo.Orientation", new BitmapTypedValue(PhotoOrientation.Normal, PropertyType.UInt16) }
        //};
        //            await encoder.BitmapProperties.SetPropertiesAsync(properties);

        //            await encoder.FlushAsync();
        //        }
        //    }
        }

        private void CameraForm_Load(object sender, EventArgs e)
        {

        }
    }
}
