using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Filmrecensenterna.Model.BLL
{
    public class FilmRecension
    {
        public Film film;
        public Recension recension;

        public FilmRecension(Film film, Recension recension)
        {
            this.film = film;
            this.recension = recension;
        }
    }
}