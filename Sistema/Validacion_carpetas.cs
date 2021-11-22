using CBR_ADMIN.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CBR_ADMIN.Sistema
{
    public partial class Validacion_carpetas : Form
    {
        public Validacion_carpetas()
        {
            InitializeComponent();
        }
        
        private void Guardar_Click(object sender, EventArgs e)
        {

            acceder(Nombreu.Text, contraseñau.Text);
           

           
     

        }
        public static string ObtenerCadena()
        {
            return Settings.Default.CBR_IngenieriaConnectionString;/*Este codigo obtiene los datos de la cadena de conexion declarada en los settings de la aplicacion*/


        }
        public void acceder(string usuario, string contrasena)
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
                                                "[Contraseña] " +

                                                "from [Acceso_Carpetas] " +
                                                "where [Usuario]=@usuario " +
                                                "and [Contraseña]=@contraseña "
                                                , conexion);
                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.Parameters.AddWithValue("contraseña", contrasena);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.SelectCommand.CommandTimeout = 36000;
                DataTable dt = new DataTable();
                sda.Fill(dt);



                conexion.Dispose();


                if (dt.Rows.Count > 0)
                {

                    //MessageBox.Show("Si tiene acceso a esta planta");
                    // this.Close();
                    string Nombre = dt.Rows[0][0].ToString();
                    string Apellido = dt.Rows[0][1].ToString();
                    string Usuario = dt.Rows[0][3].ToString();
                    string Permisos = dt.Rows[0][2].ToString();
                    if (Permisos == "Total" || Permisos == "especial")
                    {
                        MessageBox.Show("Acceso concendio");

                        this.Hide();

                        Crea_proyecto crear = new Crea_proyecto();
                        crear.Nombre =Nombreu.Text;
                        crear.contraseña = contraseñau.Text;
                        crear.BringToFront();
                        crear.WindowState = FormWindowState.Normal;
                        crear.Show();

                    }
                    else
                    {
                        MessageBox.Show("Sin  acceso");
                    }



                }
                ////////////////////////////////////SI EL USUARIO, CONTRASENA O PLANTA ESTA MAL//////////////////////////////////////////////////////////////////////////
                else
                {


                    MessageBox.Show("Datos incorrectos de acceso");
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

        private void Nombreu_Click(object sender, EventArgs e)
        {
            Nombreu.Text = "";
        }

        private void contraseñau_Click(object sender, EventArgs e)
        {
            contraseñau.Text = "";
        }
    }
}
