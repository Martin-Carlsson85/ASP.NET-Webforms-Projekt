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
    public partial class FilmView : System.Web.UI.Page
    {
        private static Label label;

        private Service _service;
        private Service Service {
            get { return _service ?? (_service = new Service()); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            label = (Label)Master.FindControl("RightMessage");
        }

        public IEnumerable<Film> Filmrecensionerna_GetData()
        {
            try
            {
                return Service.GetFilms();
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett fel inträffade vid hämtning utav filmer.");
                return null;
            }
        }

        public void Filmrecensionerna_InsertItem(Film toAdd)
        {
           // label = (Label)item.FindControl("RightMessage");

            try
            {
                Service.AddFilm(toAdd);
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett fel inträffade när filmen skulle läggas till.");
            }

        }

        public void Filmrecensionerna_DeleteItem(int FilmID)
        {
            //try
            //{
            Service.DeleteFilm(FilmID);
            //}
            //catch (Exception)
            //{
            //    ModelState.AddModelError(String.Empty, "Ett fel inträffade när filmen skulle tas bort.");
            //}
            
        }

        public void Filmrecensionerna_UpdateItem(Film toEdit)
        {
            try
            {
                Service.EditFilm(toEdit);
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett fel inträffade när filmen skulle uppdateras.");
            }
        }
    }
}