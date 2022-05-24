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

        public Equip RetornarEquip(string nom)
        {
            return llistatEquips.Find(x => x.NomEquip == nom);
        }

        public bool EliminarEquip(int idEquip)
        {
            bool eliminat = false;
            try
            {
                EquipBD.EliminarEquip(idEquip);
                llistatEquips.RemoveAt(llistatEquips.FindIndex(x => x.IdEquip == idEquip));
                eliminat = true;
            }
            catch(Exception e)
            {
                throw e;
            }
            return eliminat;
        }

        public List<Equip> EquipsBaseDades()
        {
            return EquipBD.LlistatEquips();
        }
    }
}
