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
        //Skapa en post
        /// <summary>
        /// Sätter in en ny post.
        /// </summary>
        /// <param name="contact">Posten som ska sättas in.</param>
//        public void InsertContact(Contact contact)
//        {
//            using (var con = CreateConnection())
//            {
//                try
//                {
//                    var cmd = new SqlCommand("Person.uspAddContact", con);
//                    cmd.CommandType = CommandType.StoredProcedure;
//                    cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50).Value = contact.FirstName;
//                    cmd.Parameters.Add("@LastName", SqlDbType.NVarChar, 50).Value = contact.LastName;
//                    cmd.Parameters.Add("@EmailAddress", SqlDbType.NVarChar, 50).Value = contact.EmailAddress;
//                    cmd.Parameters.Add("@ContactID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

//                    con.Open();
//                    cmd.ExecuteNonQuery();

//                    contact.ContactId = (int)cmd.Parameters["@ContactID"].Value;
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

//        public void UpdateContact(Contact contact)
//        {
//            using (var con = CreateConnection())
//            {
//                try
//                {
//                    var cmd = new SqlCommand("Person.uspUpdateContact", con);
//                    cmd.CommandType = CommandType.StoredProcedure;
//                    cmd.Parameters.Add("@ContactID", SqlDbType.Int, 4).Value = contact.ContactId;
//                    cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50).Value = contact.FirstName;
//                    cmd.Parameters.Add("@LastName", SqlDbType.NVarChar, 50).Value = contact.LastName;
//                    cmd.Parameters.Add("@EmailAddress", SqlDbType.NVarChar, 50).Value = contact.EmailAddress;

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