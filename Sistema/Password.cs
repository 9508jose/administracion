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

namespace CBR_ADMIN.Sistema
{
    public partial class Password : UserControl
    {
        private static Password _instance;
        public static Password Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Password();
                return _instance;
            }
        }
        public Password()
        {
            InitializeComponent();
        }
        public string Nombre, Apellido,Email1;

        private void Contraseña1_Click(object sender, EventArgs e)
        {
            Contraseña1.Text = "";
        }

        private void Contraseña2_Click(object sender, EventArgs e)
        {
            Contraseña2.Text = "";
        }

        private void Guardar_Click(object sender, EventArgs e)
        {
            if(Contraseña1.Text == Contraseña2.Text)
            {
                MessageBox.Show("Contraseña correcta");
                this.login_DepartamentosTableAdapter.ActualizaContrUsua(Contraseña2.Text, Nombre, Apellido);
                Envio_destinatario(Nombre, Apellido);
            }
            else
            {
                MessageBox.Show("Las contraseñas no coinciden intentenlo de nuevo");
            }
        }
        public static string ObtenerCadena()
        {
            return Settings.Default.CBR_IngenieriaConnectionString;/*Este codigo obtiene los datos de la cadena de conexion declarada en los settings de la aplicacion*/
        }
        SqlConnection conexion = new SqlConnection(ObtenerCadena());
        public void Envio_destinatario(string nombre, string apeliido)
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
                                                "where [Nombre]=@nombre " +
                                                "and [Apellido]=@apellido "
                                                , conexion);
                cmd.Parameters.AddWithValue("nombre", Nombre);
                cmd.Parameters.AddWithValue("apellido", Apellido);


                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.SelectCommand.CommandTimeout = 36000;
                DataTable dt = new DataTable();
                sda.Fill(dt);

                conexion.Dispose();

                if (dt.Rows.Count > 0)
                {
                    //MessageBox.Show("Si tiene acceso a esta planta");
                    // this.Close();

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
                    message.Subject = "Actualizacion de Contraseña";

                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));

                    client.Send(message);

                    DialogResult Resultado;

      



                }
                ////////////////////////////////////SI EL USUARIO, CONTRASENA O PLANTA ESTA MAL//////////////////////////////////////////////////////////////////////////
                else
                {
                    MessageBox.Show("Usuario sin registro");
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

        private AlternateView getEmbeddedImage(String filePath)
        {
            // below line was corrected to include the mediatype so it displays in all 
            // mail clients. previous solution only displays in Gmail the inline images 
            LinkedResource res = new LinkedResource(filePath, MediaTypeNames.Image.Jpeg);
            res.ContentId = Guid.NewGuid().ToString();
            String Body = "<DIV><H5>Su contraseña ha sido modificada exitosamente  </DIV></H>";
            Body += "<DIV>Si no ha sido usted notificar a soporte</DIV>";




            string htmlBody = "" + Body + "" + @"<img src='cid:" + res.ContentId + @"'/> ";
            AlternateView alternateView = AlternateView.CreateAlternateViewFromString(htmlBody,
             null, MediaTypeNames.Text.Html);
            alternateView.LinkedResources.Add(res);
            return alternateView;
        }
    }
}
