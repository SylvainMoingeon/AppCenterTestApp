using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.UITest;

namespace AppCenterTestApp.UITest.Helpers
{
    /// <summary>
    /// Base page for pages for Page Model Pattern UITest
    /// </summary>
    public abstract class BasePage
    {
        protected IApp _app { get; private set; }
        public string PageName { get; protected set; }
        public string PageAutomationId { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="pageName">Name of the page</param>
        /// <param name="pageAutomationId">AutomationId defined on XAML element</param>
        public BasePage(IApp app, string pageName, string pageAutomationId)
        {            
            _app = app;
            PageName = pageName;
            PageAutomationId = pageAutomationId;
        }

        /// <summary>
        /// Check if page is displayed on screen. 
        /// </summary>
        public bool CheckForPage()
        {
            try
            {
                _app.WaitForElement(PageAutomationId);
                _app.Screenshot($"Page {PageName} is displayed");
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
