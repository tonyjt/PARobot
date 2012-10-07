using PARobot.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PARobot.Core.JsonModels
{
    public class JsonResult:IJsonResult
    {
        //{"Status":{"StatusCode":200800,"StatusMessage":"200800"},"

        public JsonStatus Status { get; set; }

    }
}
