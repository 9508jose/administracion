using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CBR_ADMIN.Sistema;
using System.Threading;
using System.Net.Mail;
using System.Net.Mime;
using System.Data.SqlClient;
using CBR_ADMIN.Properties;

namespace CBR_ADMIN.Administracion
{

    public partial class Actualizacion_NC : UserControl
    {
        private static Actualizacion_NC _instance;
        public static Actualizacion_NC Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Actualizacion_NC();
                return _instance;
            }


        }
        public Actualizacion_NC()
        {
            InitializeComponent();
        }
        int UsuarioKey;
         String  dato;
        String Tipo, Status, FechaReporte, Persona_Reporta, Descripcion_NC, Descripcion_CR, FechaCompromiso, Responsables, Resultado, PersonaAC, CategoriaCausa, Analisis_causas;

        String Email_1, Email_2, Email_3, Email_4, Email_5, Email_6, Email_7, Email_8, Email_9, Email_10,body2;


        String Email_11, Email_12, Email_13, Email_14, Email_15, Email_16, Email_17, Email_18, Email_19, Email_20;

        private void DG_NC_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex > 0)
                {
                    UsuarioKey = Convert.ToInt32(DG_NC.Rows[e.RowIndex].Cells[0].FormattedValue.ToString());
                    dato = DG_NC.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValue.ToString();

                    MessageBox.Show("" + dato);
                    Tipo = DG_NC.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                    Status = DG_NC.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
                    FechaReporte = DG_NC.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
                    Persona_Reporta = DG_NC.Rows[e.RowIndex].Cells[4].FormattedValue.ToString();
                    Descripcion_NC = DG_NC.Rows[e.RowIndex].Cells[5].FormattedValue.ToString();
                    Descripcion_CR = DG_NC.Rows[e.RowIndex].Cells[6].FormattedValue.ToString();
                    FechaCompromiso = DG_NC.Rows[e.RowIndex].Cells[7].FormattedValue.ToString();
                    Responsables = DG_NC.Rows[e.RowIndex].Cells[8].FormattedValue.ToString();
                    Resultado = DG_NC.Rows[e.RowIndex].Cells[9].FormattedValue.ToString();
                    PersonaAC = DG_NC.Rows[e.RowIndex].Cells[10].FormattedValue.ToString();
                    CategoriaCausa = DG_NC.Rows[e.RowIndex].Cells[11].FormattedValue.ToString();
                    Analisis_causas = DG_NC.Rows[e.RowIndex].Cells[12].FormattedValue.ToString();
                    Rep_proceso = DG_NC.Rows[e.RowIndex].Cells[13].FormattedValue.ToString();
                    Proceso_origen = DG_NC.Rows[e.RowIndex].Cells[14].FormattedValue.ToString();
                    DescripcionAC = DG_NC.Rows[e.RowIndex].Cells[15].FormattedValue.ToString();
                    Doc_Modificar = DG_NC.Rows[e.RowIndex].Cells[16].FormattedValue.ToString();
                    FechaompromisoAC = DG_NC.Rows[e.RowIndex].Cells[17].FormattedValue.ToString();
                    FechaCierreAC2 = DG_NC.Rows[e.RowIndex].Cells[18].FormattedValue.ToString();
                    ResponsableAC = DG_NC.Rows[e.RowIndex].Cells[19].FormattedValue.ToString();
                    ResultadoAC = DG_NC.Rows[e.RowIndex].Cells[20].FormattedValue.ToString();
                    Fecha_Verifiacionq = DG_NC.Rows[e.RowIndex].Cells[21].FormattedValue.ToString();
                    Eliminacion_Causa = DG_NC.Rows[e.RowIndex].Cells[22].FormattedValue.ToString();
                    AC_Efica = DG_NC.Rows[e.RowIndex].Cells[23].FormattedValue.ToString();
                    Key.Text = UsuarioKey.ToString();
             
                }
                else
                {

                    UsuarioKey = 0;
                    Key.Text = UsuarioKey.ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }

        private void elimina_Click(object sender, EventArgs e)
        {
            DialogResult Resultado2;
            Resultado2 = MessageBox.Show("Está seguro que desea eliminar la no conformidad con numero  "+Key.Text, "Confirmación", MessageBoxButtons.YesNo);
            if (Resultado2 == DialogResult.Yes)
            {
                int ID = Int32.Parse(Key.Text);
                this.no_Conformidades_usuarioTableAdapter.ELiminaNoti(ID);
                this.no_ConformidadesTableAdapter.EliminaNCGeneral(ID);
                MessageBox.Show("Eliminación correcta");

            }
            else if (Resultado2 == DialogResult.No)
            {

                MessageBox.Show("Operacion Cancelada");
               
            }
        }

        private void DG_NC_RowPostPaint_1(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DG_NC[0, e.RowIndex].Style.BackColor = Color.Gray;
            DG_NC[1, e.RowIndex].Style.BackColor = Color.Gray;
            DG_NC[2, e.RowIndex].Style.BackColor = Color.Gray;
            DG_NC[3, e.RowIndex].Style.BackColor = Color.Gray;
            DG_NC[4, e.RowIndex].Style.BackColor = Color.Gray;
            DG_NC[5, e.RowIndex].Style.BackColor = Color.Gray;
            DG_NC[6, e.RowIndex].Style.BackColor = Color.SteelBlue;
            DG_NC[7, e.RowIndex].Style.BackColor = Color.SteelBlue;
            DG_NC[8, e.RowIndex].Style.BackColor = Color.SteelBlue;
            DG_NC[9, e.RowIndex].Style.BackColor = Color.SteelBlue;
            DG_NC[10, e.RowIndex].Style.BackColor = Color.LimeGreen;
            DG_NC[11, e.RowIndex].Style.BackColor = Color.LimeGreen;
            DG_NC[12, e.RowIndex].Style.BackColor = Color.LimeGreen;
            DG_NC[13, e.RowIndex].Style.BackColor = Color.LimeGreen;
            DG_NC[14, e.RowIndex].Style.BackColor = Color.LimeGreen;
            DG_NC[15, e.RowIndex].Style.BackColor = Color.LimeGreen;
            DG_NC[16, e.RowIndex].Style.BackColor = Color.Goldenrod;
            DG_NC[17, e.RowIndex].Style.BackColor = Color.Goldenrod;
            DG_NC[18, e.RowIndex].Style.BackColor = Color.Goldenrod;
            DG_NC[19, e.RowIndex].Style.BackColor = Color.Goldenrod;
            DG_NC[20, e.RowIndex].Style.BackColor = Color.Goldenrod;
            DG_NC[21, e.RowIndex].Style.BackColor = Color.Gold;
            DG_NC[22, e.RowIndex].Style.BackColor = Color.Gold;
            DG_NC[23, e.RowIndex].Style.BackColor = Color.Gold;
        }

        private void DG_NC_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult Resultado;
            Resultado = MessageBox.Show("Está seguro que desea enviar correo", "Confirmación", MessageBoxButtons.YesNo);
            if (Resultado == DialogResult.Yes)
            {
                Email_1 = destinario.Text;
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
                body2 = cuerpom.Text;
                MailMessage message = new MailMessage(_sender, Email_1);
                message.Subject = "Correo enviado atraves de CBR APP  "+""+asunto.Text;
                message.IsBodyHtml = true;
                message.AlternateViews.Add(getEmbeddedlmagen2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                client.Send(message);
                MessageBox.Show("Correo enviado");
            }
            else if (Resultado == DialogResult.No)
            {

                MessageBox.Show("Operacion Cancelada");


            }
          
        }

        String Email_21, Email_22, Email_23, Email_24, Email_25, Email_26, Email_27, Email_28, Email_29, Email_30;
        String Email_31, Email_32, Email_33, Email_34, Email_35, Email_36, Email_37, Email_38, Email_39, Email_40;
        public static string ObtenerCadena()
        {
            return Settings.Default.CBR_IngenieriaConnectionString;/*Este codigo obtiene los datos de la cadena de conexion declarada en los settings de la aplicacion*/
        }
        private void Notificacion_Click(object sender, EventArgs e)
        {


            DialogResult Resultado;
            Resultado = MessageBox.Show("Está seguro que desea enviar correo masivo ", "Confirmación", MessageBoxButtons.YesNo);
            if (Resultado == DialogResult.Yes)
            {
                enviamasivoNC();
                MessageBox.Show("Operacion Realizada correctamente");
            }
            else if (Resultado == DialogResult.No)
            {

                MessageBox.Show("Operacion Cancelada");

         
            }
         
        }
        private AlternateView getEmbeddedlmagen1(String filePath)
        {
            // below line was corrected to include the mediatype so it displays in all 
            // mail clients. previous solution only displays in Gmail the inline images 
            LinkedResource res = new LinkedResource(filePath, MediaTypeNames.Image.Jpeg);
            res.ContentId = Guid.NewGuid().ToString();
            String Body = "<DIV><H5>Cuentas aun con no conformidades abiertas</DIV></H>";
            Body += "<DIV>Ingrese a su perfil para darle seguimiento </DIV>";
            string htmlBody = "" + Body + "" + @"<img src='cid:" + res.ContentId + @"'/> ";
            AlternateView alternateView = AlternateView.CreateAlternateViewFromString(htmlBody,
             null, MediaTypeNames.Text.Html);
            alternateView.LinkedResources.Add(res);
            return alternateView;
        }

        private AlternateView getEmbeddedlmagen2(String filePath)
        {
            // below line was corrected to include the mediatype so it displays in all 
            // mail clients. previous solution only displays in Gmail the inline images 
            LinkedResource res = new LinkedResource(filePath, MediaTypeNames.Image.Jpeg);
            res.ContentId = Guid.NewGuid().ToString();
           
            string htmlBody =  body2 ;
            AlternateView alternateView = AlternateView.CreateAlternateViewFromString(htmlBody,
             null, MediaTypeNames.Text.Html);
            alternateView.LinkedResources.Add(res);
            return alternateView;
        }



        public void enviamasivoNC()
        {

            try
            {
                ////////////////////////////////////SE ABRE LA CONEXION/////////////////////////////////////////////////////////////////////////////////
                SqlConnection conexion = new SqlConnection(ObtenerCadena());
                conexion.Open();
                ////////////////////////////////////SE EJECUTA EL COMANDO HACIA LA VISTA Y SE HACE LA VALIDACION//////////////////////////////////////
                SqlCommand cmd = new SqlCommand(
                                                "select COUNT([Status]) AS Abierta,Email from [No_Conformidades_usuario] where" +
                                               " Status = 'Abierta'" +

                                                "group by Status, Email"

                                                , conexion);




                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.SelectCommand.CommandTimeout = 36000;
                DataTable dt = new DataTable();
                sda.Fill(dt);

                conexion.Dispose();


                if (dt.Rows.Count == 1)
                {
                    Email_1 = dt.Rows[0][1].ToString();
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
                    if (Email_1 == "") { Email_1 = "Support@cbr-ingenieria.com.mx"; } else { };
                    MailMessage message = new MailMessage(_sender, Email_1);
                    message.Subject = "Notificacion No conformidad";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedlmagen1("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }

                else if (dt.Rows.Count == 2)
                {
                    Email_1 = dt.Rows[0][1].ToString();
                    Email_2 = dt.Rows[1][1].ToString();
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
                    if (Email_1 == "") { Email_1 = "Support@cbr-ingenieria.com.mx"; } else { };
                    MailMessage message = new MailMessage(_sender, Email_1);
                    message.To.Add(Email_2);
                    message.Subject = "Notificacion No conformidad";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedlmagen1("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 3)
                {
                    Email_1 = dt.Rows[0][1].ToString();
                    Email_2 = dt.Rows[1][1].ToString();
                    Email_3 = dt.Rows[2][1].ToString();
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
                    if (Email_1 == "") { Email_1 = "Support@cbr-ingenieria.com.mx"; } else { };
                    MailMessage message = new MailMessage(_sender, Email_1);
                    message.To.Add(Email_2);
                    message.To.Add(Email_3);
                    message.Subject = "Notificacion No conformidad";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedlmagen1("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 4)
                {
                    Email_1 = dt.Rows[0][1].ToString();
                    Email_2 = dt.Rows[1][1].ToString();
                    Email_3 = dt.Rows[2][1].ToString();
                    Email_4 = dt.Rows[3][1].ToString();
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
                    if (Email_1 == "") { Email_1 = "Support@cbr-ingenieria.com.mx"; } else { };
                    MailMessage message = new MailMessage(_sender, Email_1);
                    message.To.Add(Email_2);
                    message.To.Add(Email_3);
                    message.To.Add(Email_4);

                    message.Subject = "Notificacion No conformidad";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedlmagen1("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 5)
                {
                    Email_1 = dt.Rows[0][1].ToString();
                    Email_2 = dt.Rows[1][1].ToString();
                    Email_3 = dt.Rows[2][1].ToString();
                    Email_4 = dt.Rows[3][1].ToString();
                    Email_5 = dt.Rows[4][1].ToString();
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
                    if (Email_1 == "") { Email_1 = "Support@cbr-ingenieria.com.mx"; } else { };
                    MailMessage message = new MailMessage(_sender, Email_1);
                    message.To.Add(Email_2);
                    message.To.Add(Email_3);
                    message.To.Add(Email_4);
                    message.To.Add(Email_5);

                    message.Subject = "Notificacion No conformidad";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedlmagen1("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);

                }
                else if (dt.Rows.Count == 6)
                {
                    Email_1 = dt.Rows[0][1].ToString();
                    Email_2 = dt.Rows[1][1].ToString();
                    Email_3 = dt.Rows[2][1].ToString();
                    Email_4 = dt.Rows[3][1].ToString();
                    Email_5 = dt.Rows[4][1].ToString();
                    Email_6 = dt.Rows[5][1].ToString();
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
                    if (Email_1 == "") { Email_1 = "Support@cbr-ingenieria.com.mx"; } else { };
                    MailMessage message = new MailMessage(_sender, Email_1);
                    message.To.Add(Email_2);
                    message.To.Add(Email_3);
                    message.To.Add(Email_4);
                    message.To.Add(Email_5);
                    message.To.Add(Email_6);
                    message.Subject = "Notificacion No conformidad";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedlmagen1("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 7)
                {
                    Email_1 = dt.Rows[0][1].ToString();
                    Email_2 = dt.Rows[1][1].ToString();
                    Email_3 = dt.Rows[2][1].ToString();
                    Email_4 = dt.Rows[3][1].ToString();
                    Email_5 = dt.Rows[4][1].ToString();
                    Email_6 = dt.Rows[5][1].ToString();
                    Email_7 = dt.Rows[6][1].ToString();
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
                    if (Email_1 == "") { Email_1 = "Support@cbr-ingenieria.com.mx"; } else { };
                    MailMessage message = new MailMessage(_sender, Email_1);
                    message.To.Add(Email_2);
                    message.To.Add(Email_3);
                    message.To.Add(Email_4);
                    message.To.Add(Email_5);
                    message.To.Add(Email_6);
                    message.To.Add(Email_7);
                    message.Subject = "Notificacion No conformidad";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedlmagen1("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 8)
                {
                    Email_1 = dt.Rows[0][1].ToString();
                    Email_2 = dt.Rows[1][1].ToString();
                    Email_3 = dt.Rows[2][1].ToString();
                    Email_4 = dt.Rows[3][1].ToString();
                    Email_5 = dt.Rows[4][1].ToString();
                    Email_6 = dt.Rows[5][1].ToString();
                    Email_7 = dt.Rows[6][1].ToString();
                    Email_8 = dt.Rows[7][1].ToString();
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
                    if (Email_1 == "") { Email_1 = "Support@cbr-ingenieria.com.mx"; } else { };
                    MailMessage message = new MailMessage(_sender, Email_1);
                    message.To.Add(Email_2);
                    message.To.Add(Email_3);
                    message.To.Add(Email_4);
                    message.To.Add(Email_5);
                    message.To.Add(Email_6);
                    message.To.Add(Email_7);
                    message.To.Add(Email_8);
                    message.Subject = "Notificacion No conformidad";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedlmagen1("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 9)
                {
                    Email_1 = dt.Rows[0][1].ToString();
                    Email_2 = dt.Rows[1][1].ToString();
                    Email_3 = dt.Rows[2][1].ToString();
                    Email_4 = dt.Rows[3][1].ToString();
                    Email_5 = dt.Rows[4][1].ToString();
                    Email_6 = dt.Rows[5][1].ToString();
                    Email_7 = dt.Rows[6][1].ToString();
                    Email_8 = dt.Rows[7][1].ToString();
                    Email_9 = dt.Rows[8][1].ToString();
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
                    if (Email_1 == "") { Email_1 = "Support@cbr-ingenieria.com.mx"; } else { };
                    MailMessage message = new MailMessage(_sender, Email_1);
                    message.To.Add(Email_2);
                    message.To.Add(Email_3);
                    message.To.Add(Email_4);
                    message.To.Add(Email_5);
                    message.To.Add(Email_6);
                    message.To.Add(Email_7);
                    message.To.Add(Email_8);
                    message.To.Add(Email_9);
                    message.Subject = "Notificacion No conformidad";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedlmagen1("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 10)
                {
                    Email_1 = dt.Rows[0][1].ToString();
                    Email_2 = dt.Rows[1][1].ToString();
                    Email_3 = dt.Rows[2][1].ToString();
                    Email_4 = dt.Rows[3][1].ToString();
                    Email_5 = dt.Rows[4][1].ToString();
                    Email_6 = dt.Rows[5][1].ToString();
                    Email_7 = dt.Rows[6][1].ToString();
                    Email_8 = dt.Rows[7][1].ToString();
                    Email_9 = dt.Rows[8][1].ToString();
                    Email_10 = dt.Rows[9][1].ToString();
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
                    if (Email_1 == "") { Email_1 = "Support@cbr-ingenieria.com.mx"; } else { };
                    MailMessage message = new MailMessage(_sender, Email_1);
                    message.To.Add(Email_2);
                    message.To.Add(Email_3);
                    message.To.Add(Email_4);
                    message.To.Add(Email_5);
                    message.To.Add(Email_6);
                    message.To.Add(Email_7);
                    message.To.Add(Email_8);
                    message.To.Add(Email_9);
                    message.To.Add(Email_10);
                    message.Subject = "Notificacion No conformidad";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedlmagen1("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);

                }
                else if (dt.Rows.Count == 11)
                {
                    Email_1 = dt.Rows[0][1].ToString();
                    Email_2 = dt.Rows[1][1].ToString();
                    Email_3 = dt.Rows[2][1].ToString();
                    Email_4 = dt.Rows[3][1].ToString();
                    Email_5 = dt.Rows[4][1].ToString();
                    Email_6 = dt.Rows[5][1].ToString();
                    Email_7 = dt.Rows[6][1].ToString();
                    Email_8 = dt.Rows[7][1].ToString();
                    Email_9 = dt.Rows[8][1].ToString();
                    Email_10 = dt.Rows[9][1].ToString();
                    Email_11 = dt.Rows[10][1].ToString();
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
                    if (Email_1 == "") { Email_1 = "Support@cbr-ingenieria.com.mx"; } else { };
                    MailMessage message = new MailMessage(_sender, Email_1);
                    message.To.Add(Email_2);
                    message.To.Add(Email_3);
                    message.To.Add(Email_4);
                    message.To.Add(Email_5);
                    message.To.Add(Email_6);
                    message.To.Add(Email_7);
                    message.To.Add(Email_8);
                    message.To.Add(Email_9);
                    message.To.Add(Email_10);
                    message.To.Add(Email_11);
                    message.Subject = "Notificacion No conformidad";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedlmagen1("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 12)
                {
                    Email_1 = dt.Rows[0][1].ToString();
                    Email_2 = dt.Rows[1][1].ToString();
                    Email_3 = dt.Rows[2][1].ToString();
                    Email_4 = dt.Rows[3][1].ToString();
                    Email_5 = dt.Rows[4][1].ToString();
                    Email_6 = dt.Rows[5][1].ToString();
                    Email_7 = dt.Rows[6][1].ToString();
                    Email_8 = dt.Rows[7][1].ToString();
                    Email_9 = dt.Rows[8][1].ToString();
                    Email_10 = dt.Rows[9][1].ToString();
                    Email_11 = dt.Rows[10][1].ToString();
                    Email_12 = dt.Rows[11][1].ToString();
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
                    if (Email_1 == "") { Email_1 = "Support@cbr-ingenieria.com.mx"; } else { };
                    MailMessage message = new MailMessage(_sender, Email_1);
                    message.To.Add(Email_2);
                    message.To.Add(Email_3);
                    message.To.Add(Email_4);
                    message.To.Add(Email_5);
                    message.To.Add(Email_6);
                    message.To.Add(Email_7);
                    message.To.Add(Email_8);
                    message.To.Add(Email_9);
                    message.To.Add(Email_10);
                    message.To.Add(Email_11);
                    message.To.Add(Email_12);
                    message.Subject = "Notificacion No conformidad";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedlmagen1("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 13)
                {
                    Email_1 = dt.Rows[0][1].ToString();
                    Email_2 = dt.Rows[1][1].ToString();
                    Email_3 = dt.Rows[2][1].ToString();
                    Email_4 = dt.Rows[3][1].ToString();
                    Email_5 = dt.Rows[4][1].ToString();
                    Email_6 = dt.Rows[5][1].ToString();
                    Email_7 = dt.Rows[6][1].ToString();
                    Email_8 = dt.Rows[7][1].ToString();
                    Email_9 = dt.Rows[8][1].ToString();
                    Email_10 = dt.Rows[9][1].ToString();
                    Email_11 = dt.Rows[10][1].ToString();
                    Email_12 = dt.Rows[11][1].ToString();
                    Email_13 = dt.Rows[12][1].ToString();
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
                    if (Email_1 == "") { Email_1 = "Support@cbr-ingenieria.com.mx"; } else { };
                    MailMessage message = new MailMessage(_sender, Email_1);
                    message.To.Add(Email_2);
                    message.To.Add(Email_3);
                    message.To.Add(Email_4);
                    message.To.Add(Email_5);
                    message.To.Add(Email_6);
                    message.To.Add(Email_7);
                    message.To.Add(Email_8);
                    message.To.Add(Email_9);
                    message.To.Add(Email_10);
                    message.To.Add(Email_11);
                    message.To.Add(Email_12);
                    message.To.Add(Email_13);
                    message.Subject = "Notificacion No conformidad";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedlmagen1("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 14)
                {
                    Email_1 = dt.Rows[0][1].ToString();
                    Email_2 = dt.Rows[1][1].ToString();
                    Email_3 = dt.Rows[2][1].ToString();
                    Email_4 = dt.Rows[3][1].ToString();
                    Email_5 = dt.Rows[4][1].ToString();
                    Email_6 = dt.Rows[5][1].ToString();
                    Email_7 = dt.Rows[6][1].ToString();
                    Email_8 = dt.Rows[7][1].ToString();
                    Email_9 = dt.Rows[8][1].ToString();
                    Email_10 = dt.Rows[9][1].ToString();
                    Email_11 = dt.Rows[10][1].ToString();
                    Email_12 = dt.Rows[11][1].ToString();
                    Email_13 = dt.Rows[12][1].ToString();
                    Email_14 = dt.Rows[13][1].ToString();
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
                    if (Email_1 == "") { Email_1 = "Support@cbr-ingenieria.com.mx"; } else { };
                    MailMessage message = new MailMessage(_sender, Email_1);
                    message.To.Add(Email_2);
                    message.To.Add(Email_3);
                    message.To.Add(Email_4);
                    message.To.Add(Email_5);
                    message.To.Add(Email_6);
                    message.To.Add(Email_7);
                    message.To.Add(Email_8);
                    message.To.Add(Email_9);
                    message.To.Add(Email_10);
                    message.To.Add(Email_11);
                    message.To.Add(Email_12);
                    message.To.Add(Email_13);
                    message.To.Add(Email_14);
                    message.Subject = "Notificacion No conformidad";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedlmagen1("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 15)
                {
                    Email_1 = dt.Rows[0][1].ToString();
                    Email_2 = dt.Rows[1][1].ToString();
                    Email_3 = dt.Rows[2][1].ToString();
                    Email_4 = dt.Rows[3][1].ToString();
                    Email_5 = dt.Rows[4][1].ToString();
                    Email_6 = dt.Rows[5][1].ToString();
                    Email_7 = dt.Rows[6][1].ToString();
                    Email_8 = dt.Rows[7][1].ToString();
                    Email_9 = dt.Rows[8][1].ToString();
                    Email_10 = dt.Rows[9][1].ToString();
                    Email_11 = dt.Rows[10][1].ToString();
                    Email_12 = dt.Rows[11][1].ToString();
                    Email_13 = dt.Rows[12][1].ToString();
                    Email_14 = dt.Rows[13][1].ToString();
                    Email_15 = dt.Rows[14][1].ToString();
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
                    if (Email_1 == "") { Email_1 = "Support@cbr-ingenieria.com.mx"; } else { };
                    MailMessage message = new MailMessage(_sender, Email_1);
                    message.To.Add(Email_2);
                    message.To.Add(Email_3);
                    message.To.Add(Email_4);
                    message.To.Add(Email_5);
                    message.To.Add(Email_6);
                    message.To.Add(Email_7);
                    message.To.Add(Email_8);
                    message.To.Add(Email_9);
                    message.To.Add(Email_10);
                    message.To.Add(Email_11);
                    message.To.Add(Email_12);
                    message.To.Add(Email_13);
                    message.To.Add(Email_14);
                    message.To.Add(Email_15);
                    message.Subject = "Notificacion No conformidad";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedlmagen1("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);

                }
                else if (dt.Rows.Count == 16)
                {
                    Email_1 = dt.Rows[0][1].ToString();
                    Email_2 = dt.Rows[1][1].ToString();
                    Email_3 = dt.Rows[2][1].ToString();
                    Email_4 = dt.Rows[3][1].ToString();
                    Email_5 = dt.Rows[4][1].ToString();
                    Email_6 = dt.Rows[5][1].ToString();
                    Email_7 = dt.Rows[6][1].ToString();
                    Email_8 = dt.Rows[7][1].ToString();
                    Email_9 = dt.Rows[8][1].ToString();
                    Email_10 = dt.Rows[9][1].ToString();
                    Email_11 = dt.Rows[10][1].ToString();
                    Email_12 = dt.Rows[11][1].ToString();
                    Email_13 = dt.Rows[12][1].ToString();
                    Email_14 = dt.Rows[13][1].ToString();
                    Email_15 = dt.Rows[14][1].ToString();
                    Email_16 = dt.Rows[15][1].ToString();
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
                    if (Email_1 == "") { Email_1 = "Support@cbr-ingenieria.com.mx"; } else { };
                    MailMessage message = new MailMessage(_sender, Email_1);
                    message.To.Add(Email_2);
                    message.To.Add(Email_3);
                    message.To.Add(Email_4);
                    message.To.Add(Email_5);
                    message.To.Add(Email_6);
                    message.To.Add(Email_7);
                    message.To.Add(Email_8);
                    message.To.Add(Email_9);
                    message.To.Add(Email_10);
                    message.To.Add(Email_11);
                    message.To.Add(Email_12);
                    message.To.Add(Email_13);
                    message.To.Add(Email_14);
                    message.To.Add(Email_15);
                    message.To.Add(Email_16);
                    message.Subject = "Notificacion No conformidad";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedlmagen1("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 17)
                {
                    Email_1 = dt.Rows[0][1].ToString();
                    Email_2 = dt.Rows[1][1].ToString();
                    Email_3 = dt.Rows[2][1].ToString();
                    Email_4 = dt.Rows[3][1].ToString();
                    Email_5 = dt.Rows[4][1].ToString();
                    Email_6 = dt.Rows[5][1].ToString();
                    Email_7 = dt.Rows[6][1].ToString();
                    Email_8 = dt.Rows[7][1].ToString();
                    Email_9 = dt.Rows[8][1].ToString();
                    Email_10 = dt.Rows[9][1].ToString();
                    Email_11 = dt.Rows[10][1].ToString();
                    Email_12 = dt.Rows[11][1].ToString();
                    Email_13 = dt.Rows[12][1].ToString();
                    Email_14 = dt.Rows[13][1].ToString();
                    Email_15 = dt.Rows[14][1].ToString();
                    Email_16 = dt.Rows[15][1].ToString();
                    Email_17 = dt.Rows[16][1].ToString();
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
                    if (Email_1 == "") { Email_1 = "Support@cbr-ingenieria.com.mx"; } else { };
                    MailMessage message = new MailMessage(_sender, Email_1);
                    message.To.Add(Email_2);
                    message.To.Add(Email_3);
                    message.To.Add(Email_4);
                    message.To.Add(Email_5);
                    message.To.Add(Email_6);
                    message.To.Add(Email_7);
                    message.To.Add(Email_8);
                    message.To.Add(Email_9);
                    message.To.Add(Email_10);
                    message.To.Add(Email_11);
                    message.To.Add(Email_12);
                    message.To.Add(Email_13);
                    message.To.Add(Email_14);
                    message.To.Add(Email_15);
                    message.To.Add(Email_16);
                    message.To.Add(Email_17);
                    message.Subject = "Notificacion No conformidad";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedlmagen1("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 18)
                {
                    Email_1 = dt.Rows[0][1].ToString();
                    Email_2 = dt.Rows[1][1].ToString();
                    Email_3 = dt.Rows[2][1].ToString();
                    Email_4 = dt.Rows[3][1].ToString();
                    Email_5 = dt.Rows[4][1].ToString();
                    Email_6 = dt.Rows[5][1].ToString();
                    Email_7 = dt.Rows[6][1].ToString();
                    Email_8 = dt.Rows[7][1].ToString();
                    Email_9 = dt.Rows[8][1].ToString();
                    Email_10 = dt.Rows[9][1].ToString();
                    Email_11 = dt.Rows[10][1].ToString();
                    Email_12 = dt.Rows[11][1].ToString();
                    Email_13 = dt.Rows[12][1].ToString();
                    Email_14 = dt.Rows[13][1].ToString();
                    Email_15 = dt.Rows[14][1].ToString();
                    Email_16 = dt.Rows[15][1].ToString();
                    Email_17 = dt.Rows[16][1].ToString();
                    Email_18 = dt.Rows[17][1].ToString();
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
                    if (Email_1 == "") { Email_1 = "Support@cbr-ingenieria.com.mx"; } else { };
                    MailMessage message = new MailMessage(_sender, Email_1);
                    message.To.Add(Email_2);
                    message.To.Add(Email_3);
                    message.To.Add(Email_4);
                    message.To.Add(Email_5);
                    message.To.Add(Email_6);
                    message.To.Add(Email_7);
                    message.To.Add(Email_8);
                    message.To.Add(Email_9);
                    message.To.Add(Email_10);
                    message.To.Add(Email_11);
                    message.To.Add(Email_12);
                    message.To.Add(Email_13);
                    message.To.Add(Email_14);
                    message.To.Add(Email_15);
                    message.To.Add(Email_16);
                    message.To.Add(Email_17);
                    message.To.Add(Email_18);
                    message.Subject = "Notificacion No conformidad";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedlmagen1("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 19)
                {
                    Email_1 = dt.Rows[0][1].ToString();
                    Email_2 = dt.Rows[1][1].ToString();
                    Email_3 = dt.Rows[2][1].ToString();
                    Email_4 = dt.Rows[3][1].ToString();
                    Email_5 = dt.Rows[4][1].ToString();
                    Email_6 = dt.Rows[5][1].ToString();
                    Email_7 = dt.Rows[6][1].ToString();
                    Email_8 = dt.Rows[7][1].ToString();
                    Email_9 = dt.Rows[8][1].ToString();
                    Email_10 = dt.Rows[9][1].ToString();
                    Email_11 = dt.Rows[10][1].ToString();
                    Email_12 = dt.Rows[11][1].ToString();
                    Email_13 = dt.Rows[12][1].ToString();
                    Email_14 = dt.Rows[13][1].ToString();
                    Email_15 = dt.Rows[14][1].ToString();
                    Email_16 = dt.Rows[15][1].ToString();
                    Email_17 = dt.Rows[16][1].ToString();
                    Email_18 = dt.Rows[17][1].ToString();
                    Email_19 = dt.Rows[18][1].ToString();
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
                    if (Email_1 == "") { Email_1 = "Support@cbr-ingenieria.com.mx"; } else { };
                    MailMessage message = new MailMessage(_sender, Email_1);
                    message.To.Add(Email_2);
                    message.To.Add(Email_3);
                    message.To.Add(Email_4);
                    message.To.Add(Email_5);
                    message.To.Add(Email_6);
                    message.To.Add(Email_7);
                    message.To.Add(Email_8);
                    message.To.Add(Email_9);
                    message.To.Add(Email_10);
                    message.To.Add(Email_11);
                    message.To.Add(Email_12);
                    message.To.Add(Email_13);
                    message.To.Add(Email_14);
                    message.To.Add(Email_15);
                    message.To.Add(Email_16);
                    message.To.Add(Email_17);
                    message.To.Add(Email_18);
                    message.To.Add(Email_19);
                    message.Subject = "Notificacion No conformidad";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedlmagen1("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 20)
                {
                    Email_1 = dt.Rows[0][1].ToString();
                    Email_2 = dt.Rows[1][1].ToString();
                    Email_3 = dt.Rows[2][1].ToString();
                    Email_4 = dt.Rows[3][1].ToString();
                    Email_5 = dt.Rows[4][1].ToString();
                    Email_6 = dt.Rows[5][1].ToString();
                    Email_7 = dt.Rows[6][1].ToString();
                    Email_8 = dt.Rows[7][1].ToString();
                    Email_9 = dt.Rows[8][1].ToString();
                    Email_10 = dt.Rows[9][1].ToString();
                    Email_11 = dt.Rows[10][1].ToString();
                    Email_12 = dt.Rows[11][1].ToString();
                    Email_13 = dt.Rows[12][1].ToString();
                    Email_14 = dt.Rows[13][1].ToString();
                    Email_15 = dt.Rows[14][1].ToString();
                    Email_16 = dt.Rows[15][1].ToString();
                    Email_17 = dt.Rows[16][1].ToString();
                    Email_18 = dt.Rows[17][1].ToString();
                    Email_19 = dt.Rows[18][1].ToString();
                    Email_20 = dt.Rows[19][1].ToString();
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
                    if (Email_1 == "") { Email_1 = "Support@cbr-ingenieria.com.mx"; } else { };
                    MailMessage message = new MailMessage(_sender, Email_1);
                    message.To.Add(Email_2);
                    message.To.Add(Email_3);
                    message.To.Add(Email_4);
                    message.To.Add(Email_5);
                    message.To.Add(Email_6);
                    message.To.Add(Email_7);
                    message.To.Add(Email_8);
                    message.To.Add(Email_9);
                    message.To.Add(Email_10);
                    message.To.Add(Email_11);
                    message.To.Add(Email_12);
                    message.To.Add(Email_13);
                    message.To.Add(Email_14);
                    message.To.Add(Email_15);
                    message.To.Add(Email_16);
                    message.To.Add(Email_17);
                    message.To.Add(Email_18);
                    message.To.Add(Email_19);
                    message.To.Add(Email_20);
                    message.Subject = "Notificacion No conformidad";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedlmagen1("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);

                }
                else if (dt.Rows.Count == 21)
                {
                    Email_1 = dt.Rows[0][1].ToString();
                    Email_2 = dt.Rows[1][1].ToString();
                    Email_3 = dt.Rows[2][1].ToString();
                    Email_4 = dt.Rows[3][1].ToString();
                    Email_5 = dt.Rows[4][1].ToString();
                    Email_6 = dt.Rows[5][1].ToString();
                    Email_7 = dt.Rows[6][1].ToString();
                    Email_8 = dt.Rows[7][1].ToString();
                    Email_9 = dt.Rows[8][1].ToString();
                    Email_10 = dt.Rows[9][1].ToString();
                    Email_11 = dt.Rows[10][1].ToString();
                    Email_12 = dt.Rows[11][1].ToString();
                    Email_13 = dt.Rows[12][1].ToString();
                    Email_14 = dt.Rows[13][1].ToString();
                    Email_15 = dt.Rows[14][1].ToString();
                    Email_16 = dt.Rows[15][1].ToString();
                    Email_17 = dt.Rows[16][1].ToString();
                    Email_18 = dt.Rows[17][1].ToString();
                    Email_19 = dt.Rows[18][1].ToString();
                    Email_20 = dt.Rows[19][1].ToString();
                    Email_21 = dt.Rows[20][1].ToString();
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
                    if (Email_1 == "") { Email_1 = "Support@cbr-ingenieria.com.mx"; } else { };
                    MailMessage message = new MailMessage(_sender, Email_1);
                    message.To.Add(Email_2);
                    message.To.Add(Email_3);
                    message.To.Add(Email_4);
                    message.To.Add(Email_5);
                    message.To.Add(Email_6);
                    message.To.Add(Email_7);
                    message.To.Add(Email_8);
                    message.To.Add(Email_9);
                    message.To.Add(Email_10);
                    message.To.Add(Email_11);
                    message.To.Add(Email_12);
                    message.To.Add(Email_13);
                    message.To.Add(Email_14);
                    message.To.Add(Email_15);
                    message.To.Add(Email_16);
                    message.To.Add(Email_17);
                    message.To.Add(Email_18);
                    message.To.Add(Email_19);
                    message.To.Add(Email_20);
                    message.To.Add(Email_21);
                    message.Subject = "Notificacion No conformidad";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedlmagen1("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 22)
                {
                    Email_1 = dt.Rows[0][1].ToString();
                    Email_2 = dt.Rows[1][1].ToString();
                    Email_3 = dt.Rows[2][1].ToString();
                    Email_4 = dt.Rows[3][1].ToString();
                    Email_5 = dt.Rows[4][1].ToString();
                    Email_6 = dt.Rows[5][1].ToString();
                    Email_7 = dt.Rows[6][1].ToString();
                    Email_8 = dt.Rows[7][1].ToString();
                    Email_9 = dt.Rows[8][1].ToString();
                    Email_10 = dt.Rows[9][1].ToString();
                    Email_11 = dt.Rows[10][1].ToString();
                    Email_12 = dt.Rows[11][1].ToString();
                    Email_13 = dt.Rows[12][1].ToString();
                    Email_14 = dt.Rows[13][1].ToString();
                    Email_15 = dt.Rows[14][1].ToString();
                    Email_16 = dt.Rows[15][1].ToString();
                    Email_17 = dt.Rows[16][1].ToString();
                    Email_18 = dt.Rows[17][1].ToString();
                    Email_19 = dt.Rows[18][1].ToString();
                    Email_20 = dt.Rows[19][1].ToString();
                    Email_21 = dt.Rows[20][1].ToString();
                    Email_22 = dt.Rows[21][1].ToString();
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
                    if (Email_1 == "") { Email_1 = "Support@cbr-ingenieria.com.mx"; } else { };
                    MailMessage message = new MailMessage(_sender, Email_1);
                    message.To.Add(Email_2);
                    message.To.Add(Email_3);
                    message.To.Add(Email_4);
                    message.To.Add(Email_5);
                    message.To.Add(Email_6);
                    message.To.Add(Email_7);
                    message.To.Add(Email_8);
                    message.To.Add(Email_9);
                    message.To.Add(Email_10);
                    message.To.Add(Email_11);
                    message.To.Add(Email_12);
                    message.To.Add(Email_13);
                    message.To.Add(Email_14);
                    message.To.Add(Email_15);
                    message.To.Add(Email_16);
                    message.To.Add(Email_17);
                    message.To.Add(Email_18);
                    message.To.Add(Email_19);
                    message.To.Add(Email_20);
                    message.To.Add(Email_21);
                    message.To.Add(Email_22);
                    message.Subject = "Notificacion No conformidad";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedlmagen1("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 23)
                {
                    Email_1 = dt.Rows[0][1].ToString();
                    Email_2 = dt.Rows[1][1].ToString();
                    Email_3 = dt.Rows[2][1].ToString();
                    Email_4 = dt.Rows[3][1].ToString();
                    Email_5 = dt.Rows[4][1].ToString();
                    Email_6 = dt.Rows[5][1].ToString();
                    Email_7 = dt.Rows[6][1].ToString();
                    Email_8 = dt.Rows[7][1].ToString();
                    Email_9 = dt.Rows[8][1].ToString();
                    Email_10 = dt.Rows[9][1].ToString();
                    Email_11 = dt.Rows[10][1].ToString();
                    Email_12 = dt.Rows[11][1].ToString();
                    Email_13 = dt.Rows[12][1].ToString();
                    Email_14 = dt.Rows[13][1].ToString();
                    Email_15 = dt.Rows[14][1].ToString();
                    Email_16 = dt.Rows[15][1].ToString();
                    Email_17 = dt.Rows[16][1].ToString();
                    Email_18 = dt.Rows[17][1].ToString();
                    Email_19 = dt.Rows[18][1].ToString();
                    Email_20 = dt.Rows[19][1].ToString();
                    Email_21 = dt.Rows[20][1].ToString();
                    Email_22 = dt.Rows[21][1].ToString();
                    Email_23 = dt.Rows[22][1].ToString();
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
                    if (Email_1 == "") { Email_1 = "Support@cbr-ingenieria.com.mx"; } else { };
                    MailMessage message = new MailMessage(_sender, Email_1);
                    message.To.Add(Email_2);
                    message.To.Add(Email_3);
                    message.To.Add(Email_4);
                    message.To.Add(Email_5);
                    message.To.Add(Email_6);
                    message.To.Add(Email_7);
                    message.To.Add(Email_8);
                    message.To.Add(Email_9);
                    message.To.Add(Email_10);
                    message.To.Add(Email_11);
                    message.To.Add(Email_12);
                    message.To.Add(Email_13);
                    message.To.Add(Email_14);
                    message.To.Add(Email_15);
                    message.To.Add(Email_16);
                    message.To.Add(Email_17);
                    message.To.Add(Email_18);
                    message.To.Add(Email_19);
                    message.To.Add(Email_20);
                    message.To.Add(Email_21);
                    message.To.Add(Email_22);
                    message.To.Add(Email_23);
                    message.Subject = "Notificacion No conformidad";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedlmagen1("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 24)
                {
                    Email_1 = dt.Rows[0][1].ToString();
                    Email_2 = dt.Rows[1][1].ToString();
                    Email_3 = dt.Rows[2][1].ToString();
                    Email_4 = dt.Rows[3][1].ToString();
                    Email_5 = dt.Rows[4][1].ToString();
                    Email_6 = dt.Rows[5][1].ToString();
                    Email_7 = dt.Rows[6][1].ToString();
                    Email_8 = dt.Rows[7][1].ToString();
                    Email_9 = dt.Rows[8][1].ToString();
                    Email_10 = dt.Rows[9][1].ToString();
                    Email_11 = dt.Rows[10][1].ToString();
                    Email_12 = dt.Rows[11][1].ToString();
                    Email_13 = dt.Rows[12][1].ToString();
                    Email_14 = dt.Rows[13][1].ToString();
                    Email_15 = dt.Rows[14][1].ToString();
                    Email_16 = dt.Rows[15][1].ToString();
                    Email_17 = dt.Rows[16][1].ToString();
                    Email_18 = dt.Rows[17][1].ToString();
                    Email_19 = dt.Rows[18][1].ToString();
                    Email_20 = dt.Rows[19][1].ToString();
                    Email_21 = dt.Rows[20][1].ToString();
                    Email_22 = dt.Rows[21][1].ToString();
                    Email_23 = dt.Rows[22][1].ToString();
                    Email_24 = dt.Rows[23][1].ToString();
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
                    if (Email_1 == "") { Email_1 = "Support@cbr-ingenieria.com.mx"; } else { };
                    MailMessage message = new MailMessage(_sender, Email_1);
                    message.To.Add(Email_2);
                    message.To.Add(Email_3);
                    message.To.Add(Email_4);
                    message.To.Add(Email_5);
                    message.To.Add(Email_6);
                    message.To.Add(Email_7);
                    message.To.Add(Email_8);
                    message.To.Add(Email_9);
                    message.To.Add(Email_10);
                    message.To.Add(Email_11);
                    message.To.Add(Email_12);
                    message.To.Add(Email_13);
                    message.To.Add(Email_14);
                    message.To.Add(Email_15);
                    message.To.Add(Email_16);
                    message.To.Add(Email_17);
                    message.To.Add(Email_18);
                    message.To.Add(Email_19);
                    message.To.Add(Email_20);
                    message.To.Add(Email_21);
                    message.To.Add(Email_22);
                    message.To.Add(Email_23);
                    message.To.Add(Email_24);
                    message.Subject = "Notificacion No conformidad";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedlmagen1("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 25)
                {
                    Email_1 = dt.Rows[0][1].ToString();
                    Email_2 = dt.Rows[1][1].ToString();
                    Email_3 = dt.Rows[2][1].ToString();
                    Email_4 = dt.Rows[3][1].ToString();
                    Email_5 = dt.Rows[4][1].ToString();
                    Email_6 = dt.Rows[5][1].ToString();
                    Email_7 = dt.Rows[6][1].ToString();
                    Email_8 = dt.Rows[7][1].ToString();
                    Email_9 = dt.Rows[8][1].ToString();
                    Email_10 = dt.Rows[9][1].ToString();
                    Email_11 = dt.Rows[10][1].ToString();
                    Email_12 = dt.Rows[11][1].ToString();
                    Email_13 = dt.Rows[12][1].ToString();
                    Email_14 = dt.Rows[13][1].ToString();
                    Email_15 = dt.Rows[14][1].ToString();
                    Email_16 = dt.Rows[15][1].ToString();
                    Email_17 = dt.Rows[16][1].ToString();
                    Email_18 = dt.Rows[17][1].ToString();
                    Email_19 = dt.Rows[18][1].ToString();
                    Email_20 = dt.Rows[19][1].ToString();
                    Email_21 = dt.Rows[20][1].ToString();
                    Email_22 = dt.Rows[21][1].ToString();
                    Email_23 = dt.Rows[22][1].ToString();
                    Email_24 = dt.Rows[23][1].ToString();
                    Email_25 = dt.Rows[24][1].ToString();
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
                    if (Email_1 == "") { Email_1 = "Support@cbr-ingenieria.com.mx"; } else { };
                    MailMessage message = new MailMessage(_sender, Email_1);
                    message.To.Add(Email_2);
                    message.To.Add(Email_3);
                    message.To.Add(Email_4);
                    message.To.Add(Email_5);
                    message.To.Add(Email_6);
                    message.To.Add(Email_7);
                    message.To.Add(Email_8);
                    message.To.Add(Email_9);
                    message.To.Add(Email_10);
                    message.To.Add(Email_11);
                    message.To.Add(Email_12);
                    message.To.Add(Email_13);
                    message.To.Add(Email_14);
                    message.To.Add(Email_15);
                    message.To.Add(Email_16);
                    message.To.Add(Email_17);
                    message.To.Add(Email_18);
                    message.To.Add(Email_19);
                    message.To.Add(Email_20);
                    message.To.Add(Email_21);
                    message.To.Add(Email_22);
                    message.To.Add(Email_23);
                    message.To.Add(Email_24);
                    message.To.Add(Email_25);
                    message.Subject = "Notificacion No conformidad";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedlmagen1("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);

                }
                else if (dt.Rows.Count == 26)
                {
                    Email_1 = dt.Rows[0][1].ToString();
                    Email_2 = dt.Rows[1][1].ToString();
                    Email_3 = dt.Rows[2][1].ToString();
                    Email_4 = dt.Rows[3][1].ToString();
                    Email_5 = dt.Rows[4][1].ToString();
                    Email_6 = dt.Rows[5][1].ToString();
                    Email_7 = dt.Rows[6][1].ToString();
                    Email_8 = dt.Rows[7][1].ToString();
                    Email_9 = dt.Rows[8][1].ToString();
                    Email_10 = dt.Rows[9][1].ToString();
                    Email_11 = dt.Rows[10][1].ToString();
                    Email_12 = dt.Rows[11][1].ToString();
                    Email_13 = dt.Rows[12][1].ToString();
                    Email_14 = dt.Rows[13][1].ToString();
                    Email_15 = dt.Rows[14][1].ToString();
                    Email_16 = dt.Rows[15][1].ToString();
                    Email_17 = dt.Rows[16][1].ToString();
                    Email_18 = dt.Rows[17][1].ToString();
                    Email_19 = dt.Rows[18][1].ToString();
                    Email_20 = dt.Rows[19][1].ToString();
                    Email_21 = dt.Rows[20][1].ToString();
                    Email_22 = dt.Rows[21][1].ToString();
                    Email_23 = dt.Rows[22][1].ToString();
                    Email_24 = dt.Rows[23][1].ToString();
                    Email_25 = dt.Rows[24][1].ToString();
                    Email_26 = dt.Rows[25][1].ToString();
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
                    if (Email_1 == "") { Email_1 = "Support@cbr-ingenieria.com.mx"; } else { };
                    MailMessage message = new MailMessage(_sender, Email_1);
                    message.To.Add(Email_2);
                    message.To.Add(Email_3);
                    message.To.Add(Email_4);
                    message.To.Add(Email_5);
                    message.To.Add(Email_6);
                    message.To.Add(Email_7);
                    message.To.Add(Email_8);
                    message.To.Add(Email_9);
                    message.To.Add(Email_10);
                    message.To.Add(Email_11);
                    message.To.Add(Email_12);
                    message.To.Add(Email_13);
                    message.To.Add(Email_14);
                    message.To.Add(Email_15);
                    message.To.Add(Email_16);
                    message.To.Add(Email_17);
                    message.To.Add(Email_18);
                    message.To.Add(Email_19);
                    message.To.Add(Email_20);
                    message.To.Add(Email_21);
                    message.To.Add(Email_22);
                    message.To.Add(Email_23);
                    message.To.Add(Email_24);
                    message.To.Add(Email_25);
                    message.To.Add(Email_26);
                    message.Subject = "Notificacion No conformidad";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedlmagen1("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 27)
                {
                    Email_1 = dt.Rows[0][1].ToString();
                    Email_2 = dt.Rows[1][1].ToString();
                    Email_3 = dt.Rows[2][1].ToString();
                    Email_4 = dt.Rows[3][1].ToString();
                    Email_5 = dt.Rows[4][1].ToString();
                    Email_6 = dt.Rows[5][1].ToString();
                    Email_7 = dt.Rows[6][1].ToString();
                    Email_8 = dt.Rows[7][1].ToString();
                    Email_9 = dt.Rows[8][1].ToString();
                    Email_10 = dt.Rows[9][1].ToString();
                    Email_11 = dt.Rows[10][1].ToString();
                    Email_12 = dt.Rows[11][1].ToString();
                    Email_13 = dt.Rows[12][1].ToString();
                    Email_14 = dt.Rows[13][1].ToString();
                    Email_15 = dt.Rows[14][1].ToString();
                    Email_16 = dt.Rows[15][1].ToString();
                    Email_17 = dt.Rows[16][1].ToString();
                    Email_18 = dt.Rows[17][1].ToString();
                    Email_19 = dt.Rows[18][1].ToString();
                    Email_20 = dt.Rows[19][1].ToString();
                    Email_21 = dt.Rows[20][1].ToString();
                    Email_22 = dt.Rows[21][1].ToString();
                    Email_23 = dt.Rows[22][1].ToString();
                    Email_24 = dt.Rows[23][1].ToString();
                    Email_25 = dt.Rows[24][1].ToString();
                    Email_26 = dt.Rows[25][1].ToString();
                    Email_27 = dt.Rows[26][1].ToString();
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
                    if (Email_1 == "") { Email_1 = "Support@cbr-ingenieria.com.mx"; } else { };
                    MailMessage message = new MailMessage(_sender, Email_1);
                    message.To.Add(Email_2);
                    message.To.Add(Email_3);
                    message.To.Add(Email_4);
                    message.To.Add(Email_5);
                    message.To.Add(Email_6);
                    message.To.Add(Email_7);
                    message.To.Add(Email_8);
                    message.To.Add(Email_9);
                    message.To.Add(Email_10);
                    message.To.Add(Email_11);
                    message.To.Add(Email_12);
                    message.To.Add(Email_13);
                    message.To.Add(Email_14);
                    message.To.Add(Email_15);
                    message.To.Add(Email_16);
                    message.To.Add(Email_17);
                    message.To.Add(Email_18);
                    message.To.Add(Email_19);
                    message.To.Add(Email_20);
                    message.To.Add(Email_21);
                    message.To.Add(Email_22);
                    message.To.Add(Email_23);
                    message.To.Add(Email_24);
                    message.To.Add(Email_25);
                    message.To.Add(Email_26);
                    message.To.Add(Email_27);
                    message.Subject = "Notificacion No conformidad";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedlmagen1("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 28)
                {
                    Email_1 = dt.Rows[0][1].ToString();
                    Email_2 = dt.Rows[1][1].ToString();
                    Email_3 = dt.Rows[2][1].ToString();
                    Email_4 = dt.Rows[3][1].ToString();
                    Email_5 = dt.Rows[4][1].ToString();
                    Email_6 = dt.Rows[5][1].ToString();
                    Email_7 = dt.Rows[6][1].ToString();
                    Email_8 = dt.Rows[7][1].ToString();
                    Email_9 = dt.Rows[8][1].ToString();
                    Email_10 = dt.Rows[9][1].ToString();
                    Email_11 = dt.Rows[10][1].ToString();
                    Email_12 = dt.Rows[11][1].ToString();
                    Email_13 = dt.Rows[12][1].ToString();
                    Email_14 = dt.Rows[13][1].ToString();
                    Email_15 = dt.Rows[14][1].ToString();
                    Email_16 = dt.Rows[15][1].ToString();
                    Email_17 = dt.Rows[16][1].ToString();
                    Email_18 = dt.Rows[17][1].ToString();
                    Email_19 = dt.Rows[18][1].ToString();
                    Email_20 = dt.Rows[19][1].ToString();
                    Email_21 = dt.Rows[20][1].ToString();
                    Email_22 = dt.Rows[21][1].ToString();
                    Email_23 = dt.Rows[22][1].ToString();
                    Email_24 = dt.Rows[23][1].ToString();
                    Email_25 = dt.Rows[24][1].ToString();
                    Email_26 = dt.Rows[25][1].ToString();
                    Email_27 = dt.Rows[26][1].ToString();
                    Email_28 = dt.Rows[27][1].ToString();
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
                    if (Email_1 == "") { Email_1 = "Support@cbr-ingenieria.com.mx"; } else { };
                    MailMessage message = new MailMessage(_sender, Email_1);
                    message.To.Add(Email_2);
                    message.To.Add(Email_3);
                    message.To.Add(Email_4);
                    message.To.Add(Email_5);
                    message.To.Add(Email_6);
                    message.To.Add(Email_7);
                    message.To.Add(Email_8);
                    message.To.Add(Email_9);
                    message.To.Add(Email_10);
                    message.To.Add(Email_11);
                    message.To.Add(Email_12);
                    message.To.Add(Email_13);
                    message.To.Add(Email_14);
                    message.To.Add(Email_15);
                    message.To.Add(Email_16);
                    message.To.Add(Email_17);
                    message.To.Add(Email_18);
                    message.To.Add(Email_19);
                    message.To.Add(Email_20);
                    message.To.Add(Email_21);
                    message.To.Add(Email_22);
                    message.To.Add(Email_23);
                    message.To.Add(Email_24);
                    message.To.Add(Email_25);
                    message.To.Add(Email_26);
                    message.To.Add(Email_27);
                    message.To.Add(Email_28);
                    message.Subject = "Notificacion No conformidad";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedlmagen1("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 29)
                {
                    Email_1 = dt.Rows[0][1].ToString();
                    Email_2 = dt.Rows[1][1].ToString();
                    Email_3 = dt.Rows[2][1].ToString();
                    Email_4 = dt.Rows[3][1].ToString();
                    Email_5 = dt.Rows[4][1].ToString();
                    Email_6 = dt.Rows[5][1].ToString();
                    Email_7 = dt.Rows[6][1].ToString();
                    Email_8 = dt.Rows[7][1].ToString();
                    Email_9 = dt.Rows[8][1].ToString();
                    Email_10 = dt.Rows[9][1].ToString();
                    Email_11 = dt.Rows[10][1].ToString();
                    Email_12 = dt.Rows[11][1].ToString();
                    Email_13 = dt.Rows[12][1].ToString();
                    Email_14 = dt.Rows[13][1].ToString();
                    Email_15 = dt.Rows[14][1].ToString();
                    Email_16 = dt.Rows[15][1].ToString();
                    Email_17 = dt.Rows[16][1].ToString();
                    Email_18 = dt.Rows[17][1].ToString();
                    Email_19 = dt.Rows[18][1].ToString();
                    Email_20 = dt.Rows[19][1].ToString();
                    Email_21 = dt.Rows[20][1].ToString();
                    Email_22 = dt.Rows[21][1].ToString();
                    Email_23 = dt.Rows[22][1].ToString();
                    Email_24 = dt.Rows[23][1].ToString();
                    Email_25 = dt.Rows[24][1].ToString();
                    Email_26 = dt.Rows[25][1].ToString();
                    Email_27 = dt.Rows[26][1].ToString();
                    Email_28 = dt.Rows[27][1].ToString();
                    Email_29 = dt.Rows[28][1].ToString();
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
                    if (Email_1 == "") { Email_1 = "Support@cbr-ingenieria.com.mx"; } else { };
                    MailMessage message = new MailMessage(_sender, Email_1);
                    message.CC.Add(new MailAddress(Email_2));
                    message.CC.Add(new MailAddress(Email_3));
                    message.CC.Add(new MailAddress(Email_4));
                    message.CC.Add(new MailAddress(Email_5));
                    message.CC.Add(new MailAddress(Email_6));
                    message.CC.Add(new MailAddress(Email_7));
                    message.CC.Add(new MailAddress(Email_8));
                    message.CC.Add(new MailAddress(Email_9));
                    message.Subject = "Notificacion No conformidad";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedlmagen1("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 30)
                {
                    Email_1 = dt.Rows[0][1].ToString();
                    Email_2 = dt.Rows[1][1].ToString();
                    Email_3 = dt.Rows[2][1].ToString();
                    Email_4 = dt.Rows[3][1].ToString();
                    Email_5 = dt.Rows[4][1].ToString();
                    Email_6 = dt.Rows[5][1].ToString();
                    Email_7 = dt.Rows[6][1].ToString();
                    Email_8 = dt.Rows[7][1].ToString();
                    Email_9 = dt.Rows[8][1].ToString();
                    Email_10 = dt.Rows[9][1].ToString();
                    Email_11 = dt.Rows[10][1].ToString();
                    Email_12 = dt.Rows[11][1].ToString();
                    Email_13 = dt.Rows[12][1].ToString();
                    Email_14 = dt.Rows[13][1].ToString();
                    Email_15 = dt.Rows[14][1].ToString();
                    Email_16 = dt.Rows[15][1].ToString();
                    Email_17 = dt.Rows[16][1].ToString();
                    Email_18 = dt.Rows[17][1].ToString();
                    Email_19 = dt.Rows[18][1].ToString();
                    Email_20 = dt.Rows[19][1].ToString();
                    Email_21 = dt.Rows[20][1].ToString();
                    Email_22 = dt.Rows[21][1].ToString();
                    Email_23 = dt.Rows[22][1].ToString();
                    Email_24 = dt.Rows[23][1].ToString();
                    Email_25 = dt.Rows[24][1].ToString();
                    Email_26 = dt.Rows[25][1].ToString();
                    Email_27 = dt.Rows[26][1].ToString();
                    Email_28 = dt.Rows[27][1].ToString();
                    Email_29 = dt.Rows[28][1].ToString();
                    Email_30 = dt.Rows[29][1].ToString();
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
                    if (Email_1 == "") { Email_1 = "Support@cbr-ingenieria.com.mx"; } else { };
                    MailMessage message = new MailMessage(_sender, Email_1);
                    message.To.Add(Email_2);
                    message.To.Add(Email_3);
                    message.To.Add(Email_4);
                    message.To.Add(Email_5);
                    message.To.Add(Email_6);
                    message.To.Add(Email_7);
                    message.To.Add(Email_8);
                    message.To.Add(Email_9);
                    message.To.Add(Email_10);
                    message.To.Add(Email_11);
                    message.To.Add(Email_12);
                    message.To.Add(Email_13);
                    message.To.Add(Email_14);
                    message.To.Add(Email_15);
                    message.To.Add(Email_16);
                    message.To.Add(Email_17);
                    message.To.Add(Email_18);
                    message.To.Add(Email_19);
                    message.To.Add(Email_20);
                    message.To.Add(Email_21);
                    message.To.Add(Email_22);
                    message.To.Add(Email_23);
                    message.To.Add(Email_24);
                    message.To.Add(Email_25);
                    message.To.Add(Email_26);
                    message.To.Add(Email_27);
                    message.To.Add(Email_28);
                    message.To.Add(Email_29);
                    message.Subject = "Notificacion No conformidad";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedlmagen1("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);

                }
                else if (dt.Rows.Count == 31)
                {
                    Email_1 = dt.Rows[0][1].ToString();
                    Email_2 = dt.Rows[1][1].ToString();
                    Email_3 = dt.Rows[2][1].ToString();
                    Email_4 = dt.Rows[3][1].ToString();
                    Email_5 = dt.Rows[4][1].ToString();
                    Email_6 = dt.Rows[5][1].ToString();
                    Email_7 = dt.Rows[6][1].ToString();
                    Email_8 = dt.Rows[7][1].ToString();
                    Email_9 = dt.Rows[8][1].ToString();
                    Email_10 = dt.Rows[9][1].ToString();
                    Email_11 = dt.Rows[10][1].ToString();
                    Email_12 = dt.Rows[11][1].ToString();
                    Email_13 = dt.Rows[12][1].ToString();
                    Email_14 = dt.Rows[13][1].ToString();
                    Email_15 = dt.Rows[14][1].ToString();
                    Email_16 = dt.Rows[15][1].ToString();
                    Email_17 = dt.Rows[16][1].ToString();
                    Email_18 = dt.Rows[17][1].ToString();
                    Email_19 = dt.Rows[18][1].ToString();
                    Email_20 = dt.Rows[19][1].ToString();
                    Email_21 = dt.Rows[20][1].ToString();
                    Email_22 = dt.Rows[21][1].ToString();
                    Email_23 = dt.Rows[22][1].ToString();
                    Email_24 = dt.Rows[23][1].ToString();
                    Email_25 = dt.Rows[24][1].ToString();
                    Email_26 = dt.Rows[25][1].ToString();
                    Email_27 = dt.Rows[26][1].ToString();
                    Email_28 = dt.Rows[27][1].ToString();
                    Email_29 = dt.Rows[28][1].ToString();
                    Email_30 = dt.Rows[29][1].ToString();
                    Email_31 = dt.Rows[30][1].ToString();
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
                    if (Email_1 == "") { Email_1 = "Support@cbr-ingenieria.com.mx"; } else { };
                    MailMessage message = new MailMessage(_sender, Email_1);
                    message.To.Add(Email_2);
                    message.To.Add(Email_3);
                    message.To.Add(Email_4);
                    message.To.Add(Email_5);
                    message.To.Add(Email_6);
                    message.To.Add(Email_7);
                    message.To.Add(Email_8);
                    message.To.Add(Email_9);
                    message.To.Add(Email_10);
                    message.To.Add(Email_11);
                    message.To.Add(Email_12);
                    message.To.Add(Email_13);
                    message.To.Add(Email_14);
                    message.To.Add(Email_15);
                    message.To.Add(Email_16);
                    message.To.Add(Email_17);
                    message.To.Add(Email_18);
                    message.To.Add(Email_19);
                    message.To.Add(Email_20);
                    message.To.Add(Email_21);
                    message.To.Add(Email_22);
                    message.To.Add(Email_23);
                    message.To.Add(Email_24);
                    message.To.Add(Email_25);
                    message.To.Add(Email_26);
                    message.To.Add(Email_27);
                    message.To.Add(Email_28);
                    message.To.Add(Email_29);
                    message.To.Add(Email_30);
                    message.To.Add(Email_31);
                    message.Subject = "Notificacion No conformidad";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedlmagen1("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 32)
                {
                    Email_1 = dt.Rows[0][1].ToString();
                    Email_2 = dt.Rows[1][1].ToString();
                    Email_3 = dt.Rows[2][1].ToString();
                    Email_4 = dt.Rows[3][1].ToString();
                    Email_5 = dt.Rows[4][1].ToString();
                    Email_6 = dt.Rows[5][1].ToString();
                    Email_7 = dt.Rows[6][1].ToString();
                    Email_8 = dt.Rows[7][1].ToString();
                    Email_9 = dt.Rows[8][1].ToString();
                    Email_10 = dt.Rows[9][1].ToString();
                    Email_11 = dt.Rows[10][1].ToString();
                    Email_12 = dt.Rows[11][1].ToString();
                    Email_13 = dt.Rows[12][1].ToString();
                    Email_14 = dt.Rows[13][1].ToString();
                    Email_15 = dt.Rows[14][1].ToString();
                    Email_16 = dt.Rows[15][1].ToString();
                    Email_17 = dt.Rows[16][1].ToString();
                    Email_18 = dt.Rows[17][1].ToString();
                    Email_19 = dt.Rows[18][1].ToString();
                    Email_20 = dt.Rows[19][1].ToString();
                    Email_21 = dt.Rows[20][1].ToString();
                    Email_22 = dt.Rows[21][1].ToString();
                    Email_23 = dt.Rows[22][1].ToString();
                    Email_24 = dt.Rows[23][1].ToString();
                    Email_25 = dt.Rows[24][1].ToString();
                    Email_26 = dt.Rows[25][1].ToString();
                    Email_27 = dt.Rows[26][1].ToString();
                    Email_28 = dt.Rows[27][1].ToString();
                    Email_29 = dt.Rows[28][1].ToString();
                    Email_30 = dt.Rows[29][1].ToString();
                    Email_31 = dt.Rows[30][1].ToString();
                    Email_32 = dt.Rows[31][1].ToString();
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
                    if (Email_1 == "") { Email_1 = "Support@cbr-ingenieria.com.mx"; } else { };
                    MailMessage message = new MailMessage(_sender, Email_1);
                    message.To.Add(Email_2);
                    message.To.Add(Email_3);
                    message.To.Add(Email_4);
                    message.To.Add(Email_5);
                    message.To.Add(Email_6);
                    message.To.Add(Email_7);
                    message.To.Add(Email_8);
                    message.To.Add(Email_9);
                    message.To.Add(Email_10);
                    message.To.Add(Email_11);
                    message.To.Add(Email_12);
                    message.To.Add(Email_13);
                    message.To.Add(Email_14);
                    message.To.Add(Email_15);
                    message.To.Add(Email_16);
                    message.To.Add(Email_17);
                    message.To.Add(Email_18);
                    message.To.Add(Email_19);
                    message.To.Add(Email_20);
                    message.To.Add(Email_21);
                    message.To.Add(Email_22);
                    message.To.Add(Email_23);
                    message.To.Add(Email_24);
                    message.To.Add(Email_25);
                    message.To.Add(Email_26);
                    message.To.Add(Email_27);
                    message.To.Add(Email_28);
                    message.To.Add(Email_29);
                    message.To.Add(Email_30);
                    message.To.Add(Email_31);
                    message.To.Add(Email_32);
                    message.Subject = "Notificacion No conformidad";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedlmagen1("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 33)
                {

                    Email_1 = dt.Rows[0][1].ToString();
                    Email_2 = dt.Rows[1][1].ToString();
                    Email_3 = dt.Rows[2][1].ToString();
                    Email_4 = dt.Rows[3][1].ToString();
                    Email_5 = dt.Rows[4][1].ToString();
                    Email_6 = dt.Rows[5][1].ToString();
                    Email_7 = dt.Rows[6][1].ToString();
                    Email_8 = dt.Rows[7][1].ToString();
                    Email_9 = dt.Rows[8][1].ToString();
                    Email_10 = dt.Rows[9][1].ToString();
                    Email_11 = dt.Rows[10][1].ToString();
                    Email_12 = dt.Rows[11][1].ToString();
                    Email_13 = dt.Rows[12][1].ToString();
                    Email_14 = dt.Rows[13][1].ToString();
                    Email_15 = dt.Rows[14][1].ToString();
                    Email_16 = dt.Rows[15][1].ToString();
                    Email_17 = dt.Rows[16][1].ToString();
                    Email_18 = dt.Rows[17][1].ToString();
                    Email_19 = dt.Rows[18][1].ToString();
                    Email_20 = dt.Rows[19][1].ToString();
                    Email_21 = dt.Rows[20][1].ToString();
                    Email_22 = dt.Rows[21][1].ToString();
                    Email_23 = dt.Rows[22][1].ToString();
                    Email_24 = dt.Rows[23][1].ToString();
                    Email_25 = dt.Rows[24][1].ToString();
                    Email_26 = dt.Rows[25][1].ToString();
                    Email_27 = dt.Rows[26][1].ToString();
                    Email_28 = dt.Rows[27][1].ToString();
                    Email_29 = dt.Rows[28][1].ToString();
                    Email_30 = dt.Rows[29][1].ToString();
                    Email_31 = dt.Rows[30][1].ToString();
                    Email_32 = dt.Rows[31][1].ToString();
                    Email_33 = dt.Rows[32][1].ToString();
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
                    if (Email_1 == "") { Email_1 = "Support@cbr-ingenieria.com.mx"; } else { };
                    MailMessage message = new MailMessage(_sender, Email_1);
                    message.To.Add(Email_2);
                    message.To.Add(Email_3);
                    message.To.Add(Email_4);
                    message.To.Add(Email_5);
                    message.To.Add(Email_6);
                    message.To.Add(Email_7);
                    message.To.Add(Email_8);
                    message.To.Add(Email_9);
                    message.To.Add(Email_10);
                    message.To.Add(Email_11);
                    message.To.Add(Email_12);
                    message.To.Add(Email_13);
                    message.To.Add(Email_14);
                    message.To.Add(Email_15);
                    message.To.Add(Email_16);
                    message.To.Add(Email_17);
                    message.To.Add(Email_18);
                    message.To.Add(Email_19);
                    message.To.Add(Email_20);
                    message.To.Add(Email_21);
                    message.To.Add(Email_22);
                    message.To.Add(Email_23);
                    message.To.Add(Email_24);
                    message.To.Add(Email_25);
                    message.To.Add(Email_26);
                    message.To.Add(Email_27);
                    message.To.Add(Email_28);
                    message.To.Add(Email_29);
                    message.To.Add(Email_30);
                    message.To.Add(Email_31);
                    message.To.Add(Email_32);
                    message.To.Add(Email_33);
                    message.Subject = "Notificacion No conformidad";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedlmagen1("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 34)
                {
                    Email_1 = dt.Rows[0][1].ToString();
                    Email_2 = dt.Rows[1][1].ToString();
                    Email_3 = dt.Rows[2][1].ToString();
                    Email_4 = dt.Rows[3][1].ToString();
                    Email_5 = dt.Rows[4][1].ToString();
                    Email_6 = dt.Rows[5][1].ToString();
                    Email_7 = dt.Rows[6][1].ToString();
                    Email_8 = dt.Rows[7][1].ToString();
                    Email_9 = dt.Rows[8][1].ToString();
                    Email_10 = dt.Rows[9][1].ToString();
                    Email_11 = dt.Rows[10][1].ToString();
                    Email_12 = dt.Rows[11][1].ToString();
                    Email_13 = dt.Rows[12][1].ToString();
                    Email_14 = dt.Rows[13][1].ToString();
                    Email_15 = dt.Rows[14][1].ToString();
                    Email_16 = dt.Rows[15][1].ToString();
                    Email_17 = dt.Rows[16][1].ToString();
                    Email_18 = dt.Rows[17][1].ToString();
                    Email_19 = dt.Rows[18][1].ToString();
                    Email_20 = dt.Rows[19][1].ToString();
                    Email_21 = dt.Rows[20][1].ToString();
                    Email_22 = dt.Rows[21][1].ToString();
                    Email_23 = dt.Rows[22][1].ToString();
                    Email_24 = dt.Rows[23][1].ToString();
                    Email_25 = dt.Rows[24][1].ToString();
                    Email_26 = dt.Rows[25][1].ToString();
                    Email_27 = dt.Rows[26][1].ToString();
                    Email_28 = dt.Rows[27][1].ToString();
                    Email_29 = dt.Rows[28][1].ToString();
                    Email_30 = dt.Rows[29][1].ToString();
                    Email_31 = dt.Rows[30][1].ToString();
                    Email_32 = dt.Rows[31][1].ToString();
                    Email_33 = dt.Rows[32][1].ToString();
                    Email_34 = dt.Rows[33][1].ToString();
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
                    if (Email_1 == "") { Email_1 = "Support@cbr-ingenieria.com.mx"; } else { };
                    MailMessage message = new MailMessage(_sender, Email_1);
                    message.To.Add(Email_2);
                    message.To.Add(Email_3);
                    message.To.Add(Email_4);
                    message.To.Add(Email_5);
                    message.To.Add(Email_6);
                    message.To.Add(Email_7);
                    message.To.Add(Email_8);
                    message.To.Add(Email_9);
                    message.To.Add(Email_10);
                    message.To.Add(Email_11);
                    message.To.Add(Email_12);
                    message.To.Add(Email_13);
                    message.To.Add(Email_14);
                    message.To.Add(Email_15);
                    message.To.Add(Email_16);
                    message.To.Add(Email_17);
                    message.To.Add(Email_18);
                    message.To.Add(Email_19);
                    message.To.Add(Email_20);
                    message.To.Add(Email_21);
                    message.To.Add(Email_22);
                    message.To.Add(Email_23);
                    message.To.Add(Email_24);
                    message.To.Add(Email_25);
                    message.To.Add(Email_26);
                    message.To.Add(Email_27);
                    message.To.Add(Email_28);
                    message.To.Add(Email_29);
                    message.To.Add(Email_30);
                    message.To.Add(Email_31);
                    message.To.Add(Email_32);
                    message.To.Add(Email_33);
                    message.To.Add(Email_34);
                    message.Subject = "Notificacion No conformidad";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedlmagen1("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 35)
                {
                    Email_1 = dt.Rows[0][1].ToString();
                    Email_2 = dt.Rows[1][1].ToString();
                    Email_3 = dt.Rows[2][1].ToString();
                    Email_4 = dt.Rows[3][1].ToString();
                    Email_5 = dt.Rows[4][1].ToString();
                    Email_6 = dt.Rows[5][1].ToString();
                    Email_7 = dt.Rows[6][1].ToString();
                    Email_8 = dt.Rows[7][1].ToString();
                    Email_9 = dt.Rows[8][1].ToString();
                    Email_10 = dt.Rows[9][1].ToString();
                    Email_11 = dt.Rows[10][1].ToString();
                    Email_12 = dt.Rows[11][1].ToString();
                    Email_13 = dt.Rows[12][1].ToString();
                    Email_14 = dt.Rows[13][1].ToString();
                    Email_15 = dt.Rows[14][1].ToString();
                    Email_16 = dt.Rows[15][1].ToString();
                    Email_17 = dt.Rows[16][1].ToString();
                    Email_18 = dt.Rows[17][1].ToString();
                    Email_19 = dt.Rows[18][1].ToString();
                    Email_20 = dt.Rows[19][1].ToString();
                    Email_21 = dt.Rows[20][1].ToString();
                    Email_22 = dt.Rows[21][1].ToString();
                    Email_23 = dt.Rows[22][1].ToString();
                    Email_24 = dt.Rows[23][1].ToString();
                    Email_25 = dt.Rows[24][1].ToString();
                    Email_26 = dt.Rows[25][1].ToString();
                    Email_27 = dt.Rows[26][1].ToString();
                    Email_28 = dt.Rows[27][1].ToString();
                    Email_29 = dt.Rows[28][1].ToString();
                    Email_30 = dt.Rows[29][1].ToString();
                    Email_31 = dt.Rows[30][1].ToString();
                    Email_32 = dt.Rows[31][1].ToString();
                    Email_33 = dt.Rows[32][1].ToString();
                    Email_34 = dt.Rows[33][1].ToString();
                    Email_35 = dt.Rows[34][1].ToString();
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
                    if (Email_1 == "") { Email_1 = "Support@cbr-ingenieria.com.mx"; } else { };
                    MailMessage message = new MailMessage(_sender, Email_1);
                    message.To.Add(Email_2);
                    message.To.Add(Email_3);
                    message.To.Add(Email_4);
                    message.To.Add(Email_5);
                    message.To.Add(Email_6);
                    message.To.Add(Email_7);
                    message.To.Add(Email_8);
                    message.To.Add(Email_9);
                    message.To.Add(Email_10);
                    message.To.Add(Email_11);
                    message.To.Add(Email_12);
                    message.To.Add(Email_13);
                    message.To.Add(Email_14);
                    message.To.Add(Email_15);
                    message.To.Add(Email_16);
                    message.To.Add(Email_17);
                    message.To.Add(Email_18);
                    message.To.Add(Email_19);
                    message.To.Add(Email_20);
                    message.To.Add(Email_21);
                    message.To.Add(Email_22);
                    message.To.Add(Email_23);
                    message.To.Add(Email_24);
                    message.To.Add(Email_25);
                    message.To.Add(Email_26);
                    message.To.Add(Email_27);
                    message.To.Add(Email_28);
                    message.To.Add(Email_29);
                    message.To.Add(Email_30);
                    message.To.Add(Email_31);
                    message.To.Add(Email_32);
                    message.To.Add(Email_33);
                    message.To.Add(Email_34);
                    message.To.Add(Email_35);
                    message.Subject = "Notificacion No conformidad";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedlmagen1("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);

                }
                else if (dt.Rows.Count == 36)
                {
                    Email_1 = dt.Rows[0][1].ToString();
                    Email_2 = dt.Rows[1][1].ToString();
                    Email_3 = dt.Rows[2][1].ToString();
                    Email_4 = dt.Rows[3][1].ToString();
                    Email_5 = dt.Rows[4][1].ToString();
                    Email_6 = dt.Rows[5][1].ToString();
                    Email_7 = dt.Rows[6][1].ToString();
                    Email_8 = dt.Rows[7][1].ToString();
                    Email_9 = dt.Rows[8][1].ToString();
                    Email_10 = dt.Rows[9][1].ToString();
                    Email_11 = dt.Rows[10][1].ToString();
                    Email_12 = dt.Rows[11][1].ToString();
                    Email_13 = dt.Rows[12][1].ToString();
                    Email_14 = dt.Rows[13][1].ToString();
                    Email_15 = dt.Rows[14][1].ToString();
                    Email_16 = dt.Rows[15][1].ToString();
                    Email_17 = dt.Rows[16][1].ToString();
                    Email_18 = dt.Rows[17][1].ToString();
                    Email_19 = dt.Rows[18][1].ToString();
                    Email_20 = dt.Rows[19][1].ToString();
                    Email_21 = dt.Rows[20][1].ToString();
                    Email_22 = dt.Rows[21][1].ToString();
                    Email_23 = dt.Rows[22][1].ToString();
                    Email_24 = dt.Rows[23][1].ToString();
                    Email_25 = dt.Rows[24][1].ToString();
                    Email_26 = dt.Rows[25][1].ToString();
                    Email_27 = dt.Rows[26][1].ToString();
                    Email_28 = dt.Rows[27][1].ToString();
                    Email_29 = dt.Rows[28][1].ToString();
                    Email_30 = dt.Rows[29][1].ToString();
                    Email_31 = dt.Rows[30][1].ToString();
                    Email_32 = dt.Rows[31][1].ToString();
                    Email_33 = dt.Rows[32][1].ToString();
                    Email_34 = dt.Rows[33][1].ToString();
                    Email_35 = dt.Rows[34][1].ToString();
                    Email_36 = dt.Rows[35][1].ToString();
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
                    if (Email_1 == "") { Email_1 = "Support@cbr-ingenieria.com.mx"; } else { };
                    MailMessage message = new MailMessage(_sender, Email_1);
                    message.To.Add(Email_2);
                    message.To.Add(Email_3);
                    message.To.Add(Email_4);
                    message.To.Add(Email_5);
                    message.To.Add(Email_6);
                    message.To.Add(Email_7);
                    message.To.Add(Email_8);
                    message.To.Add(Email_9);
                    message.To.Add(Email_10);
                    message.To.Add(Email_11);
                    message.To.Add(Email_12);
                    message.To.Add(Email_13);
                    message.To.Add(Email_14);
                    message.To.Add(Email_15);
                    message.To.Add(Email_16);
                    message.To.Add(Email_17);
                    message.To.Add(Email_18);
                    message.To.Add(Email_19);
                    message.To.Add(Email_20);
                    message.To.Add(Email_21);
                    message.To.Add(Email_22);
                    message.To.Add(Email_23);
                    message.To.Add(Email_24);
                    message.To.Add(Email_25);
                    message.To.Add(Email_26);
                    message.To.Add(Email_27);
                    message.To.Add(Email_28);
                    message.To.Add(Email_29);
                    message.To.Add(Email_30);
                    message.To.Add(Email_31);
                    message.To.Add(Email_32);
                    message.To.Add(Email_33);
                    message.To.Add(Email_34);
                    message.To.Add(Email_35);
                    message.To.Add(Email_36);
                    message.Subject = "Notificacion No conformidad";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedlmagen1("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 37)
                {
                    Email_1 = dt.Rows[0][1].ToString();
                    Email_2 = dt.Rows[1][1].ToString();
                    Email_3 = dt.Rows[2][1].ToString();
                    Email_4 = dt.Rows[3][1].ToString();
                    Email_5 = dt.Rows[4][1].ToString();
                    Email_6 = dt.Rows[5][1].ToString();
                    Email_7 = dt.Rows[6][1].ToString();
                    Email_8 = dt.Rows[7][1].ToString();
                    Email_9 = dt.Rows[8][1].ToString();
                    Email_10 = dt.Rows[9][1].ToString();
                    Email_11 = dt.Rows[10][1].ToString();
                    Email_12 = dt.Rows[11][1].ToString();
                    Email_13 = dt.Rows[12][1].ToString();
                    Email_14 = dt.Rows[13][1].ToString();
                    Email_15 = dt.Rows[14][1].ToString();
                    Email_16 = dt.Rows[15][1].ToString();
                    Email_17 = dt.Rows[16][1].ToString();
                    Email_18 = dt.Rows[17][1].ToString();
                    Email_19 = dt.Rows[18][1].ToString();
                    Email_20 = dt.Rows[19][1].ToString();
                    Email_21 = dt.Rows[20][1].ToString();
                    Email_22 = dt.Rows[21][1].ToString();
                    Email_23 = dt.Rows[22][1].ToString();
                    Email_24 = dt.Rows[23][1].ToString();
                    Email_25 = dt.Rows[24][1].ToString();
                    Email_26 = dt.Rows[25][1].ToString();
                    Email_27 = dt.Rows[26][1].ToString();
                    Email_28 = dt.Rows[27][1].ToString();
                    Email_29 = dt.Rows[28][1].ToString();
                    Email_30 = dt.Rows[29][1].ToString();
                    Email_31 = dt.Rows[30][1].ToString();
                    Email_32 = dt.Rows[31][1].ToString();
                    Email_33 = dt.Rows[32][1].ToString();
                    Email_34 = dt.Rows[33][1].ToString();
                    Email_35 = dt.Rows[34][1].ToString();
                    Email_36 = dt.Rows[35][1].ToString();
                    Email_37 = dt.Rows[36][1].ToString();
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
                    if (Email_1 == "") { Email_1 = "Support@cbr-ingenieria.com.mx"; } else { };
                    MailMessage message = new MailMessage(_sender, Email_1);
                    message.To.Add(Email_2);
                    message.To.Add(Email_3);
                    message.To.Add(Email_4);
                    message.To.Add(Email_5);
                    message.To.Add(Email_6);
                    message.To.Add(Email_7);
                    message.To.Add(Email_8);
                    message.To.Add(Email_9);
                    message.To.Add(Email_10);
                    message.To.Add(Email_11);
                    message.To.Add(Email_12);
                    message.To.Add(Email_13);
                    message.To.Add(Email_14);
                    message.To.Add(Email_15);
                    message.To.Add(Email_16);
                    message.To.Add(Email_17);
                    message.To.Add(Email_18);
                    message.To.Add(Email_19);
                    message.To.Add(Email_20);
                    message.To.Add(Email_21);
                    message.To.Add(Email_22);
                    message.To.Add(Email_23);
                    message.To.Add(Email_24);
                    message.To.Add(Email_25);
                    message.To.Add(Email_26);
                    message.To.Add(Email_27);
                    message.To.Add(Email_28);
                    message.To.Add(Email_29);
                    message.To.Add(Email_30);
                    message.To.Add(Email_31);
                    message.To.Add(Email_32);
                    message.To.Add(Email_33);
                    message.To.Add(Email_34);
                    message.To.Add(Email_35);
                    message.To.Add(Email_36);
                    message.To.Add(Email_37);
                    message.Subject = "Notificacion No conformidad";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedlmagen1("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 38)
                {
                    Email_1 = dt.Rows[0][1].ToString();
                    Email_2 = dt.Rows[1][1].ToString();
                    Email_3 = dt.Rows[2][1].ToString();
                    Email_4 = dt.Rows[3][1].ToString();
                    Email_5 = dt.Rows[4][1].ToString();
                    Email_6 = dt.Rows[5][1].ToString();
                    Email_7 = dt.Rows[6][1].ToString();
                    Email_8 = dt.Rows[7][1].ToString();
                    Email_9 = dt.Rows[8][1].ToString();
                    Email_10 = dt.Rows[9][1].ToString();
                    Email_11 = dt.Rows[10][1].ToString();
                    Email_12 = dt.Rows[11][1].ToString();
                    Email_13 = dt.Rows[12][1].ToString();
                    Email_14 = dt.Rows[13][1].ToString();
                    Email_15 = dt.Rows[14][1].ToString();
                    Email_16 = dt.Rows[15][1].ToString();
                    Email_17 = dt.Rows[16][1].ToString();
                    Email_18 = dt.Rows[17][1].ToString();
                    Email_19 = dt.Rows[18][1].ToString();
                    Email_20 = dt.Rows[19][1].ToString();
                    Email_21 = dt.Rows[20][1].ToString();
                    Email_22 = dt.Rows[21][1].ToString();
                    Email_23 = dt.Rows[22][1].ToString();
                    Email_24 = dt.Rows[23][1].ToString();
                    Email_25 = dt.Rows[24][1].ToString();
                    Email_26 = dt.Rows[25][1].ToString();
                    Email_27 = dt.Rows[26][1].ToString();
                    Email_28 = dt.Rows[27][1].ToString();
                    Email_29 = dt.Rows[28][1].ToString();
                    Email_30 = dt.Rows[29][1].ToString();
                    Email_31 = dt.Rows[30][1].ToString();
                    Email_32 = dt.Rows[31][1].ToString();
                    Email_33 = dt.Rows[32][1].ToString();
                    Email_34 = dt.Rows[33][1].ToString();
                    Email_35 = dt.Rows[34][1].ToString();
                    Email_36 = dt.Rows[35][1].ToString();
                    Email_37 = dt.Rows[36][1].ToString();
                    Email_38 = dt.Rows[37][1].ToString();
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
                    if (Email_1 == "") { Email_1 = "Support@cbr-ingenieria.com.mx"; } else { };
                    MailMessage message = new MailMessage(_sender, Email_1);
                    message.To.Add(Email_2);
                    message.To.Add(Email_3);
                    message.To.Add(Email_4);
                    message.To.Add(Email_5);
                    message.To.Add(Email_6);
                    message.To.Add(Email_7);
                    message.To.Add(Email_8);
                    message.To.Add(Email_9);
                    message.To.Add(Email_10);
                    message.To.Add(Email_11);
                    message.To.Add(Email_12);
                    message.To.Add(Email_13);
                    message.To.Add(Email_14);
                    message.To.Add(Email_15);
                    message.To.Add(Email_16);
                    message.To.Add(Email_17);
                    message.To.Add(Email_18);
                    message.To.Add(Email_19);
                    message.To.Add(Email_20);
                    message.To.Add(Email_21);
                    message.To.Add(Email_22);
                    message.To.Add(Email_23);
                    message.To.Add(Email_24);
                    message.To.Add(Email_25);
                    message.To.Add(Email_26);
                    message.To.Add(Email_27);
                    message.To.Add(Email_28);
                    message.To.Add(Email_29);
                    message.To.Add(Email_30);
                    message.To.Add(Email_31);
                    message.To.Add(Email_32);
                    message.To.Add(Email_33);
                    message.To.Add(Email_34);
                    message.To.Add(Email_35);
                    message.To.Add(Email_36);
                    message.To.Add(Email_37);
                    message.To.Add(Email_38);
                    message.Subject = "Notificacion No conformidad";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedlmagen1("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 39)
                {
                    Email_1 = dt.Rows[0][1].ToString();
                    Email_2 = dt.Rows[1][1].ToString();
                    Email_3 = dt.Rows[2][1].ToString();
                    Email_4 = dt.Rows[3][1].ToString();
                    Email_5 = dt.Rows[4][1].ToString();
                    Email_6 = dt.Rows[5][1].ToString();
                    Email_7 = dt.Rows[6][1].ToString();
                    Email_8 = dt.Rows[7][1].ToString();
                    Email_9 = dt.Rows[8][1].ToString();
                    Email_10 = dt.Rows[9][1].ToString();
                    Email_11 = dt.Rows[10][1].ToString();
                    Email_12 = dt.Rows[11][1].ToString();
                    Email_13 = dt.Rows[12][1].ToString();
                    Email_14 = dt.Rows[13][1].ToString();
                    Email_15 = dt.Rows[14][1].ToString();
                    Email_16 = dt.Rows[15][1].ToString();
                    Email_17 = dt.Rows[16][1].ToString();
                    Email_18 = dt.Rows[17][1].ToString();
                    Email_19 = dt.Rows[18][1].ToString();
                    Email_20 = dt.Rows[19][1].ToString();
                    Email_21 = dt.Rows[20][1].ToString();
                    Email_22 = dt.Rows[21][1].ToString();
                    Email_23 = dt.Rows[22][1].ToString();
                    Email_24 = dt.Rows[23][1].ToString();
                    Email_25 = dt.Rows[24][1].ToString();
                    Email_26 = dt.Rows[25][1].ToString();
                    Email_27 = dt.Rows[26][1].ToString();
                    Email_28 = dt.Rows[27][1].ToString();
                    Email_29 = dt.Rows[28][1].ToString();
                    Email_30 = dt.Rows[29][1].ToString();
                    Email_31 = dt.Rows[30][1].ToString();
                    Email_32 = dt.Rows[31][1].ToString();
                    Email_33 = dt.Rows[32][1].ToString();
                    Email_34 = dt.Rows[33][1].ToString();
                    Email_35 = dt.Rows[34][1].ToString();
                    Email_36 = dt.Rows[35][1].ToString();
                    Email_37 = dt.Rows[36][1].ToString();
                    Email_38 = dt.Rows[37][1].ToString();
                    Email_39 = dt.Rows[38][1].ToString();
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
                    if (Email_1 == "") { Email_1 = "Support@cbr-ingenieria.com.mx"; } else { };
                    MailMessage message = new MailMessage(_sender, Email_1);
                    message.To.Add(Email_2);
                    message.To.Add(Email_3);
                    message.To.Add(Email_4);
                    message.To.Add(Email_5);
                    message.To.Add(Email_6);
                    message.To.Add(Email_7);
                    message.To.Add(Email_8);
                    message.To.Add(Email_9);
                    message.To.Add(Email_10);
                    message.To.Add(Email_11);
                    message.To.Add(Email_12);
                    message.To.Add(Email_13);
                    message.To.Add(Email_14);
                    message.To.Add(Email_15);
                    message.To.Add(Email_16);
                    message.To.Add(Email_17);
                    message.To.Add(Email_18);
                    message.To.Add(Email_19);
                    message.To.Add(Email_20);
                    message.To.Add(Email_21);
                    message.To.Add(Email_22);
                    message.To.Add(Email_23);
                    message.To.Add(Email_24);
                    message.To.Add(Email_25);
                    message.To.Add(Email_26);
                    message.To.Add(Email_27);
                    message.To.Add(Email_28);
                    message.To.Add(Email_29);
                    message.To.Add(Email_30);
                    message.To.Add(Email_31);
                    message.To.Add(Email_32);
                    message.To.Add(Email_33);
                    message.To.Add(Email_34);
                    message.To.Add(Email_35);
                    message.To.Add(Email_36);
                    message.To.Add(Email_37);
                    message.To.Add(Email_38);
                    message.To.Add(Email_39);
                    message.Subject = "Notificacion No conformidad";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedlmagen1("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);
                }
                else if (dt.Rows.Count == 40)
                {
                    Email_1 = dt.Rows[0][1].ToString();
                    Email_2 = dt.Rows[1][1].ToString();
                    Email_3 = dt.Rows[2][1].ToString();
                    Email_4 = dt.Rows[3][1].ToString();
                    Email_5 = dt.Rows[4][1].ToString();
                    Email_6 = dt.Rows[5][1].ToString();
                    Email_7 = dt.Rows[6][1].ToString();
                    Email_8 = dt.Rows[7][1].ToString();
                    Email_9 = dt.Rows[8][1].ToString();
                    Email_10 = dt.Rows[9][1].ToString();
                    Email_11 = dt.Rows[10][1].ToString();
                    Email_12 = dt.Rows[11][1].ToString();
                    Email_13 = dt.Rows[12][1].ToString();
                    Email_14 = dt.Rows[13][1].ToString();
                    Email_15 = dt.Rows[14][1].ToString();
                    Email_16 = dt.Rows[15][1].ToString();
                    Email_17 = dt.Rows[16][1].ToString();
                    Email_18 = dt.Rows[17][1].ToString();
                    Email_19 = dt.Rows[18][1].ToString();
                    Email_20 = dt.Rows[19][1].ToString();
                    Email_21 = dt.Rows[20][1].ToString();
                    Email_22 = dt.Rows[21][1].ToString();
                    Email_23 = dt.Rows[22][1].ToString();
                    Email_24 = dt.Rows[23][1].ToString();
                    Email_25 = dt.Rows[24][1].ToString();
                    Email_26 = dt.Rows[25][1].ToString();
                    Email_27 = dt.Rows[26][1].ToString();
                    Email_28 = dt.Rows[27][1].ToString();
                    Email_29 = dt.Rows[28][1].ToString();
                    Email_30 = dt.Rows[29][1].ToString();
                    Email_31 = dt.Rows[30][1].ToString();
                    Email_32 = dt.Rows[31][1].ToString();
                    Email_33 = dt.Rows[32][1].ToString();
                    Email_34 = dt.Rows[33][1].ToString();
                    Email_35 = dt.Rows[34][1].ToString();
                    Email_36 = dt.Rows[35][1].ToString();
                    Email_37 = dt.Rows[36][1].ToString();
                    Email_38 = dt.Rows[37][1].ToString();
                    Email_39 = dt.Rows[38][1].ToString();
                    Email_40 = dt.Rows[39][1].ToString();
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
                    if (Email_1 == "") { Email_1 = "Support@cbr-ingenieria.com.mx"; } else { };
                    MailMessage message = new MailMessage(_sender, Email_1);
                    message.To.Add(Email_2);
                    message.To.Add(Email_3);
                    message.To.Add(Email_4);
                    message.To.Add(Email_5);
                    message.To.Add(Email_6);
                    message.To.Add(Email_7);
                    message.To.Add(Email_8);
                    message.To.Add(Email_9);
                    message.To.Add(Email_10);
                    message.To.Add(Email_11);
                    message.To.Add(Email_12);
                    message.To.Add(Email_13);
                    message.To.Add(Email_14);
                    message.To.Add(Email_15);
                    message.To.Add(Email_16);
                    message.To.Add(Email_17);
                    message.To.Add(Email_18);
                    message.To.Add(Email_19);
                    message.To.Add(Email_20);
                    message.To.Add(Email_21);
                    message.To.Add(Email_22);
                    message.To.Add(Email_23);
                    message.To.Add(Email_24);
                    message.To.Add(Email_25);
                    message.To.Add(Email_26);
                    message.To.Add(Email_27);
                    message.To.Add(Email_28);
                    message.To.Add(Email_29);
                    message.To.Add(Email_30);
                    message.To.Add(Email_31);
                    message.To.Add(Email_32);
                    message.To.Add(Email_33);
                    message.To.Add(Email_34);
                    message.To.Add(Email_35);
                    message.To.Add(Email_36);
                    message.To.Add(Email_37);
                    message.To.Add(Email_38);
                    message.To.Add(Email_39);
                    message.To.Add(Email_40);
                    message.Subject = "Notificacion No conformidad";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedlmagen1("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                    client.Send(message);

                }
                else if (dt.Rows.Count > 41)
                {
                    MessageBox.Show("Numero de destinatarios maximo alcanzado  contacte con soporte");
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
        private void Consulta_Filtrada_Click(object sender, EventArgs e)
        {


            this.no_ConformidadesTableAdapter.Filtro_Status(cBR_No_Conf.No_Conformidades, CB_Status.Text);


        }

        private void Btn_Departamento_Click(object sender, EventArgs e)
        {
            this.no_ConformidadesTableAdapter.Filtro_Departamento(cBR_No_Conf.No_Conformidades, CB_Departamento.Text);
        }

        private void Btn_Responsable_Click(object sender, EventArgs e)
        {
            this.no_ConformidadesTableAdapter.filtro_Responsable(cBR_No_Conf.No_Conformidades, CB_Responsable.Text);
        }

        private void Btn_Fecha_Reporte_Click(object sender, EventArgs e)
        {
            DateTime FechaCierre = DateTime.Parse(CB_Fecha_CompromisoAC.Text);
            DateTime FechaCompromiso = DateTime.Parse(CB_Fecha_Compromiso.Text);
            DateTime FechaReporte = DateTime.Parse(CB_Fecha_Reporte.Text);

            this.no_ConformidadesTableAdapter.Filtro_fecha_Reporte(cBR_No_Conf.No_Conformidades, FechaReporte);
        }

        private void Bnt_Fecha_Compromiso_Click(object sender, EventArgs e)
        {

            DateTime FechaCompromiso = DateTime.Parse(CB_Fecha_Compromiso.Text);


            this.no_ConformidadesTableAdapter.Filtro_Fecha_Compromiso(cBR_No_Conf.No_Conformidades, FechaCompromiso);
        }

        private void BTn_FechaCompromisoAc_Click(object sender, EventArgs e)
        {
            DateTime FechaCompromisoAC = DateTime.Parse(CB_Fecha_CompromisoAC.Text);
            this.no_ConformidadesTableAdapter.Filtro_Fecha_CompromisoAC(cBR_No_Conf.No_Conformidades, FechaCompromisoAC);
        }

        private void Btn_Fecha_Cierre_Click(object sender, EventArgs e)
        {
            DateTime Fechacierre = DateTime.Parse(CB_Fecha_Cierre.Text);
            this.no_ConformidadesTableAdapter.Filtro_Fecha_Cierre(cBR_No_Conf.No_Conformidades, Fechacierre);
        }
        private void Exporta_Click(object sender, EventArgs e)
        {
            ThreadStart proceso = new ThreadStart(MostrarCuadroInicio);
            Thread hilo = new Thread(proceso);
            try
            {
                SaveFileDialog Fichero = new SaveFileDialog();
                Fichero.Filter = "Archivos de Excel (*.xls)|*.xls";
                Fichero.Title = "Seleccione el archivo de Excel";//le damos un titulo a la ventana
                Fichero.FileName = string.Empty;
                if (Fichero.ShowDialog() == DialogResult.OK)
                {

                    hilo.Start(); hilo.Join(200);
                    Microsoft.Office.Interop.Excel.Application aplicacion;
                    Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
                    Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;

                    aplicacion = new Microsoft.Office.Interop.Excel.Application();
                    libros_trabajo = aplicacion.Workbooks.Add(Type.Missing);
                    hoja_trabajo = null;
                    hoja_trabajo = libros_trabajo.Sheets["Hoja1"];
                    hoja_trabajo = libros_trabajo.ActiveSheet;
                    //hoja_trabajo.name



                    for (int i = 1; i < DG_NC.Columns.Count + 1; i++)
                    {
                        hoja_trabajo.Cells[1, i] = DG_NC.Columns[i - 1].HeaderText;

                    }
                    // storing Each row and column value to excel sheet  
                    for (int i = 0; i < DG_NC.Rows.Count - 1; i++)
                    {

                        for (int j = 0; j < DG_NC.Columns.Count; j++)
                        {
                            hoja_trabajo.Cells[i + 2, j + 1].NumberFormat = "@";
                            hoja_trabajo.Cells[i + 2, j + 1] = DG_NC.Rows[i].Cells[j].Value.ToString();
                        }
                    }


                    libros_trabajo.SaveAs(Fichero.FileName,
                        Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                    libros_trabajo.Close(true);
                    aplicacion.Quit();
                    hilo.Abort(); hilo.Join(200);
                    MessageBox.Show("Exportado");
                    hilo.Join(200);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
        }
        private void GenerarReporte_Click(object sender, EventArgs e)
        {
          

     
            int INC1 = Int32.Parse(NC1.Text);
            int INC2 = Int32.Parse(NC2.Text);
            this.no_ConformidadesTableAdapter.GeneraReporte(cBR_No_Conf.No_Conformidades, INC1, INC2);

        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.no_ConformidadesTableAdapter.Fill(cBR_No_Conf.No_Conformidades);
        }

        String Rep_proceso, Proceso_origen, DescripcionAC, Doc_Modificar, FechaompromisoAC, FechaCierreAC2, ResponsableAC, ResultadoAC, Fecha_Verifiacionq, Eliminacion_Causa, AC_Efica;
        private void Generar_Click(object sender, EventArgs e)
        {
            ThreadStart proceso = new ThreadStart(MostrarCuadroInicio); Thread hilo = new Thread(proceso);
            hilo.Start();
            DateTime FechaReporte1 = DateTime.Parse(FechaReporte);
            DateTime FechaCompromiso1 = DateTime.Parse(FechaCompromiso);
            DateTime FechaCompromisoAC1 = DateTime.Parse(FechaompromisoAC);
            DateTime FechaCierreAC1 = DateTime.Parse(FechaCierreAC2);
            DateTime Fecha_Verifiacion = DateTime.Parse(Fecha_Verifiacionq);


            DialogResult Resultado2;
            Resultado2 = MessageBox.Show("Está seguro que desea actualizar el registro seleccionado ", "Confirmación", MessageBoxButtons.YesNo);
            if (Resultado2 == DialogResult.Yes)
            {
                this.no_ConformidadesTableAdapter.Actualiza(Tipo, Status, FechaReporte1, Persona_Reporta, Descripcion_NC, Descripcion_CR, FechaCompromiso1, Responsables, Resultado, PersonaAC, CategoriaCausa, Analisis_causas, Rep_proceso, Proceso_origen, DescripcionAC, Doc_Modificar, FechaCompromiso1, FechaCierreAC1, ResponsableAC, ResultadoAC, Fecha_Verifiacion, Eliminacion_Causa, AC_Efica, UsuarioKey);
                hilo.Abort();
            }
            else if (Resultado2 == DialogResult.No)
            {

                MessageBox.Show("Operacion Cancelada");
                hilo.Abort();
            }
            this.no_ConformidadesTableAdapter.Fill(cBR_No_Conf.No_Conformidades);

        



        }

        private void MostrarCuadroInicio()
        {
            Loading Cargando = new Loading();
            Cargando.ShowDialog();

        }

       
        private void Actualizacion_NC_Load(object sender, EventArgs e)
        {
            this.no_ConformidadesTableAdapter.Fill(this.cBR_No_Conf.No_Conformidades);
            this.login_DepartamentosTableAdapter.Fill(this.cBR_Login_Dep.Login_Departamentos);
        }

        private void DG_NC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex > 0)
                {
                    UsuarioKey = Convert.ToInt32(DG_NC.Rows[e.RowIndex].Cells[0].FormattedValue.ToString());


                    Tipo = DG_NC.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                    Status = DG_NC.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
                    FechaReporte = DG_NC.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
                    Persona_Reporta = DG_NC.Rows[e.RowIndex].Cells[4].FormattedValue.ToString();
                    Descripcion_NC = DG_NC.Rows[e.RowIndex].Cells[5].FormattedValue.ToString();
                    Descripcion_CR = DG_NC.Rows[e.RowIndex].Cells[6].FormattedValue.ToString();
                    FechaCompromiso = DG_NC.Rows[e.RowIndex].Cells[7].FormattedValue.ToString();
                    Responsables = DG_NC.Rows[e.RowIndex].Cells[8].FormattedValue.ToString();
                    Resultado = DG_NC.Rows[e.RowIndex].Cells[9].FormattedValue.ToString();
                    PersonaAC = DG_NC.Rows[e.RowIndex].Cells[10].FormattedValue.ToString();
                    CategoriaCausa = DG_NC.Rows[e.RowIndex].Cells[11].FormattedValue.ToString();
                    Analisis_causas = DG_NC.Rows[e.RowIndex].Cells[12].FormattedValue.ToString();
                    Rep_proceso = DG_NC.Rows[e.RowIndex].Cells[13].FormattedValue.ToString();
                    Proceso_origen = DG_NC.Rows[e.RowIndex].Cells[14].FormattedValue.ToString();
                    DescripcionAC = DG_NC.Rows[e.RowIndex].Cells[15].FormattedValue.ToString();
                    Doc_Modificar = DG_NC.Rows[e.RowIndex].Cells[16].FormattedValue.ToString();
                    FechaompromisoAC = DG_NC.Rows[e.RowIndex].Cells[17].FormattedValue.ToString();
                    FechaCierreAC2 = DG_NC.Rows[e.RowIndex].Cells[18].FormattedValue.ToString();
                    ResponsableAC = DG_NC.Rows[e.RowIndex].Cells[19].FormattedValue.ToString();
                    ResultadoAC = DG_NC.Rows[e.RowIndex].Cells[20].FormattedValue.ToString();
                    Fecha_Verifiacionq = DG_NC.Rows[e.RowIndex].Cells[21].FormattedValue.ToString();
                    Eliminacion_Causa = DG_NC.Rows[e.RowIndex].Cells[22].FormattedValue.ToString();
                    AC_Efica = DG_NC.Rows[e.RowIndex].Cells[23].FormattedValue.ToString();

                    Key.Text = UsuarioKey.ToString();
                }
                else
                {

                    UsuarioKey = 0;
                    Key.Text = UsuarioKey.ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }
    }
}
