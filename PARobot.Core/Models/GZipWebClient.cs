using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace PARobot.Core.Models
{
    public class GZipWebClient : WebClient
    {
        /// <summary>
        /// Timeout 毫秒
        /// </summary>
        private int timeOut;

        protected override WebRequest GetWebRequest(Uri address)
        {
            HttpWebRequest request = (HttpWebRequest)base.GetWebRequest(address);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            if (timeOut > 0) request.Timeout = timeOut;
            return request;
        }

        public GZipWebClient(int timeOut = 0)
        {
            this.Encoding = Encoding.UTF8;
            this.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            this.timeOut = timeOut;
        }



    }
}
