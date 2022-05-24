using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PorraGironaCSharp.Capes.DataBase;

namespace PorraGironaCSharp.Capes.Model
{
    class Porristes
    {
        private List<Porrista> llistatPorristes;

        public Porristes()
        {
            llistatPorristes = UsuariBD.LlistaPorristes();
        }

        public List<Porrista> LlistaPorristes { get => llistatPorristes; }
        

        public bool AfegirPorrista(Porrista porrista)
        {
            bool outcome = true ;
            try
            {
                llistatPorristes.Add(porrista);
            }
            catch(Exception ex)
            {
                
                outcome = false;
            }
            
                return outcome;
            
            
        }

        public bool EliminarPorrista(int idPorrista)
        {
            bool outcome=true;
            try
            {
                llistatPorristes.RemoveAt(llistatPorristes.FindIndex(x => x.IdPorrista == idPorrista));
            }
            catch (Exception ex)
            {
                outcome = false;

            }
            return outcome;
           
        }

        public List<Porrista> RecuperarPorristes()
        {
            return UsuariBD.LlistaPorristes();

        }
    }
}
