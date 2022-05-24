using PorraGironaCSharp.Capes.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorraGironaCSharp.Capes.Model
{
   
    public class Usuari
    {
        public string alias { get; set; }
        private string contrasenya { get; set; }
        private string nom { get; set; }
        private string cognom { get; set; }
        private string nif { get; set; }
        private string rol { get; set; }
       

        public Usuari(string alias, string contrasenya)
        {
            this.alias = alias;
            this.contrasenya = contrasenya;
        }

        


       
        public Usuari(string nom, string cognom, string dni ,string alias, string contrasenya) //Algo he posat per aqui;
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


    }
}
