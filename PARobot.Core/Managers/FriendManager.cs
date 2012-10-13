using PARobot.Core.Helper;
using PARobot.Core.JsonModels;
using PARobot.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PARobot.Core.Managers
{
    public class FriendManager
    {
        public static string FriendUrl { get; set; }

        public static List<Friend> GetMyFriends(int pageCount = 1000, int pageIndex = 1)
        {
            List<KeyValuePair<string, string>> postData = new List<KeyValuePair<string, string>>();

            postData.Add(
                new KeyValuePair<string, string>(
                "PageCount",
                pageCount.ToString()));
            postData.Add(
                new KeyValuePair<string, string>(
                "PageIndex",
                pageIndex.ToString())
            );

            string result = RequestManager.SendRequest(FriendUrl, postData, true);

            if (string.IsNullOrEmpty(result)) return null;

            JsonFriendList list = JsonHelper.JavaScriptDeserialize<JsonFriendList>(result);

            return ParseFriendJsonResult(list);
        }


        private static List<Friend> ParseFriendJsonResult(JsonFriendList list)
        {
            if (list == null) return null;

            List<Friend> friendList = new List<Friend>();

            foreach (JsonFriend jf in list.Friends)
            {
                Friend friend = new Friend
                {
                    Id = jf.UserId,
                    Level = jf.Level,
                    IsProtect = jf.IsProect,
                    HasAttack = jf.HasAttacked
                };

                friendList.Add(friend);
            }

            return friendList;
        }


        public static List<Friend> GetAllMyFriends()
        {
            return GetMyFriends(100000, 1);
        }
    }
}
