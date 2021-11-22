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

namespace CBR_ADMIN.Sistema
{
    public partial class Baja_usuarios : UserControl
    {
        private static Baja_usuarios _instance;
        public static Baja_usuarios Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Baja_usuarios();
                return _instance;
            }
        }

        public Baja_usuarios()
        {
            InitializeComponent();
        }
        String ID;
        private void Baja_usuarios_Load(object sender, EventArgs e)
        {
            this.login_DepartamentosTableAdapter.Fill(cBR_Login_Dep.Login_Departamentos);
        }


        private void DG_genera_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    ID = Convert.ToString(DG_Baja.Rows[e.RowIndex].Cells[0].FormattedValue.ToString());
                    ID = DG_Baja.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                    Key_Dep.Text = ID.ToString();

                }
                else
                {
                    ID = "0";
                    Key_Dep.Text = ID.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }

        private void DG_genera_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex > 0)
                {
                    ID = Convert.ToString(DG_Baja.Rows[e.RowIndex].Cells[0].FormattedValue.ToString());
                    ID = DG_Baja.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                    Key_Dep.Text = ID.ToString();

                }
                else
                {
                    ID = "0";
                    Key_Dep.Text = ID.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }
        private void MostrarCuadroInicio()
        {
            Loading Cargando = new Loading();
            Cargando.ShowDialog();

        }
        private void Generar_Click(object sender, EventArgs e)
        {
            ThreadStart proceso = new ThreadStart(MostrarCuadroInicio);
            Thread hilo = new Thread(proceso);

           
            DialogResult Resultado;
            Resultado = MessageBox.Show("Está seguro que desea eliminar el registro seleccionado ", "Confirmación", MessageBoxButtons.YesNo);
            if (Resultado == DialogResult.Yes)
            {
                hilo.Start();
                int Prvi = Int32.Parse(Key_Dep.Text);
                this.login_DepartamentosTableAdapter.Elimina(Prvi);
                hilo.Abort();

            }
            else if (Resultado == DialogResult.No)
            {
                int Prvi = Int32.Parse(Key_Dep.Text);
                hilo.Abort();

                MessageBox.Show("Operacion Cancelada");
            }

        }


        
    }
}
