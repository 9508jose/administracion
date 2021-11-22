using aejw.Network;
using Cake.Core.IO;
using CBR_ADMIN.Properties;
using CBR_ADMIN.Sistema;
using DiffuseDlgDemo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CBR_ADMIN
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        public static string ObtenerCadena()
        {
            return Settings.Default.CBR_IngenieriaConnectionString;/*Este codigo obtiene los datos de la cadena de conexion declarada en los settings de la aplicacion*/
            return Settings.Default.masterConnectionString;
            return Settings.Default.modelConnectionString;
            return Settings.Default.tempdbConnectionString;

        }
        public static string cifrado2()
        {         
            return Settings.Default.masterConnectionString;  }
        public static string cifrado3()
        {
            
            return Settings.Default.modelConnectionString;

        }
        public static string cifrado4()
        {
            return Settings.Default.tempdbConnectionString;      }

        SqlConnection conexion = new SqlConnection(ObtenerCadena());
        SqlConnection conexion2 = new SqlConnection(cifrado2());
        SqlConnection conexion3 = new SqlConnection(cifrado3());
        SqlConnection conexion4 = new SqlConnection(cifrado4());
        string localIP = "";
        string mac = "";
        string strHostName = string.Empty;
        string externalip = /*new WebClient().DownloadString("http://icanhazip.com");*/"";
        public string host,cuidad,estado,pais,CP,Proveedor,dominio;
        

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void GetUserCountryByIp(string ip)
        {
            IpInfo ipInfo = new IpInfo();
            try
            {
                string info = new WebClient().DownloadString("http://ipinfo.io/" + ip);
                ipInfo = JsonConvert.DeserializeObject<IpInfo>(info);
                RegionInfo myRI1 = new RegionInfo(ipInfo.Country);
                ipInfo.Country = myRI1.EnglishName;
            }
            catch (Exception)
            {
                ipInfo.Country = null;
            }
            host = ipInfo.Hostname;
            cuidad = ipInfo.City;
            estado = ipInfo.Region;        
            pais = ipInfo.Country;
            CP = ipInfo.Postal;
            dominio = ipInfo.Dominio;
            Proveedor = ipInfo.Org;
           

        }

        public class IpInfo
        {

            [JsonProperty("ip")]
            public string Ip { get; set; }

            [JsonProperty("hostname")]
            public string Hostname { get; set; }

            [JsonProperty("city")]
            public string City { get; set; }

            [JsonProperty("region")]
            public string Region { get; set; }

            [JsonProperty("country")]
            public string Country { get; set; }

            [JsonProperty("loc")]
            public string Loc { get; set; }

            [JsonProperty("org")]
            public string Org { get; set; }

            [JsonProperty("postal")]
            public string Postal { get; set; }

            [JsonProperty("company")]
            public string Dominio { get; set; }

            [JsonProperty("name")]
            public string Proveedor { get; set; }

        }

        ////////////////////////////////////SE CREA EL METODO LOGUEAR PARA LA VALIDACION DE LOS USUARIOS///////////////////////////////////////////////
        public void Logear(string usuario, string contrasena)
        {
            
           
            try
            {
                
                ////////////////////////////////////SE ABRE LA CONEXION/////////////////////////////////////////////////////////////////////////////////
                SqlConnection conexion = new SqlConnection(ObtenerCadena());
                SqlConnection conexion2 = new SqlConnection(cifrado2());
                SqlConnection conexion3 = new SqlConnection(cifrado3());
                SqlConnection conexion4 = new SqlConnection(cifrado4());
                conexion.Open();
                conexion2.Open();
                conexion3.Open();
                conexion4.Open();
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
                                                "where [Usuario]=@usuario " +
                                                "and [Contraseña]=@password "
                                                , conexion);
                cmd.Parameters.AddWithValue("usuario", usuario);
                cmd.Parameters.AddWithValue("password", contrasena);
                GetUserCountryByIp(externalip);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.SelectCommand.CommandTimeout = 36000;
                DataTable dt = new DataTable();
                sda.Fill(dt);
                
                ////////////////////////////////////////////encriptaciones//////////////////////////////////////////////////////////////////////////////////////////////
                SqlCommand cmd2 = new SqlCommand("SELECT [ID],[App],[$Cifrado$],[Variable]FROM[dbo].[$cifrado$]",conexion);
                SqlDataAdapter sda2 = new SqlDataAdapter(cmd2);
                sda2.SelectCommand.CommandTimeout = 36000;
                DataTable dt2 = new DataTable();
                sda2.Fill(dt2);
                conexion.Dispose();
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                SqlCommand cmd3 = new SqlCommand("SELECT [ID],[App],[$Cifrado$],[Variable]FROM[dbo].[$cifrado$]",conexion2);
                SqlDataAdapter sda3 = new SqlDataAdapter(cmd3);
                sda3.SelectCommand.CommandTimeout = 36000;
                DataTable dt3 = new DataTable();
                sda3.Fill(dt3);
                conexion2.Dispose();
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                SqlCommand cmd4 = new SqlCommand("SELECT [ID],[App],[$Cifrado$],[Variable]FROM[dbo].[$cifrado$]", conexion3);
                SqlDataAdapter sda4 = new SqlDataAdapter(cmd4);
                sda4.SelectCommand.CommandTimeout = 36000;
                DataTable dt4 = new DataTable();
                sda4.Fill(dt4);
                conexion3.Dispose();
                //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                SqlCommand cmd5 = new SqlCommand("SELECT [ID],[App],[$Cifrado$],[Variable]FROM[dbo].[$cifrado$]", conexion4);
                SqlDataAdapter sda5 = new SqlDataAdapter(cmd5);
                sda5.SelectCommand.CommandTimeout = 36000;
                DataTable dt5 = new DataTable();
                sda5.Fill(dt5);
                conexion4.Dispose();

                if (dt.Rows.Count > 0 )
                {
                 
                    //MessageBox.Show("Si tiene acceso a esta planta");
                    // this.Close();
                    string Nombre = dt.Rows[0][0].ToString();
                    string Apellido = dt.Rows[0][1].ToString();
                    string Usuario = dt.Rows[0][3].ToString();
                    string Permisos = dt.Rows[0][2].ToString();
                    string Puesto = dt.Rows[0][5].ToString();
                    string Departamento = dt.Rows[0][6].ToString();
                    string Email = dt.Rows[0][7].ToString();
                    string XcifradoX = dt2.Rows[0][2].ToString();
                    string Xvariable = dt2.Rows[0][3].ToString();
                    string XcifradoXY = dt3.Rows[0][2].ToString();
                    string XvariableY = dt3.Rows[0][3].ToString();
                    string XcifradoXYz = dt4.Rows[0][2].ToString();
                    string XvariableYz = dt4.Rows[0][3].ToString();
                    string XcifradoXYzt = dt5.Rows[0][2].ToString();
                    string XvariableYzt = dt5.Rows[0][3].ToString();

                    /////////////////////////////////////////////////////////////////////77
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
                    ///////////////////////////////////////////////////////////////////////////////
                    

                    IPHostEntry host;
                    
                    host = Dns.GetHostEntry(Dns.GetHostName());
                    foreach (IPAddress ip in host.AddressList)
                    {
                        if (ip.AddressFamily.ToString() == "InterNetwork")
                        {
                            localIP = ip.ToString();
                        }
                    }



                    ////////////////////////////////////////////////////////////////////////////////////////
               
                    foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
                    {

                        if (nic.OperationalStatus == OperationalStatus.Up && (!nic.Description.Contains("Virtual") && !nic.Description.Contains("Pseudo")))
                        {
                            if (nic.GetPhysicalAddress().ToString() != "")
                            {
                                mac = nic.GetPhysicalAddress().ToString();
                            }
                        }
                    }
                    
                    strHostName = Dns.GetHostName();
                    ///////////////////////////////////////////////////////////////////////////////////
                    message.IsBodyHtml = true;
            //        message.AlternateViews.Add(getEmbeddedImage(" //192.168.1.101/Aplicativos/CBR Sistema global/logo_cbr.png"));
                 
                    message.Subject = "Inicio de Sesion ";

                    client.Send(message);
                   


                    this.Hide();
                    General genera = new General();
                    General21 general = new General21();
                    general.Nombre = Nombre;               
                    general.Apellido = Apellido;
                    general.Permiso = Permisos;
                    general.Puesto = Puesto;
                    general.Departamento = Departamento;
                    general.Email = Email;
                    genera.Cif1 = XcifradoX;
                    genera.Var1 = Xvariable;
                    genera.Cif2 = XcifradoXY;
                    genera.Var2 = XvariableY;
                    genera.Cif3 = XcifradoXYz;
                    genera.Var3 = XvariableYz;
                    genera.Cif4 = XcifradoXYzt;
                    genera.Var4 = XvariableYzt;


      
                    general.Apellido = Apellido;
                    general.Permiso = Permisos;
                    general.Puesto = Puesto;
                    general.Departamento = Departamento;
                    general.Email = Email;
                    general.Show();
                    // genera.Show();
                    Bienvenida_Principal apertura = new Bienvenida_Principal();
                    //apertura.Show();
                    //apertura.BringToFront();
                    //apertura.WindowState = FormWindowState.Normal;

                    Notification apertura1 = new Notification();
                    apertura1.Show();

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
        private AlternateView getEmbeddedImage(String filePath)
        {
           
            // below line was corrected to include the mediatype so it displays in all 
            // mail clients. previous solution only displays in Gmail the inline images 
            LinkedResource res = new LinkedResource(filePath, MediaTypeNames.Image.Jpeg);
            res.ContentId = Guid.NewGuid().ToString();
            String Body = "<DIV><H5>Nuevo inicio de sesion en Cbr App</HEAD></DIV></H>";
            Body += "<DIV>Notamos que hubo un nuevo inicio de sesión en tu cuenta. Estos son los datos detallados del acceso </DIV>" +
             "<DIV>IP local:  " + localIP + "</DIV>" +
             "<DIV>IP Publica:  " + externalip + "</DIV>" +
             "<DIV>MAC:" + mac + "</DIV>" +
             "<DIV>Nombre del equipo:"+""+"" + strHostName + "</DIV>" +
            "<DIV>Host:" + "" + "" + host + "</DIV>" +
            "<DIV>Ciudad:" + "" + "" + cuidad + "</DIV>" +
            "<DIV>Estado:" + "" + "" + estado + "</DIV>" +
             "<DIV>Pais:" + "" + "" + pais + "</DIV>" +
             "<DIV>CP:" + "" + "" + CP + "</DIV>" +
               "<DIV>Proveedor:"+" "+ ""+ Proveedor + "</DIV>" +
            "<DIV>Si no reconoces este inicio de sesion, te recomendamos que contactes con el area de sistemas</DIV>";


            string htmlBody ="" +Body+""+@"<img src='cid:" + res.ContentId + @"'/> ";
            AlternateView alternateView = AlternateView.CreateAlternateViewFromString(htmlBody,
             null, MediaTypeNames.Text.Html);
            alternateView.LinkedResources.Add(res);
            return alternateView;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void pictureBox6_DoubleClick(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Ingresa_Click(object sender, EventArgs e)
        {
            Logear(this.Txt_Nombre.Text, this.Txt_Password.Text);

      


        }
        public void MostrarCuadroInicio()
        {
            Loading Cargando = new Loading();
            
            Cargando.ShowDialog();

        }

        public static string FolderPath => string.Concat(Directory.GetCurrentDirectory(),
  "\\VPN");

        private void pictureBox6_Click_1(object sender, EventArgs e)
        {

            //File.WriteAllText(FolderPath + "\\VpnDisconnect.bat", "rasdial /d");

            //var newProcess = new Process
            //{
            //    StartInfo =
            //    {
            //        FileName = FolderPath + "\\VpnDisconnect.bat",
            //        WindowStyle = ProcessWindowStyle.Minimized
            //    }
            //};

            //NetworkDrive oNetDrive1 = new NetworkDrive();
            //try
            //{
            //    //set propertys
            //    oNetDrive1.Force = true;
            //    oNetDrive1.LocalDrive = "G";
            //    oNetDrive1.ShareName = url.Text;
            //    //match call to options provided
            //    oNetDrive1.MapDrive();

            //    //update status
            //}
            //catch (Exception err)
            //{
            //    //report error

            //    MessageBox.Show(this, "Cannot map drive!\nError: " + err.Message);

            //}

            //NetworkDrive oNetDrive = new NetworkDrive();

            //try
            //{

            //    oNetDrive.LocalDrive = "G";
            //    oNetDrive.UnMapDrive();

            //    //update status
            //}
            //catch (Exception err)
            //{
            //    //report error

            //    MessageBox.Show(this, "Cannot map drive!\nError: " + err.Message);

            //}
            string strCmdText;
            strCmdText = "/C attrib +h +s G:\\SGC-PROYECTOS-CBR ";
            Process cop = System.Diagnostics.Process.Start("CMD.exe", strCmdText);
            cop.WaitForExit();
            strCmdText = "/C attrib -h +- G:\\SGC";
            Process cop1 = System.Diagnostics.Process.Start("CMD.exe", strCmdText);
            cop1.WaitForExit();
            strCmdText = "/C attrib +h +s G:\\Sistema ";
            Process cop2 = System.Diagnostics.Process.Start("CMD.exe", strCmdText);
            cop2.WaitForExit();


            this.Hide();
            Close();
            Application.Exit();
        }

        private void Login_KeyPress(object sender, KeyPressEventArgs e)
        {
            Logear(this.Txt_Nombre.Text, this.Txt_Password.Text);
        }

        private void Txt_Password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Logear(this.Txt_Nombre.Text, this.Txt_Password.Text);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Reestablecimiento reestablece = new Reestablecimiento();
     
            reestablece.Show();

        }

        private void Txt_Password_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Logear(this.Txt_Nombre.Text, this.Txt_Password.Text);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            General21 general = new General21();
            general.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Txt_Nombre_Click(object sender, EventArgs e)
        {
            Txt_Nombre.Text = "";
        }

        private void Txt_Password_Click(object sender, EventArgs e)
        {
            Txt_Password.Text = "";
        }

        private void btnminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            
                if (Txt_Password.PasswordChar == '*')
                {
                Txt_Password.PasswordChar = '\0';
                }
                else
                {
                Txt_Password.PasswordChar = '*';
                }
            
        }

        private void Login_Load(object sender, EventArgs e)
        {
           
        }

   
    }
}


