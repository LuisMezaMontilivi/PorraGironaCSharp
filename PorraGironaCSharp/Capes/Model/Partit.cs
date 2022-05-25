using PorraGironaCSharp.Capes.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorraGironaCSharp.Capes.Model
{
    public class Partit
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

        public Partit(int id, string estat, Equip local, Equip visitant, DateTime temps) : this(estat, local, visitant, temps)
        {
            idPartit = id;
        }

        public int GolsLocal
        {
            get { return golsLocal; }
        }

        public int GolsVisitant
        {
            get { return golsVisitant; }
        }

        public int Id
        {
            get { return idPartit; }
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
            set { data = value; }
        }

        public string Estat
        {
            get { return estat; }
        }

        public void CanviarEstat(string NouEstat)
        {
            estat = NouEstat;
        }

        public void ActualitzarMarcador(int local, int visitant)
        {
            golsLocal = local;
            golsVisitant = visitant;
        }

        public void EnviarCanvis()
        {
            PartitBD.ActualitzarPartit(this);
        }
    }
}
