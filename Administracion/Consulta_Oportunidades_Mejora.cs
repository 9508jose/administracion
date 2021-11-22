using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using CBR_ADMIN.Sistema;

namespace CBR_ADMIN.Administracion
{
    public partial class Consulta_Oportunidades_Mejora : UserControl
    {
        private static Consulta_Oportunidades_Mejora _instance;
        public static Consulta_Oportunidades_Mejora Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Consulta_Oportunidades_Mejora();
                return _instance;
            }


        }
        public string Ventana1, Nombre, Departamento, NoConfor, Reporta, Responsable, Fecha, Email1;
        String dato;
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dato = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValue.ToString();

            MessageBox.Show("" + dato);
        }

        public Consulta_Oportunidades_Mejora()
        {
            InitializeComponent();
        }
       
        private void Consulta_Oportunidades_Mejora_Load(object sender, EventArgs e)
        {

           

           
            this.op_MejoraTableAdapter.Filtro_Departamento(cBR_No_Oportunidad.Op_Mejora,Departamento);
       
        }
    }
}
