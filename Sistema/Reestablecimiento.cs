using CBR_ADMIN.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CBR_ADMIN.Sistema
{
    public partial class Reestablecimiento : Form
    {
        public Reestablecimiento()
        {
            InitializeComponent();
        }
        public static string ObtenerCadena()
        {
            return Settings.Default.CBR_IngenieriaConnectionString;/*Este codigo obtiene los datos de la cadena de conexion declarada en los settings de la aplicacion*/
        }
        SqlConnection conexion = new SqlConnection(ObtenerCadena());
        string ID,Reestablece;
        int Id;
        int Id1;
        private void button1_Click(object sender, EventArgs e)
        {
            ThreadStart proceso = new ThreadStart(MostrarCuadroInicio);
            Thread hilo = new Thread(proceso);

            hilo.Start(); hilo.Join(200);
            Reestablecer(email.Text);
            hilo.Abort();
            MessageBox.Show("Correo enviado revisar bandeja de entrada para obtener su codigo de verificacion");
        }
        private void MostrarCuadroInicio()
        {
            Loading Cargando = new Loading();
            Cargando.ShowDialog();

        }
        private AlternateView getEmbeddedImage(String filePath)
        {
            // below line was corrected to include the mediatype so it displays in all 
            // mail clients. previous solution only displays in Gmail the inline images 
            LinkedResource res = new LinkedResource(filePath, MediaTypeNames.Image.Jpeg);
            res.ContentId = Guid.NewGuid().ToString();
            String Body = "<DIV><H5>Restablecimiento de contraseña Cbr App</HEAD></DIV></H>";
            Body += "<DIV>Su codigo de verificacion es "+Reestablece+ "</DIV>"+"Si no reconoce esta accion contacte a soporte";
          


            string htmlBody = "" + Body + "" + @"<img src='cid:" + res.ContentId + @"'/> ";
            AlternateView alternateView = AlternateView.CreateAlternateViewFromString(htmlBody,
             null, MediaTypeNames.Text.Html);
            alternateView.LinkedResources.Add(res);
            return alternateView;
        }

        private AlternateView getEmbeddedImage2(String filePath)
        {
            // below line was corrected to include the mediatype so it displays in all 
            // mail clients. previous solution only displays in Gmail the inline images 
            LinkedResource res = new LinkedResource(filePath, MediaTypeNames.Image.Jpeg);
            res.ContentId = Guid.NewGuid().ToString();
            String Body = "<DIV><H5>Restablecimiento de contraseña Cbr App</HEAD></DIV></H>";
            Body += "<DIV>Su contraseña se ha reeestablecido</DIV>";



            string htmlBody = "" + Body + "" + @"<img src='cid:" + res.ContentId + @"'/> ";
            AlternateView alternateView = AlternateView.CreateAlternateViewFromString(htmlBody,
             null, MediaTypeNames.Text.Html);
            alternateView.LinkedResources.Add(res);
            return alternateView;
        }
        public void Reestablecer(string Email)
        {
            try
            {
                ////////////////////////////////////SE ABRE LA CONEXION/////////////////////////////////////////////////////////////////////////////////
                SqlConnection conexion = new SqlConnection(ObtenerCadena());
                conexion.Open();
                ////////////////////////////////////SE EJECUTA EL COMANDO HACIA LA VISTA Y SE HACE LA VALIDACION//////////////////////////////////////
                SqlCommand cmd = new SqlCommand(
                                                "select " +
                                                "[ID], " +
                                                "[Nombre], " +
                                                "[Apellido], " +
                                                "[Privilegios], " +
                                                "[Usuario], " +
                                                "[Contraseña], " +
                                                 "[Puesto], " +
                                                 "[Departamento], " +
                                                  "[Email] " +
                                                "from [Login_Departamentos] " +
                                                "where [Email]=@Email "
                                                , conexion);
                cmd.Parameters.AddWithValue("Email", Email);


                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.SelectCommand.CommandTimeout = 36000;
                DataTable dt = new DataTable();
                sda.Fill(dt);

                conexion.Dispose();

                if (dt.Rows.Count > 0)
                {
                    //MessageBox.Show("Si tiene acceso a esta planta");
                    // this.Close();
                    string fecha = DateTime.Now.ToString("hh:mm:ss");
                    ID = dt.Rows[0][0].ToString();
                     Id = Int32.Parse(ID);
                    Reestablece = ID + "Res-" + fecha;
                    //    this.login_RestablecimientoTableAdapter.Inserta(Id, Reestablece);
                    this.restablecimientoTableAdapter.Genera(Reestablece, Id);
                    ///////////////////////////////////////////////////////////////////////77
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
               
                    /////////////////////////////////////////////////////////////////////////////////////
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));

                    message.Subject = "Reestablecimiento de contraseña";


                    /////////////////////////////////////////////////////////////////////////////////////////////////








                    ///////////////////////////////////////////////////////////////////////////////////////
                    client.Send(message);

                }
                ////////////////////////////////////SI EL USUARIO, CONTRASENA O PLANTA ESTA MAL//////////////////////////////////////////////////////////////////////////
                else
                {
                    MessageBox.Show("No tiene acceso o el usuario o contraseña esta mal");
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true) {
                if (Password.PasswordChar == '*')
                {
                    Password.PasswordChar = '\0';
                }
                else {
                    Password.PasswordChar = '*';
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (llave.Text == "" || Password.Text == "") { MessageBox.Show("No se permite dejar espacio en blanco"); }
            else { 
                
                if(ID== null) {
                    ID = "0";
                    Reestablecer2(ID, llave.Text);
                }

                else { 
                Reestablecer2(ID, llave.Text);
                }

            }
            this.Hide();
            Login login = new Login();
            login.Show();


        }

        public void Reestablecer2(string Id,string llave)
        {
            try
            {
               
           
                ////////////////////////////////////SE ABRE LA CONEXION/////////////////////////////////////////////////////////////////////////////////
                SqlConnection conexion = new SqlConnection(ObtenerCadena());
                conexion.Open();
                ////////////////////////////////////SE EJECUTA EL COMANDO HACIA LA VISTA Y SE HACE LA VALIDACION//////////////////////////////////////
                SqlCommand cmd = new SqlCommand(
                                                "select " +
                                                "[ID], " +
                                                "[Llave]" +

                                                "from [Restablecimiento] " +
                                                "where [ID]=@ID and"+
                                                 " [Llave]=@llave"
                                                , conexion);
                cmd.Parameters.AddWithValue("ID", ID);
                cmd.Parameters.AddWithValue("Llave", llave);


                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.SelectCommand.CommandTimeout = 36000;
                DataTable dt = new DataTable();
                sda.Fill(dt);

                conexion.Dispose();

                if (dt.Rows.Count > 0)
                {
                    string Email1 = email.Text;
                     Id1 = Int32.Parse(Id);
                    this.login_DepartamentosTableAdapter.ActualizaPass(Password.Text,email.Text);
                    this.restablecimientoTableAdapter.elimina(Id1);
                
                    ///////////////////////////////////////////////////////////////////////77
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

                    /////////////////////////////////////////////////////////////////////////////////////
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));

                    message.Subject = "Reestablecimiento de contraseña";



                    ///////////////////////////////////////////////////////////////////////////////////////
                    client.Send(message);

                }
                ////////////////////////////////////SI EL USUARIO, CONTRASENA O PLANTA ESTA MAL//////////////////////////////////////////////////////////////////////////
                else
                {
                    MessageBox.Show("El codigo es incorrecto verique su codigo o contacte a soporte");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {

            }
            MessageBox.Show("Contraseña actualizada");
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Id1 = Int32.Parse(ID);

            this.restablecimientoTableAdapter.elimina(Id1);
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void Reestablecimiento_Load(object sender, EventArgs e)
        {
           
            // TODO: esta línea de código carga datos en la tabla 'cBR_Reestablece.Restablecimiento' Puede moverla o quitarla según sea necesario.
            this.restablecimientoTableAdapter.Fill(this.cBR_Reestablece.Restablecimiento);
            // TODO: esta línea de código carga datos en la tabla 'cBR_Restablece.Login_Restablecimiento' Puede moverla o quitarla según sea necesario.
            
            // TODO: esta línea de código carga datos en la tabla 'cBR_Login_Dep.Login_Departamentos' Puede moverla o quitarla según sea necesario.
            this.login_DepartamentosTableAdapter.Fill(this.cBR_Login_Dep.Login_Departamentos);

        }
    }
}
