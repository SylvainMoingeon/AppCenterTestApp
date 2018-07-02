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
    public class MainPageTests
    {
        IApp app;
        Platform platform;

        // SUT
        MainPage _mainPage;

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

            _mainPage = new LoginPage(app).Login("admin","admin");
        }


        //[Test]
        //[Category("localUITest")]
        //public void _RunRepl()
        //{
        //    app.Repl();
        //}

        #region Navigation
        [Test]
        [Category(category_navigationCategory)]
        public void Navigation_NextButtonTap_ShouldNavigateToSecondPage()
        {
            // Arrange

            // Act
            var secondPage = _mainPage.TapNextPageButton();

            // Assert
            Assert.IsTrue(secondPage.IsPageDisplayed);
            app.Screenshot("Navigate to second page");
        }
        #endregion


        [Test]
        [Category(category_initialConditionCategory)]
        public void AtLaunch_IntegerEntryShouldDisplayZero()
        {
            // Arrange

            // Act

            // Assert
            Assert.AreEqual("0", _mainPage.IntegerEntryValue);
            app.Screenshot("Value is zero at launch");
        }

        [Test]
        [Category(category_initialConditionCategory)]
        public void AtLaunch_PlusButtonShouldBeEnabled()
        {
            // Arrange

            // Act

            // Assert
            Assert.IsTrue(_mainPage.PlusButtonEnabled, "Plus button should be enabled at launch.");
        }

        [Test]
        [TestCase(10, 0)]
        [TestCase(9, 1)]
        [TestCase(5, 5)]
        [TestCase(9, 5)]
        [Category(category_businessLogicCategory)]
        public void IfEntryIntegerValueEqualOrGreaterThanTen_PlusButtonShouldBeDisable(int startingValue, int numberOfTaps)
        {
            // Arrange    
            _mainPage.FillNumber(startingValue);

            // Act
            _mainPage.TapPlusButton(numberOfTaps);

            // Assert
            Assert.IsFalse(_mainPage.PlusButtonEnabled, "Plus button should be disabled");

        }

        [Test]
        [TestCase(1, "1")]
        [TestCase(2, "2")]
        [TestCase(3, "3")]
        [Category(category_businessLogicCategory)]
        public void StartingFromZero_TapPlusButtonXTimes_IntegerEntryDisplaysX(int numberOfTaps, String entryTextResult)
        {
            // Arrange

            // Act
            _mainPage.TapPlusButton(numberOfTaps);

            // Assert            
            Assert.AreEqual(entryTextResult, _mainPage.IntegerEntryValue);
            app.Screenshot($"IntegerEntry value is {entryTextResult}");
        }


    }
}
