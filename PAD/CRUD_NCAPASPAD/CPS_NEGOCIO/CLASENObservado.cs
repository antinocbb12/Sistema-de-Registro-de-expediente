using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using CPS_DATOS;
namespace CPS_NEGOCIO
{
    public class CLASENObservado
    {

        private CLASEConexion conexion = new CLASEConexion();
        SqlDataReader lee;

        SqlCommand comando = new SqlCommand();
        private CLASEDObservado observadoN = new CLASEDObservado();
             public DataTable mostrarNobservado()
        {
            DataTable tabla = new DataTable();
            tabla = observadoN.Mostrarobservado();
            return tabla;
        }
        public DataTable mostrarbusquedao()
        {
            DataTable tabla = new DataTable();
            tabla = observadoN.Mostrarobservado();
            SqlDataAdapter da = new SqlDataAdapter();
            da.Fill(tabla);
           
            return tabla;
        }
        public SqlDataAdapter buscada_titulado(string filtro)
        {
           

            comando.Connection = conexion.Abrirconexion();
            SqlCommand da = new SqlCommand(" select id_titulado as Nr_titulado, p.id_persona as numero ,apellidos,nombre,nomtr_tramitante AS TRAMITANTE,revisado,remitodo_observado,observacion_corregida,segunda_observacion,ok_numero,fecha_OK  from persona p inner join tramite tr on p.id_tramite = tr.id_tramite inner join tramite_titulado t on p.id_persona = t.id_persona where apellidos like '" + filtro+ "%'", conexion.Abrirconexion());
            /* comando.CommandType = CommandType.StoredProcedure;
             comando.Parameters.AddWithValue("@filtro", filtro);*/
            SqlDataAdapter ejecutar = new SqlDataAdapter(da);
            comando.Parameters.Clear();
            return ejecutar;

        }

        public void insetartramititulado(string revisado, string remitido_revisado, string observacion_corregida, string segunda_observacion, string ok_numero, string fecha_ok,  int numero_persona)
        {
            observadoN.insertartitulado(revisado, remitido_revisado, observacion_corregida, segunda_observacion,ok_numero ,fecha_ok, Convert.ToInt32(numero_persona));
        }
        public void editarNegocio(string revisado, string remitido_revisado, string observacion_corregida, string segunda_observacion, string ok_numero, string fecha_ok, int numero_persona, string idti)
        {
            observadoN.Editar(revisado, remitido_revisado, observacion_corregida, segunda_observacion, ok_numero, fecha_ok, Convert.ToInt32(numero_persona),Convert.ToInt32(idti));
        }
        public void elminarprod(string id)
        {
            observadoN.eliminar_titulado(Convert.ToInt32(id));
        }
        /*public void busquedatitulo (  string filtro)
        {
            observadoN.buscada_titulado(filtro);
        }*/
    }
}
