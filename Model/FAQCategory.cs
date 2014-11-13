/*
 * Webapplikasjoner Prosjekt 3 individuell innlevering (høsten 2014)
 * 
 * Navn: Ole Aarnseth (s180482)
 * 
 * Dette er domenemodellen for en spørsmålskategori for FAQ-spørsmål i EF-databasen.
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class FAQCategory
    {
        public int FAQCategoryId { get; set; }
        public string Name { get; set; }
        public List<FAQQuestion> Questions { get; set; }
    }
}
