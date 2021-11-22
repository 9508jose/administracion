using CBR_ADMIN.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CBR_ADMIN.Administracion
{
    public partial class Consulta : Form
    {
        public Consulta()
        {
            InitializeComponent();
        }
        public static string ObtenerCadena2()
        {
            return Settings.Default.CBR_IngenieriaConnectionString;/*Este codigo obtiene los datos de la cadena de conexion declarada en los settings de la aplicacion*/
        }

        SqlConnection conexion2 = new SqlConnection(ObtenerCadena2());

        private void Consulta_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'table_Pdf.GuardaPDF' Puede moverla o quitarla según sea necesario.
            this.guardaPDFTableAdapter.Fill(this.table_Pdf.GuardaPDF);

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {





                string qry = "select Titulo, Archivo from GuardaPDF where Titulo = @prId";

                // Inicializa el objeto SqlCommand
                SqlCommand SqlCom = new SqlCommand(qry, conexion2);

                // Se agrega la información de búsqueda con parámetros
                SqlCom.Parameters.Add(new SqlParameter("@prId", comboBox1.Text));

                // Abre la conexión y ejecutar el query
                conexion2.Open();
                SqlDataReader rdr2 = SqlCom.ExecuteReader();

                Image newImage = null;

                if (rdr2.Read())
                {
                    // Obtiene los resultados de la búsqueda

                    byte[] imgData = (byte[])rdr2.GetValue(1);

                    //// Trata la información de la imagen para poder trasladarla al picturebox
                    //using (MemoryStream ms = new MemoryStream(imgData, 0, imgData.Length))
                    //{
                    //    ms.Write(imgData, 0, imgData.Length);
                    //    newImage = Image.FromStream(ms, true);
                    //}

                    //pictureBox2.Image = newImage;
                    //newImage = null;

                    string userName = Environment.UserName;
                    File.Delete(@"C:\Users\" + userName + "\\AppData\\Local\\Temp\\temppdf.pdf");




                    File.WriteAllBytes(@"C:\Users\" + userName + "\\AppData\\Local\\Temp\\temppdf.pdf", imgData);
                    System.Diagnostics.Process.Start(@"C:\Users\" + userName + "\\AppData\\Local\\Temp\\temppdf.pdf");


                }
                else
                {
                    MessageBox.Show("No existe registro con ese Id", "Búsqueda de Documento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Cerrar la conexión si esta se encuentra abierta
                if (conexion2.State == ConnectionState.Open)
                    conexion2.Close();
            }
            this.Close();
        }
    }
}
