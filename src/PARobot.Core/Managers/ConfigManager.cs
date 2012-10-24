using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace PARobot.Core.Managers
{
    public class ConfigManager
    {
        public static void InitConfig()
        {
            RequestManager.RootUrl = "http://50.56.203.49:4005/api/";
            //RequestManager.Credential = "iShFeoHM78LpzBC7Dn/i5LQ4aVX5uxfdU0nqrqtyw+7HeSVk6zeaTZ3cVWSUau+ZeN73aF166YYO1XfKh5KBfNFzg+5bYCoA";
            RequestManager.ClientType = "flash";
            RequestManager.ClientVersion = "3.8.0";
            RequestManager.ClientSettingVersion = GetConfig("ClientSettingVersion");
            #region BuildingManager
            BuildingManager.MoveUrl = "userbuilding/plan.json";
            #endregion

            #region GainManager
            
            GainManager.BowlPoint = new Models.Point{
                X = GetConfig("BowlPointX",38),
                Y = GetConfig("BowlPointY",22)
            };
            GainManager.GainResourceUrl = "Userbuilding/FarmlandGain.json";
            GainManager.GainGoldUrl = "userbuilding/gain.json";
            #endregion

            #region LoadManager
            LoadManager.Url = "user/init.json";
            #endregion

            #region MemberManager
            MembershipManager.LoginUrl = "User/Login.json";
            #endregion

            #region StoreManager
            StoreManager.FilePath = "data.txt";
            #endregion

            #region ItemManager
            ItemManager.UseUrl = "userprop/operating.json"; 
            #endregion

            #region FriendManager
            FriendManager.FriendUrl = GetConfig("FriendListUrl","Friends/FriendList.json");
            #endregion

            #region FightManager
            FightManager.AttackLevelDistance = GetConfig("AttackLevelDistance", 1);
            #endregion
        }


        public static string GetConfig(string key,string defaultValue="")
        {
            string value =  ConfigurationManager.AppSettings[key];
            if (string.IsNullOrEmpty(value))
            {
                value = defaultValue;
            }
            return value;
        }

        public static int GetConfig(string key, int defaulValue)
        {
            string value = GetConfig(key,"");

            int result;

            if (!int.TryParse(value, out result)) result = defaulValue;

            return result;
        }
    }
}
