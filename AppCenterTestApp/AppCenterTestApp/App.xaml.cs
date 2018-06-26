using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using AppCenterTestApp.Views;
using AppCenterTestApp.ViewModels;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace AppCenterTestApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPageViewModel = new MainPageViewModel();
            SecondPageViewModel = new SecondPageViewModel();

            MainPage = new NavigationPage(new MainPage());
        }

        public MainPageViewModel MainPageViewModel { get; private set; }
        public SecondPageViewModel SecondPageViewModel { get; private set; }

        protected override void OnStart()
        {
            // Handle when your app starts
            AppCenter.Start("android=7d096ecd-e96c-4236-bf94-a07de36fd26f;" +
                            "uwp=28a878a9-5765-4242-8b85-d083e8d58299;" +
                            "ios=1bd011eb-6e2b-4588-9ac4-aceabda4a786;", typeof(Analytics), typeof(Crashes));
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
