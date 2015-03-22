using Filmrecensenterna.Model.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Filmrecensenterna.Model.DAL
{
    public class FilmDAL : DALBase
    {


        //Läsa en post
        public IEnumerable<Film> GetMovies()
        {
            try
            {
                using (var conn = CreateConnection())
                {
                    var film = new List<Film>();

                    var cmd = new SqlCommand("appSchema.usp_GetMovies", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        var filmIndex = reader.GetOrdinal("Film");
                        var artalIndex = reader.GetOrdinal("Årtal");
                        var filmIDIndex = reader.GetOrdinal("FilmID");

                        while (reader.Read())
                        {
                            film.Add(new Film
                            {
                                FilmID = reader.GetInt32(filmIDIndex),
                                Filmnamn = reader.GetString(filmIndex),
                                Årtal = reader.GetInt32(artalIndex),
                            });
                        }
                    }

                    film.TrimExcess();
                    return film;
                }
            }
            catch (Exception)
            {

                throw new ApplicationException("Ett fel uppstod i samband med uppkopplingen mot databasen.");
            }
        }

        public void AddMovie(Film film)
        {
            try
            {
                using (var con = CreateConnection())
                {
                    var cmd = new SqlCommand("appSchema.usp_AddMovies", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@FilmID", SqlDbType.Int, 4).Value = film.FilmID;
                    cmd.Parameters.Add("@Film", SqlDbType.NVarChar, 50).Value = film.Filmnamn;
                    cmd.Parameters.Add("@Årtal", SqlDbType.NVarChar, 50).Value = film.Årtal;


                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                
                throw new ApplicationException("Ett fel uppstod i samband med uppkopplingen mot databasen.");
            }
        }

        //Uppdatera en post
        public void UpdateMovie(Film film)
        {
            try
            {

                using (var con = CreateConnection())
                {

                    var cmd = new SqlCommand("appSchema.usp_UpdateMovie", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@FilmID", SqlDbType.Int, 4).Value = film.FilmID;
                    cmd.Parameters.Add("@Film", SqlDbType.NVarChar, 50).Value = film.Filmnamn;
                    cmd.Parameters.Add("@Årtal", SqlDbType.NVarChar, 50).Value = film.Årtal;


                    con.Open();
                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception)
            {
                
                throw new ApplicationException("Ett fel uppstod i samband med uppkopplingen mot databasen.");
            }
        }


        //Radera en post
        public void DeleteMovie(int FilmId)
        {
            try
            {
                using (var con = CreateConnection())
                {
                    var cmd = new SqlCommand("appSchema.usp_DeleteMovie", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@FilmID", SqlDbType.Int, 4).Value = FilmId;

                    con.Open();
                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception)
            {
                
                throw new ApplicationException("Ett fel uppstod i samband med uppkopplingen mot databasen.");
            }
        }
    }
}