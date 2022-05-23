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
        private List<Equip> llistatEquips;

        public Equips()
        {
            llistatEquips = EquipBD.LlistatEquips();
        }

        public bool AfegirEquip(Equip equip)
        {
            llistatEquips.Add(equip);
            return EquipBD.InsertarEquip(equip);
        }

        public bool EliminarEquip(int idEquip)
        {
            throw new System.NotImplementedException();
        }

        public List<Equip> EquipsBaseDades()
        {
            return EquipBD.LlistatEquips();
        }
    }
}
