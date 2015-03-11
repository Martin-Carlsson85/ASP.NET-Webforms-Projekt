using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Filmrecensenterna.Model.BLL
{
    public class Recension
    {

        //När jag hämtar
        public int RecID { get; set; }

        public string Film { get; set; }

        public string Fnamn { get; set; }
        public string Enamn { get; set; }
        public int Betyg { get; set; }

        //När jag ska lägga till och editera
        public int FilmID { get; set; }
        public int BetygID { get; set; }
        public int MedlemID { get; set; }

        public string Recension { get; set; }
    }
}