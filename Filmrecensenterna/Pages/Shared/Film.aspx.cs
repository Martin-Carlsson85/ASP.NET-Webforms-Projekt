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
        private Service _service;
        private Service Service {
            get { return _service ?? (_service = new Service()); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public IEnumerable<Film> Filmrecensionerna_GetData()
        {
            return Service.GetFilms();
        }

        public void Filmrecensionerna_InsertItem(Film toAdd)
        {
            Service.AddFilm(toAdd);
        }

        public void Filmrecensionerna_DeleteItem(Film toDelete)
        {
            Service.DeleteFilm(toDelete);
        }

        public void Filmrecensionerna_UpdateItem(Film toEdit)
        {
            Service.EditFilm(toEdit);
        }
    }
}