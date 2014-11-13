/*
 * Webapplikasjoner Prosjekt 3 individuell innlevering (høsten 2014)
 * 
 * Navn: Ole Aarnseth (s180482)
 * 
 * Dette er kontrollobjekt for FAQ-delen av applikasjonen, som blant annet overfører FAQ-spørsmålene fra BLL-en til Viewene.
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Model;
using Prosjekt1.ViewModels;

namespace Prosjekt1.Controllers
{
    public class FAQController : Controller
    {
        private FAQBLL BLL;

        public FAQController()
        {
            BLL = new FAQBLL();
        }

        public ActionResult Index()
        {
            var Questions = BLL.GetQuestions();

            var CategoryList = BLL.GetCategories();
            var CategorySelectList = new List<SelectListItem>();

            foreach (var Category in CategoryList)
            {
                CategorySelectList.Add(new SelectListItem()
                {
                    Text = Category.Name,
                    Value = Category.FAQCategoryId.ToString()
                });
            }

            ViewData["CategorySelect"] = CategorySelectList;

            return View(Questions);
        }

        // When a category is selected in the Category DropDown, it will do an auto postback and this method is invoked
        [HttpPost]
        public ActionResult Index(FormCollection Collection)
        {
            string SelectedCategory = Collection.Get("CategoryDropDown");

            if (SelectedCategory != "")
            {
                int CatId = Convert.ToInt32(SelectedCategory);
                var Questions = BLL.GetQuestionsInCategory(CatId);

                var CategoryList = BLL.GetCategories();
                var CategorySelectList = new List<SelectListItem>();

                foreach (var Category in CategoryList)
                {
                    CategorySelectList.Add(new SelectListItem()
                    {
                        Text = Category.Name,
                        Value = Category.FAQCategoryId.ToString()
                    });

                    if (Category.FAQCategoryId == CatId)
                    {
                        CategorySelectList.Last().Selected = true;
                    }
                }

                ViewData["CategorySelect"] = CategorySelectList;

                return View(Questions);
            }

            return RedirectToAction("Index");
        }

        public ActionResult SendFAQQuestion()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendFAQQuestion(EmailedFAQQuestionViewModel FAQQuestion)
        {
            if (ModelState.IsValid)
            {
                if (BLL.DuplicateQuestionExists(FAQQuestion.QuestionText))
                {
                    ViewBag.ErrorMessage = "This question has already been asked.";
                }

                else
                {
                    bool AddOK = BLL.AddEmailedFAQQuestion(new EmailedFAQQuestion() {
                        ContactEmail = FAQQuestion.ContactEmail,
                        QuestionText = FAQQuestion.QuestionText
                    });

                    if (AddOK)
                    {
                        return RedirectToAction("EmailedFAQAdded");
                    }

                    else
                    {
                        ViewBag.ErrorMessage = "Database error, please try again.";
                    }
                }
            }

            return View();
        }

        public ActionResult EmailedFAQAdded()
        {
            return View();
        }

        public ActionResult ViewEmailedFAQQustions()
        {
            var EmailedQuestions = BLL.GetEmailedFAQQuestions();

            return View(EmailedQuestions);
        }
    }
}