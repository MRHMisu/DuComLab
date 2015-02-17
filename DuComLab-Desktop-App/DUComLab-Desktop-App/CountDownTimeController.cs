using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CyberCenterClient.CyberCenterServices;
using System.Data;

namespace CyberCenterClient
{
    public class CountDownTimerController:BaseController
    {

        public int minitues;
        public int seconds;
        public int milisecond;

        public CountDownTimerController(string CardNumber, int CardUsageId, int TotalUsingTime, ProxyClientServices ProxyServices) 
        {
            base.CardNumber = CardNumber;
            base.CardUsageId = CardUsageId;
            base.TotalUsingTime = TotalUsingTime;
            base.ProxyServices = ProxyServices;
            setTimerValue();
        }

        public void setTimerValue()
        {
            this.minitues = (TotalUsingTime / 60);
            this.seconds = (TotalUsingTime % 60);
            this.milisecond = 0;
        }
        public bool LogOut()
        {
            try
            {
                base.ProxyServices.ToBeInActive(base.CardNumber);
                Updating();
                base.ProxyServices.ProxyService.Close();
                return true;

            }
            catch (Exception)
            {
                MessageBox.Show("Please Click Log Out Again Server not Respons");
                return false;

            }


        }

        public void Updating()
        {
            base.ProxyServices.UpdateFinishingTime(base.CardUsageId);
        }



    }
}
