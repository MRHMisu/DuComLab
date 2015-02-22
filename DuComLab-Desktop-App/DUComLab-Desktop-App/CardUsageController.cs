using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;


namespace CyberCenterClient
{
    public class CardUsageController
    {
       private  Excel.Application xlApp;
       private Excel.Workbook xlWorkBook;
       private Excel.Worksheet xlWorkSheet;
       object misValue = System.Reflection.Missing.Value;


       public void ExpotToExcel(DataGridView dataGridView1,string SaveFilePath) 
       {
           xlApp = new Excel.Application();
           xlWorkBook = xlApp.Workbooks.Add(misValue);
           xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
           int i = 0;
           int j = 0;

           for (i = 0; i <= dataGridView1.RowCount - 1; i++)
           {
               for (j = 0; j <= dataGridView1.ColumnCount - 1; j++)
               {
                   DataGridViewCell cell = dataGridView1[j, i];
                   xlWorkSheet.Cells[i + 1, j + 1] = cell.Value;
               }
           }

           xlWorkBook.SaveAs(SaveFilePath, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
           xlWorkBook.Close(true, misValue, misValue);
           xlApp.Quit();

           releaseObject(xlWorkSheet);
           releaseObject(xlWorkBook);
           releaseObject(xlApp);

           MessageBox.Show("Your file is saved" + SaveFilePath);
            
         
       
       }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        public void SaveExcelFile(DataGridView dataGridView1,string CardNumber) 
        { 
            SaveFileDialog SaveFileDiologBox = new SaveFileDialog();
            SaveFileDiologBox.InitialDirectory = @"C:\";
            SaveFileDiologBox.Filter = "Excel files (*.xls)|*.xls";
            SaveFileDiologBox.FilterIndex = 0;
            SaveFileDiologBox.RestoreDirectory = true;
            SaveFileDiologBox.Title = "Save Card Usage History";
            SaveFileDiologBox.FileName = CardNumber + "_Usage_History";

            if (SaveFileDiologBox.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (SaveFileDiologBox.FileName != null)
                { 
                    ExpotToExcel(dataGridView1,SaveFileDiologBox.FileName);
                
                }
            }
        
        
        }
    }
}
