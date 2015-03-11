using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Filmrecensenterna.Model.BLL
{
    public class Recension
    {
        public int RecID { get; set; }

        public int FilmID { get; set; }

        public int MedlemID { get; set; }

        public string Recensionen { get; set; }
    }
}