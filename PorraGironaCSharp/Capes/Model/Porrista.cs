using PorraGironaCSharp.Capes.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorraGironaCSharp.Capes.Model
{
    public class Porrista: Usuari
    {

        private int idPorrista;
        private int puntuacio;
        private int posicioRanking;
       
       
        private int puntuacioTotal;
       // private List<Historic> historics;

       
        public Porrista() { }
        public Porrista(string nom, string cognom, string dni, string alias, string contrasenya, int idPorrista, int puntuacioTotal) : base(nom, cognom, dni, alias)
        {
            
           
            this.puntuacioTotal = puntuacioTotal;
           
        }

        public Porrista(string nom, string cognom, string dni, string alias,int idUsuari, int puntuacioTotal) : base(nom, cognom, dni, alias, idUsuari )
        {
            
            
            this.puntuacioTotal = puntuacioTotal;

        }


       
        
        public int PuntuacioTotal { get => puntuacioTotal; set => puntuacioTotal = value; }
        public int PosicioRanking { get => posicioRanking; set => posicioRanking = value; }

        // internal List<Historic> Historics { get => historics; set => historics = value; }

        public bool AugmentarPuntuacio(int punts)
        {
            throw new System.NotImplementedException();
        }

        public void AfegirHistoric(Historic historic)
        {
            throw new System.NotImplementedException();
        }

        public void FerPrediccio(Porra porra, string alias)
        {

           if(!UsuariBD.InsertarPorra(porra, alias))
            {
                UsuariBD.ModificarPorra(porra, alias);
            }
            
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
