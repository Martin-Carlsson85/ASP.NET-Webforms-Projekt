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
                        
                        var fnamnIndex = reader.GetOrdinal("Fnamn");
                        var enamnIndex = reader.GetOrdinal("Enamn");
                        var adressIndex = reader.GetOrdinal("Adress");
                        var ortIndex = reader.GetOrdinal("Ort");
                        var postnrIndex = reader.GetOrdinal("Postnr");

                        while (reader.Read())
                        {
                            medlemmar.Add(new Medlem
                            {
                             
                                Fnamn = reader.GetString(fnamnIndex),
                                Enamn = reader.GetString(enamnIndex),
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
