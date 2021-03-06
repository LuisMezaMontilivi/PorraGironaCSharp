using PorraGironaCSharp.Capes.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorraGironaCSharp.Capes.Model
{
    public class Partits
    {
        private List<Partit> partits;

        public Partits()
        {
            try
            {
                partits = PartitBD.LlistarPartits();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public bool AfegirPartit(Partit p)
        {
            bool insercio = false;
            try
            {
                partits.Add(p);
                PartitBD.InsertarPartit(p);
                insercio = true;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            
            return insercio;
        }

        public Partit RecuperarPartit(int posicio)
        {
            return partits[posicio];
        }

        public Partit RecuperarUltimPartitNoJugat()
        {
            List<Partit> noJugats = partits.FindAll(p => p.Estat == "Per Jugar");
            return noJugats.Find(p => p.Data == noJugats.Min(t => t.Data));
        }

        public Partit RecuperarUltimPartitJugat()
        {
            List<Partit> Jugats = partits.FindAll(p => p.Estat == "Acabat");
            return Jugats.Find(p => p.Data == Jugats.Max(t => t.Data));
        }

        public void EliminarPartit(Partit p)
        {
            partits.Remove(p);
            PorraBD.EliminarPorresPartit(p.Id);
            PartitBD.EliminarPartit(p.Id);
        }

        public bool ActualtizarPartit(int idPartit)
        {
            throw new System.NotImplementedException();
        }


        public List<Partit> LlistarPartits()
        {
            return partits;
        }

        public void ActualitzarPartit(Partit p)
        {
            PartitBD.ActualitzarPartitBD(p);
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
