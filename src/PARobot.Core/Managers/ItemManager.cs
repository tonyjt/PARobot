using PARobot.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PARobot.Core.Managers
{
    public class ItemManager
    {
        public static string UseUrl { get; set; }

        public static Result UseItem(Item item)
        {

            List<KeyValuePair<string, string>> postData = new List<KeyValuePair<string, string>>();

            postData.Add(new KeyValuePair<string, string>(
                "pid",
                item.Id.ToString()
            ));
            string result = RequestManager.SendRequest(UseUrl, postData, true);

            
            return ResponseManager.ProcessResponse(result);
        }
    }
}
