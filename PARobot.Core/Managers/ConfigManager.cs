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
            RequestManager.Credential ="iShFeoHM78Jt0FNI87cQFIVa3Z2BY7hNTrBjLLuF2Ky9Pl2tMjywVcvcasxBvlOv85jhYA+S2wCK9xIXM442khOdZZfwT6MC";

            #region GainManager
            GainManager.MoveUrl = "userbuilding/plan.json";
            GainManager.BowlPoint = new Models.Point{X = 38,Y = 38};
            #endregion
            

        }
       
    }
}
