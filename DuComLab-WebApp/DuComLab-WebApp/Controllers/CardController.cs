using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace AdminSideApplication.Controllers
{
    public class CardController : Controller
    {

        // GET: Card        
        [Authorize(Roles = "System Admin")]
        [HttpGet]
        public ActionResult ShowCards()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ViewCards(CardInput cardInput)
        {

            if (ModelState.IsValid)
            {
                CardGenerator cardGenerator = new CardGenerator(cardInput.GeneratingDate, cardInput.NumberOfCards);
                List<Card> CardList = cardGenerator.GetCardsList();
                CardDAO cardDAO = new CardDAO();
                if (!cardDAO.ISExsistCardDate(CardList[0].CardNumber))
                {
                    GridView gridView = new GridView();
                    gridView.DataSource = CardList;
                    gridView.DataBind();
                    Session["CardsListEXCEL"] = gridView;
                    Session["CardsList"] = CardList;

                    return View(CardList);
                }
                else
                {
                    ModelState.AddModelError("", "You have already generated cards on this date, so choose aonther date. ");
                    return View("ShowCards");


                }


            }
            else
            {
                ModelState.AddModelError("", "Card List is not available");
                return View("ShowCards");
            }


        }

        public ActionResult Download()
        {
            if (Session["CardsListEXCEL"] != null && Session["CardsList"] != null)
            {
                List<Card> cardList = (List<Card>)Session["CardsList"];
                CardDAO cardDAO = new CardDAO();
                try 
                { 
                    cardDAO.SaveCardsListIntoDataBase(cardList);
                    return new DownloadFileActionResult((GridView)Session["CardsListEXCEL"], "CardsListEXCEL.xls");

                }catch(Exception)
                {
                    ModelState.AddModelError("", "The Card list is already saved into the database.So,please generate new Cards");
                    return View("ShowCards");
                }
              
            }
            else
            {
                return View();
            }
        }





    }
}