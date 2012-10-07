using PARobot.Core.JsonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PARobot.Core.Interfaces
{
    public interface IJsonResult
    {
        JsonStatus Status { get; set; }
    }
}
