using System.Collections.Generic;
using NUnit.Framework;
using System.Net;
using Newtonsoft.Json;

namespace JsonPlaseHolder
{
    [TestFixture]
    class JsonPlaseHolderResponceTest
    {
        private string _responceBody;
        private HttpWebResponse _responce;

        [OneTimeSetUp]
        public void MakeRequest()
        {
            var a = new APIInteractor();
            var request = a.CreateRequest("https://jsonplaceholder.typicode.com/users");
            _responceBody = a.GetResponceBoby(request);
            _responce = a.GetResponce(request);
        }

        [Test]
        public void CheckResponseStatusCode()
        {
            Assert.IsTrue(_responce.StatusCode == HttpStatusCode.OK);
        }

        [Test]
        public void VerifyContentBodyExists()
        {
            Assert.IsNotNull(_responce.ContentType);
        }

        [Test]
        public void CompareContentBodyValue()
        {
            Assert.AreEqual(_responce.ContentType, "application/json; charset=utf-8");
        }

        [Test]
        public void VerifyResponceBody()
        {
            List<User> usersOnPage = JsonConvert.DeserializeObject<List<User>>(_responceBody);
            int expectedUsersCount = 10;

            Assert.AreEqual(expectedUsersCount, usersOnPage.Count);
        }
    }
}
