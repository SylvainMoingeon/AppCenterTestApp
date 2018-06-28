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

        private String userId;

        public String UserId
        {
            get { return userId; }
            set
            {
                Set(ref userId, value);
                RefreshCanExecutes();
                BadCredentials = false;
            }
        }

        private String userPassword;

        public String UserPassword
        {
            get { return userPassword; }
            set
            {
                Set(ref userPassword, value);
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
            if (UserId == "admin" && UserPassword == "admin")
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
            return !String.IsNullOrWhiteSpace(UserId) && !String.IsNullOrWhiteSpace(UserPassword) && !isLogged;
        }

        void RefreshCanExecutes()
        {
            (LoginCommand as Command).ChangeCanExecute();

        }

    }
}
