using System;
using NUnit.Framework;
using Xamarin.UITest;

namespace MobileTests
{
    [TestFixture]
    class TestApp
    {
        IApp app;

        [SetUp]
        public void SetUp()
        {
            app = AppInitializer.StartApp(Platform.Android);
        }

        [Test]
        public void NewComersInstructionsIsDisplayed()
        {
            var newcomersWelcomeText = app.Query(c => c.Text("Добро пожаловать!"));
            Assert.IsTrue(newcomersWelcomeText.Length != 0);
        }

        [Test]

        public void OpenDevicePage()
        {
            SkipNewcomersInstruction();
            SearhFor("jbl");
            app.DismissKeyboard();
            app.ScrollDownTo("JBL Flip 4 Trio", strategy: ScrollStrategy.Programmatically, timeout: new TimeSpan(0, 1, 0));
            app.Tap(c => c.Text("JBL Flip 4 Trio"));
        }

        public void SkipNewcomersInstruction()
        {
            app.Tap(c => c.Id("nextView"));
            app.Tap(c => c.Id("nextView"));
            app.Tap(c => c.Id("nextView"));
            app.Tap(c => c.Id("nextView"));
            app.Tap(c => c.Id("nextView"));
        }

        public void SearhFor(string searhFor)
        {
            app.Tap(c => c.Id("menu_search"));
            app.EnterText(c => c.Id("menu_search"), searhFor);
        }
    }
}
