using GalleryApp.ViewModels;
using Xamarin.Forms;

namespace GalleryApp.Views
{
    public partial class PicturePage : ContentPage
    {
        public PictureViewModel ViewModel { get; private set; }
        public PicturePage(PictureViewModel vm)
        {
            InitializeComponent();
            ViewModel = vm;
            this.BindingContext = ViewModel;
        }
    }
}