using PARobot.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;

namespace PARobot.Core.Managers
{
    public class RequestManager
    {
        public static string RootUrl { get; set; }

        public static string Credential { get; set; }

        public static string ClientType { get; set; }

        public static string ClientVersion{get;set;}

        public static string ClientSettingVersion { get; set; }

        public static string SendRequest(string actionPath, IEnumerable<KeyValuePair<string, string>> postData, bool isPost = false, int timeOut = 0)
        {
            string data = GenerateQueryString(postData);

            string url = GenerateUrl(RootUrl, actionPath);

            return SendRequest(url, data, isPost,timeOut);
        }

        private static string GenerateQueryString(IEnumerable<KeyValuePair<string, string>> data)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in data)
            {
                if (!string.IsNullOrEmpty(item.Key)
                    && !string.IsNullOrEmpty(item.Value))
                {
                    if (sb.Length != 0)
                        sb.Append("&");

                    sb.AppendFormat("{0}={1}", item.Key,item.Value);
                }
            }
            return sb.ToString();
        }

        private static string GenerateUrl(string rootUrl,string partUrl)
        {
            return rootUrl + partUrl;
        }

        /// <summary>
        /// 发送请求
        /// </summary>
        /// <param name="url">Url</param>
        /// <param name="isPost">是否Post</param>
        /// <param name="timeOut">过期时间（为0则不设置过期时间）</param>
        /// <returns></returns>
        private static  string SendRequest(string url,string data, bool isPost = true, int timeOut = 0)
        {
            GZipWebClient webClient = new GZipWebClient(timeOut);
            webClient.Headers.Add("Credential", Credential);
            webClient.Headers.Add("ClientType", ClientType);
            webClient.Headers.Add("ClientVersion", ClientVersion);
            webClient.Headers.Add("Referer", "http://www.idfgame.com/New2.swf");
            webClient.Headers.Add("ClientSettingVersion", ClientSettingVersion);
            try
            {
                string returnResponse = "";
                if (!isPost)
                {
                    string address = string.Format("{0}?{1}",url,data);

                    StreamReader Reader = new StreamReader(webClient.OpenRead(address), Encoding.UTF8);

                    returnResponse = Reader.ReadToEnd();
                }
                else
                {

                    returnResponse = webClient.UploadString(url, data);
                }
                Credential = webClient.ResponseHeaders["Credential"];

                if (webClient.StatusCode() != HttpStatusCode.OK) return "";

                return returnResponse;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
