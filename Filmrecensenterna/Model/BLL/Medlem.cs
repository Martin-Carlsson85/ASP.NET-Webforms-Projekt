using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Filmrecensenterna.Model.BLL
{
    public class Medlem
    {
        public int MedlemID { get; set; }

        //[Required]
        public string Namn { get; set; }

        //[Required]
        public string Adress { get; set; }

        public int Postnr { get; set; }

        //[Required]
        public string Ort { get; set; }
    }
}