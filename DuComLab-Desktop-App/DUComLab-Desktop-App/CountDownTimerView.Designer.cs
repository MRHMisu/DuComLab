namespace CyberCenterClient
{
    partial class CountDownTimerView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.LabelTimer = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.Updatetimer = new System.Windows.Forms.Timer(this.components);
            this.ButtonViewCardUsage = new System.Windows.Forms.Button();
            this.buttonLogOut = new System.Windows.Forms.Button();
            this.LabelRemaningTime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LabelTimer
            // 
            this.LabelTimer.AutoSize = true;
            this.LabelTimer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(25)))), ((int)(((byte)(114)))));
            this.LabelTimer.Font = new System.Drawing.Font("Times New Roman", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelTimer.ForeColor = System.Drawing.Color.White;
            this.LabelTimer.Location = new System.Drawing.Point(5, 48);
            this.LabelTimer.Name = "LabelTimer";
            this.LabelTimer.Size = new System.Drawing.Size(191, 54);
            this.LabelTimer.TabIndex = 1;
            this.LabelTimer.Text = "300.00.0";
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // Updatetimer
            // 
            this.Updatetimer.Interval = 60000;
            this.Updatetimer.Tick += new System.EventHandler(this.Updatetimer_Tick);
            // 
            // ButtonViewCardUsage
            // 
            this.ButtonViewCardUsage.BackColor = System.Drawing.Color.White;
            this.ButtonViewCardUsage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ButtonViewCardUsage.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonViewCardUsage.ForeColor = System.Drawing.Color.Black;
            this.ButtonViewCardUsage.Location = new System.Drawing.Point(0, 156);
            this.ButtonViewCardUsage.Name = "ButtonViewCardUsage";
            this.ButtonViewCardUsage.Size = new System.Drawing.Size(116, 33);
            this.ButtonViewCardUsage.TabIndex = 3;
            this.ButtonViewCardUsage.Text = "Card Usage";
            this.ButtonViewCardUsage.UseVisualStyleBackColor = false;
            this.ButtonViewCardUsage.Click += new System.EventHandler(this.ButtonViewCardUsage_Click);
            this.ButtonViewCardUsage.MouseLeave += new System.EventHandler(this.ButtonViewCardUsage_MouseLeave);
            this.ButtonViewCardUsage.MouseHover += new System.EventHandler(this.ButtonViewCardUsage_MouseHover);
            // 
            // buttonLogOut
            // 
            this.buttonLogOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonLogOut.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogOut.Image = global::CyberCenterClient.Properties.Resources.turnoff;
            this.buttonLogOut.Location = new System.Drawing.Point(116, 107);
            this.buttonLogOut.Name = "buttonLogOut";
            this.buttonLogOut.Size = new System.Drawing.Size(89, 82);
            this.buttonLogOut.TabIndex = 2;
            this.buttonLogOut.UseVisualStyleBackColor = true;
            this.buttonLogOut.Click += new System.EventHandler(this.buttonLogOut_Click);
            // 
            // LabelRemaningTime
            // 
            this.LabelRemaningTime.AutoSize = true;
            this.LabelRemaningTime.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelRemaningTime.ForeColor = System.Drawing.Color.White;
            this.LabelRemaningTime.Location = new System.Drawing.Point(9, 9);
            this.LabelRemaningTime.Name = "LabelRemaningTime";
            this.LabelRemaningTime.Size = new System.Drawing.Size(181, 26);
            this.LabelRemaningTime.TabIndex = 4;
            this.LabelRemaningTime.Text = "Remaining Time";
            // 
            // CountDownTimerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(25)))), ((int)(((byte)(114)))));
            this.ClientSize = new System.Drawing.Size(206, 189);
            this.ControlBox = false;
            this.Controls.Add(this.LabelRemaningTime);
            this.Controls.Add(this.ButtonViewCardUsage);
            this.Controls.Add(this.buttonLogOut);
            this.Controls.Add(this.LabelTimer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(212, 195);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(212, 195);
            this.Name = "CountDownTimerView";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TransparencyKey = System.Drawing.Color.DimGray;
            this.LocationChanged += new System.EventHandler(this.TimerWindowForm_LocationChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelTimer;
        private System.Windows.Forms.Button buttonLogOut;
        private System.Windows.Forms.Button ButtonViewCardUsage;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Timer Updatetimer;
        private System.Windows.Forms.Label LabelRemaningTime;
    }
}