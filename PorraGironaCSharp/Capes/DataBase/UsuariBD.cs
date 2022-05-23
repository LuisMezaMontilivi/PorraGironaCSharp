﻿using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorraGironaCSharp.Capes.DataBase
{
    class UsuariBD
    {
        //MySqlConnection connexio = new MySqlConnection($"server=localhost; port=3306; user=root; password=; database=porra");
        static public string SelectRol(string usuari, string contrasenya)
        {
           
            MySqlCommand command = new MySqlCommand($"Select Rol from Usuari where Alias='{usuari}' and Contrasenya = '{contrasenya}';");
            command.Connection=Connexio.Connect();
            Connexio.Open();
            string rol = command.ExecuteScalar().ToString();
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
        static public void EliminarUsuari(string id)
        {
            MySqlCommand command = new MySqlCommand($"Delete from Usuari where IdUsuari={id};");
            command.Connection = Connexio.Connect();
            Connexio.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
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
    }
}
