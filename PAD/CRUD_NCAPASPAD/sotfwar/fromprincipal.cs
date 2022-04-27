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
    public partial class fromprincipal : Form
    {
        public fromprincipal()
        {
            InitializeComponent();
        }

        private void privilegiado_suario()
        {
            /* if(Program.cargo!= "administrador")
             {
                 button2.Enabled = false;
             }*/

        }
        private  void motrarcargo()
        {
            lblcargo.Text = Program.Cargo;
        }
        
        private void btncerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
        int lx, ly;

        private void btnrestaurar_Click(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Normal;
            this.Size = new Size(1536, 687);
            this.Location = new Point(lx, ly);
            btnrestaurar.Visible = false;
            maximisar.Visible = true;
        }

        private void fromprincipal_Load(object sender, EventArgs e)
        {
            motrarcargo();

        }

        private void btnminimisar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void maximisar_Click(object sender, EventArgs e)
        {
            lx = this.Location.X;
            ly = this.Location.Y;
            //this.WindowState = FormWindowState.Maximized;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            maximisar.Visible = false;
            btnrestaurar.Visible = true;
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        private void barratitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblhora.Text = DateTime.Now.ToLongTimeString();
            lblfecha.Text = DateTime.Now.ToLongDateString();
        }
        private void AbrirFormInPanel(object formHijo)
        {
            if (this.panelcontrol.Controls.Count > 0)
                this.panelcontrol.Controls.RemoveAt(0);
            Form fh = formHijo as Form;
            fh.TopLevel = false;
            fh.FormBorderStyle = FormBorderStyle.None;
            fh.Dock = DockStyle.Fill;
            this.panelcontrol.Controls.Add(fh);
            this.panelcontrol.Tag = fh;
            fh.Show();
        }

        private void btnestudiante_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new fromestudiante());

        }
        private void AbrirForm(object formHijo1)
        {
            if (this.panelcontrol.Controls.Count > 0)
                this.panelcontrol.Controls.RemoveAt(0);
            Form fh = formHijo1 as Form;
            fh.TopLevel = false;
            fh.FormBorderStyle = FormBorderStyle.None;
            fh.Dock = DockStyle.Fill;
            this.panelcontrol.Controls.Add(fh);
            this.panelcontrol.Tag = fh;
            fh.Show();
        }
        private void btnobservado_Click(object sender, EventArgs e)
        {
            AbrirForm(new fromObservaciones());

        }
        private void AbrirFrombachiller(object formHijo1)
        {
            if (this.panelcontrol.Controls.Count > 0)
                this.panelcontrol.Controls.RemoveAt(0);
            Form fh = formHijo1 as Form;
            fh.TopLevel = false;
            fh.FormBorderStyle = FormBorderStyle.None;
            fh.Dock = DockStyle.Fill;
            this.panelcontrol.Controls.Add(fh);
            this.panelcontrol.Tag = fh;
            fh.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            AbrirFrombachiller(new frombachiller());

        }
        private void AbrirFormRpor(object formHijo1)
        {
            if (this.panelcontrol.Controls.Count > 0)
                this.panelcontrol.Controls.RemoveAt(0);
            Form fh = formHijo1 as Form;
            fh.TopLevel = false;
            fh.FormBorderStyle = FormBorderStyle.None;
            fh.Dock = DockStyle.Fill;
            this.panelcontrol.Controls.Add(fh);
            this.panelcontrol.Tag = fh;
            fh.Show();
        }
        protected override void WndProc(ref Message msj)
        {
            const int CoordenadaWFP = 0x84; //ibicacion de la parte derecha inferior del form
            const int DesIzquierda = 16;
            const int DesDerecha = 17;
            if (msj.Msg == CoordenadaWFP)
            {
                int x = (int)(msj.LParam.ToInt64() & 0xFFFF);
                int y = (int)((msj.LParam.ToInt64() & 0xFFFF0000) >> 16);
                Point CoordenadaArea = PointToClient(new Point(x, y));
                Size TamañoAreaForm = ClientSize;
                if (CoordenadaArea.X >= TamañoAreaForm.Width - 16 && CoordenadaArea.Y >= TamañoAreaForm.Height - 16 && TamañoAreaForm.Height >= 16)
                {
                    msj.Result = (IntPtr)(IsMirrored ? DesIzquierda : DesDerecha);
                    return;
                }
            }
            base.WndProc(ref msj);
        }
        private int tolerance = 15;
        private const int WM_NCHITTEST = 132;
        private const int HTBOTTOMRIGHT = 17;
        private Rectangle sizeGripRectangle;
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            var region = new Region(new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height));

            sizeGripRectangle = new Rectangle(this.ClientRectangle.Width - tolerance, this.ClientRectangle.Height - tolerance, tolerance, tolerance);

            region.Exclude(sizeGripRectangle);
            this.panelcontrol.Region = region;
            this.Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {

            SolidBrush blueBrush = new SolidBrush(Color.FromArgb(55, 61, 69));
            e.Graphics.FillRectangle(blueBrush, sizeGripRectangle);

            base.OnPaint(e);
            ControlPaint.DrawSizeGrip(e.Graphics, Color.Transparent, sizeGripRectangle);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (Program.Cargo == "administrador")

                AbrirFormRpor(new fromReportes());
            else
                MessageBox.Show("usted no tiene permiso ");
        }

        private void lblcargo_Click(object sender, EventArgs e)
        {

        }

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
    }

}
