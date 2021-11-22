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
    public partial class Consulta_Proyectos_General : Form
    {
       public  String dato, dato2;
        public string  proyecto { get; set; }
        public Transmisor Nombre { get; set; }
        private static Consulta_Proyectos_General _instance;
        public static Consulta_Proyectos_General Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Consulta_Proyectos_General();
                return _instance;
            }
        }
        public Consulta_Proyectos_General()
        {
            InitializeComponent();
        }

        private void Consulta_Proyectos_General_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'folio_general.Folio_Proyectos_General' Puede moverla o quitarla según sea necesario.
            this.folio_Proyectos_GeneralTableAdapter.Fill(this.folio_general.Folio_Proyectos_General);

        }

    

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string clave = "%" + Clave.Text + "%";

            folio_Proyectos_GeneralTableAdapter.FillBy(folio_general.Folio_Proyectos_General, clave);
        }

        private void advancedDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dato = advancedDataGridView1.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
            dato2 = advancedDataGridView1.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();

            MessageBox.Show("" + dato+"-"+dato2);
            DatosGenerales.name = dato2;
            this.Close();
          


        }
    }
}
