using MySqlConnector;
using PorraGironaCSharp.Capes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorraGironaCSharp.Capes.DataBase
{
    public class PorraBD
    {
        public static List<Porra> RecuperarPorres()
        {
            List<Porra> porres = new List<Porra>();
            MySqlConnection connexio = new MySqlConnection($"server=localhost; port=3306;user=root;password=;database=porra");
            
            connexio.Open();
            MySqlCommand command = new MySqlCommand("SELECT * FROM porra;", connexio);
            MySqlDataReader lector = command.ExecuteReader();
            while (lector.Read())
            {
                porres.Add(new Porra((int)lector["IdUsuari"],
                                      (int)lector["IdPartit"],
                                      (int)lector["GolsLocal"],
                                      (int)lector["GolsVisitant"],
                                      DateTime.Parse(lector["DataPorra"].ToString()),
                                      (int)lector["PuntuacioObtinguda"]));
            }
            return porres;
        }

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
