using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PorraGironaCSharp.Capes.DataBase
{
    class BaseDadesUsuari
    {
        MySqlConnection connexio;
        private string servidor;
        private string port;
        private string usuari;
        private string contrasenya;
        private string basedades;



        public BaseDadesUsuari()
        {
            connexio = new MySqlConnection($"server=localhost; port=3306; user=daw; password=daw; database=hospital");
        }
        public BaseDadesUsuari(string servidor, string usuari, string port, string contrasenya, string basedades)
        {
            this.servidor = servidor;
            this.port = port;
            this.usuari = usuari;
            this.contrasenya = contrasenya;
            this.basedades = basedades;

            connexio = new MySqlConnection($"server={servidor}; port={port}; user={usuari}; password={contrasenya}; database={basedades}");
        }
    }
}
