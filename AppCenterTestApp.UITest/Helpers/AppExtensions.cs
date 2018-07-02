using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace AppCenterTestApp.UITest.Helpers
{
    /// <summary>
    /// Extension class for UITest.IApp class. Add some helpers to IApp.
    /// </summary>
    public static class AppExtensions
    {

        /// <summary>
        /// Get results of a query on XAML elements
        /// </summary>
        /// <param name="app"></param>
        /// <param name="query">Query to identify the elements to return</param>
        /// <returns></returns>
        public static AppResult[] Query(this IApp app, Query query)
        {
            return app.Query(query.Func);
        }

        /// <summary>
        /// Get results of a query on XAML elements by AutomationId
        /// </summary>
        /// <param name="app"></param>
        /// <param name="automationId"></param>
        /// <returns></returns>
        public static AppResult[] Query(this IApp app, string automationId)
        {
            return app.Query(automationId);
        }

        /// <summary>
        /// Wait for element and tap on it
        /// </summary>
        /// <param name="app"></param>
        /// <param name="query">Query to identify the element to tap</param>
        public static void WaitAndTap(this IApp app, Query query)
        {
            app.WaitForElement(query.Func);
            app.Tap(query.Func);
        }

        /// <summary>
        /// Wait for element and tap on it
        /// </summary>
        /// <param name="app"></param>
        /// <param name="automationId">AutomationId defined on XAML element</param>
        public static void WaitAndTap(this IApp app, string automationId)
        {
            WaitAndTap(app, new Query(automationId));
        }

        /// <summary>
        /// Enter text on element
        /// </summary>
        /// <param name="app"></param>
        /// <param name="query">Query to identify the element</param>
        /// <param name="text">Text to enter</param>
        public static void EnterText(this IApp app, Query query, string text)
        {
            app.EnterText(query.Func, text);
        }

        /// <summary>
        /// Tap on element
        /// </summary>
        /// <param name="app"></param>
        /// <param name="query">Query to identify the element</param>
        public static void Tap(this IApp app, Query query)
        {
            app.Tap(query.Func);
        }

        /// <summary>
        /// Tap on element
        /// </summary>
        /// <param name="app"></param>
        /// <param name="automationId">AutomationId defined on XAML element</param>
        public static void Tap(this IApp app, String automationId)
        {
            Tap(app, new Query(automationId));
        }

        /// <summary>
        /// Check if an element is displayed on page
        /// </summary>
        /// <param name="app"></param>
        /// <param name="automationId">AutomationId of the element to check</param>
        /// <returns>True if element is displayed on page</returns>
        public static bool CheckForElement(this IApp app, String automationId)
        {
            return app.Query(automationId).Any();
        }

        /// <summary>
        /// Check if an element is enabled on page
        /// </summary>
        /// <param name="app"></param>
        /// <param name="automationId">AutomationId of the element to check</param>
        /// <returns>True if element is enabled</returns>
        /// <exception cref="ArgumentNullException">Throw exception if element is not displayed on page.</exception>
        public static bool IsElementEnabled(this IApp app, String automationId)
        {
            if (app.CheckForElement(automationId))
            {
                return app.Query(automationId).First().Enabled;
            }

            throw new ArgumentNullException(automationId, $"Element marked with {automationId} si not displayed !");
        }
    }
}

