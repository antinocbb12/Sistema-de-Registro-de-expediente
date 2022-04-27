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
    public class CLASENPersona
    {
        private CLASEConexion conexion = new CLASEConexion();
        SqlDataReader lee;
        SqlCommand comando = new SqlCommand();

        private CLASEPersona objetoclas = new CLASEPersona();
        public DataTable mostrarpersona()
        {
            DataTable tabla = new DataTable();
            tabla = objetoclas.Mostrar();
            return tabla;
        }
        public DataTable mostrarpersona1()
        {
            DataTable tabla = new DataTable();
            tabla = objetoclas.Mostrar1();
            return tabla;
        }
        public DataTable listramitante()
        {
            DataTable tabla = new DataTable();
            tabla = objetoclas.CDtramitante();
            return tabla;
        }
        public SqlDataAdapter buscada_tituladoP(string filtro)
        {
            comando.Connection = conexion.Abrirconexion();
            SqlCommand da = new SqlCommand(" select id_persona as numero ,apellidos,nombre,nomtr_tramitante AS TRAMITANTE from persona p   inner join tramite  t on p.id_tramite = t.id_tramite   where apellidos like '" + filtro + "%'", conexion.Abrirconexion());
            /* comando.CommandType = CommandType.StoredProcedure;
             comando.Parameters.AddWithValue("@filtro", filtro);*/
            SqlDataAdapter ejecutar = new SqlDataAdapter(da);
            comando.Parameters.Clear();
            return ejecutar;

        }
        public SqlDataAdapter buscada_tituladoB(string filtro)
        {
            comando.Connection = conexion.Abrirconexion();
            SqlCommand da = new SqlCommand(" select id_persona as numero ,apellidos,nombre,nomtr_tramitante AS TRAMITANTE from persona p   inner join tramite  t on p.id_tramite = t.id_tramite   where apellidos like '" + filtro + "%'", conexion.Abrirconexion());
            /* comando.CommandType = CommandType.StoredProcedure;
             comando.Parameters.AddWithValue("@filtro", filtro);*/
            SqlDataAdapter ejecutar = new SqlDataAdapter(da);
            comando.Parameters.Clear();
            return ejecutar;

        }
        public void insetarnpersona(string nombre, string apellidos, int tramitante)
        {
            objetoclas.insertarPersona(nombre, apellidos,Convert.ToInt32(tramitante) );
        }
        public void editarpersona(string nombre, string apellidos, int tramitante,string id)
        {
            objetoclas.Editar(nombre, apellidos, Convert.ToInt32(tramitante), Convert.ToInt32(id));
        }
        public void elminarprod(string id)
        {
            objetoclas.elimnar(Convert.ToInt32(id));
        }
    }
}
