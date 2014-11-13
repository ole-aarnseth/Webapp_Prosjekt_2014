/*
 * Webapplikasjoner Prosjekt 3 individuell innlevering (høsten 2014)
 * 
 * Navn: Ole Aarnseth (s180482)
 * 
 * Dette er logikklageret for FAQ-delen av nettstedet.
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BLL
{
    public class FAQBLL
    {
        private FAQDAL DAL;

        public FAQBLL()
        {
            DAL = new FAQDAL();
        }

        public List<FAQQuestion> GetQuestions()
        {
            return DAL.GetQuestions();
        }

        public List<FAQQuestion> GetQuestionsInCategory(int CategoryId)
        {
            return DAL.GetQuestionsInCategory(CategoryId);
        }

        public List<FAQCategory> GetCategories()
        {
            return DAL.GetCategories();
        }

        public bool DuplicateQuestionExists(string QuestionText)
        {
            return DAL.DuplicateQuestionExists(QuestionText);
        }

        public bool AddEmailedFAQQuestion(EmailedFAQQuestion Question)
        {
            return DAL.AddEmailedFAQQuestion(Question);
        }

        public List<EmailedFAQQuestion> GetEmailedFAQQuestions()
        {
            return DAL.GetEmailedFAQQuestions();
        }
    }
}
