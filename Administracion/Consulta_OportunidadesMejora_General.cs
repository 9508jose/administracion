using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CBR_ADMIN.Sistema;
using System.Threading;

namespace CBR_ADMIN.Administracion
{
    public partial class Consulta_OportunidadesMejora_General : UserControl
    {
        private static Consulta_OportunidadesMejora_General _instance;
        public static Consulta_OportunidadesMejora_General Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Consulta_OportunidadesMejora_General();
                return _instance;
            }


        }
        public Consulta_OportunidadesMejora_General()
        {
            InitializeComponent();
        }
        string dato;
        private void Consulta_OportunidadesMejora_General_Load(object sender, EventArgs e)
        {

          
            this.op_MejoraTableAdapter.Fill(cBR_No_Oportunidad.Op_Mejora);
          
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dato = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValue.ToString();

            MessageBox.Show("" + dato);
        }
    }
}
