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
    public partial class Cierre_No_confor : UserControl
    {


        private static Cierre_No_confor _instance;
        public static Cierre_No_confor Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Cierre_No_confor();
                return _instance;
            }


        }
        public Cierre_No_confor()
        {
            InitializeComponent();
        }
      
        String Email1, Email2, Email3, Email4, Email5, Email6, Email7, Email8, Email9, Email10;
        String Departamento;
        String dato;
        public static string ObtenerCadena()
        {
            return Settings.Default.CBR_IngenieriaConnectionString;/*Este codigo obtiene los datos de la cadena de conexion declarada en los settings de la aplicacion*/
        }
        SqlConnection conexion = new SqlConnection(ObtenerCadena());
        private void MostrarCuadroInicio()
        {
          
           
        }
        private void Cierre_No_confor_Load(object sender, EventArgs e)
        {
            ThreadStart proceso = new ThreadStart(MostrarCuadroInicio); Thread hilo = new Thread(proceso);
        hilo.Start();     hilo.Join(200);

            this.no_ConformidadesTableAdapter.consulta2020(this.cBR_No_Conf.No_Conformidades);
            this.departamentosTableAdapter.Fill(this.cBR_Departamento.Departamentos);
            this.nC_ResponsableTableAdapter.Fill(this.cBR_Responsable.NC_Responsable);
            this.nC_Fecha_ReporteTableAdapter.Fill(this.cBR_Fecha_Reporte.NC_Fecha_Reporte);
            this.nC_Fecha_CompromisoTableAdapter.Fill(this.cBR_Fecha_Compromiso.NC_Fecha_Compromiso);
            this.nC_Fecha_Compromiso_ACTableAdapter.Fill(this.cBR_Fecha_Compromiso_AC.NC_Fecha_Compromiso_AC);
            this.nC_Fecha_Cierre_ACTableAdapter.Fill(this.cBR_Fecha_Cierre_AC.NC_Fecha_Cierre_AC);
            this.login_DepartamentosTableAdapter.Fill(this.cBR_Login_Dep.Login_Departamentos);

            hilo.Abort();
        }
      
        private void Generar_Click(object sender, EventArgs e)
        {
            ThreadStart proceso = new ThreadStart(MostrarCuadroInicio);
            Thread hilo = new Thread(proceso);


            DialogResult Resultado;
            Resultado = MessageBox.Show("Está seguro que desea actualizar el registro seleccionado ", "Confirmación", MessageBoxButtons.YesNo);
            if (Resultado == DialogResult.Yes)
            {
            hilo.Start();     hilo.Join(200);
                int NoConf = Int32.Parse(NumeroNC.Text);
                DateTime Fechaf = DateTime.Parse(Fechacompromiso.Text);
                this.no_ConformidadesTableAdapter.Cierre_NC(Status.Text, Fechaf, CB_Causa.Text, CB_Causa.Text, NoConf);
                this.no_ConformidadesTableAdapter.Fill(cBR_No_Conf.No_Conformidades);
                this.no_Conformidades_usuarioTableAdapter.Actualiza("Cerrada", NoConf);
                enviamasivo(Key_Dep.Text);
                hilo.Abort();
            }
            else if (Resultado == DialogResult.No)
            {
                hilo.Abort();
                MessageBox.Show("Operacion Cancelada");
            }

         ;
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
                    message.Subject = "Cierre de No conformidad";
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
                    message.Subject = "Cierre de No conformidad";
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
                    message.Subject = "Cierre de No conformidad";
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
                    message.Subject = "Cierre de No conformidad";
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
                    message.Subject = "Cierre de No conformidad";
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
                    message.Subject = "Cierre de No conformidad";
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
                    message.Subject = "Cierre de No conformidad";
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
                    message.Subject = "Cierre de No conformidad";
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
                    message.Subject = "Cierre de No conformidad";
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
                    message.Subject = "Cierre de No conformidad";
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
                String Body = "<DIV><H5>Se ha cerrado una no conformidad</HEAD></DIV></H>";
                Body += "<DIV>Ingrese a su perfil para vericarla </DIV>";




                string htmlBody = "" + Body + "" + @"<img src='cid:" + res.ContentId + @"'/> ";
                AlternateView alternateView = AlternateView.CreateAlternateViewFromString(htmlBody,
                 null, MediaTypeNames.Text.Html);
                alternateView.LinkedResources.Add(res);
                return alternateView;
            }

        private void GenerarReporte_Click(object sender, EventArgs e)
        {
            ThreadStart proceso = new ThreadStart(MostrarCuadroInicio);
            Thread hilo = new Thread(proceso);

        hilo.Start();     hilo.Join(200);
            int INC1 = Int32.Parse(NC1.Text);
            int INC2 = Int32.Parse(NC2.Text);
            INC2 = INC2 +1;
            this.no_ConformidadesTableAdapter.GeneraReporte(cBR_No_Conf.No_Conformidades, INC1,INC2);
        


            hilo.Abort();
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
                
                 

                    for (int i = 1; i < DG_genera.Columns.Count + 1; i++)
                    {
                        hoja_trabajo.Cells[1, i] = DG_genera.Columns[i - 1].HeaderText;

                    }
                    // storing Each row and column value to excel sheet  
                    for (int i = 0; i < DG_genera.Rows.Count - 1; i++)
                    {

                        for (int j = 0; j < DG_genera.Columns.Count; j++)
                        {
                            hoja_trabajo.Cells[i + 2, j + 1].NumberFormat = "@";
                            hoja_trabajo.Cells[i + 2, j + 1] = DG_genera.Rows[i].Cells[j].Value.ToString();
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

        private void DG_genera_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex > 0)
                {
                    Departamento = Convert.ToString(DG_genera.Rows[e.RowIndex].Cells[0].FormattedValue.ToString());
                    Departamento = DG_genera.Rows[e.RowIndex].Cells[24].FormattedValue.ToString();
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
                    Departamento = Convert.ToString(DG_genera.Rows[e.RowIndex].Cells[0].FormattedValue.ToString());
                    Departamento = DG_genera.Rows[e.RowIndex].Cells[24].FormattedValue.ToString();
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.no_ConformidadesTableAdapter.consulta2020(cBR_No_Conf.No_Conformidades);
        }


        private void DG_genera_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {

            DG_genera[0, e.RowIndex].Style.BackColor = Color.Gray;
            DG_genera[1, e.RowIndex].Style.BackColor = Color.Gray;
            DG_genera[2, e.RowIndex].Style.BackColor = Color.Gray;
            DG_genera[3, e.RowIndex].Style.BackColor = Color.Gray;
            DG_genera[4, e.RowIndex].Style.BackColor = Color.Gray;
            DG_genera[5, e.RowIndex].Style.BackColor = Color.Gray;
            DG_genera[6, e.RowIndex].Style.BackColor = Color.SteelBlue;
            DG_genera[7, e.RowIndex].Style.BackColor = Color.SteelBlue;
            DG_genera[8, e.RowIndex].Style.BackColor = Color.SteelBlue;
            DG_genera[9, e.RowIndex].Style.BackColor = Color.SteelBlue;
            DG_genera[10, e.RowIndex].Style.BackColor = Color.LimeGreen;
            DG_genera[11, e.RowIndex].Style.BackColor = Color.LimeGreen;
            DG_genera[12, e.RowIndex].Style.BackColor = Color.LimeGreen;
            DG_genera[13, e.RowIndex].Style.BackColor = Color.LimeGreen;
            DG_genera[14, e.RowIndex].Style.BackColor = Color.LimeGreen;
            DG_genera[15, e.RowIndex].Style.BackColor = Color.LimeGreen;
            DG_genera[16, e.RowIndex].Style.BackColor = Color.Goldenrod;
            DG_genera[17, e.RowIndex].Style.BackColor = Color.Goldenrod;
            DG_genera[18, e.RowIndex].Style.BackColor = Color.Goldenrod;
            DG_genera[19, e.RowIndex].Style.BackColor = Color.Goldenrod;
            DG_genera[20, e.RowIndex].Style.BackColor = Color.Goldenrod;
            DG_genera[21, e.RowIndex].Style.BackColor = Color.Gold;
            DG_genera[22, e.RowIndex].Style.BackColor = Color.Gold;
            DG_genera[23, e.RowIndex].Style.BackColor = Color.Gold;









        }

        private void DG_genera_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dato = DG_genera.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValue.ToString();

            MessageBox.Show("" + dato);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.no_ConformidadesTableAdapter.Fill(cBR_No_Conf.No_Conformidades);
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

       

   
    }
    }


