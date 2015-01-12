using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
using System.Web.UI.WebControls;
using System.Net;

namespace AdminSideApplication.Controllers
{
    public class BalanceSheetController : Controller
    {
        // GET: BalanceSheet

        [Authorize(Roles = "System Admin")]
        [HttpGet]
        public ActionResult ShowBalanceSheet()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ViewBalanceSheet(BalanceSheetInput balanceSheet)
        {
            if (ModelState.IsValid)
            {
                TimeSpan timeSpan = (balanceSheet.MonthEnd - balanceSheet.MonthStart);
                if (timeSpan.Days >= 0)
                {
                    BalanceSheetDAO BalanceSheetDAO = new BalanceSheetDAO();
                    List<BalanceSheet> BalanceSheetList = BalanceSheetDAO.GetMonthlyBaanceSheet(balanceSheet.MonthStart, balanceSheet.MonthEnd, balanceSheet.UnitPrice).ToList();

                    GridView gridView = new GridView();
                    gridView.DataSource = BalanceSheetList;
                    gridView.DataBind();
                    Session["BalanceSheet"] = gridView;

                    return View(BalanceSheetList);
                }
                else
                {
                    ModelState.AddModelError("", "Please Select a valid range with correct dates");
                    return View("ShowBalanceSheet");
                }
            }
            else
            {
                ModelState.AddModelError("", "Balance Sheet is not available");
                return View("ShowBalanceSheet");

            }
        }

        public ActionResult Download()
        {
            if (Session["BalanceSheet"] != null)
            {
                return new DownloadFileActionResult((GridView)Session["BalanceSheet"], "BalanceSheet.xls");
            }
            else
            {
                return View();
            }
        }
    }
}