using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Filmrecensenterna.Model.BLL
{
    public class Film
    {
        public int FilmID { get; set; }

        public string Filmnamn { get; set; }

        public int Årtal { get; set; }
    }
}