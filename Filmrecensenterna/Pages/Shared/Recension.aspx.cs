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

        }

        public IEnumerable<Model.BLL.Recension> Filmrecensionerna_GetData()
        {
            return Service.GetFilmRecensioner();
        }

        public string GetName(int id)
        {
            return Service.GetMedlem(id).Namn;
        }

        public IEnumerable<Film> FilmDropDownList_GetData()
        {
            return Service.GetFilms();
        }

        public IEnumerable<Medlem> PersonDropDownList_GetData()
        {
            return Service.GetMedlemmar();
        }

        public void Filmrecensionerna_InsertItem(Model.BLL.Recension toAdd)
        {
            Service.AddRecension(toAdd);
        }

        public void Filmrecensionerna_DeleteItem(Model.BLL.Recension toDelete)
        {
            Service.DeleteRecension(toDelete);
        }

        public void Filmrecensionerna_UpdateItem(Model.BLL.Recension toEdit)
        {
            Service.EditRecension(toEdit);
        }
    }
}