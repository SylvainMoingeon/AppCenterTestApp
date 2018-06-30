using System;
using System.IO;
using System.Linq;
using AppCenterTestApp.UITest.Pages;
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
            var loginPage = new LoginPage(app);

            // Act

            // Assert
            Assert.IsTrue(loginPage.IsPageDisplayed, "Login page is not displayed at launch");

        }

        [Test]
        [Category(category_initialCondition)]
        public void AtLaunch_LoginButtonShouldBeDisabled()
        {
            // Arrange
            var loginPage = new LoginPage(app);

            // Act

            // Assert
            Assert.IsFalse(loginPage.LoginButtonEnabled, "At launch login button should be disabled");

        }
        #endregion

        #region Validation
        [Test]
        [Category(category_validation)]
        public void Validation_BadCredentials_ShouldDisplayErrorMessage()
        {
            // Arrange
            var loginPage = new LoginPage(app);

            // Act
            loginPage.Login("admin", "badpassword");


            // Assert
            Assert.IsTrue(loginPage.ErrorMessageDisplayed, "Error message isn't displayed.");

        }

        [Test]
        [Category(category_validation)]
        public void Validation_IfUserIdIsEmpty_LoginButtonShouldBeDisable()
        {
            // Arrange
            var loginPage = new LoginPage(app);


            // Act
            loginPage.ClearUserName();
            loginPage.FillPassword("password");

            // Assert
            Assert.IsFalse(loginPage.LoginButtonEnabled, "If Username is empty login button should be disabled");
        }

        [Test]
        [Category(category_validation)]
        public void Validation_IfUserPasswordIsEmpty_LoginButtonShouldBeDisable()
        {
            // Arrange
            var loginPage = new LoginPage(app);


            // Act
            loginPage.FillUserName("admin");
            loginPage.ClearPassword();

            // Assert
            Assert.IsFalse(loginPage.LoginButtonEnabled, "If password is empty login button should be disabled");
        }
        #endregion

        #region Navigation
        [Test]
        [Category(category_navigation)]
        public void Navigation_AtLoginSuccess_ShouldNavigateToMainPage()
        {
            // Arrange
            var loginPage = new LoginPage(app);

            // Act
            var mainPage = loginPage.Login("admin", "admin");

            // Assert
            Assert.IsTrue(mainPage.IsPageDisplayed, "The main page should display");

        }
        #endregion







    }
}
