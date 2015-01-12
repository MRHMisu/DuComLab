using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

namespace AdminSideApplication.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                if (WebSecurity.Login(login.Email, login.Password))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Sorry, The Password or Email is Invalid");
                    return View(login);
                }

            }
            else
            {
                ModelState.AddModelError("", "Sorry, The Password or Email  is Invalid");
                return View(login);
            }
        }



        [Authorize(Roles = "System Admin")]
        [HttpGet]
        public ActionResult RegisterUser()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterUser(RegisterUser User, string UserRole)
        {

            if (ModelState.IsValid)
            {

                try
                {
                    if (UserRole != "")
                    {
                        WebSecurity.CreateUserAndAccount(User.Email, User.Password, new { Name = User.Name });
                        Roles.AddUserToRole(User.Email, UserRole);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Please Specify a Role");
                        return View();
                    }


                }
                catch (MembershipCreateUserException)
                {
                    ModelState.AddModelError("", "Sorry, the User Email already exists in this system");
                    return View(User);
                }


            }
            else
            {
                ModelState.AddModelError("", "Sorry, the User Name already exists");
                return View(User);
            }


        }

        public ActionResult Logout()
        {
            WebSecurity.Logout();
            return RedirectToAction("Index", "Home");
        }
    }
}