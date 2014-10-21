/*
 * Webapplikasjoner Prosjekt 1 gruppeinnlevering (høsten 2014)
 * 
 * Gruppen består av:
 * Ahmed Abdi Warsame (s180483)
 * Ole Aarnseth (s180482)
 * 
 * Denne klassen består av konstanter som gis som argumenter til StoreControllers BookDetails View,
 * slik at den vet hvor brukeren kom ifra, og "back"-knappen vil dermed føre brukeren tilbake der
 * han kom.
 * 
 * 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prosjekt1.Constants
{
    public static class DetailsFromContext
    {
        // Constants used to determine from which context Details-View in StoreController is called from:
        public const int FromIndex = 0;
        public const int FromBrowseAuthor = 1;
        public const int FromBrowseGenre = 2;
        public const int FromCartIndex = 3;
    }
}