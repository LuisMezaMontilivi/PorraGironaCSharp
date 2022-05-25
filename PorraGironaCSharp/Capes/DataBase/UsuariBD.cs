using MySqlConnector;
using PorraGironaCSharp.Capes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PorraGironaCSharp.Capes.Model;

namespace PorraGironaCSharp.Capes.DataBase
{
    class UsuariBD
    {
        //MySqlConnection connexio = new MySqlConnection($"server=localhost; port=3306; user=root; password=; database=porra");
        static public string SelectRol(string usuari, string contrasenya)
        {
            string rol = "";
            MySqlCommand command = new MySqlCommand($"Select Rol from Usuari where Alias='{usuari}' and Contrasenya = '{contrasenya}';");
            command.Connection=Connexio.Connect();
            Connexio.Open();
            if (command.ExecuteScalar() != null)
            {
                rol = command.ExecuteScalar().ToString();
            }
            else
            {
                rol = null;
            }
           
            command.Connection.Close();
            Connexio.Close();
            return rol;

        }
        static public string SelectEscut()
        {

            MySqlCommand command = new MySqlCommand($"Select Escut from Equip where IdEquip=1;");
            command.Connection = Connexio.Connect();
            Connexio.Open();
            string escut = command.ExecuteScalar().ToString();
            command.Connection.Close();
            Connexio.Close();

            return escut;

        }
        static public void InsertUsuari(string nom, string cognom, string nif, string alias, string contrasenya)
        {

            MySqlCommand command = new MySqlCommand($"Insert into Usuari(Nom, Cognom, Nif,Alias,Rol,Contrasenya,DataAlta,PuntuacioTotal) Values ('{nom}','{cognom}','{nif}','{alias}','user','{contrasenya}',current_timestamp,0);");
            //insert into usuari values (null,'Fernanda','Perez','12345678A','FPerez','user','1234',current_timestamp,10);
            command.Connection = Connexio.Connect();
            Connexio.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
            
        }
        static public void EliminarUsuari(string alias)
        {
            MySqlCommand command = new MySqlCommand($"Delete from Usuari where Alias = '{alias}';");
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
        static public void ActualitzarUsuari(string id, string nom, string cognom, string nif, string dataAlta, string puntuacio)
        {
            MySqlCommand command = new MySqlCommand($"update usuari set Nom='{nom}', Cognom='{cognom}', Nif='{nif}', DataAlta='{dataAlta}', PuntuacioTotal='{puntuacio}' where IdUsuari={id};");
            //update usuari set Nom = 'Jorge', Cognom = 'Curioso', Nif = '41654422H', DataAlta = current_timestamp, PuntuacioTotal = 5 where IdUsuari = 5;
            command.Connection = Connexio.Connect();
            Connexio.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
        }

        static public List<Usuari> LlistatUsuaris()
        {
            List<Usuari> usuaris = new List<Usuari>();
            string conexio = "server=localhost; port=3306; user=root; password=; database=porra";
            using (MySqlConnection connect = new MySqlConnection(conexio))
            {
                connect.Open();
                MySqlCommand llegirEquips = new MySqlCommand("SELECT * FROM Usuari", connect);
                MySqlDataReader lector = llegirEquips.ExecuteReader();
                while (lector.Read())
                {
                    usuaris.Add(new Usuari((string)lector["Nom"],
                                         (string)lector["Cognom"],
                                         (string)lector["Nif"],
                                         (string)lector["Alias"],
                                         (string)lector["Contrasenya"]));
                }
            }
            return usuaris;
        }

        static public void InsertarUsuariBD(Usuari u)
        {
            MySqlCommand command = new MySqlCommand($"Insert into Usuari(Nom, Cognom, Nif,Alias,Rol,Contrasenya,DataAlta,PuntuacioTotal)" +
                $" Values ('{u.nom}','{u.cognom}','{u.nif}','{u.alias}','{u.rol}','{u.contrasenya}',current_timestamp,0);");
            command.Connection = Connexio.Connect();
            Connexio.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
        }

        static public bool InsertarPorra(Porra porra, string alias) //Faig que retorni true o false perquè em serà interessant per saber si puc insertar o modificar
        {
            bool output=true;
            MySqlCommand command = new MySqlCommand($"Insert into porra((select IdUsuari from usuari where alias = '{alias}'), {porra.Partit.Id}, {porra.PrevisioGolsLocal}, " +
                $"{porra.PrevisioGolsLocal}, current_timestamp, 0 )");
            command.Connection = Connexio.Connect();
            Connexio.Open();

            try
            {
                command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                output = false;
            }
           
            command.Connection.Close();
            return output;
        }

        static public void ModificarPorra(Porra porra, string alias)
        {
           
            

            MySqlCommand command = new MySqlCommand($"update porra set GolsLocal ={porra.PrevisioGolsLocal}, GolsVisitant = {porra.PrevisioGolsVisitant}, " +
                $"DataPorra = current_timestamp()" +
                $"where IdUsuari = (select IdUsuari from usuari where alias = '{alias}'); ");
            command.Connection = Connexio.Connect();
            Connexio.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();



        }


        //public static List<Porrista> LlistaPorristes()
        //{
        //    string query = $"select * from usuari where rol = 'user'";
        //    MySqlCommand command = new MySqlCommand(query, Connexio.Connect());
        //    command.CommandTimeout = 60; //Per que no es pengi la cosa
        //    List<Porrista> output = new List<Porrista>();

        //    using (Connexio.Connect())
        //    {
        //        Connexio.Open();
        //        MySqlDataReader reader = command.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            output.Add(new Porrista(
        //                                            (string)reader["Nom"],
        //                                            (string)reader["Cognom"],
        //                                            (string)reader["Nif"],
        //                                            (string)reader["Alias"],
        //                                            (string)reader["IdUsuari"],
        //                                            (Int32)reader["PuntuacioTotal"]
        //                                            ));
        //        }

        //    }

        //    return output;


        //}
        public static List<Porrista> LlistaPorristes()
        {
            string conexio = "server=localhost; port=3306; user=root; password=; database=porra";
            List<Porrista> retorn = new List<Porrista>();
            using (MySqlConnection connect = new MySqlConnection(conexio))
            {
                connect.Open();
                MySqlCommand llegirEquips = new MySqlCommand("SELECT * FROM usuari where rol = 'user' order by PuntuacioTotal DESC", connect);
                MySqlDataReader lector = llegirEquips.ExecuteReader();
                while (lector.Read())
                {
                    retorn.Add(new Porrista( (string)lector["Nom"],
                                         (string)lector["Cognom"],
                                         (string)lector["Nif"],
                                         (string)lector["Alias"],
                                         (int)lector["IdUsuari"],
                                         (int)lector["PuntuacioTotal"]));
                }
            }
            return retorn;
        }



    }
}
