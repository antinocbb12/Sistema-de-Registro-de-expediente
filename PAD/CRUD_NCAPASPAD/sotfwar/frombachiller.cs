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
    public partial class frombachiller : Form
    {
        public frombachiller()
        {
            InitializeComponent();
        }
        CLASENBachiller objetonbach = new CLASENBachiller();
        private string idproducto = null;
        private bool editar = false;

        private void frombachiller_Load(object sender, EventArgs e)
        {
            motrarbachiller();
            priveligio();
        }
        private void motrarbachiller()
        {
            CLASENBachiller objnobachilP = new CLASENBachiller();
            dataGridView1.DataSource = objnobachilP.mostrarNobachiller();

        }
        private void limpiarfrom()
        {
            txtremitobservado.Clear();
            txtobservacioncorregida.Clear();
            txtsegobservado.Clear();
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
                    objetonbach.insertarNeg(revisado.Text, txtremitobservado.Text, txtobservacioncorregida.Text, txtsegobservado.Text, oknumero.Text, txtrevisado.Text, Convert.ToInt32(numeropersona.Text));
                    MessageBox.Show("se inserto correctamente");
                    motrarbachiller();
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
                    objetonbach.editarNegocio(revisado.Text, txtremitobservado.Text, txtobservacioncorregida.Text, txtsegobservado.Text, oknumero.Text, txtrevisado.Text, Convert.ToInt32(numeropersona.Text), idproducto);
                    MessageBox.Show("se registro correctamente");
                    motrarbachiller();
                    limpiarfrom();


                    editar = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("no pudo registrar " + ex);
                }
            }
        }

        private void btnregistrar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                editar = true;
                revisado.Text = dataGridView1.CurrentRow.Cells["revisado"].Value.ToString();
                txtremitobservado.Text = dataGridView1.CurrentRow.Cells["remitodo_observado"].Value.ToString();
                txtobservacioncorregida.Text = dataGridView1.CurrentRow.Cells["observacion_corregida"].Value.ToString();
                txtsegobservado.Text = dataGridView1.CurrentRow.Cells["segunda_observacion"].Value.ToString();
                oknumero.Text = dataGridView1.CurrentRow.Cells["ok_numero"].Value.ToString();
                txtrevisado.Text = dataGridView1.CurrentRow.Cells["fecha_ok"].Value.ToString();
                numeropersona.Text = dataGridView1.CurrentRow.Cells["numero"].Value.ToString();
                idproducto = dataGridView1.CurrentRow.Cells["Nr_bachillar"].Value.ToString();
            }
            else
                MessageBox.Show("selecione una fila por favor");
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                idproducto = dataGridView1.CurrentRow.Cells["Nr_bachillar"].Value.ToString();
                objetonbach.elminarprod(idproducto);
                MessageBox.Show("eliminado correctamente");
                motrarbachiller();
            }
            else
                MessageBox.Show("selecione una fila por favor");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //crear un objeto de la clase estudiante
            CLASENBachiller estudiante1 = new CLASENBachiller();
            //instanciamos la clase dataset
            DataSet almasenar = new DataSet();
            //llenamos de valores el dataset
            estudiante1.buscada_bachiller(textBox1.Text).Fill(almasenar);//FILL ES UN METODO es un objeto dataset
            dataGridView1.DataSource = almasenar.Tables[0];
        }

        private void btnbuscarid_Click(object sender, EventArgs e)
        {
            fromestudiante fr = new fromestudiante();
            AddOwnedForm(fr);
            fr.Show();
        }
        private void priveligio()
        {
            if (Program.Cargo != "administrador")
            {
                btneliminar.Enabled = false;
            }
        }
    }
}
