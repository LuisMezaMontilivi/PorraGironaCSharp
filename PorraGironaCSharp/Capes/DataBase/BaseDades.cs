using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PorraGironaCSharp.Capes.DataBase
{

    class BaseDades
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
        public string SelectEscut()
        {

            MySqlCommand command = new MySqlCommand($"Select Escut from Equip where IdEquip=1;");
            command.Connection = connexio;
            connexio.Open();
            string escut = command.ExecuteScalar().ToString();
            command.Connection.Close();

            return escut;

        }
        public void InsertUsuari(string nom, string cognom, string nif, string alias, string contrasenya)
        {

            MySqlCommand command = new MySqlCommand($"Insert into Usuari(Nom, Cognom, Nif,Alias,Rol,Contrasenya,DataAlta,PuntuacioTotal) Values ('{nom}','{cognom}','{nif}','{alias}','user','{contrasenya}',current_timestamp,0);");
            //insert into usuari values (null,'Fernanda','Perez','12345678A','FPerez','user','1234',current_timestamp,10);
            command.Connection = connexio;
            connexio.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();

            

        }
    }
}
