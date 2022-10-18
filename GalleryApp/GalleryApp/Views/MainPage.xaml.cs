using System;
using Xamarin.Forms;

namespace GalleryApp.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            if (App.Current.Properties.ContainsKey("UserPIN"))
            {
                regButton.IsVisible = false;
                
            } else
            {
                loginButton.IsVisible = false;
            }

            base.OnAppearing();
        }

        private async void regButton_ClickedAsync(object sender, EventArgs e)
        {
            if (!CheckPin(pin.Text)) 
            {
                infoMessage.Text = "Pin must be 4-chars, try again";
                return;
            }

            App.Current.Properties.Add("UserPIN", pin.Text);
            await Navigation.PushAsync(new PicListPage());
        }

        private bool CheckPin(string text)
        {
            return text.Length == 4;
        }

        private async void loginButton_ClickedAsync(object sender, EventArgs e)
        {
            if (!CheckPin(pin.Text))
            {
                infoMessage.Text = "Pin must be 4-chars, try again";
                return;
            }

            if (pin.Text == App.Current.Properties["UserPIN"] as string)
            {
                await Navigation.PushAsync(new PicListPage());
            }
            else
            {
                infoMessage.Text = "Wrong PIN, try again";
            }
        }

        private void pin_TextChanged(object sender, TextChangedEventArgs e)
        {
            infoMessage.Text = "";
        }
    }
}
