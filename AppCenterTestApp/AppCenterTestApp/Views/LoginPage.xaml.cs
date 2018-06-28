using AppCenterTestApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCenterTestApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<LoginPageViewModel>(this, MessengerKeys.LoginSuccess,   (sender) =>
            {
                Application.Current.MainPage = new NavigationPage(new MainPage());
                //await Navigation.PushAsync(new MainPage());
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<LoginPageViewModel>(this, MessengerKeys.LoginSuccess);
        }
    }
}