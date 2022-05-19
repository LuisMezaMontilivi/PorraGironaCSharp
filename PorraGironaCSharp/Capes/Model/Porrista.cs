using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorraGironaCSharp.Capes.Model
{
    class Porrista
    {
        private DateTime dataAlta;
        private int idPorrista;
        private int puntuacioTotal;
        private List<Historic> historics;

        public int Puntuacio
        {
            get => default;
            set
            {
            }
        }

        public bool AugmentarPuntuacio(int punts)
        {
            throw new System.NotImplementedException();
        }

        public void AfegirHistoric(Historic historic)
        {
            throw new System.NotImplementedException();
        }

        public void FerPrediccio()
        {
            throw new System.NotImplementedException();
        }

        public void VeurePrediccions()
        {
            throw new System.NotImplementedException();
        }

        public void VeureTemporades()
        {
            throw new System.NotImplementedException();
        }
    }
}
