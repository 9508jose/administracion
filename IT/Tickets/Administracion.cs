using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net.Mime;
using System.Data.SqlClient;
using CBR_ADMIN.Properties;
using System.Threading;
using CBR_ADMIN.Sistema;

namespace CBR_ADMIN.IT
{
    public partial class Administracion : UserControl
    {
        private static Administracion _instance;
        public static Administracion Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Administracion();
                return _instance;
            }
        }

        public Administracion()
        {
            InitializeComponent();
        }

        public static string ObtenerCadena()
        {
            return Settings.Default.CBR_IngenieriaConnectionString;/*Este codigo obtiene los datos de la cadena de conexion declarada en los settings de la aplicacion*/
        }
        SqlConnection conexion = new SqlConnection(ObtenerCadena());
        public string Permiso;
        public string Nombre;
        public string Apellido;
        String Tik,Email;
        String fecha2, fecha3, fecha4;
        String Hora2;

    

        private void Adminstracion_Load(object sender, EventArgs e)
        {
            ThreadStart proceso = new ThreadStart(MostrarCuadroInicio); Thread hilo = new Thread(proceso);
            hilo.Start();
            // TODO: esta línea de código carga datos en la tabla 'cBR_Tikets.Tickets' Puede moverla o quitarla según sea necesario.
            this.ticketsTableAdapter.Fill(this.cbr_Tikets.Tickets);
            // TODO: esta línea de código carga datos en la tabla 'tikets_Fecha.Tikets_fecha' Puede moverla o quitarla según sea necesario.


            string UsuarioWindows = SystemInformation.UserName;
            uwin.Text = UsuarioWindows;
            Usuario.Text = Nombre;
            hilo.Abort();
        }
        private void MostrarCuadroInicio()
        {
          

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void Generar_Click(object sender, EventArgs e)
        {

            fecha2 = DateTime.Now.ToString("MM");
            fecha3 = DateTime.Now.ToString("yy");
            Hora2 = DateTime.Now.ToString("hh");
            fecha4 = fecha2 + fecha3;
            Tik = Nombre.Substring(0, 2) + "AD" + fecha4 + "-" + Hora2;

            this.ticketsTableAdapter.Generar(Tik, "Administracion", Nombre, Apellido, Detalle.Text, CB_Adm.Text, "2", "Sin iniciar");
            this.tikets_fechaTableAdapter.TikFech(Tik, DateTime.Now);
            DialogResult Resultado;
            envia(Nombre, Apellido);
            Resultado = MessageBox.Show("Tiket Generado");
            Resultado = MessageBox.Show("Su Tiket es  " + Tik);
        }

        private AlternateView getEmbeddedImage(String filePath)
        {
            // below line was corrected to include the mediatype so it displays in all 
            // mail clients. previous solution only displays in Gmail the inline images 
            LinkedResource res = new LinkedResource(filePath, MediaTypeNames.Image.Jpeg);
  
            res.ContentId = Guid.NewGuid().ToString();
            String Body = "<DIV><H5>Se ha generado un tickets con numero</HEAD></DIV></H>"+Tik;
            Body += "<DIV>En breve el personal de sistemas atendera su solicitud  </DIV>" +
                "";




            string htmlBody = "" + Body + "" + @"<img src='cid:" + res.ContentId + @"'/> ";

            AlternateView alternateView = AlternateView.CreateAlternateViewFromString(htmlBody,
             null, MediaTypeNames.Text.Html);
            alternateView.LinkedResources.Add(res);
            return alternateView;
        }
   
        public void envia(string nombre,string apellido)
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
                                                "where [Nombre]=@Nombre and Apellido =@Apellido "

                                                , conexion);
                cmd.Parameters.AddWithValue("Apellido", Apellido);
                cmd.Parameters.AddWithValue("Nombre", Nombre);


                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.SelectCommand.CommandTimeout = 36000;
                DataTable dt = new DataTable();
                sda.Fill(dt);

                conexion.Dispose();

                if (dt.Rows.Count > 0)
                {
                    Email = dt.Rows[0][7].ToString();
                    string _sender = "support@cbr-ingenieria.com.mx";
                    string _password = "Cbrsoporte2020.";
                    SmtpClient client = new SmtpClient("smtp.office365.com");
                    client.Port = 587;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    System.Net.NetworkCredential credentials =
                     new System.Net.NetworkCredential(_sender, _password);
                    client.EnableSsl = true;
                    client.Credentials = credentials;
                    MailMessage message = new MailMessage(_sender, Email);
                    message.CC.Add("jose.orzuna@cbr-ingenieria.com.mx");
                    message.Subject = "Generacion de Nuevo Ticket";
                    message.IsBodyHtml = true;
                    

                    message.AlternateViews.Add(getEmbeddedImage("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }

                else if (dt.Rows.Count < 0)
                {
                    MessageBox.Show("Nose encontraron destinatarios contactar a soporte");
                }


                ////////////////////////////////////SI EL USUARIO, CONTRASENA O PLANTA ESTA MAL//////////////////////////////////////////////////////////////////////////
                else
                {
                    MessageBox.Show("Sin resultado");
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
    }
}
