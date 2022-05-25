using PorraGironaCSharp.Capes.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorraGironaCSharp.Capes.Model
{
    public class Equips
    {
        private List<Equip> equips;

        public Equips()
        {
            equips = EquipBD.LlistatEquips();
        }

        public bool AfegirEquip(Equip equip)
        {
            equips.Add(equip);
            return EquipBD.InsertarEquip(equip);
        }

        public Equip RetornarEquip(string nom)
        {
            return equips.Find(x => x.NomEquip == nom);
        }

        public bool EliminarEquip(Equip e)
        {
            bool eliminat = false;
            try
            {
                PartitBD.EliminarPartitOnHaJugat(e.IdEquip);
                EquipBD.EliminarEquip(e.IdEquip);
                equips.Remove(e);
                eliminat = true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return eliminat;
        }

        public List<string> NomsEquips()
        {
            List<string> noms = new List<string>();
            foreach(Equip X in equips)
            {
                noms.Add(X.NomEquip);
            }
            return noms;
        }

        public Equip RecuperarEquip(int posicio)
        {
            return equips[posicio];
        }

        public List<Equip> EquipsBaseDades()
        {
            return EquipBD.LlistatEquips();
        }
    }
}
