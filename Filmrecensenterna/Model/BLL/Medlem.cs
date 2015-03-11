using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Filmrecensenterna.Model.BLL
{
    public class Medlem
    {
        public int MedlemID { get; set; }

        public string Namn { get; set; }

        public string Adress { get; set; }

        public int Postnr { get; set; }

        public string Ort { get; set; }
    }
}