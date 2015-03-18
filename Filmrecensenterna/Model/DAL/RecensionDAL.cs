using Filmrecensenterna.Model.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Filmrecensenterna.Model.DAL
{
    public class RecensionDAL : DALBase
    {
        //Läsa en post
        public IEnumerable<Recension> GetReview()
        {
            using (var conn = CreateConnection())
            {
                var recensioner = new List<Recension>();

                var cmd = new SqlCommand("appSchema.usp_GetReview", conn);
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


        //Skapa en post
        /// <summary>
        /// Sätter in en ny post.
        /// </summary>
        /// <param name="filmRec">Posten som ska sättas in.</param>
        //        public void InsertContact(Contact filmRec)
        //        {
        //            using (var con = CreateConnection())
        //            {
        //                try
        //                {
        //                    var cmd = new SqlCommand("Person.uspAddContact", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50).Value = filmRec.FirstName;
        //                    cmd.Parameters.Add("@LastName", SqlDbType.NVarChar, 50).Value = filmRec.LastName;
        //                    cmd.Parameters.Add("@EmailAddress", SqlDbType.NVarChar, 50).Value = filmRec.EmailAddress;
        //                    cmd.Parameters.Add("@ContactID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

        //                    con.Open();
        //                    cmd.ExecuteNonQuery();

        //                    filmRec.ContactId = (int)cmd.Parameters["@ContactID"].Value;
        //                }
        //                catch
        //                {
        //                    throw new ApplicationException("An error occured during the connection with the database.");
        //                }
        //            }
        //        }


        //        //Läsa en post

        //        public Contact GetContactById(int contactId)
        //        {
        //            using (var con = CreateConnection())
        //            {
        //                try
        //                {
        //                    var cmd = new SqlCommand("Person.uspGetContact", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add("@ContactID", SqlDbType.Int, 4).Value = contactId;

        //                    con.Open();

        //                    using (var reader = cmd.ExecuteReader())
        //                    {
        //                        var contactIdIndex = reader.GetOrdinal("ContactID");
        //                        var firstNameIndex = reader.GetOrdinal("FirstName");
        //                        var lastNameIndex = reader.GetOrdinal("LastName");
        //                        var emailAddressIndex = reader.GetOrdinal("EmailAddress");

        //                        if (reader.Read())
        //                        {
        //                            return new Contact
        //                            {
        //                                ContactId = reader.GetInt32(contactIdIndex),
        //                                FirstName = reader.GetString(firstNameIndex),
        //                                LastName = reader.GetString(lastNameIndex),
        //                                EmailAddress = reader.GetString(emailAddressIndex)
        //                            };
        //                        }

        //                        return null;
        //                    }
        //                }
        //                catch
        //                {
        //                    throw new ApplicationException("Ett fel uppstod i samband med uppkopplingen mot databasen.");
        //                }
        //            }
        //        }

        //        //Uppdatera en post

        //        public void UpdateContact(Contact filmRec)
        //        {
        //            using (var con = CreateConnection())
        //            {
        //                try
        //                {
        //                    var cmd = new SqlCommand("Person.uspUpdateContact", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add("@ContactID", SqlDbType.Int, 4).Value = filmRec.ContactId;
        //                    cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50).Value = filmRec.FirstName;
        //                    cmd.Parameters.Add("@LastName", SqlDbType.NVarChar, 50).Value = filmRec.LastName;
        //                    cmd.Parameters.Add("@EmailAddress", SqlDbType.NVarChar, 50).Value = filmRec.EmailAddress;

        //                    con.Open();
        //                    cmd.ExecuteNonQuery();
        //                }
        //                catch
        //                {
        //                    throw new ApplicationException("An error occured during the connection with the database.");
        //                }
        //            }
        //        }

        //        /// <summary>
        //        /// Radera en post.
        //        /// </summary>
        //        /// <param name="contactId">Raderar en post. Det är själva id:et som raderas.</param>
        //        public void DeleteContact(int contactId)
        //        {
        //            using (var con = CreateConnection())
        //            {
        //                try
        //                {
        //                    var cmd = new SqlCommand("Person.uspRemoveContact", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add("@ContactID", SqlDbType.Int, 4).Value = contactId;

        //                    con.Open();
        //                    cmd.ExecuteNonQuery();
        //                }
        //                catch
        //                {
        //                    throw new ApplicationException("Ett fel uppstod i samband med uppkopplingen mot databasen.");
        //                }
        //            }
        //        }
    }
}