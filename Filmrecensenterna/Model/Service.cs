using Filmrecensenterna.Model.BLL;
using Filmrecensenterna.Model.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            var validationContext = new ValidationContext(toDelete);
            var validationResults = new List<ValidationResult>();
            if (!Validator.TryValidateObject(toDelete, validationContext, validationResults))
            {
                var ex = new ValidationException("Objektet klarade inte valideringen.");
                ex.Data.Add("ValidationResults", validationResults);
                throw ex;
            }

            if (toDelete.RecID == 0)
            {
                RecDAL.DeleteReview(toDelete.RecID);
            }
            else
            {
                RecDAL.DeleteReview(toDelete.RecID);
            }
            //RecDAL.DeleteReview(toDelete.RecID);
        }

        public void EditRecension(Recension toEdit)
        {
            var validationContext = new ValidationContext(toEdit);
            var validationResults = new List<ValidationResult>();
            if (!Validator.TryValidateObject(toEdit, validationContext, validationResults))
            {
                var ex = new ValidationException("Objektet klarade inte valideringen.");
                ex.Data.Add("ValidationResults", validationResults);
                throw ex;
            }

            if (toEdit.RecID == 0)
            {
                RecDAL.UpdateReview(toEdit);
            }
            else
            {
                RecDAL.UpdateReview(toEdit);
            }
            //RecDAL.UpdateReview(toEdit);
        }

        public Medlem GetMedlem(int id)
        {

            return MedlemDAL.GetMedlem(id);
        }

        public void AddRecension(Recension toAdd)
        {
            var validationContext = new ValidationContext(toAdd);
            var validationResults = new List<ValidationResult>();
            if (!Validator.TryValidateObject(toAdd, validationContext, validationResults))
            {
                var ex = new ValidationException("Objektet klarade inte valideringen.");
                ex.Data.Add("ValidationResults", validationResults);
                throw ex;
            }

            if (toAdd.RecID == 0)
            {
                RecDAL.AddReview(toAdd);
            }
            else
            {
                RecDAL.AddReview(toAdd);
            }
            //RecDAL.AddReview(toAdd);
        }

        public void AddFilm(Film toAdd)
        {
            var validationContext = new ValidationContext(toAdd);
            var validationResults = new List<ValidationResult>();
            if (!Validator.TryValidateObject(toAdd, validationContext, validationResults))
            {
                var ex = new ValidationException("Objektet klarade inte valideringen.");
                ex.Data.Add("ValidationResults", validationResults);
                throw ex;
            }

            if (toAdd.FilmID == 0)
            {
                FilmDAL.AddMovie(toAdd);
            }
            else
            {
                FilmDAL.AddMovie(toAdd);
            }
            //FilmDAL.AddMovie(toAdd);
        }

        public void DeleteFilm(Film toDelete)
        {
            var validationContext = new ValidationContext(toDelete);
            var validationResults = new List<ValidationResult>();
            if (!Validator.TryValidateObject(toDelete, validationContext, validationResults))
            {
                var ex = new ValidationException("Objektet klarade inte valideringen.");
                ex.Data.Add("ValidationResults", validationResults);
                throw ex;
            }

            if (toDelete.FilmID == 0)
            {
                FilmDAL.DeleteMovie(toDelete.FilmID);
            }
            else
            {
                FilmDAL.DeleteMovie(toDelete.FilmID);
            }
            //FilmDAL.DeleteMovie(toDelete.FilmID);
        }
        public void EditFilm(Film toEdit)
        {
            var validationContext = new ValidationContext(toEdit);
            var validationResults = new List<ValidationResult>();
            if (!Validator.TryValidateObject(toEdit, validationContext, validationResults))
            {
                var ex = new ValidationException("Objektet klarade inte valideringen.");
                ex.Data.Add("ValidationResults", validationResults);
                throw ex;
            }

            if (toEdit.FilmID == 0)
            {
                FilmDAL.UpdateMovie(toEdit);
            }
            else
            {
                FilmDAL.UpdateMovie(toEdit);
            }
            //FilmDAL.UpdateMovie(toEdit);
        }
    }
}