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
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        [TestCase(1, "1")]
        [TestCase(2, "2")]
        [TestCase(3, "3")]
        public void TapXTimesPlusButton_IncrementsXTimesIntegerEntry(int numberOfTaps, String entryTextResult)
        {
            // Arrange

            // Act
            for (int i = 0; i < numberOfTaps; i++)
            {
                app.Tap(x => x.Button("PlusButton"));
                app.Screenshot("Tap Tap Number Button");
            }


            // Assert
            var appResult = app.Query("IntegerEntry").First(result => result.Text.Equals(entryTextResult));
        }
    }
}
