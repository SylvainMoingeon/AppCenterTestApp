using AppCenterTestApp.UITest.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace AppCenterTestApp.UITest.Pages
{
    public class LoginPage : BasePage
    {
        const string LoginPageName = "LoginPage";

        const string LoginPageAutomationId = "LoginPage";
        const string LoginButtonAutomationId = "LoginButton";
        const string UserNameEntryAutomationId = "UserNameEntry";
        const string PasswordEntryAutomationId = "PasswordEntry";
        const string ErrorMessageLabelAutomationId = "ErrorMessageLabel";

        //static readonly Query loginPageQuery = new Query("LoginPage");
        //static readonly Query loginButtonQuery = new Query("LoginButton");
        //static readonly Query userIdEntryQuery = new Query("UserIdEntry");
        //static readonly Query userPasswordEntryQuery = new Query("UserPasswordEntry");
        //static readonly Query errorMessageLabelQuery = new Query("ErrorMessageLabel");



        public LoginPage(IApp app) : base(app, LoginPageName, LoginPageAutomationId)
        {
        }

        //
        public void FillUserName(string username)
        {
            _app.WaitForElement(UserNameEntryAutomationId);
            _app.Screenshot("Youhou");
            _app.EnterText(UserNameEntryAutomationId, username);
            _app.Screenshot("Username is filled");
        }

        public void FillPassword(string password)
        {
            _app.EnterText(PasswordEntryAutomationId, password);
            _app.Screenshot("Password is filled");

        }

        public void ClearUserName()
        {
            _app.ClearText(UserNameEntryAutomationId);
            _app.Screenshot("Username is cleared");
        }

        public void ClearPassword()
        {
            _app.ClearText(PasswordEntryAutomationId);
            _app.Screenshot("Passwordis cleaned");
        }


        public void TapLoginButton()
        {
            _app.WaitAndTap(LoginButtonAutomationId);
            _app.Screenshot("Login Button is tapped");
        }

        public bool IsLoginButtonEnabled()
        {
            _app.WaitForElement(LoginButtonAutomationId, "Login button is not displayed");
            var button = _app.Query(LoginButtonAutomationId).Single();

            return button.Enabled;
        }

        public MainPage Login(string username, string password)
        {
            FillUserName(username);
            FillPassword(password);
            TapLoginButton();

            return new MainPage(_app);
        }

        public bool CheckForErrorMessage()
        {
            _app.WaitForElement(ErrorMessageLabelAutomationId, "Error message is not displayed", new TimeSpan(0, 0, 1));
            _app.Screenshot("Error message is displayed");

            return true;
        }

        public bool CheckForNoErrorMessage()
        {
            _app.WaitForNoElement(ErrorMessageLabelAutomationId, "Error message still displayed", new TimeSpan(0, 0, 1));
            _app.Screenshot("Error message is hidden");

            return true;
        }

    }
}
