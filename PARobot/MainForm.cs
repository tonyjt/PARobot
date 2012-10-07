using PARobot.Core.Managers;
using PARobot.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace PARobot
{
    public partial class MainForm : Form
    {
        public string Email { get; set; }

        public string Password { get; set; }

        delegate void SetProgressBarMaxCallback(int count);
        delegate void SetProgressBarStepCallback(int count);
        delegate void SetCompleateCallback();
        delegate void ShowGainFailedCallback(string message);

        public MainForm()
        {
            InitializeComponent();
            ConfigManager.InitConfig();
            LoadInitData();
            InitDelegate();
        }

        public void LoadInitData()
        {
            Email = StoreManager.Read("Email");
            Password = StoreManager.Read("Password");
            txtEmail.Text = Email;
            txtPwd.Text = Password;
            pb.Minimum = 0;
            pb.Step = 1;
            
        }

        public void SaveData()
        {
            Email = txtEmail.Text;
            StoreManager.Save("Email", Email);

            Password = txtPwd.Text;
            StoreManager.Save("Password", Password);
        }
        public void InitDelegate()
        {
            GainManager.Start = new GainManager.GainDelegate(StartGainHandler);
            GainManager.GainComplelte = new GainManager.GainDelegate(GainCompleteHandler);
            GainManager.GainFailed = new GainManager.GainFailedMessage(GainFailedHandler);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtEmail.Text = txtEmail.Text.Trim();
            txtPwd.Text = txtPwd.Text.Trim();

            StartGain();

            Thread newThread = new Thread(new ThreadStart(Gain));
            newThread.Start();
        }

        private void StartGain()
        {
            txtEmail.Enabled = false;
            txtPwd.Enabled = false;
            button2.Enabled = false;
            pb.Visible = true;
            pb.Value = 0;
        }

        private void StopGain()
        {
            txtEmail.Enabled = true;
            txtPwd.Enabled = true;
            button2.Enabled = true;
            pb.Visible = false;
        }

        private void Gain()
        {
            if (MembershipManager.Login(txtEmail.Text, txtPwd.Text).Flag == ResultFlag.Success)
            {
                //Save Password
                SaveData();

                List<Building> buildings = BuildingManager.GetAllBuildings();

                MessageBox.Show("收割完成，建筑物数量为:" + GainManager.GainAll(buildings).ToString());

            }
            else
            {
                MessageBox.Show("登录失败");
            }

            SetCompleate();
        }
        #region Thread Safe
        private void SetProgressBarMax(int count)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.pb.InvokeRequired)
            {
                SetProgressBarMaxCallback d = new SetProgressBarMaxCallback(SetProgressBarMax);
                this.Invoke(d, new object[] { count });
            }
            else
            {
                this.pb.Maximum = count;
            }
        }

        private void SetProgressBarStep(int count)
        {
            if (this.pb.InvokeRequired)
            {
                SetProgressBarStepCallback d = new SetProgressBarStepCallback(SetProgressBarStep);
                this.Invoke(d, new object[] { count });
            }
            else
            {
                this.pb.PerformStep();
            }
        }

        private void SetCompleate()
        {
            if (this.pb.InvokeRequired)
            {
                SetCompleateCallback d = new SetCompleateCallback(SetCompleate);
                this.Invoke(d);
            }
            else
            {
                StopGain();
            }
        }

        private void ShowGainFailed(string message)
        {
            if (this.pb.InvokeRequired)
            {
                ShowGainFailedCallback d = new ShowGainFailedCallback(ShowGainFailed);
                this.Invoke(d, new object[] { message });
            }
            else
            {
                MessageBox.Show(message);
                StopGain();
            }
        }


        #endregion
        #region DelegateHandler
        public void StartGainHandler(int count)
        {
            SetProgressBarMax(count);
        }
        public void GainCompleteHandler(int count)
        {
            SetProgressBarStep(count);
        }

        public void GainFailedHandler(string message)
        {
            ShowGainFailed(message);
        }
        #endregion
    }
}
