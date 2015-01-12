using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminSideApplication.Controllers
{
    public class ActiveUserController : Controller
    {
        // GET: ActiveUser


        [Authorize(Roles = "System Admin, Regular Admin")]
        [HttpGet]
        public ActionResult ViewActiveUser()
        {
            ActiveUserDAO ActiveUser_DAO = new ActiveUserDAO();
            List<ActiveUser> Active_User = ActiveUser_DAO.GetActiveUser().ToList();
            ViewData["Count"] = Active_User.Count;
            return View(Active_User);
        }


        [Authorize(Roles = "System Admin, Regular Admin")]
        [HttpGet]
        public ActionResult RefreshAll()
        {
            ActiveUserDAO ActiveUser_DAO = new ActiveUserDAO();
            ActiveUser_DAO.RefreshActiveUserList();
            return View();
        }


        [Authorize(Roles = "System Admin, Regular Admin")]
        [HttpGet]
        public ActionResult ShowParticularCard()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RefreshParticularCard(SearchStudent active_CardNumber)
        {
            if (ModelState.IsValid)
            {
                CardDAO Card_DAO = new CardDAO();
                if (Card_DAO.ISExsistCardDate(active_CardNumber.CardNumber))
                {
                    RegestrationDAO Registrator = new RegestrationDAO();
                    if (Registrator.IsValidCardInDataBase(active_CardNumber.CardNumber))
                    {
                        ActiveUserDAO ActiveUser_DAO = new ActiveUserDAO();
                        if (ActiveUser_DAO.IsActive(active_CardNumber.CardNumber))
                        {

                            ActiveUser_DAO.RefreshActiveUserListForParticularCard(active_CardNumber.CardNumber);
                            return View();

                        }
                        else
                        {
                            ModelState.AddModelError("", "The Card is not active yet .So there is no reason for removing it from the active user list");
                            return View("ShowParticularCard");
                        }

                    }
                    else
                    {
                        ModelState.AddModelError("", "The Card Number is not sold yet,so there is no student registerd with this card number");
                        return View("ShowParticularCard");

                    }
                }
                else
                {

                    ModelState.AddModelError("", "There is no card with this card number.Please give a valid card number");
                    return View("ShowParticularCard");
                }



            }
            else
            {
                ModelState.AddModelError("", "Active user not found");
                return View("ShowParticularCard");

            }
        }

    }
}