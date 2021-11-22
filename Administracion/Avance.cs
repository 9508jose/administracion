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
using System.Windows.Forms.DataVisualization.Charting;

namespace CBR_ADMIN.Administracion
{
    public partial class Avance : Form
    {
        public Avance()
        {
            InitializeComponent();
        }
        public static string ObtenerCadena()
        {
            return Settings.Default.CBR_IngenieriaConnectionString;/*Este codigo obtiene los datos de la cadena de conexion declarada en los settings de la aplicacion*/

        }
        string
       AtencionClientes
      , AtencionClientes_Atencion
      , AtencionClientes_EntregaDocumentos
      , AtencionClientes_Postventa
      , AtencionClientes_Encuesta
      , Finanzas
      , Finanzas_CierreProyecto
      , Compraas
      , DosierdeCalidad
      , Ventas
      , Ventas_AltayDocumentosClientes
      , Ventas_PedidoInterno
      , Ventas_ExpedienteComercial
      , Proyectos
      , Proyectos_ExpedienteTecnic
      , Proyectos_Planos
      , EquipamientoeInstalaciones
      , EquipamientoeInstalaciones_FabricacionyEquipamiento
      , EquipamientoeInstalaciones_Instalacionyarranque
      , EquipamientoeInstalaciones_OperacionyMantenimiento
      , General;
        string tipo = "";
        private void label7_Click(object sender, EventArgs e)
        {
            String año = "", tipo = "", nombre = "";
            Archivos.Text = "";
            SqlConnection conexion = new SqlConnection(ObtenerCadena());
            conexion.Open();
            SqlCommand cmd = new SqlCommand(
                                   "select" +
                                   "[Ano], " +
                                   "[tipo2], " +
                                   "[Nombre], " +
                                   "[Nombre2] " +

                                   "from [Folio_proyectos>2019]  where Nombre2=@Nombre2"

                                   , conexion);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("Nombre2", Proyecto.Text);
            sda.SelectCommand.CommandTimeout = 36000;
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                año = dt.Rows[0][0].ToString();
                tipo = dt.Rows[0][1].ToString();
                nombre = dt.Rows[0][2].ToString();





                conexion.Dispose();

            }
            else { }

            string[] ubicacion = Directory.GetFiles("G:/SGC-PROYECTOS-CBR/SGC/" + año + "/" + tipo + "/" + nombre + "/" + label7.Text);

            for (int i = 0; i < ubicacion.Length; i++)
            {
                // comboBox1.Items.Add(Path.GetFileName(ubicacion[i]));
                Archivos.Text = Archivos.Text + "\n" + Path.GetFileName(ubicacion[i]);
                String Archivo = Path.GetFileName(ubicacion[i]);



            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            String año = "", tipo = "", nombre = "";
            Archivos.Text = "";
            SqlConnection conexion = new SqlConnection(ObtenerCadena());
            conexion.Open();
            SqlCommand cmd = new SqlCommand(
                                   "select" +
                                   "[Ano], " +
                                   "[tipo2], " +
                                   "[Nombre], " +
                                   "[Nombre2] " +

                                   "from [Folio_proyectos>2019]  where Nombre2=@Nombre2"

                                   , conexion);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("Nombre2", Proyecto.Text);
            sda.SelectCommand.CommandTimeout = 36000;
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                año = dt.Rows[0][0].ToString();
                tipo = dt.Rows[0][1].ToString();
                nombre = dt.Rows[0][2].ToString();





                conexion.Dispose();

            }
            else { }

            string[] ubicacion = Directory.GetFiles("G:/SGC-PROYECTOS-CBR/SGC/" + año + "/" + tipo + "/" + nombre + "/" + label8.Text);

            for (int i = 0; i < ubicacion.Length; i++)
            {
                // comboBox1.Items.Add(Path.GetFileName(ubicacion[i]));
                Archivos.Text = Archivos.Text + "\n" + Path.GetFileName(ubicacion[i]);
                String Archivo = Path.GetFileName(ubicacion[i]);



            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool dragging = false;
        private Point startPoint = new Point(0, 0);
        private void label29_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void label29_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            startPoint = new Point(e.X, e.Y);
        }

        private void label29_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.startPoint.X, p.Y - this.startPoint.Y);
            }
        }

        private void label16_Click(object sender, EventArgs e)
        {
            String año = "", tipo = "", nombre = "";
            Archivos.Text = "";
            SqlConnection conexion = new SqlConnection(ObtenerCadena());
            conexion.Open();
            SqlCommand cmd = new SqlCommand(
                                   "select" +
                                   "[Ano], " +
                                   "[tipo2], " +
                                   "[Nombre], " +
                                   "[Nombre2] " +

                                   "from [Folio_proyectos>2019]  where Nombre2=@Nombre2"

                                   , conexion);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("Nombre2", Proyecto.Text);
            sda.SelectCommand.CommandTimeout = 36000;
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                año = dt.Rows[0][0].ToString();
                tipo = dt.Rows[0][1].ToString();
                nombre = dt.Rows[0][2].ToString();





                conexion.Dispose();

            }
            else { }

            string[] ubicacion = Directory.GetFiles("G:/SGC-PROYECTOS-CBR/SGC/" + año + "/" + tipo + "/" + nombre + "/" + label6.Text);

            for (int i = 0; i < ubicacion.Length; i++)
            {
                // comboBox1.Items.Add(Path.GetFileName(ubicacion[i]));
                Archivos.Text = Archivos.Text + "\n" + Path.GetFileName(ubicacion[i]);
                String Archivo = Path.GetFileName(ubicacion[i]);



            }
        }

        private void label9_Click(object sender, EventArgs e)
        {
            String año = "", tipo = "", nombre = "";
            Archivos.Text = "";
            SqlConnection conexion = new SqlConnection(ObtenerCadena());
            conexion.Open();
            SqlCommand cmd = new SqlCommand(
                                   "select" +
                                   "[Ano], " +
                                   "[tipo2], " +
                                   "[Nombre], " +
                                   "[Nombre2] " +

                                   "from [Folio_proyectos>2019]  where Nombre2=@Nombre2"

                                   , conexion);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("Nombre2", Proyecto.Text);
            sda.SelectCommand.CommandTimeout = 36000;
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                año = dt.Rows[0][0].ToString();
                tipo = dt.Rows[0][1].ToString();
                nombre = dt.Rows[0][2].ToString();





                conexion.Dispose();

            }
            else { }

            string[] ubicacion = Directory.GetFiles("G:/SGC-PROYECTOS-CBR/SGC/" + año + "/" + tipo + "/" + nombre + "/" + label9.Text);

            for (int i = 0; i < ubicacion.Length; i++)
            {
                // comboBox1.Items.Add(Path.GetFileName(ubicacion[i]));
                Archivos.Text = Archivos.Text + "\n" + Path.GetFileName(ubicacion[i]);
                String Archivo = Path.GetFileName(ubicacion[i]);



            }
        }

        private void label10_Click(object sender, EventArgs e)
        {
            String año = "", tipo = "", nombre = "";
            Archivos.Text = "";
            SqlConnection conexion = new SqlConnection(ObtenerCadena());
            conexion.Open();
            SqlCommand cmd = new SqlCommand(
                                   "select" +
                                   "[Ano], " +
                                   "[tipo2], " +
                                   "[Nombre], " +
                                   "[Nombre2] " +

                                   "from [Folio_proyectos>2019]  where Nombre2=@Nombre2"

                                   , conexion);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("Nombre2", Proyecto.Text);
            sda.SelectCommand.CommandTimeout = 36000;
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                año = dt.Rows[0][0].ToString();
                tipo = dt.Rows[0][1].ToString();
                nombre = dt.Rows[0][2].ToString();





                conexion.Dispose();

            }
            else { }

            string[] ubicacion = Directory.GetFiles("G:/SGC-PROYECTOS-CBR/SGC/" + año + "/" + tipo + "/" + nombre + "/" + label10.Text);

            for (int i = 0; i < ubicacion.Length; i++)
            {
                // comboBox1.Items.Add(Path.GetFileName(ubicacion[i]));
                Archivos.Text = Archivos.Text + "\n" + Path.GetFileName(ubicacion[i]);
                String Archivo = Path.GetFileName(ubicacion[i]);



            }
        }

        private void label11_Click(object sender, EventArgs e)
        {
            String año = "", tipo = "", nombre = "";
            Archivos.Text = "";
            SqlConnection conexion = new SqlConnection(ObtenerCadena());
            conexion.Open();
            SqlCommand cmd = new SqlCommand(
                                   "select" +
                                   "[Ano], " +
                                   "[tipo2], " +
                                   "[Nombre], " +
                                   "[Nombre2] " +

                                   "from [Folio_proyectos>2019]  where Nombre2=@Nombre2"

                                   , conexion);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("Nombre2", Proyecto.Text);
            sda.SelectCommand.CommandTimeout = 36000;
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                año = dt.Rows[0][0].ToString();
                tipo = dt.Rows[0][1].ToString();
                nombre = dt.Rows[0][2].ToString();





                conexion.Dispose();

            }
            else { }

            string[] ubicacion = Directory.GetFiles("G:/SGC-PROYECTOS-CBR/SGC/" + año + "/" + tipo + "/" + nombre + "/" + label11.Text);

            for (int i = 0; i < ubicacion.Length; i++)
            {
                // comboBox1.Items.Add(Path.GetFileName(ubicacion[i]));
                Archivos.Text = Archivos.Text + "\n" + Path.GetFileName(ubicacion[i]);
                String Archivo = Path.GetFileName(ubicacion[i]);



            }
        }

        private void label12_Click(object sender, EventArgs e)
        {
            String año = "", tipo = "", nombre = "";
            Archivos.Text = "";
            SqlConnection conexion = new SqlConnection(ObtenerCadena());
            conexion.Open();
            SqlCommand cmd = new SqlCommand(
                                   "select" +
                                   "[Ano], " +
                                   "[tipo2], " +
                                   "[Nombre], " +
                                   "[Nombre2] " +

                                   "from [Folio_proyectos>2019]  where Nombre2=@Nombre2"

                                   , conexion);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("Nombre2", Proyecto.Text);
            sda.SelectCommand.CommandTimeout = 36000;
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                año = dt.Rows[0][0].ToString();
                tipo = dt.Rows[0][1].ToString();
                nombre = dt.Rows[0][2].ToString();





                conexion.Dispose();

            }
            else { }

            string[] ubicacion = Directory.GetFiles("G:/SGC-PROYECTOS-CBR/SGC/" + año + "/" + tipo + "/" + nombre + "/" + label2.Text);

            for (int i = 0; i < ubicacion.Length; i++)
            {
                // comboBox1.Items.Add(Path.GetFileName(ubicacion[i]));
                Archivos.Text = Archivos.Text + "\n" + Path.GetFileName(ubicacion[i]);
                String Archivo = Path.GetFileName(ubicacion[i]);



            }
        }

        private void label13_Click(object sender, EventArgs e)
        {
            String año = "", tipo = "", nombre = "";
            Archivos.Text = "";
            SqlConnection conexion = new SqlConnection(ObtenerCadena());
            conexion.Open();
            SqlCommand cmd = new SqlCommand(
                                   "select" +
                                   "[Ano], " +
                                   "[tipo2], " +
                                   "[Nombre], " +
                                   "[Nombre2] " +

                                   "from [Folio_proyectos>2019]  where Nombre2=@Nombre2"

                                   , conexion);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("Nombre2", Proyecto.Text);
            sda.SelectCommand.CommandTimeout = 36000;
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                año = dt.Rows[0][0].ToString();
                tipo = dt.Rows[0][1].ToString();
                nombre = dt.Rows[0][2].ToString();





                conexion.Dispose();

            }
            else { }

            string[] ubicacion = Directory.GetFiles("G:/SGC-PROYECTOS-CBR/SGC/" + año + "/" + tipo + "/" + nombre + "/" + label13.Text);

            for (int i = 0; i < ubicacion.Length; i++)
            {
                // comboBox1.Items.Add(Path.GetFileName(ubicacion[i]));
                Archivos.Text = Archivos.Text + "\n" + Path.GetFileName(ubicacion[i]);
                String Archivo = Path.GetFileName(ubicacion[i]);



            }
        }

        private void label14_Click(object sender, EventArgs e)
        {
            String año = "", tipo = "", nombre = "";
            Archivos.Text = "";
            SqlConnection conexion = new SqlConnection(ObtenerCadena());
            conexion.Open();
            SqlCommand cmd = new SqlCommand(
                                   "select" +
                                   "[Ano], " +
                                   "[tipo2], " +
                                   "[Nombre], " +
                                   "[Nombre2] " +

                                   "from [Folio_proyectos>2019]  where Nombre2=@Nombre2"

                                   , conexion);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("Nombre2", Proyecto.Text);
            sda.SelectCommand.CommandTimeout = 36000;
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                año = dt.Rows[0][0].ToString();
                tipo = dt.Rows[0][1].ToString();
                nombre = dt.Rows[0][2].ToString();





                conexion.Dispose();

            }
            else { }

            string[] ubicacion = Directory.GetFiles("G:/SGC-PROYECTOS-CBR/SGC/" + año + "/" + tipo + "/" + nombre + "/" + label4.Text);

            for (int i = 0; i < ubicacion.Length; i++)
            {
                // comboBox1.Items.Add(Path.GetFileName(ubicacion[i]));
                Archivos.Text = Archivos.Text + "\n" + Path.GetFileName(ubicacion[i]);
                String Archivo = Path.GetFileName(ubicacion[i]);



            }
        }


        private void label6_Click(object sender, EventArgs e)
        {
            String año = "", tipo = "", nombre = "";
            Archivos.Text = "";
            SqlConnection conexion = new SqlConnection(ObtenerCadena());
            conexion.Open();
            SqlCommand cmd = new SqlCommand(
                                   "select" +
                                   "[Ano], " +
                                   "[tipo2], " +
                                   "[Nombre], " +
                                   "[Nombre2] " +

                                   "from [Folio_proyectos>2019]  where Nombre2=@Nombre2"

                                   , conexion);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("Nombre2", Proyecto.Text);
            sda.SelectCommand.CommandTimeout = 36000;
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                año = dt.Rows[0][0].ToString();
                tipo = dt.Rows[0][1].ToString();
                nombre = dt.Rows[0][2].ToString();





                conexion.Dispose();

            }
            else { }

            string[] ubicacion = Directory.GetFiles("G:/SGC-PROYECTOS-CBR/SGC/" + año + "/" + tipo + "/" + nombre + "/" + label6.Text);

            for (int i = 0; i < ubicacion.Length; i++)
            {
                // comboBox1.Items.Add(Path.GetFileName(ubicacion[i]));
                Archivos.Text = Archivos.Text + "\n" + Path.GetFileName(ubicacion[i]);
                String Archivo = Path.GetFileName(ubicacion[i]);



            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            String año = "", tipo = "", nombre = "";
            Archivos.Text = "";
            SqlConnection conexion = new SqlConnection(ObtenerCadena());
            conexion.Open();
            SqlCommand cmd = new SqlCommand(
                                   "select" +
                                   "[Ano], " +
                                   "[tipo2], " +
                                   "[Nombre], " +
                                   "[Nombre2] " +

                                   "from [Folio_proyectos>2019]  where Nombre2=@Nombre2"

                                   , conexion);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("Nombre2", Proyecto.Text);
            sda.SelectCommand.CommandTimeout = 36000;
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                año = dt.Rows[0][0].ToString();
                tipo = dt.Rows[0][1].ToString();
                nombre = dt.Rows[0][2].ToString();





                conexion.Dispose();

            }
            else { }

            string[] ubicacion = Directory.GetFiles("G:/SGC-PROYECTOS-CBR/SGC/" + año + "/" + tipo + "/" + nombre + "/" + label5.Text);

            for (int i = 0; i < ubicacion.Length; i++)
            {
                // comboBox1.Items.Add(Path.GetFileName(ubicacion[i]));
                Archivos.Text = Archivos.Text + "\n" + Path.GetFileName(ubicacion[i]);
                String Archivo = Path.GetFileName(ubicacion[i]);



            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            String año = "", tipo = "", nombre = "";
            Archivos.Text = "";
            SqlConnection conexion = new SqlConnection(ObtenerCadena());
            conexion.Open();
            SqlCommand cmd = new SqlCommand(
                                   "select" +
                                   "[Ano], " +
                                   "[tipo2], " +
                                   "[Nombre], " +
                                   "[Nombre2] " +

                                   "from [Folio_proyectos>2019]  where Nombre2=@Nombre2"

                                   , conexion);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("Nombre2", Proyecto.Text);
            sda.SelectCommand.CommandTimeout = 36000;
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                año = dt.Rows[0][0].ToString();
                tipo = dt.Rows[0][1].ToString();
                nombre = dt.Rows[0][2].ToString();





                conexion.Dispose();

            }
            else { }

            string[] ubicacion = Directory.GetFiles("G:/SGC-PROYECTOS-CBR/SGC/" + año + "/" + tipo + "/" + nombre + "/" + label4.Text);

            for (int i = 0; i < ubicacion.Length; i++)
            {
                // comboBox1.Items.Add(Path.GetFileName(ubicacion[i]));
                Archivos.Text = Archivos.Text + "\n" + Path.GetFileName(ubicacion[i]);
                String Archivo = Path.GetFileName(ubicacion[i]);



            }
        }

        private void circularProgressBar13_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            String año = "", tipo = "", nombre = "";
            Archivos.Text = "";
            SqlConnection conexion = new SqlConnection(ObtenerCadena());
            conexion.Open();
            SqlCommand cmd = new SqlCommand(
                                   "select" +
                                   "[Ano], " +
                                   "[tipo2], " +
                                   "[Nombre], " +
                                   "[Nombre2] " +

                                   "from [Folio_proyectos>2019]  where Nombre2=@Nombre2"

                                   , conexion);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("Nombre2", Proyecto.Text);
            sda.SelectCommand.CommandTimeout = 36000;
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                año = dt.Rows[0][0].ToString();
                tipo = dt.Rows[0][1].ToString();
                nombre = dt.Rows[0][2].ToString();





                conexion.Dispose();

            }
            else { }

            string[] ubicacion = Directory.GetFiles("G:/SGC-PROYECTOS-CBR/SGC/" + año + "/" + tipo + "/" + nombre + "/" + label3.Text);

            for (int i = 0; i < ubicacion.Length; i++)
            {
                // comboBox1.Items.Add(Path.GetFileName(ubicacion[i]));
                Archivos.Text = Archivos.Text + "\n" + Path.GetFileName(ubicacion[i]);
                String Archivo = Path.GetFileName(ubicacion[i]);



            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            String año="", tipo="", nombre="";
            Archivos.Text = "";

            SqlConnection conexion = new SqlConnection(ObtenerCadena());
            conexion.Open();
            SqlCommand cmd = new SqlCommand(
                                   "select"+
                                   "[Ano], " +
                                   "[tipo2], " +
                                   "[Nombre], " +
                                   "[Nombre2] " +

                                   "from [Folio_proyectos>2019]  where Nombre2=@Nombre2"

                                   , conexion);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("Nombre2",Proyecto.Text);
            sda.SelectCommand.CommandTimeout = 36000;
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                año = dt.Rows[0][0].ToString();
                tipo = dt.Rows[0][1].ToString();
                nombre = dt.Rows[0][2].ToString();





                conexion.Dispose();

            }
            else { }

            string[] ubicacion = Directory.GetFiles("G:/SGC-PROYECTOS-CBR/SGC/" + año + "/" + tipo + "/" + nombre + "/" + label2.Text);

            for (int i = 0; i < ubicacion.Length; i++)
            {
                // comboBox1.Items.Add(Path.GetFileName(ubicacion[i]));
                Archivos.Text = Archivos.Text + "\n" + Path.GetFileName(ubicacion[i]);
                String Archivo = Path.GetFileName(ubicacion[i]);



            }
            }
            private void tableLayoutPanel3_Click(object sender, EventArgs e)
        {
       
        }

        private void circularProgressBar15_Click(object sender, EventArgs e)
        {
       
            
        }

        private void Avance_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'proyectos_Avance.Proyectos_Avance' Puede moverla o quitarla según sea necesario.
            this.proyectos_AvanceTableAdapter.Fill(this.proyectos_Avance.Proyectos_Avance);
            // TODO: esta línea de código carga datos en la tabla 'avance1.Proyectos_Avance' Puede moverla o quitarla según sea necesario.
         

         

            // TODO: esta línea de código carga datos en la tabla 'folio_Proyectos._Folio_Proyectos' Puede moverla o quitarla según sea necesario.

            // TODO: esta línea de código carga datos en la tabla 'folio_Proyectos._Folio_Proyectos' Puede moverla o quitarla según sea necesario.

            // TODO: esta línea de código carga datos en la tabla 'avance1.Proyectos_Avance' Puede moverla o quitarla según sea necesario.

            // TODO: esta línea de código carga datos en la tabla 'avance1.Proyectos_Avance' Puede moverla o quitarla según sea necesario.

            chart1.Visible = false;

            circularProgressBar1.Value = 0;
            circularProgressBar1.Minimum = 0;
            circularProgressBar1.Maximum = 100;

            circularProgressBar2.Value = 0;
            circularProgressBar2.Minimum = 0;
            circularProgressBar2.Maximum = 100;

            circularProgressBar3.Value = 0;
            circularProgressBar3.Minimum = 0;
            circularProgressBar3.Maximum = 100;

            circularProgressBar4.Value = 0;
            circularProgressBar4.Minimum = 0;
            circularProgressBar4.Maximum = 100;

            circularProgressBar5.Value = 0;
            circularProgressBar5.Minimum = 0;
            circularProgressBar5.Maximum = 100;

            circularProgressBar6.Value = 0;
            circularProgressBar6.Minimum = 0;
            circularProgressBar6.Maximum = 100;

            circularProgressBar7.Value = 0;
            circularProgressBar7.Minimum = 0;
            circularProgressBar7.Maximum = 100;

            circularProgressBar8.Value = 0;
            circularProgressBar8.Minimum = 0;
            circularProgressBar8.Maximum = 100;

            circularProgressBar9.Value = 0;
            circularProgressBar9.Minimum = 0;
            circularProgressBar9.Maximum = 100;

            circularProgressBar10.Value = 0;
            circularProgressBar10.Minimum = 0;
            circularProgressBar10.Maximum = 100;

            circularProgressBar11.Value = 0;
            circularProgressBar11.Minimum = 0;
            circularProgressBar11.Maximum = 100;

            circularProgressBar12.Value = 0;
            circularProgressBar12.Minimum = 0;
            circularProgressBar12.Maximum = 100;

            circularProgressBar13.Value = 0;
            circularProgressBar13.Minimum = 0;
            circularProgressBar13.Maximum = 100;

            circularProgressBar14.Value = 0;
            circularProgressBar14.Minimum = 0;
            circularProgressBar14.Maximum = 100;

            circularProgressBar15.Value = 0;
            circularProgressBar15.Minimum = 0;
            circularProgressBar15.Maximum = 100;

            circularProgressBar16.Value = 0;
            circularProgressBar16.Minimum = 0;
            circularProgressBar16.Maximum = 100;


            circularProgressBar17.Value = 0;
            circularProgressBar17.Minimum = 0;
            circularProgressBar17.Maximum = 100;






        }

        private void panel1_Paint_2(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Tipo();
            if (tipo != "Proyectos-Inox")
            {
                progreso1.Visible = true;
                progreso2.Visible = true;
                progreso3.Visible = true;
                progreso4.Visible = true;
                valor1.Visible = true;
                valor2.Visible = true;
                valor3.Visible = true;
                valor4.Visible = true;
                Carpeta1.Visible = true;
                Carpeta2.Visible = true;
                Carpeta3.Visible = true;
                Carpeta4.Visible = true;
                Carpeta1.Text = "Obra Civil";
                Carpeta2.Text = "Siroc e Imss";
                Carpeta3.Text = "Dossier de calidad";
                Carpeta4.Text = "";
            }

            else {
                progreso1.Visible = true;
                progreso2.Visible = true;
                progreso3.Visible = false;
                progreso4.Visible = false;
                valor1.Visible = true;
                valor2.Visible = true;
                valor3.Visible = false;
                valor4.Visible = false;
                Carpeta1.Visible = true;
                Carpeta2.Visible = true;
                Carpeta3.Visible = false;
                Carpeta4.Visible = false;
                
                Carpeta1.Text = "Lista de Materiales y Equipos";
                Carpeta2.Text = "Instalacion y Preparativos";
                Carpeta3.Text = "Fabricacion y Equipamiento";
                Carpeta4.Text = "Dossier de calidad";
            }

            Archivos.Text = "";
            SqlConnection conexion = new SqlConnection(ObtenerCadena());
            conexion.Open();
            SqlCommand cmd2 = new SqlCommand(
                                           "select " + 
     "  [AtencionClientes]"+
     " ,[AtencionClientes_Atencion]"+
     " ,[AtencionClientes_EntregaDocumentos]"+
     " ,[AtencionClientes_Postventa]"+
     " ,[AtencionClientes_Encuesta]"+
     " ,[Finanzas]"+
     " ,[Finanzas_CierreProyecto]"+
     " ,[Compras]"+
     " ,[Dosier de Calidad]"+
     " ,[Ventas]"+
     " ,[Ventas_AltayDocumentosClientes]"+
     " ,[Ventas_PedidoInterno]"+
     " ,[Ventas_ExpedienteComercial]"+
     " ,[Proyectos]"+
     " ,[Proyectos_ExpedienteTecnico]"+
     " ,[Proyectos_Planos]"+
     " ,[EquipamientoeInstalaciones]"+
     " ,[EquipamientoeInstalaciones_Fabricacion y Equipamiento]"+
     " ,[EquipamientoeInstalaciones_Instalacionyarranque]"+
     " ,[EquipamientoeInstalaciones_OperacionyMantenimiento]"+
     " ,[General]"+


                                           "from [Proyectos_Avance] where Proyecto = @proyecto"

                                           , conexion);
            SqlDataAdapter sda2 = new SqlDataAdapter(cmd2);
            cmd2.Parameters.AddWithValue("proyecto", Proyecto.Text);
            sda2.SelectCommand.CommandTimeout = 36000;
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            if (dt2.Rows.Count > 0)
            {



                AtencionClientes = dt2.Rows[0][0].ToString();
                AtencionClientes_Atencion = dt2.Rows[0][1].ToString();
                AtencionClientes_EntregaDocumentos = dt2.Rows[0][2].ToString();
                AtencionClientes_Postventa = dt2.Rows[0][3].ToString();
                AtencionClientes_Encuesta = dt2.Rows[0][4].ToString();
                Finanzas = dt2.Rows[0][5].ToString();
                Finanzas_CierreProyecto = dt2.Rows[0][6].ToString();
                Compraas = dt2.Rows[0][7].ToString();
                DosierdeCalidad = dt2.Rows[0][8].ToString();
                Ventas = dt2.Rows[0][9].ToString();
                Ventas_AltayDocumentosClientes = dt2.Rows[0][10].ToString();
                Ventas_PedidoInterno = dt2.Rows[0][11].ToString();
                Ventas_ExpedienteComercial = dt2.Rows[0][12].ToString();
                Proyectos = dt2.Rows[0][13].ToString();
                Proyectos_ExpedienteTecnic = dt2.Rows[0][14].ToString();
                Proyectos_Planos = dt2.Rows[0][15].ToString();
                EquipamientoeInstalaciones = dt2.Rows[0][16].ToString();
                EquipamientoeInstalaciones_FabricacionyEquipamiento = dt2.Rows[0][17].ToString();
                EquipamientoeInstalaciones_Instalacionyarranque = dt2.Rows[0][18].ToString();
                EquipamientoeInstalaciones_OperacionyMantenimiento = dt2.Rows[0][19].ToString();
                General = dt2.Rows[0][20].ToString();


                conexion.Dispose();
            }



            if (AtencionClientes == "" || AtencionClientes == null || AtencionClientes == "0") { AtencionClientes = "0.001"; }
            if (AtencionClientes_Atencion == "" || AtencionClientes_Atencion == null || AtencionClientes_Atencion == "0") { AtencionClientes_Atencion = "0.001"; }
            if (AtencionClientes_EntregaDocumentos == "" || AtencionClientes_EntregaDocumentos == null || AtencionClientes_EntregaDocumentos == "0") { AtencionClientes_EntregaDocumentos = "0.001"; }
            if (AtencionClientes_Postventa == "" || AtencionClientes_Postventa == null || AtencionClientes_Postventa == "0") { AtencionClientes_Postventa = "0.001"; }
            if (AtencionClientes_Encuesta == "" || AtencionClientes_Encuesta == null || AtencionClientes_Encuesta == "0") { AtencionClientes_Encuesta = "0.001"; }
            if (Finanzas == "" || Finanzas == null || Finanzas == "0") { Finanzas = "0.001"; }
            if (Finanzas_CierreProyecto == "" || Finanzas_CierreProyecto == null || Finanzas_CierreProyecto == "0") { Finanzas_CierreProyecto = "0.001"; }
            if (Compraas == "" || Compraas == null || Compraas == "0") { Compraas = "0.001"; }
            if (DosierdeCalidad == "" || DosierdeCalidad == null || DosierdeCalidad == "0") { DosierdeCalidad = "0.001"; }
            if (Ventas == "" || Ventas == null || Ventas == "0") { Ventas = "0.001"; }
            if (Ventas_AltayDocumentosClientes == "" || Ventas_AltayDocumentosClientes == null || Ventas_AltayDocumentosClientes == "0") { Ventas_AltayDocumentosClientes = "0.001"; }
            if (Ventas_PedidoInterno == "" || Ventas_PedidoInterno == null || Ventas_PedidoInterno == "0") { Ventas_PedidoInterno = "0.001"; }
            if (Ventas_ExpedienteComercial == "" || Ventas_ExpedienteComercial == null || Ventas_ExpedienteComercial == "0") { Ventas_ExpedienteComercial = "0.001"; }
            if (Proyectos == "" || Ventas_ExpedienteComercial == null || Ventas_ExpedienteComercial == "0") { Ventas_ExpedienteComercial = "0.001"; }
            if (Proyectos_ExpedienteTecnic == "" || Proyectos_ExpedienteTecnic == null || Proyectos_ExpedienteTecnic == "0") { Proyectos_ExpedienteTecnic = "0.001"; }
            if (EquipamientoeInstalaciones == "" || EquipamientoeInstalaciones == null || EquipamientoeInstalaciones == "0") { EquipamientoeInstalaciones = "0.001"; }
            if (EquipamientoeInstalaciones_FabricacionyEquipamiento == "" || EquipamientoeInstalaciones_FabricacionyEquipamiento == null || EquipamientoeInstalaciones_FabricacionyEquipamiento == "0") { EquipamientoeInstalaciones_FabricacionyEquipamiento = "0.001"; }
            if (EquipamientoeInstalaciones_Instalacionyarranque == "" || EquipamientoeInstalaciones_Instalacionyarranque == null || EquipamientoeInstalaciones_Instalacionyarranque == "0") { EquipamientoeInstalaciones_Instalacionyarranque = "0.001"; }
            if (EquipamientoeInstalaciones_OperacionyMantenimiento == "" || EquipamientoeInstalaciones_OperacionyMantenimiento == null || EquipamientoeInstalaciones_OperacionyMantenimiento == "0") { EquipamientoeInstalaciones_OperacionyMantenimiento = "0.001"; }
            if (General == "" || General == null || General == "0") { General = "0.001"; }





            altasydocumentoscliente.Text = Ventas_AltayDocumentosClientes + " %";
            atencionaclientes.Text = AtencionClientes_Atencion + " %";
            calidad.Text = DosierdeCalidad + " %";
            cierreproyecto.Text = Finanzas_CierreProyecto + " %";
            entregdocumentos.Text = AtencionClientes_EntregaDocumentos + " %";
            Encuesta.Text= AtencionClientes_Encuesta + " %";
            expedientecomercial.Text = Ventas_ExpedienteComercial + " %";
            expedientetecnico.Text = Proyectos_ExpedienteTecnic + " %";
            posventa.Text = AtencionClientes_Postventa + " %";
            planos.Text = Proyectos_Planos + " %";
            pedidointerno.Text = Ventas_PedidoInterno + " %";
            operacionymantenimiento.Text = EquipamientoeInstalaciones_OperacionyMantenimiento + " %";
            Fabricacion.Text = EquipamientoeInstalaciones_FabricacionyEquipamiento + " %";
            instalacionyarranque.Text = EquipamientoeInstalaciones_Instalacionyarranque + " %";
     
            total.Text = General + " %";
            Compras.Text = Compraas + "%";
      
            this.chart1.Series.Clear();
            this.chart1.Titles.Clear();
            chart1.Series.Add("Compras");
            chart1.Series.Add("Ventas");
            chart1.Series.Add("Atencion a Clientes");
            chart1.Series.Add("Producción");
            chart1.Series.Add("Finanzas");
            chart1.Series.Add("Proyectos");
            chart1.Series.Add("Equipamiento e Insta");
         
            chart1.Visible = true;
            grafico();
            decimal general = Convert.ToDecimal(General);
            int intGeneral = Convert.ToInt32(general);

            decimal dato = Convert.ToDecimal(EquipamientoeInstalaciones_FabricacionyEquipamiento);
            int iProduccion_FabricacionyEquipamiento = Convert.ToInt32(dato);

            decimal dato2 = Convert.ToDecimal(EquipamientoeInstalaciones_Instalacionyarranque);
            int iEquipamientoeInstalaciones_Instalacionyarranque = Convert.ToInt32(dato2);

            //decimal dato3 = Convert.ToDecimal(Proyectos_ListadeMaterialesyEquipos);
            //int iProyectos_ListadeMaterialesyEquipos = Convert.ToInt32(dato3);

            decimal dato4 = Convert.ToDecimal(EquipamientoeInstalaciones_OperacionyMantenimiento);
            int iEquipamientoeInstalaciones_OperacionyMantenimiento = Convert.ToInt32(dato4);

            decimal dato5 = Convert.ToDecimal(Ventas_PedidoInterno);
            int iVentas_PedidoInterno = Convert.ToInt32(dato5);

            decimal dato6 = Convert.ToDecimal(Proyectos_Planos);
            int iProyectos_Planos = Convert.ToInt32(dato6);

            decimal dato7 = Convert.ToDecimal(AtencionClientes_Postventa);
            int iAtencionClientes_Postventa = Convert.ToInt32(dato7);

            decimal dato8 = Convert.ToDecimal(Proyectos_ExpedienteTecnic);
            int iProyectos_ExpedienteTecnico = Convert.ToInt32(dato8);

            decimal dato9 = Convert.ToDecimal(Ventas_ExpedienteComercial);
            int iVentas_ExpedienteComercial = Convert.ToInt32(dato9);

            decimal dato10 = Convert.ToDecimal(AtencionClientes_EntregaDocumentos);
            int iAtencionClientes_EntregaDocumentos = Convert.ToInt32(dato10);

            decimal dato11 = Convert.ToDecimal(Finanzas_CierreProyecto);
            int iFinanzas_CierreProyecto = Convert.ToInt32(dato11);

            decimal dato12 = Convert.ToDecimal(DosierdeCalidad);
            int iProduccion_Calidad = Convert.ToInt32(dato12);

            decimal dato13 = Convert.ToDecimal(AtencionClientes_Atencion);
            int iAtencionClientes_Atencion = Convert.ToInt32(dato13);

            decimal dato14 = Convert.ToDecimal(Ventas_AltayDocumentosClientes);
            int iVentas_AltayDocumentosClientes = Convert.ToInt32(dato14);

            decimal dato15 = Convert.ToDecimal(Compraas);
            int iCompras = Convert.ToInt32(dato15);

            decimal dato16 = Convert.ToDecimal(AtencionClientes_Encuesta);
            int iEncuesta = Convert.ToInt32(dato16);

            circularProgressBar1.Value = Convert.ToInt32(intGeneral);
        
            circularProgressBar3.Value = Convert.ToInt32(iEquipamientoeInstalaciones_Instalacionyarranque);
            circularProgressBar4.Value = Convert.ToInt32(iProduccion_FabricacionyEquipamiento);
            circularProgressBar5.Value = Convert.ToInt32(iEquipamientoeInstalaciones_OperacionyMantenimiento);
            circularProgressBar6.Value = Convert.ToInt32(iVentas_PedidoInterno);
            circularProgressBar7.Value = Convert.ToInt32(iProyectos_Planos);
            circularProgressBar8.Value = Convert.ToInt32(iAtencionClientes_Postventa);
            circularProgressBar9.Value = Convert.ToInt32(iProyectos_ExpedienteTecnico);
            circularProgressBar10.Value = Convert.ToInt32(iVentas_ExpedienteComercial);
            circularProgressBar11.Value = Convert.ToInt32(iAtencionClientes_EntregaDocumentos);
            circularProgressBar12.Value = Convert.ToInt32(iFinanzas_CierreProyecto);
            circularProgressBar13.Value = Convert.ToInt32(iProduccion_Calidad);
            circularProgressBar14.Value = Convert.ToInt32(iAtencionClientes_Atencion);
            circularProgressBar15.Value = Convert.ToInt32(iVentas_AltayDocumentosClientes);
            circularProgressBar16.Value = Convert.ToInt32(iCompras);
            circularProgressBar17.Value = Convert.ToInt32(iEncuesta);

            tipoF.Text = tipo;

        }


        public void grafico() {

         
    
            Series S = chart1.Series[0];
            Series S2 = chart1.Series[1];
            Series S3 = chart1.Series[2];
            Series S4 = chart1.Series[3];
            Series S5 = chart1.Series[4];
            Series S6 = chart1.Series[5];
            Series S7 = chart1.Series[6];
            ChartArea CA = chart1.ChartAreas[0];
            ChartArea CA2 = chart1.ChartAreas[0];
            ChartArea CA3 = chart1.ChartAreas[0];
            ChartArea CA4 = chart1.ChartAreas[0];
            ChartArea CA5 = chart1.ChartAreas[0];
            ChartArea CA6 = chart1.ChartAreas[0];
            ChartArea CA7 = chart1.ChartAreas[0];
            Axis AY = CA.AxisY;
            Axis AY2 = CA2.AxisY;
            Axis AY3 = CA3.AxisY;
            Axis AY4 = CA4.AxisY;
            Axis AY5 = CA5.AxisY;
            Axis AY6 = CA6.AxisY;
            Axis AY7 = CA7.AxisY;
            Title titulo = new Title("Departamentos");
            chart1.Titles.Add(titulo);
            Color color = ColorTranslator.FromHtml("#003366");


 
            S.Points.AddXY("Valor", Ventas);
            S2.Points.AddXY("Valor", AtencionClientes);
            S3.Points.AddXY("Valor", EquipamientoeInstalaciones_FabricacionyEquipamiento);
            S4.Points.AddXY("Valor", Finanzas);
            S5.Points.AddXY("Valor", Proyectos);
            S6.Points.AddXY("Valor", EquipamientoeInstalaciones);
            S7.Points.AddXY("Valor", Compraas);
            CA.Area3DStyle.Enable3D = true;
            CA2.Area3DStyle.Enable3D = true;
            CA3.Area3DStyle.Enable3D = true;
            CA4.Area3DStyle.Enable3D = true;
            CA5.Area3DStyle.Enable3D = true;
            CA6.Area3DStyle.Enable3D = true;
            CA7.Area3DStyle.Enable3D = true;
            S.IsValueShownAsLabel = true;
            S2.IsValueShownAsLabel = true;
            S3.IsValueShownAsLabel = true;
            S4.IsValueShownAsLabel = true;
            S5.IsValueShownAsLabel = true;
            S6.IsValueShownAsLabel = true;
            S7.IsValueShownAsLabel = true;
            S.Label = "#VALY{#.##}" + "% " + "Ventas";
            S.ToolTip = "#VALX{#.##}" + " : " + "#VALY1{#.##}";
            S2.Label = "#VALY{#.##}" + "% " + "Atencion a clientes";
            S2.ToolTip = "#VALX{#.##}" + " : " + "#VALY1{#.##}";
            S3.Label = "#VALY{#.##}" + "% " + "Produccion";
            S3.ToolTip = "#VALX{#.##}" + " : " + "#VALY1{#.##}";
            S4.Label = "#VALY{#.##}" + "% " + "Finanzas";
            S4.ToolTip = "#VALX{#.##}" + " : " + "#VALY1{#.##}";
            S5.Label = "#VALY{#.##}" + "% " + "Proyectos";
            S5.ToolTip = "#VALX{#.##}" + " : " + "#VALY1{#.##}";
            S6.Label = "#VALY{#.##}" + "% " + "Equipamiento";
            S6.ToolTip = "#VALX{#.##}" + " : " + "#VALY1{#.##}";
            S7.Label = "#VALY{#.##}" + "% " + "Compras";
            S7.ToolTip = "#VALX{#.##}" + " : " + "#VALY1{#.##}";
            double max = S.Points.Max(x => x.YValues[0]);
            double max2 = S.Points.Max(x => x.YValues[0]);
            double max3 = S.Points.Max(x => x.YValues[0]);
            double max4 = S.Points.Max(x => x.YValues[0]);
            double max5 = S.Points.Max(x => x.YValues[0]);
            double max6 = S.Points.Max(x => x.YValues[0]);
            double max7 = S.Points.Max(x => x.YValues[0]);
            for (int i = 0; i < S.Points.Count; i++)
            {
                DataPoint dp = S.Points[i];
                double y0 = S.Points[i].YValues[0];
                AY.CustomLabels.Add(y0, y0 + 1, (y0 / max * 100f).ToString("0.0") + "%");

            }

        }


        private void Tipo()
        {
            String año = "",  nombre = "";
            Archivos.Text = "";
            SqlConnection conexion = new SqlConnection(ObtenerCadena());
            conexion.Open();
            SqlCommand cmd = new SqlCommand(
                                   "select" +
                                   "[Ano], " +
                                   "[tipo2], " +
                                   "[Nombre], " +
                                   "[Nombre2] " +

                                   "from [Folio_proyectos>2019]  where Nombre2=@Nombre2"

                                   , conexion);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("Nombre2", Proyecto.Text);
            sda.SelectCommand.CommandTimeout = 36000;
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                año = dt.Rows[0][0].ToString();
                tipo = dt.Rows[0][1].ToString();
                nombre = dt.Rows[0][2].ToString();





                conexion.Dispose();

            }
            else { }

            }
        }




    }

