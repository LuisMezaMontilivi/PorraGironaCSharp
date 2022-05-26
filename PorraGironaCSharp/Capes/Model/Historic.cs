using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorraGironaCSharp.Capes.Model
{
   public  class Historic
    {
        private int idUsuari;
        private string temporada;
        private int puntuacioTotal;
        private int posicio;

        public Historic(int idUsuari ,string temporada, int puntuacioTotal, int posicio)
        {
            this.idUsuari = idUsuari;
            this.temporada = temporada;
            this.puntuacioTotal = puntuacioTotal;
            this.posicio = posicio;
        }

        public int Puntuacio
        {
            get { return PuntuacioTotal; }
            set { PuntuacioTotal = value; }
        }

        public int Posicio { get => posicio; set => posicio = value; }
        public string Temporada { get => temporada; set => temporada = value; }
        public int PuntuacioTotal { get => puntuacioTotal; set => puntuacioTotal = value; }
        public int IdUsuari { get => idUsuari; set => idUsuari = value; }
    }
}
