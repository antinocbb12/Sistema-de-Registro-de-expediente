using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CPS_DATOS
{
    public class CLASEPersona
    {
        private CLASEConexion conexion = new CLASEConexion();
        SqlDataReader lee;
      
        SqlCommand comando = new SqlCommand();

        public DataTable Mostrar()
        {
            //transacional
            DataTable tabla = new DataTable();
            comando.Connection = conexion.Abrirconexion();
            comando.CommandText = "motrarpersona_titulado";

            comando.CommandType = CommandType.StoredProcedure;
            lee = comando.ExecuteReader();
            tabla.Load(lee);
            conexion.Cerrarconexion();
            return tabla;
        }
        public DataTable Mostrar1()
        {
            //transacional
            DataTable tabla = new DataTable();
            comando.Connection = conexion.Abrirconexion();
            comando.CommandText = "motrarpersona_bachiller";

            comando.CommandType = CommandType.StoredProcedure;
            lee = comando.ExecuteReader();
            tabla.Load(lee);
            conexion.Cerrarconexion();
            return tabla;
        }
        public DataTable CDtramitante()
        {
            //transacional
            DataTable tabla = new DataTable();
            comando.Connection = conexion.Abrirconexion();
            comando.CommandText = "listaregresado";
            comando.CommandType = CommandType.StoredProcedure;
            lee = comando.ExecuteReader();
            tabla.Load(lee);
            conexion.Cerrarconexion();
            return tabla;
        }

        public void  insertarPersona (string nombre,string apellidos,int tramitante)
        {
            comando.Connection = conexion.Abrirconexion();
            comando.CommandText = "insertarpersona";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@apellidos", apellidos);
            comando.Parameters.AddWithValue("@tramitante", tramitante);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }
        public void Editar (string nombre, string apellidos, int tramitante  ,int ide)
        {
            comando.Connection = conexion.Abrirconexion();
            comando.CommandText = "editarpersona";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@apellidos", apellidos);
            comando.Parameters.AddWithValue("@tramitante", tramitante);
            comando.Parameters.AddWithValue("@id", ide);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }
        public void elimnar  (int id)
        {
            comando.Connection = conexion.Abrirconexion();
            comando.CommandText = "eliminar";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idpro", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }
        }
    }

