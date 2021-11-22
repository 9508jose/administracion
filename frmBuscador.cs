using CBR_ADMIN.Sistema;
using Controlador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CBR_ADMIN
{
    public partial class frmBuscador : Form
    {
        private static frmBuscador _instance;
        public static frmBuscador Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new frmBuscador();
                return _instance;
            }
        }
        public frmBuscador()
        {
            InitializeComponent();
        }


        public String dato;
        public string nodo { get; set; }
        public BuscadorNodos NombreNodo { get; set; }

        private void frmBuscador_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(835, 120);
            this.Visible = true;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            
            string rutaBuscador = txtBuscador.Text;
            General21 f1 = new General21();

            f1.BuscarGeneral(rutaBuscador);
            txtBuscador.Text = "";

           
         this.Hide();
           


            
        }


        private void dgdBusqueda_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            String nombre;
            String ruteo;



            DataGridViewRow row = dgdBusqueda.Rows[e.RowIndex];
            nombre = row.Cells[0].Value.ToString();
            ruteo = row.Cells[1].Value.ToString();

            if (ruteo == "--")
            {
                ruteo = nombre;
            }

        }

        private void dgdBusqueda_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dato = dgdBusqueda.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
            GeneralDatos.nodo = dato;
            this.Close();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
