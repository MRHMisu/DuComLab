using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
using System.Web.UI.WebControls;
using PagedList;
using PagedList.Mvc;

namespace AdminSideApplication.Controllers
{
    public class HistoryController : Controller
    {
        // GET: History

        [Authorize(Roles = "System Admin, Regular Admin")]
        [HttpGet]
        public ActionResult ShowHistory()
        {
            return View();
        }


        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult ViewHistory(HistoryInput historyInput,int? page)
        {
            if (ModelState.IsValid)
            {
                TimeSpan timeSpan = (historyInput.EndDate - historyInput.StartDate);
                if (timeSpan.Days >= 0)
                {
                    HistoryDAO History_DAO = new HistoryDAO();
                    List<History> HistoryList = History_DAO.ShowHisroty(historyInput.StartDate, historyInput.EndDate).ToList();

                    GridView gridView = new GridView();
                    gridView.DataSource = HistoryList;
                    gridView.DataBind();
                    Session["History"] = gridView;

                    return View(HistoryList.ToPagedList(page ?? 1,10));
                }
                else
                {
                    ModelState.AddModelError("", "Please Select a valid range with correct dates");
                    return View("ShowHistory");

                }
            }
            else
            {
                ModelState.AddModelError("", "History is not available");
                return View("ShowHistory");
            }


        }


        public ActionResult Download()
        {
            if (Session["History"] != null)
            {
                return new DownloadFileActionResult((GridView)Session["History"], "History.xls");
            }
            else
            {
                return View();
            }
        }
    }
}