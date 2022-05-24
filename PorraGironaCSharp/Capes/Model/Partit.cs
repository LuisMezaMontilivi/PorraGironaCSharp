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
        private DateTime data;

        public Partit(string estat, Equip local, Equip visitant, DateTime temps)
        {
            this.estat = estat; EquipLocal = local; EquipVisitant = visitant; data = temps;
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

        public string Estat
        {
            get => default;
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
