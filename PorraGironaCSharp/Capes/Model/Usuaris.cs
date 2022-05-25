using PorraGironaCSharp.Capes.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorraGironaCSharp.Capes.Model
{
    public class Usuaris
    {
        List<Usuari> usuaris;

        public Usuaris()
        {
            usuaris = UsuariBD.LlistatUsuaris();
        }

        public bool AfegirUsuari(Usuari u)
        {
            //codi que falla
            //bool existeixAlias = usuaris.FindIndex(x => x.alias == u.alias) != -1;
            //if (!existeixAlias)
            //{
            //    UsuariBD.InsertarUsuariBD(u);
            //    usuaris.Add(u);
            //}
            //return !existeixAlias;
            UsuariBD.InsertarUsuariBD(u); //falla inclós només amb això, referencia a objeto no establecida como instancia de un objeto
            return true;
        }

        public Usuari RecuperarUsuari(int posicio)
        {
            return usuaris[posicio];
        }

        public void EliminarUsuari(Usuari del)
        {
            usuaris.Remove(del);
            PorraBD.EliminarPorresUsuari(del.alias);
            UsuariBD.EliminarUsuari(del.alias);
        }

        public void ActualitzarUsuari(Usuari actualitzar)
        {
            //Usuari enllacActu = usuaris.Find(x => x.alias == actualitzar.alias);
            //enllacActu = actualitzar; //substituim directament tota la informació
            UsuariBD.ActualitzarUsuariBD(actualitzar);
        }

        public List<string> AliesUsuaris()
        {
            List<string> alies = new List<string>();
            foreach(Usuari X in usuaris)
            {
                alies.Add(X.alias);
            }
            return alies;
        }
    }
}
