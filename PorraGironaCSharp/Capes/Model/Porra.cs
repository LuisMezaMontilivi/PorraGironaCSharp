using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorraGironaCSharp.Capes.Model
{
    class Porra
    {
        private DateTime dataPorra;
        private int previsioGolsLocal;
        private int previsioGolsVisitant;
        private Porrista porrista;
        private Partit partit;


        public Porra() => dataPorra = DateTime.Now;


        public Porra(DateTime dataPorra, int previsioGolsLocal, int previsioGolsVisitant, Porrista porrista, Partit partit)
        {
            this.dataPorra = dataPorra;
            this.previsioGolsLocal = previsioGolsLocal;
            this.previsioGolsVisitant = previsioGolsVisitant;
            this.porrista = porrista;
            this.partit = partit;

        }

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

        public DateTime DataPorra { get => dataPorra; set => dataPorra = value; }
        public int PrevisioGolsLocal { get => previsioGolsLocal; set => previsioGolsLocal = value; }
        public int PrevisioGolsVisitant { get => previsioGolsVisitant; set => previsioGolsVisitant = value; }

        public bool ModificarPrevisio(int previsioLocal, int previsioVisitant)
        {
            throw new System.NotImplementedException();
        }
    }
}
