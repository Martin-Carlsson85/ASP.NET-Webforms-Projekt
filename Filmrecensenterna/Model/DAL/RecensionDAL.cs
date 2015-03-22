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
            try
            {
                using (var conn = CreateConnection())
                {
                    var recensioner = new List<Recension>();

                    var cmd = new SqlCommand("appSchema.usp_GetReview", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        var filmIDIndex = reader.GetOrdinal("FilmID");
                        var recIDIndex = reader.GetOrdinal("RecID");
                        var medlemIDIndex = reader.GetOrdinal("MedlemID");
                        var recensionIndex = reader.GetOrdinal("Recension");
                        var filmIndex = reader.GetOrdinal("Film");
                        var artalIndex = reader.GetOrdinal("Årtal");

                        while (reader.Read())
                        {
                            recensioner.Add(
                            new Recension
                            {
                                RecID = reader.GetInt32(recIDIndex),
                                FilmID = reader.GetInt32(filmIDIndex),
                                MedlemID = reader.GetInt32(medlemIDIndex),
                                Recensionen = reader.GetString(recensionIndex),
                                Film = reader.GetString(filmIndex),
                                Årtal = reader.GetInt32(artalIndex)
                            });
                        }
                    }

                    recensioner.TrimExcess();
                    return recensioner;
                }
            }
            catch (Exception)
            {
                
                throw new ApplicationException("Ett fel uppstod i samband med uppkopplingen mot databasen.");
            }
        }


        //Skapa en post
        /// <summary>
        /// Sätter in en ny post.
        /// </summary>
        /// <param name="toAdd">Posten som ska sättas in.</param>
        //        public void InsertContact(Contact toAdd)
        //        {
        //            using (var con = CreateConnection())
        //            {
        //                try
        //                {
        //                    var cmd = new SqlCommand("Person.uspAddContact", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50).Value = toAdd.FirstName;
        //                    cmd.Parameters.Add("@LastName", SqlDbType.NVarChar, 50).Value = toAdd.LastName;
        //                    cmd.Parameters.Add("@EmailAddress", SqlDbType.NVarChar, 50).Value = toAdd.EmailAddress;
        //                    cmd.Parameters.Add("@ContactID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

        //                    con.Open();
        //                    cmd.ExecuteNonQuery();

        //                    toAdd.ContactId = (int)cmd.Parameters["@ContactID"].Value;
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

        //        public void UpdateContact(Contact toAdd)
        //        {
        //            using (var con = CreateConnection())
        //            {
        //                try
        //                {
        //                    var cmd = new SqlCommand("Person.uspUpdateContact", con);
        //                    cmd.CommandType = CommandType.StoredProcedure;
        //                    cmd.Parameters.Add("@ContactID", SqlDbType.Int, 4).Value = toAdd.ContactId;
        //                    cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50).Value = toAdd.FirstName;
        //                    cmd.Parameters.Add("@LastName", SqlDbType.NVarChar, 50).Value = toAdd.LastName;
        //                    cmd.Parameters.Add("@EmailAddress", SqlDbType.NVarChar, 50).Value = toAdd.EmailAddress;

        //                    con.Open();
        //                    cmd.ExecuteNonQuery();
        //                }
        //                catch
        //                {
        //                    throw new ApplicationException("An error occured during the connection with the database.");
        //                }
        //            }
        //        }

        /// <summary>
        /// Radera en post.
        /// </summary>
        /// <param name="contactId">Raderar en p
        /// ost. Det är själva id:et som raderas.</param>
        public void DeleteReview(int recId)
        {
            using (var con = CreateConnection())
            {
                try
                {
                    var cmd = new SqlCommand("appSchema.usp_DeleteReview", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@RecID", SqlDbType.Int, 4).Value = recId;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    throw new ApplicationException("Ett fel uppstod i samband med uppkopplingen mot databasen.");
                }
            }
        }

        /// <summary>
        /// Uppdaterar en post.
        /// </summary>
        /// <param name="contact">Posten som ska uppdateras.</param>
        public void UpdateReview(Recension toEdit)
        {
            using (var con = CreateConnection())
            {
                try
                {
                    var cmd = new SqlCommand("appSchema.usp_UpdateReview", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@RecID", SqlDbType.Int, 4).Value = toEdit.RecID;
                    cmd.Parameters.Add("@FilmID", SqlDbType.Int, 4).Value = toEdit.FilmID;
                    cmd.Parameters.Add("@MedlemID", SqlDbType.Int, 4).Value = toEdit.MedlemID;
                    cmd.Parameters.Add("@Recension", SqlDbType.NVarChar, 150).Value = toEdit.Recensionen;
                    
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    throw new ApplicationException("Ett fel uppstod i samband med uppkopplingen mot databasen.");
                }
            }
        }

        public void AddReview(Recension toAdd)
        {
            using (var con = CreateConnection())
            {
                try
                {
                    var cmd = new SqlCommand("appSchema.usp_AddReview", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@RecID", SqlDbType.Int, 4).Value = toAdd.RecID;
                    cmd.Parameters.Add("@FilmID", SqlDbType.Int, 4).Value = toAdd.FilmID;
                    cmd.Parameters.Add("@MedlemID", SqlDbType.Int, 4).Value = toAdd.MedlemID;
                    cmd.Parameters.Add("@Recension", SqlDbType.NVarChar, 150).Value = toAdd.Recensionen;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    throw new ApplicationException("Ett fel uppstod i samband med uppkopplingen mot databasen.");
                }
            }
        }
    }
}