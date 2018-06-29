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
        const string MainPageName = "Main page";
        const string MainPageAutomationId = "MainPage";

        public MainPage(IApp app) : base(app, MainPageName, MainPageAutomationId)
        {

        }
    }
}
