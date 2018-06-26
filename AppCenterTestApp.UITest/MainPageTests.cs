using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace AppCenterTestApp.UITest
{
    [TestFixture(Platform.iOS)]
    [TestFixture(Platform.Android)]
    public class MainPageTests
    {
        IApp app;
        Platform platform;

        static readonly Func<AppQuery, AppQuery> plusButton = q => q.Button("PlusButton");
        static readonly Func<AppQuery, AppQuery> nextButton = q => q.Button("NextPageButton");
        static readonly Func<AppQuery, AppQuery> integerEntry = q => q.Marked("IntegerEntry");

        const String initialConditionCategory = "InitialCondition";
        const String navigationCategory = "Navigation";
        const String businessLogicCategory = "BusinessLogic";

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

        [Test]
        [Category(navigationCategory)]
        public void Navigation_NextButtonTap_ShouldNavigateToSecondPage()
        {
            // Arrange

            // Act
            app.Tap(nextButton);

            // Assert
            app.WaitForElement("SecondPage", "La page suivante ne peux pas être atteinte.");
            app.Screenshot("Navigate to second page");
        }

        [Test]
        [Category(initialConditionCategory)]
        public void IntegerEntry_AtLaunch_ShouldDisplayZero()
        {
            // Arrange

            // Act

            // Assert
            var appResult = app.Query(integerEntry).Single();
            Assert.AreEqual("0", appResult.Text);
            app.Screenshot("Value is zero at launch");
        }

        [Test]
        [Category(initialConditionCategory)]
        public void PlusButton_AtLaunch_ShouldBeEnabled()
        {
            // Arrange

            // Act

            // Assert
            var appResult = app.Query(plusButton).Single();
            Assert.IsTrue(appResult.Enabled, "Le bouton 'Plus' devrait être activé à l'ouverture de la fenêtre.");
            app.Screenshot("PlusButton enabled at launch");
        }

        [Test]
        [TestCase("10", 0)]
        [TestCase("9", 1)]
        [TestCase("5", 5)]
        [TestCase("9", 5)]
        [Category(businessLogicCategory)]
        public void PlusButton_IfEntryIntegerValueEqualOrGreaterThanTen_ShouldBeDisable(string startingValue, int numberOfTap)
        {
            // Arrange
            app.EnterText(integerEntry, startingValue);

            // Act
            for (int i = 0; i < numberOfTap; i++)
            {
                app.Tap(plusButton);
            }

            // Assert
            var appResult = app.Query(plusButton).Single();
            Assert.IsTrue(!appResult.Enabled, "Le bouton plus devrait être désactivé si la valeur est supérieure ou égale à 10");
            app.Screenshot("PlusButton disabled at 10");

        }

        [Test]
        [TestCase(1, "1")]
        [TestCase(2, "2")]
        [TestCase(3, "3")]
        [Category(businessLogicCategory)]
        public void PlusButton_StartingFromZero_TapXTimes_IntegerEntryDisplaysX(int numberOfTaps, String entryTextResult)
        {
            // Arrange
            app.EnterText(integerEntry, "0");

            // Act
            for (int i = 0; i < numberOfTaps; i++)
            {
                app.Tap(plusButton);
                app.Screenshot("Tap PlusButton");
            }

            // Assert
            var appResult = app.Query(integerEntry).Single();
            Assert.AreEqual(  entryTextResult, appResult.Text);
            app.Screenshot($"Le champs de saisie affiche {entryTextResult}");
        }


    }
}
