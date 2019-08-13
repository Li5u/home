using System;
using System.Net;
using System.IO;

namespace JsonPlaseHolder
{
    class APIInteractor
    {
        public HttpWebRequest CreateRequest(string requestURL)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(requestURL);
            request.Method = "GET";

            return request;
        }

        public string GetResponceBoby(HttpWebRequest request)
        {
            string responceBody = String.Empty;
            HttpWebResponse responce = (HttpWebResponse)request.GetResponse();
            using (Stream s = responce.GetResponseStream())
            {
                using (StreamReader r = new StreamReader(s))
                {
                    responceBody = r.ReadToEnd();
                }
            }
            return responceBody;
        }

        public HttpWebResponse GetResponce(HttpWebRequest request)
        {
            HttpWebResponse responce = (HttpWebResponse)request.GetResponse();

            return responce;
        }
    }
}
