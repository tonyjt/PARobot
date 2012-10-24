using PARobot.Core.Helper;
using PARobot.Core.Interfaces;
using PARobot.Core.JsonModels;
using PARobot.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PARobot.Core.Managers
{
    public class ResponseManager
    {

        public static Result ProcessResponse(string strResult)
        {
            IJsonResult jsonResult;

            return ProcessResponse<JsonResult>(strResult, out jsonResult);
        }



        public static Result ProcessResponse<T>(string strResult, out IJsonResult jsonResult)
        {
            Result result= new Result();
            jsonResult = null;
            if (string.IsNullOrEmpty(strResult)) result.Flag = ResultFlag.Failed;

            else
            {
                try
                {
                    jsonResult = (IJsonResult)JsonHelper.JavaScriptDeserialize<T>(strResult);

                    if (jsonResult.Status.StatusCode % 100 == 0) result.Flag = ResultFlag.Success;

                    else if (jsonResult.Status.StatusCode == 201003) result.Flag = ResultFlag.EnergyNotEnough;

                    else result.Flag = ResultFlag.Failed;
                }
                catch
                {
                    result.Flag = ResultFlag.Failed;
                }
            }
            return result;
        }
    }
}
