using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace CyberCenterClient
{
    public partial class LoginView : Form
    {
        private int minitues =4;
        private int seconds = 59;
        private int milisecond = 100;
        
        List<TextBox> TextList = new List<TextBox>();
        List<Label> LabelListError = new List<Label>();
        LoginController logIntoSystem = new LoginController();
        CountDownTimerController countDownTimer;
        
       
        public LoginView()
        {
            InitializeComponent();
            AddLoginFieldComponentWithView();
            SettingComponentDinamiclly();
            Logintimer.Start();
            
        }
        private void AddLoginFieldComponentWithView()
        {
            TextList.Add(textBoxCardNumber);
            TextList.Add(textBoxPinNumber);
            LabelListError.Add(LabelCardNumberError);
            LabelListError.Add(LabelPinNumberError);
            this.Width = Screen.PrimaryScreen.Bounds.Width;
            this.Height = Screen.PrimaryScreen.Bounds.Height;
        }
        private void SettingComponentDinamiclly()
        {

            this.pictureBoxDuLogo.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxIitLogo.Location = new System.Drawing.Point((Screen.PrimaryScreen.Bounds.Width - pictureBoxIitLogo.Width - 12), 12);

            this.panelLogIn.Location = new System.Drawing.Point(((Screen.PrimaryScreen.Bounds.Width / 2) - (panelLogIn.Width / 2)) -40, ((Screen.PrimaryScreen.Bounds.Height / 2) - (panelLogIn.Height / 2)) +20);
            this.pictureBoxWelcome.Location = new System.Drawing.Point(((Screen.PrimaryScreen.Bounds.Width / 2) - (pictureBoxWelcome.Width / 2))-80, 20);

            this.panelLogInTimerInfo.Location = new System.Drawing.Point(((Screen.PrimaryScreen.Bounds.Width / 3) - (panelLogIn.Width / 2))-20, ((Screen.PrimaryScreen.Bounds.Height) - panelLogInTimerInfo.Height *4));
            this.panelFooter.Location = new System.Drawing.Point(((Screen.PrimaryScreen.Bounds.Width /2) - (panelFooter.Width / 2)-40), (Screen.PrimaryScreen.Bounds.Height - panelFooter.Height));
        }
        private void LogInForm_LocationChanged(object sender, EventArgs e)
        {
            Location = new Point(0, 0);
        }
        private void Logintimer_Tick(object sender, EventArgs e)
        {
            LabelLoginTimer.Text = minitues.ToString() + ":" + seconds.ToString() + ":" + ((milisecond % 10)).ToString();
            milisecond--;
            if (milisecond % 10 == 0)
            {
                milisecond = 100;
                seconds--;
                if (seconds % 60 == 0)
                {
                    seconds = 59;
                    minitues--;
                    if (minitues < 0)
                    {
                        Logintimer.Stop();
                        Process.Start("shutdown", "/s /t 0");

                    }

                }

            }
        }

        private void buttonSubmitt_Click(object sender, EventArgs e)
        {
            this.countDownTimer = logIntoSystem.LoginValidUser(TextList, LabelListError);
            if (countDownTimer != null)
            {
                Logintimer.Stop();
                this.Hide();
                Process.Start(@"C:\Windows\system32\userinit.exe");
                CountDownTimerView TimerWindow = new CountDownTimerView(countDownTimer);
                TimerWindow.ShowDialog();
                this.Close();
            }

        }
    }
}
