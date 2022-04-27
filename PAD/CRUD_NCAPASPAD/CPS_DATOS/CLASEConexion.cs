using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace CPS_DATOS
{
    public class CLASEConexion
    {
        private SqlConnection conexion = new SqlConnection("server=DESKTOP-JOV9P95;database=pad;user=sa;password=123");
        public SqlConnection Abrirconexion()
        {
            if (conexion.State == ConnectionState.Closed)
                conexion.Open();
            return conexion;
        }
        public SqlConnection Cerrarconexion()
        {
            if (conexion.State == ConnectionState.Open)
                conexion.Close();
            return conexion;
        }
    }
}
