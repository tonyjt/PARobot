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
    public partial class FunctionMenu : Form
    {
        public FunctionMenu()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FightForm fightForm = new FightForm();
            fightForm.Show();
        }
    }
}
