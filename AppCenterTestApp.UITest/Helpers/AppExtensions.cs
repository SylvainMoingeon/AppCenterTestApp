using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace AppCenterTestApp.UITest.Helpers
{
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
    }
}
