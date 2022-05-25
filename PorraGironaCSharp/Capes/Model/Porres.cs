using PorraGironaCSharp.Capes.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorraGironaCSharp.Capes.Model
{
    class Porres
    {
        private List<Porra> llistatPorres;

        public Porres()
        {
            llistatPorres = PorraBD.RecuperarPorres();
        }

        public void ActualitzarResultatsPorra(Partit p)
        {
            List<Porra> actualitzar = llistatPorres.FindAll(x => x.IdPartit == p.Id);
            foreach(Porra x in actualitzar)
            {
                if (x.AcertatPrediccio(p.GolsLocal, p.GolsVisitant))
                    UsuariBD.AugmentarPuntuacio(1, x.IdUsuari);
            }
        }

        public bool AfegirPorra(Porra porra)
        {
            throw new System.NotImplementedException();
        }

        public bool EliminarPorra(int idPorra)
        {
            throw new System.NotImplementedException();
        }
    }
}
