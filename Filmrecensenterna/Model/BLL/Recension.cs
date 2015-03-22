using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Filmrecensenterna.Model.BLL
{
    public class Recension
    {

        //När jag hämtar
        public int Årtal { get; set; }
        public int RecID { get; set; }

       // [Required]
        //[StringLength(30)]
        public string Film { get; set; }

        //[Required]
        //public string Fnamn { get; set; }

       // [Required]
        //public string Enamn { get; set; }
        public int Betyg { get; set; }

        //När jag ska lägga till och editera
        public int FilmID { get; set; }
        public int BetygID { get; set; }
        public int MedlemID { get; set; }

        [Required(ErrorMessage="En recension måste anges.")]
        [StringLength(150)]
        public string Recensionen { get; set; }
    }
}