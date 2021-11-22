using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CBR_ADMIN.Properties;
using System.Data.SqlClient;
using System.Threading;

namespace CBR_ADMIN.Sistema
{
    public partial class Alta_usuarios : UserControl
    {
        private static Alta_usuarios _instance;
        public static Alta_usuarios Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Alta_usuarios();
                return _instance;
            }
        }

        public Alta_usuarios()
        {
            InitializeComponent();
        }
        public static string ObtenerCadena()
        {
            return Settings.Default.CBR_IngenieriaConnectionString;/*Este codigo obtiene los datos de la cadena de conexion declarada en los settings de la aplicacion*/
        }
        SqlConnection conexion = new SqlConnection(ObtenerCadena());

        private void Alta_usuarios_Load(object sender, EventArgs e)
        {
            
                this.login_DepartamentosTableAdapter.Fill(cBR_Login_Dep.Login_Departamentos);
            this.departamentosTableAdapter.Fill(cBR_Departamento.Departamentos);
            
        }

        private void Guardar_Click(object sender, EventArgs e)
        {
            if (TB_Nombre.Text.Trim() == "" || TB_Apellido.Text.Trim() == "" || TB_Privilegios.Text.Trim() == "" || TB_Usuario.Text.Trim() == "" || TB_Email.Text.Trim() == "" || TB_Contraseña.Text.Trim() == "" || TB_Usuario.Text.Trim() == "")
            {
                MessageBox.Show("Faltan campos por llenar");
            }

            else {
         

                

                Logear(TB_Usuario.Text);
            
            }

        }
  
        public void Logear(string usuario)
        {
            try
            {
                ////////////////////////////////////SE ABRE LA CONEXION/////////////////////////////////////////////////////////////////////////////////
                SqlConnection conexion = new SqlConnection(ObtenerCadena());
                conexion.Open();
                ////////////////////////////////////SE EJECUTA EL COMANDO HACIA LA VISTA Y SE HACE LA VALIDACION//////////////////////////////////////
                SqlCommand cmd = new SqlCommand(
                                                "select " +
                                                "[Nombre], " +
                                                "[Apellido], " +
                                                "[Privilegios], " +
                                                "[Usuario], " +
                                                "[Contraseña], " +
                                                 "[Puesto], " +
                                                 "[Departamento], " +
                                                  "[Email] " +
                                                "from [Login_Departamentos] " +
                                                "where [Usuario]=@usuario " 
                                               
                                                , conexion);
                cmd.Parameters.AddWithValue("usuario", usuario);
       


                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.SelectCommand.CommandTimeout = 36000;
                DataTable dt = new DataTable();
                sda.Fill(dt);

                conexion.Dispose();

                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("El usuario: " + TB_Usuario.Text.Trim() + " ya existe");

                }
                ////////////////////////////////////SI EL USUARIO, CONTRASENA O PLANTA ESTA MAL//////////////////////////////////////////////////////////////////////////
                else
                {
                    int Prvi = Int32.Parse(TB_Privilegios.Text);
                    this.login_DepartamentosTableAdapter.Agrega(TB_Nombre.Text, TB_Apellido.Text, Prvi, TB_Usuario.Text, TB_Contraseña.Text, TB_Puesto.Text, CB_Departamento.Text, TB_Email.Text);
                    MessageBox.Show("Usuario agregado correctamente");
                    this.login_DepartamentosTableAdapter.Fill(cBR_Login_Dep.Login_Departamentos);
                 
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {

            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            TB_Nombre.Text = "";
            TB_Apellido.Text = "";
            TB_Privilegios.Text = "";
            TB_Usuario.Text = "";
            TB_Contraseña.Text = "";
            TB_Puesto.Text = "";
            CB_Departamento.SelectedIndex = 0;
            TB_Email.Text = "";
        }
    }
}
