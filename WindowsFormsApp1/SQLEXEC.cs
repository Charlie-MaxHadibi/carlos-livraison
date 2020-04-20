using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLEXEC
{
    class sqlConexion2
    {
        public static SqlConnection OpenSqlConnection()
        {
            try
            {
                string BddConnex = ("persist security info=True;initial catalog=PPE2;data source=LOCALHOST;user id=DESKTOP-ONCU3TD\tmax;password=1234aqwzsx;");

                string connectionString = BddConnex;

                SqlConnection connection = new SqlConnection();

                connection.ConnectionString = connectionString;

                connection.Open();

                if (connection.State == System.Data.ConnectionState.Open || connection.State == System.Data.ConnectionState.Connecting)
                {
                    return connection;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
    //class sqlExec
    //{
    //    public Boolean execsql(string pRequest)
    //    {

    //    }
    //    public Array reqsql(string pRequest)
    //    {

    //    }

    //}
}
