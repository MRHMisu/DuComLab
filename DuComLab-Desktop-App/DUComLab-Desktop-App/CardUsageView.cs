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
    public partial class CardUsageView : Form
    {
        private string CardNumber;
        public CardUsageView(ProxyClientServices ProxyService,string CardNumber)
        {
            InitializeComponent();
            showdata(ProxyService, CardNumber);
            this.CardNumber = CardNumber;
            this.Text = "View Card Usage for Card Number: " + CardNumber;
            LabelTittleCardNumber.Text = LabelTittleCardNumber.Text + CardNumber;
        }

        private void showdata(ProxyClientServices ProxyService,string CardNumber){
            DataSet dataSet = new DataSet();
            dataSet = ProxyService.ViewCardUsage(CardNumber);
            if (dataSet != null)
            {
                CardUsageGridView.DataSource = dataSet.Tables[0];
                CardUsageGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);


            }

            
        }

        private void ButtonSaveExcel_Click(object sender, EventArgs e)
        {
            try 
            {
                CardUsageController Export = new CardUsageController();
                Export.SaveExcelFile(CardUsageGridView,CardNumber);
            
            }catch(Exception)
            {
                MessageBox.Show("Sorry The System can't export your history");

            
            }


        }
    }
}
