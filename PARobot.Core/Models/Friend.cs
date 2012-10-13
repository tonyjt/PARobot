using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PARobot.Core.Models
{
    public class Friend:IdBase
    {
        public string Name { get; set; }

        public int Level { get; set; }

        public bool IsProtect { get; set; }

        public bool HasAttack { get; set; }
    }
}
