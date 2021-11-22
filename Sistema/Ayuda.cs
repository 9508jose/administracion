using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CBR_ADMIN.Sistema
{
    public partial class Ayuda : Form
    {
        public string Formulario;
        private static Ayuda _instance;
        public static Ayuda Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Ayuda();
                return _instance;
            }
        }
        public Ayuda()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Ayuda_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(835, 120);
            this.Visible = true;
          
            label1.Text = Formulario;

            if(Formulario == "Alta de Usuarios")
            {
                label2.Text = Properties.Resources.FormularioAltaUsuarios;
            }
            else if (Formulario == "Baja de Usuarios")
            {
                label2.Text = Properties.Resources.FormularioBajaUsuarios;
            }
            else if (Formulario == "Modificar Usuarios")
            {
                label2.Text = Properties.Resources.FormularioModificarUsuarios;
            }
            else if (Formulario == "Cambio de Contraseña")
            {
                label2.Text = Properties.Resources.FormularioContra;
            }
            else
            {
                label2.Text = "";
            }


        }

        private bool dragging = false;
        private Point startPoint = new Point(0, 0);
        private void tableLayoutPanel1_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void tableLayoutPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            startPoint = new Point(e.X, e.Y);
        }

        private void tableLayoutPanel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.startPoint.X, p.Y - this.startPoint.Y);
            }

        }

        private void label29_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void label29_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            startPoint = new Point(e.X, e.Y);
        }

        private void label29_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.startPoint.X, p.Y - this.startPoint.Y);
            }
        }
    }
}
