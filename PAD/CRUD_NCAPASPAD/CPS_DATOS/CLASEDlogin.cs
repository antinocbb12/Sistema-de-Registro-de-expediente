using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CPS_DATOS
{
    public class CLASEDlogin
    {
        private CLASEConexion conexion = new CLASEConexion();
        private SqlDataReader leer;
            public SqlDataReader inciarsecion(string user, string pass)
        {
            SqlCommand comando = new SqlCommand("admin", conexion.Abrirconexion());
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@usuario", user);
            comando.Parameters.AddWithValue("@passowrd", pass);
            leer = comando.ExecuteReader();
            return leer;
        }
    }
}
