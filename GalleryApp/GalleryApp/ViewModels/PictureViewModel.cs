using GalleryApp.Models;
using Xamarin.Forms;

namespace GalleryApp.ViewModels
{
    public class PictureViewModel
    {
        public ImageSource Image { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public Picture Picture { get; private set; }

        public PictureViewModel(Picture picture)
        {
            Image = ImageSource.FromFile(picture.FullPath);
            Date = picture.CreationDate.ToString();
            Name = picture.Name;
            Picture = picture;
        }
    }
}