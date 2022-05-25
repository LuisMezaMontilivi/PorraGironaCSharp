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
