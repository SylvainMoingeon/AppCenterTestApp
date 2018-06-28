using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace AppCenterTestApp.UITest
{
    //[TestFixture(Platform.iOS)]
    [TestFixture(Platform.Android)]
    public class LoginPageTests
    {
        IApp app;
        Platform platform;

        // Login Page
        static readonly Func<AppQuery, AppQuery> LoginPage = q => q.Marked("LoginPage");
        static readonly Func<AppQuery, AppQuery> loginButton = q => q.Button("LoginButton");
        static readonly Func<AppQuery, AppQuery> UserIdEntry = q => q.Marked("UserIdEntry");
        static readonly Func<AppQuery, AppQuery> UserPasswordEntry = q => q.Marked("UserPasswordEntry");
        static readonly Func<AppQuery, AppQuery> ErrorMessageLabel = q => q.Marked("ErrorMessageLabel");

        // Main Page
        static readonly Func<AppQuery, AppQuery> MainPage = q => q.Marked("MainPage");


        const String category_initialCondition = "InitialCondition";
        const String category_navigation = "Navigation";
        const String category_validation = "Validation";

        public LoginPageTests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }


        //[Test]
        //[Category("localUITest")]
        //public void _RunRepl()
        //{
        //    app.Repl();
        //}

        #region Initial Conditions
        [Test]
        [Category(category_initialCondition)]
        public void AtLAunch_LoginPageShouldLoad()
        {
            // Arrange

            // Act
            app.Screenshot("At Launch");
            app.WaitForElement("LoginPage", "La page de login ne s'affiche pas au démarrage");
            app.Screenshot("At Launch should display Login page");

            // Assert

        }

        [Test]
        [Category(category_initialCondition)]
        public void AtLaunch_LoginButtonShouldBeDisabled()
        {
            // Arrange
            app.WaitForElement("LoginPage", "La page de login ne s'affiche pas au démarrage");
            app.Screenshot("Login page is displayed");

            // Act

            // Assert
            var loginButtonResult = app.Query(loginButton).Single();
            Assert.IsTrue(!loginButtonResult.Enabled, "At launch login button should be disabled");

        }
        #endregion

        #region Validation
        [Test]
        [Category(category_validation)]
        public void Validation_BadCredentials_ShouldDisplayErrorMessage()
        {
            // Arrange
            app.WaitForElement("LoginPage", "La page de login ne s'affiche pas");

            app.EnterText(UserIdEntry, "admin");
            app.EnterText(UserPasswordEntry, "baspassword");

            // Act
            app.Screenshot("Login button should be enabled");
            app.Tap(loginButton);

            // Assert
            app.WaitForElement(ErrorMessageLabel, "Error message isn't displayed.");
            app.Screenshot("Bad credentials display error message");
        }

        [Test]
        [Category(category_validation)]
        public void Validation_IfUserIdIsEmpty_LoginButtonShouldBeDisable()
        {
            // Arrange
            app.WaitForElement("LoginPage", "La page de login ne s'affiche pas");

            // Act
            app.ClearText(UserIdEntry);
            app.EnterText(UserPasswordEntry, "somepassword");
            app.Screenshot("UserId is empty");

            // Assert
            var loginButtonResult = app.Query(loginButton).Single();
            Assert.IsTrue(!loginButtonResult.Enabled, "If UserId is empty login button should be disabled");
            app.Screenshot("UserId is empty and login button is disabled");
        }

        [Test]
        [Category(category_validation)]
        public void Validation_IfUserPasswordIsEmpty_LoginButtonShouldBeDisable()
        {
            // Arrange
            app.WaitForElement("LoginPage", "La page de login ne s'affiche pas");

            // Act
            app.ClearText(UserPasswordEntry );
            app.EnterText(UserIdEntry, "admin");
            app.Screenshot("UserPassword is empty");

            // Assert
            var loginButtonResult = app.Query(loginButton).Single();
            Assert.IsTrue(!loginButtonResult.Enabled, "If UserPassword is empty login button should be disabled");
            app.Screenshot("UserPassword is empty and login button is disabled");
        }
        #endregion

        #region Navigation
        [Test]
        [Category(category_navigation)]
        public void Navigation_AtLoginSuccess_ShouldNavigateToMainPage()
        {
            // Arrange
            app.WaitForElement("LoginPage", "La page de login ne s'affiche pas");
            app.EnterText(UserIdEntry, "admin");
            app.EnterText(UserPasswordEntry, "admin");


            // Act
            app.Screenshot("Login button should be enabled");
            app.Tap(loginButton);

            // Assert
            app.WaitForElement("MainPage", "Navigation from login page to mainpage didn't work.");
            app.Screenshot("Navigate to main page");
        }
        #endregion







    }
}
