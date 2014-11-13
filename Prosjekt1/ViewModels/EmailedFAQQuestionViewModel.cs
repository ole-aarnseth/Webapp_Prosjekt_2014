/*
 * Webapplikasjoner Prosjekt 3 individuell innlevering (høsten 2014)
 * 
 * Navn: Ole Aarnseth (s180482)
 * 
 * Dette er en View-modell of Model/EmailedFAQQuestion, den inneholder valideringsregler som benyttes i FAQ/SendFAQQuestion-Viewet.
 * 
 */

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Prosjekt1.ViewModels
{
    public class EmailedFAQQuestionViewModel
    {
        [Required(ErrorMessage = "Email is required")]
        [StringLength(40)]
        public string ContactEmail { get; set; }

        [Required(ErrorMessage = "Question is required")]
        [StringLength(230)]
        [DataType(DataType.MultilineText)]
        public string QuestionText { get; set; }
    }
}