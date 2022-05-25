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
            MySqlConnection connexio = new MySqlConnection($"server=localhost; port=3306; user=root; password=; database=porra; convert zero datetime=True");
            bool resultatInsercio = true;
            try
            {
                MySqlCommand command = new MySqlCommand($"INSERT INTO Partit (IdEquipLocal, IdEquipVisitant, Estat, Moment, Gols_Local, Gols_Visitant) " +
                                                         $"VALUES ({p.EquipLocal.IdEquip},{p.EquipVisitant.IdEquip},'Per Jugar','{p.Data.ToString("yyyy-MM-dd HH-mm-ss")}',{p.GolsLocal},{p.GolsVisitant});");
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

        static public void EliminarPartit(int id)
        {
            MySqlCommand command = new MySqlCommand($"Delete from Partit where IdPartit={id};");
            command.Connection = Connexio.Connect();
            Connexio.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
        }

        static public void EliminarPartitOnHaJugat(int idEquip)
        {
            MySqlCommand command = new MySqlCommand($"DELETE FROM Partit WHERE idEquipLocal = {idEquip} OR idEquipVisitant =  {idEquip};");
            command.Connection = Connexio.Connect();
            Connexio.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
        }


        static public List<Partit> LlistarPartits()
        {
            MySqlConnection connexio = new MySqlConnection($"server=localhost; port=3306;user=root;password=;database=porra");
            List<Partit> partits = new List<Partit>();
            connexio.Open();
            MySqlCommand command = new MySqlCommand("select p.Idpartit, p.Estat, p.Gols_Local, p.Gols_Visitant, p.Moment, " +
                    "e.IdEquip idLocal, e.Nom_Equip nomLocal, e.Nom_Camp campLocal, e.Municipi municipiLocal, e.Escut escutLocal, " +
                    "ev.IdEquip idVisitant, ev.Nom_Equip nomVisitant, ev.Nom_Camp campVisitant, ev.Municipi municipiVisitant, ev.Escut escutVisitant " +
                    "from partit p join equip e on (p.idEquipLocal = e.IdEquip) " +
                    "join equip ev on (p.idEquipVisitant = ev.IdEquip);", connexio);
            MySqlDataReader lector = command.ExecuteReader();
            while (lector.Read())
            {
                Equip local = new Equip((int)lector["idLocal"], (string)lector["nomLocal"], (string)lector["campLocal"], (string)lector["municipiLocal"], (string)lector["escutLocal"]);
                Equip visitant = new Equip((int)lector["idVisitant"], (string)lector["nomVisitant"], (string)lector["campVisitant"], (string)lector["municipiVisitant"], (string)lector["escutVisitant"]);
                Partit prova = new Partit((int)lector["IdPartit"],(string)lector["Estat"], local, visitant, DateTime.Parse(lector["Moment"].ToString()));
                partits.Add(prova);
            }
            return partits;
        }

        static public Partit RecuperarUltim()
        {
            MySqlConnection connexio = new MySqlConnection($"server=localhost; port=3306;user=root;password=;database=porra");
            connexio.Open();
            MySqlCommand command = new MySqlCommand("select p.Idpartit, p.Estat, p.Gols_Local, p.Gols_Visitant, p.Moment, " +
                    "e.IdEquip idLocal, e.Nom_Equip nomLocal, e.Nom_Camp campLocal, e.Municipi municipiLocal, e.Escut escutLocal, " +
                    "ev.IdEquip idVisitant, ev.Nom_Equip nomVisitant, ev.Nom_Camp campVisitant, ev.Municipi municipiVisitant, ev.Escut escutVisitant " +
                    "from partit p join equip e on (p.idEquipLocal = e.IdEquip) " +
                    "join equip ev on (p.idEquipVisitant = ev.IdEquip) " +
                    "where estat = 'Per Jugar' and moment = (select min(moment) from partit where estat = 'Per Jugar');", connexio);
            MySqlDataReader lector = command.ExecuteReader();
            Partit prova = null;
            while (lector.Read())
            {
                Equip local = new Equip((int)lector["idLocal"], (string)lector["nomLocal"], (string)lector["campLocal"], (string)lector["municipiLocal"], (string)lector["escutLocal"]);
                Equip visitant = new Equip((int)lector["idVisitant"], (string)lector["nomVisitant"], (string)lector["campVisitant"], (string)lector["municipiVisitant"], (string)lector["escutVisitant"]);
                prova = new Partit((int)lector["IdPartit"],(string)lector["Estat"], local, visitant, DateTime.Parse(lector["Moment"].ToString()));
            }
            return prova;
        }

    }
}
