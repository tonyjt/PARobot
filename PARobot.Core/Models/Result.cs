using PARobot.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PARobot.Core.Models
{
    public class Result:IResult
    {
        public ResultFlag Flag { get; set; }

        public int ObjectId { get; set; }
    }

    public enum ResultFlag:byte
    {
        Success = 1,
        
        Failed = 2,

        EnergyNotEnough = 3,

        
    }
}
