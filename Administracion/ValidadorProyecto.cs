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

namespace CBR_ADMIN.Administracion
{
    public partial class ValidadorProyecto : Form
    {
        string codigo,codig2,codig3,body2;

        private void ValidadorProyecto_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'verificador.Verificacion_Proyecto' Puede moverla o quitarla según sea necesario.
            this.verificacion_ProyectoTableAdapter.Fill(this.verificador.Verificacion_Proyecto);
            // TODO: esta línea de código carga datos en la tabla 'cBR_Login_Dep.Login_Departamentos' Puede moverla o quitarla según sea necesario.
            this.login_DepartamentosTableAdapter.Fill(this.cBR_Login_Dep.Login_Departamentos);
            // TODO: esta línea de código carga datos en la tabla 'verificador.Verificacion_Proyecto' Puede moverla o quitarla según sea necesario.
            this.verificacion_ProyectoTableAdapter.Fill(this.verificador.Verificacion_Proyecto);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult Resultado;
            Resultado = MessageBox.Show("Está seguro que desea enviar correo", "Confirmación", MessageBoxButtons.YesNo);
            if (Resultado == DialogResult.Yes)
            {
          
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
              
                MailMessage message = new MailMessage(_sender, comboBox1.Text);
                message.Subject = "Correo enviado atraves de CBR APP  ";
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

        private AlternateView getEmbeddedlmagen2(String filePath)
        {
            body2 = "El codigo para dar de alta el proyecto:" + "\t" + textBox1.Text + " \t" + "es:" + label2.Text;
            // mail clients. previous solution only displays in Gmail the inline images 
            LinkedResource res = new LinkedResource(filePath, MediaTypeNames.Image.Jpeg);
            res.ContentId = Guid.NewGuid().ToString();
            String Body = "<DIV><H5>El codigo para dar de alta el proyecto:"+textBox1.Text+"</DIV></H>";
            Body += "<DIV>Es:"+label2.Text+ "</DIV>";
            string htmlBody = "" + Body + "" + @"<img src='cid:" + res.ContentId + @"'/> ";
            AlternateView alternateView = AlternateView.CreateAlternateViewFromString(htmlBody,
             null, MediaTypeNames.Text.Html);
            alternateView.LinkedResources.Add(res);
            return alternateView;
        }
        public ValidadorProyecto()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox1.Text == null) { MessageBox.Show(this, "Ingrese el nombre de Proyecto "); }
            else
            {
                DateTime.Now.ToString("HH:mm:ss");
                codigo = DateTime.Now.ToString("HH");
                codig2 = DateTime.Now.ToString("mm");
                codig3 = DateTime.Now.ToString("ss");
                label2.Text = codigo + textBox1.Text + codig2 + "x¡" + codig3;
                verificacion_ProyectoTableAdapter.Genera(label2.Text, textBox1.Text);
                MessageBox.Show(this, "Codigo Generado correctamente ");
            }
        }
    }
}
