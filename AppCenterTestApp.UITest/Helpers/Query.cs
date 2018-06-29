using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.UITest.Queries;

namespace AppCenterTestApp.UITest.Helpers
{

    public class Query
    {
        public Func<AppQuery, AppQuery> Func { get; private set; }

        public Query(Func<AppQuery, AppQuery> query)
        {
            Func = query;
        }

        /// <summary>
        /// Creates a new "Marked" query, which matches id/text on Android and iOS, 
        /// accessibilityLabel on iOS and contentDescription on Android. 
        /// This method works well with AutomationId in Xamarin.Forms.
        /// </summary>
        /// <param name="marked">Something that identifies controls among : 
        /// Xamarin.Forms : AutomationId
        /// iOS : AccessibilityIdentifier, AccessibilityLabel
        /// Android :  Id, ContentDescription or Text</param>
        public Query(string marked)
        {
            Func = e => e.Marked(marked);
        }

    }
}
