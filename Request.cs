using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace NewCTeam.Core
{
    public class Request
    {
        #region Property
        public List<string> Cookie
        {
            get; set;
        }

        public Dictionary<string, string> Params
        {
            get; set;
        }
        #endregion

        #region Memberfunction
        /// <summary>
        /// Constructor
        /// </summary>
        public Request()
        {
            Params = new Dictionary<string, string>();
            Cookie = new List<string>();
        }
        /// <summary>
        /// Post Method
        /// </summary>
        /// <param name="Url"></param>
        /// <returns></returns>
        public string Post(string Url)
        {
            string result = string.Empty;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.CookieContainer = new CookieContainer();
            foreach (var item in Cookie)
            {
                request.CookieContainer.SetCookies(new Uri(Url), item);
            }

            NameValueCollection postParams = HttpUtility.ParseQueryString(string.Empty);
            foreach (var item in Params)
            {
                postParams.Add(item.Key, item.Value);
            }
            //要發送的字串轉為byte[] 
            byte[] byteArray =
                Encoding.UTF8.GetBytes(
                        postParams.ToString()
                );
            using (Stream reqStream = request.GetRequestStream())
            {
                reqStream.Write(byteArray, 0, byteArray.Length);
            }

            string responseStr = "";
            //發出Request
            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader sr =
                    new StreamReader(
                        response.GetResponseStream(),
                        Encoding.UTF8))
                {
                    responseStr = sr.ReadToEnd();
                }
            }
            result = responseStr;
            return result;
        }

        /// <summary>
        /// Get Method
        /// </summary>
        /// <param name="Url"></param>
        /// <returns></returns>
        public string Get(string Url)
        {
            string result = string.Empty;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded";
            request.CookieContainer = new CookieContainer();
            foreach (var item in Cookie)
            {
                request.CookieContainer.SetCookies(new Uri(Url), item);
            }

            NameValueCollection postParams = HttpUtility.ParseQueryString(string.Empty);
            foreach (var item in Params)
            {
                postParams.Add(item.Key, item.Value);
            }
            //要發送的字串轉為byte[] 
            byte[] byteArray =
                Encoding.UTF8.GetBytes(
                        postParams.ToString()
                );
            using (Stream reqStream = request.GetRequestStream())
            {
                reqStream.Write(byteArray, 0, byteArray.Length);
            }

            string responseStr = "";
            //發出Request
            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader sr =
                    new StreamReader(
                        response.GetResponseStream(),
                        Encoding.UTF8))
                {
                    responseStr = sr.ReadToEnd();
                }
            }
            result = responseStr;
            return result;
        }
        #endregion
    }
}
