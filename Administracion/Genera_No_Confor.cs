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
using System.Net;
using CBR_ADMIN.Properties;
using System.Data.SqlClient;
using System.Net.Mime;
using System.Threading;
using CBR_ADMIN.Sistema;

namespace CBR_ADMIN.Administracion
{
    public partial class Genera_No_Confor : UserControl
    {
        public Genera_No_Confor()
        {
            InitializeComponent();
        }
        private static Genera_No_Confor _instance;
        public static Genera_No_Confor Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Genera_No_Confor();
                return _instance;
            } }
        public string Ventana1, Nombre,Departamento,Reporta,Responsable,Fecha,Email1,Email2,Email3,Email4,Email5, EmailAsis;
        string NoConfor;
        int noconfor;
        public static string ObtenerCadena()
        {
            return Settings.Default.CBR_IngenieriaConnectionString;/*Este codigo obtiene los datos de la cadena de conexion declarada en los settings de la aplicacion*/
        }
        SqlConnection conexion = new SqlConnection(ObtenerCadena());

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            CB_Dep.Text = "General";
        }

        private void Genera_No_Confor_Load(object sender, EventArgs e)
        {
            this.login_DepartamentosTableAdapter.FillBy1(cBR_Login_Dep.Login_Departamentos);
            this.departamentosTableAdapter.Fill(cBR_Departamento.Departamentos);
           
            CB_Nombre.Text = ""; CB_Nomb1.Text = ""; CB_Nom2.Text = ""; CB_Nom3.Text = ""; CB_Nom4.Text = ""; CB_Nom5.Text = "";
            CB_Apellido.Text = ""; CB_Apell1.Text = ""; CB_Apell2.Text = ""; CB_Apell3.Text = ""; CB_Apell4.Text = ""; CB_Apell5.Text = "";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CB_Dep.Text = "General";
          
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            CB_Dep.Text = "General";
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            CB_Dep.Text = "General";
        }

        private void MostrarCuadroInicio()
        {
            Loading Cargando = new Loading();
            Cargando.ShowDialog();

        }
        private void button1_Click(object sender, EventArgs e)
        {
             
            ThreadStart proceso = new ThreadStart(MostrarCuadroInicio);
            Thread hilo = new Thread(proceso);

           if (CB_Nomb1.Text =="" && CB_Apell1.Text == "") { MessageBox.Show("Falta Nombre y Apellido Responsable 1"); }
           else if (CB_Nomb1.Text ==  "") { MessageBox.Show("Falta Nombre  Responsable 1"); }
           else if (CB_Apell1.Text == "") { MessageBox.Show("Falta Apellido Responsable 1"); }
            else if (tipo.Text == "") { MessageBox.Show("Falta seleccionar el tipo de conformidad"); }

            if (CB_Nombre.Text == "" && CB_Apellido.Text == "") { MessageBox.Show("Falta Nombre y Apellido Persona que reporta"); }
            else if (CB_Nombre.Text == "") { MessageBox.Show("Falta Nombre  Pprsona que reporta"); }
            else if (CB_Apellido.Text == "") { MessageBox.Show("Falta Apellido persona que reporta"); }
            else if (Descrip.Text == "") { MessageBox.Show("Falta agregar la descripción"); }
            else {
                    DialogResult Resultado;
                    Resultado = MessageBox.Show("Está seguro que desea registrar la no Conformidad ", "Confirmación", MessageBoxButtons.YesNo);
                    if (Resultado == DialogResult.Yes)
                    {
                        hilo.Start(); hilo.Join(200);
                        NC();


                        //Fecha = Fechacompromiso.Value.ToString("MM-dd-yyyy");
                        DateTime Fechaf = DateTime.Parse(Fechacompromiso.Text);




                        int idDEparta = 0;
                        if (CB_Dep.Text == "Atencion a clientes") { idDEparta = 1; }
                        else if (CB_Dep.Text == "Compras") { idDEparta = 2; }
                        else if (CB_Dep.Text == "Ventas") { idDEparta = 3; }
                        else if (CB_Dep.Text == "Administracion") { idDEparta = 4; }
                        else if (CB_Dep.Text == "Potabiliza") { idDEparta = 5; }
                        else if (CB_Dep.Text == "Asistente de direccion") { idDEparta = 6; }
                        else if (CB_Dep.Text == "Cobranza") { idDEparta = 7; }
                        else if (CB_Dep.Text == "Instalaciones") { idDEparta = 8; }
                        else if (CB_Dep.Text == "Proyectos") { idDEparta = 9; }
                        else if (CB_Dep.Text == "Mantenimiento") { idDEparta = 10; }
                        else if (CB_Dep.Text == "Produccion") { idDEparta = 11; }
                        else if (CB_Dep.Text == "Sistemas") { idDEparta = 12; }
                        else if (CB_Dep.Text == "Dirección General") { idDEparta = 13; }
                        else if (CB_Dep.Text == "Director de Operaciones") { idDEparta = 14; }
                        else if (CB_Dep.Text == "General") { idDEparta = 15; }


                        Reporta = CB_Nombre.Text + " " + " " + CB_Apellido.Text;


                        if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false)
                        { Responsable = CB_Nomb1.Text + " " + " " + CB_Apell1.Text; usuario(this.CB_Nomb1.Text, this.CB_Apell1.Text);
                            Email2 = "support@cbr-ingenieria.com.mx";
                            Email3 = "support@cbr-ingenieria.com.mx";
                            Email4 = "support@cbr-ingenieria.com.mx";
                            Email5 = "support@cbr-ingenieria.com.mx";
                            CB_Dep.Text = "General";
                        }
                        if (checkBox1.Checked == true && checkBox2.Checked == false && checkBox3.Checked == false && checkBox4.Checked == false)
                        { Responsable = CB_Nomb1.Text + " " + " " + CB_Apell1.Text + "/" + CB_Nom2.Text + " " + " " + CB_Apell2.Text;
                            usuario(this.CB_Nomb1.Text, this.CB_Apell1.Text);
                            usuario2(this.CB_Nom2.Text, this.CB_Apell2.Text);
                            Email3 = "support@cbr-ingenieria.com.mx";
                            Email4 = "support@cbr-ingenieria.com.mx";
                            Email5 = "support@cbr-ingenieria.com.mx";
                            CB_Dep.Text = "General";
                        }
                        if (checkBox1.Checked == true && checkBox2.Checked == true && checkBox3.Checked == false && checkBox4.Checked == false)
                        { Responsable = CB_Nomb1.Text + " " + " " + CB_Apell1.Text + "/" + CB_Nom2.Text + " " + " " + CB_Apell2.Text + "/" + CB_Nom3.Text + " " + " " + CB_Apell3.Text;
                            usuario(this.CB_Nomb1.Text, this.CB_Apell1.Text);
                            usuario2(this.CB_Nom2.Text, this.CB_Apell2.Text);
                            usuario3(this.CB_Nom3.Text, this.CB_Apell3.Text);
                            Email4 = "support@cbr-ingenieria.com.mx";
                            Email5 = "support@cbr-ingenieria.com.mx";
                            CB_Dep.Text = "General";
                        }
                        if (checkBox1.Checked == true && checkBox2.Checked == true && checkBox3.Checked == true && checkBox4.Checked == false)
                        { Responsable = CB_Nomb1.Text + " " + " " + CB_Apell1.Text + "/" + CB_Nom2.Text + " " + " " + CB_Apell2.Text + "/" + CB_Nom3.Text + " " + " " + CB_Apell3.Text + "/" + CB_Nom4.Text + " " + " " + CB_Apell4.Text;
                            usuario(this.CB_Nomb1.Text, this.CB_Apell1.Text);
                            usuario2(this.CB_Nom2.Text, this.CB_Apell2.Text);
                            usuario3(this.CB_Nom3.Text, this.CB_Apell3.Text);
                            usuario4(this.CB_Nom4.Text, this.CB_Apell4.Text);
                            Email5 = "support@cbr-ingenieria.com.mx";
                            CB_Dep.Text = "General";
                        }
                        if (checkBox1.Checked == true && checkBox2.Checked == true && checkBox3.Checked == true && checkBox4.Checked == true)
                        { Responsable = CB_Nomb1.Text + " " + " " + CB_Apell1.Text + "/" + CB_Nom2.Text + " " + " " + CB_Apell2.Text + "/" + CB_Nom3.Text + " " + " " + CB_Apell3.Text + "/" + CB_Nom4.Text + " " + " " + CB_Apell4.Text + "/" + CB_Nom5.Text + " " + " " + CB_Apell5.Text;
                            usuario(this.CB_Nomb1.Text, this.CB_Apell1.Text);
                            usuario2(this.CB_Nom2.Text, this.CB_Apell2.Text);
                            usuario3(this.CB_Nom3.Text, this.CB_Apell3.Text);
                            usuario4(this.CB_Nom4.Text, this.CB_Apell4.Text);
                            usuario5(this.CB_Nom5.Text, this.CB_Apell5.Text);
                            CB_Dep.Text = "General";
                        }



                        this.no_ConformidadesTableAdapter.InserNC(noconfor, tipo.Text, Fechaf, Reporta, Descrip.Text, Responsable, CB_Dep.Text, idDEparta);


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
                        message.Subject = "Levantamiento de nueva no conformidad";
                        message.IsBodyHtml = true;
                        message.AlternateViews.Add(getEmbeddedImage("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                        client.Send(message);
                        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                        MailMessage message2 = new MailMessage(_sender, Email2);
                        message2.Subject = "Levantamiento de nueva no conformidad";
                        message2.IsBodyHtml = true;
                        message2.AlternateViews.Add(getEmbeddedImage("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                        client.Send(message2);
                        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        MailMessage message3 = new MailMessage(_sender, Email3);
                        message3.Subject = "Levantamiento de nueva no conformidad";
                        message3.IsBodyHtml = true;
                        message3.AlternateViews.Add(getEmbeddedImage("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                        client.Send(message3);
                        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        MailMessage message4 = new MailMessage(_sender, Email4);
                        message4.Subject = "Levantamiento de nueva no conformidad";
                        message4.IsBodyHtml = true;
                        message4.AlternateViews.Add(getEmbeddedImage("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                        client.Send(message4);
                        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        MailMessage message5 = new MailMessage(_sender, Email5);
                        message5.Subject = "Levantamiento de nueva no conformidad";
                        message5.IsBodyHtml = true;
                        message5.AlternateViews.Add(getEmbeddedImage("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
                        client.Send(message5);



                        enviaAsis();


                        DialogResult Resultado2;
                        hilo.Abort();
                        Resultado2 = MessageBox.Show("Generada correctamente");

                        tipo.Text = "";
                        CB_Nombre.Text = "";
                        CB_Apellido.Text = "";
                        CB_Nomb1.Text = "";
                        CB_Apell1.Text = "";
                        CB_Dep.Text = "";
                        Descrip.Text = "";

                    }
                    else if (Resultado == DialogResult.No)
                    {
                        hilo.Abort();
                        MessageBox.Show("Operacion Cancelada");
                    }

                }

          

        }

        private AlternateView getEmbeddedImage(String filePath)
        {
            // below line was corrected to include the mediatype so it displays in all 
            // mail clients. previous solution only displays in Gmail the inline images 
            LinkedResource res = new LinkedResource(filePath, MediaTypeNames.Image.Jpeg);
            res.ContentId = Guid.NewGuid().ToString();
            String Body = "<DIV><H5>Se ha generado una nueva no conformidad</HEAD></DIV></H>";
            Body += "<DIV>Ingrese a su perfil para darle seguimiento </DIV>";
           
           


            string htmlBody = "" + Body + "" + @"<img src='cid:" + res.ContentId + @"'/> ";
            AlternateView alternateView = AlternateView.CreateAlternateViewFromString(htmlBody,
             null, MediaTypeNames.Text.Html);
            alternateView.LinkedResources.Add(res);
            return alternateView;
        }

        public void usuario(string usuario, string apellido)
        {
            int NoConf;
            NoConf = Int32.Parse(NoConfor);
            noconfor = NoConf + 1;
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
                cmd.Parameters.AddWithValue("nombre", CB_Nomb1.Text);
                cmd.Parameters.AddWithValue("apellido", CB_Apell1.Text);


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

                    this.no_Conformidades_usuarioTableAdapter.Inserta(noconfor, CB_Nomb1.Text, CB_Apell1.Text, "Abierta",Email1);


                }
                ////////////////////////////////////SI EL USUARIO, CONTRASENA O PLANTA ESTA MAL//////////////////////////////////////////////////////////////////////////
                else
                {
                    MessageBox.Show("Sin datos de correo registrado");
                    this.no_Conformidades_usuarioTableAdapter.Inserta(noconfor, CB_Nomb1.Text, CB_Apell1.Text, "Abierta", "");
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
        public void usuario2(string usuario, string apellido)
        {
            int NoConf;
            NoConf = Int32.Parse(NoConfor);
            noconfor = NoConf + 1;
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
                cmd.Parameters.AddWithValue("nombre", CB_Nom2.Text);
                cmd.Parameters.AddWithValue("apellido", CB_Apell2.Text);


                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.SelectCommand.CommandTimeout = 36000;
                DataTable dt = new DataTable();
                sda.Fill(dt);

                conexion.Dispose();

                if (dt.Rows.Count > 0)
                {
                    //MessageBox.Show("Si tiene acceso a esta planta");
                    // this.Close();

                    Email2 = dt.Rows[0][7].ToString();

                    this.no_Conformidades_usuarioTableAdapter.Inserta(noconfor, CB_Nom2.Text, CB_Apell2.Text, "Abierta", Email2);


                }
                ////////////////////////////////////SI EL USUARIO, CONTRASENA O PLANTA ESTA MAL//////////////////////////////////////////////////////////////////////////
                else
                {
                    MessageBox.Show("Sin datos de correo registrado");
                    this.no_Conformidades_usuarioTableAdapter.Inserta(noconfor, CB_Nom2.Text, CB_Apell2.Text, "Abierta", "");
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
        public void usuario3(string usuario, string apellido)
        {
            int NoConf;
            NoConf = Int32.Parse(NoConfor);
            noconfor = NoConf + 1;
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
                cmd.Parameters.AddWithValue("nombre", CB_Nom3.Text);
                cmd.Parameters.AddWithValue("apellido", CB_Apell3.Text);


                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.SelectCommand.CommandTimeout = 36000;
                DataTable dt = new DataTable();
                sda.Fill(dt);

                conexion.Dispose();

                if (dt.Rows.Count > 0)
                {
                    //MessageBox.Show("Si tiene acceso a esta planta");
                    // this.Close();

                    Email3 = dt.Rows[0][7].ToString();

                    this.no_Conformidades_usuarioTableAdapter.Inserta(noconfor, CB_Nom3.Text, CB_Apell3.Text, "Abierta", Email3);


                }
                ////////////////////////////////////SI EL USUARIO, CONTRASENA O PLANTA ESTA MAL//////////////////////////////////////////////////////////////////////////
                else
                {
                    MessageBox.Show("Sin datos de correo registrado");
                    this.no_Conformidades_usuarioTableAdapter.Inserta(noconfor, CB_Nom3.Text, CB_Apell3.Text, "Abierta", "");
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
        public void usuario4(string usuario, string apellido)
        {
            int NoConf;
            NoConf = Int32.Parse(NoConfor);
            noconfor = NoConf + 1;
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
                cmd.Parameters.AddWithValue("nombre", CB_Nom4.Text);
                cmd.Parameters.AddWithValue("apellido", CB_Apell4.Text);


                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.SelectCommand.CommandTimeout = 36000;
                DataTable dt = new DataTable();
                sda.Fill(dt);

                conexion.Dispose();

                if (dt.Rows.Count > 0)
                {
                    //MessageBox.Show("Si tiene acceso a esta planta");
                    // this.Close();

                    Email4 = dt.Rows[0][7].ToString();

                    this.no_Conformidades_usuarioTableAdapter.Inserta(noconfor, CB_Nom4.Text, CB_Apell4.Text, "Abierta", Email4);


                }
                ////////////////////////////////////SI EL USUARIO, CONTRASENA O PLANTA ESTA MAL//////////////////////////////////////////////////////////////////////////
                else
                {
                    MessageBox.Show("Sin datos de correo registrado");
                    this.no_Conformidades_usuarioTableAdapter.Inserta(noconfor, CB_Nom4.Text, CB_Apell4.Text, "Abierta", "");
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
        public void usuario5(string usuario, string apellido)
        {
            int NoConf;
            NoConf = Int32.Parse(NoConfor);
            noconfor = NoConf + 1;
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
                cmd.Parameters.AddWithValue("nombre", CB_Nom5.Text);
                cmd.Parameters.AddWithValue("apellido", CB_Apell5.Text);


                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.SelectCommand.CommandTimeout = 36000;
                DataTable dt = new DataTable();
                sda.Fill(dt);

                conexion.Dispose();

                if (dt.Rows.Count > 0)
                {
                    //MessageBox.Show("Si tiene acceso a esta planta");
                    // this.Close();

                    Email5 = dt.Rows[0][7].ToString();

                    this.no_Conformidades_usuarioTableAdapter.Inserta(noconfor, CB_Nom5.Text, CB_Apell5.Text, "Abierta", Email5);


                }
                ////////////////////////////////////SI EL USUARIO, CONTRASENA O PLANTA ESTA MAL//////////////////////////////////////////////////////////////////////////
                else
                {
                    MessageBox.Show("Sin datos de correo registrado");
                    this.no_Conformidades_usuarioTableAdapter.Inserta(noconfor, CB_Nom5.Text, CB_Apell5.Text, "Abierta", "");
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
                    message.Subject = "Levantamiento de nueva NO Conformidad";
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
        private AlternateView getEmbeddedImage2(String filePath)
        {
            // below line was corrected to include the mediatype so it displays in all 
            // mail clients. previous solution only displays in Gmail the inline images 
            LinkedResource res = new LinkedResource(filePath, MediaTypeNames.Image.Jpeg);
            res.ContentId = Guid.NewGuid().ToString();
            String Body = "<DIV><H5>Se ha generado una No conformidad para el departamento de:</HEAD></DIV></H>" + CB_Dep.Text;

            string htmlBody = "" + Body + "" + @"<img src='cid:" + res.ContentId + @"'/> ";
            AlternateView alternateView = AlternateView.CreateAlternateViewFromString(htmlBody,
             null, MediaTypeNames.Text.Html);
            alternateView.LinkedResources.Add(res);
            return alternateView;
        }
        public void NC()
        {
            try
            {
                ////////////////////////////////////SE ABRE LA CONEXION/////////////////////////////////////////////////////////////////////////////////
                SqlConnection conexion = new SqlConnection(ObtenerCadena());
                conexion.Open();
                ////////////////////////////////////SE EJECUTA EL COMANDO HACIA LA VISTA Y SE HACE LA VALIDACION//////////////////////////////////////
                SqlCommand cmd = new SqlCommand(
                                                "select " +
                                                "[# NC]"+
                                                "from [No_Conformidades]   order by [# NC]"
                                                , conexion);
              


                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.SelectCommand.CommandTimeout = 36000;
                DataTable dt = new DataTable();
                sda.Fill(dt);

                conexion.Dispose();

                if (dt.Rows.Count > 0)
                {
                    //MessageBox.Show("Si tiene acceso a esta planta");
                    // this.Close();
                    int d = dt.Rows.Count - 1;

                    NoConfor = dt.Rows[d][0].ToString();
                  


                    // NoConfor = [dt.Rows.Count][0].ToString();


                }
                ////////////////////////////////////SI EL USUARIO, CONTRASENA O PLANTA ESTA MAL//////////////////////////////////////////////////////////////////////////
                else
                {
                    MessageBox.Show("Sin datos ");
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



    }
}
