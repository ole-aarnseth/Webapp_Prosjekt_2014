/*
 * Webapplikasjoner Prosjekt 3 individuell innlevering (høsten 2014)
 * 
 * Navn: Ole Aarnseth (s180482)
 * 
 * Dette er domenemodellen for et FAQ-spørsmål i EF-databasen.
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class FAQQuestion
    {
        public int FAQQuestionId { get; set; }
        public string QuestionText { get; set; }
        public string Answer { get; set; }

        public int FAQCategoryId { get; set; }
        public FAQCategory Category { get; set; }
    }
}
