using CBR_ADMIN.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CBR_ADMIN.Sistema
{
    public partial class Crea_Rehabilitacion : Form
    {
        string valor;
        public string Nombre, contraseña, consecutivo, cap;
        int consecutivo1;
        string fecha, tipopt;
        string consecutivo2;
        DateTime Fechaf = DateTime.Now;
        int capacidad;
        string año = DateTime.Now.ToString("yyyy");
        String Email1, Email2, Email3, Email4, Email5, Email6, Email7, Email8, Email9, Email10;
        public Crea_Rehabilitacion()
        {
            InitializeComponent();
        }
        public static string ObtenerCadena()
        {
            return Settings.Default.CBR_IngenieriaConnectionString;/*Este codigo obtiene los datos de la cadena de conexion declarada en los settings de la aplicacion*/


        }

        private void Crea_Rehabilitacion_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'cBR_Folio_Rehabilitacion.Folio_Rehabilitaciones' Puede moverla o quitarla según sea necesario.
            this.folio_RehabilitacionesTableAdapter.Fill(this.cBR_Folio_Rehabilitacion.Folio_Rehabilitaciones);
            // TODO: esta línea de código carga datos en la tabla 'folio_Proyectos._Folio_Proyectos' Puede moverla o quitarla según sea necesario.
       
            comboBox3.Visible = false;
            textBox1.Visible = false;
            label8.Visible = false;
            label7.Visible = false;

        }
        private AlternateView getEmbeddedImage2(String filePath)
        {



            // below line was corrected to include the mediatype so it displays in all 
            // mail clients. previous solution only displays in Gmail the inline images 
            LinkedResource res = new LinkedResource(filePath, MediaTypeNames.Image.Jpeg);
            res.ContentId = Guid.NewGuid().ToString();
            String Body = "<DIV><H5>Se ha generado una Rehabilitacion con nombre: </HEAD></DIV></H>" + NombreProyecto.Text; ;
            Body += "<DIV><H5>Con folio: </HEAD></DIV></H>" + Folio.Text; ;
            Body += "<DIV>Ingrese ala plataforma para darle seguimiento</DIV>";




            string htmlBody = "" + Body + "" + @"<img src='cid:" + res.ContentId + @"'/> ";
            AlternateView alternateView = AlternateView.CreateAlternateViewFromString(htmlBody,
             null, MediaTypeNames.Text.Html);
            alternateView.LinkedResources.Add(res);
            return alternateView;
        }
        public void enviamasivo1(string Departamento)
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
                                                "where [Departamento]=@Departamento "

                                                , conexion);
                cmd.Parameters.AddWithValue("Departamento", "Direccion");



                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.SelectCommand.CommandTimeout = 36000;
                DataTable dt = new DataTable();
                sda.Fill(dt);

                conexion.Dispose();

                if (dt.Rows.Count == 1)
                {
                    Email1 = dt.Rows[0][7].ToString();
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
                    MailMessage message = new MailMessage(_sender, Email1);

                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }

                else if (dt.Rows.Count == 2)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    ///////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));

                    message.Subject = "Actualizacion de  Carpeta";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 3)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    /////////////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));

                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 4)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    Email4 = dt.Rows[3][7].ToString();
                    /////////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.CC.Add(new MailAddress(Email4));

                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 5)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    Email4 = dt.Rows[3][7].ToString();
                    Email5 = dt.Rows[4][7].ToString();
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.CC.Add(new MailAddress(Email4));
                    message.CC.Add(new MailAddress(Email5));

                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);

                }
                else if (dt.Rows.Count == 6)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    Email4 = dt.Rows[3][7].ToString();
                    Email5 = dt.Rows[4][7].ToString();
                    Email6 = dt.Rows[5][7].ToString();
                    /////////////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.CC.Add(new MailAddress(Email4));
                    message.CC.Add(new MailAddress(Email5));
                    message.CC.Add(new MailAddress(Email6));
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 7)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    Email4 = dt.Rows[3][7].ToString();
                    Email5 = dt.Rows[4][7].ToString();
                    Email6 = dt.Rows[5][7].ToString();
                    Email7 = dt.Rows[6][7].ToString();
                    //////////////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.CC.Add(new MailAddress(Email4));
                    message.CC.Add(new MailAddress(Email5));
                    message.CC.Add(new MailAddress(Email6));

                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 8)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    Email4 = dt.Rows[3][7].ToString();
                    Email5 = dt.Rows[4][7].ToString();
                    Email6 = dt.Rows[5][7].ToString();
                    Email7 = dt.Rows[6][7].ToString();
                    Email8 = dt.Rows[7][7].ToString();
                    ///////////////////////////////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.CC.Add(new MailAddress(Email4));
                    message.CC.Add(new MailAddress(Email5));
                    message.CC.Add(new MailAddress(Email6));
                    message.CC.Add(new MailAddress(Email7));
                    message.CC.Add(new MailAddress(Email8));
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 9)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    Email4 = dt.Rows[3][7].ToString();
                    Email5 = dt.Rows[4][7].ToString();
                    Email6 = dt.Rows[5][7].ToString();
                    Email7 = dt.Rows[6][7].ToString();
                    Email8 = dt.Rows[7][7].ToString();
                    Email9 = dt.Rows[8][7].ToString();
                    ///////////////////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.CC.Add(new MailAddress(Email4));
                    message.CC.Add(new MailAddress(Email5));
                    message.CC.Add(new MailAddress(Email6));
                    message.CC.Add(new MailAddress(Email7));
                    message.CC.Add(new MailAddress(Email8));
                    message.CC.Add(new MailAddress(Email9));
                    message.CC.Add(new MailAddress("sandra.cabrera@cbr-ingenieria.com.mx"));
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 10)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    Email4 = dt.Rows[3][7].ToString();
                    Email5 = dt.Rows[4][7].ToString();
                    Email6 = dt.Rows[5][7].ToString();
                    Email7 = dt.Rows[6][7].ToString();
                    Email8 = dt.Rows[7][7].ToString();
                    Email9 = dt.Rows[8][7].ToString();
                    Email10 = dt.Rows[9][7].ToString();
                    ////////////////////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.CC.Add(new MailAddress(Email4));
                    message.CC.Add(new MailAddress(Email5));
                    message.CC.Add(new MailAddress(Email6));
                    message.CC.Add(new MailAddress(Email7));
                    message.CC.Add(new MailAddress(Email8));
                    message.CC.Add(new MailAddress(Email9));
                    message.CC.Add(new MailAddress(Email10));
                    message.CC.Add(new MailAddress("sandra.cabrera@cbr-ingenieria.com.mx"));
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);

                }
                else if (dt.Rows.Count > 10)
                {
                    MessageBox.Show("Numero de destinatarios maximo alcanzado por departamento contacte con soporte");
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
        /// Asistente de direccion
        public void enviamasivo2(string Departamento)
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
                                                "where [Departamento]=@Departamento "

                                                , conexion);
                cmd.Parameters.AddWithValue("Departamento", "Asistente de direccion");



                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.SelectCommand.CommandTimeout = 36000;
                DataTable dt = new DataTable();
                sda.Fill(dt);

                conexion.Dispose();

                if (dt.Rows.Count == 1)
                {
                    Email1 = dt.Rows[0][7].ToString();
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
                    MailMessage message = new MailMessage(_sender, Email1);

                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }

                else if (dt.Rows.Count == 2)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    ///////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));

                    message.Subject = "Actualizacion de  Carpeta";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 3)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    /////////////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));

                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 4)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    Email4 = dt.Rows[3][7].ToString();
                    /////////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.CC.Add(new MailAddress(Email4));
                    ;
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 5)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    Email4 = dt.Rows[3][7].ToString();
                    Email5 = dt.Rows[4][7].ToString();
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.CC.Add(new MailAddress(Email4));
                    message.CC.Add(new MailAddress(Email5));

                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);

                }
                else if (dt.Rows.Count == 6)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    Email4 = dt.Rows[3][7].ToString();
                    Email5 = dt.Rows[4][7].ToString();
                    Email6 = dt.Rows[5][7].ToString();
                    /////////////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.CC.Add(new MailAddress(Email4));
                    message.CC.Add(new MailAddress(Email5));
                    message.CC.Add(new MailAddress(Email6));
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 7)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    Email4 = dt.Rows[3][7].ToString();
                    Email5 = dt.Rows[4][7].ToString();
                    Email6 = dt.Rows[5][7].ToString();
                    Email7 = dt.Rows[6][7].ToString();
                    //////////////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.CC.Add(new MailAddress(Email4));
                    message.CC.Add(new MailAddress(Email5));
                    message.CC.Add(new MailAddress(Email6));

                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 8)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    Email4 = dt.Rows[3][7].ToString();
                    Email5 = dt.Rows[4][7].ToString();
                    Email6 = dt.Rows[5][7].ToString();
                    Email7 = dt.Rows[6][7].ToString();
                    Email8 = dt.Rows[7][7].ToString();
                    ///////////////////////////////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.CC.Add(new MailAddress(Email4));
                    message.CC.Add(new MailAddress(Email5));
                    message.CC.Add(new MailAddress(Email6));
                    message.CC.Add(new MailAddress(Email7));
                    message.CC.Add(new MailAddress(Email8));
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 9)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    Email4 = dt.Rows[3][7].ToString();
                    Email5 = dt.Rows[4][7].ToString();
                    Email6 = dt.Rows[5][7].ToString();
                    Email7 = dt.Rows[6][7].ToString();
                    Email8 = dt.Rows[7][7].ToString();
                    Email9 = dt.Rows[8][7].ToString();
                    ///////////////////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.CC.Add(new MailAddress(Email4));
                    message.CC.Add(new MailAddress(Email5));
                    message.CC.Add(new MailAddress(Email6));
                    message.CC.Add(new MailAddress(Email7));
                    message.CC.Add(new MailAddress(Email8));
                    message.CC.Add(new MailAddress(Email9));

                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 10)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    Email4 = dt.Rows[3][7].ToString();
                    Email5 = dt.Rows[4][7].ToString();
                    Email6 = dt.Rows[5][7].ToString();
                    Email7 = dt.Rows[6][7].ToString();
                    Email8 = dt.Rows[7][7].ToString();
                    Email9 = dt.Rows[8][7].ToString();
                    Email10 = dt.Rows[9][7].ToString();
                    ////////////////////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.CC.Add(new MailAddress(Email4));
                    message.CC.Add(new MailAddress(Email5));
                    message.CC.Add(new MailAddress(Email6));
                    message.CC.Add(new MailAddress(Email7));
                    message.CC.Add(new MailAddress(Email8));
                    message.CC.Add(new MailAddress(Email9));
                    message.CC.Add(new MailAddress(Email10));

                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);

                }
                else if (dt.Rows.Count > 10)
                {
                    MessageBox.Show("Numero de destinatarios maximo alcanzado por departamento contacte con soporte");
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
        /// ventas
        public void enviamasivo3(string Departamento)
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
                                                "where [Departamento]=@Departamento "

                                                , conexion);
                cmd.Parameters.AddWithValue("Departamento", "Ventas");



                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.SelectCommand.CommandTimeout = 36000;
                DataTable dt = new DataTable();
                sda.Fill(dt);

                conexion.Dispose();

                if (dt.Rows.Count == 1)
                {
                    Email1 = dt.Rows[0][7].ToString();
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }

                else if (dt.Rows.Count == 2)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    ///////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress("sandra.cabrera@cbr-ingenieria.com.mx"));
                    message.Subject = "Actualizacion de  Carpeta";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 3)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    /////////////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 4)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    Email4 = dt.Rows[3][7].ToString();
                    /////////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.CC.Add(new MailAddress(Email4));
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 5)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    Email4 = dt.Rows[3][7].ToString();
                    Email5 = dt.Rows[4][7].ToString();
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.CC.Add(new MailAddress(Email4));
                    message.CC.Add(new MailAddress(Email5));
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);

                }
                else if (dt.Rows.Count == 6)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    Email4 = dt.Rows[3][7].ToString();
                    Email5 = dt.Rows[4][7].ToString();
                    Email6 = dt.Rows[5][7].ToString();
                    /////////////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.CC.Add(new MailAddress(Email4));
                    message.CC.Add(new MailAddress(Email5));
                    message.CC.Add(new MailAddress(Email6));
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 7)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    Email4 = dt.Rows[3][7].ToString();
                    Email5 = dt.Rows[4][7].ToString();
                    Email6 = dt.Rows[5][7].ToString();
                    Email7 = dt.Rows[6][7].ToString();
                    //////////////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.CC.Add(new MailAddress(Email4));
                    message.CC.Add(new MailAddress(Email5));
                    message.CC.Add(new MailAddress(Email6));
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 8)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    Email4 = dt.Rows[3][7].ToString();
                    Email5 = dt.Rows[4][7].ToString();
                    Email6 = dt.Rows[5][7].ToString();
                    Email7 = dt.Rows[6][7].ToString();
                    Email8 = dt.Rows[7][7].ToString();
                    ///////////////////////////////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.CC.Add(new MailAddress(Email4));
                    message.CC.Add(new MailAddress(Email5));
                    message.CC.Add(new MailAddress(Email6));
                    message.CC.Add(new MailAddress(Email7));
                    message.CC.Add(new MailAddress(Email8));
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 9)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    Email4 = dt.Rows[3][7].ToString();
                    Email5 = dt.Rows[4][7].ToString();
                    Email6 = dt.Rows[5][7].ToString();
                    Email7 = dt.Rows[6][7].ToString();
                    Email8 = dt.Rows[7][7].ToString();
                    Email9 = dt.Rows[8][7].ToString();
                    ///////////////////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.CC.Add(new MailAddress(Email4));
                    message.CC.Add(new MailAddress(Email5));
                    message.CC.Add(new MailAddress(Email6));
                    message.CC.Add(new MailAddress(Email7));
                    message.CC.Add(new MailAddress(Email8));
                    message.CC.Add(new MailAddress(Email9));
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 10)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    Email4 = dt.Rows[3][7].ToString();
                    Email5 = dt.Rows[4][7].ToString();
                    Email6 = dt.Rows[5][7].ToString();
                    Email7 = dt.Rows[6][7].ToString();
                    Email8 = dt.Rows[7][7].ToString();
                    Email9 = dt.Rows[8][7].ToString();
                    Email10 = dt.Rows[9][7].ToString();
                    ////////////////////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.CC.Add(new MailAddress(Email4));
                    message.CC.Add(new MailAddress(Email5));
                    message.CC.Add(new MailAddress(Email6));
                    message.CC.Add(new MailAddress(Email7));
                    message.CC.Add(new MailAddress(Email8));
                    message.CC.Add(new MailAddress(Email9));
                    message.CC.Add(new MailAddress(Email10));
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);

                }
                else if (dt.Rows.Count > 10)
                {
                    MessageBox.Show("Numero de destinatarios maximo alcanzado por departamento contacte con soporte");
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
        /// proyectos
        public void enviamasivo4(string Departamento)
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
                                                "where [Departamento]=@Departamento "

                                                , conexion);
                cmd.Parameters.AddWithValue("Departamento", "Proyectos");



                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.SelectCommand.CommandTimeout = 36000;
                DataTable dt = new DataTable();
                sda.Fill(dt);

                conexion.Dispose();

                if (dt.Rows.Count == 1)
                {
                    Email1 = dt.Rows[0][7].ToString();
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress("sandra.cabrera@cbr-ingenieria.com.mx"));
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }

                else if (dt.Rows.Count == 2)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    ///////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.Subject = "Actualizacion de  Carpeta";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 3)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    /////////////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 4)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    Email4 = dt.Rows[3][7].ToString();
                    /////////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.CC.Add(new MailAddress(Email4));
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 5)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    Email4 = dt.Rows[3][7].ToString();
                    Email5 = dt.Rows[4][7].ToString();
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.CC.Add(new MailAddress(Email4));
                    message.CC.Add(new MailAddress(Email5));
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);

                }
                else if (dt.Rows.Count == 6)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    Email4 = dt.Rows[3][7].ToString();
                    Email5 = dt.Rows[4][7].ToString();
                    Email6 = dt.Rows[5][7].ToString();
                    /////////////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.CC.Add(new MailAddress(Email4));
                    message.CC.Add(new MailAddress(Email5));
                    message.CC.Add(new MailAddress(Email6));
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 7)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    Email4 = dt.Rows[3][7].ToString();
                    Email5 = dt.Rows[4][7].ToString();
                    Email6 = dt.Rows[5][7].ToString();
                    Email7 = dt.Rows[6][7].ToString();
                    //////////////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.CC.Add(new MailAddress(Email4));
                    message.CC.Add(new MailAddress(Email5));
                    message.CC.Add(new MailAddress(Email6));
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 8)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    Email4 = dt.Rows[3][7].ToString();
                    Email5 = dt.Rows[4][7].ToString();
                    Email6 = dt.Rows[5][7].ToString();
                    Email7 = dt.Rows[6][7].ToString();
                    Email8 = dt.Rows[7][7].ToString();
                    ///////////////////////////////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.CC.Add(new MailAddress(Email4));
                    message.CC.Add(new MailAddress(Email5));
                    message.CC.Add(new MailAddress(Email6));
                    message.CC.Add(new MailAddress(Email7));
                    message.CC.Add(new MailAddress(Email8));
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 9)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    Email4 = dt.Rows[3][7].ToString();
                    Email5 = dt.Rows[4][7].ToString();
                    Email6 = dt.Rows[5][7].ToString();
                    Email7 = dt.Rows[6][7].ToString();
                    Email8 = dt.Rows[7][7].ToString();
                    Email9 = dt.Rows[8][7].ToString();
                    ///////////////////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.CC.Add(new MailAddress(Email4));
                    message.CC.Add(new MailAddress(Email5));
                    message.CC.Add(new MailAddress(Email6));
                    message.CC.Add(new MailAddress(Email7));
                    message.CC.Add(new MailAddress(Email8));
                    message.CC.Add(new MailAddress(Email9));
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 10)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    Email4 = dt.Rows[3][7].ToString();
                    Email5 = dt.Rows[4][7].ToString();
                    Email6 = dt.Rows[5][7].ToString();
                    Email7 = dt.Rows[6][7].ToString();
                    Email8 = dt.Rows[7][7].ToString();
                    Email9 = dt.Rows[8][7].ToString();
                    Email10 = dt.Rows[9][7].ToString();
                    ////////////////////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.CC.Add(new MailAddress(Email4));
                    message.CC.Add(new MailAddress(Email5));
                    message.CC.Add(new MailAddress(Email6));
                    message.CC.Add(new MailAddress(Email7));
                    message.CC.Add(new MailAddress(Email8));
                    message.CC.Add(new MailAddress(Email9));
                    message.CC.Add(new MailAddress(Email10));
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);

                }
                else if (dt.Rows.Count > 10)
                {
                    MessageBox.Show("Numero de destinatarios maximo alcanzado por departamento contacte con soporte");
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
        /// produccion
        public void enviamasivo5(string Departamento)
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
                                                "where [Departamento]=@Departamento "

                                                , conexion);
                cmd.Parameters.AddWithValue("Departamento", "Produccion");



                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.SelectCommand.CommandTimeout = 36000;
                DataTable dt = new DataTable();
                sda.Fill(dt);

                conexion.Dispose();

                if (dt.Rows.Count == 1)
                {
                    Email1 = dt.Rows[0][7].ToString();
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }

                else if (dt.Rows.Count == 2)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    ///////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.Subject = "Actualizacion de  Carpeta";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 3)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    /////////////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.CC.Add(new MailAddress("sandra.cabrera@cbr-ingenieria.com.mx"));
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 4)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    Email4 = dt.Rows[3][7].ToString();
                    /////////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.CC.Add(new MailAddress(Email4));
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 5)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    Email4 = dt.Rows[3][7].ToString();
                    Email5 = dt.Rows[4][7].ToString();
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.CC.Add(new MailAddress(Email4));
                    message.CC.Add(new MailAddress(Email5));
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);

                }
                else if (dt.Rows.Count == 6)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    Email4 = dt.Rows[3][7].ToString();
                    Email5 = dt.Rows[4][7].ToString();
                    Email6 = dt.Rows[5][7].ToString();
                    /////////////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.CC.Add(new MailAddress(Email4));
                    message.CC.Add(new MailAddress(Email5));
                    message.CC.Add(new MailAddress(Email6));
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 7)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    Email4 = dt.Rows[3][7].ToString();
                    Email5 = dt.Rows[4][7].ToString();
                    Email6 = dt.Rows[5][7].ToString();
                    Email7 = dt.Rows[6][7].ToString();
                    //////////////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.CC.Add(new MailAddress(Email4));
                    message.CC.Add(new MailAddress(Email5));
                    message.CC.Add(new MailAddress(Email6));
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 8)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    Email4 = dt.Rows[3][7].ToString();
                    Email5 = dt.Rows[4][7].ToString();
                    Email6 = dt.Rows[5][7].ToString();
                    Email7 = dt.Rows[6][7].ToString();
                    Email8 = dt.Rows[7][7].ToString();
                    ///////////////////////////////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.CC.Add(new MailAddress(Email4));
                    message.CC.Add(new MailAddress(Email5));
                    message.CC.Add(new MailAddress(Email6));
                    message.CC.Add(new MailAddress(Email7));
                    message.CC.Add(new MailAddress(Email8));
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 9)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    Email4 = dt.Rows[3][7].ToString();
                    Email5 = dt.Rows[4][7].ToString();
                    Email6 = dt.Rows[5][7].ToString();
                    Email7 = dt.Rows[6][7].ToString();
                    Email8 = dt.Rows[7][7].ToString();
                    Email9 = dt.Rows[8][7].ToString();
                    ///////////////////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.CC.Add(new MailAddress(Email4));
                    message.CC.Add(new MailAddress(Email5));
                    message.CC.Add(new MailAddress(Email6));
                    message.CC.Add(new MailAddress(Email7));
                    message.CC.Add(new MailAddress(Email8));
                    message.CC.Add(new MailAddress(Email9));
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 10)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    Email4 = dt.Rows[3][7].ToString();
                    Email5 = dt.Rows[4][7].ToString();
                    Email6 = dt.Rows[5][7].ToString();
                    Email7 = dt.Rows[6][7].ToString();
                    Email8 = dt.Rows[7][7].ToString();
                    Email9 = dt.Rows[8][7].ToString();
                    Email10 = dt.Rows[9][7].ToString();
                    ////////////////////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.CC.Add(new MailAddress(Email4));
                    message.CC.Add(new MailAddress(Email5));
                    message.CC.Add(new MailAddress(Email6));
                    message.CC.Add(new MailAddress(Email7));
                    message.CC.Add(new MailAddress(Email8));
                    message.CC.Add(new MailAddress(Email9));
                    message.CC.Add(new MailAddress(Email10));
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);

                }
                else if (dt.Rows.Count > 10)
                {
                    MessageBox.Show("Numero de destinatarios maximo alcanzado por departamento contacte con soporte");
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
        /// atencion a clientes
        public void enviamasivo6(string Departamento)
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
                                                "where [Departamento]=@Departamento "

                                                , conexion);
                cmd.Parameters.AddWithValue("Departamento", "Atencion a Clientes");



                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.SelectCommand.CommandTimeout = 36000;
                DataTable dt = new DataTable();
                sda.Fill(dt);

                conexion.Dispose();

                if (dt.Rows.Count == 1)
                {
                    Email1 = dt.Rows[0][7].ToString();
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }

                else if (dt.Rows.Count == 2)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    ///////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.Subject = "Actualizacion de  Carpeta";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 3)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    /////////////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 4)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    Email4 = dt.Rows[3][7].ToString();
                    /////////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.CC.Add(new MailAddress(Email4));
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 5)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    Email4 = dt.Rows[3][7].ToString();
                    Email5 = dt.Rows[4][7].ToString();
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.CC.Add(new MailAddress(Email4));
                    message.CC.Add(new MailAddress(Email5));
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);

                }
                else if (dt.Rows.Count == 6)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    Email4 = dt.Rows[3][7].ToString();
                    Email5 = dt.Rows[4][7].ToString();
                    Email6 = dt.Rows[5][7].ToString();
                    /////////////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.CC.Add(new MailAddress(Email4));
                    message.CC.Add(new MailAddress(Email5));
                    message.CC.Add(new MailAddress(Email6));
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 7)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    Email4 = dt.Rows[3][7].ToString();
                    Email5 = dt.Rows[4][7].ToString();
                    Email6 = dt.Rows[5][7].ToString();
                    Email7 = dt.Rows[6][7].ToString();
                    //////////////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.CC.Add(new MailAddress(Email4));
                    message.CC.Add(new MailAddress(Email5));
                    message.CC.Add(new MailAddress(Email6));
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 8)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    Email4 = dt.Rows[3][7].ToString();
                    Email5 = dt.Rows[4][7].ToString();
                    Email6 = dt.Rows[5][7].ToString();
                    Email7 = dt.Rows[6][7].ToString();
                    Email8 = dt.Rows[7][7].ToString();
                    ///////////////////////////////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.CC.Add(new MailAddress(Email4));
                    message.CC.Add(new MailAddress(Email5));
                    message.CC.Add(new MailAddress(Email6));
                    message.CC.Add(new MailAddress(Email7));
                    message.CC.Add(new MailAddress(Email8));
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 9)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    Email4 = dt.Rows[3][7].ToString();
                    Email5 = dt.Rows[4][7].ToString();
                    Email6 = dt.Rows[5][7].ToString();
                    Email7 = dt.Rows[6][7].ToString();
                    Email8 = dt.Rows[7][7].ToString();
                    Email9 = dt.Rows[8][7].ToString();
                    ///////////////////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.CC.Add(new MailAddress(Email4));
                    message.CC.Add(new MailAddress(Email5));
                    message.CC.Add(new MailAddress(Email6));
                    message.CC.Add(new MailAddress(Email7));
                    message.CC.Add(new MailAddress(Email8));
                    message.CC.Add(new MailAddress(Email9));
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 10)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    Email4 = dt.Rows[3][7].ToString();
                    Email5 = dt.Rows[4][7].ToString();
                    Email6 = dt.Rows[5][7].ToString();
                    Email7 = dt.Rows[6][7].ToString();
                    Email8 = dt.Rows[7][7].ToString();
                    Email9 = dt.Rows[8][7].ToString();
                    Email10 = dt.Rows[9][7].ToString();
                    ////////////////////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.CC.Add(new MailAddress(Email4));
                    message.CC.Add(new MailAddress(Email5));
                    message.CC.Add(new MailAddress(Email6));
                    message.CC.Add(new MailAddress(Email7));
                    message.CC.Add(new MailAddress(Email8));
                    message.CC.Add(new MailAddress(Email9));
                    message.CC.Add(new MailAddress(Email10));
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);

                }
                else if (dt.Rows.Count > 10)
                {
                    MessageBox.Show("Numero de destinatarios maximo alcanzado por departamento contacte con soporte");
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
        ///Construccion e Instalaciones
        public void enviamasivo7(string Departamento)
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
                                                "where [Departamento]=@Departamento "

                                                , conexion);
                cmd.Parameters.AddWithValue("Departamento", "Construccion e Instalaciones");



                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.SelectCommand.CommandTimeout = 36000;
                DataTable dt = new DataTable();
                sda.Fill(dt);

                conexion.Dispose();

                if (dt.Rows.Count == 1)
                {
                    Email1 = dt.Rows[0][7].ToString();
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }

                else if (dt.Rows.Count == 2)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    ///////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.Subject = "Actualizacion de  Carpeta";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 3)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    /////////////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 4)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    Email4 = dt.Rows[3][7].ToString();
                    /////////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.CC.Add(new MailAddress(Email4));
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 5)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    Email4 = dt.Rows[3][7].ToString();
                    Email5 = dt.Rows[4][7].ToString();
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.CC.Add(new MailAddress(Email4));
                    message.CC.Add(new MailAddress(Email5));
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);

                }
                else if (dt.Rows.Count == 6)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    Email4 = dt.Rows[3][7].ToString();
                    Email5 = dt.Rows[4][7].ToString();
                    Email6 = dt.Rows[5][7].ToString();
                    /////////////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.CC.Add(new MailAddress(Email4));
                    message.CC.Add(new MailAddress(Email5));
                    message.CC.Add(new MailAddress(Email6));
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 7)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    Email4 = dt.Rows[3][7].ToString();
                    Email5 = dt.Rows[4][7].ToString();
                    Email6 = dt.Rows[5][7].ToString();
                    Email7 = dt.Rows[6][7].ToString();
                    //////////////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.CC.Add(new MailAddress(Email4));
                    message.CC.Add(new MailAddress(Email5));
                    message.CC.Add(new MailAddress(Email6));
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 8)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    Email4 = dt.Rows[3][7].ToString();
                    Email5 = dt.Rows[4][7].ToString();
                    Email6 = dt.Rows[5][7].ToString();
                    Email7 = dt.Rows[6][7].ToString();
                    Email8 = dt.Rows[7][7].ToString();
                    ///////////////////////////////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.CC.Add(new MailAddress(Email4));
                    message.CC.Add(new MailAddress(Email5));
                    message.CC.Add(new MailAddress(Email6));
                    message.CC.Add(new MailAddress(Email7));
                    message.CC.Add(new MailAddress(Email8));
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 9)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    Email4 = dt.Rows[3][7].ToString();
                    Email5 = dt.Rows[4][7].ToString();
                    Email6 = dt.Rows[5][7].ToString();
                    Email7 = dt.Rows[6][7].ToString();
                    Email8 = dt.Rows[7][7].ToString();
                    Email9 = dt.Rows[8][7].ToString();
                    ///////////////////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.CC.Add(new MailAddress(Email4));
                    message.CC.Add(new MailAddress(Email5));
                    message.CC.Add(new MailAddress(Email6));
                    message.CC.Add(new MailAddress(Email7));
                    message.CC.Add(new MailAddress(Email8));
                    message.CC.Add(new MailAddress(Email9));
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 10)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    Email4 = dt.Rows[3][7].ToString();
                    Email5 = dt.Rows[4][7].ToString();
                    Email6 = dt.Rows[5][7].ToString();
                    Email7 = dt.Rows[6][7].ToString();
                    Email8 = dt.Rows[7][7].ToString();
                    Email9 = dt.Rows[8][7].ToString();
                    Email10 = dt.Rows[9][7].ToString();
                    ////////////////////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.CC.Add(new MailAddress(Email4));
                    message.CC.Add(new MailAddress(Email5));
                    message.CC.Add(new MailAddress(Email6));
                    message.CC.Add(new MailAddress(Email7));
                    message.CC.Add(new MailAddress(Email8));
                    message.CC.Add(new MailAddress(Email9));
                    message.CC.Add(new MailAddress(Email10));
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);

                }
                else if (dt.Rows.Count > 10)
                {
                    MessageBox.Show("Numero de destinatarios maximo alcanzado por departamento contacte con soporte");
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
        ///Construccion e Instalaciones
        public void enviamasivo8(string Departamento)
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
                                                "where [Departamento]=@Departamento "

                                                , conexion);
                cmd.Parameters.AddWithValue("Departamento", "Operacion y Mantenimiento");



                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.SelectCommand.CommandTimeout = 36000;
                DataTable dt = new DataTable();
                sda.Fill(dt);

                conexion.Dispose();

                if (dt.Rows.Count == 1)
                {
                    Email1 = dt.Rows[0][7].ToString();
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }

                else if (dt.Rows.Count == 2)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    ///////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.Subject = "Actualizacion de  Carpeta";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 3)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    /////////////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 4)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    Email4 = dt.Rows[3][7].ToString();
                    /////////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.CC.Add(new MailAddress(Email4));
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 5)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    Email4 = dt.Rows[3][7].ToString();
                    Email5 = dt.Rows[4][7].ToString();
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.CC.Add(new MailAddress(Email4));
                    message.CC.Add(new MailAddress(Email5));
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);

                }
                else if (dt.Rows.Count == 6)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    Email4 = dt.Rows[3][7].ToString();
                    Email5 = dt.Rows[4][7].ToString();
                    Email6 = dt.Rows[5][7].ToString();
                    /////////////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.CC.Add(new MailAddress(Email4));
                    message.CC.Add(new MailAddress(Email5));
                    message.CC.Add(new MailAddress(Email6));
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 7)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    Email4 = dt.Rows[3][7].ToString();
                    Email5 = dt.Rows[4][7].ToString();
                    Email6 = dt.Rows[5][7].ToString();
                    Email7 = dt.Rows[6][7].ToString();
                    //////////////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.CC.Add(new MailAddress(Email4));
                    message.CC.Add(new MailAddress(Email5));
                    message.CC.Add(new MailAddress(Email6));
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 8)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    Email4 = dt.Rows[3][7].ToString();
                    Email5 = dt.Rows[4][7].ToString();
                    Email6 = dt.Rows[5][7].ToString();
                    Email7 = dt.Rows[6][7].ToString();
                    Email8 = dt.Rows[7][7].ToString();
                    ///////////////////////////////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.CC.Add(new MailAddress(Email4));
                    message.CC.Add(new MailAddress(Email5));
                    message.CC.Add(new MailAddress(Email6));
                    message.CC.Add(new MailAddress(Email7));
                    message.CC.Add(new MailAddress(Email8));
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 9)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    Email4 = dt.Rows[3][7].ToString();
                    Email5 = dt.Rows[4][7].ToString();
                    Email6 = dt.Rows[5][7].ToString();
                    Email7 = dt.Rows[6][7].ToString();
                    Email8 = dt.Rows[7][7].ToString();
                    Email9 = dt.Rows[8][7].ToString();
                    ///////////////////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.CC.Add(new MailAddress(Email4));
                    message.CC.Add(new MailAddress(Email5));
                    message.CC.Add(new MailAddress(Email6));
                    message.CC.Add(new MailAddress(Email7));
                    message.CC.Add(new MailAddress(Email8));
                    message.CC.Add(new MailAddress(Email9));
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 10)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    Email4 = dt.Rows[3][7].ToString();
                    Email5 = dt.Rows[4][7].ToString();
                    Email6 = dt.Rows[5][7].ToString();
                    Email7 = dt.Rows[6][7].ToString();
                    Email8 = dt.Rows[7][7].ToString();
                    Email9 = dt.Rows[8][7].ToString();
                    Email10 = dt.Rows[9][7].ToString();
                    ////////////////////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.CC.Add(new MailAddress(Email4));
                    message.CC.Add(new MailAddress(Email5));
                    message.CC.Add(new MailAddress(Email6));
                    message.CC.Add(new MailAddress(Email7));
                    message.CC.Add(new MailAddress(Email8));
                    message.CC.Add(new MailAddress(Email9));
                    message.CC.Add(new MailAddress(Email10));
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);

                }
                else if (dt.Rows.Count > 10)
                {
                    MessageBox.Show("Numero de destinatarios maximo alcanzado por departamento contacte con soporte");
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

        ///Construccion e Instalaciones
        public void enviamasivo9(string Departamento)
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
                                                "where [Departamento]=@Departamento "

                                                , conexion);
                cmd.Parameters.AddWithValue("Departamento", "Infraestructura");



                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.SelectCommand.CommandTimeout = 36000;
                DataTable dt = new DataTable();
                sda.Fill(dt);

                conexion.Dispose();

                if (dt.Rows.Count == 1)
                {
                    Email1 = dt.Rows[0][7].ToString();
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }

                else if (dt.Rows.Count == 2)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    ///////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.Subject = "Actualizacion de  Carpeta";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 3)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    /////////////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 4)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    Email4 = dt.Rows[3][7].ToString();
                    /////////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.CC.Add(new MailAddress(Email4));
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 5)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    Email4 = dt.Rows[3][7].ToString();
                    Email5 = dt.Rows[4][7].ToString();
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.CC.Add(new MailAddress(Email4));
                    message.CC.Add(new MailAddress(Email5));
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);

                }
                else if (dt.Rows.Count == 6)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    Email4 = dt.Rows[3][7].ToString();
                    Email5 = dt.Rows[4][7].ToString();
                    Email6 = dt.Rows[5][7].ToString();
                    /////////////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.CC.Add(new MailAddress(Email4));
                    message.CC.Add(new MailAddress(Email5));
                    message.CC.Add(new MailAddress(Email6));
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 7)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    Email4 = dt.Rows[3][7].ToString();
                    Email5 = dt.Rows[4][7].ToString();
                    Email6 = dt.Rows[5][7].ToString();
                    Email7 = dt.Rows[6][7].ToString();
                    //////////////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.CC.Add(new MailAddress(Email4));
                    message.CC.Add(new MailAddress(Email5));
                    message.CC.Add(new MailAddress(Email6));
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 8)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    Email4 = dt.Rows[3][7].ToString();
                    Email5 = dt.Rows[4][7].ToString();
                    Email6 = dt.Rows[5][7].ToString();
                    Email7 = dt.Rows[6][7].ToString();
                    Email8 = dt.Rows[7][7].ToString();
                    ///////////////////////////////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.CC.Add(new MailAddress(Email4));
                    message.CC.Add(new MailAddress(Email5));
                    message.CC.Add(new MailAddress(Email6));
                    message.CC.Add(new MailAddress(Email7));
                    message.CC.Add(new MailAddress(Email8));
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 9)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    Email4 = dt.Rows[3][7].ToString();
                    Email5 = dt.Rows[4][7].ToString();
                    Email6 = dt.Rows[5][7].ToString();
                    Email7 = dt.Rows[6][7].ToString();
                    Email8 = dt.Rows[7][7].ToString();
                    Email9 = dt.Rows[8][7].ToString();
                    ///////////////////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.CC.Add(new MailAddress(Email4));
                    message.CC.Add(new MailAddress(Email5));
                    message.CC.Add(new MailAddress(Email6));
                    message.CC.Add(new MailAddress(Email7));
                    message.CC.Add(new MailAddress(Email8));
                    message.CC.Add(new MailAddress(Email9));
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 10)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    Email4 = dt.Rows[3][7].ToString();
                    Email5 = dt.Rows[4][7].ToString();
                    Email6 = dt.Rows[5][7].ToString();
                    Email7 = dt.Rows[6][7].ToString();
                    Email8 = dt.Rows[7][7].ToString();
                    Email9 = dt.Rows[8][7].ToString();
                    Email10 = dt.Rows[9][7].ToString();
                    ////////////////////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.CC.Add(new MailAddress(Email4));
                    message.CC.Add(new MailAddress(Email5));
                    message.CC.Add(new MailAddress(Email6));
                    message.CC.Add(new MailAddress(Email7));
                    message.CC.Add(new MailAddress(Email8));
                    message.CC.Add(new MailAddress(Email9));
                    message.CC.Add(new MailAddress(Email10));
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);

                }
                else if (dt.Rows.Count > 10)
                {
                    MessageBox.Show("Numero de destinatarios maximo alcanzado por departamento contacte con soporte");
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
        ///Construccion e Instalaciones
        public void enviamasivo10(string Departamento)
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
                                                "where [Departamento]=@Departamento "

                                                , conexion);
                cmd.Parameters.AddWithValue("Departamento", "Administracion");



                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.SelectCommand.CommandTimeout = 36000;
                DataTable dt = new DataTable();
                sda.Fill(dt);

                conexion.Dispose();

                if (dt.Rows.Count == 1)
                {
                    Email1 = dt.Rows[0][7].ToString();
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }

                else if (dt.Rows.Count == 2)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    ///////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.Subject = "Actualizacion de  Carpeta";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 3)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    /////////////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 4)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    Email4 = dt.Rows[3][7].ToString();
                    /////////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.CC.Add(new MailAddress(Email4));
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 5)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    Email4 = dt.Rows[3][7].ToString();
                    Email5 = dt.Rows[4][7].ToString();
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.CC.Add(new MailAddress(Email4));
                    message.CC.Add(new MailAddress(Email5));
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);

                }
                else if (dt.Rows.Count == 6)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    Email4 = dt.Rows[3][7].ToString();
                    Email5 = dt.Rows[4][7].ToString();
                    Email6 = dt.Rows[5][7].ToString();
                    /////////////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.CC.Add(new MailAddress(Email4));
                    message.CC.Add(new MailAddress(Email5));
                    message.CC.Add(new MailAddress(Email6));
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 7)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    Email4 = dt.Rows[3][7].ToString();
                    Email5 = dt.Rows[4][7].ToString();
                    Email6 = dt.Rows[5][7].ToString();
                    Email7 = dt.Rows[6][7].ToString();
                    //////////////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.CC.Add(new MailAddress(Email4));
                    message.CC.Add(new MailAddress(Email5));
                    message.CC.Add(new MailAddress(Email6));
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 8)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    Email4 = dt.Rows[3][7].ToString();
                    Email5 = dt.Rows[4][7].ToString();
                    Email6 = dt.Rows[5][7].ToString();
                    Email7 = dt.Rows[6][7].ToString();
                    Email8 = dt.Rows[7][7].ToString();
                    ///////////////////////////////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.CC.Add(new MailAddress(Email4));
                    message.CC.Add(new MailAddress(Email5));
                    message.CC.Add(new MailAddress(Email6));
                    message.CC.Add(new MailAddress(Email7));
                    message.CC.Add(new MailAddress(Email8));
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 9)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    Email4 = dt.Rows[3][7].ToString();
                    Email5 = dt.Rows[4][7].ToString();
                    Email6 = dt.Rows[5][7].ToString();
                    Email7 = dt.Rows[6][7].ToString();
                    Email8 = dt.Rows[7][7].ToString();
                    Email9 = dt.Rows[8][7].ToString();
                    ///////////////////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.CC.Add(new MailAddress(Email4));
                    message.CC.Add(new MailAddress(Email5));
                    message.CC.Add(new MailAddress(Email6));
                    message.CC.Add(new MailAddress(Email7));
                    message.CC.Add(new MailAddress(Email8));
                    message.CC.Add(new MailAddress(Email9));
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 10)
                {
                    Email1 = dt.Rows[0][7].ToString();
                    Email2 = dt.Rows[1][7].ToString();
                    Email3 = dt.Rows[2][7].ToString();
                    Email4 = dt.Rows[3][7].ToString();
                    Email5 = dt.Rows[4][7].ToString();
                    Email6 = dt.Rows[5][7].ToString();
                    Email7 = dt.Rows[6][7].ToString();
                    Email8 = dt.Rows[7][7].ToString();
                    Email9 = dt.Rows[8][7].ToString();
                    Email10 = dt.Rows[9][7].ToString();
                    ////////////////////////////////////////////
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
                    MailMessage message = new MailMessage(_sender, Email1);
                    message.CC.Add(new MailAddress(Email2));
                    message.CC.Add(new MailAddress(Email3));
                    message.CC.Add(new MailAddress(Email4));
                    message.CC.Add(new MailAddress(Email5));
                    message.CC.Add(new MailAddress(Email6));
                    message.CC.Add(new MailAddress(Email7));
                    message.CC.Add(new MailAddress(Email8));
                    message.CC.Add(new MailAddress(Email9));
                    message.CC.Add(new MailAddress(Email10));
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);

                }
                else if (dt.Rows.Count > 10)
                {
                    MessageBox.Show("Numero de destinatarios maximo alcanzado por departamento contacte con soporte");
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

        private void Tipo_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (Tipo.Text == "Proyecto Industrial y Potabiliza")
            {
               
                tipopt = "E";
               



            }
            else if (Tipo.Text == "Proyecto Alto Flujo")
            {
               
                tipopt = "AF"; 
             
           

            }
            else if (Tipo.Text == "Proyecto Compacta")
            {
            
                tipopt = "C"; 
          

            

            }
            else if (Tipo.Text == "Proyectos INOX")
            {
              
                tipopt = "P"; 
          

          

            }
            else if (Tipo.Text == "")
            {
           

            }
        }

        private void Guardar_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            valor = comboBox1.Text;
          
            if (valor == "No")
            {
                fecha = DateTime.Today.ToString("ddMMyy");
                obtenienconsecutivore();
                label8.Visible = false;
                label3.Visible = true;
                label7.Visible = true;
                textBox1.Visible = true;
                NombreProyecto.Visible = true;
                comboBox3.Visible = false;
                consecutivo2 = consecutivo;
                capacidad = Int32.Parse(cap);
                consecutivo = consecutivo + "NR";

            }
            if (valor == "Si")
            {
                fecha = DateTime.Today.ToString("ddMMyy");

                obtenienconsecutivo();

                label8.Visible = true;
                comboBox3.Visible = true;
                label3.Visible = false;
                consecutivo2 = "0";
                NombreProyecto.Visible = false;
                capacidad = Int32.Parse(cap);


            }
            Folio.Text = consecutivo + "-" + norma.Text + "R" + cap + "-" + fecha;
            Proyecto.Text = comboBox3.Text;
        }

        private void Guardar_Click_1(object sender, EventArgs e)
        {
            if (Proyecto.Text.Trim() != "" && Folio.Text.Trim() != "-----" && Tipo.Text.Trim() != "")

            {
                if (Tipo.Text == "Proyecto Industrial y Potabiliza")
                {

                    DialogResult Resultado;
                    Resultado = MessageBox.Show("Está seguro que desea crear el proyecto " + NombreProyecto.Text, "Confirmación", MessageBoxButtons.YesNo);
                    if (NombreProyecto.Text.Trim() != "" || Folio.Text.Trim() != "" || Tipo.Text.Trim() != "")

                    {
                      

                        if (Resultado == DialogResult.Yes)
                        {

                            var path = @"G:\SGC-PROYECTOS-CBR\SGC\" + año + @"\Proyectos-Industrial-Potabiliza\" + Folio.Text + "-" + NombreProyecto.Text;

                            if (!System.IO.Directory.Exists(path))
                            {

                                System.IO.Directory.CreateDirectory(path);
                                string strCmdText;
                                strCmdText = "/C Robocopy G:\\SGC\\2020\\CodificadoresLideres-Indus-Pot\\" + "Lp1-Lobra1-Lins1" + " " + "\"" + "G:\\SGC-PROYECTOS-CBR\\SGC\\" + año + "\\Proyectos-Industrial-Potabiliza\\" + Folio.Text + "-" + NombreProyecto.Text + "\"" + " " + " /E /SEC";
                                Process cop = System.Diagnostics.Process.Start("CMD.exe", strCmdText);
                                cop.WaitForExit();
                                string strCmdText2;
                                strCmdText2 = "/C Robocopy G:\\SGC\\2020\\Indus-Pot" + " " + "\"" + "G:\\SGC-PROYECTOS-CBR\\SGC\\" + año + "\\Proyectos-Industrial-Potabiliza\\" + Folio.Text + "-" + NombreProyecto.Text + "\"" + " " + " /E /SEC";
                                Process cop2 = System.Diagnostics.Process.Start("CMD.exe", strCmdText2);
                                cop2.WaitForExit();
                                this.Hide();
                                enviamasivo1(Folio.Text);
                                enviamasivo2(Folio.Text);
                                enviamasivo3(Folio.Text);
                                enviamasivo4(Folio.Text);
                                enviamasivo5(Folio.Text);
                                enviamasivo6(Folio.Text);
                                enviamasivo7(Folio.Text);
                                enviamasivo8(Folio.Text);
                                enviamasivo9(Folio.Text);
                                enviamasivo10(Folio.Text);
                                MessageBox.Show("Proyecto creado correctamente");
                            }
                            else if (NombreProyecto.Text.Trim() == "" || Folio.Text.Trim() == "" || Tipo.Text.Trim() == "")
                            {
                                MessageBox.Show("Ya existe un proyecto con ese nombre ingrese otro nombre");
                            }



                        }
                        else if (Resultado == DialogResult.No)
                        {


                            MessageBox.Show("Operacion Cancelada");
                            this.Hide();
                            Close();
                        }
                    }
                    else { MessageBox.Show("No puede dejar campos vacios"); }
                }
                else if (Tipo.Text == "Proyecto Alto Flujo")
                {

                    DialogResult Resultado;
                    Resultado = MessageBox.Show("Está seguro que desea crear el proyecto " + NombreProyecto.Text, "Confirmación", MessageBoxButtons.YesNo);
                    if (NombreProyecto.Text.Trim() != "" || Folio.Text.Trim() != "" || Tipo.Text.Trim() != "")

                    {
                        if (Resultado == DialogResult.Yes)
                        {
                    
                            var path = @"G:\SGC-PROYECTOS-CBR\SGC\" + año + @"\Proyectos-Alto-Flujo\" + Folio.Text + "-" + NombreProyecto.Text;

                            if (!System.IO.Directory.Exists(path))
                            {

                                System.IO.Directory.CreateDirectory(path);
                                string strCmdText;
                                strCmdText = "/C Robocopy G:\\SGC\\2020\\CodificadoresLideres-Af-Comp\\" + "Lp1-Lobra1-Lins1" + " " + "\"" + "G:\\SGC-PROYECTOS-CBR\\SGC\\" + año + "\\Proyectos-Alto-Flujo\\" + Folio.Text + "-" + NombreProyecto.Text + "\"" + " " + " /E /SEC";
                                Process cop = System.Diagnostics.Process.Start("CMD.exe", strCmdText);
                                cop.WaitForExit();
                                string strCmdText2;
                                strCmdText2 = "/C Robocopy G:\\SGC\\2020\\Af-Comp" + " " + "\"" + "G:\\SGC-PROYECTOS-CBR\\SGC\\" + año + "\\Proyectos-Alto-Flujo\\" + Folio.Text + "-" + NombreProyecto.Text + "\"" + " " + " /E /SEC";
                                Process cop2 = System.Diagnostics.Process.Start("CMD.exe", strCmdText2);
                                cop2.WaitForExit();

                                this.Hide();
                                enviamasivo1(Folio.Text);
                                enviamasivo2(Folio.Text);
                                enviamasivo3(Folio.Text);
                                enviamasivo4(Folio.Text);
                                enviamasivo5(Folio.Text);
                                enviamasivo6(Folio.Text);
                                enviamasivo7(Folio.Text);
                                enviamasivo8(Folio.Text);
                                enviamasivo9(Folio.Text);
                                enviamasivo10(Folio.Text);
                                MessageBox.Show("Proyecto creado correctamente");
                            }
                            else if (NombreProyecto.Text.Trim() == "" || Folio.Text.Trim() == "" || Tipo.Text.Trim() == "")
                            {
                                MessageBox.Show("Ya existe un proyecto con ese nombre ingrese otro nombre");
                            }



                        }
                        else if (Resultado == DialogResult.No)
                        {


                            MessageBox.Show("Operacion Cancelada");
                            this.Hide();
                            Close();
                        }
                    }
                    else { MessageBox.Show("No puede dejar campos vacios"); }
                }
                else if (Tipo.Text == "Proyecto Compacta")
                {

                    DialogResult Resultado;
                    Resultado = MessageBox.Show("Está seguro que desea crear el proyecto " + NombreProyecto.Text, "Confirmación", MessageBoxButtons.YesNo);
                    if (NombreProyecto.Text.Trim() != "" || Folio.Text.Trim() != "" || Tipo.Text.Trim() != "")

                    {
                        if (Resultado == DialogResult.Yes)
                        {
                           
                            var path = @"G:\SGC-PROYECTOS-CBR\SGC\" + año + @"\Proyectos-Compacta\" + Folio.Text + "-" + NombreProyecto.Text;

                            if (!System.IO.Directory.Exists(path))
                            {
                                System.IO.Directory.CreateDirectory(path);
                                string strCmdText;
                                strCmdText = "/C Robocopy G:\\SGC\\2020\\CodificadoresLideres-Af-Comp\\" + "Lp1-Lobra1-Lins1" + " " + "\"" + "G:\\SGC-PROYECTOS-CBR\\SGC\\" + año + "\\Proyectos-Compacta\\" + Folio.Text + "-" + NombreProyecto.Text + "\"" + " " + " /E /SEC";
                                string strCmdText2;
                                strCmdText2 = "/C Robocopy G:\\SGC\\2020\\Af-Comp" + " " + "\"" + "G:\\SGC-PROYECTOS-CBR\\SGC\\" + año + "\\Proyectos-Compacta\\" + Folio.Text + "-" + NombreProyecto.Text + "\"" + " " + " /E /SEC";
                                Process cop = System.Diagnostics.Process.Start("CMD.exe", strCmdText);
                                cop.WaitForExit();
                                Process cop2 = System.Diagnostics.Process.Start("CMD.exe", strCmdText2);
                                cop2.WaitForExit();

                                this.Hide();
                                enviamasivo1(Folio.Text);
                                enviamasivo2(Folio.Text);
                                enviamasivo3(Folio.Text);
                                enviamasivo4(Folio.Text);
                                enviamasivo5(Folio.Text);
                                enviamasivo6(Folio.Text);
                                enviamasivo7(Folio.Text);
                                enviamasivo8(Folio.Text);
                                enviamasivo9(Folio.Text);
                                enviamasivo10(Folio.Text);
                                MessageBox.Show("Proyecto creado correctamente");
                            }
                            else
                            {
                                MessageBox.Show("Ya existe un proyecto con ese nombre ingrese otro nombre");
                            }



                        }
                        else if (Resultado == DialogResult.No)
                        {


                            MessageBox.Show("Operacion Cancelada");
                            this.Hide();
                            Close();
                        }
                    }
                    else { MessageBox.Show("No puede dejar campos vacios"); }
                }
                else if (Tipo.Text == "Proyectos INOX")
                {

                    DialogResult Resultado;
                    Resultado = MessageBox.Show("Está seguro que desea crear el proyecto " + NombreProyecto.Text, "Confirmación", MessageBoxButtons.YesNo);
                    if (NombreProyecto.Text.Trim() != "" || Folio.Text.Trim() != "" || Tipo.Text.Trim() != "")

                    {
                        if (Resultado == DialogResult.Yes)
                        {
                         
                            var path = @"G:\SGC-PROYECTOS-CBR\SGC\" + año + @"\Proyectos-Inox\" + Folio.Text + "-" + NombreProyecto.Text;

                            if (!System.IO.Directory.Exists(path))
                            {
                                System.IO.Directory.CreateDirectory(path);
                                string strCmdText;
                                strCmdText = "/C Robocopy G:\\SGC\\2020\\Proyecto-INOX " + " " + "\"" + "G:\\SGC-PROYECTOS-CBR\\SGC\\" + año + "\\Proyectos-Inox\\" + Folio.Text + "-" + NombreProyecto.Text + "\"" + " " + " /E /SEC";

                                System.Diagnostics.Process.Start("CMD.exe", strCmdText);
                                this.Hide();
                                enviamasivo1(Folio.Text);
                                enviamasivo2(Folio.Text);
                                enviamasivo3(Folio.Text);
                                enviamasivo4(Folio.Text);
                                enviamasivo5(Folio.Text);
                                enviamasivo6(Folio.Text);
                                enviamasivo7(Folio.Text);
                                enviamasivo8(Folio.Text);
                                enviamasivo9(Folio.Text);
                                enviamasivo10(Folio.Text);
                                MessageBox.Show("Proyecto creado correctamente");

                            }
                            else if (NombreProyecto.Text.Trim() == "" || Folio.Text.Trim() == "" || Tipo.Text.Trim() == "")
                            {
                                MessageBox.Show("Ya existe un proyecto con ese nombre ingrese otro nombre");
                            }



                        }
                        else if (Resultado == DialogResult.No)
                        {


                            MessageBox.Show("Operacion Cancelada");
                            this.Hide();
                            Close();
                        }
                    }
                    else { MessageBox.Show("No puede dejar campos vacios"); }
                }




                this.folio_RehabilitacionesTableAdapter.Inserta(consecutivo, consecutivo2, norma.Text, tipopt, capacidad, Fechaf, Folio.Text, Folio.Text + "-" + NombreProyecto.Text, año, Tipo.Text, NombreProyecto.Text);
            }
        
                                else { MessageBox.Show("No puede dejar campos vacios"); }

}

  

        private void NombreProyecto_TextChanged(object sender, EventArgs e)
        {
            Proyecto.Text = NombreProyecto.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Folio.Text = consecutivo + "-" + norma.Text + "R" + textBox1.Text + "-" + fecha;
        }

        SqlConnection conexion = new SqlConnection(ObtenerCadena());
        public void obtenienconsecutivo()
        {


            try
            {

                ////////////////////////////////////SE ABRE LA CONEXION/////////////////////////////////////////////////////////////////////////////////
                SqlConnection conexion = new SqlConnection(ObtenerCadena());

                conexion.Open();
                string nombre = comboBox3.Text;
                ////////////////////////////////////SE EJECUTA EL COMANDO HACIA LA VISTA Y SE HACE LA VALIDACION//////////////////////////////////////
                SqlCommand cmd = new SqlCommand(
                                                "select " +
                                                "[Consecutivo]," +
                                                "[Capacidad]" +


                                                "from [Folio_Proyectos] " +
                                             " Where [Nombre2]=@Nombre2"
                                     

                                                , conexion);

             cmd.Parameters.AddWithValue("Nombre2", nombre);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.SelectCommand.CommandTimeout = 36000;
                DataTable dt = new DataTable();
                sda.Fill(dt);



                conexion.Dispose();


                if (dt.Rows.Count > 0)
                {

                    //MessageBox.Show("Si tiene acceso a esta planta");
                    // this.Close();
                    int d = dt.Rows.Count - 1;


                    consecutivo = dt.Rows[d][0].ToString();
                    cap = dt.Rows[d][1].ToString();
                    consecutivo1 = Convert.ToInt32(consecutivo);
                    consecutivo1 = consecutivo1;
            

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
        public void obtenienconsecutivore()
        {


            try
            {

                ////////////////////////////////////SE ABRE LA CONEXION/////////////////////////////////////////////////////////////////////////////////
                SqlConnection conexion = new SqlConnection(ObtenerCadena());

                conexion.Open();

                ////////////////////////////////////SE EJECUTA EL COMANDO HACIA LA VISTA Y SE HACE LA VALIDACION//////////////////////////////////////
                SqlCommand cmd = new SqlCommand(
                                                "select " +
                                                "[Consecutivo-Fraccion] " +



                                                "from [Folio_Rehabilitaciones] " +
                                                "order by Consecutivo"

                                                , conexion);


                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.SelectCommand.CommandTimeout = 36000;
                DataTable dt = new DataTable();
                sda.Fill(dt);



                conexion.Dispose();


                if (dt.Rows.Count > 0)
                {

                    //MessageBox.Show("Si tiene acceso a esta planta");
                    // this.Close();
                    int d = dt.Rows.Count - 1;


                    consecutivo = dt.Rows[d][0].ToString();
                    cap = dt.Rows[d][1].ToString();
                    consecutivo1 = Convert.ToInt32(consecutivo);
                    consecutivo1 = consecutivo1;


                }
                ////////////////////////////////////SI EL USUARIO, CONTRASENA O PLANTA ESTA MAL//////////////////////////////////////////////////////////////////////////
                else
                {


                    MessageBox.Show("Valor nulo");
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
          
        
            valor = comboBox1.Text;
            if (valor == "No")
            {
                label7.Visible = true;
                textBox1.Visible = true;

                label8.Visible = false;
                label3.Visible = true;
                NombreProyecto.Visible = true;
                comboBox3.Visible = false;
                fecha = DateTime.Today.ToString("ddMMyy");
                obtenienconsecutivore();
                label8.Visible = false;
                label3.Visible = true;
                NombreProyecto.Visible = true;
                comboBox3.Visible = false;
                consecutivo2 = consecutivo+1;
        
                consecutivo = consecutivo+1 + "NR";
                Folio.Text = consecutivo + "-" + norma.Text + "R" + textBox1.Text + "-" + fecha;

            }
            if (valor == "Si")
            {
        

                label8.Visible = true;
                comboBox3.Visible = true;
                label3.Visible = false;
                NombreProyecto.Visible = false;
           
               
            }
        

        }
    }

   





}
