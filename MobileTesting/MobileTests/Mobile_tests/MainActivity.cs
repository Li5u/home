using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

namespace MobileTests
{
    class MainActivity
    {
        public void OnCreate()
        {
            AppCenter.Start("da300441-af60-41c5-b608-ba34258b1c8b",
                   typeof(Analytics), typeof(Crashes));
        }
    }
}
