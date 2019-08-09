using NUnit.Framework;
using TechTalk.SpecFlow;
namespace WebDriverBasics
{
    [Binding]
    class BaseTest
    {
        [SetUp]
        [BeforeFeature]
        public static void StartBrowser()
        {
            Browser = Browser.Instance;
            Browser.WindowMaximise();
            Browser.NavigateTo(Configuration.StartUrl);
            LoginPage = new YandexLoginPage(Browser.GetDriver());
        }

        [TearDown]
        [AfterTestRun]
        public static void CloseBrowser()
        {
            Browser.Quit();
        }

        protected static Browser Browser = Browser.Instance;

        protected static YandexLoginPage LoginPage { get; set; }
    }
}
