using MySqlConnector;
using PorraGironaCSharp.Capes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorraGironaCSharp.Capes.DataBase
{
    class EquipBD
    {
        
        static public bool InsertarEquip(Equip e)
        {
            MySqlConnection connexio = new MySqlConnection($"server=localhost; port=3306; user=root; password=; database=porra");
            bool resultatInsercio = true;
            try
            {
                MySqlCommand command = new MySqlCommand($"INSERT INTO Equip (Nom_Equip, Nom_Camp, Municipi, Escut) VALUES ('{e.NomEquip}', '{e.NomCamp}', '{e.Municipi}', '{e.RutaEscut}');");
                command.Connection = connexio;
                connexio.Open();
                command.ExecuteNonQuery();
                command.Connection.Close();
            }
            catch
            {
                resultatInsercio = false;
            }
            return resultatInsercio;
        }

        public static List<Equip> LlistatEquips()
        {
            string conexio = "server=localhost; port=3306; user=root; password=; database=porra";
            List<Equip> retorn = new List<Equip>();
            using (MySqlConnection connect = new MySqlConnection(conexio))
            {
                connect.Open();
                MySqlCommand llegirEquips = new MySqlCommand("SELECT * FROM Equip", connect);
                MySqlDataReader lector = llegirEquips.ExecuteReader();
                while (lector.Read())
                {
                    retorn.Add(new Equip((int)lector["IdEquip"],
                                         (string)lector["Nom_Equip"],
                                         (string)lector["Municipi"],
                                         (string)lector["Nom_Camp"],
                                         (string)lector["Escut"]));
                }
            }
            return retorn;
        }
    }


}
