using Filmrecensenterna.Model.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Filmrecensenterna.Model.DAL
{
    public class MedlemDAL : DALBase
    {
      

        //Läsa en post
        public IEnumerable<Medlem> GetMedlemmar()
        {
            try
            {
                using (var conn = CreateConnection())
                {
                    var medlemmar = new List<Medlem>();

                    var cmd = new SqlCommand("appSchema.usp_GetMembers", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        var medlemIDIndex = reader.GetOrdinal("MedlemID");
                        var namnIndex = reader.GetOrdinal("Namn");
                        var adressIndex = reader.GetOrdinal("Adress");
                        var ortIndex = reader.GetOrdinal("Ort");
                        var postnrIndex = reader.GetOrdinal("Postnr");

                        while (reader.Read())
                        {
                            medlemmar.Add(new Medlem
                            {
                                MedlemID = reader.GetInt32(medlemIDIndex),
                                Namn = reader.GetString(namnIndex),
                                Adress = reader.GetString(adressIndex),
                                Ort = reader.GetString(ortIndex),
                                Postnr = reader.GetInt32(postnrIndex)
                            });
                        }
                    }

                    medlemmar.TrimExcess();

                    return medlemmar;

                }
            }
            catch (Exception)
            {
                
                throw new ApplicationException("Ett fel uppstod i samband med uppkopplingen mot databasen.");
            }


        }


        public Medlem GetMedlem(int id)
        {
            try
            {
                using (var conn = CreateConnection())
                {
                    Medlem medlem = new Medlem();

                    var cmd = new SqlCommand("appSchema.usp_GetMembers", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MedlemID", SqlDbType.Int, 4).Value = id;

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {

                        var namnIndex = reader.GetOrdinal("Namn");
                        var adressIndex = reader.GetOrdinal("Adress");
                        var ortIndex = reader.GetOrdinal("Ort");
                        var postnrIndex = reader.GetOrdinal("Postnr");

                        if (reader.Read())
                        {
                            medlem = new Medlem
                            {

                                Namn = reader.GetString(namnIndex),
                                Adress = reader.GetString(adressIndex),
                                Ort = reader.GetString(ortIndex),
                                Postnr = reader.GetInt32(postnrIndex)
                            };
                        }
                    }

                    return medlem;
                }
            }
            catch (Exception)
            {
                
                throw new ApplicationException("Ett fel uppstod i samband med uppkopplingen mot databasen.");
            }
        }
    }
 }
