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
        string connectionString = "Server=localhost;Database=fitz;Uid=root;Pwd=92253711";
        public MySqlConnection Open()
        {
            /*classe para pode se conectar a banco de dados*/
            var connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();
                return connection;
            }catch(Exception e)
            {
                return connection;
            }
            }
        public MySqlConnection Closed()
        {
            var connection = new MySqlConnection(connectionString);

            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
            return connection;
        }
    }
}