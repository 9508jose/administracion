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
using System.Net.Mail;
using System.Net.Mime;
using CBR_ADMIN.Properties;
using CBR_ADMIN.Sistema;
using System.Threading;

namespace CBR_ADMIN.Administracion
{
    public partial class Ciere_Accion_Mejora : UserControl
    {
        private static Ciere_Accion_Mejora _instance;
        public static Ciere_Accion_Mejora Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Ciere_Accion_Mejora();
                return _instance;
            }


        }

        public Ciere_Accion_Mejora()
        {
            InitializeComponent();
        }
        String Email1, Email2, Email3, Email4, Email5, Email6, Email7, Email8, Email9, Email10;
        String dato;
        public string Departamento, Nombre, Ventana1;
        public static string ObtenerCadena()
        {
            return Settings.Default.CBR_IngenieriaConnectionString;/*Este codigo obtiene los datos de la cadena de conexion declarada en los settings de la aplicacion*/
        }
        SqlConnection conexion = new SqlConnection(ObtenerCadena());

        private void Btn_Responsable_Click(object sender, EventArgs e)
        {
            this.op_MejoraTableAdapter.Filtro_Responsable(cBR_No_Oportunidad.Op_Mejora, CB_Responsable.Text);
       
        }

        private void Btn_Status_Click(object sender, EventArgs e)
        {
            this.op_MejoraTableAdapter.Filtro_Status(cBR_No_Oportunidad.Op_Mejora, CB_Status.Text);
       
        }

        private void Btn_Fecha_Reporte_Click(object sender, EventArgs e)
        {
           
            DateTime FechaReporte = DateTime.Parse(CB_Fecha_Reporte.Text);
        
            this.op_MejoraTableAdapter.Filtro_FechaReporte(cBR_No_Oportunidad.Op_Mejora, FechaReporte);
    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.op_MejoraTableAdapter.Filtro_Proceso(cBR_No_Oportunidad.Op_Mejora, CB_Proceso.Text);
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ThreadStart proceso = new ThreadStart(MostrarCuadroInicio);
            Thread hilo = new Thread(proceso);

           hilo.Start();     hilo.Join(200);
            this.op_MejoraTableAdapter.Fill(cBR_No_Oportunidad.Op_Mejora);
            hilo.Abort();
        }

        private void Btn_Fecha_Cierre_Click(object sender, EventArgs e)
        {
            DateTime FechaCierre = DateTime.Parse(CB_Fecha_Cierre.Text);
            this.op_MejoraTableAdapter.Filtro_fechacierre(cBR_No_Oportunidad.Op_Mejora, FechaCierre);
        }

        private void DG_CiereAM_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dato = DG_CiereAM.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValue.ToString();

            MessageBox.Show("" + dato);
        }

        private void DG_CiereAM_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Bnt_Fecha_Compromiso_Click(object sender, EventArgs e)
        {
            DateTime Fechacompromiso = DateTime.Parse(CB_Fecha_Compromiso.Text);
     
            this.op_MejoraTableAdapter.Filtro_fechacompromiso(cBR_No_Oportunidad.Op_Mejora, Fechacompromiso);

        }

   

        private void Cerrar_Click(object sender, EventArgs e)
        {
            int NoConf = Int32.Parse(NumeroNC.Text);
            ThreadStart proceso = new ThreadStart(MostrarCuadroInicio); Thread hilo = new Thread(proceso);
           
            DialogResult Resultado;
            Resultado = MessageBox.Show("Está seguro que desea cerrar la Accion de Mejora seleccionada ", "Confirmación", MessageBoxButtons.YesNo);
            if (Resultado == DialogResult.Yes)
            {
               hilo.Start();     hilo.Join(200);
                this.op_MejoraTableAdapter.CierraAM(NoConf);
                this.op_MejoraTableAdapter.Fill(cBR_No_Oportunidad.Op_Mejora);
                this.no_Accion_usuarioTableAdapter.Actualiza("Cierra",NoConf);
                enviamasivo(Key_Dep.Text);
                MessageBox.Show("Accion de Mejora Cerrada correctamente");

                hilo.Abort(); 
            }
            else if (Resultado == DialogResult.No)
            {

                MessageBox.Show("Operacion Cancelada");

                hilo.Abort();
            }

           
         
        }

        private void Btn_Departamento_Click(object sender, EventArgs e)
        {
            
            this.op_MejoraTableAdapter.Filtro_Departamento(cBR_No_Oportunidad.Op_Mejora, CB_Departamento.Text);
   
        }
   
        private void Ciere_Accion_Mejora_Load(object sender, EventArgs e)
        {
            this.op_MejoraTableAdapter.Fill(cBR_No_Oportunidad.Op_Mejora);
        }

        public void enviamasivo(string Departamento)
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
                cmd.Parameters.AddWithValue("Departamento", Key_Dep.Text);



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
                    message.Subject = "Cierre de Accion de Mejora";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Cierre de Accion de Mejora";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Cierre de Accion de Mejora";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Cierre de Accion de Mejora";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Cierre de Accion de Mejora";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Cierre de Accion de Mejora";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Cierre de Accion de Mejora";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Cierre de Accion de Mejora";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Cierre de Accion de Mejora";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Cierre de Accion de Mejora";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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

        private AlternateView getEmbeddedImage(String filePath)
        {
            // below line was corrected to include the mediatype so it displays in all 
            // mail clients. previous solution only displays in Gmail the inline images 
            LinkedResource res = new LinkedResource(filePath, MediaTypeNames.Image.Jpeg);
            res.ContentId = Guid.NewGuid().ToString();
            String Body = "<DIV><H5>Se ha cerrado una Accion de mejora </HEAD></DIV></H>";
            Body += "<DIV>Ingrese a su perfil para vericarla </DIV>";




            string htmlBody = "" + Body + "" + @"<img src='cid:" + res.ContentId + @"'/> ";
            AlternateView alternateView = AlternateView.CreateAlternateViewFromString(htmlBody,
             null, MediaTypeNames.Text.Html);
            alternateView.LinkedResources.Add(res);
            return alternateView;
        }
        private void MostrarCuadroInicio()
        {
            Loading Cargando = new Loading();
            Cargando.ShowDialog();
          
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

                   hilo.Start();     hilo.Join(200);





                    Microsoft.Office.Interop.Excel.Application aplicacion;
                    Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
                    Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;

                    aplicacion = new Microsoft.Office.Interop.Excel.Application();
                    libros_trabajo = aplicacion.Workbooks.Add(Type.Missing);
                    hoja_trabajo = null;
                    hoja_trabajo = libros_trabajo.Sheets["Hoja1"];
                    hoja_trabajo = libros_trabajo.ActiveSheet;
                    //hoja_trabajo.name



                    for (int i = 1; i < DG_CiereAM.Columns.Count + 1; i++)
                    {
                        hoja_trabajo.Cells[1, i] = DG_CiereAM.Columns[i - 1].HeaderText;

                    }
                    // storing Each row and column value to excel sheet  
                    for (int i = 0; i < DG_CiereAM.Rows.Count - 1; i++)
                    {

                        for (int j = 0; j < DG_CiereAM.Columns.Count; j++)
                        {
                            hoja_trabajo.Cells[i + 2, j + 1].NumberFormat = "@";
                            hoja_trabajo.Cells[i + 2, j + 1] = DG_CiereAM.Rows[i].Cells[j].Value.ToString();
                        }
                    }

                    libros_trabajo.SaveAs(Fichero.FileName,
                        Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
                    libros_trabajo.Close(true);
                    aplicacion.Quit();
                    hilo.Abort();
                    MessageBox.Show("Exportado");
                  
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
        }

        private void DG_genera_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex > 0)
                {
                    Departamento = Convert.ToString(DG_CiereAM.Rows[e.RowIndex].Cells[0].FormattedValue.ToString());
                    Departamento = DG_CiereAM.Rows[e.RowIndex].Cells[11].FormattedValue.ToString();
                    Key_Dep.Text = Departamento.ToString();

                }
                else
                {
                    Departamento = "0";
                    Key_Dep.Text = Departamento.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }

        private void DG_genera_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex > 0)
                {
                    Departamento = Convert.ToString(DG_CiereAM.Rows[e.RowIndex].Cells[0].FormattedValue.ToString());
                    Departamento = DG_CiereAM.Rows[e.RowIndex].Cells[11].FormattedValue.ToString();
                    Key_Dep.Text = DG_CiereAM.ToString();

                }
                else
                {
                    Departamento = "0";
                    Key_Dep.Text = Departamento.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }
        private void GenerarReporte_Click(object sender, EventArgs e)
        {
            ThreadStart proceso = new ThreadStart(MostrarCuadroInicio);
            Thread hilo = new Thread(proceso);
           hilo.Start();     hilo.Join(200);
            int INC1 = Int32.Parse(NC1.Text);
            int INC2 = Int32.Parse(NC2.Text);
            this.op_MejoraTableAdapter.GeneraReporte(cBR_No_Oportunidad.Op_Mejora, INC1, INC2);
            hilo.Abort();
        }

    }
}
