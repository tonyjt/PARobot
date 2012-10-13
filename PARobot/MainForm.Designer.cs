namespace PARobot
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button2 = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pb = new System.Windows.Forms.ProgressBar();
            this.btnRunInterval = new System.Windows.Forms.Button();
            this.btnFightLoop = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(144, 164);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(170, 41);
            this.button2.TabIndex = 1;
            this.button2.Text = "开动收割机";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(173, 75);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(179, 21);
            this.txtEmail.TabIndex = 2;
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(173, 137);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(179, 21);
            this.txtPwd.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(89, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "邮箱:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(89, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "密码：";
            // 
            // pb
            // 
            this.pb.Location = new System.Drawing.Point(78, 29);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(295, 23);
            this.pb.TabIndex = 6;
            this.pb.Visible = false;
            // 
            // btnRunInterval
            // 
            this.btnRunInterval.Location = new System.Drawing.Point(387, 100);
            this.btnRunInterval.Name = "btnRunInterval";
            this.btnRunInterval.Size = new System.Drawing.Size(75, 23);
            this.btnRunInterval.TabIndex = 7;
            this.btnRunInterval.Text = "登录";
            this.btnRunInterval.UseVisualStyleBackColor = true;
            this.btnRunInterval.Click += new System.EventHandler(this.btnRunInterval_Click);
            // 
            // btnFightLoop
            // 
            this.btnFightLoop.Enabled = false;
            this.btnFightLoop.Location = new System.Drawing.Point(43, 30);
            this.btnFightLoop.Name = "btnFightLoop";
            this.btnFightLoop.Size = new System.Drawing.Size(75, 23);
            this.btnFightLoop.TabIndex = 8;
            this.btnFightLoop.Text = "攻击侦查";
            this.btnFightLoop.UseVisualStyleBackColor = true;
            this.btnFightLoop.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnFightLoop);
            this.groupBox1.Location = new System.Drawing.Point(35, 227);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(426, 82);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "其他功能";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 317);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnRunInterval);
            this.Controls.Add(this.pb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.button2);
            this.Name = "MainForm";
            this.Text = "联合收割机";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar pb;
        private System.Windows.Forms.Button btnRunInterval;
        private System.Windows.Forms.Button btnFightLoop;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

