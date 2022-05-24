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
            llistatPartits = PartitBD.LlistarPartits();
        }

        public bool AfegirPartit(Partit p)
        {
            bool insercio = false;
            try
            {
                llistatPartits.Add(p);
                PartitBD.InsertarPartit(p);
                insercio = true;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            
            return insercio;
        }

        public bool EliminarPartit(int idPartit)
        {
            throw new System.NotImplementedException();
        }

        public bool ActualtizarPartit(int idPartit)
        {
            throw new System.NotImplementedException();
        }

        public List<Partit> LlistarPartits()
        {
            return llistatPartits;
        }

        public Partit UltimPartit()
        {
            try
            {
                return PartitBD.RecuperarUltim();
            }
            catch(Exception e)
            {
                throw e;
            }
            
        }
    }
}
