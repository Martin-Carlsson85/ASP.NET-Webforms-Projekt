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

        private RecensionDAL _recDAL;
        private RecensionDAL RecDAL
        {
            get { return _recDAL ?? (_recDAL = new RecensionDAL()); }
        }

        private FilmDAL _filmDAL;
        private FilmDAL FilmDAL
        {
            get { return _filmDAL ?? (_filmDAL = new FilmDAL()); }
        }

        public IEnumerable<Medlem> GetMedlemmar()
        {
            return MedlemDAL.GetMedlemmar();
        }


        public IEnumerable<Recension> GetFilmRecensioner()
        {
            return RecDAL.GetReview();
        }

        public IEnumerable<Film> GetFilms()
        {
            return FilmDAL.GetMovies();
        }
        public void DeleteRecension(Recension toDelete)
        {
            RecDAL.DeleteReview(toDelete.RecID);
        }

        public void EditRecension(Recension toEdit)
        {
            RecDAL.UpdateReview(toEdit);
        }

        public Medlem GetMedlem(int id)
        {
            return MedlemDAL.GetMedlem(id);
        }

        public void AddRecension(Recension toAdd)
        {
            RecDAL.AddReview(toAdd);
        }

        public void AddFilm(Film toAdd)
        {
            FilmDAL.AddMovie(toAdd);
        }

        public void DeleteFilm(Film toDelete)
        {
            FilmDAL.DeleteMovie(toDelete.FilmID);
        }
        public void EditFilm(Film toEdit)
        {
            FilmDAL.UpdateMovie(toEdit);
        }
    }
}