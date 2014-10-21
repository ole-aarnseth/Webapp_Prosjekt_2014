/*
 * Webapplikasjoner Prosjekt 1 gruppeinnlevering (høsten 2014)
 * 
 * Gruppen består av:
 * Ahmed Abdi Warsame (s180483)
 * Ole Aarnseth (s180482)
 * 
 * Modellobjekt for validering og overføring av innloggingsdata gjennom HTML-form. Brukes til innlogging av en kunde.
 * 
 * 
*/

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Prosjekt1.Models
{
    public class SignInCredentials
    {
        [Required(ErrorMessage = "Email is required")]
        [StringLength(160)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [StringLength(160)]
        public string LoginPassword { get; set; }
    }
}