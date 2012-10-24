using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PARobot.Core.Managers;
using PARobot.Core.Models;

namespace PARobot
{
    public partial class UpgradeForm : Form
    {
        public UpgradeForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int exp = ParseExp();

            if(exp <=0) {
                MessageBox.Show("请输入5的倍数的正整数");
                return;
            }

            Item item = new Item{
                Id = 1103
            };
            if (comboBox1.SelectedIndex == 1)
                item.Id = 1106;
            string message;

            if (MembershipManager.Login().Flag == ResultFlag.Success)
            {

                int actualExps = UpgradeManager.AddExp(exp, GainManager.BowlPoint, item);

                if (actualExps < exp)
                {
                    message = string.Format("出现问题，已转换{0}点体力", actualExps);
                }
                else message = string.Format("转换{0}点经验成功", actualExps);
            }
            else message = "登录失败，请稍后重试";

            MessageBox.Show(message);
        }

        private int ParseExp()
        {
            int exp;
            if (!int.TryParse(txtExp.Text, out exp))
            {
                exp = 0;
            }

            return exp;
        }

        private void UpgradeForm_Load(object sender, EventArgs e)
        {
            this.comboBox1.SelectedIndex = 0;
        }
    }
}
