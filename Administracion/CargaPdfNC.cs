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

namespace CBR_ADMIN.Administracion
{
    public partial class CargaPdfNC : Form
    {
        public String ID;
        public CargaPdfNC()
        {
            InitializeComponent();
        }

        public static string ObtenerCadena()
        {
            return Settings.Default.CBR_IngenieriaConnectionString;/*Este codigo obtiene los datos de la cadena de conexion declarada en los settings de la aplicacion*/
        }

        SqlConnection conexion = new SqlConnection(ObtenerCadena());




        private void btnBuscarArchivo_Click_1(object sender, EventArgs e)
        {
            string url = "";

            dlgImagen.Filter = "Archivo Pdf (*.pdf*)|*.pdf*";
            DialogResult r = dlgImagen.ShowDialog();
            if (r == DialogResult.OK)
            {
                txtRuta.Text = dlgImagen.FileName;
                // pictureBox1.Load(txtRuta.Text);
                url = dlgImagen.FileName;
            }

            webBrowser1.Url = new System.Uri(url);
                }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            if (txtTitulo.Text == "" || txtTitulo.Text == null) { MessageBox.Show("Ingrese Nombre de archivo", "Guarga Pdf", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            else
            {
                byte[] data = System.IO.File.ReadAllBytes(txtRuta.Text);
                string qry = "insert into GuardaPDF (Id,Titulo, Archivo) values (@ID,@prTitulo, @Archivo)";

                try
                {
                    // Inicializa el objeto SqlCommand
                    SqlCommand SqlCom = new SqlCommand(qry, conexion);

                    // Se agrega la información como parámetros

                    SqlCom.Parameters.Add(new SqlParameter("@ID", ID));
                    SqlCom.Parameters.Add(new SqlParameter("@prTitulo", txtTitulo.Text));
                    SqlCom.Parameters.Add(new SqlParameter("@Archivo", data));

                    // Abrir la conexión y ejecutar el query
                    conexion.Open();
                    SqlCom.ExecuteNonQuery();

                    // De no haber error, mostrar mensaje de confirmación
                    MessageBox.Show("Archivo guardado correctamente", "Guarga Pdf", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    // Cerrar la conexión si esta se encuentra abierta
                    if (conexion.State == ConnectionState.Open)
                        conexion.Close();
                }
                this.Close();
            }
        }
    }
}
