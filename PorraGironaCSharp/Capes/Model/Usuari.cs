﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorraGironaCSharp.Capes.Model
{
    class Usuari
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

        public string Verificar()
        {
            string rol="";


            return rol;
        }


    }
}
