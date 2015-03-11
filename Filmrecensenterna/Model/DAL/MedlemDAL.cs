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
            using (var conn = CreateConnection())
            {
               

                    var medlemmar = new List<Medlem>();

                    var cmd = new SqlCommand("appSchema.usp_GetMembers", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        
                        var namnIndex = reader.GetOrdinal("Namn");
                        var adressIndex = reader.GetOrdinal("Adress");
                        var ortIndex = reader.GetOrdinal("Ort");
                        var postnrIndex = reader.GetOrdinal("Postnr");

                        while (reader.Read())
                        {
                            medlemmar.Add(new Medlem
                            {
                             
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
        
    }
 }
