using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CyberCenterClient.CyberCenterServices;
using System.Windows.Forms;

namespace CyberCenterClient
{
    public class LoginController:BaseController
    {
        private bool isValidInput(List<TextBox> TextList, List<Label> LabelListError)
        {

            string CardNumber = TextList[0].Text;
            string PinNumber = TextList[1].Text;
            if (CardNumber == "" || PinNumber == "")
            {
                if (CardNumber == "")
                {
                    LabelListError[0].Text = "*** Please Provide a Card Number";
                }
                else
                {
                    LabelListError[0].Text = "";
                }
                if (PinNumber == "")
                {
                    LabelListError[1].Text = "*** Please Provide the Pin Number";
                }
                else
                {
                    LabelListError[1].Text = "";
                }

                return false;
            }
            else
            {
                LabelListError[0].Text = "";
                LabelListError[1].Text = "";

                base.CardNumber = CardNumber;
                base.PinNumber = PinNumber;
                base.PcName = Environment.MachineName;
                return true;

            }

        }
       
        private bool CheckUserValidity(List<TextBox> TextList, List<Label> LabelListError)
        {
            if (isValidInput(TextList, LabelListError))
            {
                try
                {
                    if (ProxyServices.IsValidUser(CardNumber, PinNumber))
                    {
                        if (!ProxyServices.IsCardExperiedByDate(CardNumber))
                        {
                            if (ProxyServices.getUsingTime(CardNumber) < 18000)
                            {
                                if (!ProxyServices.IsActive(CardNumber))
                                {
                                    return true;

                                }
                                else
                                {
                                    MessageBox.Show("The Card is now active");
                                    return false;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Your Total Using Time is excceding Cards Time Limit");
                                return false;

                            }
                        }
                        else
                        {
                            MessageBox.Show("Your Card is Expered by 180 days");
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Card Number or Pin Number is incorrect");
                        return false;

                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("Try Again Server is not Running at that moment");
                    return false;

                }

            }
            else
            {
                return false;
            }


        }

        public CountDownTimerController LoginValidUser(List<TextBox> TextList, List<Label> LabelListError) 
        {
            if (CheckUserValidity(TextList, LabelListError))
            {
                base.CardUsageId = base.ProxyServices.getCardUsageIdAfterInsertingStartingTime(base.CardNumber,base.PcName);
                base.TotalUsingTime = base.ProxyServices.getUsingTime(base.CardNumber);
                base.ProxyServices.InsertIntoActiveSession(base.CardNumber,base.PcName);
                CountDownTimerController countDownTimer = new CountDownTimerController(CardNumber, CardUsageId, TotalUsingTime, ProxyServices);
                return countDownTimer; 
            }
            else {

                return null;
            }
        
        }
    }
}
