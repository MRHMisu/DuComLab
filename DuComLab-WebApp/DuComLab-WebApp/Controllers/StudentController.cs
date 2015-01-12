using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
using System.Net;

namespace AdminSideApplication.Controllers
{
    public class StudentController : Controller
    {

        // GET: Student
        [Authorize(Roles = "System Admin, Regular Admin")]
        [HttpGet]
        public ActionResult SearchStudent()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ViewStudent(SearchStudent searchStudent)
        {

            if (ModelState.IsValid)
            {
                CardDAO Card_DAO = new CardDAO();
                if (Card_DAO.ISExsistCardDate(searchStudent.CardNumber))
                {
                    RegestrationDAO Registrator = new RegestrationDAO();
                    if (Registrator.IsValidCardInDataBase(searchStudent.CardNumber))
                    {
                        StudentDAO Student_DAO = new StudentDAO();
                        return View(Student_DAO.GetStudenInfo(searchStudent.CardNumber));
                    }
                    else
                    {
                        ModelState.AddModelError("", "The Card Number is not sold yet,so there is no student registerd with this card number");
                        return View("SearchStudent");
                    }


                }
                else
                {
                    ModelState.AddModelError("", "There is no card with this card number.Please give a valid card number");
                    return View("SearchStudent");

                }
            }
            else
            {
                ModelState.AddModelError("", "The Card Number is invalid");
                return View("SearchStudent");
            }

        }


        [Authorize(Roles = "System Admin, Regular Admin")]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            if (ModelState.IsValid)
            {
                StudentDAO Student_DAO = new StudentDAO();
                return View(Student_DAO.GetStudenInfoForEditing(id));

            }
            else
            {
                ModelState.AddModelError("", "Sorry Student information is not found.");
                return View("SearchStudent");

            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edited(Student student)
        {
            if (ModelState.IsValid)
            {
                StudentDAO Student_DAO = new StudentDAO();
                Student_DAO.UpdateStudentInfoWithStudentId(student);
                return View(Student_DAO.GetStudenInfoForEditing(student.StudentId));

            }
            else
            {
                return View("Edit");
            }


        }

        [Authorize(Roles = "System Admin, Regular Admin")]
        [HttpGet]
        public ActionResult AddCard(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            if (ModelState.IsValid)
            {
                StudentDAO Student_DAO = new StudentDAO();
                Session["StudentId"] = id;
                return View();
            }
            else
            {
                ModelState.AddModelError("", "Sorry Student information is not found.");
                return View();
            }


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCard(SearchStudent studentCardNumber)
        {
            if (ModelState.IsValid)
            {
                if (Session["StudentId"] != null)
                {

                    CardDAO Card_DAO = new CardDAO();
                    if (Card_DAO.ISExsistCardDate(studentCardNumber.CardNumber))
                    {
                        RegestrationDAO Registrator = new RegestrationDAO();
                        if (Registrator.IsCardUnsoldAndUnRegisteredWhileRegitered(studentCardNumber.CardNumber))
                        {
                            int StudentId = (Int32)Session["StudentId"];
                            Registrator.UpdateCardsTableWithStudentId(studentCardNumber.CardNumber, StudentId);
                            ModelState.AddModelError("", "The New Card is added successfully .Please check student information by searching.");
                            return View("SearchStudent");
                        }
                        else
                        {
                            ModelState.AddModelError("", "The Card is already sold,Please give an unsold card number.");
                            return View("SearchStudent");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "There is no card with this card number.Please give a valid card number.");
                        return View("SearchStudent");

                    }


                }
                else
                {
                    ModelState.AddModelError("", "Sorry Student information is not found.");
                    return View("SearchStudent");
                }


            }
            else
            {

                ModelState.AddModelError("", "Sorry Student information is not found.");
                return View("SearchStudent");
            }



        }




    }
}