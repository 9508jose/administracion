using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CBR_ADMIN.Properties;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading;
using CBR_ADMIN.Sistema;

namespace CBR_ADMIN.Administracion
{
    public partial class Seguimiento_AM : UserControl
    {
        public Seguimiento_AM()
        {
            InitializeComponent();
        }
        private static Seguimiento_AM _instance;
        public static Seguimiento_AM Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Seguimiento_AM();
                return _instance;
            }
        } int AMKey;
        public static string ObtenerCadena()
        {
            return Settings.Default.CBR_IngenieriaConnectionString;/*Este codigo obtiene los datos de la cadena de conexion declarada en los settings de la aplicacion*/
        }
        SqlConnection conexion = new SqlConnection(ObtenerCadena());

        public string Departamento, Nombre,Apellido, Ventana1,Email1, EmailAsis;

        private void MostrarCuadroInicio()
        {
            Loading Cargando = new Loading();
            Cargando.ShowDialog();

        }
        private void Guardar_Click(object sender, EventArgs e)
        {
            ThreadStart proceso = new ThreadStart(MostrarCuadroInicio);
            Thread hilo = new Thread(proceso);

           
            DialogResult Resultado;
            Resultado = MessageBox.Show("Está seguro que desea guardar los cambios ingresados", "Confirmación", MessageBoxButtons.YesNo);
            if (Resultado == DialogResult.Yes)
            {
                hilo.Start();     hilo.Join(200);
                DateTime Fechacompro = DateTime.Parse(Fechacompromiso.Text);
                DateTime Fechacierr = DateTime.Parse(Fecha_cierre.Text);
             
                int NA = Int32.Parse(CB_NA.Text);
                this.op_MejoraTableAdapter.Seguimiento(DescripcionAccionMejora.Text, Fechacompro, Fechacierr, Resultado_verificacion.Text,Contexto.Text,Planteamiento_Problema.Text,Analisis_Causa.Text,Condicion_Obj.Text,Estado_Ideal.Text,Seguimiento.Text, NA);
                Envio_destinatario(Nombre, Apellido);
                hilo.Abort();
                this.no_Accion_usuarioTableAdapter.Actualiza("Registrada",  NA);
                enviaAsis();
            }
            else if (Resultado == DialogResult.No)
            {

                MessageBox.Show("Operacion Cancelada"); hilo.Abort();
            }

 

        }



        //private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        //{
        //    try
        //    {
        //        if (e.RowIndex >= 0 && e.ColumnIndex > 0)
        //        {
        //            DescripcionAccionMejora.Text = "cambi";
        //        }
        //        else
        //        {

                    

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error: " + ex);
        //    }
        //}

        public void enviaAsis()
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
                                                "where [Departamento]=@Departamento"

                                                , conexion);
                cmd.Parameters.AddWithValue("Departamento", "Asistente de direccion");




                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.SelectCommand.CommandTimeout = 36000;
                DataTable dt = new DataTable();
                sda.Fill(dt);

                conexion.Dispose();

                if (dt.Rows.Count > 0)
                {
                    EmailAsis = dt.Rows[0][7].ToString();
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
                    MailMessage message = new MailMessage(_sender, EmailAsis);
                    message.Subject = "Levantamiento de nueva Accion de Mejora";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
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
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Seguimiento_AM_Load(object sender, EventArgs e)
        {
            this.login_DepartamentosTableAdapter.Fill(cBR_Login_Dep.Login_Departamentos);
            this.op_MejoraTableAdapter.NoOport(cBR_No_Oportunidad.Op_Mejora,Departamento);
           
         
        }

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
                    message.Subject = "Actualizacion de Accion de Mejora";

                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));

                    client.Send(message);

                    DialogResult Resultado;

                    Resultado = MessageBox.Show("Actualizacion generada correctamente");



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
            String Body = "<DIV><H5>Se te ha asignado como responsable para la accion de Mejora </DIV></H>";
            Body += "<DIV>Ingresa a tu perfil para darle seguimiento</DIV>";




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
            String Body = "<DIV><H5>Se ha actualizado una Accionde de Mejora para el departamento de:</HEAD></DIV></H>"+Departamento ;

            string htmlBody = "" + Body + "" + @"<img src='cid:" + res.ContentId + @"'/> ";
            AlternateView alternateView = AlternateView.CreateAlternateViewFromString(htmlBody,
             null, MediaTypeNames.Text.Html);
            alternateView.LinkedResources.Add(res);
            return alternateView;
        }
    }
}
