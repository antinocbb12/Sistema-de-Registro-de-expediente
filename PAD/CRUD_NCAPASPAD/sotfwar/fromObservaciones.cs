using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CPS_NEGOCIO;

namespace sotfwar
{
    public partial class fromObservaciones : Form
    {
        public fromObservaciones()
        {
            InitializeComponent();
        }
        CLASENObservado objPretitulado = new CLASENObservado();
        private string idproducto = null;
        private bool editar = false;
        private void fromObservaciones_Load(object sender, EventArgs e)
        {
            motratOservadoP();
            priveligio();

        }
        private void motratOservadoP()
        {
            CLASENObservado objnoservado = new CLASENObservado();
            dataGridView1.DataSource = objnoservado.mostrarNobservado();

        }
        private void limpiarfrom()
        {
            txtremitidoobserv.Clear();
            txtobservacioncorregida.Clear();
            txtsegobsevacion.Clear();
            oknumero.Clear();
            txtrevisado.Clear();

            //cbntramitante.Clear();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (editar == false)
            {
                try
                {
                    /* DateTime date = Convert.ToDateTime(dateTimePicker1);*/
                    objPretitulado.insetartramititulado(revisado.Text, txtremitidoobserv.Text, txtobservacioncorregida.Text, txtsegobsevacion.Text, oknumero.Text, txtrevisado.Text, Convert.ToInt32(numeropersona.Text));
                    MessageBox.Show("se inserto correctamente");
                    motratOservadoP();
                    limpiarfrom();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("no se puede insertar los datos por" + ex);
                }
            }
            //editar
            if (editar == true)
            {
                try
                {
                    objPretitulado.editarNegocio(revisado.Text, txtremitidoobserv.Text, txtobservacioncorregida.Text, txtsegobsevacion.Text, oknumero.Text, txtrevisado.Text, Convert.ToInt32(numeropersona.Text), idproducto);
                    MessageBox.Show("se registro correctamente");
                    motratOservadoP();
                    limpiarfrom();


                    editar = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("no se puede registrar" + ex);
                }
            }
        }

        private void btneditarobservado_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                editar = true;
                revisado.Text = dataGridView1.CurrentRow.Cells["revisado"].Value.ToString();
                txtremitidoobserv.Text = dataGridView1.CurrentRow.Cells["remitodo_observado"].Value.ToString();
                txtobservacioncorregida.Text = dataGridView1.CurrentRow.Cells["observacion_corregida"].Value.ToString();
                txtsegobsevacion.Text = dataGridView1.CurrentRow.Cells["segunda_observacion"].Value.ToString();
                oknumero.Text = dataGridView1.CurrentRow.Cells["ok_numero"].Value.ToString();
                txtrevisado.Text = dataGridView1.CurrentRow.Cells["fecha_ok"].Value.ToString();
                numeropersona.Text = dataGridView1.CurrentRow.Cells["numero"].Value.ToString();
                idproducto = dataGridView1.CurrentRow.Cells["Nr_titulado"].Value.ToString();
            }
            else
                MessageBox.Show("selecione una fila por favor");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //crear un objeto de la clase estudiante
            CLASENObservado estudiante1 = new CLASENObservado();
            //instanciamos la clase dataset
            DataSet almasenar = new DataSet();
            //llenamos de valores el dataset
            estudiante1.buscada_titulado(textBox1.Text).Fill(almasenar);//FILL ES UN METODO es un objeto dataset
            dataGridView1.DataSource = almasenar.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                idproducto = dataGridView1.CurrentRow.Cells["Nr_titulado"].Value.ToString();
                objPretitulado.elminarprod(idproducto);
                MessageBox.Show("eliminado correctamente");
                motratOservadoP();
            }
            else
                MessageBox.Show("selecione una fila por favor");
        }

        private void btnbuscarid_Click(object sender, EventArgs e)
        {
            fromestudiante frm = new fromestudiante();
            AddOwnedForm(frm);
            frm.Show();
        }
        private void priveligio()
        {
            if (Program.Cargo != "administrador")
            {
                button1.Enabled = false;               
            }
        }
    }
}
