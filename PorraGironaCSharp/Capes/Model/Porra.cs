using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorraGironaCSharp.Capes.Model
{
    public class Porra
    {
        private DateTime dataPorra;
        private int previsioGolsLocal;
        private int previsioGolsVisitant;
        private Porrista porrista;
        private Partit partit;


        public Porra() => dataPorra = DateTime.Now;

        private int idUsuari;
        private int idPartit;

        public Porra(int idUsuari, int idPartit, int golsLocal, int golsVisitant, DateTime data, int puntuacio)
        {
            this.idUsuari = idUsuari;
            this.idPartit = idPartit;
            previsioGolsLocal = golsLocal;
            previsioGolsVisitant = golsVisitant;
            dataPorra = data;
        }

        public int IdPartit
        {
            get { return idPartit; }
        }

        public int IdUsuari
        {
            get { return idUsuari; }
        }



        public Porra(DateTime dataPorra, int previsioGolsLocal, int previsioGolsVisitant, Porrista porrista, Partit partit)
        {
            this.dataPorra = dataPorra;
            this.previsioGolsLocal = previsioGolsLocal;
            this.previsioGolsVisitant = previsioGolsVisitant;
            this.Porrista = porrista;
            this.Partit = partit;

        }

        public DateTime DataPorra { get => dataPorra; set => dataPorra = value; }
        public int PrevisioGolsLocal { get => previsioGolsLocal; set => previsioGolsLocal = value; }
        public int PrevisioGolsVisitant { get => previsioGolsVisitant; set => previsioGolsVisitant = value; }
        public Partit Partit { get => partit; set => partit = value; }
        public Porrista Porrista { get => porrista; set => porrista = value; }

        public bool AcertatPrediccio(int local, int visitant)
        {
            return local == previsioGolsLocal && visitant == previsioGolsVisitant;
        }


        public bool ModificarPrevisio(int previsioLocal, int previsioVisitant)
        {
            throw new System.NotImplementedException();
        }
    }
}
