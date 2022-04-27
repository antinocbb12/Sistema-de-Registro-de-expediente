using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CPS_DATOS
{
    public class CLASEDBachiller
    {
        private CLASEConexion conexion = new CLASEConexion();
        SqlDataReader lee;

        SqlCommand comando = new SqlCommand();

        public DataTable Mostrarobachiller()
        {
            //transacional
            DataTable tabla = new DataTable();
            comando.Connection = conexion.Abrirconexion();
            comando.CommandText = "motrar_tr_bachiller";
            comando.CommandType = CommandType.StoredProcedure;
            lee = comando.ExecuteReader();
            tabla.Load(lee);
            conexion.Cerrarconexion();
            return tabla;
        }
        public void insertarbachillar(string revisado, string remitido_revisado, string observacion_corregida, string segunda_observacion, string ok_numero, string fecha_ok, int numero_persona)
        {
            comando.Connection = conexion.Abrirconexion();
            comando.CommandText = "insertarbachillar";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@revisado", revisado);
            comando.Parameters.AddWithValue("@remitido_revisado", remitido_revisado);
            comando.Parameters.AddWithValue("@observacion_corregida", observacion_corregida);
            comando.Parameters.AddWithValue("@segunda_observacion", segunda_observacion);
            comando.Parameters.AddWithValue("@ok_numero", ok_numero);
            comando.Parameters.AddWithValue("@fecha_ok", fecha_ok);
            comando.Parameters.AddWithValue("@numero_persona", numero_persona);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }
        public void Editar(string revisado, string remitido_revisado, string observacion_corregida, string segunda_observacion, string ok_numero, string fecha_ok, int numero_persona, int idti)
        {
            comando.Connection = conexion.Abrirconexion();
            comando.CommandText = "editarbachiller";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@revisado", revisado);
            comando.Parameters.AddWithValue("@remitido_revisado", remitido_revisado);
            comando.Parameters.AddWithValue("@observacion_corregida", observacion_corregida);
            comando.Parameters.AddWithValue("@segunda_observacion", segunda_observacion);
            comando.Parameters.AddWithValue("@ok_numero", ok_numero);
            comando.Parameters.AddWithValue("@fecha_ok", fecha_ok);
            comando.Parameters.AddWithValue("@numero_persona", numero_persona);
            comando.Parameters.AddWithValue("@id", idti);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }
        public void eliminar_bachiller(int id)
        {
            comando.Connection = conexion.Abrirconexion();
            comando.CommandText = "eliminar_bachiller";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idpro", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }
    }
}
