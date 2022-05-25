using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorraGironaCSharp.Capes.Model
{
   public  class Historic
    {
        private int temporada;
        private int puntuacioTotal;

        public Historic(int temp, int punts)
        {
            temporada = temp;
            puntuacioTotal = punts;
        }

        public int Puntuacio
        {
            get { return puntuacioTotal; }
            set { puntuacioTotal = value; }
        }

        
    }
}
