using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CPS_DATOS;
using System.Data.SqlClient;

namespace CPS_NEGOCIO
{
    public class CLASENlogin
    {
        private CLASEDlogin obnlong = new CLASEDlogin();
        private string _usuario;
        private string _contraseña;

        public string usuario
        {
            set { _usuario = value; }
            get { return _usuario; }
        }
        public string contraseña
        {
            set { _contraseña = value; }
            get { return _contraseña; }
        }
        
        public SqlDataReader iniciar_secion() {
            SqlDataReader loguear;
            loguear = obnlong.inciarsecion(usuario, contraseña);

            return loguear;
        }
    }
}
