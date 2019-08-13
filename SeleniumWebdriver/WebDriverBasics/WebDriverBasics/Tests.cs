using System;
using NUnit.Framework;

namespace WebDriverBasics
{
    [TestFixture]
    class Tests : BaseTest
    {
        private readonly string _username = "seleniumTestEpam4";
        private readonly string _password = "24514125s";
        private readonly string _address = "seleniumTaskEpam@mail.ru";
        private readonly string _subject = "Some subject";
        private readonly string _text = "Hello!";

        [Test]
        public void LoginWithValidCredentials()
        {
            var yandexMainPage = LoginPage.LoginAs(_username, _password);
            Assert.IsTrue(yandexMainPage.SendLetterButton.Displayed);
        }

        [Test]
        public void VerifyThatMailIPresentedInDraftFolder()
        {
            var yandexMainPage = LoginPage.LoginAs(_username, _password);
            yandexMainPage.ShowDrafts();
            int initialDraftCount = yandexMainPage.GetLettersFromFolder().Count;
            var yandexSendMessagePage = yandexMainPage.ClickSendMessageButton();
            yandexMainPage = yandexSendMessagePage.SaveAsDraft(_address, _subject, _text);
            yandexMainPage.ShowDrafts();
            int finalDraftCount = yandexMainPage.GetLettersFromFolder().Count;

            Assert.AreEqual(finalDraftCount, initialDraftCount + 1);
        }

        [Test]
        public void VerifyDraftAddress()
        {
            var yandexMainPage = LoginPage.LoginAs(_username, _password);
            var yandexSendMessagePage = yandexMainPage.ClickSendMessageButton();
            yandexMainPage = yandexSendMessagePage.SaveAsDraft(_address, _subject, _text);
            yandexMainPage.ShowDrafts();
            yandexSendMessagePage = yandexMainPage.OpenLatestLetter();
            var actualDraftAddress = yandexSendMessagePage.AddressField.Text;
            Console.WriteLine(actualDraftAddress);

            Assert.AreEqual(_address, actualDraftAddress);
        }

        [Test]
        public void VerifyDraftSubject()
        {
            var yandexMainPage = LoginPage.LoginAs(_username, _password);
            var yandexSendMessagePage = yandexMainPage.ClickSendMessageButton();
            yandexMainPage = yandexSendMessagePage.SaveAsDraft(_address, _subject, _text);
            yandexMainPage.ShowDrafts();
            yandexSendMessagePage = yandexMainPage.OpenLatestLetter();
            var actualDraftSubject = yandexSendMessagePage.SubjectField;

            Assert.AreEqual(_subject, actualDraftSubject.GetAttribute("value"));
        }

        [Test]
        public void VerifyDraftText()
        {
            var yandexMainPage = LoginPage.LoginAs(_username, _password);
            var yandexSendMessagePage = yandexMainPage.ClickSendMessageButton();
            yandexMainPage = yandexSendMessagePage.SaveAsDraft(_address, _subject, _text);
            yandexMainPage.ShowDrafts();
            yandexSendMessagePage = yandexMainPage.OpenLatestLetter();
            var actualDraftText = yandexSendMessagePage.TextField.Text;

            Assert.AreEqual(_text, actualDraftText);
        }

        [Test]
        public void VerifyThatMailIsPresentedInSendedMailsFolder()
        {
            var yandexMainPage = LoginPage.LoginAs(_username, _password);
            yandexMainPage.ShowSendedLetters();
            int initialSentMailsCount = yandexMainPage.GetLettersFromFolder().Count;
            var yandexSendMessagePage = yandexMainPage.ClickSendMessageButton();
            yandexMainPage = yandexSendMessagePage.SaveAsDraft(_address, _subject, _text);
            yandexMainPage.ShowDrafts();
            yandexSendMessagePage = yandexMainPage.OpenLatestLetter();
            yandexMainPage = yandexSendMessagePage.ClickSendLetterButton();
            yandexMainPage.ShowSendedLetters();
            int finalMailsCount = yandexMainPage.GetLettersFromFolder().Count;

            Assert.AreEqual(finalMailsCount, initialSentMailsCount + 1);
        }

        [Test]
        public void VerifyThatMailIsNotPresentedInDraftFolderAfterSanding()
        {
            var yandexMainPage = LoginPage.LoginAs(_username, _password);
            var yandexSendMessagePage = yandexMainPage.ClickSendMessageButton();
            yandexMainPage = yandexSendMessagePage.SaveAsDraft(_address, _subject, _text);
            yandexMainPage.ShowDrafts();
            int initialDraftCount = yandexMainPage.GetLettersFromFolder().Count;
            yandexSendMessagePage = yandexMainPage.OpenLatestLetter();
            yandexMainPage = yandexSendMessagePage.ClickSendLetterButton();
            yandexMainPage.ShowDrafts();
            int finalDraftCount = yandexMainPage.GetLettersFromFolder().Count;

            Assert.AreEqual(finalDraftCount, initialDraftCount - 1);
        }
    }
}
