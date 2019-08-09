using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace WebDriverBasics
{

    class YandexLoginPage : BasePage
    {
        public IWebElement LoginIntoButton => Driver.FindElement(By.XPath("//a[contains(@class,'button desk-notif-card__login-enter-expanded')]"));
        public IWebElement LoginField => Driver.FindElement(By.XPath("//input[@id = 'passp-field-login']"));
        public IWebElement PasswordField => Driver.FindElement(By.XPath("//input[@id = 'passp-field-passwd']"));
        public IWebElement SubmitButton => Driver.FindElement(By.XPath("//button[@type = 'submit']"));
        public string loginPageUrl = "https://yandex.by/";

        public YandexLoginPage(IWebDriver driver) : base(driver) { }

        public void GoToPage()
        {
            Driver.Navigate().GoToUrl(loginPageUrl);
        }

        public YandexLoginPage TypeUsername(String username)
        {
            new Actions(Driver).SendKeys(LoginField, username).Build().Perform();
            //LoginField.SendKeys(username);

            return this;
        }

        public YandexLoginPage TypePassword(String password)
        {
            PasswordField.SendKeys(password);

            return this;
        }

        public YandexMainPage SubmitLogin()
        {
            //new Actions(Driver).Click(SubmitButton).Build().Perform();
            SubmitButton.Click();

            return new YandexMainPage(Driver);
        }

        public YandexLoginPage StartLogin()
        {
            LoginIntoButton.Click();

            return this;
        }

        public YandexMainPage LoginAs(String username, String password)
        {
            StartLogin();
            TypeUsername(username);
            SubmitLogin();
            TypePassword(password);

            return SubmitLogin();
        }
    }
}
