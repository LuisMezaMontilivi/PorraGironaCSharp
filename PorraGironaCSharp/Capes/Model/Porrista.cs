using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorraGironaCSharp.Capes.Model
{
    public class Porrista: Usuari
    {
        private DateTime dataAlta;
        private int idPorrista;
        private int puntuacioTotal;
       // private List<Historic> historics;

       

        public Porrista(string nom, string cognom, string dni, string alias, string contrasenya, DateTime dataAlta, int idPorrista, int puntuacioTotal) : base(nom, cognom, dni, alias, contrasenya)
        {
            this.dataAlta = dataAlta;
            this.idPorrista = idPorrista;
            this.puntuacioTotal = puntuacioTotal;
           
        }

        public DateTime DataAlta { get => dataAlta; set => dataAlta = value; }
        public int IdPorrista { get => idPorrista; set => idPorrista = value; }
        public int PuntuacioTotal { get => puntuacioTotal; set => puntuacioTotal = value; }
       // internal List<Historic> Historics { get => historics; set => historics = value; }

        public bool AugmentarPuntuacio(int punts)
        {
            throw new System.NotImplementedException();
        }

        public void AfegirHistoric(Historic historic)
        {
            throw new System.NotImplementedException();
        }

        public void FerPrediccio()
        {
            throw new System.NotImplementedException();
        }

        public void VeurePrediccions()
        {
            throw new System.NotImplementedException();
        }

        public void VeureTemporades()
        {
            throw new System.NotImplementedException();
        }
    }
}
