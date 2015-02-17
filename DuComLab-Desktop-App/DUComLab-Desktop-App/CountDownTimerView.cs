using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CyberCenterClient
{
    public partial class CountDownTimerView : Form
    {
        private int minitues;
        private int seconds;
        private int milisecond;
        CountDownTimerController countDownTimer;
        bool Is_15_Minitues_NofificationSent = false;
        bool Is_5_Minitues_NofificationSent = false;
        public CountDownTimerView(CountDownTimerController countDownTimer)
        {
            InitializeComponent();
            this.countDownTimer = countDownTimer;
            this.minitues =299 - countDownTimer.minitues;
            this.seconds =59 - countDownTimer.seconds;
            this.milisecond = 100;
            if (minitues < 15) 
            { this.LabelTimer.ForeColor = System.Drawing.Color.Red; }
            timer.Start();
            Updatetimer.Start();
        
        
        }

        private void Notify_Before_15_Minitues(int minitues) 
        {
            if (minitues > 5 && minitues <15)
            {
                this.Is_15_Minitues_NofificationSent = true;
                this.LabelTimer.ForeColor = System.Drawing.Color.Red;
                MessageBox.Show("Your remaning time is less than 15 minitues");
            }
        
        }

        private void Notify_Before_5_Minitues(int minitues)
        {
            if (minitues < 5)
            {
                this.Is_5_Minitues_NofificationSent = true;
                this.LabelTimer.ForeColor = System.Drawing.Color.Red;
                MessageBox.Show("Your remaning time is less than 5 minitues");
            }

        }

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
                ForcedLogOut();
        }
        private void ForcedLogOut()
        {
            if (countDownTimer.LogOut())
            {
                timer.Stop();
                Updatetimer.Stop();
                this.Hide();
                LoginView loginScreen = new LoginView();
                loginScreen.ShowDialog();
                this.Close();
            }
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            if (minitues < 0) ForcedLogOut();
            if (Is_5_Minitues_NofificationSent == false) Notify_Before_5_Minitues(minitues);
            if (Is_15_Minitues_NofificationSent == false) Notify_Before_15_Minitues(minitues);
            LabelTimer.Text = minitues.ToString() + ":" + seconds.ToString() + ":" + ((milisecond % 10)).ToString();
            milisecond--;
            if (milisecond % 10 == 0)
            {
                milisecond = 100;
                seconds--;
                if (seconds % 60 == 0)
                {
                    seconds = 59;
                    minitues--;
                    
                    
                }

            }

        }

        private void Updatetimer_Tick(object sender, EventArgs e)
        {
            countDownTimer.Updating();

        }

        private void TimerWindowForm_LocationChanged(object sender, EventArgs e)
        {
            Location = new Point(Screen.PrimaryScreen.Bounds.Width - Width,0);
        }

        private void ButtonViewCardUsage_Click(object sender, EventArgs e)
        {
            try 
            {
                CardUsageView view = new CardUsageView(countDownTimer.ProxyServices, countDownTimer.CardNumber);
                view.ShowDialog();
            }catch(Exception)
            {
                MessageBox.Show("Your Server is not running");
            
            
            }
            

        }

        private void ButtonViewCardUsage_MouseHover(object sender, EventArgs e)
        {
            ButtonViewCardUsage.BackColor = System.Drawing.Color.Aquamarine;
        }

        private void ButtonViewCardUsage_MouseLeave(object sender, EventArgs e)
        {
            ButtonViewCardUsage.BackColor = System.Drawing.Color.White;
        }
    }
}
