using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using CPS_NEGOCIO;
using System.Data.SqlClient;

namespace sotfwar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtusuario_Enter(object sender, EventArgs e)
        {
            if (txtusuario.Text == "USUARIO")
            {
                txtusuario.Text = "";
                txtusuario.ForeColor = Color.LightGray;
            }
        }

        private void txtusuario_Leave(object sender, EventArgs e)
        {

            if (txtusuario.Text == "")
                txtusuario.Text = "USUARIO";
            txtusuario.ForeColor = Color.DarkGray;
        }

        private void txtpaswor_Enter(object sender, EventArgs e)
        {
            if (txtpaswor.Text == "PASSWORD")
                txtpaswor.Text = "";
            txtpaswor.ForeColor = Color.LightGray;
            txtpaswor.UseSystemPasswordChar = true;
        }

        private void txtpaswor_Leave(object sender, EventArgs e)
        {
            if (txtpaswor.Text == "")
                txtpaswor.Text = "PASSWORD";
            txtpaswor.ForeColor = Color.DarkGray;
            txtpaswor.UseSystemPasswordChar = true;
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void btnminimisar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            CLASENlogin obplong = new CLASENlogin();
            SqlDataReader loguear;
            obplong.usuario = txtusuario.Text;
            obplong.contraseña = txtpaswor.Text;
            loguear = obplong.iniciar_secion();
            if (loguear.Read() == true)
            {
                this.Hide();
                fromprincipal oplog = new fromprincipal();
                Program.Cargo = loguear["cargo"].ToString();

                oplog.Show();
            }
            else
                MessageBox.Show("usuario contraseña invalido");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
