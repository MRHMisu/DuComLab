using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;

namespace AdminSideApplication.Controllers
{
    public class RegestrationController : Controller
    {

        // GET: Regestration

        [Authorize(Roles = "System Admin, Regular Admin")]
        [HttpGet]
        public ActionResult RegisterStudent()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisteredStudent(Regestration studentRegestration)
        {
            if (ModelState.IsValid)
            {
                CardDAO Card_DAO = new CardDAO();
                if (Card_DAO.ISExsistCardDate(studentRegestration.CardNumber))
                {
                    RegestrationDAO Registrator = new RegestrationDAO();
                    if (Registrator.IsCardUnsoldAndUnRegisteredWhileRegitered(studentRegestration.CardNumber))
                    {
                        Registrator.RegisterStudent(studentRegestration);
                        return View(studentRegestration);

                    }
                    else
                    {
                        ModelState.AddModelError("", "The Card is already sold or the card number is invalid.");
                        return View("RegisterStudent");
                    }

                }
                else
                {
                    ModelState.AddModelError("", "There is no card with this card number.Please give a valid card number");
                    return View("RegisterStudent");
                }


            }
            else
            {
                ModelState.AddModelError("", "It seems it's lacking required information");
                return View("RegisterStudent");
            }


        }
    }
}