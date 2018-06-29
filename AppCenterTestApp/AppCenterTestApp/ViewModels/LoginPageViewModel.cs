using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppCenterTestApp.ViewModels
{
    public class LoginPageViewModel : SimpleObservableObject
    {
        public ICommand LoginCommand { private set; get; }

        private String userName;

        public String UserName
        {
            get { return userName; }
            set
            {
                Set(ref userName, value);
                RefreshCanExecutes();
                BadCredentials = false;
            }
        }

        private String password;

        public String Password
        {
            get { return password; }
            set
            {
                Set(ref password, value);
                RefreshCanExecutes();
                BadCredentials = false;
            }
        }

        private bool isLogged;

        public bool IsLogged
        {
            get { return isLogged; }
            set
            {
                Set(ref isLogged, value);
                RefreshCanExecutes();
            }
        }

        private bool badCredentials;

        public bool BadCredentials
        {
            get { return badCredentials; }
            set { Set(ref badCredentials, value); }
        }



        public LoginPageViewModel()
        {
            LoginCommand = new Command(Login, LoginCanExecute);
        }

        private void Login(object obj)
        {
            if (UserName == "admin" && Password == "admin")
            {
                BadCredentials = false;
                IsLogged = true;

                MessagingCenter.Send(this, MessengerKeys.LoginSuccess);
            }
            else
            {
                IsLogged = false;
                BadCredentials = true;
            }

        }

        private bool LoginCanExecute(object arg)
        {
            return !String.IsNullOrWhiteSpace(UserName) && !String.IsNullOrWhiteSpace(Password) && !isLogged;
        }

        void RefreshCanExecutes()
        {
            (LoginCommand as Command).ChangeCanExecute();

        }

    }
}
