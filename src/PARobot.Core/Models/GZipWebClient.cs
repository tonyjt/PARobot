using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;

namespace PARobot.Core.Models
{
    public class GZipWebClient : WebClient
    {
        /// <summary>
        /// Timeout 毫秒
        /// </summary>
        private int timeOut;

        private HttpWebRequest request = null;


        protected override WebRequest GetWebRequest(Uri address)
        {
            request = (HttpWebRequest)base.GetWebRequest(address);

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


        
        public HttpStatusCode StatusCode()
        {
            HttpStatusCode result;

            if (this.request == null)
            {
                throw (new InvalidOperationException("Unable to retrieve the status code, maybe you haven't made a request yet."));
            }

            HttpWebResponse response = base.GetWebResponse(this.request) 
                                       as HttpWebResponse;

            if (response != null)
            {
                result = response.StatusCode;
            }
            else
            {
                throw (new InvalidOperationException("Unable to retrieve the status code, maybe you haven't made a request yet."));
            }

            return result;
        }

        

    }
}
