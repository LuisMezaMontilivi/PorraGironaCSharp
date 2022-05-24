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
        private Equip equipLocal;
        private Equip equipVisitant;

        public Partit(string estat, Equip local, Equip visitant, DateTime temps)
        {
            this.estat = estat; equipLocal = local; equipVisitant = visitant; data = temps;
            golsLocal = golsVisitant = 0;
        }

        public Equip EquipVisitant
        {
            get { return equipVisitant; }
            set
            {
            }
        }

        public Equip EquipLocal
        {
            get { return equipLocal; }
            set
            {
            }
        }

        public DateTime Data
        {
            get { return data; }
        }

        public string Estat
        {
            get { return estat; }
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
