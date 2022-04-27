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
    public partial class fromestudiante : Form
    {
        public fromestudiante()
        {
            InitializeComponent();
        }
        CLASENPersona objeton = new CLASENPersona();
        private string idproducto = null;
        private bool editar = false;
        private bool editar1 = false;

        private void fromestudiante_Load(object sender, EventArgs e)
        {
            motratPresona();
            listartramitante();
            motratPresona1();
            priveligio();
        }
        private void listartramitante()
        {
            CLASENPersona obetotrami = new CLASENPersona();
            cbntramitante.DataSource = obetotrami.listramitante();
            cbntramitante.DisplayMember = "nomtr_tramitante";
            cbntramitante.ValueMember = "id_tramite";
        }
        private void motratPresona()
        {
            CLASENPersona objetonp = new CLASENPersona();
            dataGridView1.DataSource = objetonp.mostrarpersona();
        }

        private void motratPresona1()
        {
            CLASENPersona objeton1p = new CLASENPersona();
            dataGridView2.DataSource = objeton1p.mostrarpersona1();
        }
        private void limpiarfrom()
        {
            txtnombre.Clear();
            txtapellidos.Clear();
            //cbntramitante.Clear();
        }
        private void btnguardar_Click(object sender, EventArgs e)
        {
            if (editar == false)
            {

                try
                {
                    
                        /* DateTime date = Convert.ToDateTime(dateTimePicker1);*/
                        objeton.insetarnpersona(txtnombre.Text, txtapellidos.Text, Convert.ToInt32(cbntramitante.SelectedValue));
                        MessageBox.Show("se inserto correctamente");
                        motratPresona();
                        motratPresona1();
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
                    objeton.editarpersona(txtnombre.Text, txtapellidos.Text, Convert.ToInt32(cbntramitante.SelectedValue), idproducto);
                    MessageBox.Show("se edito correctamente");

                    motratPresona();
                    limpiarfrom();
                    editar = false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("no se puede editar los datos por" + ex);
                }
            }

        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                editar = true;
                txtnombre.Text = dataGridView1.CurrentRow.Cells["nombre"].Value.ToString();
                txtapellidos.Text = dataGridView1.CurrentRow.Cells["apellidos"].Value.ToString();
                cbntramitante.Text = dataGridView1.CurrentRow.Cells["tramitante"].Value.ToString();
                idproducto = dataGridView1.CurrentRow.Cells["numero"].Value.ToString();
            }

            else
                MessageBox.Show("selecione una fila por favor");
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
           
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    idproducto = dataGridView1.CurrentRow.Cells["numero"].Value.ToString();
                    objeton.elminarprod(idproducto);
                    MessageBox.Show("eliminado correctamente");
                    motratPresona();
                }
                else
                {
                    MessageBox.Show("selecione una fila por favor");
                }
            
        }

        private void editar2_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                editar1 = true;
                txtnombre.Text = dataGridView2.CurrentRow.Cells["nombre"].Value.ToString();
                txtapellidos.Text = dataGridView2.CurrentRow.Cells["apellidos"].Value.ToString();
                cbntramitante.Text = dataGridView2.CurrentRow.Cells["tramitante"].Value.ToString();
                idproducto = dataGridView2.CurrentRow.Cells["numero"].Value.ToString();
            }
            else
                MessageBox.Show("selecione una fila por favor");
        }

        private void elimar2_Click(object sender, EventArgs e)
        {
          

                if (dataGridView2.SelectedRows.Count > 0)
                {
                    idproducto = dataGridView2.CurrentRow.Cells["numero"].Value.ToString();
                    objeton.elminarprod(idproducto);
                    MessageBox.Show("eliminado correctamente");
                    motratPresona1();
                }
                else
                {
                    MessageBox.Show("selecione una fila por favor");
                }
      

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (editar1 == false)
            {

                try
                {
                    objeton.insetarnpersona(txtnombre.Text, txtapellidos.Text, Convert.ToInt32(cbntramitante.SelectedValue));
                    MessageBox.Show("se inserto correctamente");
                    motratPresona1();

                    limpiarfrom();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("no se puede insertar los datos por" + ex);
                }
            }
            //editar
            if (editar1 == true)
            {
                try
                {
                    objeton.editarpersona(txtnombre.Text, txtapellidos.Text, Convert.ToInt32(cbntramitante.SelectedValue), idproducto);
                    MessageBox.Show("se edito correctamente");
                    motratPresona1();


                    limpiarfrom();

                    editar1 = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("no se puede editar los datos por" + ex);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //crear un objeto de la clase estudiante
            CLASENPersona estudiante1 = new CLASENPersona();
            //instanciamos la clase dataset
            DataSet almasenar = new DataSet();
            //llenamos de valores el dataset
            estudiante1.buscada_tituladoP(textBox1.Text).Fill(almasenar);//FILL ES UN METODO es un objeto dataset
            dataGridView1.DataSource = almasenar.Tables[0];
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            CLASENPersona estudiante1 = new CLASENPersona();
            //instanciamos la clase dataset
            DataSet almasenarR = new DataSet();
            //llenamos de valores el dataset
            estudiante1.buscada_tituladoB(textBox2.Text).Fill(almasenarR);//FILL ES UN METODO es un objeto dataset
            dataGridView2.DataSource = almasenarR.Tables[0];
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            fromObservaciones from = Owner as fromObservaciones;

            from.numeropersona.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            this.Close();
        }

        private void dataGridView2_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frombachiller frm = Owner as frombachiller;
            frm.numeropersona.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            this.Close();
        }

        private void priveligio()
        {
            if (Program.Cargo != "administrador")
            {
                btneliminar.Enabled = false;
                elimar2.Enabled = false;
            }
        }
    }
    }

