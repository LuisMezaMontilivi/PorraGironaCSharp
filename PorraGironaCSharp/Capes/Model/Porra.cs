using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorraGironaCSharp.Capes.Model
{
    class Porra
    {
        private int dataPorra;
        private int previsioGolsLocal;
        private int previsioGolsVisitant;

        public Porrista Porrista
        {
            get => default;
            set
            {
            }
        }

        public Partit Partit
        {
            get => default;
            set
            {
            }
        }

        public bool ModificarPrevisio(int previsioLocal, int previsioVisitant)
        {
            throw new System.NotImplementedException();
        }
    }
}
