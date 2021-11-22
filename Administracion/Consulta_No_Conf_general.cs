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
using System.Data.SqlClient;
using CBR_ADMIN.Properties;
using System.IO;

namespace CBR_ADMIN.Administracion
{
    public partial class Consulta_No_Conf_general : UserControl
    {
        private static Consulta_No_Conf_general _instance;
        public static Consulta_No_Conf_general Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Consulta_No_Conf_general();
                return _instance;
            }


        }
        public string ID;

        public static string ObtenerCadena()
        {
            return Settings.Default.CBR_IngenieriaConnectionString;/*Este codigo obtiene los datos de la cadena de conexion declarada en los settings de la aplicacion*/
        }
        public static string ObtenerCadena2()
        {
            return Settings.Default.CBR_IngenieriaConnectionString;/*Este codigo obtiene los datos de la cadena de conexion declarada en los settings de la aplicacion*/
        }


        SqlConnection conexion = new SqlConnection(ObtenerCadena());
        SqlConnection conexion2 = new SqlConnection(ObtenerCadena2());


        public Consulta_No_Conf_general()
        {
            InitializeComponent();
        }
        String dato;
        private void Consulta_No_Conf_general_Load(object sender, EventArgs e)
        {

            ThreadStart proceso = new ThreadStart(MostrarCuadroInicio);
            Thread hilo = new Thread(proceso);

         
            this.no_ConformidadesTableAdapter.consulta2020(cBR_No_Conf.No_Conformidades);
          
        }
        private void MostrarCuadroInicio()
        {
            Loading Cargando = new Loading();
            Cargando.ShowDialog();

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

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            int UsuarioKey = 0;
            if (e.RowIndex >= 0 && e.ColumnIndex > 0)
            {
                UsuarioKey = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].FormattedValue.ToString());

                ID = UsuarioKey.ToString();
            }

           

          
            ////Consulta/////////
            if (e.ColumnIndex == 25)
            {
                CargaPdfNC genera = new CargaPdfNC();
                genera.ID = ID;
             


                genera.Show();
            }

            ////////////Agrega/
            
            if (e.ColumnIndex == 26)
            {

                String valor="";
                int valor1=0;
                SqlConnection conexion = new SqlConnection(ObtenerCadena());

                conexion.Open();
                ////////////////////////////////////////////////////////////////////////////////////






                ////////////////////////////////////SE EJECUTA EL COMANDO HACIA LA VISTA Y SE HACE LA VALIDACION//////////////////////////////////////
                SqlCommand cmd = new SqlCommand(
                                                "select " +
                                                "Count('ID') " +
                                                "from [GuardaPDF]  where Id=@id"

                                                , conexion);


                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("id", ID);
                sda.SelectCommand.CommandTimeout = 36000;
                DataTable dt = new DataTable();
                sda.Fill(dt);



                conexion.Dispose();
                if (dt.Rows.Count > 0)
                {
                    valor = dt.Rows[0][0].ToString();
                    valor1 = Int32.Parse(valor);
                }
                if (valor1 == 0) {

                    MessageBox.Show("No existe registros", "Búsqueda de Documento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (valor1 == 1)
                {


                    consulta();
               

                }
                else if (valor1 > 1 )
                {
                    Consulta genera = new Consulta();
                    genera.Show();
                }





            }
        }

        public void consulta() {
            try
            {
            

               


                string qry = "select Titulo, Archivo from GuardaPDF where Id = @prId";

                // Inicializa el objeto SqlCommand
                SqlCommand SqlCom = new SqlCommand(qry, conexion2);

                // Se agrega la información de búsqueda con parámetros
                SqlCom.Parameters.Add(new SqlParameter("@prId", ID));

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


        }
    }
}
