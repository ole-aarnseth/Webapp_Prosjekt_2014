/*
 * Webapplikasjoner Prosjekt 3 individuell innlevering (høsten 2014)
 * 
 * Navn: Ole Aarnseth (s180482)
 * 
 * Dette er dataaksesslageret for FAQ-delen av nettstedet.
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL
{
    public class FAQDAL
    {
        public List<FAQQuestion> GetQuestions()
        {
            using (DBContext context = new DBContext())
            {
                try
                {
                    return context.FAQQuestions.ToList();
                }

                catch (Exception exc)
                {
                    ErrorLogWriter LogWriter = new ErrorLogWriter();
                    LogWriter.WriteToLogFile(exc.ToString());
                    return null;
                }
            }
        }

        public List<FAQQuestion> GetQuestionsInCategory(int CategoryId)
        {
            using (DBContext context = new DBContext())
            {
                try
                {
                    return context.FAQQuestions.Where(q => q.FAQCategoryId == CategoryId).ToList();
                }

                catch (Exception exc)
                {
                    ErrorLogWriter LogWriter = new ErrorLogWriter();
                    LogWriter.WriteToLogFile(exc.ToString());
                    return null;
                }
            }
        }

        public List<FAQCategory> GetCategories()
        {
            using (DBContext context = new DBContext())
            {
                try
                {
                    return context.FAQCategories.ToList();
                }

                catch (Exception exc)
                {
                    ErrorLogWriter LogWriter = new ErrorLogWriter();
                    LogWriter.WriteToLogFile(exc.ToString());
                    return null;
                }
            }
        }

        public bool DuplicateQuestionExists(string QuestionText)
        {
            using (DBContext context = new DBContext())
            {
                try
                {
                    var check = (from q in context.FAQQuestions
                                  where String.Compare(q.QuestionText, QuestionText, StringComparison.InvariantCultureIgnoreCase) == 0
                                  select new
                                  {
                                      QuestionText = q.QuestionText
                                  }).SingleOrDefault();

                    return check != null;
                }

                catch (Exception exc)
                {
                    ErrorLogWriter LogWriter = new ErrorLogWriter();
                    LogWriter.WriteToLogFile(exc.ToString());
                    return false;
                }
            }
        }

        public bool AddEmailedFAQQuestion(EmailedFAQQuestion Question)
        {
            using (DBContext context = new DBContext())
            {
                try
                {
                    context.EmailedFAQQuestions.Add(Question);
                    context.SaveChanges();
                }

                catch (Exception exc)
                {
                    ErrorLogWriter LogWriter = new ErrorLogWriter();
                    LogWriter.WriteToLogFile(exc.ToString());
                    return false;
                }

                return true;
            }
        }

        public List<EmailedFAQQuestion> GetEmailedFAQQuestions()
        {
            using (DBContext context = new DBContext())
            {
                try
                {
                    return context.EmailedFAQQuestions.ToList();
                }

                catch (Exception exc)
                {
                    ErrorLogWriter LogWriter = new ErrorLogWriter();
                    LogWriter.WriteToLogFile(exc.ToString());
                    return null;
                }
            }
        }
    }
}
