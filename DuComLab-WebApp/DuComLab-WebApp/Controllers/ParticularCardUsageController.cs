using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
using System.Web.UI.WebControls;

namespace AdminSideApplication.Controllers
{
    public class ParticularCardUsageController : Controller
    {
        // GET: ParticularCardUsage

        [Authorize(Roles = "System Admin, Regular Admin")]
        [HttpGet]
        public ActionResult ShowCardUsage()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ViewCardUsage(SearchStudent searchStudent)
        {
            if (ModelState.IsValid)
            {
                CardDAO Card_DAO = new CardDAO();
                if (Card_DAO.ISExsistCardDate(searchStudent.CardNumber))
                {
                    RegestrationDAO Registrator = new RegestrationDAO();

                    if (Registrator.IsValidCardInDataBase(searchStudent.CardNumber))
                    {
                        ParticularCardUsageDAO CardUsage_DAO = new ParticularCardUsageDAO();
                        List<History> CardUsageList = CardUsage_DAO.ShowParticularCardHisroty(searchStudent.CardNumber).ToList();

                        GridView gridView = new GridView();
                        gridView.DataSource = CardUsageList;
                        gridView.DataBind();
                        Session["CardUsage"] = gridView;
                        return View(CardUsageList);
                    }
                    else
                    {

                        ModelState.AddModelError("", "The Card with this card number is not sold yet.So there is no student registerd with this card number.");
                        return View("ShowCardUsage");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "There is no card with this card number.Please give a valid card number.");
                    return View("ShowCardUsage");

                }
            }
            else
            {
                ModelState.AddModelError("", "The Card Number is invalid.");
                return View("ShowCardUsage");
            }

        }

        public ActionResult Download()
        {
            if (Session["CardUsage"] != null)
            {
                return new DownloadFileActionResult((GridView)Session["CardUsage"], "CardUsage.xls");
            }
            else
            {
                return View();
            }
        }
    }
}