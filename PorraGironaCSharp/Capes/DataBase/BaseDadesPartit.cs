using MySqlConnector;
using PorraGironaCSharp.Capes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorraGironaCSharp.Capes.DataBase
{
    class BaseDadesPartit
    {
        static public bool InsertarPartit(Partit p)
        {
            MySqlConnection connexio = new MySqlConnection($"server=localhost; port=3306; user=root; password=; database=porra");
            bool resultatInsercio = true;
            try
            {
                MySqlCommand command = new MySqlCommand($"INSERT INTO Partit (IdEquipLocal, IdEquipVisitant, Estat, Descripcio_Jornada) VALUES ({p.EquipLocal.IdEquip},{p.EquipLocal.IdEquip},'Per Jugar','Puta Basura');");
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
    }
}
