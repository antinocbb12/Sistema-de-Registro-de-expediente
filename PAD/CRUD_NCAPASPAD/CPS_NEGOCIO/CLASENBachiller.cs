using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data;
using CPS_DATOS;

namespace CPS_NEGOCIO
{
    public class CLASENBachiller
    {
        private CLASEConexion conexion = new CLASEConexion();
        SqlDataReader lee;
        
        SqlCommand comando = new SqlCommand();

        private CLASEDBachiller bachillerN = new CLASEDBachiller();
        public DataTable mostrarNobachiller()
        {
            DataTable tabla = new DataTable();
            tabla = bachillerN.Mostrarobachiller();
            return tabla;
        }
       
        public SqlDataAdapter buscada_bachiller(string filtro)
        {


            comando.Connection = conexion.Abrirconexion();
            SqlCommand da = new SqlCommand(" select id_bachiller as Nr_bachillar ,p.id_persona as numero ,apellidos,nombre,nomtr_tramitante AS TRAMITANTE,revisado,remitodo_observado,observacion_corregida,segunda_observacion,ok_numero,fecha_OK from persona p inner join tramite tr  on p.id_tramite = tr.id_tramite inner join tramite_bachiller b on p.id_persona = b.id_persona     where apellidos like '" + filtro + "%'", conexion.Abrirconexion());
            /* comando.CommandType = CommandType.StoredProcedure;
             comando.Parameters.AddWithValue("@filtro", filtro);*/
            SqlDataAdapter ejecutar = new SqlDataAdapter(da);
            comando.Parameters.Clear();
            return ejecutar;

        }
        public void insertarNeg(string revisado, string remitido_revisado, string observacion_corregida, string segunda_observacion, string ok_numero, string fecha_ok, int numero_persona)
        {
            bachillerN.insertarbachillar(revisado, remitido_revisado, observacion_corregida, segunda_observacion, ok_numero, fecha_ok, Convert.ToInt32(numero_persona));
        }
        public void editarNegocio(string revisado, string remitido_revisado, string observacion_corregida, string segunda_observacion, string ok_numero, string fecha_ok, int numero_persona, string idti)
        {
            bachillerN.Editar(revisado, remitido_revisado, observacion_corregida, segunda_observacion,ok_numero, fecha_ok, Convert.ToInt32(numero_persona), Convert.ToInt32(idti));
        }
        public void elminarprod(string id)
        {
            bachillerN.eliminar_bachiller(Convert.ToInt32(id));
        }
    }
}
