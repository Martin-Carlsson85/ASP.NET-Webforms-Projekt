using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Filmrecensenterna.Model.DAL
{
    public class DALBase
    {
        private static readonly string _connectionString;

        //Skapar en instans för Sql-uppkopplingen
        protected SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

        static DALBase()
        {
            _connectionString = WebConfigurationManager.ConnectionStrings["Filmrecensioner"].ConnectionString;
        }
    }
}