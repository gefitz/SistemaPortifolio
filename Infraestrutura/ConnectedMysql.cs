using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql;
using MySql.Data.MySqlClient;

namespace Infraestrutura
{
    public class ConnectedMysql
    {
        public MySqlConnection Open()
        {
            /*classe para pode se conectar a banco de dados*/
            var connectionString = "Server=localhost;Database=test;Uid=root;Pwd=92253711";
            var connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();
                return connection;
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
    }
}
