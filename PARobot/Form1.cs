using PARobot.Core.Managers;
using PARobot.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PARobot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ConfigManager.InitConfig();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Building building = new Building();
            building.Id = 117503;
            building.Location = new Core.Models.Rectangle
            {
                Point = new Core.Models.Point
                {
                    X = 49,
                    Y = 61
                },
                Width =3,
                Length =3
            };

            GainManager.MoveToTreasureBowl(building);
        }
    }
}
