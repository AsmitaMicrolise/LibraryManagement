using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace LibraryManagement
{
    public class DatabaseConnection
    {
       private static string ConnectionString = "Data Source=MIC383\\SQLEXPRESS;Initial Catalog=Library_System;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        public static SqlConnection getConnection()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            return connection;
        }


    }
}
