using Filmrecensenterna.Model.BLL;
using Filmrecensenterna.Model.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Filmrecensenterna.Model
{
    public class Service
    {
        private MedlemDAL _medlemDAL;

        private MedlemDAL MedlemDAL
        {
           
            get { return _medlemDAL ?? (_medlemDAL = new MedlemDAL()); }
        }

        public IEnumerable<Medlem> GetMedlemmar()
        {
            return MedlemDAL.GetMedlemmar();
        }

    }
}