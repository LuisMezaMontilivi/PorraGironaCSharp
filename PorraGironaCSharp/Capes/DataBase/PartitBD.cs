using MySqlConnector;
using PorraGironaCSharp.Capes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorraGironaCSharp.Capes.DataBase
{
    class PartitBD
    {
        static public bool InsertarPartit(Partit p)
        {
            MySqlConnection connexio = new MySqlConnection($"server=localhost; port=3306; user=root; password=; database=porra");
            bool resultatInsercio = true;
            try
            {
                MySqlCommand command = new MySqlCommand($"INSERT INTO Partit (IdEquipLocal, IdEquipVisitant, Estat, Descripcio_Jornada) VALUES ({p.EquipLocal.IdEquip},{p.EquipLocal.IdEquip},'Per Jugar','Hola');");
                command.Connection = connexio;
                connexio.Open();
                command.ExecuteNonQuery();
                command.Connection.Close();
            }
            catch (Exception e)
            {
                resultatInsercio = false;
                throw new Exception(e.Message);
            }
            return resultatInsercio;
        }

        static public List<Partit> LlistarPartits()
        {
            List<Partit> partits = new List<Partit>();
            string conexio = "server=localhost; port=3306; user=root; password=; database=porra; convert zero datetime=True";
            using (MySqlConnection connect = new MySqlConnection(conexio))
            {
                connect.Open();
                MySqlCommand llegirEquips = new MySqlCommand("SELECT * FROM Partit", connect);
                MySqlDataReader lector = llegirEquips.ExecuteReader();
                while (lector.Read())
                {
                    partits.Add(new Partit((string)lector["Estat"],
                                         new Equip((int)lector["IdEquipLocal"],"a","a","a","a"),
                                         new Equip((int)lector["IdEquipVisitant"], "a", "a", "a", "a"),
                                         DateTime.Parse(lector["Moment"].ToString())));
                }
            }
            return partits;
        }

    }
}
