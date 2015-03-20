using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Filmrecensenterna.Model.BLL
{
    public class FilmRecension
    {
        public int RecID { get; set; }
        public Film film { get; set; }
        public Recension recension { get; set; }

        public FilmRecension(int RecID, Film film, Recension recension)
        {
            this.RecID = RecID;
            this.film = film;
            this.recension = recension;
        }

    }
}