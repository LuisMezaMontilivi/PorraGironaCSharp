using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PorraGironaCSharp.Capes.DataBase
{

    class BaseDadesUsuari
    {
        MySqlConnection connexio = new MySqlConnection($"server=localhost; port=3306; user=root; password=; database=porra");
      
        public string SelectRol(string usuari, string contrasenya)
        {
           
            MySqlCommand command = new MySqlCommand($"Select Rol from Usuari where Alias='{usuari}' and Contrasenya = '{contrasenya}';");
            command.Connection = connexio;
            connexio.Open();
            string rol = command.ExecuteScalar().ToString();
            command.Connection.Close();
            
            return rol;

        }
    }
}
