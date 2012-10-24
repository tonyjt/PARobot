using PARobot.Core.Helper;
using PARobot.Core.JsonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PARobot.Core.Managers
{
    public class LoadManager
    {
        public static string Url{get;set;}


        public static JsonAllInfo Load()
        {
            List<KeyValuePair<string, string>> postData = new List<KeyValuePair<string, string>>();

            postData.Add(new KeyValuePair<string, string>(
                "Credential",
                "flash"
            ));

            string result = RequestManager.SendRequest(Url, postData, true);

            if (string.IsNullOrEmpty(result)) return null;

            else return JsonHelper.JavaScriptDeserialize<JsonAllInfo>(result);

        }
    }
}
