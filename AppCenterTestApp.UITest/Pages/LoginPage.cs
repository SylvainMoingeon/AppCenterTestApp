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

        public LoginPage(IApp app) : base(app, LoginPageName, LoginPageAutomationId)
        {
        }

        public string UserNameText => _app.Query(UserNameEntryAutomationId).Single().Text;
        public string PassWordText => _app.Query(PasswordEntryAutomationId).Single().Text;

        public bool ErrorMessageDisplayed => _app.CheckForElement(ErrorMessageLabelAutomationId);
        public bool LoginButtonDisplayed => _app.CheckForElement(LoginButtonAutomationId);

        public bool LoginButtonEnabled => _app.IsElementEnabled(LoginButtonAutomationId);
        
        
        public void FillUserName(string username)
        {
            _app.EnterText(UserNameEntryAutomationId, username);
            _app.Screenshot("Filled Username");
        }

        public void FillPassword(string password)
        {
            _app.EnterText(PasswordEntryAutomationId, password);
            _app.Screenshot("Filled Password");

        }

        public void ClearUserName()
        {
            _app.ClearText(UserNameEntryAutomationId);
            _app.Screenshot("Cleared Username");
        }

        public void ClearPassword()
        {
            _app.ClearText(PasswordEntryAutomationId);
            _app.Screenshot("Cleared Password");
        }


        public void TapLoginButton()
        {
            _app.WaitAndTap(LoginButtonAutomationId);
            _app.Screenshot("Tapped Login Button");
        }
            

        public MainPage Login(string username, string password)
        {
            FillUserName(username);
            FillPassword(password);
            TapLoginButton();

            return new MainPage(_app);
        }

      

    }
}
