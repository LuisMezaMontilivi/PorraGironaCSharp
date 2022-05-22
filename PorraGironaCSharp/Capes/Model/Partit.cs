using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorraGironaCSharp.Capes.Model
{
    class Partit
    {
        private string estat;
        private int golsLocal;
        private int golsVisitant;
        private int idPartit;
        private int temporada;

        public Partit(string estat, Equip local, Equip visitant, int temp)
        {
            this.estat = estat; EquipLocal = local; EquipVisitant = visitant; temporada = temp;
            golsLocal = golsVisitant = 0;
        }

        public Equip EquipVisitant
        {
            get => default;
            set
            {
            }
        }

        public Equip EquipLocal
        {
            get => default;
            set
            {
            }
        }

        public bool CanviarEstat(string NouEstat)
        {
            throw new System.NotImplementedException();
        }

        public bool ActualitzarMarcador(int local, int visitant)
        {
            throw new System.NotImplementedException();
        }
    }
}
