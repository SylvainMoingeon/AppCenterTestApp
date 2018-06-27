using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppCenterTestApp.Views
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        private async void NextPageButton_Clicked(object sender, EventArgs e)
        {           
            await Navigation.PushAsync(new SecondPage(), true);
        }

        private async void LoginPageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage(), true);

        }
    }
}
