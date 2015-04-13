using Filmrecensenterna.Model;
using Filmrecensenterna.Model.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Filmrecensenterna.Pages
{
    public partial class Recension : System.Web.UI.Page
    {
        private Service _service;
        private Service Service {
            get { return _service ?? (_service = new Service()); }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["confirmtab"] != null)
            {
                confirmholder.Visible = true;
                confirmText.Text = Session["confirmtab"] as string;
                Session.Remove("confirmtab");
                
            }
        }

        public IEnumerable<Model.BLL.Recension> Filmrecensionerna_GetData()
        {
            try
            {
                return Service.GetFilmRecensioner();
            }
            catch (Exception)
            {
                
                 ModelState.AddModelError(String.Empty, "Ett fel inträffade när filmen skulle uppdateras.");
                 return null;
            }
        }

        public string GetName(int id)
        {
            try
            {
                return Service.GetMedlem(id).Namn;
            }
            catch (Exception)
            {
                
                 ModelState.AddModelError(String.Empty, "Ett fel inträffade när filmen skulle uppdateras.");
                 return null;
            }
        }

        public IEnumerable<Film> FilmDropDownList_GetData()
        {
            try
            {
                return Service.GetFilms();
            }
            catch (Exception)
            {
                
                 ModelState.AddModelError(String.Empty, "Ett fel inträffade när filmen skulle uppdateras.");
                 return null;
            }
        }

        public IEnumerable<Medlem> PersonDropDownList_GetData()
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

        public void Filmrecensionerna_InsertItem(Model.BLL.Recension toAdd)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    Service.AddRecension(toAdd);
                    Session["confirmtab"] = "Det lyckades!";
                    Response.Redirect(Request.RawUrl);
                }
                catch (Exception)
                {

                    ModelState.AddModelError(String.Empty, "Ett fel inträffade när recensionen skulle läggas till.");
                }
            }
        }

        public void Filmrecensionerna_DeleteItem(int RecID) //Recension toDelete
        {
            try
            {
                Service.DeleteRecension(RecID); //toDelete
            }
            catch (Exception)
            {
                
                 ModelState.AddModelError(String.Empty, "Ett fel inträffade när recensionen skulle tas bort.");
            }
        }

        public void Filmrecensionerna_UpdateItem(Model.BLL.Recension toEdit)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    Service.EditRecension(toEdit);
                    Session["confirmtab"] = "Det lyckades!";
                    Response.Redirect(Request.RawUrl);
                }
                catch (Exception)
                {

                    ModelState.AddModelError(String.Empty, "Ett fel inträffade när recensionen skulle uppdateras.");
                }
            }
        }

        protected void Filmrecensenterna_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}