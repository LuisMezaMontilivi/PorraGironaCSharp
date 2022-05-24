using PorraGironaCSharp.Capes.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorraGironaCSharp.Capes.Model
{
   
    class Usuari
    {
        public string alias { get; set; }
        public string contrasenya { get; set; }
        public string nom { get; set; }
        public string cognom { get; set; }
        public string nif { get; set; }
        public string rol { get; set; }

        public Usuari(string alias, string contrasenya)
        {
            this.alias = alias;
            this.contrasenya = contrasenya;
        }
        public Usuari(string nom, string cognom, string dni ,string alias, string contrasenya)
        {
            this.nom = nom;
            this.cognom = cognom;
            this.nif = dni;
            this.alias = alias;
            this.contrasenya = contrasenya;
        }

        public string Verificar(string alias, string contrasenya)
        {
            string rol="";
            

            try
            {
                rol=UsuariBD.SelectRol(alias,contrasenya);
               
            }
            catch
            {
                rol = "No Funciona";
            }
            

            return rol;
        }
        public bool Afegir(string nom, string cognom, string dni, string alias, string contrasenya)
        {
            bool funciona;
            

            try
            {
               UsuariBD.InsertUsuari(nom,cognom,dni,alias, contrasenya);
               funciona = true;
               
            }
            catch
            {
                funciona = false;
            }
            
            return funciona;

            
        }

        public bool Eliminar()
        {
            bool eliminacio = false;
            try
            {
                UsuariBD.EliminarUsuari(alias);
                eliminacio = true;
            }
            catch(Exception e)
            {
                throw e;
            }
            return eliminacio;
        }


    }
}
