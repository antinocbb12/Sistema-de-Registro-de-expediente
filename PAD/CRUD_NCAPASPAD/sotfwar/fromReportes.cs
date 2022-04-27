using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using CPS_NEGOCIO;
namespace sotfwar
{
    public partial class fromReportes : Form
    {
        public fromReportes()
        {
            InitializeComponent();
        }
        private SqlConnection conexion = new SqlConnection("server=DESKTOP-JOV9P95;database=pad;user=sa;password=123");
        SqlCommand cmd;
        SqlDataReader dr;
        private void fromReportes_Load(object sender, EventArgs e)
        {
            dasuchuardatos();
            motratPresona();
            bscarfecha();
            bscarfecha2();
        }
        private void dasuchuardatos()
        {
            cmd = new SqlCommand("numero", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter totaltitualado = new SqlParameter("@numer_titualados", 0); totaltitualado.Direction = ParameterDirection.Output;
            SqlParameter totalbachiller = new SqlParameter("@umero_bachiler", 0); totalbachiller.Direction = ParameterDirection.Output;
            SqlParameter totalpersona = new SqlParameter("@numero_tramitante", 0); totalpersona.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(totaltitualado);
            cmd.Parameters.Add(totalbachiller);
            cmd.Parameters.Add(totalpersona);

            conexion.Open();
            cmd.ExecuteNonQuery();
            totaltitulado.Text = cmd.Parameters["@numer_titualados"].Value.ToString();
            totalbachillerrrr.Text = cmd.Parameters["@umero_bachiler"].Value.ToString();
            totalpersonaaaa.Text = cmd.Parameters["@numero_tramitante"].Value.ToString();

            conexion.Close();
        }
        private void motratPresona()
        {
            CLASENPersona objetonp = new CLASENPersona();
            dataGridView1.DataSource = objetonp.mostrarpersona();
        }
        private void bscarfecha()
        {
            SqlDataAdapter da = new SqlDataAdapter("fecha_bachiller", conexion);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@fecha", SqlDbType.DateTime).Value = dateTimePicker1.Text;
            DataTable dt = new DataTable();
            da.Fill(dt);
            this.dataGridView1.DataSource = dt;
        }
        private void bscarfecha2()
        {
            SqlDataAdapter da = new SqlDataAdapter("fecha_titulado", conexion);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@fecha", SqlDbType.DateTime).Value = dateTimePicker2.Text;
            DataTable dt = new DataTable();
            da.Fill(dt);
            this.dataGridView2.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bscarfecha();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            bscarfecha2();

        }
    }
}
