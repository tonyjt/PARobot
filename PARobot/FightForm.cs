using PARobot.Core.Managers;
using PARobot.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Timers;
using System.Windows.Forms;

namespace PARobot
{
    public partial class FightForm : Form
    {

        System.Timers.Timer aTimer;

        delegate void SetProgressBarStepCallback(int count);

        delegate void StopCallback();

        public int count;

        public FightForm()
        {
            InitializeComponent();
            InitTimer();
        }

        private void InitTimer()
        {
            aTimer = new System.Timers.Timer();

            aTimer.Elapsed += new ElapsedEventHandler(RunLoop);

            aTimer.Interval = 15000;

            aTimer.Enabled = true;
           
        }
        private void button1_Click(object sender, EventArgs e)
        {
            StartLoop();
        }

        private void StartLoop()
        {

            SetControlsLooping();
            aTimer.Start();
            Loop();
            count = 0;
        }


        private void StopLoop()
        {
            aTimer.Stop();
            SetControlsStop();
        }
        private void RunLoop(object source, ElapsedEventArgs e)
        {
            Loop();
        }

         private void Loop()
         {
             User user = UserManager.GetCurrentUser();

             List<Friend> friend = FightManager.GetAttackAbleFriends(user.Level);

             if (friend != null && friend.Count > 0)
             {
                 onePing();
                 StopLoop();
                 MessageBox.Show(string.Format("有{0}个可攻击好友", friend.Count));
             }
             else
             {
                 count++;
                 SetProgressBarStep(count);
             }
         }

         private void SetProgressBarStep(int count)
         {
             if (this.lblMsg.InvokeRequired)
             {
                 SetProgressBarStepCallback d = new SetProgressBarStepCallback(SetProgressBarStep);
                 this.Invoke(d, new object[] { count });
             }
             else
             {
                 lblMsg.Text = string.Format("已轮询{0}次", count);
             }
         }

         private void StopCallbackHandler()
         {
            
             if (this.lblMsg.InvokeRequired)
             {
                 StopCallback d = new StopCallback(StopCallbackHandler);
                 this.Invoke(d);
             }
             else
             {
                 SetControlsStop();
             }
         }
         
         private void SetControlsLooping()
         {
             button1.Text = "轮询中...";
             textBox1.Enabled = false;
             button1.Enabled = false;
         }
         private void SetControlsStop()
         {
             button1.Text = "轮询";
             textBox1.Enabled = true;
             button1.Enabled = true;
         }

        public void onePing(int count = 10)
        {
            for (int i = 0; i < count; i++)
            {
                SystemSounds.Beep.Play();
                Thread.Sleep(500);
            }
        }
    }
}
