using Filmrecensenterna.Model.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Filmrecensenterna.Model.DAL
{
    public class FilmRecDAL : DALBase
    {
        //Skapa en post
        public void InsertFilmRecension(FilmRecension filmRec)
        {
            using (var con = CreateConnection())
            {
                try
                {
                    var cmd = new SqlCommand("appSchema.usp_AddMovieRew", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Film", SqlDbType.NVarChar, 50).Value = filmRec.film.Filmnamn;
                    cmd.Parameters.Add("@Recension", SqlDbType.NVarChar, 50).Value = filmRec.recension.Recensionen;
                    cmd.Parameters.Add("@Årtal", SqlDbType.NVarChar, 50).Value = filmRec.film.Årtal;


                    con.Open();
                    cmd.ExecuteNonQuery();

                    filmRec.film.FilmID = (int)cmd.Parameters["@FilmID"].Value;
                    filmRec.recension.BetygID = (int)cmd.Parameters["@RecID"].Value;
                }
                catch
                {
                    throw new ApplicationException("Ett fel uppstod i samband med uppkopplingen mot databasen.");
                }
            }
        }

        //Läsa en post
        public IEnumerable<FilmRecension> GetMovieRes()
        {
            using (var conn = CreateConnection())
            {
                var recensioner = new List<FilmRecension>();

                var cmd = new SqlCommand("appSchema.usp_GetMovieRes", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    var filmIndex = reader.GetOrdinal("Film");
                    var artalIndex = reader.GetOrdinal("Årtal");
                    var recensionIndex = reader.GetOrdinal("Recension");

                    while (reader.Read())
                    {
                        recensioner.Add(new FilmRecension(
                        new Film
                        {
                            Filmnamn = reader.GetString(filmIndex),
                            Årtal = reader.GetInt32(artalIndex),
                        },
                        new Recension
                        {
                            Recensionen = reader.GetString(recensionIndex)
                        }));
                    }
                }

                recensioner.TrimExcess();
                return recensioner;
            }
        }
    }
}