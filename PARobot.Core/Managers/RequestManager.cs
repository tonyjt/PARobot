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

        public static string Post(string actionPath, IEnumerable<KeyValuePair<string, string>> postData)
        {
            string data = GenerateQueryString(postData);

            byte[] tPostData = Encoding.Default.GetBytes(data);

            string url = GenerateUrl(RootUrl, actionPath);

            var stream = DownLoadStream(url, "", true, tPostData, 300, null);

            if (stream != null)
            {
                using (System.IO.StreamReader sr = new StreamReader(stream, Encoding.Default))
                {
                    return sr.ReadToEnd();
                }
            }
            else
                return null;
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
        /// PSOT 方式下载指定 URL 的流数据内容, 本方法可指定待下载页面的引用页面/页面编码/下载超时时间/HTTP 代理
        /// </summary>
        /// <param name="url">待下载 URL</param>
        /// <param name="headerReferer">待下载页面的引用页</param>
        /// <param name="isPost">是否 POST 方式下载页面</param>
        /// <param name="postData">POST 方式下载页面的参数</param>
        /// <param name="pageEncoding">待下载页面的页面编码</param>
        /// <param name="timeout">下载页面的超时时间, -1 将忽略本项, 单位:毫秒, 默认值为 100,000 毫秒</param>
        /// <param name="webProxy">当前下载操作使用的 HTTP 代理</param>
        /// <returns>下载得到的页面流数据, 如果下载失败返回 NULL</returns>
        /// <exception cref="ArgumentNullException">url is null</exception>
        public static Stream DownLoadStream(string url, string headerReferer, bool isPost, byte[] postData, int timeout, IWebProxy webProxy)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentNullException("url", "[url] null...");

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                {
                    request.Accept = "*/*";

                    if (webProxy != null)
                        request.Proxy = webProxy;

                    if (!string.IsNullOrEmpty(headerReferer))
                        request.Referer = headerReferer;

                    if (timeout > 0)
                        request.Timeout = timeout;

                    // request.Headers["Cookie"] = "ASPSESSIONIDSATSACRA=FDAANHLDOGLMEDOMKGOEBHFK";

                    #region 拼接 POST 数据
                    if (isPost)
                    {
                        request.Method = "POST";
                        request.ContentType = "application/x-www-form-urlencoded";

                        if (postData != null && postData.Length != 0)
                        {
                            request.ContentLength = postData.Length;

                            using (Stream requestStream = request.GetRequestStream())
                            {
                                requestStream.Write(postData, 0, postData.Length);
                            }
                        }
                        else
                            request.ContentLength = 0l;
                    }
                    #endregion

                    request.Headers["Accept-Language"] = "zh-cn";
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; Trident/4.0; Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1) ; InfoPath.2; .NET CLR 2.0.50727; CIBA; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729; .NET4.0C; .NET4.0E)";
                    request.Headers["Credential"] = Credential;

                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        MemoryStream stream = new MemoryStream();
                        var resStream = response.ContentEncoding != "gzip"  //解压某些WEB服务器强行响应 GZIP 数据
                                            ? response.GetResponseStream()
                                            : new GZipStream(response.GetResponseStream(), CompressionMode.Decompress);

                        byte[] buffer = new byte[1024];
                        int len = 0;
                        while ((len = resStream.Read(buffer, 0, 1024)) > 0)
                        {
                            stream.Write(buffer, 0, len);
                        }

                        stream.Seek(0, SeekOrigin.Begin); //INFO 下载的流数据把起始位置设到开始, 否则对流数据的接下来的操作会有莫名 BUG
                        return stream;
                    }
                }
            }
            catch (Exception ex)
            {
                //LogManager.Instance.Error(null, url, headerReferer, ex);
                ex = null;
            }
            return null;
        } 
    }
}
