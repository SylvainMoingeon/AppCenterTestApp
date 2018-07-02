using AppCenterTestApp.UITest.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.UITest;

namespace AppCenterTestApp.UITest.Pages
{

    public class SecondPage : BasePage
    {
        const string SecondPageName = "Second Page";
        const string SecondPageAutomationId = "SecondPage";

        public SecondPage(IApp app) : base(app, SecondPageName, SecondPageAutomationId)
        {
        }
    }
}
