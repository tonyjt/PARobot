using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PARobot.Core.Models
{
    public class User:IdBase
    {
        public int Level { get; set; }

        public int Gold { get; set; }

        public int GameCurrency { get; set; }

        public int Energy { get; set; }

        public int Food { get; set; }

        public int Iron { get; set; }

        public int Oil { get; set; }
    }
}
