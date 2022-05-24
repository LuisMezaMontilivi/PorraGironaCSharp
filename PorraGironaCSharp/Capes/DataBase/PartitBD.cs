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

        static public void EliminarPartit(string id)
        {
            MySqlCommand command = new MySqlCommand($"Delete from Partit where IdPartit={id};");
            command.Connection = Connexio.Connect();
            Connexio.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
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

        static public Partit RecuperarUltim()
        {
            Partit partit = null;
            string conexio = "server=localhost; port=3306; user=root; password=; database=porra; convert zero datetime=True";
            using (MySqlConnection connect = new MySqlConnection(conexio))
            {
                connect.Open();
                MySqlCommand llegirDarrerPartit = new MySqlCommand("select p.Idpartit, p.Estat, p.Gols_Local, p.Gols_Visitant, p.Moment, " +
                    "e.IdEquip idLocal, e.Nom_Equip nomLocal, e.Nom_Camp campLocal, e.Municipi municipiLocal, e.Escut escutLocal, " +
                    "ev.IdEquip idVisitant, ev.Nom_Equip nomVisitant, ev.Nom_Camp campVisitant, ev.Municipi municipiVisitant, ev.Escut escutVisitant " +
                    "from partit p join equip e on (p.idEquipLocal = e.IdEquip) " +
                    "join equip ev on (p.idEquipVisitant = ev.IdEquip) " +
                    "where estat = 'Per Jugar' and moment = (select min(moment) from partit where estat = 'Per Jugar');", connect);
                MySqlDataReader lector = llegirDarrerPartit.ExecuteReader();
                Equip local = new Equip((int)lector["idLocal"], (string)lector["nomLocal"], (string)lector["campLocal"], (string)lector["municipiLocal"], (string)lector["escutLocal"]);
                Equip visitant = new Equip((int)lector["idVisitant"], (string)lector["nomVisitant"], (string)lector["campVisitant"], (string)lector["municipiVisitant"], (string)lector["escutVisitant"]);
                partit = new Partit((string)lector["Estat"],local,visitant, DateTime.Parse(lector["Moment"].ToString()));
            }
            return partit;
        }

    }
}
