using GalleryApp.ViewModels;
using Xamarin.Forms;

namespace GalleryApp.Views
{
    public partial class PicListPage : ContentPage
    {
        public PicListPage()
        {
            InitializeComponent();

            BindingContext = new PicturesListViewModel() { Navigation = this.Navigation };
        }
    }
}