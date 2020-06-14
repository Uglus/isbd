using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using System.Data.SqlClient;
//using System.Data.EntityClient;
using System.Data;

namespace Server
{
    public class DbProvider
    {
        string connectionString ;
        protected SqlConnection connection;
       // protected Ent

        public DbProvider()
        {
            connectionString = ConfigurationManager
                .ConnectionStrings["Model1Container"]
                .ConnectionString;
            connection =
                new SqlConnection(connectionString);
        }

    }
}
