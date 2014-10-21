/*
 * Webapplikasjoner Prosjekt 1 gruppeinnlevering (høsten 2014)
 * 
 * Gruppen består av:
 * Ahmed Abdi Warsame (s180483)
 * Ole Aarnseth (s180482)
 * 
 * Denne klassen består av nøkkelkonstanter som brukes for å finne igjen forskjellige Session-variabler som brukes
 * i applikasjonen.
 * 
 * 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prosjekt1.Constants
{
    public class SessionKeys
    {
        public const string CartSessionKey = "CartSessionId";
        public const string SignedInSessionKey = "SignedInId";
        public const string ReDirectToOrderReviewAfterSignInKey = "ReDirectAfterSignInId";
    }
}