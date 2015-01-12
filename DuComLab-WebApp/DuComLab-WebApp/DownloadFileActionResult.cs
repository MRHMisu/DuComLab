using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminSideApplication
{

    public class DownloadFileActionResult : ActionResult
    {
        public GridView ExcelGridView { get; set; }
        public string FileName { get; set; }


        public DownloadFileActionResult(GridView gridView, string FileName)
        {
            this.ExcelGridView = gridView;
            this.FileName = FileName;
        }


        public override void ExecuteResult(ControllerContext context)
        {

            //Create a response stream to create and write the Excel file
            HttpContext responsContext = HttpContext.Current;
            responsContext.Response.Clear();
            responsContext.Response.AddHeader("content-disposition", "attachment;filename=" + FileName);
            responsContext.Response.Charset = "";
            responsContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            responsContext.Response.ContentType = "application/vnd.ms-excel";

            //Convert the rendering of the gridview to a string representation 
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            ExcelGridView.RenderControl(htw);

            //Open a memory stream that you can use to write back to the response
            byte[] byteArray = Encoding.ASCII.GetBytes(sw.ToString());
            MemoryStream memoryStream = new MemoryStream(byteArray);
            StreamReader streamReader = new StreamReader(memoryStream, Encoding.ASCII);

            //Write the stream back to the response
            responsContext.Response.Write(streamReader.ReadToEnd());
            responsContext.Response.End();

        }

    }
}