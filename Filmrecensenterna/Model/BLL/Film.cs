using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Filmrecensenterna.Model.BLL
{
    public class Film
    {
        public int FilmID { get; set; }

        [Required(ErrorMessage="Ett filmnamn måste anges.")]
        [StringLength(30)]
        public string Filmnamn { get; set; }

        [Required(ErrorMessage = "Ett årtal måste anges.")]
        public int Årtal { get; set; }
    }
}