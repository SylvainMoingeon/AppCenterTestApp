using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.UITest.Utils;

namespace AppCenterTestApp.UITest.Helpers
{
    public class WaitTimes : IWaitTimes
    {
        public TimeSpan GestureWaitTimeout
        {
            get { return TimeSpan.FromMinutes(1); }
        }
        public TimeSpan WaitForTimeout
        {
            get { return TimeSpan.FromMinutes(1); }
        }

        public TimeSpan GestureCompletionTimeout
        {
            get { return TimeSpan.FromSeconds(5); }
        }
    }
}
