using GalleryApp.Models;
using GalleryApp.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace GalleryApp.ViewModels
{
    public class PicturesListViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<PictureViewModel> Pictures { get; set; }
        public INavigation Navigation { get; set; }

        private PictureViewModel selectedItem;

        public PictureViewModel SelectedItem
        {
            get { return selectedItem; }
            set 
            {
                if (selectedItem != value)
                {
                    selectedItem = value;
                    OnPropertyChanged("SelectedItem");
                }
            }
        }

        public ICommand ShowPictureCommand { protected set; get; }
        public ICommand DeletePictureCommand { protected set; get; }

        public event PropertyChangedEventHandler PropertyChanged;

        public PicturesListViewModel()
        {
            IEnumerable<PictureViewModel> pics = Directory.GetFiles("/storage/emulated/0/DCIM/Camera/").Select(f => new PictureViewModel(new Picture(f)));
            Pictures = new ObservableCollection<PictureViewModel>(pics);
            ShowPictureCommand = new Command(ShowPictureAsync, IsItemSelected);
            DeletePictureCommand = new Command(DeletePicture, IsItemSelected);
        }

        private bool IsItemSelected(object obj)
        {
            return SelectedItem != null;
        }

        private void DeletePicture(object obj)
        {
            PictureViewModel pictureVM = obj as PictureViewModel;
            Pictures.Remove(pictureVM);
            SelectedItem = null;
            File.Delete(pictureVM.Picture.FullPath);
        }

        private async void ShowPictureAsync(object obj)
        {
            PictureViewModel picture = obj as PictureViewModel;
            await Navigation.PushAsync(new PicturePage(picture));
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
