using PorraGironaCSharp.Capes.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorraGironaCSharp.Capes.Model
{
    class Historics
    {

        private List<Historic> llistaHistorics;

        public List<Historic> LlistaHistorics { get => llistaHistorics; set => llistaHistorics = value; }



        public List<Historic> RecuperarHistorics(string alias)
        {
            return UsuariBD.LlistaHistorics( alias);

        }



    }
}
