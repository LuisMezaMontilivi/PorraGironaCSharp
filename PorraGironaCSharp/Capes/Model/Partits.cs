using PorraGironaCSharp.Capes.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorraGironaCSharp.Capes.Model
{
    class Partits
    {
        private List<Partit> llistatPartits;

        public Partits()
        {
            llistatPartits = new List<Partit>();
        }

        public bool AfegirPartit(Partit p)
        {
            llistatPartits.Add(p);
            PartitBD.InsertarPartit(p);
            return true;
        }

        public bool EliminarPartit(int idPartit)
        {
            throw new System.NotImplementedException();
        }

        public bool ActualtizarPartit(int idPartit)
        {
            throw new System.NotImplementedException();
        }
    }
}
