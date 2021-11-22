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
    public partial class Consulta_No_Conf : UserControl
    {

        private static Consulta_No_Conf _instance;
        public static Consulta_No_Conf Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Consulta_No_Conf();
                return _instance;
            }


        }
        public Consulta_No_Conf()
        {
            InitializeComponent();
        }
        public string Departamento;
        String dato;
        private void Consulta_No_Conf_Load(object sender, EventArgs e)
        {
            
            this.no_ConformidadesTableAdapter.Cons(this.cBR_No_Conf.No_Conformidades, Departamento);
            
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridView1[0, e.RowIndex].Style.BackColor = Color.Gray;
            dataGridView1[1, e.RowIndex].Style.BackColor = Color.Gray;
            dataGridView1[2, e.RowIndex].Style.BackColor = Color.Gray;
            dataGridView1[3, e.RowIndex].Style.BackColor = Color.Gray;
            dataGridView1[4, e.RowIndex].Style.BackColor = Color.Gray;
            dataGridView1[5, e.RowIndex].Style.BackColor = Color.Gray;
            dataGridView1[6, e.RowIndex].Style.BackColor = Color.SteelBlue;
            dataGridView1[7, e.RowIndex].Style.BackColor = Color.SteelBlue;
            dataGridView1[8, e.RowIndex].Style.BackColor = Color.SteelBlue;
            dataGridView1[9, e.RowIndex].Style.BackColor = Color.SteelBlue;
            dataGridView1[10, e.RowIndex].Style.BackColor = Color.LimeGreen;
            dataGridView1[11, e.RowIndex].Style.BackColor = Color.LimeGreen;
            dataGridView1[12, e.RowIndex].Style.BackColor = Color.LimeGreen;
            dataGridView1[13, e.RowIndex].Style.BackColor = Color.LimeGreen;
            dataGridView1[14, e.RowIndex].Style.BackColor = Color.LimeGreen;
            dataGridView1[15, e.RowIndex].Style.BackColor = Color.LimeGreen;
            dataGridView1[16, e.RowIndex].Style.BackColor = Color.Goldenrod;
            dataGridView1[17, e.RowIndex].Style.BackColor = Color.Goldenrod;
            dataGridView1[18, e.RowIndex].Style.BackColor = Color.Goldenrod;
            dataGridView1[19, e.RowIndex].Style.BackColor = Color.Goldenrod;
            dataGridView1[20, e.RowIndex].Style.BackColor = Color.Goldenrod;
            dataGridView1[21, e.RowIndex].Style.BackColor = Color.Gold;
            dataGridView1[22, e.RowIndex].Style.BackColor = Color.Gold;
            dataGridView1[23, e.RowIndex].Style.BackColor = Color.Gold;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dato = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValue.ToString();

            MessageBox.Show("" + dato);
        }
    }
}
