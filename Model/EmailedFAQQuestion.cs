/*
 * Webapplikasjoner Prosjekt 3 individuell innlevering (høsten 2014)
 * 
 * Navn: Ole Aarnseth (s180482)
 * 
 * Dette er domenemodellen for et innsendt FAQ-spørsmål i EF-databasen. Den har en tilhørende View-modell i Prosjekt1/ViewModels som inneholder
 * valideringsregler.
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class EmailedFAQQuestion
    {
        public int EmailedFAQQuestionId { get; set; }
        public string ContactEmail { get; set; }
        public string QuestionText { get; set; }
    }
}
