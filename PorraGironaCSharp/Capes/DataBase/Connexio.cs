using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PorraGironaCSharp.Capes.DataBase
{

    class Connexio
    {
        static MySqlConnection connexio = new MySqlConnection($"server=localhost; port=3306; user=root; password=; database=porra");

        static public void Open()
        {
            connexio.Open();
        }
        static public void Close()
        {
            connexio.Close();
        }
        static public MySqlConnection Connect()
        {
            return connexio;
        }
    }
}
