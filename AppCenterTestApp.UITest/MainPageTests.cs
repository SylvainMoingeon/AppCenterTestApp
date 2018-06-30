using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace AppCenterTestApp.UITest
{
    //[TestFixture(Platform.iOS)]
    //[TestFixture(Platform.Android)]
    public class MainPageTests
    {
        IApp app;
        Platform platform;

        // MainPage
        static readonly Func<AppQuery, AppQuery> plusButton = q => q.Button("PlusButton");
        static readonly Func<AppQuery, AppQuery> nextButton = q => q.Button("NextPageButton");
        static readonly Func<AppQuery, AppQuery> integerEntry = q => q.Marked("IntegerEntry");

        // Login Page
        static readonly Func<AppQuery, AppQuery> LoginPage = q => q.Marked("LoginPage");
        static readonly Func<AppQuery, AppQuery> loginButton = q => q.Button("LoginButton");
        static readonly Func<AppQuery, AppQuery> UserIdEntry = q => q.Marked("UserIdEntry");
        static readonly Func<AppQuery, AppQuery> UserPasswordEntry = q => q.Marked("UserPasswordEntry");

        const String category_initialConditionCategory = "InitialCondition";
        const String category_navigationCategory = "Navigation";
        const String category_businessLogicCategory = "BusinessLogic";

        public MainPageTests(Platform platform)
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

        private void Login()
        {
            app.WaitForElement("LoginPage", "La page de login ne s'affiche pas");
            app.EnterText(UserIdEntry, "admin");
            app.EnterText(UserPasswordEntry, "admin");

            app.Screenshot("Login button should be enabled");
            app.Tap(loginButton);

            app.WaitForElement("MainPage", "Navigation from login page to mainpage didn't work.");
            app.Screenshot("Navigate to main page");
        }

        #region Navigation
        [Test]
        [Category(category_navigationCategory)]
        public void Navigation_NextButtonTap_ShouldNavigateToSecondPage()
        {
            // Arrange
            Login();

            // Act
            app.Tap(nextButton);

            // Assert
            app.WaitForElement("SecondPage", "La page suivante ne peux pas être atteinte.");
            app.Screenshot("Navigate to second page");
        }
        #endregion


        [Test]
        [Category(category_initialConditionCategory)]
        public void AtLaunch_IntegerEntryShouldDisplayZero()
        {
            // Arrange
            Login();

            // Act

            // Assert
            var appResult = app.Query(integerEntry).Single();
            app.Screenshot("Value is zero at launch");
            Assert.AreEqual("0", appResult.Text);
        }

        [Test]
        [Category(category_initialConditionCategory)]
        public void AtLaunch_PlusButtonShouldBeEnabled()
        {
            // Arrange
            Login();

            // Act

            // Assert
            var appResult = app.Query(plusButton).Single();
            app.Screenshot("PlusButton enabled at launch");
            Assert.IsTrue(appResult.Enabled, "Le bouton 'Plus' devrait être activé à l'ouverture de la fenêtre.");
        }

        [Test]
        [TestCase("10", 0)]
        [TestCase("9", 1)]
        [TestCase("5", 5)]
        [TestCase("9", 5)]
        [Category(category_businessLogicCategory)]
        public void IfEntryIntegerValueEqualOrGreaterThanTen_PlusButtonShouldBeDisable(string startingValue, int numberOfTap)
        {
            // Arrange
            Login();

            app.EnterText(integerEntry, startingValue);

            // Act
            for (int i = 0; i < numberOfTap; i++)
            {
                app.Tap(plusButton);
            }

            // Assert
            var appResult = app.Query(plusButton).Single();
            app.Screenshot("PlusButton disabled at 10");
            Assert.IsTrue(!appResult.Enabled, "Le bouton plus devrait être désactivé si la valeur est supérieure ou égale à 10");

        }

        [Test]
        [TestCase(1, "1")]
        [TestCase(2, "2")]
        [TestCase(3, "3")]
        [Category(category_businessLogicCategory)]
        public void StartingFromZero_TapPlusButtonXTimes_IntegerEntryDisplaysX(int numberOfTaps, String entryTextResult)
        {
            // Arrange
            Login();

            // Act
            for (int i = 0; i < numberOfTaps; i++)
            {
                app.Tap(plusButton);
                app.Screenshot("Tap PlusButton");
            }

            // Assert
            var appResult = app.Query(integerEntry).Single();

            app.Screenshot($"Le champs de saisie affiche {entryTextResult}");
            Assert.AreEqual(entryTextResult, appResult.Text);
        }


    }
}
