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

                var cmd = new SqlCommand("appSchema.usp_GetMovieRew", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    var filmIndex = reader.GetOrdinal("Film");
                    var artalIndex = reader.GetOrdinal("Årtal");
                    var recensionText = reader.GetOrdinal("Recension");
                    var recensionID = reader.GetOrdinal("RecID");
                    var filmID = reader.GetOrdinal("FilmID");


                    while (reader.Read())
                    {
                        recensioner.Add(new FilmRecension(
                        reader.GetInt32(recensionID),
                        new Film
                        {
                            FilmID = reader.GetInt32(filmID),
                            Filmnamn = reader.GetString(filmIndex),
                            Årtal = reader.GetInt32(artalIndex),
                        },
                        new Recension
                        {
                            RecID = reader.GetInt32(recensionID),
                            Recensionen = reader.GetString(recensionText)
                        }));
                    }
                }
                recensioner.TrimExcess();
                return recensioner;
            }
        }
    }
}