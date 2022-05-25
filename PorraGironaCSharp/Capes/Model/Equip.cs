using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PorraGironaCSharp.Capes.Model
{
    public class Equip
    {
        public Equip(int id, string nom, string mun, string camp, string ruta)
        {
            idEquip = id; nomEquip = nom; municipi = mun; nomCamp = camp; rutaImatge = ruta;
        }

        private int idEquip;
        private string municipi;
        private string nomCamp;
        private string nomEquip;
        private string rutaImatge;


        public int IdEquip
        {
            get { return idEquip; }
        }

        public string Municipi
        {
            get { return municipi; }
        }
        public string NomCamp
        {
            get { return nomCamp; }
            set { nomCamp = value; }
        }
        public string NomEquip
        {
            get { return nomEquip; }
        }

        public string RutaEscut
        {
            get { return rutaImatge; }
            set { rutaImatge = value; }
        }
    }
}
