using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorraGironaCSharp.Capes.DataBase
{
    public class PorraBD
    {
        static public void EliminarPorresUsuari(string aliesUsuari)
        {
            MySqlCommand command = new MySqlCommand($"DELETE FROM porra WHERE IdUsuari = (SELECT IdUsuari FROM usuari WHERE alias = '{aliesUsuari}');");
            command.Connection = Connexio.Connect();
            Connexio.Open();
            try
            {
                command.ExecuteNonQuery();
            }
            finally
            {
                command.Connection.Close();
            }
        }

        static public void EliminarPorresPartit(int idPartit)
        {
            MySqlCommand command = new MySqlCommand($"DELETE FROM porra WHERE IdPartit = {idPartit} ;");
            command.Connection = Connexio.Connect();
            Connexio.Open();
            try
            {
                command.ExecuteNonQuery();
            }
            finally
            {
                command.Connection.Close();
            }
        }
    }
}
