using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Filmrecensenterna.Model.BLL
{
    public class FilmRecension
    {
        public int RecID { get; set; }
        
        [Required(ErrorMessage="Ett filmnamn måste anges.")]
        [StringLength(30)]
        public Film film { get; set; }
        
        [Required(ErrorMessage="En recension måste anges.")]
        [StringLength(150)]
        public Recension recension { get; set; }

        public FilmRecension(int RecID, Film film, Recension recension)
        {
            this.RecID = RecID;
            this.film = film;
            this.recension = recension;
        }

    }
}