/*
 * Webapplikasjoner Prosjekt 1 gruppeinnlevering (høsten 2014)
 * 
 * Gruppen består av:
 * Ahmed Abdi Warsame (s180483)
 * Ole Aarnseth (s180482)
 * 
 * Modellobjekt for kunder, brukes til validering av HTML-form input fra Register av EditCustomer-Viewene. Selve kundedataene
 * lagres i DBCustomer-modellen.
 * 
 * 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Prosjekt1.Models
{
    public class Customer
    {
        [Required(ErrorMessage = "Email is required")]
        [StringLength(40)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [StringLength(100)]
        public string LoginPassword { get; set; }
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(100)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(100)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Phone Number is required")]
        [StringLength(12)]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Address is required")]
        [StringLength(50)]
        public string Address { get; set; }
        [Required(ErrorMessage = "Postal Code is required")]
        [StringLength(10)]
        public string PostalCode { get; set; }
        [Required(ErrorMessage = "City is required")]
        [StringLength(50)]
        public string City { get; set; }
    }
}