using Filmrecensenterna.Model;
using Filmrecensenterna.Model.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Filmrecensenterna.Pages.Shared
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        private Service _service;

        private Service Service
        {
        
            get { return _service ?? (_service = new Service()); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

    
        public IEnumerable<Medlem> Medlemslist_GetData()
        {
            try
            {
                return Service.GetMedlemmar();
            }
            catch (Exception)
            {
                
                 ModelState.AddModelError(String.Empty, "Ett fel inträffade när filmen skulle uppdateras.");
                 return null;
            }
        }
    }
}