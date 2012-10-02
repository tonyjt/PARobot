using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PARobot.Core.Managers
{
    public class ConfigManager
    {
        public static void InitConfig()
        {
            RequestManager.RootUrl = "http://50.56.203.49:4005/api/";
            RequestManager.Credential = "iShFeoHM78LpzBC7Dn/i5LQ4aVX5uxfdU0nqrqtyw+7HeSVk6zeaTZ3cVWSUau+ZeN73aF166YYO1XfKh5KBfNFzg+5bYCoA";
            RequestManager.ClientType = "flash";
            RequestManager.ClientVersion = "3.8.0";
            #region GainManager
            GainManager.MoveUrl = "userbuilding/plan.json";
            GainManager.BowlPoint = new Models.Point{X = 38,Y = 38};
            GainManager.GainResourceUrl = "Userbuilding/FarmlandGain.json";
            GainManager.GainGoldUrl = "userbuilding/gain.json";
            #endregion
            #region LoadManager
            LoadManager.Url = "user/init.json";
            #endregion


        }
       
    }
}
