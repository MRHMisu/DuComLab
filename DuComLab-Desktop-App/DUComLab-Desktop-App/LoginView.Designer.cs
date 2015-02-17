namespace CyberCenterClient
{
    partial class LoginView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginView));
            this.panelLogIn = new System.Windows.Forms.Panel();
            this.labelEnterPinNumber = new System.Windows.Forms.Label();
            this.labelEnterCardNumber = new System.Windows.Forms.Label();
            this.LabelPinNumberError = new System.Windows.Forms.Label();
            this.LabelCardNumberError = new System.Windows.Forms.Label();
            this.buttonSubmitt = new System.Windows.Forms.Button();
            this.textBoxPinNumber = new System.Windows.Forms.TextBox();
            this.textBoxCardNumber = new System.Windows.Forms.TextBox();
            this.Logintimer = new System.Windows.Forms.Timer(this.components);
            this.labelSubmitInfo = new System.Windows.Forms.Label();
            this.LabelLoginTimer = new System.Windows.Forms.Label();
            this.LabelShudownInfo = new System.Windows.Forms.Label();
            this.panelLogInTimerInfo = new System.Windows.Forms.Panel();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.labelDevelopBy = new System.Windows.Forms.Label();
            this.labelPoweredBy = new System.Windows.Forms.Label();
            this.labelCopyRight = new System.Windows.Forms.Label();
            this.pictureBoxWelcome = new System.Windows.Forms.PictureBox();
            this.pictureBoxIitLogo = new System.Windows.Forms.PictureBox();
            this.pictureBoxDuLogo = new System.Windows.Forms.PictureBox();
            this.panelLogIn.SuspendLayout();
            this.panelLogInTimerInfo.SuspendLayout();
            this.panelFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWelcome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIitLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDuLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // panelLogIn
            // 
            this.panelLogIn.BackColor = System.Drawing.Color.White;
            this.panelLogIn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLogIn.Controls.Add(this.labelEnterPinNumber);
            this.panelLogIn.Controls.Add(this.labelEnterCardNumber);
            this.panelLogIn.Controls.Add(this.LabelPinNumberError);
            this.panelLogIn.Controls.Add(this.LabelCardNumberError);
            this.panelLogIn.Controls.Add(this.buttonSubmitt);
            this.panelLogIn.Controls.Add(this.textBoxPinNumber);
            this.panelLogIn.Controls.Add(this.textBoxCardNumber);
            this.panelLogIn.Cursor = System.Windows.Forms.Cursors.Default;
            this.panelLogIn.Location = new System.Drawing.Point(399, 294);
            this.panelLogIn.Name = "panelLogIn";
            this.panelLogIn.Size = new System.Drawing.Size(314, 269);
            this.panelLogIn.TabIndex = 8;
            // 
            // labelEnterPinNumber
            // 
            this.labelEnterPinNumber.AutoSize = true;
            this.labelEnterPinNumber.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEnterPinNumber.Location = new System.Drawing.Point(18, 109);
            this.labelEnterPinNumber.Name = "labelEnterPinNumber";
            this.labelEnterPinNumber.Size = new System.Drawing.Size(219, 24);
            this.labelEnterPinNumber.TabIndex = 13;
            this.labelEnterPinNumber.Text = "Enter Your Pin Number";
            // 
            // labelEnterCardNumber
            // 
            this.labelEnterCardNumber.AutoSize = true;
            this.labelEnterCardNumber.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEnterCardNumber.Location = new System.Drawing.Point(18, 10);
            this.labelEnterCardNumber.Name = "labelEnterCardNumber";
            this.labelEnterCardNumber.Size = new System.Drawing.Size(234, 24);
            this.labelEnterCardNumber.TabIndex = 12;
            this.labelEnterCardNumber.Text = "Enter Your Card Number";
            // 
            // LabelPinNumberError
            // 
            this.LabelPinNumberError.AutoSize = true;
            this.LabelPinNumberError.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelPinNumberError.ForeColor = System.Drawing.Color.Red;
            this.LabelPinNumberError.Location = new System.Drawing.Point(18, 181);
            this.LabelPinNumberError.Name = "LabelPinNumberError";
            this.LabelPinNumberError.Size = new System.Drawing.Size(0, 19);
            this.LabelPinNumberError.TabIndex = 11;
            // 
            // LabelCardNumberError
            // 
            this.LabelCardNumberError.AutoSize = true;
            this.LabelCardNumberError.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelCardNumberError.ForeColor = System.Drawing.Color.Red;
            this.LabelCardNumberError.Location = new System.Drawing.Point(18, 81);
            this.LabelCardNumberError.Name = "LabelCardNumberError";
            this.LabelCardNumberError.Size = new System.Drawing.Size(0, 19);
            this.LabelCardNumberError.TabIndex = 10;
            // 
            // buttonSubmitt
            // 
            this.buttonSubmitt.BackColor = System.Drawing.Color.White;
            this.buttonSubmitt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSubmitt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSubmitt.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSubmitt.Location = new System.Drawing.Point(91, 214);
            this.buttonSubmitt.Name = "buttonSubmitt";
            this.buttonSubmitt.Size = new System.Drawing.Size(129, 39);
            this.buttonSubmitt.TabIndex = 9;
            this.buttonSubmitt.Text = "Submit";
            this.buttonSubmitt.UseVisualStyleBackColor = false;
            this.buttonSubmitt.Click += new System.EventHandler(this.buttonSubmitt_Click);
            // 
            // textBoxPinNumber
            // 
            this.textBoxPinNumber.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPinNumber.ForeColor = System.Drawing.Color.DarkRed;
            this.textBoxPinNumber.Location = new System.Drawing.Point(20, 136);
            this.textBoxPinNumber.MaxLength = 8;
            this.textBoxPinNumber.Name = "textBoxPinNumber";
            this.textBoxPinNumber.Size = new System.Drawing.Size(273, 32);
            this.textBoxPinNumber.TabIndex = 8;
            // 
            // textBoxCardNumber
            // 
            this.textBoxCardNumber.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCardNumber.ForeColor = System.Drawing.Color.DarkRed;
            this.textBoxCardNumber.Location = new System.Drawing.Point(20, 37);
            this.textBoxCardNumber.MaxLength = 10;
            this.textBoxCardNumber.Name = "textBoxCardNumber";
            this.textBoxCardNumber.Size = new System.Drawing.Size(273, 32);
            this.textBoxCardNumber.TabIndex = 6;
            // 
            // Logintimer
            // 
            this.Logintimer.Tick += new System.EventHandler(this.Logintimer_Tick);
            // 
            // labelSubmitInfo
            // 
            this.labelSubmitInfo.AutoSize = true;
            this.labelSubmitInfo.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSubmitInfo.Location = new System.Drawing.Point(15, 11);
            this.labelSubmitInfo.Name = "labelSubmitInfo";
            this.labelSubmitInfo.Size = new System.Drawing.Size(174, 24);
            this.labelSubmitInfo.TabIndex = 11;
            this.labelSubmitInfo.Text = "Submit credentials";
            // 
            // LabelLoginTimer
            // 
            this.LabelLoginTimer.AutoSize = true;
            this.LabelLoginTimer.BackColor = System.Drawing.Color.White;
            this.LabelLoginTimer.Font = new System.Drawing.Font("Times New Roman", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelLoginTimer.ForeColor = System.Drawing.Color.Red;
            this.LabelLoginTimer.Location = new System.Drawing.Point(206, 5);
            this.LabelLoginTimer.Name = "LabelLoginTimer";
            this.LabelLoginTimer.Size = new System.Drawing.Size(88, 31);
            this.LabelLoginTimer.TabIndex = 12;
            this.LabelLoginTimer.Text = "4:59:0";
            // 
            // LabelShudownInfo
            // 
            this.LabelShudownInfo.AutoSize = true;
            this.LabelShudownInfo.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelShudownInfo.Location = new System.Drawing.Point(297, 11);
            this.LabelShudownInfo.Name = "LabelShudownInfo";
            this.LabelShudownInfo.Size = new System.Drawing.Size(409, 24);
            this.LabelShudownInfo.TabIndex = 13;
            this.LabelShudownInfo.Text = "Otherwise This PC Shuts down automatically";
            // 
            // panelLogInTimerInfo
            // 
            this.panelLogInTimerInfo.Controls.Add(this.labelSubmitInfo);
            this.panelLogInTimerInfo.Controls.Add(this.LabelLoginTimer);
            this.panelLogInTimerInfo.Controls.Add(this.LabelShudownInfo);
            this.panelLogInTimerInfo.Location = new System.Drawing.Point(282, 636);
            this.panelLogInTimerInfo.Name = "panelLogInTimerInfo";
            this.panelLogInTimerInfo.Size = new System.Drawing.Size(708, 44);
            this.panelLogInTimerInfo.TabIndex = 17;
            // 
            // panelFooter
            // 
            this.panelFooter.Controls.Add(this.labelDevelopBy);
            this.panelFooter.Controls.Add(this.labelPoweredBy);
            this.panelFooter.Controls.Add(this.labelCopyRight);
            this.panelFooter.Location = new System.Drawing.Point(277, 686);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(492, 80);
            this.panelFooter.TabIndex = 18;
            // 
            // labelDevelopBy
            // 
            this.labelDevelopBy.AutoSize = true;
            this.labelDevelopBy.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDevelopBy.ForeColor = System.Drawing.Color.Black;
            this.labelDevelopBy.Location = new System.Drawing.Point(21, 49);
            this.labelDevelopBy.Name = "labelDevelopBy";
            this.labelDevelopBy.Size = new System.Drawing.Size(468, 19);
            this.labelDevelopBy.TabIndex = 2;
            this.labelDevelopBy.Text = "Developed by B.S (Hons.) Software Engineering 5th Batch ( IIT DU )";
            // 
            // labelPoweredBy
            // 
            this.labelPoweredBy.AutoSize = true;
            this.labelPoweredBy.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPoweredBy.ForeColor = System.Drawing.Color.Black;
            this.labelPoweredBy.Location = new System.Drawing.Point(171, 30);
            this.labelPoweredBy.Name = "labelPoweredBy";
            this.labelPoweredBy.Size = new System.Drawing.Size(139, 19);
            this.labelPoweredBy.TabIndex = 1;
            this.labelPoweredBy.Text = "Powered by IIT DU";
            // 
            // labelCopyRight
            // 
            this.labelCopyRight.AutoSize = true;
            this.labelCopyRight.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCopyRight.ForeColor = System.Drawing.Color.Black;
            this.labelCopyRight.Location = new System.Drawing.Point(81, 11);
            this.labelCopyRight.Name = "labelCopyRight";
            this.labelCopyRight.Size = new System.Drawing.Size(325, 19);
            this.labelCopyRight.TabIndex = 0;
            this.labelCopyRight.Text = "© 2015 -University of Dhaka, All right reserved";
            // 
            // pictureBoxWelcome
            // 
            this.pictureBoxWelcome.Image = global::CyberCenterClient.Properties.Resources.wer;
            this.pictureBoxWelcome.Location = new System.Drawing.Point(217, 12);
            this.pictureBoxWelcome.Name = "pictureBoxWelcome";
            this.pictureBoxWelcome.Size = new System.Drawing.Size(593, 212);
            this.pictureBoxWelcome.TabIndex = 16;
            this.pictureBoxWelcome.TabStop = false;
            // 
            // pictureBoxIitLogo
            // 
            this.pictureBoxIitLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxIitLogo.Image")));
            this.pictureBoxIitLogo.Location = new System.Drawing.Point(903, 12);
            this.pictureBoxIitLogo.Name = "pictureBoxIitLogo";
            this.pictureBoxIitLogo.Size = new System.Drawing.Size(165, 173);
            this.pictureBoxIitLogo.TabIndex = 15;
            this.pictureBoxIitLogo.TabStop = false;
            // 
            // pictureBoxDuLogo
            // 
            this.pictureBoxDuLogo.Image = global::CyberCenterClient.Properties.Resources.DD;
            this.pictureBoxDuLogo.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxDuLogo.Name = "pictureBoxDuLogo";
            this.pictureBoxDuLogo.Size = new System.Drawing.Size(123, 173);
            this.pictureBoxDuLogo.TabIndex = 14;
            this.pictureBoxDuLogo.TabStop = false;
            // 
            // LoginView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1067, 738);
            this.ControlBox = false;
            this.Controls.Add(this.panelFooter);
            this.Controls.Add(this.panelLogInTimerInfo);
            this.Controls.Add(this.pictureBoxWelcome);
            this.Controls.Add(this.pictureBoxIitLogo);
            this.Controls.Add(this.pictureBoxDuLogo);
            this.Controls.Add(this.panelLogIn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginView";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.LocationChanged += new System.EventHandler(this.LogInForm_LocationChanged);
            this.panelLogIn.ResumeLayout(false);
            this.panelLogIn.PerformLayout();
            this.panelLogInTimerInfo.ResumeLayout(false);
            this.panelLogInTimerInfo.PerformLayout();
            this.panelFooter.ResumeLayout(false);
            this.panelFooter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWelcome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIitLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDuLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelLogIn;
        private System.Windows.Forms.Label LabelPinNumberError;
        private System.Windows.Forms.Label LabelCardNumberError;
        private System.Windows.Forms.Button buttonSubmitt;
        private System.Windows.Forms.TextBox textBoxPinNumber;
        private System.Windows.Forms.TextBox textBoxCardNumber;
        private System.Windows.Forms.Timer Logintimer;
        private System.Windows.Forms.Label labelSubmitInfo;
        private System.Windows.Forms.Label LabelLoginTimer;
        private System.Windows.Forms.Label LabelShudownInfo;
        private System.Windows.Forms.PictureBox pictureBoxDuLogo;
        private System.Windows.Forms.PictureBox pictureBoxIitLogo;
        private System.Windows.Forms.PictureBox pictureBoxWelcome;
        private System.Windows.Forms.Label labelEnterPinNumber;
        private System.Windows.Forms.Label labelEnterCardNumber;
        private System.Windows.Forms.Panel panelLogInTimerInfo;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Label labelDevelopBy;
        private System.Windows.Forms.Label labelPoweredBy;
        private System.Windows.Forms.Label labelCopyRight;
    }
}

