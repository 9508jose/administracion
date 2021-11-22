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
using System.Threading;
using CBR_ADMIN.Sistema;

namespace CBR_ADMIN.Administracion
{
    public partial class Seguimiento_No_confor : UserControl
    {
        public string Ventana1, Nombre, Apellido, Departamento, NoConfor, Responsable, Fecha, Email1, Email2, valor, descpcorrec, resultado, FechaComp, Resultaco, catcau, name, analisis, rep, origen, Descpac, doc, fechacomp, fechaaccion, resultaac, responsabac;
        int nc;
        private static Seguimiento_No_confor _instance;
        public static Seguimiento_No_confor Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Seguimiento_No_confor();
                return _instance;
            }

    
    }
        public Seguimiento_No_confor()
        {
            InitializeComponent();
        }
      

        private void Causas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.RowIndex >= 0 && e.ColumnIndex > 0)
                {

                    nc = Convert.ToInt32(Correcciones.Rows[e.RowIndex].Cells[0].FormattedValue.ToString());
                    descpcorrec = (Correcciones.Rows[e.RowIndex].Cells[1].FormattedValue.ToString());
                    FechaComp = (Correcciones.Rows[e.RowIndex].Cells[2].FormattedValue.ToString());
                    Resultaco = (Correcciones.Rows[e.RowIndex].Cells[4].FormattedValue.ToString());
                    catcau = (Causas.Rows[e.RowIndex].Cells[1].FormattedValue.ToString());
                    name = (Causas.Rows[e.RowIndex].Cells[0].FormattedValue.ToString());
                    analisis = (Causas.Rows[e.RowIndex].Cells[2].FormattedValue.ToString());
                    rep = (Causas.Rows[e.RowIndex].Cells[3].FormattedValue.ToString());
                    origen = (Causas.Rows[e.RowIndex].Cells[4].FormattedValue.ToString());
                    Descpac = (Acciones_Correctivas.Rows[e.RowIndex].Cells[0].FormattedValue.ToString());
                    doc = (Acciones_Correctivas.Rows[e.RowIndex].Cells[1].FormattedValue.ToString());
                    fechacomp = (Acciones_Correctivas.Rows[e.RowIndex].Cells[2].FormattedValue.ToString());
                    fechaaccion = (Acciones_Correctivas.Rows[e.RowIndex].Cells[3].FormattedValue.ToString());
                    resultaac = (Acciones_Correctivas.Rows[e.RowIndex].Cells[5].FormattedValue.ToString());
                    responsabac = (Acciones_Correctivas.Rows[e.RowIndex].Cells[4].FormattedValue.ToString());

                    DescripcionCorrectiva.Text = descpcorrec.ToString();
                    FechacompromisoC.Text = FechaComp.ToString();
                    ResultadoC.Text = Resultaco.ToString();
                    NameDT.Text = name.ToString();
                    Categoria_causa.Text = catcau.ToString();
                    Descripcion_Causa.Text = analisis.ToString();
                    CB_Nombre.Text = "";
                    CB_Apellido.Text = "";
                    CB_Procesos.Text = rep.ToString();
                    Cb_Origen_Proceso.Text = origen.ToString();
                    Descripcion_correctiva.Text = Descpac.ToString();
                    Documento.Text = doc.ToString();
                    FechaCompromisaAC.Text = fechacomp.ToString();
                    Fecha_Cierre.Text = fechaaccion.ToString();
                    Resultado_AC.Text = resultaac.ToString();
                    Responsable_AC.Text = responsabac.ToString();


                    keyNC.Text = nc.ToString();
                    KeyNC1.Text = nc.ToString();
                    KeyNC2.Text = nc.ToString();
                }
                else
                {
                    nc = 0;
                    keyNC.Text = nc.ToString();



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }

        private void Acciones_Correctivas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.RowIndex >= 0 && e.ColumnIndex > 0)
                {

                    nc = Convert.ToInt32(Correcciones.Rows[e.RowIndex].Cells[0].FormattedValue.ToString());
                    descpcorrec = (Correcciones.Rows[e.RowIndex].Cells[1].FormattedValue.ToString());
                    FechaComp = (Correcciones.Rows[e.RowIndex].Cells[2].FormattedValue.ToString());
                    Resultaco = (Correcciones.Rows[e.RowIndex].Cells[4].FormattedValue.ToString());
                    catcau = (Causas.Rows[e.RowIndex].Cells[1].FormattedValue.ToString());
                    name = (Causas.Rows[e.RowIndex].Cells[0].FormattedValue.ToString());
                    analisis = (Causas.Rows[e.RowIndex].Cells[2].FormattedValue.ToString());
                    rep = (Causas.Rows[e.RowIndex].Cells[3].FormattedValue.ToString());
                    origen = (Causas.Rows[e.RowIndex].Cells[4].FormattedValue.ToString());
                    Descpac = (Acciones_Correctivas.Rows[e.RowIndex].Cells[0].FormattedValue.ToString());
                    doc = (Acciones_Correctivas.Rows[e.RowIndex].Cells[1].FormattedValue.ToString());
                    fechacomp = (Acciones_Correctivas.Rows[e.RowIndex].Cells[2].FormattedValue.ToString());
                    fechaaccion = (Acciones_Correctivas.Rows[e.RowIndex].Cells[3].FormattedValue.ToString());
                    resultaac = (Acciones_Correctivas.Rows[e.RowIndex].Cells[5].FormattedValue.ToString());
                    responsabac = (Acciones_Correctivas.Rows[e.RowIndex].Cells[4].FormattedValue.ToString());

                    DescripcionCorrectiva.Text = descpcorrec.ToString();
                    FechacompromisoC.Text = FechaComp.ToString();
                    ResultadoC.Text = Resultaco.ToString();
                    NameDT.Text = name.ToString();
                    Categoria_causa.Text = catcau.ToString();
                    Descripcion_Causa.Text = analisis.ToString();
                    CB_Nombre.Text = "";
                    CB_Apellido.Text = "";
                    CB_Procesos.Text = rep.ToString();
                    Cb_Origen_Proceso.Text = origen.ToString();
                    Descripcion_correctiva.Text = Descpac.ToString();
                    Documento.Text = doc.ToString();
                    FechaCompromisaAC.Text = fechacomp.ToString();
                    Fecha_Cierre.Text = fechaaccion.ToString();
                    Resultado_AC.Text = resultaac.ToString();
                    Responsable_AC.Text = responsabac.ToString();


                    keyNC.Text = nc.ToString();
                    KeyNC1.Text = nc.ToString();
                    KeyNC2.Text = nc.ToString();
                }
                else
                {
                    nc = 0;
                    keyNC.Text = nc.ToString();



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }

        public static string ObtenerCadena()
        {
            return Settings.Default.CBR_IngenieriaConnectionString;/*Este codigo obtiene los datos de la cadena de conexion declarada en los settings de la aplicacion*/
        }

        private void comboBox1_MouseCaptureChanged(object sender, EventArgs e)
        {
            if (CB_AC.Text == "Si") {
                DescripcionCorrectiva.Text = "";
                ResultadoC.Text = "";
                CB_Nombre.Text = "";
                CB_Apellido.Text = "";
                Categoria_causa.Text = "";
                Descripcion_Causa.Text = "";
                CB_Procesos.Text = "";
                Cb_Origen_Proceso.Text = "";
                Descripcion_correctiva.Text = "";
                Documento.Text = "";
                Responsable_AC.Text = "";
                Resultado_AC.Text = "";
            }
            else if (CB_AC.Text == "No")
            {
                DescripcionCorrectiva.Text = "NA";
                ResultadoC.Text = "NA";
                CB_Nombre.Text = "NA";
                CB_Apellido.Text = "NA";
                Categoria_causa.Text = "NA";
                Descripcion_Causa.Text = "NA";
                CB_Procesos.Text = "NA";
                Cb_Origen_Proceso.Text = "NA";
                Descripcion_correctiva.Text = "NA";
                Documento.Text = "NA";
                Responsable_AC.Text = "NA";
                Resultado_AC.Text = "NA";

            }
        }

        private void CB_AC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CB_AC.Text == "Si")
            {
                DescripcionCorrectiva.Text = "";
                ResultadoC.Text = "";
                CB_Nombre.Text = "";
                CB_Apellido.Text = "";
                Categoria_causa.Text = "";
                Descripcion_Causa.Text = "";
                CB_Procesos.Text = "";
                Cb_Origen_Proceso.Text = "";
                Descripcion_correctiva.Text = "";
                Documento.Text = "";
                Responsable_AC.Text = "";
                Resultado_AC.Text = "";
            }
            else if (CB_AC.Text == "No")
            {
                DescripcionCorrectiva.Text = "NA";
                ResultadoC.Text = "NA";
                CB_Nombre.Text = "NA";
                CB_Apellido.Text = "NA";
                Categoria_causa.Text = "NA";
                Descripcion_Causa.Text = "NA";
                CB_Procesos.Text = "NA";
                Cb_Origen_Proceso.Text = "NA";
                Descripcion_correctiva.Text = "NA";
                Documento.Text = "NA";
                Responsable_AC.Text = "NA";
                Resultado_AC.Text = "NA";

            }
        }

        SqlConnection conexion = new SqlConnection(ObtenerCadena());



        private void MostrarCuadroInicio()
        {
            Loading Cargando = new Loading();
            Cargando.ShowDialog();

        }

        private void Correcciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.RowIndex >= 0 && e.ColumnIndex > 0)
                {

                    nc = Convert.ToInt32(Correcciones.Rows[e.RowIndex].Cells[0].FormattedValue.ToString());
                    descpcorrec = (Correcciones.Rows[e.RowIndex].Cells[1].FormattedValue.ToString());
                    FechaComp = (Correcciones.Rows[e.RowIndex].Cells[2].FormattedValue.ToString());
                    Resultaco = (Correcciones.Rows[e.RowIndex].Cells[4].FormattedValue.ToString());
                    catcau = (Causas.Rows[e.RowIndex].Cells[1].FormattedValue.ToString());
                    name = (Causas.Rows[e.RowIndex].Cells[0].FormattedValue.ToString());
                    analisis = (Causas.Rows[e.RowIndex].Cells[2].FormattedValue.ToString());
                    rep = (Causas.Rows[e.RowIndex].Cells[3].FormattedValue.ToString());
                    origen = (Causas.Rows[e.RowIndex].Cells[4].FormattedValue.ToString());
                    Descpac = (Acciones_Correctivas.Rows[e.RowIndex].Cells[0].FormattedValue.ToString());
                    doc = (Acciones_Correctivas.Rows[e.RowIndex].Cells[1].FormattedValue.ToString());
                    fechacomp = (Acciones_Correctivas.Rows[e.RowIndex].Cells[2].FormattedValue.ToString());
                    fechaaccion = (Acciones_Correctivas.Rows[e.RowIndex].Cells[3].FormattedValue.ToString());
                    resultaac = (Acciones_Correctivas.Rows[e.RowIndex].Cells[5].FormattedValue.ToString());
                    responsabac = (Acciones_Correctivas.Rows[e.RowIndex].Cells[4].FormattedValue.ToString());

                    DescripcionCorrectiva.Text = descpcorrec.ToString();
                    FechacompromisoC.Text = FechaComp.ToString();
                    ResultadoC.Text = Resultaco.ToString();
                    NameDT.Text = name.ToString();
                    Categoria_causa.Text = catcau.ToString();
                    Descripcion_Causa.Text = analisis.ToString();
                    CB_Nombre.Text = "";
                    CB_Apellido.Text = "";
                    CB_Procesos.Text = rep.ToString();
                    Cb_Origen_Proceso.Text = origen.ToString();
                    Descripcion_correctiva.Text = Descpac.ToString();
                    Documento.Text = doc.ToString();
                    FechaCompromisaAC.Text = fechacomp.ToString();
                    Fecha_Cierre.Text = fechaaccion.ToString();
                    Resultado_AC.Text = resultaac.ToString();
                    Responsable_AC.Text = responsabac.ToString();


                    keyNC.Text = nc.ToString();
                    KeyNC1.Text = nc.ToString();
                    KeyNC2.Text = nc.ToString();
                }
                else
                {
                    nc = 0;
                    keyNC.Text = nc.ToString();



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            nc = Int32.Parse(CB_NC.Text);
            this.no_ConformidadesTableAdapter.rellenoSeg(this.cBR_No_Conf.No_Conformidades, nc);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.no_ConformidadesTableAdapter.Cons(this.cBR_No_Conf.No_Conformidades, Departamento);

            DescripcionCorrectiva.Text = "";
            FechacompromisoC.Text = "";
            ResultadoC.Text = "";
            NameDT.Text = "";
            Categoria_causa.Text = "";
            Descripcion_Causa.Text = "";
            CB_Nombre.Text = "";
            CB_Apellido.Text = "";
            CB_Procesos.Text = "";
            Cb_Origen_Proceso.Text = "";
            Descripcion_correctiva.Text = "";
            Documento.Text = "";
            FechaCompromisaAC.Text = "";
            Fecha_Cierre.Text = "";
            Resultado_AC.Text = "";
            Responsable_AC.Text = "";


            keyNC.Text = nc.ToString();
            KeyNC1.Text = nc.ToString();
            KeyNC2.Text = nc.ToString();
        }

        private void Correcciones_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
          

            try
            {
              
                if (e.RowIndex >= 0 && e.ColumnIndex > 0)
                {

                    valor = Correcciones.Rows[1].Cells[0].FormattedValue.ToString();
                    nc = Convert.ToInt32(Correcciones.Rows[e.RowIndex].Cells[0].FormattedValue.ToString());
                    descpcorrec = (Correcciones.Rows[e.RowIndex].Cells[1].FormattedValue.ToString());
                    DescripcionCorrectiva.Text = descpcorrec.ToString();
                    keyNC.Text = nc.ToString();
                }
                else
                {

                    valor = "";

              

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }

        private void Guardar_Click(object sender, EventArgs e)
        {
            ThreadStart proceso = new ThreadStart(MostrarCuadroInicio);
            Thread hilo = new Thread(proceso);
            String DepRevisor = "Asistente de direccion";


            DialogResult Resultado;
            Resultado = MessageBox.Show("Está seguro que desea actualizar el registro seleccionado ", "Confirmación", MessageBoxButtons.YesNo);
            if (Resultado == DialogResult.Yes)
            {
                hilo.Start();     hilo.Join(200);
                int Nc = Int32.Parse(CB_NC.Text);
                DateTime FechaCorreccion = DateTime.Parse(FechacompromisoC.Text);
                DateTime FechaAccionCom = DateTime.Parse(FechaCompromisaAC.Text);
                DateTime FechaAccionCierre = DateTime.Parse(Fecha_Cierre.Text);
                Responsable = CB_Nombre.Text + "" + CB_Apellido.Text;
                if (NameDT.Text == "" || NameDT.Text == "---")
                {
                    this.no_ConformidadesTableAdapter.Seguimiento(DescripcionCorrectiva.Text, FechaCorreccion, ResultadoC.Text, Responsable, Categoria_causa.Text, Descripcion_Causa.Text, CB_Procesos.Text, Cb_Origen_Proceso.Text, FechaAccionCom, FechaAccionCierre, Responsable_AC.Text, Resultado_AC.Text, Documento.Text, Descripcion_correctiva.Text, Nc);
                    this.no_ConformidadesTableAdapter.ActuaCom(this.cBR_No_Conf.No_Conformidades, Departamento);
                    hilo.Abort();
                    this.no_Conformidades_usuarioTableAdapter.Actualiza("Registrado", Nc);
                }
          else 
                {
                    this.no_ConformidadesTableAdapter.Seguimiento(DescripcionCorrectiva.Text, FechaCorreccion, ResultadoC.Text, NameDT.Text, Categoria_causa.Text, Descripcion_Causa.Text, CB_Procesos.Text, Cb_Origen_Proceso.Text, FechaAccionCom, FechaAccionCierre, Responsable_AC.Text, Resultado_AC.Text, Documento.Text, Descripcion_correctiva.Text, Nc);
                    this.no_ConformidadesTableAdapter.ActuaCom(this.cBR_No_Conf.No_Conformidades, Departamento);
                    hilo.Abort();
                    this.no_Conformidades_usuarioTableAdapter.Actualiza("Registrado", Nc);
                }

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
                usuario(Nombre, Apellido);
                revisor(DepRevisor);
                
                MailMessage message = new MailMessage(_sender, Email1);
                message.Subject = "Seguimiento de No conformidad";

                message.IsBodyHtml = true;
                message.AlternateViews.Add(getEmbeddedImage("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));

                client.Send(message);
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                if (CB_AC.Text == "No")
                {
                    MailMessage message2 = new MailMessage(_sender,Email2);
                    message2.Subject = "Seguimiento de No conformidad";

                    message2.IsBodyHtml = true;
                    message2.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));

                    client.Send(message2);
                }
                else if (CB_AC.Text == "Si") {
                    MailMessage message2 = new MailMessage(_sender, Email2);
                    message2.Subject = "Seguimiento de No conformidad";

                    message2.IsBodyHtml = true;
                    message2.AlternateViews.Add(getEmbeddedImage3("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));

                    client.Send(message2);
                }
            }
            else if (Resultado == DialogResult.No)
            {
                hilo.Abort();
                MessageBox.Show("Operacion Cancelada");
            }

        }


        private void Seguimiento_No_confor_Load(object sender, EventArgs e)
        {
            this.no_ConformidadesTableAdapter.Cons(this.cBR_No_Conf.No_Conformidades, Departamento);
            this.login_DepartamentosTableAdapter.Fill(this.cBR_Login_Dep.Login_Departamentos);
            nc = Int32.Parse(CB_NC.Text);



        }

        private AlternateView getEmbeddedImage(String filePath)
        {
            // below line was corrected to include the mediatype so it displays in all 
            // mail clients. previous solution only displays in Gmail the inline images 
            LinkedResource res = new LinkedResource(filePath, MediaTypeNames.Image.Jpeg);
            res.ContentId = Guid.NewGuid().ToString();
            String Body = "<DIV><H5>Se han realizado Actualizaciones de No conformidades en su perfil</DIV></H>";
            Body += "<DIV>Ingrese a su perfil para Verificarlo </DIV>";




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
            String Body = "<DIV><H5>Se han realizado Actualizaciones de No conformidades en modo Accion Correctica NA    Numero de NC:</DIV></H>"+ CB_NC.Text;
            Body += "<DIV>Ingrese a su perfil para Verificar</DIV>";




            string htmlBody = "" + Body + "" + @"<img src='cid:" + res.ContentId + @"'/> ";
            AlternateView alternateView = AlternateView.CreateAlternateViewFromString(htmlBody,
             null, MediaTypeNames.Text.Html);
            alternateView.LinkedResources.Add(res);
            return alternateView;
        }
        private AlternateView getEmbeddedImage3(String filePath)
        {
            // below line was corrected to include the mediatype so it displays in all 
            // mail clients. previous solution only displays in Gmail the inline images 
            LinkedResource res = new LinkedResource(filePath, MediaTypeNames.Image.Jpeg);
            res.ContentId = Guid.NewGuid().ToString();
            String Body = "<DIV><H5>Se han realizado Actualizaciones de No conformidades  Numero de NC:</DIV></H>" + CB_NC.Text;
            Body += "<DIV>Ingrese a su perfil para Verificar</DIV>";




            string htmlBody = "" + Body + "" + @"<img src='cid:" + res.ContentId + @"'/> ";
            AlternateView alternateView = AlternateView.CreateAlternateViewFromString(htmlBody,
             null, MediaTypeNames.Text.Html);
            alternateView.LinkedResources.Add(res);
            return alternateView;
        }

        public void usuario(string usuario, string apellido)
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
                cmd.Parameters.AddWithValue("nombre", usuario);
                cmd.Parameters.AddWithValue("apellido", apellido);


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

              


                }
                ////////////////////////////////////SI EL USUARIO, CONTRASENA O PLANTA ESTA MAL//////////////////////////////////////////////////////////////////////////
                else
                {
                    MessageBox.Show("Sin datos de correo registrado");
                   
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
        public void revisor(string departamento)
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
                cmd.Parameters.AddWithValue("Departamento", departamento);
              


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




                }
                ////////////////////////////////////SI EL USUARIO, CONTRASENA O PLANTA ESTA MAL//////////////////////////////////////////////////////////////////////////
                else
                {
                    MessageBox.Show("Sin datos de correo registrado");

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
