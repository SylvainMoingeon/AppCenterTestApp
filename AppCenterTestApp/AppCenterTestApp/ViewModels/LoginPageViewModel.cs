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


        public LoginPageViewModel()
        {
            LoginCommand = new Command(Login, LoginCanExecute);
        }

        private void Login(object obj)
        {
            if (UserId == "Toto" && UserPassword == "Zér0")
            {
                IsLogged = true;
            }
            else
            {
                IsLogged = false;
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
