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
    public partial class Config_usuarios : UserControl
    {
        private static Config_usuarios _instance;
        public static Config_usuarios Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Config_usuarios();
                return _instance;
            }
        }

        public Config_usuarios()
        {
            InitializeComponent();
        }
        int UsuarioKey;
        string Nombre, Apellido, Privilegios, Usuario, Contraseña, Puesto, Departamento, Email;
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
            Resultado = MessageBox.Show("Está seguro que desea actualizar el registro seleccionado ", "Confirmación", MessageBoxButtons.YesNo);
            if (Resultado == DialogResult.Yes)
            {
                hilo.Start();

                int Privi = Int32.Parse(Privilegios);
                this.login_DepartamentosTableAdapter.Actualizacion(Nombre, Apellido, Privi, Usuario, Contraseña, Puesto, Departamento, Email, UsuarioKey); hilo.Abort();
            }
            else if (Resultado == DialogResult.No)
            {
                hilo.Abort();
                MessageBox.Show("Operacion Cancelada");
            }
            this.login_DepartamentosTableAdapter.Fill(cBR_Login_Dep.Login_Departamentos);
          
        }

        private void DG_Catalogo_Usuario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex > 0)
                {
                    UsuarioKey = Convert.ToInt32(DG_Catalogo_Usuario.Rows[e.RowIndex].Cells[0].FormattedValue.ToString());
                    Nombre = DG_Catalogo_Usuario.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                    Apellido = DG_Catalogo_Usuario.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
                    Privilegios = DG_Catalogo_Usuario.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
                    Usuario = DG_Catalogo_Usuario.Rows[e.RowIndex].Cells[4].FormattedValue.ToString();
                    Contraseña = DG_Catalogo_Usuario.Rows[e.RowIndex].Cells[5].FormattedValue.ToString();
                    Puesto = DG_Catalogo_Usuario.Rows[e.RowIndex].Cells[6].FormattedValue.ToString();
                    Departamento = DG_Catalogo_Usuario.Rows[e.RowIndex].Cells[7].FormattedValue.ToString();
                    Email = DG_Catalogo_Usuario.Rows[e.RowIndex].Cells[8].FormattedValue.ToString();
                    Key.Text = UsuarioKey.ToString();
                }
                else
                {

                    UsuarioKey = 0;
                    Key.Text = UsuarioKey.ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }

        private void Config_usuarios_Load(object sender, EventArgs e)
        {
            {
                this.login_DepartamentosTableAdapter.Fill(cBR_Login_Dep.Login_Departamentos);
            }
        }







        private void DG_V_Usuarios_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex > 0)
                {
                    UsuarioKey = Convert.ToInt32(DG_Catalogo_Usuario.Rows[e.RowIndex].Cells[0].FormattedValue.ToString());
                    Nombre = DG_Catalogo_Usuario.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                    Apellido = DG_Catalogo_Usuario.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
                    Privilegios = DG_Catalogo_Usuario.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
                    Usuario = DG_Catalogo_Usuario.Rows[e.RowIndex].Cells[4].FormattedValue.ToString();
                    Contraseña = DG_Catalogo_Usuario.Rows[e.RowIndex].Cells[5].FormattedValue.ToString();
                    Puesto = DG_Catalogo_Usuario.Rows[e.RowIndex].Cells[6].FormattedValue.ToString();
                    Departamento = DG_Catalogo_Usuario.Rows[e.RowIndex].Cells[7].FormattedValue.ToString();
                    Email = DG_Catalogo_Usuario.Rows[e.RowIndex].Cells[8].FormattedValue.ToString();
                    Key.Text = UsuarioKey.ToString();
                }
                else
                {

                    UsuarioKey = 0;
                    Key.Text = UsuarioKey.ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }




        }
    }
}
