using AppCenterTestApp.UITest.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.UITest;

namespace AppCenterTestApp.UITest.Pages
{
    public class MainPage : BasePage
    {
        const string MainPageName = "Main Page";

        const string MainPageAutomationId = "MainPage";
        const string PlusButtonAutomationId = "PlusButton";
        const string NextPageButtonAutomationId = "NextPageButton";
        const string IntegerEntryAutomationId = "IntegerEntry";

        public bool PlusButtonEnabled => _app.IsElementEnabled(PlusButtonAutomationId);
        public bool PlusButtonDisplayed => _app.CheckForElement(PlusButtonAutomationId);

        public string IntegerEntryValue => _app.Query(IntegerEntryAutomationId).Single().Text;

        public MainPage(IApp app) : base(app, MainPageName, MainPageAutomationId)
        {

        }

        public void FillNumber(int number)
        {
            _app.EnterText(IntegerEntryAutomationId, number.ToString());
            _app.Screenshot($"Filled IntegerEntry field with {number}");
        }


        public void ClearNumber()
        {
            _app.ClearText(IntegerEntryAutomationId);
            _app.Screenshot("Cleared IntegerEntry field");
        }

        public void TapPlusButton(int numberOfTaps)
        {
            for (int i = 0; i < numberOfTaps; i++)
            {
                TapPlusButton();
            }
        }

        public void TapPlusButton()
        {
            _app.Tap(PlusButtonAutomationId);
            _app.Screenshot("Tapped Plus button");
        }

        public SecondPage TapNextPageButton()
        {
            _app.Tap(NextPageButtonAutomationId);
            _app.Screenshot("Tapped Next Page button");

            return new SecondPage(_app);
        }

    }
}
