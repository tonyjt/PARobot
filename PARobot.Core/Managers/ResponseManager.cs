using PARobot.Core.Helper;
using PARobot.Core.JsonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PARobot.Core.Managers
{
    public class ResponseManager
    {

        public static bool ProcessResponse(string result)
        {
            if (string.IsNullOrEmpty(result)) return false;

            try
            {
                JsonResult jsonResult = JsonHelper.JavaScriptDeserialize<JsonResult>(result);

                if (jsonResult.Status.StatusCode % 100 == 0) return true;

                else return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
