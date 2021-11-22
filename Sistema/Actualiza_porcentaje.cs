using CBR_ADMIN.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CBR_ADMIN.Sistema
{
    public partial class Actualiza_porcentaje : Form
    {
        int numerador, numerador2, numerador3, numerador4; string Nombre, Nombre2, nom3, Proyecto, Carpeta, Departamento; int suma, suma2, suma3, suma4, k, k1, k2, k4;
        String Archivototal, departamen, carpet, nombr, Nomproyectenvia;
        string
AtencionClientes
, AtencionClientes_Atencion
, AtencionClientes_EntregaDocumentos
, AtencionClientes_Postventa
, AtencionClientes_Encuesta
, Finanzas
, Finanzas_CierreProyecto
, Compraas
, DosierdeCalidad
, Ventas
, Ventas_AltayDocumentosClientes
, Ventas_PedidoInterno
, Ventas_ExpedienteComercial
, Proyectos
, Proyectos_ExpedienteTecnic
, Proyectos_Planos
, EquipamientoeInstalaciones
, EquipamientoeInstalaciones_FabricacionyEquipamiento
, EquipamientoeInstalaciones_Instalacionyarranque
, EquipamientoeInstalaciones_OperacionyMantenimiento
, General;

        private void Actualiza_porcentaje_Load(object sender, EventArgs e)
        {
            this.folio_ProyectosTableAdapter.Fill(this.folio_proyecto.Folio_Proyectos);
            // TODO: esta línea de código carga datos en la tabla 'proyectos_Avance.Proyectos_Avance' Puede moverla o quitarla según sea necesario.
            this.proyectos_AvanceTableAdapter.Fill(this.proyectos_Avance.Proyectos_Avance);
            // TODO: esta línea de código carga datos en la tabla 'proyectos_Avance.Proyectos_Avance' Puede moverla o quitarla según sea necesario.
            this.proyectos_AvanceTableAdapter.Fill(this.proyectos_Avance.Proyectos_Avance);
            // TODO: esta línea de código carga datos en la tabla 'proyectos_Avance.Proyectos_Avance' Puede moverla o quitarla según sea necesario.
            this.proyectos_AvanceTableAdapter.Fill(this.proyectos_Avance.Proyectos_Avance);
            // TODO: esta línea de código carga datos en la tabla 'proyectos_avance.Proyectos_Avance' Puede moverla o quitarla según sea necesario.

            // TODO: esta línea de código carga datos en la tabla 'match_carpetas.Index_carpetas' Puede moverla o quitarla según sea necesario.
            this.index_carpetasTableAdapter.Fill(this.match_carpetas.Index_carpetas);
            // TODO: esta línea de código carga datos en la tabla 'proyectos_avance.Proyectos_Avance' Puede moverla o quitarla según sea necesario.
            this.proyectos_AvanceTableAdapter.Fill(this.proyectos_Avance.Proyectos_Avance);
            // TODO: esta línea de código carga datos en la tabla 'service_Documents.Ser_Documentos' Puede moverla o quitarla según sea necesario.
            this.ser_DocumentosTableAdapter.Fill(this.service_Documents.Ser_Documentos);

            index_carpetasTableAdapter.limpia();

            cb_nombre.Enabled = false;
            cbr_año.Enabled = false;
            cb_tipo.Enabled = false;
            richTextBox1.Enabled = false;
            richTextBox2.Enabled = false;
            richTextBox3.Enabled = false;
            richTextBox4.Enabled = false;
            richTextBox5.Enabled = false;
            richTextBox6.Enabled = false;
        }

        String DepAtencion = "", Depproduccion = "", DepFinanzas = "", DepProyectos = "", DepEquip = "", DepVentas = "";
        String Email1, Email2, Email3, Email4, Email5, Email6, Email7, Email8, Email9, Email10;
        String Totalarchivos = "";


        decimal contador1, contador2, contador3, contador4, contador5, contador6, contador7, contador8, contador9, contador10,
            contador11, contador12, contador13, contador14, contador15, contador16, contador17, contador18, contador19, contador20,contador21,contador22;
        decimal porcentaje, generalporcentaje;
        decimal valorproyecto;
        string strCmdText;
        public string Año, tipo, Nombre1, Documenindex, proyecto;
        public string ArchivoN;
        public static string ObtenerCadena()
        {
            return Settings.Default.CBR_IngenieriaConnectionString;/*Este codigo obtiene los datos de la cadena de conexion declarada en los settings de la aplicacion*/

        }
        public Actualiza_porcentaje()
        {
            InitializeComponent();
        }

        int min = 0;// Minimum value for progress range
        int max = 100;// Maximum value for progress range
        int val = 0;// Current progress
        ProgressBar pBar;

    
        private void button1_Click(object sender, EventArgs e)
        {
            Thread hilo1 = new Thread(new System.Threading.ThreadStart(Ventana1));





            hilo1.Start();



            Extractor();
            //  genera.Close();
            hilo1.Abort();
            this.Close();




        }


        public static void Ventana1()
        {
            Application.Run(new ProcesoPorcentaje());
        }





        public void iniciador2()
        {
            SqlConnection conexion = new SqlConnection(ObtenerCadena());

            conexion.Open();
            ////////////////////////////////////////////////////////////////////////////////////






            ////////////////////////////////////SE EJECUTA EL COMANDO HACIA LA VISTA Y SE HACE LA VALIDACION//////////////////////////////////////
            SqlCommand cmd = new SqlCommand(
                                            "select " +
                                            "Count('Consecutivo') " +
                                            "from [Carpetas_Unicas] "

                                            , conexion);


            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.SelectCommand.CommandTimeout = 36000;
            DataTable dt = new DataTable();
            sda.Fill(dt);



            conexion.Dispose();
            if (dt.Rows.Count > 0)
            {
                Nombre2 = dt.Rows[0][0].ToString();

                Extractor2();
            }
            else { }

            ////////////////////////////////////SE EJECUTA EL COMANDO HACIA LA VISTA Y SE HACE LA VALIDACION//////////////////////////////////////





        }
        public void iniciador3()
        {
            SqlConnection conexion = new SqlConnection(ObtenerCadena());

            conexion.Open();
            ////////////////////////////////////////////////////////////////////////////////////






            ////////////////////////////////////SE EJECUTA EL COMANDO HACIA LA VISTA Y SE HACE LA VALIDACION//////////////////////////////////////
            SqlCommand cmd = new SqlCommand(
                                            "select " +
                                            "Count('Documento') " +
                                            "from [Ser_Documentos] "

                                            , conexion);


            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.SelectCommand.CommandTimeout = 36000;
            DataTable dt = new DataTable();
            sda.Fill(dt);



            conexion.Dispose();
            if (dt.Rows.Count > 0)
            {
                nom3 = dt.Rows[0][0].ToString();

                Extractor3();
            }
            else { }

            ////////////////////////////////////SE EJECUTA EL COMANDO HACIA LA VISTA Y SE HACE LA VALIDACION//////////////////////////////////////





        }

        public void Consulta()
        {

            if (suma3 >= 74 && suma2 >= numerador2)
            {
                //     Indexarchivos();
                Indexarchivos();
                index_carpetasTableAdapter.limpia();
                Thread.Sleep(50);
                index_carpetasTableAdapter.InsertQuery1();

            }

            richTextBox2.Text = richTextBox2.Text + "\n" + "G:\\SGC-PROYECTOS-CBR\\SGC\\" + cbr_año.Text + "\\" + cb_tipo.Text + "\\" + cb_nombre.Text;

            iniciador2();




        }


        public void Consulta2()
        {
            SqlConnection conexion = new SqlConnection(ObtenerCadena());
            conexion.Open();
            SqlCommand cmd = new SqlCommand(
                                   "select top " + "(" + suma2 + ")" +

                                   "[Carpeta] " +

                                   "from [Carpetas_Unicas] "

                                   , conexion);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.SelectCommand.CommandTimeout = 36000;
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                string Carp = dt.Rows[k1 - 1][0].ToString();

                Thread.Sleep(50);
                if (tipo != "Proyectos-Inox" && Carp == "Fabricacion y Equipamiento" || tipo != "Proyectos-Inox" && Carp == "Lista de Materiales y Equipos") { }
                else
                {

                    string[] ubicacion = Directory.GetFiles("G:/SGC-PROYECTOS-CBR/SGC/" + cbr_año.Text + "/" + cb_tipo.Text + "/" + cb_nombre.Text + "/" + Carp);


                    for (int i = 0; i < ubicacion.Length; i++)
                    {
                        // comboBox1.Items.Add(Path.GetFileName(ubicacion[i]));
                        richTextBox1.Text = richTextBox1.Text + "\n" + Path.GetFileName(ubicacion[i]);
                        String Archivo = Path.GetFileName(ubicacion[i]);
                        ArchivoN = Path.GetFileName(ubicacion[i]);
                        iniciador3();


                    }


                }
                //   procStartInfo..WaitForExit();
                conexion.Dispose();
            }
            else { }
        }
        public void Consulta3()
        {
            SqlConnection conexion = new SqlConnection(ObtenerCadena());
            conexion.Open();
            SqlCommand cmd = new SqlCommand(
                                   "select top " + "(" + suma3 + ")" +
                                     "[Departamento], " +
                                   "[Carpeta], " +
                                   "[Documento] " +

                                   "from [Ser_Documentos] "

                                   , conexion);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.SelectCommand.CommandTimeout = 36000;
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Documenindex = dt.Rows[k2 - 1][2].ToString();
                Carpeta = dt.Rows[k2 - 1][1].ToString();
                Departamento = dt.Rows[k2 - 1][0].ToString();
                Thread.Sleep(50);



                if (suma3 == 1)
                {
                    richTextBox3.Text = "";

                }


                richTextBox3.Text = richTextBox3.Text + "\n" + Documenindex;
                if (Documenindex == ArchivoN)
                {
                    index_carpetasTableAdapter.DeleteQuery(Documenindex);
                    porcentaje = porcentaje + 1;
                    richTextBox4.Text = "El documento " + Documenindex + " existe en el proyecto: " + Nombre;

                    SqlConnection conexion2 = new SqlConnection(ObtenerCadena());
                    conexion2.Open();
                    SqlCommand cmd2 = new SqlCommand(
                                           "select " +
     "  [AtencionClientes]" +
     " ,[AtencionClientes_Atencion]" +
     " ,[AtencionClientes_EntregaDocumentos]" +
     " ,[AtencionClientes_Postventa]" +
     " ,[AtencionClientes_Encuesta]" +
     " ,[Finanzas]" +
     " ,[Finanzas_CierreProyecto]" +
     " ,[Compras]" +
     " ,[Dosier de Calidad]" +
     " ,[Ventas]" +
     " ,[Ventas_AltayDocumentosClientes]" +
     " ,[Ventas_PedidoInterno]" +
     " ,[Ventas_ExpedienteComercial]" +
     " ,[Proyectos]" +
     " ,[Proyectos_ExpedienteTecnico]" +
     " ,[Proyectos_Planos]" +
     " ,[EquipamientoeInstalaciones]" +
     " ,[EquipamientoeInstalaciones_Fabricacion y Equipamiento]" +
     " ,[EquipamientoeInstalaciones_Instalacionyarranque]" +
     " ,[EquipamientoeInstalaciones_OperacionyMantenimiento]" +
     " ,[General]" +


                                           "from [Proyectos_Avance] where Proyecto = @proyecto"

                                           , conexion2);
                    SqlDataAdapter sda2 = new SqlDataAdapter(cmd2);
                    cmd2.Parameters.AddWithValue("proyecto", cb_nom.Text);
                    sda2.SelectCommand.CommandTimeout = 36000;
                    DataTable dt2 = new DataTable();
                    sda2.Fill(dt2);
                    if (dt2.Rows.Count > 0)
                    {
                        AtencionClientes = dt2.Rows[0][0].ToString();
                        AtencionClientes_Atencion = dt2.Rows[0][1].ToString();
                        AtencionClientes_EntregaDocumentos = dt2.Rows[0][2].ToString();
                        AtencionClientes_Postventa = dt2.Rows[0][3].ToString();
                        AtencionClientes_Encuesta = dt2.Rows[0][4].ToString();
                        Finanzas = dt2.Rows[0][5].ToString();
                        Finanzas_CierreProyecto = dt2.Rows[0][6].ToString();
                        Compraas = dt2.Rows[0][7].ToString();
                        DosierdeCalidad = dt2.Rows[0][8].ToString();
                        Ventas = dt2.Rows[0][9].ToString();
                        Ventas_AltayDocumentosClientes = dt2.Rows[0][10].ToString();
                        Ventas_PedidoInterno = dt2.Rows[0][11].ToString();
                        Ventas_ExpedienteComercial = dt2.Rows[0][12].ToString();
                        Proyectos = dt2.Rows[0][13].ToString();
                        Proyectos_ExpedienteTecnic = dt2.Rows[0][14].ToString();
                        Proyectos_Planos = dt2.Rows[0][15].ToString();
                        EquipamientoeInstalaciones = dt2.Rows[0][16].ToString();
                        EquipamientoeInstalaciones_FabricacionyEquipamiento = dt2.Rows[0][17].ToString();
                        EquipamientoeInstalaciones_Instalacionyarranque = dt2.Rows[0][18].ToString();
                        EquipamientoeInstalaciones_OperacionyMantenimiento = dt2.Rows[0][19].ToString();
                        General = dt2.Rows[0][20].ToString();
                        conexion.Dispose();
                    }
                    else
                    {

                        proyectos_AvanceTableAdapter.AgregaProyecto(cb_nom.Text, "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
                        conexion.Dispose();
                    }



                    if (Departamento == "Ventas")
                    {
                        int total = 11; decimal porcentaje;

                        contador1 = contador1 + 1;
                        porcentaje = (contador1 * 100) / 11;

                        string Porcentaje = porcentaje.ToString();
                        proyectos_AvanceTableAdapter.Actualiza_index(
                        AtencionClientes
                        , AtencionClientes_Atencion
                        , AtencionClientes_EntregaDocumentos
                        , AtencionClientes_Postventa
                        , AtencionClientes_Encuesta
                        , Finanzas
                        , Finanzas_CierreProyecto
                        , Compraas
                        , DosierdeCalidad
                        , Porcentaje
                        , Ventas_AltayDocumentosClientes
                        , Ventas_PedidoInterno
                        , Ventas_ExpedienteComercial
                        , Proyectos
                        , Proyectos_ExpedienteTecnic
                        , Proyectos_Planos
                        , EquipamientoeInstalaciones
                        , EquipamientoeInstalaciones_FabricacionyEquipamiento
                        , EquipamientoeInstalaciones_Instalacionyarranque
                        , EquipamientoeInstalaciones_OperacionyMantenimiento
                        , General
                 
                    , cb_nom.Text);
                    }
                    else if (Departamento == "Atención a cliente")
                    {
                        int total = 25; decimal porcentaje;
                        contador2 = contador2 + 1;
                        porcentaje = (contador2 * 100) / 21;
                        string Porcentaje = porcentaje.ToString();
                        proyectos_AvanceTableAdapter.Actualiza_index(



                        Porcentaje
                        , AtencionClientes_Atencion
                        , AtencionClientes_EntregaDocumentos
                        , AtencionClientes_Postventa
                        , AtencionClientes_Encuesta
                        , Finanzas
                        , Finanzas_CierreProyecto
                        , Compraas
                        , DosierdeCalidad
                        , Ventas
                        , Ventas_AltayDocumentosClientes
                        , Ventas_PedidoInterno
                        , Ventas_ExpedienteComercial
                        , Proyectos
                        , Proyectos_ExpedienteTecnic
                        , Proyectos_Planos
                        , EquipamientoeInstalaciones
                        , EquipamientoeInstalaciones_FabricacionyEquipamiento
                        , EquipamientoeInstalaciones_Instalacionyarranque
                        , EquipamientoeInstalaciones_OperacionyMantenimiento
                        , General
                         , cb_nom.Text);

                    }

                    else if (Departamento == "PRODUCCION" || Departamento == "Produccion")
                    {

                        int total = 4; decimal porcentaje;
                        contador3 = contador3 + 1;
                        porcentaje = (contador3 * 100) / 4;
                        string Porcentaje = porcentaje.ToString();
                        proyectos_AvanceTableAdapter.Actualiza_index(
                          AtencionClientes
                        , AtencionClientes_Atencion
                        , AtencionClientes_EntregaDocumentos
                        , AtencionClientes_Postventa
                        , AtencionClientes_Encuesta
                        , Finanzas
                        , Finanzas_CierreProyecto
                        , Compraas
                        , DosierdeCalidad
                        , Ventas
                        , Ventas_AltayDocumentosClientes
                        , Ventas_PedidoInterno
                        , Ventas_ExpedienteComercial
                        , Proyectos
                        , Proyectos_ExpedienteTecnic
                        , Proyectos_Planos
                        , EquipamientoeInstalaciones
                        , Porcentaje
                        , EquipamientoeInstalaciones_Instalacionyarranque
                        , EquipamientoeInstalaciones_OperacionyMantenimiento
                        , General
                         , cb_nom.Text);

                    }
                    else if (Departamento == "FINANZAS")
                    {
                        int total = 4; decimal porcentaje;
                        contador4 = contador4 + 1;
                        porcentaje = (contador4 * 100) / 4;
                        string Porcentaje = porcentaje.ToString();
                        proyectos_AvanceTableAdapter.Actualiza_index(
             AtencionClientes
                        , AtencionClientes_Atencion
                        , AtencionClientes_EntregaDocumentos
                        , AtencionClientes_Postventa
                        , AtencionClientes_Encuesta
                        , Porcentaje
                        , Finanzas_CierreProyecto
                        , Compraas
                        , DosierdeCalidad
                        , Ventas
                        , Ventas_AltayDocumentosClientes
                        , Ventas_PedidoInterno
                        , Ventas_ExpedienteComercial
                        , Proyectos
                        , Proyectos_ExpedienteTecnic
                        , Proyectos_Planos
                        , EquipamientoeInstalaciones
                        , EquipamientoeInstalaciones_FabricacionyEquipamiento
                        , EquipamientoeInstalaciones_Instalacionyarranque
                        , EquipamientoeInstalaciones_OperacionyMantenimiento
                        , General
                         , cb_nom.Text);
                    }

                    else if (Departamento == "Proyectos")
                    {
                        int total = 8; decimal porcentaje;
                        contador5 = contador5 + 1;
                        porcentaje = (contador5 * 100) / 8;
                        string Porcentaje = porcentaje.ToString();
                        proyectos_AvanceTableAdapter.Actualiza_index(
                    AtencionClientes
                        , AtencionClientes_Atencion
                        , AtencionClientes_EntregaDocumentos
                        , AtencionClientes_Postventa
                        , AtencionClientes_Encuesta
                        , Finanzas
                        , Finanzas_CierreProyecto
                        , Compraas
                        , DosierdeCalidad
                        , Ventas
                        , Ventas_AltayDocumentosClientes
                        , Ventas_PedidoInterno
                        , Ventas_ExpedienteComercial
                        , Porcentaje
                        , Proyectos_ExpedienteTecnic
                        , Proyectos_Planos
                        , EquipamientoeInstalaciones
                        , EquipamientoeInstalaciones_FabricacionyEquipamiento
                        , EquipamientoeInstalaciones_Instalacionyarranque
                        , EquipamientoeInstalaciones_OperacionyMantenimiento
                        , General
                         , cb_nom.Text);
                    }

                    else if (Departamento == "Equipamiento e Instalaciones")
                    {
                        int total = 23; decimal porcentaje;
                        contador6 = contador6 + 1;
                        porcentaje = (contador6 * 100) / 23;
                        string Porcentaje = porcentaje.ToString();
                        proyectos_AvanceTableAdapter.Actualiza_index(
               AtencionClientes
                        , AtencionClientes_Atencion
                        , AtencionClientes_EntregaDocumentos
                        , AtencionClientes_Postventa
                        , AtencionClientes_Encuesta
                        , Finanzas
                        , Finanzas_CierreProyecto
                        , Compraas
                        , DosierdeCalidad
                        , Ventas
                        , Ventas_AltayDocumentosClientes
                        , Ventas_PedidoInterno
                        , Ventas_ExpedienteComercial
                        , Proyectos
                        , Proyectos_ExpedienteTecnic
                        , Proyectos_Planos
                        , Porcentaje
                        , EquipamientoeInstalaciones_FabricacionyEquipamiento
                        , EquipamientoeInstalaciones_Instalacionyarranque
                        , EquipamientoeInstalaciones_OperacionyMantenimiento
                        , General
                         , cb_nom.Text);
                    }

                    else if (Departamento == "Compras")
                    {
                        int total = 3; decimal porcentaje;
                        contador7 = contador7 + 1;
                        porcentaje = (contador7 * 100) / 3;
                        string Porcentaje = porcentaje.ToString();
                        proyectos_AvanceTableAdapter.Actualiza_index(
                AtencionClientes
                        , AtencionClientes_Atencion
                        , AtencionClientes_EntregaDocumentos
                        , AtencionClientes_Postventa
                        , AtencionClientes_Encuesta
                        , Finanzas
                        , Finanzas_CierreProyecto
                        , Porcentaje
                        , DosierdeCalidad
                        , Ventas
                        , Ventas_AltayDocumentosClientes
                        , Ventas_PedidoInterno
                        , Ventas_ExpedienteComercial
                        , Proyectos
                        , Proyectos_ExpedienteTecnic
                        , Proyectos_Planos
                        , EquipamientoeInstalaciones
                        , EquipamientoeInstalaciones_FabricacionyEquipamiento
                        , EquipamientoeInstalaciones_Instalacionyarranque
                        , EquipamientoeInstalaciones_OperacionyMantenimiento
                        , General
                         , cb_nom.Text);
                    }

                    SqlConnection conexion3 = new SqlConnection(ObtenerCadena());
                    conexion3.Open();
                    SqlCommand cmd3 = new SqlCommand(
                                           "select " + "[Proyecto]" +
   "  [AtencionClientes]" +
     " ,[AtencionClientes_Atencion]" +
     " ,[AtencionClientes_EntregaDocumentos]" +
     " ,[AtencionClientes_Postventa]" +
     " ,[AtencionClientes_Encuesta]" +
     " ,[Finanzas]" +
     " ,[Finanzas_CierreProyecto]" +
     " ,[Compras]" +
     " ,[Dosier de Calidad]" +
     " ,[Ventas]" +
     " ,[Ventas_AltayDocumentosClientes]" +
     " ,[Ventas_PedidoInterno]" +
     " ,[Ventas_ExpedienteComercial]" +
     " ,[Proyectos]" +
     " ,[Proyectos_ExpedienteTecnico]" +
     " ,[Proyectos_Planos]" +
     " ,[EquipamientoeInstalaciones]" +
     " ,[EquipamientoeInstalaciones_Fabricacion y Equipamiento]" +
     " ,[EquipamientoeInstalaciones_Instalacionyarranque]" +
     " ,[EquipamientoeInstalaciones_OperacionyMantenimiento]" +
     " ,[General]" +

                                           "from [Proyectos_Avance] where Proyecto = @proyecto"

                                           , conexion3);
                    SqlDataAdapter sda3 = new SqlDataAdapter(cmd3);
                    cmd3.Parameters.AddWithValue("proyecto", cb_nom.Text);
                    sda3.SelectCommand.CommandTimeout = 36000;
                    DataTable dt3 = new DataTable();
                    sda3.Fill(dt3);
                    if (dt3.Rows.Count > 0)
                    {
                        AtencionClientes = dt2.Rows[0][0].ToString();
                        AtencionClientes_Atencion = dt2.Rows[0][1].ToString();
                        AtencionClientes_EntregaDocumentos = dt2.Rows[0][2].ToString();
                        AtencionClientes_Postventa = dt2.Rows[0][3].ToString();
                        AtencionClientes_Encuesta = dt2.Rows[0][4].ToString();
                        Finanzas = dt2.Rows[0][5].ToString();
                        Finanzas_CierreProyecto = dt2.Rows[0][6].ToString();
                        Compraas = dt2.Rows[0][7].ToString();
                        DosierdeCalidad = dt2.Rows[0][8].ToString();
                        Ventas = dt2.Rows[0][9].ToString();
                        Ventas_AltayDocumentosClientes = dt2.Rows[0][10].ToString();
                        Ventas_PedidoInterno = dt2.Rows[0][11].ToString();
                        Ventas_ExpedienteComercial = dt2.Rows[0][12].ToString();
                        Proyectos = dt2.Rows[0][13].ToString();
                        Proyectos_ExpedienteTecnic = dt2.Rows[0][14].ToString();
                        Proyectos_Planos = dt2.Rows[0][15].ToString();
                        EquipamientoeInstalaciones = dt2.Rows[0][16].ToString();
                        EquipamientoeInstalaciones_FabricacionyEquipamiento = dt2.Rows[0][17].ToString();
                        EquipamientoeInstalaciones_Instalacionyarranque = dt2.Rows[0][18].ToString();
                        EquipamientoeInstalaciones_OperacionyMantenimiento = dt2.Rows[0][19].ToString();
                        General = dt2.Rows[0][20].ToString();
                        conexion3.Dispose();
                    }
                    else { }

                    decimal porcentaje2;
                    if (Ventas == "" || Ventas == null) { Ventas = "0"; }
                    if (AtencionClientes == "" || AtencionClientes == null) { AtencionClientes = "0"; }
                    if (EquipamientoeInstalaciones_FabricacionyEquipamiento == "" || EquipamientoeInstalaciones_FabricacionyEquipamiento == null) { EquipamientoeInstalaciones_FabricacionyEquipamiento = "0"; }
                    if (Finanzas == "" || Finanzas == null) { Finanzas = "0"; }
                    if (Proyectos == "" || Proyectos == null) { Proyectos = "0"; }
                    if (EquipamientoeInstalaciones == "" || EquipamientoeInstalaciones == null) { EquipamientoeInstalaciones = "0"; }
                    if (Compraas == "" || Compraas == null) { Compraas = "0"; }


                    decimal ventas = Convert.ToDecimal(Ventas), 
                    Atencionacliente = Convert.ToDecimal(AtencionClientes),
                    produccion = Convert.ToDecimal(EquipamientoeInstalaciones_FabricacionyEquipamiento),
                    finanzas = Convert.ToDecimal(Finanzas), 
                    proyectos = Convert.ToDecimal(Proyectos), equip = Convert.ToDecimal(EquipamientoeInstalaciones);
                    generalporcentaje = ventas + Atencionacliente + produccion + finanzas + proyectos + equip;
                    porcentaje2 = (generalporcentaje * 100) / 700;
                    string Porcentaje2 = porcentaje2.ToString();
                    if (Carpeta == "Alta y Documentos Clientes")
                    {
                        int total = 6; decimal porcentaje;
                        contador8 = contador8 + 1;
                        porcentaje = (contador8 * 100) / 6;
                        string Porcentaje = porcentaje.ToString();
                        proyectos_AvanceTableAdapter.Actualiza_index(

                        AtencionClientes
                        ,AtencionClientes_Atencion
                        ,AtencionClientes_EntregaDocumentos
                        ,AtencionClientes_Postventa
                        ,AtencionClientes_Encuesta
                        ,Finanzas
                        ,Finanzas_CierreProyecto
                        ,Compraas
                        ,DosierdeCalidad
                        ,Ventas
                        ,Ventas_AltayDocumentosClientes
                        ,Ventas_PedidoInterno
                        ,Ventas_ExpedienteComercial
                        ,Proyectos
                        ,Proyectos_ExpedienteTecnic
                        ,Proyectos_Planos
                        ,EquipamientoeInstalaciones
                        ,EquipamientoeInstalaciones_FabricacionyEquipamiento
                        ,EquipamientoeInstalaciones_Instalacionyarranque
                        ,EquipamientoeInstalaciones_OperacionyMantenimiento
                        , Porcentaje2
                         , cb_nom.Text

     
                   );


                    }
                    else if (Carpeta == "Expediente Comercial")
                    {
                        int total = 4; decimal porcentaje;
                        contador9 = contador9 + 1;
                        porcentaje = (contador9 * 100) / 4;
                        string Porcentaje = porcentaje.ToString();
                        proyectos_AvanceTableAdapter.Actualiza_index(
                         AtencionClientes
                        , AtencionClientes_Atencion
                        , AtencionClientes_EntregaDocumentos
                        , AtencionClientes_Postventa
                        , AtencionClientes_Encuesta
                        , Finanzas
                        , Finanzas_CierreProyecto
                        , Compraas
                        , DosierdeCalidad
                        , Ventas
                        , Ventas_AltayDocumentosClientes
                        , Ventas_PedidoInterno
                        , Porcentaje
                        , Proyectos
                        , Proyectos_ExpedienteTecnic
                        , Proyectos_Planos
                        , EquipamientoeInstalaciones
                        , EquipamientoeInstalaciones_FabricacionyEquipamiento
                        , EquipamientoeInstalaciones_Instalacionyarranque
                        , EquipamientoeInstalaciones_OperacionyMantenimiento
                        , Porcentaje2
                         , cb_nom.Text
                   );
                    }
                    else if (Carpeta == "Pedido Interno")
                    {
                        int total = 1; decimal porcentaje;
                        contador10 = contador10 + 1;
                        porcentaje = (contador10 * 100) / 1;
                        string Porcentaje = porcentaje.ToString();
                        proyectos_AvanceTableAdapter.Actualiza_index(
              AtencionClientes
                        , AtencionClientes_Atencion
                        , AtencionClientes_EntregaDocumentos
                        , AtencionClientes_Postventa
                        , AtencionClientes_Encuesta
                        , Finanzas
                        , Finanzas_CierreProyecto
                        , Compraas
                        , DosierdeCalidad
                        , Ventas
                        , Ventas_AltayDocumentosClientes
                        , Porcentaje
                        , Ventas_ExpedienteComercial
                        , Proyectos
                        , Proyectos_ExpedienteTecnic
                        , Proyectos_Planos
                        , EquipamientoeInstalaciones
                        , EquipamientoeInstalaciones_FabricacionyEquipamiento
                        , EquipamientoeInstalaciones_Instalacionyarranque
                        , EquipamientoeInstalaciones_OperacionyMantenimiento
                        , Porcentaje2
                         , cb_nom.Text
                   );
                    }
                    else if (Carpeta == "Atencion Cliente")
                    {

                        decimal total = 7; decimal porcentaje;
                        contador11 = contador11 + 1;
                        porcentaje = (contador11 * 100) / 7;
                        string Porcentaje = porcentaje.ToString();
                        proyectos_AvanceTableAdapter.Actualiza_index(
                          AtencionClientes
                        , Porcentaje
                        , AtencionClientes_EntregaDocumentos
                        , AtencionClientes_Postventa
                        , AtencionClientes_Encuesta
                        , Finanzas
                        , Finanzas_CierreProyecto
                        , Compraas
                        , DosierdeCalidad
                        , Ventas
                        , Ventas_AltayDocumentosClientes
                        , Ventas_PedidoInterno
                        , Ventas_ExpedienteComercial
                        , Proyectos
                        , Proyectos_ExpedienteTecnic
                        , Proyectos_Planos
                        , EquipamientoeInstalaciones
                        , EquipamientoeInstalaciones_FabricacionyEquipamiento
                        , EquipamientoeInstalaciones_Instalacionyarranque
                        , EquipamientoeInstalaciones_OperacionyMantenimiento
                        , Porcentaje2
                         , cb_nom.Text
                   );

                    }
                    else if (Carpeta == "Encuestas de Satisfaccion")
                    {

                        decimal total = 1; decimal porcentaje;
                        contador12 = contador12 + 1;
                        porcentaje = (contador12 * 100) / 1;
                        string Porcentaje = porcentaje.ToString();
                        proyectos_AvanceTableAdapter.Actualiza_index(
                        AtencionClientes
                        , AtencionClientes_Atencion
                        , AtencionClientes_EntregaDocumentos
                        , AtencionClientes_Postventa
                        , Porcentaje
                        , Finanzas
                        , Finanzas_CierreProyecto
                        , Compraas
                        , DosierdeCalidad
                        , Ventas
                        , Ventas_AltayDocumentosClientes
                        , Ventas_PedidoInterno
                        , Ventas_ExpedienteComercial
                        , Proyectos
                        , Proyectos_ExpedienteTecnic
                        , Proyectos_Planos
                        , EquipamientoeInstalaciones
                        , EquipamientoeInstalaciones_FabricacionyEquipamiento
                        , EquipamientoeInstalaciones_Instalacionyarranque
                        , EquipamientoeInstalaciones_OperacionyMantenimiento
                        , Porcentaje2
                         , cb_nom.Text
                   );
                    }
                    else if (Carpeta == "Entrega Documentos")
                    {
                        int total = 11; decimal porcentaje;
                        contador13 = contador13 + 1;
                        porcentaje = (contador13 * 100) / 11;
                        string Porcentaje = porcentaje.ToString();
                        proyectos_AvanceTableAdapter.Actualiza_index(
                          AtencionClientes
                        , AtencionClientes_Atencion
                        , Porcentaje
                        , AtencionClientes_Postventa
                        , AtencionClientes_Encuesta
                        , Finanzas
                        , Finanzas_CierreProyecto
                        , Compraas
                        , DosierdeCalidad
                        , Ventas
                        , Ventas_AltayDocumentosClientes
                        , Ventas_PedidoInterno
                        , Ventas_ExpedienteComercial
                        , Proyectos
                        , Proyectos_ExpedienteTecnic
                        , Proyectos_Planos
                        , EquipamientoeInstalaciones
                        , EquipamientoeInstalaciones_FabricacionyEquipamiento
                        , EquipamientoeInstalaciones_Instalacionyarranque
                        , EquipamientoeInstalaciones_OperacionyMantenimiento
                        , Porcentaje2
                         , cb_nom.Text
                   );
                    }
                    else if (Carpeta == "Postventa")
                    {
                        int total = 2; decimal porcentaje;
                        contador14 = contador14 + 1;
                        porcentaje = (contador14 * 100) / 2;
                        string Porcentaje = porcentaje.ToString();
                        proyectos_AvanceTableAdapter.Actualiza_index(
                    AtencionClientes
                        , AtencionClientes_Atencion
                        , AtencionClientes_EntregaDocumentos
                        , Porcentaje
                        , AtencionClientes_Encuesta
                        , Finanzas
                        , Finanzas_CierreProyecto
                        , Compraas
                        , DosierdeCalidad
                        , Ventas
                        , Ventas_AltayDocumentosClientes
                        , Ventas_PedidoInterno
                        , Ventas_ExpedienteComercial
                        , Proyectos
                        , Proyectos_ExpedienteTecnic
                        , Proyectos_Planos
                        , EquipamientoeInstalaciones
                        , EquipamientoeInstalaciones_FabricacionyEquipamiento
                        , EquipamientoeInstalaciones_Instalacionyarranque
                        , EquipamientoeInstalaciones_OperacionyMantenimiento
                        , Porcentaje2
                         , cb_nom.Text
                   );
                    }
                    else if (Carpeta == "Cierre Proyecto")
                    {
                        int total = 4; decimal porcentaje;
                        contador15 = contador15 + 1;
                        porcentaje = (contador15 * 100) / 4;
                        string Porcentaje = porcentaje.ToString();
                        proyectos_AvanceTableAdapter.Actualiza_index(
                   AtencionClientes
                        , AtencionClientes_Atencion
                        , AtencionClientes_EntregaDocumentos
                        , AtencionClientes_Postventa
                        , AtencionClientes_Encuesta
                        , Finanzas
                        , Porcentaje
                        , Compraas
                        , DosierdeCalidad
                        , Ventas
                        , Ventas_AltayDocumentosClientes
                        , Ventas_PedidoInterno
                        , Ventas_ExpedienteComercial
                        , Proyectos
                        , Proyectos_ExpedienteTecnic
                        , Proyectos_Planos
                        , EquipamientoeInstalaciones
                        , EquipamientoeInstalaciones_FabricacionyEquipamiento
                        , EquipamientoeInstalaciones_Instalacionyarranque
                        , EquipamientoeInstalaciones_OperacionyMantenimiento
                        , Porcentaje2
                         , cb_nom.Text
                   );
                    }
                    else if (Carpeta == "Expediente Tecnico")
                    {
                        int total = 4; decimal porcentaje;
                        contador16 = contador16 + 1;
                        porcentaje = (contador16 * 100) / 4;
                        string Porcentaje = porcentaje.ToString();
                        proyectos_AvanceTableAdapter.Actualiza_index(
                      AtencionClientes
                        , AtencionClientes_Atencion
                        , AtencionClientes_EntregaDocumentos
                        , AtencionClientes_Postventa
                        , AtencionClientes_Encuesta
                        , Finanzas
                        , Finanzas_CierreProyecto
                        , Compraas
                        , DosierdeCalidad
                        , Ventas
                        , Ventas_AltayDocumentosClientes
                        , Ventas_PedidoInterno
                        , Ventas_ExpedienteComercial
                        , Proyectos
                        , Porcentaje
                        , Proyectos_Planos
                        , EquipamientoeInstalaciones
                        , EquipamientoeInstalaciones_FabricacionyEquipamiento
                        , EquipamientoeInstalaciones_Instalacionyarranque
                        , EquipamientoeInstalaciones_OperacionyMantenimiento
                        , Porcentaje2
                         , cb_nom.Text
                   );
                    }
                    else if (Carpeta == "Planos")
                    {
                        int total = 4; decimal porcentaje;
                        contador17 = contador17 + 1;
                        porcentaje = (contador17 * 100) / 4;
                        string Porcentaje = porcentaje.ToString();
                        proyectos_AvanceTableAdapter.Actualiza_index(
                             AtencionClientes
                        , AtencionClientes_Atencion
                        , AtencionClientes_EntregaDocumentos
                        , AtencionClientes_Postventa
                        , AtencionClientes_Encuesta
                        , Finanzas
                        , Finanzas_CierreProyecto
                        , Compraas
                        , DosierdeCalidad
                        , Ventas
                        , Ventas_AltayDocumentosClientes
                        , Ventas_PedidoInterno
                        , Ventas_ExpedienteComercial
                        , Proyectos
                        , Proyectos_ExpedienteTecnic
                        , Porcentaje
                        , EquipamientoeInstalaciones
                        , EquipamientoeInstalaciones_FabricacionyEquipamiento
                        , EquipamientoeInstalaciones_Instalacionyarranque
                        , EquipamientoeInstalaciones_OperacionyMantenimiento
                        , Porcentaje2
                         , cb_nom.Text
                   );
                    }
                    else if (Carpeta == "Fabricacion y Equipamiento")
                    {
                        int total = 4; decimal porcentaje;
                        contador18 = contador18 + 1;
                        porcentaje = (contador18 * 100) / 4;
                        string Porcentaje = porcentaje.ToString();
                        proyectos_AvanceTableAdapter.Actualiza_index(
                         AtencionClientes
                        , AtencionClientes_Atencion
                        , AtencionClientes_EntregaDocumentos
                        , AtencionClientes_Postventa
                        , AtencionClientes_Encuesta
                        , Finanzas
                        , Finanzas_CierreProyecto
                        , Compraas
                        , DosierdeCalidad
                        , Ventas
                        , Ventas_AltayDocumentosClientes
                        , Ventas_PedidoInterno
                        , Ventas_ExpedienteComercial
                        , Proyectos
                        , Proyectos_ExpedienteTecnic
                        , Proyectos_Planos
                        , EquipamientoeInstalaciones
                        , Porcentaje
                        , EquipamientoeInstalaciones_Instalacionyarranque
                        , EquipamientoeInstalaciones_OperacionyMantenimiento
                        , Porcentaje2
                         , cb_nom.Text
                   );
                    }
                 
                    else if (Carpeta == "Instalacion y arranque"|| Carpeta == "Instalacion y arranque/Reportes"|| Carpeta == "Instalacion y arranque/Comprobaciones"|| Carpeta == "Instalacion y arranque/Requisiciones"|| Carpeta == "Instalacion y arranque/Dispersion"|| Carpeta == "Instalacion y arranque/Almacen"|| Carpeta == "Instalacion y arranque/Orden de Cambio"|| Carpeta == "Instalacion y arranque/fotos")
                    {
                        int total = 6; decimal porcentaje;
                        contador19 = contador19 + 1;
                        porcentaje = (contador19 * 100) / 6;
                        string Porcentaje = porcentaje.ToString();
                        proyectos_AvanceTableAdapter.Actualiza_index(
                         AtencionClientes
                        , AtencionClientes_Atencion
                        , AtencionClientes_EntregaDocumentos
                        , AtencionClientes_Postventa
                        , AtencionClientes_Encuesta
                        , Finanzas
                        , Finanzas_CierreProyecto
                        , Compraas
                        , DosierdeCalidad
                        , Ventas
                        , Ventas_AltayDocumentosClientes
                        , Ventas_PedidoInterno
                        , Ventas_ExpedienteComercial
                        , Proyectos
                        , Proyectos_ExpedienteTecnic
                        , Proyectos_Planos
                        , EquipamientoeInstalaciones
                        , EquipamientoeInstalaciones_FabricacionyEquipamiento
                        , Porcentaje
                        , EquipamientoeInstalaciones_OperacionyMantenimiento
                        , Porcentaje2
                         , cb_nom.Text
                   );
                    }

                    else if (Carpeta == "Operacion y Mantenimiento" || Carpeta == "Operacion y Mantenimiento/Reportes" || Carpeta == "Operacion y Mantenimiento/Comprobaciones" || Carpeta == "Operacion y Mantenimiento/Requisiciones" || Carpeta == "Operacion y Mantenimiento/Dispersion" || Carpeta == "Instalacion y arranque/Almacen" || Carpeta == "Operacion y Mantenimiento/Orden de Cambio" || Carpeta == "Operacion y Mantenimiento/fotos")
                    {
                        int total = 8; decimal porcentaje;
                        contador20 = contador20 + 1;
                        porcentaje = (contador20 * 100) / 8;
                        string Porcentaje = porcentaje.ToString();
                        proyectos_AvanceTableAdapter.Actualiza_index(
                      AtencionClientes
                        , AtencionClientes_Atencion
                        , AtencionClientes_EntregaDocumentos
                        , AtencionClientes_Postventa
                        , AtencionClientes_Encuesta
                        , Finanzas
                        , Finanzas_CierreProyecto
                        , Compraas
                        , DosierdeCalidad
                        , Ventas
                        , Ventas_AltayDocumentosClientes
                        , Ventas_PedidoInterno
                        , Ventas_ExpedienteComercial
                        , Proyectos
                        , Proyectos_ExpedienteTecnic
                        , Proyectos_Planos
                        , EquipamientoeInstalaciones
                        , EquipamientoeInstalaciones_FabricacionyEquipamiento
                        , EquipamientoeInstalaciones_Instalacionyarranque
                        , Porcentaje
                        , Porcentaje2
                         , cb_nom.Text
                   );
                    }

                    else if (Carpeta == "Compras" || Carpeta == "Compras/Ordenes de Compras" || Carpeta == "Compras/Comparativas" || Carpeta == "Compras/Facturas")
                    {
                        int total = 3; decimal porcentaje;
                        contador21 = contador21 + 1;
                        porcentaje = (contador21 * 100) / 3;
                        string Porcentaje = porcentaje.ToString();
                        proyectos_AvanceTableAdapter.Actualiza_index(
                     AtencionClientes
                        , AtencionClientes_Atencion
                        , AtencionClientes_EntregaDocumentos
                        , AtencionClientes_Postventa
                        , AtencionClientes_Encuesta
                        , Finanzas
                        , Finanzas_CierreProyecto
                        , Porcentaje
                        , DosierdeCalidad
                        , Ventas
                        , Ventas_AltayDocumentosClientes
                        , Ventas_PedidoInterno
                        , Ventas_ExpedienteComercial
                        , Proyectos
                        , Proyectos_ExpedienteTecnic
                        , Proyectos_Planos
                        , EquipamientoeInstalaciones
                        , EquipamientoeInstalaciones_FabricacionyEquipamiento
                        , EquipamientoeInstalaciones_Instalacionyarranque
                        , EquipamientoeInstalaciones_OperacionyMantenimiento
                        , Porcentaje2
                         , cb_nom.Text
                   );
                    }
                    else if (Carpeta == "Dosier de Calidad"|| Carpeta == "Dosier de Calidad/Certificados de calidad" || Carpeta == "Dosier de Calidad/Pruebas de Calidad/Estanquiedad"|| Carpeta == "Dosier de Calidad/Pruebas de Calidad/Equipos"|| Carpeta == "Dosier de Calidad/Pruebas de Calidad/Instalaciones"|| Carpeta == "Dosier de Calidad/Pruebas de Calidad/Analisis Agua" || Carpeta == "Dosier de Calidad/Pruebas de Calidad/Carta Garantia" || Carpeta == "Dosier de Calidad/Pruebas de Calidad/Constancia" || Carpeta == "Dosier de Calidad/Pruebas de Calidad/Fotos" || Carpeta == "Dosier de Calidad/Pruebas de Calidad/Equipos")
                    {

                        decimal total = 19; decimal porcentaje;
                        contador22 = contador22 + 1;
                        porcentaje = (contador22 * 100) / 19;
                        string Porcentaje = porcentaje.ToString();
                        proyectos_AvanceTableAdapter.Actualiza_index(
                      AtencionClientes
                        , AtencionClientes_Atencion
                        , AtencionClientes_EntregaDocumentos
                        , AtencionClientes_Postventa
                        , AtencionClientes_Encuesta
                        , Finanzas
                        , Finanzas_CierreProyecto
                        , Compraas
                        , Porcentaje
                        , Ventas
                        , Ventas_AltayDocumentosClientes
                        , Ventas_PedidoInterno
                        , Ventas_ExpedienteComercial
                        , Proyectos
                        , Proyectos_ExpedienteTecnic
                        , Proyectos_Planos
                        , EquipamientoeInstalaciones
                        , EquipamientoeInstalaciones_FabricacionyEquipamiento
                        , EquipamientoeInstalaciones_Instalacionyarranque
                        , EquipamientoeInstalaciones_OperacionyMantenimiento
                        , Porcentaje2
                         , cb_nom.Text
                   );
                    }
              
                  
               
        
               
               
           






                }
                else
                {
                    SqlConnection conexion2 = new SqlConnection(ObtenerCadena());
                    conexion2.Open();
                    SqlCommand cmd2 = new SqlCommand(
                                           "select " + "[Proyecto]" +
   "  [AtencionClientes]" +
     " ,[AtencionClientes_Atencion]" +
     " ,[AtencionClientes_EntregaDocumentos]" +
     " ,[AtencionClientes_Postventa]" +
     " ,[AtencionClientes_Encuesta]" +
     " ,[Finanzas]" +
     " ,[Finanzas_CierreProyecto]" +
     " ,[Compras]" +
     " ,[Dosier de Calidad]" +
     " ,[Ventas]" +
     " ,[Ventas_AltayDocumentosClientes]" +
     " ,[Ventas_PedidoInterno]" +
     " ,[Ventas_ExpedienteComercial]" +
     " ,[Proyectos]" +
     " ,[Proyectos_ExpedienteTecnico]" +
     " ,[Proyectos_Planos]" +
     " ,[EquipamientoeInstalaciones]" +
     " ,[EquipamientoeInstalaciones_Fabricacion y Equipamiento]" +
     " ,[EquipamientoeInstalaciones_Instalacionyarranque]" +
     " ,[EquipamientoeInstalaciones_OperacionyMantenimiento]" +
     " ,[General]" +

                                           "from [Proyectos_Avance] where Proyecto = @proyecto"

                                           , conexion2);
                    SqlDataAdapter sda2 = new SqlDataAdapter(cmd2);
                    cmd2.Parameters.AddWithValue("proyecto", cb_nom.Text);
                    sda2.SelectCommand.CommandTimeout = 36000;
                    DataTable dt2 = new DataTable();
                    sda2.Fill(dt2);
                    if (dt2.Rows.Count > 0)
                    {
                        AtencionClientes = dt2.Rows[0][0].ToString();
                        AtencionClientes_Atencion = dt2.Rows[0][1].ToString();
                        AtencionClientes_EntregaDocumentos = dt2.Rows[0][2].ToString();
                        AtencionClientes_Postventa = dt2.Rows[0][3].ToString();
                        AtencionClientes_Encuesta = dt2.Rows[0][4].ToString();
                        Finanzas = dt2.Rows[0][5].ToString();
                        Finanzas_CierreProyecto = dt2.Rows[0][6].ToString();
                        Compraas = dt2.Rows[0][7].ToString();
                        DosierdeCalidad = dt2.Rows[0][8].ToString();
                        Ventas = dt2.Rows[0][9].ToString();
                        Ventas_AltayDocumentosClientes = dt2.Rows[0][10].ToString();
                        Ventas_PedidoInterno = dt2.Rows[0][11].ToString();
                        Ventas_ExpedienteComercial = dt2.Rows[0][12].ToString();
                        Proyectos = dt2.Rows[0][13].ToString();
                        Proyectos_ExpedienteTecnic = dt2.Rows[0][14].ToString();
                        Proyectos_Planos = dt2.Rows[0][15].ToString();
                        EquipamientoeInstalaciones = dt2.Rows[0][16].ToString();
                        EquipamientoeInstalaciones_FabricacionyEquipamiento = dt2.Rows[0][17].ToString();
                        EquipamientoeInstalaciones_Instalacionyarranque = dt2.Rows[0][18].ToString();
                        EquipamientoeInstalaciones_OperacionyMantenimiento = dt2.Rows[0][19].ToString();
                        General = dt2.Rows[0][20].ToString();

                        conexion.Dispose();
                    }
                    else
                    {

                        proyectos_AvanceTableAdapter.AgregaProyecto(cb_nom.Text, "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0", "0");
                        conexion.Dispose();
                    }


                    richTextBox5.Text = richTextBox5.Text + "\n" + "No existe el archivo " + Documenindex + " en el proyecto " + Nombre1 + " " + "\n";





                }

                conexion.Dispose();

            }
            else { }
        }
        public void Extractor()
        {

            SqlConnection conexion = new SqlConnection(ObtenerCadena());

            numerador = 1;


            conexion.Dispose();
            for (k = 1; k <= numerador; k++)
            {
                suma = suma + 1;
         
            




                Consulta();

                valorproyecto = (porcentaje * 100) / 74;



            
                richTextBox6.Text = richTextBox6.Text + "\n" + "Se lleva el:" + valorproyecto.ToString() + "% del proyecto:" + cb_nom.Text + "\n";

                porcentaje = 0;

           
            }


            ////////////////////////////////////SE EJECUTA EL COMANDO HACIA LA VISTA Y SE HACE LA VALIDACION//////////////////////////////////////

        }
        public void Extractor2()
        {

            SqlConnection conexion = new SqlConnection(ObtenerCadena());

            numerador2 = Int32.Parse(Nombre2);

            suma2 = 0;
            conexion.Dispose();
            for (k1 = 1; k1 <= numerador2; k1++)
            {
                suma2 = suma2 + 1;
                Consulta2();





            }

            ////////////////////////////////////SE EJECUTA EL COMANDO HACIA LA VISTA Y SE HACE LA VALIDACION//////////////////////////////////////

        }
        public void Extractor3()
        {

            SqlConnection conexion = new SqlConnection(ObtenerCadena());

            numerador3 = Int32.Parse(nom3);

            suma3 = 0;
            conexion.Dispose();
            for (k2 = 1; k2 <= numerador3; k2++)
            {
                suma3 = suma3 + 1;
                Consulta3();





            }



            //Totalarchivos = DepAtencion;
            //enviamasivo2("Atencion a Clientes");
            //Totalarchivos = Depproduccion;
            //enviamasivo2("Produccion");
            //Totalarchivos = DepFinanzas;
            //enviamasivo2("Asistente de direccion");
            //Totalarchivos = DepProyectos;
            //enviamasivo2("Proyectos");
            //Totalarchivos = DepEquip;
            //enviamasivo2("Construccion e Instalaciones");
            //Totalarchivos = DepVentas;
            //enviamasivo2("Ventas");
            ////////////////////////////////////SE EJECUTA EL COMANDO HACIA LA VISTA Y SE HACE LA VALIDACION//////////////////////////////////////

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
                cmd.Parameters.AddWithValue("Departamento", Departamento);



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

                    message.Subject = "Falta de documentacion en proyecto";
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

                    message.Subject = "Falta de documentacion en proyecto";
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

                    message.Subject = "Falta de documentacion en proyecto";
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

                    message.Subject = "Falta de documentacion en proyecto";
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


                    message.Subject = "Falta de documentacion en proyecto";
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
                    message.Subject = "Falta de documentacion en proyecto";
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

                    message.Subject = "Falta de documentacion en proyecto";
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
                    message.Subject = "Falta de documentacion en proyecto";
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

                    message.Subject = "Falta de documentacion en proyecto";
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

                    message.Subject = "Falta de documentacion en proyecto";
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
        private AlternateView getEmbeddedImage(String filePath)
        {



            // below line was corrected to include the mediatype so it displays in all 
            // mail clients. previous solution only displays in Gmail the inline images 
            LinkedResource res = new LinkedResource(filePath, MediaTypeNames.Image.Jpeg);
            res.ContentId = Guid.NewGuid().ToString();
            String Body = "<DIV><H5>Falta de informacion en el proyecto:</HEAD></H>" + Nomproyectenvia + "</DIV>" +
                "Los archivos faltantes son: </DIV>" +
                Totalarchivos;
            Body += "<DIV>Ingrese ala plataforma para subir la documentacion faltante</DIV>";




            string htmlBody = "" + Body + "" + @"<img src='cid:" + res.ContentId + @"'/> ";
            AlternateView alternateView = AlternateView.CreateAlternateViewFromString(htmlBody,
             null, MediaTypeNames.Text.Html);
            alternateView.LinkedResources.Add(res);
            return alternateView;
        }
        public void Indexarchivos()
        {
            Proyectondexe();
            SqlConnection conexion = new SqlConnection(ObtenerCadena());

            conexion.Open();
            ////////////////////////////////////////////////////////////////////////////////////






            ////////////////////////////////////SE EJECUTA EL COMANDO HACIA LA VISTA Y SE HACE LA VALIDACION//////////////////////////////////////
            SqlCommand cmd = new SqlCommand(
                                            "select " +
                                            "Count('Departamento') " +
                                            "from [Index_carpetas] "

                                            , conexion);


            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.SelectCommand.CommandTimeout = 36000;
            DataTable dt = new DataTable();
            sda.Fill(dt);



            conexion.Dispose();
            if (dt.Rows.Count > 0)
            {
                Totalarchivos = dt.Rows[0][0].ToString();
                conexion.Dispose();
                Extractorarchivos();
            }
            else { }
        }
        public void Extractorarchivos()
        {



            numerador4 = Int32.Parse(Totalarchivos);

            suma4 = 0;

            for (k4 = 1; k4 <= numerador4; k4++)
            {
                suma4 = suma4 + 1;
                ConsultaArchivosNombre();





            }
            Totalarchivos = DepAtencion;
            enviamasivo2("Atencion a Clientes");
            Totalarchivos = Depproduccion;
            enviamasivo2("Produccion");
            Totalarchivos = DepFinanzas;
            enviamasivo2("Asistente de direccion");
            Totalarchivos = DepProyectos;
            enviamasivo2("Proyectos");
            Totalarchivos = DepEquip;
            enviamasivo2("Construccion e Instalaciones");
            Totalarchivos = DepVentas;
            enviamasivo2("Ventas");

            ////////////////////////////////////SE EJECUTA EL COMANDO HACIA LA VISTA Y SE HACE LA VALIDACION//////////////////////////////////////

        }
        public void ConsultaArchivosNombre()
        {
            SqlConnection conexion = new SqlConnection(ObtenerCadena());
            conexion.Open();
            SqlCommand cmd = new SqlCommand(
                                   "select top " + "(" + suma4 + ")" +
                                   "[Departamento], " +
                                   "[Carpeta], " +

                                   "[Nombre] " +

                                   "from [Index_carpetas] "

                                   , conexion);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.SelectCommand.CommandTimeout = 36000;
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                departamen = dt.Rows[k4 - 1][0].ToString();
                carpet = dt.Rows[k4 - 1][1].ToString();
                nombr = dt.Rows[k4 - 1][2].ToString();
                Thread.Sleep(50);



                switch (departamen)
                {

                    case "Atención a cliente":
                        DepAtencion = DepAtencion + "</DIV>" + nombr;
                        break;

                    case "Ventas":
                        DepVentas = DepVentas + "</DIV>" + nombr;
                        break;
                    case "PRODUCCION":
                        Depproduccion = Depproduccion + "</DIV>" + nombr;
                        break;
                    case "FINANZAS":
                        DepFinanzas = DepFinanzas + "</DIV>" + nombr;
                        break;
                    case "Proyectos":
                        DepProyectos = DepProyectos + "</DIV>" + nombr;
                        break;
                    case "Equipamiento e Instalaciones":
                        DepEquip = DepEquip + "</DIV>" + nombr;
                        break;
                    default:
                        break;
                }

                conexion.Dispose();

            }
            else { }
        }
        public void Proyectondexe()
        {


            SqlConnection conexion2 = new SqlConnection(ObtenerCadena());
            conexion2.Open();
            SqlCommand cmd2 = new SqlCommand(
                                   "select " +
"     [Nombre2] " +


                                   "from [Folio_Proyectos] where Nombre = @Nombre"

                                   , conexion2);
            SqlDataAdapter sda2 = new SqlDataAdapter(cmd2);
            if (Proyecto == null) { Proyecto = ""; }
            else { }
            cmd2.Parameters.AddWithValue("Nombre", Nombre1);
            sda2.SelectCommand.CommandTimeout = 36000;
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            if (dt2.Rows.Count > 0)
            {

                Nomproyectenvia = dt2.Rows[0][0].ToString();

                conexion2.Dispose();
            }
            else
            {


                conexion2.Dispose();
            }

        }
    }
}
