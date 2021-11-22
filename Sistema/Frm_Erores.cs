using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CBR_ADMIN.Sistema
{
    public partial class Frm_Erores : Form
    {
        public Frm_Erores()
        {
            InitializeComponent();
        }
        String Email_1,body;
        private void btn_EnviarError_Click(object sender, EventArgs e)
        {
            DialogResult Resultado;
            Resultado = MessageBox.Show("Está seguro que desea enviar correo", "Confirmación", MessageBoxButtons.YesNo);
            if (Resultado == DialogResult.Yes)
            {
                Email_1 = Mensaje.Text;
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
                body = Mensaje.Text;
                MailMessage message = new MailMessage(_sender, "jose.orzuna@igrtec.com");
                message.Subject = "Correo enviado atraves de CBR APP  " + "Notificacion de Errores" ;
                message.IsBodyHtml = true;
                message.AlternateViews.Add(getEmbeddedlmagen1("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                client.Send(message);
                MessageBox.Show("Correo enviado");
            }
            else if (Resultado == DialogResult.No)
            {

                MessageBox.Show("Operacion Cancelada");


            }
            this.Close();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private AlternateView getEmbeddedlmagen1(String filePath)
        {
  
            // mail clients. previous solution only displays in Gmail the inline images 
            LinkedResource res = new LinkedResource(filePath, MediaTypeNames.Image.Jpeg);
            res.ContentId = Guid.NewGuid().ToString();
            string htmlBody = body;
            AlternateView alternateView = AlternateView.CreateAlternateViewFromString(htmlBody,
             null, MediaTypeNames.Text.Html);
            alternateView.LinkedResources.Add(res);
            return alternateView;
        }


    }
}
