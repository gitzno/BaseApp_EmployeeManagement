using Infrastructure.Interfaces;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DatabaseContext
{

    public class MariaDBContext : IDbContextMaria
    {
        public IDbConnection Connection { get; }
        #region attribute
        protected readonly string ConnectionString = "" +
            "Server = 8.222.228.150;" +
            " Port = 3306; " +
            "Database = W08.HTTHUY.MF1774; " +
            "User Id = nvmanh; " +
            "Password = 12345678;";

        #endregion
        #region constructor
        public MariaDBContext()
        {
            Connection = new MySqlConnection(ConnectionString);
        }

        #endregion
    }
}
