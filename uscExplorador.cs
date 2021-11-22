using CBR_ADMIN.Properties;
using CBR_ADMIN.Sistema;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CBR_ADMIN
{

    public partial class uscExplorador : UserControl
    {
        public string usuario, apellido, emailusuario, departamento, formato;
        public string valor = "", valor2 = "";
        public string contadorcar = "";
        public string Nombre1 = "";
        Process p = new Process();
        public string anorastreo, proyectorastreo, carpetarastreo, codifica, nomproyec1;
        string carptape, proyectoras;
        string url="";
        int numerador; string Nombre; int suma, k;
        int indicador = 0;
        String Email1, Email2, Email3, Email4, Email5, Email6, Email7, Email8, Email9, Email10;

        string Año2 = "";
        string tipo3 = "";
        string Nombre2 = "";
        private static uscExplorador _instance;
        public static uscExplorador Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uscExplorador();
                return _instance;
            }
        }

        private string ruta = @"G:\SGC-PROYECTOS-CBR\SGC\";
        private Boolean esArchivo = false;
        private string nombreSeleccionado = "";

        public uscExplorador()
        {
            InitializeComponent();
        }

        public static string ObtenerCadena()
        {
            return Settings.Default.CBR_IngenieriaConnectionString;/*Este codigo obtiene los datos de la cadena de conexion declarada en los settings de la aplicacion*/

        }

        private void Explorador_Load(object sender, EventArgs e)
        {
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            txtRuta.Text = ruta;
            cargarArchivosYDirecterios();
        }

        public void cargarArchivosYDirecterios()
        {
            DirectoryInfo listaDeArchivos;
            string rutaTemporal = "";
            FileAttributes atributos;
            try
            {
                if (esArchivo)
                {
                    rutaTemporal = ruta + "\\" + nombreSeleccionado;
                    atributos = File.GetAttributes(rutaTemporal);
                    FileInfo detalles = new FileInfo(rutaTemporal); //La ruta del archivo se manda al FileInfo para conseguir su datos//Consigue los atributos del archivo, para que con esto comparar mas adelante si es un archivo o directorio
                    Process.Start(rutaTemporal);
                }
                else
                {
                    atributos = File.GetAttributes(ruta);  //Consigue los atributos del directorio, para comprobar mas adelante
                }

                if ((atributos & FileAttributes.Directory) == FileAttributes.Directory) //Revisa si es un directorio
                {
                    listaDeArchivos = new DirectoryInfo(ruta);
                    FileInfo[] archivos = listaDeArchivos.GetFiles(); // OBTIENE TODOS LOS ARCHIVOS
                    DirectoryInfo[] directorios = listaDeArchivos.GetDirectories(); //OBTIENE TODOS LOS DIRECTORIOS

                    lsbExplorador.Clear();


                    var filtradodirec = directorios.Where(f => !f.Attributes.HasFlag(FileAttributes.Hidden));

                    foreach (var f in filtradodirec)
                    {

                        lsbExplorador.Items.Add(f.ToString(), 1);
                    }

                    var filtradoarchivos = archivos.Where(f => !f.Attributes.HasFlag(FileAttributes.Hidden));

                    foreach (var f in filtradoarchivos)
                    {

                        String extension = f.Extension.ToUpper();
                        int index = 0;

                        switch (extension)
                        {
                            case ".DOC":
                            case ".DOCX":
                                index = 2;
                                break;
                            case ".EXE":
                                index = 3;
                                break;
                            case ".PDF":
                                index = 4;
                                break;
                            case ".XLSX":
                            case ".XLS":
                                index = 5;
                                break;
                            case ".JPG":
                            case ".JPEG":
                                index = 6;
                                break;
                            case ".PNG":
                                index = 7;
                                break;
                            case ".TXT":
                                index = 8;
                                break;
                            case ".RAR":
                                index = 9;
                                break;
                            case ".ZIP":
                                index = 10;
                                break;
                            case ".PPT":
                            case ".PPTX":
                                index = 11;
                                break;
                            default:
                                index = 0;
                                break;
                        }

                        lsbExplorador.Items.Add(f.ToString(), index);
                    }

                }
                else
                {
                    lblDatoNombre.Text = this.nombreSeleccionado;
                }
            }
            catch (Exception e)
            {

            }
        }

        public void cargarArchivos() //Si se coloca algo en la ruta nuevo en el enlace nos dirige ahi
        {
            ruta = txtRuta.Text;
            cargarArchivosYDirecterios();
            esArchivo = false;
        }

        private void btnIr_Click(object sender, EventArgs e) //Si se ha click realiza el evento cargarArchivos
        {
            cargarArchivos();
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e) //Seleccionado un objeto
        {
            nombreSeleccionado = e.Item.Text;

            FileAttributes atributos = File.GetAttributes(ruta + @"\" + nombreSeleccionado); //Con esto el archivo/directorio seleccionado se consiguen sus atributos para saber si es un directorio o archivo

            if ((atributos & FileAttributes.Directory) == FileAttributes.Directory) //Se revisa
            {
                esArchivo = false;                       //Si es cierto, no es un archivo es un directorio y se pone en la ruta
                txtRuta.Text = ruta + @"\" + nombreSeleccionado;
            }
            else
            {
                esArchivo = true; //Si es falso, es un archivo
                String rutaTemporal = ruta + "\\" + nombreSeleccionado;
                FileInfo detalles = new FileInfo(rutaTemporal); //La ruta del archivo se manda al FileInfo para conseguir su datos
                lblDatoNombre.Text = detalles.Name;  //Consigue el nombre
                lblDatoTipo.Text = detalles.Extension; //Consigue el tipo
                lblDatoTamaño.Text = BytesAString(detalles.Length);

            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e) //Si se realiza doble click manda al archivo seleccionado, misma funcion que el boton ir, pero en los directorios
        {
            cargarArchivos();
        }

        private void btnCasa_Click(object sender, EventArgs e)
        {
            txtRuta.Text = @"G:\SGC-PROYECTOS-CBR\SGC\";
            cargarArchivos();

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {

          

            rastreadorproyecto();
            string url1;
            url1 = @"G:\SGC-PROYECTOS-CBR\SGC\" + Año2 + "\\" + tipo3 + "\\" + valor;
            string url2 = txtRuta.Text;
            if (Proyecto.Text == "")
            {
                String rutaAnterior = txtRuta.Text;
                if (rutaAnterior != @"G:\SGC-PROYECTOS-CBR\SGC\")
                {
                    rutaAnterior = rutaAnterior.Substring(0, rutaAnterior.LastIndexOf(@"\"));
                    esArchivo = false;
                    txtRuta.Text = rutaAnterior;
                    cargarArchivos();
                }
            }

            else if (url1 != url2)
            {
                String rutaAnterior = txtRuta.Text;
                if (rutaAnterior != @"G:\SGC-PROYECTOS-CBR\SGC\")
                {
                    rutaAnterior = rutaAnterior.Substring(0, rutaAnterior.LastIndexOf(@"\"));
                    esArchivo = false;
                    txtRuta.Text = rutaAnterior;
                    cargarArchivos();
                }
            }
            else
            {


                DialogResult Resultado;
                Resultado = MessageBox.Show("Está seguro que desea terminar la sesion en el proyecto: " + Proyecto.Text, "Confirmación", MessageBoxButtons.YesNo);
                if (Resultado == DialogResult.Yes)
                {
                    Loading apertura = new Loading();
                    apertura.Show();
                    apertura.BringToFront();
                    apertura.WindowState = FormWindowState.Normal;
                    rastreadorproyecto();
                    this.registro_AccesosTableAdapter.elimina(Proyecto.Text);



                    String rutaAnterior = txtRuta.Text;
                    if (rutaAnterior != @"G:\SGC-PROYECTOS-CBR\SGC\")
                    {
                        rutaAnterior = rutaAnterior.Substring(0, rutaAnterior.LastIndexOf(@"\"));
                        esArchivo = false;
                        txtRuta.Text = rutaAnterior;
                        cargarArchivos();
                    }




                    string strCmdText;
                    strCmdText = "/C attrib +h +s  " + "\"" + "G:\\SGC-PROYECTOS-CBR\\SGC\\" + Año2 + "\\" + tipo3 + "\\" + valor + "\\*" + "\" " + " /S /D";
                    Nombre1 = "";
                    valor = "";
                    Process cm = new Process();
                    cm.StartInfo.FileName = "cmd.exe";
                    cm.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    cm.StartInfo.Arguments = strCmdText;
                    cm.Start();
                    cm.WaitForExit();
                    apertura.Hide();
                    MessageBox.Show("Sesion cerrada correctamente");

                    this.folio_ProyectosTableAdapter.Consulta(folio_Proyectos._Folio_Proyectos, "");
                 

                }
                else if (Resultado == DialogResult.No)
                {


                    MessageBox.Show("Operacion Cancelada");
                }
            }


        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (Depa.Text != "" & carpeta.Text != "" & proye_solicita.Text != "")
            {

                DialogResult Resultado;
                Resultado = MessageBox.Show("Desea solicitar actualizacion de estado :\nCarpeta:" + carpeta.Text + "\nProyecto: " + "" + proye_solicita.Text, "Confirmación", MessageBoxButtons.YesNo);
                if (Resultado == DialogResult.Yes)
                {
                    if (Depa.Text == "") { MessageBox.Show("No ha ingresado el departamento a notificar"); }
                    if (Depa.Text != "")
                    {
                        enviamasivo2(Depa.Text);
                    }

                }
                else if (Resultado == DialogResult.No)
                {


                    MessageBox.Show("Operacion Cancelada");
                }
            }
            else if (Depa.Text == "" & carpeta.Text == "" & proye_solicita.Text == "")
            {
                MessageBox.Show("Faltan campos por llenar");
            }
            else if (Depa.Text == "")
            {
                MessageBox.Show("Faltan campos por llenar");
            }

            else if (carpeta.Text == "")
            {
                MessageBox.Show("Faltan campos por llenar");
            }
            else if (proye_solicita.Text == "")
            {
                MessageBox.Show("Faltan campos por llenar");
            }
        }
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
                cmd.Parameters.AddWithValue("Departamento", Depa.Text);



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
                    message.Subject = "Solicitud de actualizacion de Carpeta";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage("//192.168.1.101/Aplicativos/CBR Sistema global/logo_cbr.png"));
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
                    message.Subject = "Solicitud de actualizacion de Carpeta";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage("//192.168.1.101/Aplicativos/CBR Sistema global/logo_cbr.png"));
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
                    message.Subject = "Solicitud de actualizacion de Carpeta";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage("//192.168.1.101/Aplicativos/CBR Sistema global/logo_cbr.png"));
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
                    message.CC.Add(new MailAddress("sandra.cabrera@cbr-ingenieria.com.mx"));
                    message.Subject = "Solicitud de actualizacion de Carpeta";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage("//192.168.1.101/Aplicativos/CBR Sistema global/logo_cbr.png"));
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
                    message.CC.Add(new MailAddress("sandra.cabrera@cbr-ingenieria.com.mx"));
                    message.Subject = "Solicitud de actualizacion de Carpeta";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage("//192.168.1.101/Aplicativos/CBR Sistema global/logo_cbr.png"));
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
                    message.Subject = "Solicitud de actualizacion de Carpeta";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage("//192.168.1.101/Aplicativos/CBR Sistema global/logo_cbr.png"));
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
                    message.CC.Add(new MailAddress("sandra.cabrera@cbr-ingenieria.com.mx"));
                    message.Subject = "Solicitud de actualizacion de Carpeta";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage("//192.168.1.101/Aplicativos/CBR Sistema global/logo_cbr.png"));
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
                    message.Subject = "Solicitud de actualizacion de Carpeta";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage("//192.168.1.101/Aplicativos/CBR Sistema global/logo_cbr.png"));
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
                    message.Subject = "Solicitud de actualizacion de Carpeta";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage("//192.168.1.101/Aplicativos/CBR Sistema global/logo_cbr.png"));
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
                    message.Subject = "Solicitud de actualizacion de Carpeta";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage("//192.168.1.101/Aplicativos/CBR Sistema global/logo_cbr.png"));
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

        static String BytesAString(long contBytes) //Metodo para convertir en lo conseguido en file length
        {
            string[] tamaño = { "B", "KB", "MB", "GB", "TB", "PB", "EB" }; //Longs run out around EB
            if (contBytes == 0)
                return "0" + tamaño[0]; //Si es cero retorna 0 B
            long bytes = Math.Abs(contBytes);
            int lugar = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024))); //Determina a cual tamaño ira
            double num = Math.Round(bytes / Math.Pow(1024, lugar), 1);
            return (Math.Sign(contBytes) * num).ToString() + tamaño[lugar];
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Consulta_Proyectos_General hijo = new Consulta_Proyectos_General();

            hijo.Show();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            string valor = DatosGenerales.Name;
            if (valor == null || valor == "") { }
            else
            {

                this.folio_ProyectosTableAdapter.FillBy(folio_Proyectos._Folio_Proyectos, valor);
            }
        }

        private void buscador_SelectedIndexChanged(object sender, EventArgs e)
        {
      
           
        }

        private void buscador_Click(object sender, EventArgs e)
        {
          

                this.folio_ProyectosTableAdapter.Fill(folio_Proyectos._Folio_Proyectos);
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection(ObtenerCadena());
            conexion.Open();
            SqlCommand cmd = new SqlCommand(
                                   "select [Proyecto]" +
                                   "[ano], " +
                                   "[tipo], " +
                                   "[Usuario] " +

                                   "from [Registro_Accesos]  where Proyecto=@proyecto"

                                   , conexion);
            cmd.Parameters.AddWithValue("proyecto", Proyecto.Text);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.SelectCommand.CommandTimeout = 36000;
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                conexion.Dispose();
                string Año = dt.Rows[0][0].ToString();
                string tipo = dt.Rows[0][1].ToString();
                string Nombre = dt.Rows[0][2].ToString();
                if (Nombre != usuario + " " + apellido)
                {

                    DialogResult Resultado;
                    Resultado = MessageBox.Show("El proyecto esta abierto por el usuario:" + Nombre + "\nDesea forzar el ingreso al proyecto?   ", "Confirmación", MessageBoxButtons.YesNo);
                    if (Resultado == DialogResult.Yes)
                    {
                        this.registro_AccesosTableAdapter.elimina(Proyecto.Text);
                        Nombre1 = Proyecto.Text;
                        this.folio_ProyectosTableAdapter.Consulta(folio_Proyectos._Folio_Proyectos, Nombre1);
                        valor2 = this.tipo2.Text;

                       url = @"G:\SGC-PROYECTOS-CBR\SGC\" + Ano.Text + "\\" + this.tipo2.Text + "\\" + Proyecto.SelectedValue.ToString();
                        txtRuta.Text = url.ToString();
                        valor = Proyecto.SelectedValue.ToString();
                        contadortop();

                        this.registro_Accesos_monitorTableAdapter.ingresamonitor(Proyecto.Text, Ano.Text, this.tipo2.Text, usuario + " " + apellido);

                        cargarArchivos();
                    }
                    else if (Resultado == DialogResult.No)
                    {
                     

                        MessageBox.Show("Operacion Cancelada");
                    }
                }

                else
                {
                    Nombre1 = Proyecto.Text;
                    this.folio_ProyectosTableAdapter.Consulta(folio_Proyectos._Folio_Proyectos, Nombre1);
                    valor2 = this.tipo2.Text;

               //  url = @"G:/SGC-PROYECTOS-CBR/SGC/" + Ano.Text + "/" + this.tipo2.Text + "/" + Proyecto.SelectedValue.ToString();
                    url = @"G:\SGC-PROYECTOS-CBR\SGC\" + Ano.Text + "\\" + this.tipo2.Text + "\\" + Proyecto.SelectedValue.ToString();
                    txtRuta.Text = url.ToString();
                    valor = Proyecto.SelectedValue.ToString();
                    contadortop();

                    this.registro_Accesos_monitorTableAdapter.ingresamonitor(Proyecto.Text, Ano.Text, this.tipo2.Text, usuario + " " + apellido);

                    cargarArchivos();
                }
            }
            else
            {
                if (Ano.Text.Trim() != "" && Proyecto.Text.Trim() != "" && tipo2.Text.Trim() != "")
                {
                //    url = @"G:/SGC-PROYECTOS-CBR/SGC/" + Ano.Text + "/" + tipo2.Text + "/" + Proyecto.SelectedValue.ToString();
                    url = @"G:\SGC-PROYECTOS-CBR\SGC\" + Ano.Text  + "\\" + this.tipo2.Text + "\\" + Proyecto.SelectedValue.ToString();
                    txtRuta.Text = url.ToString();
                    consultacarpeta(Proyecto.Text);

                    //navegador.Text = url;
                    valor2 = tipo2.Text;
                    valor = Proyecto.SelectedValue.ToString();
                    contadortop();
                    this.registro_AccesosTableAdapter.Visualizar(Proyecto.Text, Ano.Text, tipo2.Text, usuario + " " + apellido);
                    this.registro_Accesos_monitorTableAdapter.ingresamonitor(Proyecto.Text, Ano.Text, tipo2.Text, usuario + " " + apellido);

                    //webBrowser1.Refresh();
                    //webBrowser1.Url = new Uri(url);
                    this.folio_ProyectosTableAdapter.Consulta(folio_Proyectos._Folio_Proyectos, nomproyec1);
                    cargarArchivos();

                }
                else if (Proyecto.Text.Trim() == "" & Ano.Text.Trim() == "" & tipo2.Text.Trim() == "")
                {
                    MessageBox.Show("No ha ingresado ningun dato a buscar");
                }
                else if (Ano.Text.Trim() != "" & tipo2.Text.Trim() == "" & Proyecto.Text.Trim() == "")
                {
                     url = @"G:\SGC-PROYECTOS-CBR\SGC\" + Ano.Text;
                    txtRuta.Text = url.ToString();
                    valor = Proyecto.SelectedValue.ToString();
                    contadortop();
                    this.registro_AccesosTableAdapter.Visualizar(Proyecto.Text, Ano.Text, tipo2.Text, usuario + " " + apellido);
                    this.registro_Accesos_monitorTableAdapter.ingresamonitor(Proyecto.Text, Ano.Text, tipo2.Text, usuario + " " + apellido);
                    this.folio_ProyectosTableAdapter.Consulta(folio_Proyectos._Folio_Proyectos, Nombre1);
                    //webBrowser1.Refresh();

                }
                else if (Ano.Text.Trim() != "" & tipo2.Text.Trim() != "" & Proyecto.Text.Trim() == "")
                {
                    url = @"G:\SGC-PROYECTOS-CBR\SGC\" + Ano.Text + "\\" + tipo2.Text;
                    txtRuta.Text = url.ToString();
                    //webBrowser1.Url = new Uri(url);
                    //navegador.Text = url;
                    valor = Proyecto.SelectedValue.ToString();
                    contadortop();
                    this.registro_AccesosTableAdapter.Visualizar(Proyecto.Text, Ano.Text, tipo2.Text, usuario + " " + apellido);
                    this.registro_Accesos_monitorTableAdapter.ingresamonitor(Proyecto.Text, Ano.Text, tipo2.Text, usuario + " " + apellido);
                    this.folio_ProyectosTableAdapter.Consulta(folio_Proyectos._Folio_Proyectos, Nombre1);
                    //webBrowser1.Refresh();

                }
                else if (Ano.Text.Trim() == "" & tipo2.Text.Trim() != "" & Proyecto.Text.Trim() == "")
                {
                    MessageBox.Show("Dato invalido ingrese almenos el año a buscar");
                }
                else if (Ano.Text.Trim() == "" & tipo2.Text.Trim() == "" & Proyecto.Text.Trim() != "")
                {
                    MessageBox.Show("Dato invalido ingrese  el tipo de proyecto y el año");
                }
                else if (Ano.Text.Trim() == "" & tipo2.Text.Trim() != "" & Proyecto.Text.Trim() != "")
                {
                    MessageBox.Show("Dato invalido ingrese el año");
                }
                else if (Ano.Text.Trim() != "" & tipo2.Text.Trim() == "" & Proyecto.Text.Trim() != "")
                {
                    MessageBox.Show("Dato invalido el tipo");
                }
              
                this.folio_ProyectosTableAdapter.Consulta(folio_Proyectos._Folio_Proyectos, nomproyec1);
                Nombre1 = nomproyec1;
                this.folio_ProyectosTableAdapter.Consulta(folio_Proyectos._Folio_Proyectos, Nombre1);
                txtRuta.Text = url.ToString();

            }
        }


        public void contadortop()
        {
            SqlConnection conexion = new SqlConnection(ObtenerCadena());

            conexion.Open();
            ////////////////////////////////////////////////////////////////////////////////////
            if (valor2 == "Proyectos-Inox") { valor2 = "inox"; }
            else if (valor2 == "Proyectos-Compacta") { valor2 = "compacta"; }
            else if (valor2 == "Proyectos-Alto-Flujo") { valor2 = "altoflujo"; }
            else if (valor2 == "Proyectos-Industrial-Potabiliza") { valor2 = "Industrial"; }
            else { }


            SqlCommand cmd = new SqlCommand();
         
            if (departamento == "SuperAdmin" && valor2 == "inox")
            {
                cmd = new SqlCommand(
                "select " +
                "Count('Nombre') " +
                "from [Term_inox_admin] "
                , conexion);
            }
            else if (departamento == "Direccion" && valor2 == "inox")
            {
                cmd = new SqlCommand(
                "select " +
                "Count('Nombre') " +
                "from [Term_inox_admin] "
                , conexion);
            }

            else if (departamento == "Asistente de direccion" && valor2 == "inox")
            {
                cmd = new SqlCommand(
                "select " +
                "Count('Nombre') " +
                "from [Term_inox_asistedirec] "
                , conexion);
            }
            else if (departamento == "Infraestructura" && valor2 == "inox")
            {
                cmd = new SqlCommand(
                "select " +
                "Count('Nombre') " +
                "from [Term_inox_infraestructura] "
                , conexion);
            }
            else if (departamento == "Potabiliza" && valor2 == "inox")
            {
                cmd = new SqlCommand(
                "select " +
                "Count('Nombre') " +
                "from [Term_inox_potabiliza] "
                , conexion);
            }
            else if (departamento == "Ventas" && valor2 == "inox")
            {
                cmd = new SqlCommand(
                "select " +
                "Count('Nombre') " +
                "from [Term_inox_ventas] "
                , conexion);
            }
            else if (departamento == "Proyectos" && valor2 == "inox")
            {
                cmd = new SqlCommand(
                "select " +
                "Count('Nombre') " +
                "from [Term_inox_proyectos] "
                , conexion);
            }
            else if (departamento == "Atencion a Clientes" && valor2 == "inox")
            {
                cmd = new SqlCommand(
                "select " +
                "Count('Nombre') " +
                "from [Term_inox_atnclientes] "
                , conexion);
            }
            else if (departamento == "Produccion" && valor2 == "inox")
            {
                cmd = new SqlCommand(
                "select " +
                "Count('Nombre') " +
                "from [Term_inox_produccion] "
                , conexion);
            }

            else if (departamento == "Construccion e Instalaciones" && valor2 == "inox")
            {
                cmd = new SqlCommand(
                "select " +
                "Count('Nombre') " +
                "from [Term_inox_consinst] "
                , conexion);
            }

            else if (departamento == "Operacion y Mantenimiento" && valor2 == "inox")
            {
                cmd = new SqlCommand(
                "select " +
                "Count('Nombre') " +
                "from [Term_inox_opyman] "
                , conexion);
            }
            else if (departamento == "Compras" && valor2 == "inox")
            {
                cmd = new SqlCommand(
                "select " +
                "Count('Nombre') " +
                "from [Term_inox_compras] "
                , conexion);
            }


            if (departamento == "SuperAdmin" && valor2 == "altoflujo" || departamento == "SuperAdmin" && valor2 == "compacta")
            {
                cmd = new SqlCommand(
                "select " +
                "Count('Nombre') " +
                "from [Term_af-com_admin] "
                , conexion);
            }
            else if (departamento == "Direccion" && valor2 == "altoflujo" || departamento == "Direccion" && valor2 == "compacta")
            {
                cmd = new SqlCommand(
                "select " +
                "Count('Nombre') " +
                "from [Term_af-com_admin] "
                , conexion);
            }
            if (departamento == "SuperAdmin" && valor2 == "altoflujo" || departamento == "SuperAdmin" && valor2 == "Industrial")
            {
                cmd = new SqlCommand(
                "select " +
                "Count('Nombre') " +
                "from [Term_Indus-Pot_admin] "
                , conexion);
            }
            else if (departamento == "Direccion" && valor2 == "altoflujo" || departamento == "Direccion" && valor2 == "Industrial")
            {
                cmd = new SqlCommand(
                "select " +
                "Count('Nombre') " +
                "from [Term_Indus-Pot_admin] "
                , conexion);
            }

            else if (departamento == "Asistente de direccion" && valor2 == "compacta" || departamento == "Asistente de direccion" && valor2 == "altoflujo")
            {
                cmd = new SqlCommand(
                "select " +
                "Count('Nombre') " +
                "from [Term_af-com_asistedirec] "
                , conexion);
            }
            else if (departamento == "Infraestructura" && valor2 == "compacta" || departamento == "Infraestructura" && valor2 == "altoflujo")
            {
                cmd = new SqlCommand(
                "select " +
                "Count('Nombre') " +
                "from [Term_af-com_infraestructura] "
                , conexion);
            }
            else if (departamento == "Potabiliza" && valor2 == "compacta" || departamento == "Potabiliza" && valor2 == "altoflujo")
            {
                cmd = new SqlCommand(
                "select " +
                "Count('Nombre') " +
                "from [Term_af-com_potabiliza] "
                , conexion);
            }
            else if (departamento == "Ventas" && valor2 == "compacta" || departamento == "Ventas" && valor2 == "altoflujo")
            {
                cmd = new SqlCommand(
                "select " +
                "Count('Nombre') " +
                "from [Term_af-com_ventas] "
                , conexion);
            }
            else if (departamento == "Proyectos" && valor2 == "compacta" || departamento == "Proyectos" && valor2 == "altoflujo")
            {
                cmd = new SqlCommand(
                "select " +
                "Count('Nombre') " +
                "from [Term_af-com_proyectos] "
                , conexion);
            }
            else if (departamento == "Atencion a Clientes" && valor2 == "compacta" || departamento == "Atencion a Clientes" && valor2 == "altoflujo")
            {
                cmd = new SqlCommand(
                "select " +
                "Count('Nombre') " +
                "from [Term_af-com_atnclientes] "
                , conexion);
            }
            else if (departamento == "Produccion" && valor2 == "compacta" || departamento == "Produccion" && valor2 == "altoflujo")
            {
                cmd = new SqlCommand(
                "select " +
                "Count('Nombre') " +
                "from [Term_af-com_produccion] "
                , conexion);
            }
            else if (departamento == "Construccion e Instalaciones" && valor2 == "compacta" || departamento == "Construccion e Instalaciones" && valor2 == "altoflujo")
            {
                cmd = new SqlCommand(
                "select " +
                "Count('Nombre') " +
                "from [Term_af-com_consinst] "
                , conexion);
            }
            else if (departamento == "Operacion y Mantenimiento" && valor2 == "compacta" || departamento == "Operacion y Mantenimiento" && valor2 == "altoflujo")
            {
                cmd = new SqlCommand(
                "select " +
                "Count('Nombre') " +
                "from [Term_af-com_opyman] "
                , conexion);
            }
            else if (departamento == "Compras" && valor2 == "compacta" || departamento == "Compras" && valor2 == "altoflujo")
            {
                cmd = new SqlCommand(
                "select " +
                "Count('Nombre') " +
                "from [Term_af-com_compras] "
                , conexion);
            }


            else if (departamento == "Asistente de direccion" && valor2 == "Industrial" || departamento == "Asistente de direccion" && valor2 == "Potabiliza")
            {
                cmd = new SqlCommand(
                "select " +
                "Count('Nombre') " +
                "from [Term_Indus-Pot_asistedirec] "
                , conexion);
            }
            else if (departamento == "Infraestructura" && valor2 == "Industrial" || departamento == "Infraestructura" && valor2 == "Potabiliza")
            {
                cmd = new SqlCommand(
                "select " +
                "Count('Nombre') " +
                "from [Term_Indus-Pot_infraestructura] "
                , conexion);
            }
            else if (departamento == "Potabiliza" && valor2 == "Industrial" || departamento == "Potabiliza" && valor2 == "Potabiliza")
            {
                cmd = new SqlCommand(
                "select " +
                "Count('Nombre') " +
                "from [Term_Indus-Pot_potabiliza] "
                , conexion);
            }
            else if (departamento == "Ventas" && valor2 == "Industrial" || departamento == "Ventas" && valor2 == "Potabiliza")
            {
                cmd = new SqlCommand(
                "select " +
                "Count('Nombre') " +
                "from [Term_Indus-Pot_ventas] "
                , conexion);
            }
            else if (departamento == "Proyectos" && valor2 == "Industrial" || departamento == "Proyectos" && valor2 == "Potabiliza")
            {
                cmd = new SqlCommand(
                "select " +
                "Count('Nombre') " +
                "from [Term_Indus-Pot_proyectos] "
                , conexion);
            }
            else if (departamento == "Atencion a Clientes" && valor2 == "Industrial" || departamento == "Atencion a Clientes" && valor2 == "Potabiliza")
            {
                cmd = new SqlCommand(
                "select " +
                "Count('Nombre') " +
                "from [Term_Indus-Pot_atnclientes] "
                , conexion);
            }
            else if (departamento == "Produccion" && valor2 == "Industrial" || departamento == "Produccion" && valor2 == "Potabiliza")
            {
                cmd = new SqlCommand(
                "select " +
                "Count('Nombre') " +
                "from [Term_Indus-Pot_produccion] "
                , conexion);
            }
            else if (departamento == "Construccion e Instalaciones" && valor2 == "Industrial" || departamento == "Construccion e Instalaciones" && valor2 == "Potabiliza")
            {
                cmd = new SqlCommand(
                "select " +
                "Count('Nombre') " +
                "from [Term_Indus-Pot_consinst] "
                , conexion);
            }
            else if (departamento == "Operacion y Mantenimiento" && valor2 == "Industrial" || departamento == "Operacion y Mantenimiento" && valor2 == "Potabiliza")
            {
                cmd = new SqlCommand(
                "select " +
                "Count('Nombre') " +
                "from [Term_Indus-Pot_opyman] "
                , conexion);
            }
            else if (departamento == "Compras" && valor2 == "Industrial" || departamento == "Compras" && valor2 == "Potabiliza")
            {
                cmd = new SqlCommand(
                "select " +
                "Count('Nombre') " +
                "from [Term_Indus-Pot_compras] "
                , conexion);
            }



            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.SelectCommand.CommandTimeout = 36000;
            DataTable dt = new DataTable();
            sda.Fill(dt);



            conexion.Dispose();
            if (dt.Rows.Count > 0)
            {
                Nombre = dt.Rows[0][0].ToString();

                contador();

            }
            else { }

        }

        public void consultacarpeta(string proyecto)
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
                                                "[Norma], " +
                                                "[Tipo], " +
                                                "[Capacidad], " +
                                                 "[Fecha], " +
                                                  "[Folio], " +
                                                    "[Nombre], " +
                                                         "[Ano], " +
                                                "[tipo2]," +
                                                "[Nombre2]," +
                                                "[codificador] " +

                                                "from [Folio_Proyectos] " +
                                                "where [Nombre2]=@Nombre"

                                                , conexion);
                cmd.Parameters.AddWithValue("Nombre", proyecto);


                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.SelectCommand.CommandTimeout = 36000;
                DataTable dt = new DataTable();
                sda.Fill(dt);



                conexion.Dispose();


                if (dt.Rows.Count > 0)
                {

                    //MessageBox.Show("Si tiene acceso a esta planta");
                    // this.Close();
                    string folio = dt.Rows[0][5].ToString();
                    string Nombre = dt.Rows[0][6].ToString();
                    string Año = dt.Rows[0][7].ToString();
                    string tipo = dt.Rows[0][8].ToString();
                    string codificador = dt.Rows[0][10].ToString();
                    proyectoras = folio;
                    anorastreo = Año;
                    proyectorastreo = Nombre;
                    carpetarastreo = tipo;
                    codifica = codificador;
                    nomproyec1 = dt.Rows[0][9].ToString();
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

        public void contador()
        {



            numerador = Int32.Parse(Nombre);

            suma = 0;


            rastreadorproyecto();

            for (k = 1; k <= numerador; k++)
            {
                suma = suma + k;
                if (Ano.Text == "2017" || Ano.Text == "2018" || Ano.Text == "2019") { k = numerador; suma = numerador; }
                else { }
                Procesocarp genera = new Procesocarp();

                genera.total = numerador.ToString();
                genera.contador = k.ToString();
                genera.Show();
                genera.BringToFront();
                genera.WindowState = FormWindowState.Normal;
                Mostrador();
                genera.Close();

                // richTextBox1.Text = suma.ToString();


            }
        }
        public void rastreadorproyecto()
        {
            SqlConnection conexion = new SqlConnection(ObtenerCadena());
            conexion.Open();
            SqlCommand cmd = new SqlCommand(
                                   "select [Proyecto]," +
                                   "[ano], " +
                                   "[tipo], " +
                                   "[Usuario] " +

                                   "from [Registro_Accesos]  where Proyecto=@proyecto"

                                   , conexion);
            cmd.Parameters.AddWithValue("proyecto", Proyecto.Text);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.SelectCommand.CommandTimeout = 36000;
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Nombre2 = dt.Rows[0][0].ToString();
                Año2 = dt.Rows[0][1].ToString();
                tipo3 = dt.Rows[0][2].ToString();

                conexion.Dispose();
            }
            else
            {

                conexion.Dispose();
            }

        }

        public void Mostrador()
        {



            SqlConnection conexion = new SqlConnection(ObtenerCadena());

            SqlCommand cmd = new SqlCommand();
            if (departamento == "SuperAdmin" && valor2 == "inox")
            {
                cmd = new SqlCommand(
                                   "select top " + "(" + suma + ")" +
                                "[Nombre] " +

                                   "from [Term_inox_admin] "

                                   , conexion);
            }

            else if (departamento == "Direccion" && valor2 == "inox")
            {
                cmd = new SqlCommand(
                    "select top " + "(" + suma + ")" +
                                "[Nombre] " +

                "from [Term_inox_admin] "
                , conexion);
            }
            else if (departamento == "Asistente de direccion" && valor2 == "inox")
            {
                cmd = new SqlCommand(
                "select top " + "(" + suma + ")" +
                                "[Nombre] " +

                "from [Term_inox_asistedirec] "
                , conexion);
            }
            else if (departamento == "Infraestructura" && valor2 == "inox")
            {
                cmd = new SqlCommand(
                     "select top " + "(" + suma + ")" +
                                "[Nombre] " +

                "from [Term_inox_infraestructura] "
                , conexion);
            }
            else if (departamento == "Potabiliza" && valor2 == "inox")
            {
                cmd = new SqlCommand(
                     "select top " + "(" + suma + ")" +
                                "[Nombre] " +

                "from [Term_inox_potabiliza] "
                , conexion);
            }
            else if (departamento == "Ventas" && valor2 == "inox")
            {
                cmd = new SqlCommand(
             "select top " + "(" + suma + ")" +
                                "[Nombre] " +

                "from [Term_inox_ventas] "
                , conexion);
            }
            else if (departamento == "Proyectos" && valor2 == "inox")
            {
                cmd = new SqlCommand(
                   "select top " + "(" + suma + ")" +
                                "[Nombre] " +

                "from [Term_inox_proyectos] "
                , conexion);
            }
            else if (departamento == "Atencion a Clientes" && valor2 == "inox")
            {
                cmd = new SqlCommand(
                      "select top " + "(" + suma + ")" +
                                "[Nombre] " +

                "from [Term_inox_atnclientes] "
                , conexion);
            }
            else if (departamento == "Produccion" && valor2 == "inox")
            {
                cmd = new SqlCommand(
           "select top " + "(" + suma + ")" +
                                "[Nombre] " +

                "from [Term_inox_produccion] "
                , conexion);
            }
            else if (departamento == "Construccion e Instalaciones" && valor2 == "inox")
            {
                cmd = new SqlCommand(
                    "select top " + "(" + suma + ")" +
                                "[Nombre] " +

                "from [Term_inox_consinst] "
                , conexion);
            }
            else if (departamento == "Operacion y Mantenimiento" && valor2 == "inox")
            {
                cmd = new SqlCommand(
                    "select top " + "(" + suma + ")" +
                                "[Nombre] " +

                "from [Term_inox_opyman] "
                , conexion);
            }
            else if (departamento == "Compras" && valor2 == "inox")
            {
                cmd = new SqlCommand(
                    "select top " + "(" + suma + ")" +
                                "[Nombre] " +

                "from [Term_inox_compras] "
                , conexion);
            }

            else if (departamento == "SuperAdmin" && valor2 == "altoflujo" || departamento == "SuperAdmin" && valor2 == "compacta")
            {
                cmd = new SqlCommand(
                    "select top " + "(" + suma + ")" +
                                "[Nombre] " +

                "from [Term_af-com_admin] "
                , conexion);
            }
            else if (departamento == "Direccion" && valor2 == "altoflujo" || departamento == "Direccion" && valor2 == "compacta")
            {
                cmd = new SqlCommand(
                "select top " + "(" + suma + ")" +
                                "[Nombre] " +

                "from [Term_af-com_admin] "
                , conexion);
            }
            else if (departamento == "Asistente de direccion" && valor2 == "altoflujo" || departamento == "Asistente de direccion" && valor2 == "compacta")
            {
                cmd = new SqlCommand(
                "select top " + "(" + suma + ")" +
                                "[Nombre] " +

                "from [Term_af-com_asistedirec] "
                , conexion);
            }
            else if (departamento == "Infraestructura" && valor2 == "compacta" || departamento == "Infraestructura" && valor2 == "altoflujo")
            {
                cmd = new SqlCommand(
                     "select top " + "(" + suma + ")" +
                                "[Nombre] " +

                "from [Term_af-com_infraestructura] "
                , conexion);
            }
            else if (departamento == "Potabiliza" && valor2 == "compacta" || departamento == "Potabiliza" && valor2 == "altoflujo")
            {
                cmd = new SqlCommand(
                     "select top " + "(" + suma + ")" +
                                "[Nombre] " +

                "from [Term_af-com_potabiliza] "
                , conexion);
            }
            else if (departamento == "Ventas" && valor2 == "compacta" || departamento == "Ventas" && valor2 == "altoflujo")
            {
                cmd = new SqlCommand(
             "select top " + "(" + suma + ")" +
                                "[Nombre] " +

                "from [Term_af-com_ventas] "
                , conexion);
            }
            else if (departamento == "Proyectos" && valor2 == "compacta" || departamento == "Proyectos" && valor2 == "altoflujo")
            {
                cmd = new SqlCommand(
                   "select top " + "(" + suma + ")" +
                                "[Nombre] " +

                "from [Term_af-com_proyectos] "
                , conexion);
            }
            else if (departamento == "Atencion a Clientes" && valor2 == "compacta" || departamento == "Atencion a Clientes" && valor2 == "altoflujo")
            {
                cmd = new SqlCommand(
                      "select top " + "(" + suma + ")" +
                                "[Nombre] " +

                "from [Term_af-com_atnclientes] "
                , conexion);
            }
            else if (departamento == "Produccion" && valor2 == "compacta" || departamento == "Produccion" && valor2 == "altoflujo")
            {
                cmd = new SqlCommand(
           "select top " + "(" + suma + ")" +
                                "[Nombre] " +

                "from [Term_af-com_produccion] "
                , conexion);
            }
            else if (departamento == "Construccion e Instalaciones" && valor2 == "compacta" || departamento == "Construccion e Instalaciones" && valor2 == "altoflujo")
            {
                cmd = new SqlCommand(
                    "select top " + "(" + suma + ")" +
                                "[Nombre] " +

                "from [Term_af-com_consinst] "
                , conexion);
            }
            else if (departamento == "Operacion y Mantenimiento" && valor2 == "compacta" || departamento == "Operacion y Mantenimiento" && valor2 == "altoflujo")
            {
                cmd = new SqlCommand(
                    "select top " + "(" + suma + ")" +
                                "[Nombre] " +

                "from [Term_af-com_opyman] "
                , conexion);
            }
            else if (departamento == "Compras" && valor2 == "compacta" || departamento == "Compras" && valor2 == "altoflujo")
            {
                cmd = new SqlCommand(
                    "select top " + "(" + suma + ")" +
                                "[Nombre] " +

                "from [Term_af-com_compras] "
                , conexion);
            }


            else if (departamento == "SuperAdmin" && valor2 == "Industrial" || departamento == "SuperAdmin" && valor2 == "Potabiliza")
            {
                cmd = new SqlCommand(
                    "select top " + "(" + suma + ")" +
                                "[Nombre] " +

                "from [Term_Indus-Pot_admin] "
                , conexion);
            }
            else if (departamento == "Direccion" && valor2 == "Industrial" || departamento == "Direccion" && valor2 == "Potabiliza")
            {
                cmd = new SqlCommand(
                "select top " + "(" + suma + ")" +
                                "[Nombre] " +

                "from [Term_Indus-Pot_admin] "
                , conexion);
            }
            else if (departamento == "Asistente de direccion" && valor2 == "Industrial" || departamento == "Asistente de direccion" && valor2 == "Potabiliza")
            {
                cmd = new SqlCommand(
                "select top " + "(" + suma + ")" +
                                "[Nombre] " +

                "from [Term_Indus-Pot_asistedirec] "
                , conexion);
            }
            else if (departamento == "Infraestructura" && valor2 == "Industrial" || departamento == "Infraestructura" && valor2 == "Potabiliza")
            {
                cmd = new SqlCommand(
                     "select top " + "(" + suma + ")" +
                                "[Nombre] " +

                "from [Term_Indus-Pot_infraestructura] "
                , conexion);
            }
            else if (departamento == "Potabiliza" && valor2 == "Industrial" || departamento == "Potabiliza" && valor2 == "Potabiliza")
            {
                cmd = new SqlCommand(
                     "select top " + "(" + suma + ")" +
                                "[Nombre] " +

                "from [Term_Indus-Pot_potabiliza] "
                , conexion);
            }
            else if (departamento == "Ventas" && valor2 == "Industrial" || departamento == "Ventas" && valor2 == "Potabiliza")
            {
                cmd = new SqlCommand(
             "select top " + "(" + suma + ")" +
                                "[Nombre] " +

                "from [Term_Indus-Pot_ventas] "
                , conexion);
            }
            else if (departamento == "Proyectos" && valor2 == "Industrial" || departamento == "Proyectos" && valor2 == "Potabiliza")
            {
                cmd = new SqlCommand(
                   "select top " + "(" + suma + ")" +
                                "[Nombre] " +

                "from [Term_Indus-Pot_proyectos] "
                , conexion);
            }
            else if (departamento == "Atencion a Clientes" && valor2 == "Industrial" || departamento == "Atencion a Clientes" && valor2 == "Potabiliza")
            {
                cmd = new SqlCommand(
                      "select top " + "(" + suma + ")" +
                                "[Nombre] " +

                "from [Term_Indus-Pot_atnclientes] "
                , conexion);
            }
            else if (departamento == "Produccion" && valor2 == "Industrial" || departamento == "Produccion" && valor2 == "Potabiliza")
            {
                cmd = new SqlCommand(
           "select top " + "(" + suma + ")" +
                                "[Nombre] " +

                "from [Term_Indus-Pot_produccion] "
                , conexion);
            }
            else if (departamento == "Construccion e Instalaciones" && valor2 == "Industrial" || departamento == "Construccion e Instalaciones" && valor2 == "Potabiliza")
            {
                cmd = new SqlCommand(
                    "select top " + "(" + suma + ")" +
                                "[Nombre] " +

                "from [Term_Indus-Pot_consinst] "
                , conexion);
            }
            else if (departamento == "Operacion y Mantenimiento" && valor2 == "Industrial" || departamento == "Operacion y Mantenimiento" && valor2 == "Potabiliza")
            {
                cmd = new SqlCommand(
                    "select top " + "(" + suma + ")" +
                                "[Nombre] " +

                "from [Term_Indus-Pot_opyman] "
                , conexion);
            }
            else if (departamento == "Compras" && valor2 == "Industrial" || departamento == "Compras" && valor2 == "Potabiliza")
            {
                cmd = new SqlCommand(
                    "select top " + "(" + suma + ")" +
                                "[Nombre] " +

                "from [Term_Indus-Pot_compras] "
                , conexion);
            }


            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.SelectCommand.CommandTimeout = 36000;
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                string Nombre = dt.Rows[k - 1][0].ToString();
                Thread.Sleep(10);
                string strCmdText;
                if (departamento == "Construccion e Instalaciones" && Ano.Text == "2019") { departamento = "Instalaciones y construccion"; }
                else if (departamento == "Construccion e Instalaciones" && Ano.Text == "2018") { departamento = "Instalaciones y construccion"; }
                else if (departamento == "Construccion e Instalaciones" && Ano.Text == "2017") { departamento = "Instalaciones y construccion"; }
                else if (departamento == "Construccion e Instalaciones" && Ano.Text != "2017" && departamento == "Construccion e Instalaciones" && Ano.Text != "2018" && departamento == "Construccion e Instalaciones" && Ano.Text != "2019") { departamento = "Construccion e Instalaciones"; }
                else { }

                // richTextBox1.Text = richTextBox1.Text+"\n"+ "G:\\SGC-PROYECTOS-CBR\\SGC\\"+Año +"\\"+ tipo +"\\" + Nombre ;
                if (Ano.Text == "2019" && departamento != "SuperAdmin")
                {

                    strCmdText = "/C attrib -h -s " + " \"" + "G:\\SGC-PROYECTOS-CBR\\SGC\\" + Ano.Text + "\\" + tipo2.Text + "\\" + valor + "\\" + departamento + "\\*" + "\"" + "  /S" + "  /D";
                    Process cm = new Process();
                    cm.StartInfo.FileName = "cmd.exe";
                    cm.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    cm.StartInfo.Arguments = strCmdText;
                    cm.Start();
                    cm.WaitForExit();
                }
                else if (Ano.Text == "2019" && departamento != "Direccion")
                {
                    strCmdText = "/C attrib -h -s " + " \"" + "G:\\SGC-PROYECTOS-CBR\\SGC\\" + Ano.Text + "\\" + tipo2.Text + "\\" + valor + "\\" + departamento + "\\*" + "\"" + "  /S" + "  /D";
                    Process cm = new Process();
                    cm.StartInfo.FileName = "cmd.exe";
                    cm.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    cm.StartInfo.Arguments = strCmdText;
                    cm.Start();
                    cm.WaitForExit();
                }

                else if (Ano.Text == "2019" && departamento == "Direccion" || Ano.Text == "2019" && departamento == "SuperAdmin")
                {
                    strCmdText = "/C attrib -h -s " + " \"" + "G:\\SGC-PROYECTOS-CBR\\SGC\\" + Ano.Text + "\\" + tipo2.Text + "\\" + valor + "\\*" + " " + "\" " + "  /S" + "  /D";
                    Process cm = new Process();
                    cm.StartInfo.FileName = "cmd.exe";
                    cm.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    cm.StartInfo.Arguments = strCmdText;
                    cm.Start();
                    cm.WaitForExit();
                }

                else if (Ano.Text == "2018" && departamento == "Direccion" || Ano.Text == "2018" && departamento == "SuperAdmin")
                {
                    strCmdText = "/C attrib -h -s " + " \"" + "G:\\SGC-PROYECTOS-CBR\\SGC\\" + Ano.Text + "\\" + tipo2.Text + "\\" + valor + "\\*" + " " + "\"" + "  /S" + "  /D";
                    Process cm = new Process();
                    cm.StartInfo.FileName = "cmd.exe";
                    cm.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    cm.StartInfo.Arguments = strCmdText;
                    cm.Start();
                    cm.WaitForExit();
                }
                else if (Ano.Text == "2017" && departamento == "Direccion" || Ano.Text == "2017" && departamento == "SuperAdmin")
                {
                    strCmdText = "/C attrib -h -s " + " \"" + "G:\\SGC-PROYECTOS-CBR\\SGC\\" + Ano.Text + "\\" + tipo2.Text + "\\" + valor + "\\*" + " " + "\"" + "  /S" + "  /D";
                    Process cm = new Process();
                    cm.StartInfo.FileName = "cmd.exe";
                    cm.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    cm.StartInfo.Arguments = strCmdText;
                    cm.Start();
                    cm.WaitForExit();
                }
                else if (departamento == "Direccion" && Ano.Text != "2019" || departamento == "SuperAdmin" && Ano.Text != "2019" || departamento == "Direccion" && Ano.Text != "2018" || departamento == "SuperAdmin" && Ano.Text != "2018" || departamento == "Direccion" && Ano.Text != "2017" || departamento == "SuperAdmin" && Ano.Text != "2017")
                {
                    strCmdText = "/C attrib -h -s " + " \"" + "G:\\SGC-PROYECTOS-CBR\\SGC\\" + Ano.Text + "\\" + tipo2.Text + "\\" + valor + "\\*" + "\"" + "  /S" + "  /D";
                    Process cm = new Process();
                    cm.StartInfo.FileName = "cmd.exe";
                    cm.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    cm.StartInfo.Arguments = strCmdText;
                    cm.Start();
                    cm.WaitForExit();
                }
                else if (departamento != "Direccion" && Ano.Text == "2019" || departamento != "SuperAdmin" && Ano.Text == "2019" || departamento != "Direccion" && Ano.Text == "2018" || departamento != "SuperAdmin" && Ano.Text == "2018" || departamento != "Direccion" && Ano.Text == "2017" || departamento == "SuperAdmin" && Ano.Text == "2017")

                {
                    strCmdText = "/C attrib -h -s " + " \"" + "G:\\SGC-PROYECTOS-CBR\\SGC\\" + Ano.Text + "\\" + tipo2.Text + "\\" + valor + "\\" + departamento + "\\*" + " \"" + "  /S" + "  /D";
                    Process cm = new Process();
                    cm.StartInfo.FileName = "cmd.exe";
                    cm.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    cm.StartInfo.Arguments = strCmdText;
                    cm.Start();
                    cm.WaitForExit();
                    strCmdText = "/C attrib -h -s " + " \"" + "G:\\SGC-PROYECTOS-CBR\\SGC\\" + Ano.Text + "\\" + tipo2.Text + "\\" + valor + "\\" + departamento + " \"" + "  /S" + "  /D";

                    cm.StartInfo.FileName = "cmd.exe";
                    cm.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    cm.StartInfo.Arguments = strCmdText;
                    cm.Start();
                    cm.WaitForExit();

                }
                else

                {
                    strCmdText = "/C attrib -h -s " + " \"" + "G:\\SGC-PROYECTOS-CBR\\SGC\\" + Ano.Text + "\\" + tipo2.Text + "\\" + valor + "\\" + Nombre + "\\*" + "\" " + "/S" + " /D";
                    Process cm = new Process();
                    cm.StartInfo.FileName = "cmd.exe";
                    cm.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    cm.StartInfo.Arguments = strCmdText;
                    cm.Start();
                    cm.WaitForExit();
                    strCmdText = "/C attrib -h -s " + " \"" + "G:\\SGC-PROYECTOS-CBR\\SGC\\" + Ano.Text + "\\" + tipo2.Text + "\\" + valor + "\\" + Nombre + "\" " + "/S" + " /D";

                    cm.StartInfo.FileName = "cmd.exe";
                    cm.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    cm.StartInfo.Arguments = strCmdText;
                    cm.Start();
                    cm.WaitForExit();

                }

                conexion.Dispose();
            }
            else { }
        }

        private AlternateView getEmbeddedImage(String filePath)
        {



            // below line was corrected to include the mediatype so it displays in all 
            // mail clients. previous solution only displays in Gmail the inline images 
            LinkedResource res = new LinkedResource(filePath, MediaTypeNames.Image.Jpeg);
            res.ContentId = Guid.NewGuid().ToString();
            String Body = "<DIV><H5>Solicitud de actualizado la carpeta</HEAD></DIV></H>" + carpeta.Text + " " + "Del proyecto:" + proye_solicita.Text;
            Body += "<DIV>Ingrese ala plataforma para actualizar estado de carpeta indicada</DIV>";




            string htmlBody = "" + Body + "" + @"<img src='cid:" + res.ContentId + @"'/> ";
            AlternateView alternateView = AlternateView.CreateAlternateViewFromString(htmlBody,
             null, MediaTypeNames.Text.Html);
            alternateView.LinkedResources.Add(res);
            return alternateView;
        }

    }

}
