using aejw.Network;
using CapturaPantalla;
using CBR_ADMIN.Administracion;
using CBR_ADMIN.Properties;
using CBR_ADMIN.Sistema;
using CBR_VPN;
using Controlador;
using iText.Kernel.Pdf;
using iTextSharp.text.pdf;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CBR_ADMIN
{
    public partial class General21 : Form
    {
        public General21()
        {
            InitializeComponent();
        }

        int menus = 0;
        string Nodos = "menu";

        string Ruteo;
        String Seccion;
        public string Permiso,Formulario="";

        public Bitmap objBitmap;
        public string Apellido;
        public string Ventana;
        public string Departamento;
        public string Puesto;
        public string Email;
        public string Nombre;
        string Nombrenodo;
        public Int32 NumeroConfo, NumeroOport, NumeroOportDep;
        public string NumeroConformidad;
        int conexionvpn;
        string flanco = "";
        public static string ObtenerCadena()
        {
            return Settings.Default.CBR_IngenieriaConnectionString;/*Este codigo obtiene los datos de la cadena de conexion declarada en los settings de la aplicacion*/
        }
        SqlConnection conexion = new SqlConnection(ObtenerCadena());
        frmBuscador ventana = new frmBuscador();
        float widthRatio = Screen.PrimaryScreen.Bounds.Width / 1280;
        float heightRatio = Screen.PrimaryScreen.Bounds.Height / 800f;

        private void General21_Load(object sender, EventArgs e)
        {
            Formulario = "";
            txt_NombrePrincipal.Text = "Bienvenido  " + "" + Nombre + "  " + Apellido;
            txt_Nombre.Text = "a Cbr Administracion y Servicios";
            //SizeF scale = new SizeF(widthRatio, heightRatio);
            //this.Scale(scale);
            //foreach (Control control in this.Controls)
            //{
            //    control.Font = new Font("Verdana", control.Font.SizeInPoints * heightRatio * widthRatio);
            //}
            pnlSGCAdmin.Hide();
            pnlInventarios.Hide();
            pnlTickets.Hide();
            pnlExplorador.Hide();
            pnlVentas.Hide();
            pnlClientes.Hide();
            pnlConfiguraciones.Hide();
            timer1.Enabled = true;
            timer1.Interval = 1000;


            try
            {
                ////////////////////////////////////SE ABRE LA CONEXION/////////////////////////////////////////////////////////////////////////////////
                SqlConnection conexion = new SqlConnection(ObtenerCadena());
                conexion.Open();
                ////////////////////////////////////SE EJECUTA EL COMANDO HACIA LA VISTA Y SE HACE LA VALIDACION//////////////////////////////////////
                SqlCommand cmd = new SqlCommand(
                                                "select COUNT(*) AS conteo from [No_Conformidades] where  " +
                                                "  (Status ='Abierta')" +
                                                "and (Departamento = @Departamento)"
                                                , conexion);
                cmd.Parameters.AddWithValue("Departamento", Departamento);

                SqlCommand cmd1 = new SqlCommand(
                                    "select COUNT(*) AS conteo from [No_Conformidades] where (Departamento = @Departamento)  and (Status ='Cerrada')"
                                    , conexion);
                cmd1.Parameters.AddWithValue("Departamento", Departamento);


                SqlCommand cmd2 = new SqlCommand(
                                  "select COUNT([# NC]) AS conteo from [No_Conformidades] "
                                  , conexion);


                SqlCommand cmd3 = new SqlCommand(
              "select COUNT(*) AS conteo from [No_Conformidades] where " +
              "  (Status ='Verificando')" +
              "and (Departamento = @Departamento)"
              , conexion);
                cmd3.Parameters.AddWithValue("Responsable", Nombre);
                cmd3.Parameters.AddWithValue("Departamento", Departamento);


                SqlCommand cmd4 = new SqlCommand(
           "select COUNT(*) AS conteo from [Op_Mejora] "
           , conexion);


                SqlCommand cmd5 = new SqlCommand(
                                                "select COUNT(*) AS conteo from [Op_Mejora] where  " +
                                                "  (Status ='Abierta')" +
                                                "and (Departamento = @Departamento)"
                                                , conexion);

                cmd5.Parameters.AddWithValue("Departamento", Departamento);
                SqlCommand cmd6 = new SqlCommand(
                                    "select COUNT(*) AS conteo from [Op_Mejora] where  " +
                                    "  (Status ='Cerrada') " +
                                    "and (Departamento = @Departamento)"
                                    , conexion);

                cmd6.Parameters.AddWithValue("Departamento", Departamento);


                SqlCommand cmd7 = new SqlCommand(
                                    "select COUNT(*) AS conteo from [No_Conformidades] where  " +
                                    "  (Status ='Abierta')" +
                                    "and (Departamento = 'General')"
                                    , conexion);



                SqlCommand cmd8 = new SqlCommand(
                                    "select COUNT(*) AS conteo from [No_Conformidades] where (Departamento = 'General')  and (Status ='Cerrada')"
                                    , conexion);


                SqlCommand cmd9 = new SqlCommand(
                                    "select COUNT(*) AS conteo from [No_Conformidades] where (Departamento = 'General')  and  (Status ='Verificando')"
                                    , conexion);





                Int32 rows_count = Convert.ToInt32(cmd.ExecuteScalar());
                Int32 rows_count1 = Convert.ToInt32(cmd1.ExecuteScalar());
                Int32 rows_count2 = Convert.ToInt32(cmd3.ExecuteScalar());
                Int32 rows_count3 = Convert.ToInt32(cmd5.ExecuteScalar());
                Int32 rows_count4 = Convert.ToInt32(cmd6.ExecuteScalar());
                Int32 rows_count5 = Convert.ToInt32(cmd7.ExecuteScalar());
                Int32 rows_count6 = Convert.ToInt32(cmd9.ExecuteScalar());
                Int32 rows_count7 = Convert.ToInt32(cmd8.ExecuteScalar());

                NumeroConfo = Convert.ToInt32(cmd2.ExecuteScalar());
                NumeroOport = Convert.ToInt32(cmd4.ExecuteScalar());

                cmd.Dispose();
                cmd1.Dispose();
                cmd2.Dispose();
                cmd3.Dispose();
                cmd4.Dispose();
                cmd5.Dispose();
                cmd6.Dispose();
                cmd7.Dispose();
                cmd8.Dispose();
                cmd9.Dispose();

                conexion.Close();

                NumeroConformidad = NumeroConfo.ToString();
                txt_NC_Abiertas.Text = rows_count.ToString();
                txt_Nc_Concluidas.Text = rows_count1.ToString();
                txt_NC_Verificacion.Text = rows_count2.ToString();
                txt_Op_Abiertas.Text = rows_count3.ToString();
                txt_Op_Cerradas.Text = rows_count4.ToString();
               txt_Ncag.Text = rows_count5.ToString();
                txt_Ncvg.Text = rows_count6.ToString();
                txt_Nccg.Text = rows_count7.ToString();
                txt_Usuario.Text = Nombre + " /n" + Apellido;
              
            }
            catch (Exception d)
            {
                MessageBox.Show(d.Message);
            }
            finally
            {

            }

            txt_Departamento.Text = "Departamento:"+Departamento;
            txt_Puesto.Text ="Puesto:"+ Puesto;
            txt_Email.Text = "Email:"+Email;
   
        }

        private void btnSGCAdmin_Click(object sender, EventArgs e)
        {
            if (pnlSGCAdmin.Visible == false)
            {
                pnlInventarios.Hide();
                pnlTickets.Hide();
                pnlExplorador.Hide();
                pnlVentas.Hide();
                pnlClientes.Hide();
                pnlConfiguraciones.Hide();
                pnlVentas.Hide();
                pnlSGCAdmin.Show();
            }
            else
            {
                pnlSGCAdmin.Visible = false;
            }

        }

        private void btnInventarios_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Apartado en construccion");
            //if (pnlInventarios.Visible == false)
            //{
            //    pnlTickets.Hide();
            //    pnlExplorador.Hide();
            //    pnlVentas.Hide();
            //    pnlClientes.Hide();
            //    pnlConfiguraciones.Hide();
            //    pnlSGCAdmin.Hide();
            //    pnlInventarios.Show();
            //}
            //else
            //{
            //    pnlInventarios.Visible = false;
            //}
        }

        private void btnTickets_Click(object sender, EventArgs e)
        {

            if (pnlTickets.Visible == false)
            {
                pnlExplorador.Hide();
                pnlVentas.Hide();
                pnlClientes.Hide();
                pnlConfiguraciones.Hide();
                pnlSGCAdmin.Hide();
                pnlInventarios.Hide();
                pnlTickets.Show();
            }
            else
            {
                pnlTickets.Visible = false;
            }

        }

        private void btnExplorador_Click(object sender, EventArgs e)
        {


            if (pnlExplorador.Visible == false)
            {
                pnlVentas.Hide();
                pnlClientes.Hide();
                pnlConfiguraciones.Hide();
                pnlSGCAdmin.Hide();
                pnlInventarios.Hide();
                pnlTickets.Hide();
                pnlExplorador.Show();
            }
            else
            {
                pnlExplorador.Visible = false;

            }
        }

        private void btnConfiguraciones_Click(object sender, EventArgs e)
        {

            if (Permiso == "1")
            {
                if (pnlConfiguraciones.Visible == false)
                {
                    pnlSGCAdmin.Hide();
                    pnlInventarios.Hide();
                    pnlTickets.Hide();
                    pnlExplorador.Hide();
                    pnlVentas.Hide();
                    pnlClientes.Hide();
                    pnlConfiguraciones.Show();
                }
                else
                {
                    pnlConfiguraciones.Visible = false;

                }
            }
            else {
                MessageBox.Show("No cuentas con permisos para acceder a este apartado");
            }
        }


        private void btnVentas_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Apartado en construccion");
            //if (pnlVentas.Visible == false)
            //{
            //    pnlClientes.Hide();
            //    pnlConfiguraciones.Hide();
            //    pnlSGCAdmin.Hide();
            //    pnlInventarios.Hide();
            //    pnlTickets.Hide();
            //    pnlExplorador.Hide();
            //    pnlVentas.Show();
            //}
            //else
            //{
            //    pnlVentas.Visible = false;
            //}
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Apartado en construccion");
            //if (pnlClientes.Visible == false)
            //{
            //    pnlSGCAdmin.Hide();
            //    pnlInventarios.Hide();
            //    pnlTickets.Hide();
            //    pnlExplorador.Hide();
            //    pnlConfiguraciones.Hide();
            //    pnlSGCAdmin.Hide();
            //    pnlVentas.Hide();
            //    pnlClientes.Show();
            //}
            //else
            //{
            //    pnlClientes.Visible = false;
            //}
        }

        private void tvExplorador_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            String selec = e.Node.Text;
            Formulario = "Explorador Integrador";
            CentralGeneral.Controls.Clear();
            if (selec == "Explorador Integrador")
            {


                NetworkDrive oNetDrive = new NetworkDrive();

                try
                {
                    //set propertys

                    oNetDrive.LocalDrive = "G";
                    oNetDrive.ShareName = url.Text;
                    //match call to options provided

                    oNetDrive.MapDrive();
                    conexionvpn = 1;

                    //update status

                }
                catch (Exception err)
                {
                    //report error
                    //
                    //     MessageBox.Show(this, "Cannot map drive!\nError: " + err.Message);
                }
                oNetDrive = null;




                if (!CentralGeneral.Controls.Contains(windowsNavegador.Instance))
                {
                    Ventana = "Pantalla: Consulta de No Conformidad";
                    windowsNavegador.Instance.usuario = Nombre;
                    windowsNavegador.Instance.apellido = Apellido;
                    windowsNavegador.Instance.departamento = Departamento;
                    CentralGeneral.Controls.Add(windowsNavegador.Instance);
                    windowsNavegador.Instance.Dock = DockStyle.Fill;
                    windowsNavegador.Instance.BringToFront();
                 
                }
                else
                {
                    windowsNavegador.Instance.BringToFront();
                    Ventana = "Pantalla: Consulta de No Conformidad";
                }
            }
            else if (selec == "Explorador Visualizador")
            {
                NetworkDrive oNetDrive = new NetworkDrive();
                Formulario = "Explorador Visualizador";
                try
                {
                    //set propertys

                    oNetDrive.LocalDrive = "G";
                    oNetDrive.ShareName = url.Text;
                    //match call to options provided

                    oNetDrive.MapDrive();
                    conexionvpn = 1;

                    //update status

                }
                catch (Exception err)
                {
                    //report error
                    //
                    //     MessageBox.Show(this, "Cannot map drive!\nError: " + err.Message);
                }
                oNetDrive = null;

                if (!CentralGeneral.Controls.Contains(uscExplorador.Instance))
                {
                    uscExplorador.Instance.departamento = Departamento;
                    uscExplorador.Instance.usuario = Nombre;
                    uscExplorador.Instance.apellido = Apellido;
                    CentralGeneral.Controls.Add(uscExplorador.Instance);
                    uscExplorador.Instance.Dock = DockStyle.Fill;
                    uscExplorador.Instance.BringToFront();
                }

                else
                {
                    uscExplorador.Instance.BringToFront();

                }
            }
            else if (selec == "Crear nuevo proyecto")
            {
                Validacion_carpetas crear = new Validacion_carpetas();
                crear.Show();
                Formulario = "";
            }
            else if (selec == "Cambio de Lideres")
            {
                Formulario = "";
                if (!CentralGeneral.Controls.Contains(Actualiza_lideres.Instance))
                {
                    CentralGeneral.Controls.Add(Actualiza_lideres.Instance);
                    Actualiza_lideres.Instance.Dock = DockStyle.Fill;
                    Actualiza_lideres.Instance.BringToFront();
                }
                else
                {
                    Actualiza_lideres.Instance.BringToFront();
                }
            }
            else if (selec == "Consulta Proyectos")
            {
                CBR_ADMIN.Sistema.Folio_Proyectos crear1 = new CBR_ADMIN.Sistema.Folio_Proyectos();
                Formulario = "";
                crear1.Show();
            }
            else if (selec == "Generar Validador")
            {
                ValidadorProyecto crear = new ValidadorProyecto();

                crear.Show();
                Formulario = "";
            }
            else if (selec == "Crear Nueva Rehabilitacion")
            {
                Formulario = "";
            }




        }



        public bool BuscarNodos(System.Collections.IEnumerable nodos, string buscar) //Consigue el nodo
        {


            foreach (TreeNode nodo in nodos)
            {


                if (nodo.Text.ToUpper().Contains(buscar.ToUpper())) //En cada nodo se busca que tengan lo que se quiere buscar
                {

                    if (Nodos == "menu1")
                    {
                        menu1.SelectedNode = nodo; //Selecciona el nodo, ayuda a seleccionar hijas
                        Nombrenodo = nodo.Text;
                        Ruteo = nodo.FullPath.ToString();
                        Seccion = "SGC Administración";
                        if (Nombrenodo != Ruteo)
                        {
                            ventana.dgdBusqueda.Rows.Add(Nombrenodo, Ruteo, Seccion);
                        }
                        else
                        {
                            ventana.dgdBusqueda.Rows.Add(Nombrenodo, "--", Seccion);
                        }

                        ventana.Show();
                    }
                    if (Nodos == "menu2")
                    {

                        menu2.SelectedNode = nodo; //Selecciona el nodo, ayuda a seleccionar hijas
                        Nombrenodo = nodo.Text;
                        Ruteo = nodo.FullPath.ToString();
                        Seccion = "Inventarios";
                        if (Nombrenodo != Ruteo)
                        {
                            ventana.dgdBusqueda.Rows.Add(Nombrenodo, Ruteo, Seccion);
                        }
                        else
                        {
                            ventana.dgdBusqueda.Rows.Add(Nombrenodo, "--", Seccion);
                        }
                        ventana.Show();

                    }
                    if (Nodos == "menu3")
                    {

                        menu3.SelectedNode = nodo; //Selecciona el nodo, ayuda a seleccionar hijas
                        Nombrenodo = nodo.Text;
                        Ruteo = nodo.FullPath.ToString();
                        Seccion = "Tickets";
                        if (Nombre != Ruteo)
                        {
                            ventana.dgdBusqueda.Rows.Add(Nombrenodo, Ruteo, Seccion);
                        }
                        else
                        {
                            ventana.dgdBusqueda.Rows.Add(Nombrenodo, "--", Seccion);
                        }
                        ventana.Show();

                    }
                    if (Nodos == "menu4")
                    {

                        menu4.SelectedNode = nodo; //Selecciona el nodo, ayuda a seleccionar hijas
                        Nombrenodo = nodo.Text;
                        Ruteo = nodo.FullPath.ToString();
                        Seccion = "Explorador de archivos";
                        if (Nombre != Ruteo)
                        {
                            ventana.dgdBusqueda.Rows.Add(Nombrenodo, Ruteo, Seccion);
                        }
                        else
                        {
                            ventana.dgdBusqueda.Rows.Add(Nombrenodo, "--", Seccion); //Si es el mismo ruteo como nombre se pone --
                        }
                        ventana.Show();

                    }
                    if (Nodos == "menu5")
                    {

                        menu5.SelectedNode = nodo; //Selecciona el nodo, ayuda a seleccionar hijas
                        Nombrenodo = nodo.Text;
                        Ruteo = nodo.FullPath.ToString();
                        Seccion = "Ventas";
                        if (Nombre != Ruteo)
                        {
                            ventana.dgdBusqueda.Rows.Add(Nombrenodo, Ruteo, Seccion);
                        }
                        else
                        {
                            ventana.dgdBusqueda.Rows.Add(Nombrenodo, "--", Seccion); //Si es el mismo ruteo como nombre se pone --
                        }
                        ventana.Show();

                    }
                    if (Nodos == "menu6")
                    {

                        menu6.SelectedNode = nodo; //Selecciona el nodo, ayuda a seleccionar hijas
                        Nombrenodo = nodo.Text;
                        Ruteo = nodo.FullPath.ToString();
                        Seccion = "Clientes";
                        if (Nombre != Ruteo)
                        {
                            ventana.dgdBusqueda.Rows.Add(Nombrenodo, Ruteo, Seccion);
                        }
                        else
                        {
                            ventana.dgdBusqueda.Rows.Add(Nombrenodo, "--", Seccion); //Si es el mismo ruteo como nombre se pone --
                        }
                        ventana.Show();

                    }
                    if (Nodos == "menu7")
                    {

                        menu7.SelectedNode = nodo; //Selecciona el nodo, ayuda a seleccionar hijas
                        Nombrenodo = nodo.Text;
                        Ruteo = nodo.FullPath.ToString();
                        Seccion = "Configuraciones";
                        if (Nombre != Ruteo)
                        {
                            ventana.dgdBusqueda.Rows.Add(Nombrenodo, Ruteo, Seccion);
                        }
                        else
                        {
                            ventana.dgdBusqueda.Rows.Add(Nombrenodo, "--", Seccion);
                        }
                        ventana.Show();

                    }



                }
                if (BuscarNodos(nodo.Nodes, buscar))  //Consigue los nodos hijas del nodo padre

                    return true;


            }
            return false;
        }

        private void btnBuscador_Click(object sender, EventArgs e) //Muestra la ventana de buscador
        {
            ventana.Show();
        }

        public void BuscarGeneral(String busqueda) //Ayuda a buscar entre todo los treeview
        {
            if (busqueda != "")
            {


                for (menus = 1; menus <= 7; menus++)
                {
                    Nodos = Nodos + menus.ToString();
                    if (Nodos == "menu1")
                    {
                        BuscarNodos(menu1.Nodes, busqueda);

                        Nodos = "menu";
                    }
                    else if (Nodos == "menu2")
                    {

                        BuscarNodos(menu2.Nodes, busqueda);
                        Nodos = "menu";
                    }
                    else if (Nodos == "menu3")
                    {

                        BuscarNodos(menu3.Nodes, busqueda);
                        Nodos = "menu";
                    }
                    else if (Nodos == "menu4")
                    {

                        BuscarNodos(menu4.Nodes, busqueda);
                        Nodos = "menu";
                    }
                    else if (Nodos == "menu5")
                    {

                        BuscarNodos(menu5.Nodes, busqueda);
                        Nodos = "menu";
                    }
                    else if (Nodos == "menu6")
                    {

                        BuscarNodos(menu6.Nodes, busqueda);
                        Nodos = "menu";
                    }
                    else if (Nodos == "menu7")
                    {

                        BuscarNodos(menu7.Nodes, busqueda);
                        Nodos = "menu";
                    }
                }

            }
        }

        public void BuscarRutaGeneral(String busqueda) //Ayuda a buscar entre todo los treeview
        {
            if (busqueda != "")
            {


                for (menus = 1; menus <= 7; menus++)
                {
                    Nodos = Nodos + menus.ToString();
                    if (Nodos == "menu1")
                    {
                        BuscarRutaNodos(menu1.Nodes, busqueda);

                        Nodos = "menu";
                    }
                    else if (Nodos == "menu2")
                    {

                        BuscarRutaNodos(menu2.Nodes, busqueda);
                        Nodos = "menu";
                    }
                    else if (Nodos == "menu3")
                    {

                        BuscarRutaNodos(menu3.Nodes, busqueda);
                        Nodos = "menu";
                    }
                    else if (Nodos == "menu4")
                    {

                        BuscarRutaNodos(menu4.Nodes, busqueda);
                        Nodos = "menu";
                    }
                    else if (Nodos == "menu5")
                    {

                        BuscarRutaNodos(menu5.Nodes, busqueda);
                        Nodos = "menu";
                    }
                    else if (Nodos == "menu6")
                    {

                        BuscarRutaNodos(menu6.Nodes, busqueda);
                        Nodos = "menu";
                    }
                    else if (Nodos == "menu7")
                    {

                        BuscarRutaNodos(menu7.Nodes, busqueda);
                        Nodos = "menu";
                    }
                }

            }
        }

        public bool BuscarRutaNodos(System.Collections.IEnumerable nodos, string buscar) //Consigue el nodo
        {


            foreach (TreeNode nodo in nodos)
            {


                if (nodo.FullPath.ToString().Equals(buscar)) //En cada nodo se busca que tengan lo que se quiere buscar
                {

                    if (Nodos == "menu1")
                    {
                        pnlSGCAdmin.Show();
                        menu1.SelectedNode = nodo; //Selecciona el nodo, ayuda a seleccionar hijas
                        menu1.Focus();
                        
                    }
                    if (Nodos == "menu2")
                    {
                        pnlInventarios.Show();
                        menu2.SelectedNode = nodo; //Selecciona el nodo, ayuda a seleccionar hijas
                        menu2.Focus();

                    }
                    if (Nodos == "menu3")
                    {
                        pnlTickets.Show();
                        menu3.SelectedNode = nodo; //Selecciona el nodo, ayuda a seleccionar hijas
                        menu3.Focus();
                      

                    }
                    if (Nodos == "menu4")
                    {
                        pnlExplorador.Show();
                        menu4.SelectedNode = nodo; //Selecciona el nodo, ayuda a seleccionar hijas
                        menu4.Focus();

                    }
                    if (Nodos == "menu5")
                    {
                        pnlVentas.Show();
                        menu5.SelectedNode = nodo; //Selecciona el nodo, ayuda a seleccionar hijas
                        menu5.Focus();

                    }
                    if (Nodos == "menu6")
                    {
                        pnlClientes.Show();
                        menu6.SelectedNode = nodo; //Selecciona el nodo, ayuda a seleccionar hijas
                        menu6.Focus();

                    }
                    if (Nodos == "menu7")
                    {
                        pnlConfiguraciones.Show();
                        menu7.SelectedNode = nodo; //Selecciona el nodo, ayuda a seleccionar hijas
                        menu7.Focus();

                    }



                }
                if (BuscarRutaNodos(nodo.Nodes, buscar))  //Consigue los nodos hijas del nodo padre

                    return true;


            }
            return false;
        }

        private void menu5_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
            Application.Exit();
        }

        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            btnClose.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.icons8_close_light_48));
            btnClose.BackColor = Color.Red;
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.icons8_close_48));
            btnClose.BackColor = Color.Transparent;
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void menu1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            String selec = e.Node.Text;


            CentralGeneral.Controls.Clear();
            if (selec == "Generacion No Conformidades")
            {
                if (!CentralGeneral.Controls.Contains(Genera_No_Confor.Instance))
                {
                    Formulario = "Generacion No Conformidades";

                    CentralGeneral.Controls.Add(Genera_No_Confor.Instance);
                    Genera_No_Confor.Instance.Dock = DockStyle.None;
                    Genera_No_Confor.Instance.BringToFront();
                }

                else
                {
                    uscExplorador.Instance.BringToFront();
                    Formulario = "Generacion No Conformidades";

                }
            }


            else if (selec == "Cierre")
            {
                if (Permiso == "1")
                {
                    if (!CentralGeneral.Controls.Contains(Cierre_No_confor.Instance))
                    {
                        Formulario = "Cierre";
                        CentralGeneral.Controls.Add(Cierre_No_confor.Instance);
                        Cierre_No_confor.Instance.Dock = DockStyle.Fill;
                        Cierre_No_confor.Instance.BringToFront();
                    }

                    else
                    {
                        Cierre_No_confor.Instance.BringToFront();
                        Formulario = "";
                    }
                }
                else { MessageBox.Show("No cuentas con permisos para acceder"); }
            }



            else if (selec == "Detalle")
            {
                if (Permiso == "1")
                {
                    Formulario = "Detalle";

                    if (!CentralGeneral.Controls.Contains(Detalle.Instance))
                    {
                        CentralGeneral.Controls.Add(Detalle.Instance);
                        Detalle.Instance.Dock = DockStyle.Fill;
                        Detalle.Instance.BringToFront();
                    }

                    else
                    {
                        Detalle.Instance.BringToFront();

                    }
                }
                else { MessageBox.Show("No cuentas con permisos para acceder"); }
            }


            else if (selec == "Seguimiento")
            {
                if (!CentralGeneral.Controls.Contains(Seguimiento_No_confor.Instance))
                {
                    Formulario = "Seguimiento";
                    Seguimiento_No_confor.Instance.Departamento = Departamento;
                    CentralGeneral.Controls.Add(Seguimiento_No_confor.Instance);
             
                    Seguimiento_No_confor.Instance.Dock = DockStyle.Fill;
                    Seguimiento_No_confor.Instance.BringToFront();
                }

                else
                {
                    Seguimiento_No_confor.Instance.BringToFront();

                }
            }

            else if (selec == "Actualización")
            {
                if (Permiso == "1")
                {
                    Formulario = "Actualización";
                    if (!CentralGeneral.Controls.Contains(Actualizacion_NC.Instance))
                    {
                        CentralGeneral.Controls.Add(Actualizacion_NC.Instance);
                        Actualizacion_NC.Instance.Dock = DockStyle.Fill;
                        Actualizacion_NC.Instance.BringToFront();
                    }

                    else
                    {
                        Actualizacion_NC.Instance.BringToFront();

                    }
                }
                else { MessageBox.Show("No cuentas con permisos para acceder"); }
            }

            else if (selec == "General")
            {
                Formulario = "Actualización";
                if (!CentralGeneral.Controls.Contains(Consulta_No_Conf_general.Instance))
                {
                    CentralGeneral.Controls.Add(Consulta_No_Conf_general.Instance);
                    Consulta_No_Conf_general.Instance.Dock = DockStyle.Fill;
                    Consulta_No_Conf_general.Instance.BringToFront();
                }

                else
                {
                    Consulta_No_Conf_general.Instance.BringToFront();

                }
            }

            else if (selec == "Consulta Filtrada")
            {
                Formulario = "Consulta Filtrada";
                if (!CentralGeneral.Controls.Contains(Consulta_No_Conf.Instance))
                {
                    Consulta_No_Conf.Instance.Departamento = Departamento;
                    CentralGeneral.Controls.Add(Consulta_No_Conf.Instance);
                   
                    Consulta_No_Conf.Instance.Dock = DockStyle.Fill;
                    Consulta_No_Conf.Instance.BringToFront();
                }

                else
                {
                    Consulta_No_Conf.Instance.BringToFront();

                }
            }

            else if (selec == "Generación")
            {
                if (!CentralGeneral.Controls.Contains(Genera_AM.Instance))
                {
                    Formulario = "Generación";
                    CentralGeneral.Controls.Add(Genera_AM.Instance);
                    Genera_AM.Instance.Dock = DockStyle.Fill;
                    Genera_AM.Instance.BringToFront();
                }

                else
                {
                    Genera_AM.Instance.BringToFront();

                }
            }


            else if (selec == "Seguimiento OP")
            {
                Formulario = "Seguimiento OP";
                if (!CentralGeneral.Controls.Contains(Seguimiento_AM.Instance))
                {
                    Seguimiento_AM.Instance.Departamento = Departamento;
                    CentralGeneral.Controls.Add(Seguimiento_AM.Instance);
                    
                    Seguimiento_AM.Instance.Dock = DockStyle.Fill;
                    Seguimiento_AM.Instance.BringToFront();
                }

                else
                {
                    Seguimiento_AM.Instance.BringToFront();

                }
            }

            else if (selec == "Cierre OP")
            {
                if (!CentralGeneral.Controls.Contains(Ciere_Accion_Mejora.Instance))
                {
                    Formulario = "Cierre OP";
                    CentralGeneral.Controls.Add(Ciere_Accion_Mejora.Instance);
                    Ciere_Accion_Mejora.Instance.Dock = DockStyle.Fill;
                    Ciere_Accion_Mejora.Instance.BringToFront();
                }

                else
                {
                    Ciere_Accion_Mejora.Instance.BringToFront();

                }
            }

            else if (selec == "Consulta General OP")
            {
                if (!CentralGeneral.Controls.Contains(Consulta_OportunidadesMejora_General.Instance))
                {
                    Formulario = "Consulta General OP";
                    CentralGeneral.Controls.Add(Consulta_OportunidadesMejora_General.Instance);
                    Consulta_OportunidadesMejora_General.Instance.Dock = DockStyle.Fill;
                    Consulta_OportunidadesMejora_General.Instance.BringToFront();
                }

                else
                {
                    Consulta_OportunidadesMejora_General.Instance.BringToFront();

                }
            }

            else if (selec == "Consulta Filtrada OP")
            {
                Formulario = "Consulta Filtrada OP";
                if (!CentralGeneral.Controls.Contains(Consulta_Oportunidades_Mejora.Instance))
                {
                    Consulta_Oportunidades_Mejora.Instance.Departamento = Departamento;
                    CentralGeneral.Controls.Add(Consulta_Oportunidades_Mejora.Instance);
                  
                    Consulta_Oportunidades_Mejora.Instance.Dock = DockStyle.Fill;
                    Consulta_Oportunidades_Mejora.Instance.BringToFront();
                }

                else
                {
                    Consulta_Oportunidades_Mejora.Instance.BringToFront();

                }
            }
            else if (selec == "Formatos/Instrucciones de trabajo")
            {
                Formulario = "Formatos/Instrucciones de trabajo";
                NetworkDrive oNetDrive = new NetworkDrive();

                try
                {
                    //set propertys

                    oNetDrive.LocalDrive = "G";
                    oNetDrive.ShareName = url.Text;
                    //match call to options provided

                    oNetDrive.MapDrive();
                    conexionvpn = 1;

                    //update status

                }
                catch (Exception err)
                {
                    //report error
                    //
                    //     MessageBox.Show(this, "Cannot map drive!\nError: " + err.Message);
                }
                oNetDrive = null;

                if (!CentralGeneral.Controls.Contains(uscTrabajo.Instance))
                {
                    CentralGeneral.Controls.Add(uscTrabajo.Instance);
                    uscTrabajo.Instance.Dock = DockStyle.Fill;
                    uscTrabajo.Instance.BringToFront();
                }

                else
                {
                    uscTrabajo.Instance.BringToFront();

                }
            }
            else if (selec == "Actualizar Graficas")
            {
                Formulario = "";
                Actualiza_porcentaje genera = new Actualiza_porcentaje();
                genera.Show();
            }


        }

    
        private void Btn_TiposNC_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    ////////////////////////////////////SE ABRE LA CONEXION/////////////////////////////////////////////////////////////////////////////////
                    SqlConnection conexion = new SqlConnection(ObtenerCadena());
                    conexion.Open();
                    ////////////////////////////////////SE EJECUTA EL COMANDO HACIA LA VISTA Y SE HACE LA VALIDACION//////////////////////////////////////
                    SqlCommand cmd = new SqlCommand(
                                                    "select COUNT(*) AS conteo from [No_Conformidades] where  " +
                                                    "  (Status ='Abierta')" +
                                                    "and (Departamento = @Departamento)"
                                                    , conexion);
                    cmd.Parameters.AddWithValue("Responsable", Nombre);
                    cmd.Parameters.AddWithValue("Departamento", Departamento);

                    SqlCommand cmd1 = new SqlCommand(
                                        "select COUNT(*) AS conteo from [No_Conformidades] where (Departamento = @Departamento)  and (Status ='Cerrada')"
                                        , conexion);
                    cmd1.Parameters.AddWithValue("Departamento", Departamento);


                    SqlCommand cmd2 = new SqlCommand(
                                      "select COUNT([# NC]) AS conteo from [No_Conformidades] "
                                      , conexion);


                    SqlCommand cmd3 = new SqlCommand(
                  "select COUNT(*) AS conteo from [No_Conformidades] where " +
                  "  (Status ='Verificando')" +
                  "and (Departamento = @Departamento)"
                  , conexion);
                    cmd3.Parameters.AddWithValue("Responsable", Nombre);
                    cmd3.Parameters.AddWithValue("Departamento", Departamento);


                    SqlCommand cmd4 = new SqlCommand(
               "select COUNT(*) AS conteo from [Op_Mejora] "
               , conexion);


                    SqlCommand cmd5 = new SqlCommand(
                                                    "select COUNT(*) AS conteo from [Op_Mejora] where  " +
                                                    "  (Status ='Abierta')" +
                                                    "and (Departamento = @Departamento)"
                                                    , conexion);

                    cmd5.Parameters.AddWithValue("Departamento", Departamento);
                    SqlCommand cmd6 = new SqlCommand(
                                        "select COUNT(*) AS conteo from [Op_Mejora] where  " +
                                        "  (Status ='Cerrada') " +
                                        "and (Departamento = @Departamento)"
                                        , conexion);

                    cmd6.Parameters.AddWithValue("Departamento", Departamento);


                    SqlCommand cmd7 = new SqlCommand(
                                        "select COUNT(*) AS conteo from [No_Conformidades] where  " +
                                        "  (Status ='Abierta')"

                                        , conexion);



                    SqlCommand cmd8 = new SqlCommand(
                                        "select COUNT(*) AS conteo from [No_Conformidades] where (Status ='Cerrada')"
                                        , conexion);


                    SqlCommand cmd9 = new SqlCommand(
                                        "select COUNT(*) AS conteo from [No_Conformidades] where   (Status ='Verificando')"
                                        , conexion);





                    Int32 rows_count = Convert.ToInt32(cmd.ExecuteScalar());
                    Int32 rows_count1 = Convert.ToInt32(cmd1.ExecuteScalar());
                    Int32 rows_count2 = Convert.ToInt32(cmd3.ExecuteScalar());
                    Int32 rows_count3 = Convert.ToInt32(cmd5.ExecuteScalar());
                    Int32 rows_count4 = Convert.ToInt32(cmd6.ExecuteScalar());
                    Int32 rows_count5 = Convert.ToInt32(cmd7.ExecuteScalar());
                    Int32 rows_count6 = Convert.ToInt32(cmd8.ExecuteScalar());
                    Int32 rows_count7 = Convert.ToInt32(cmd9.ExecuteScalar());

                    NumeroConfo = Convert.ToInt32(cmd2.ExecuteScalar());
                    NumeroOport = Convert.ToInt32(cmd4.ExecuteScalar());

                    cmd.Dispose();
                    cmd1.Dispose();
                    cmd2.Dispose();
                    cmd3.Dispose();
                    cmd4.Dispose();
                    cmd5.Dispose();
                    cmd6.Dispose();
                    cmd7.Dispose();
                    cmd8.Dispose();
                    cmd9.Dispose();

                    conexion.Close();

                    NumeroConformidad = NumeroConfo.ToString();
                  
                    txt_Ncag.Text = rows_count5.ToString();
                    txt_Ncvg.Text = rows_count7.ToString();
                    txt_Nccg.Text = rows_count6.ToString();
                   
                }
                catch (Exception d)
                {
                    MessageBox.Show(d.Message);
                }
                finally
                {

                }
            }
            else if (e.Button == MouseButtons.Left)
            {
                try
                {
                    ////////////////////////////////////SE ABRE LA CONEXION/////////////////////////////////////////////////////////////////////////////////
                    SqlConnection conexion = new SqlConnection(ObtenerCadena());
                    conexion.Open();
                    ////////////////////////////////////SE EJECUTA EL COMANDO HACIA LA VISTA Y SE HACE LA VALIDACION//////////////////////////////////////
                    SqlCommand cmd = new SqlCommand(
                                                    "select COUNT(*) AS conteo from [No_Conformidades] where  " +
                                                    "  (Status ='Abierta')" +
                                                    "and (Departamento = @Departamento)"
                                                    , conexion);
                    cmd.Parameters.AddWithValue("Responsable", Nombre);
                    cmd.Parameters.AddWithValue("Departamento", Departamento);

                    SqlCommand cmd1 = new SqlCommand(
                                        "select COUNT(*) AS conteo from [No_Conformidades] where (Departamento = @Departamento)  and (Status ='Cerrada')"
                                        , conexion);
                    cmd1.Parameters.AddWithValue("Departamento", Departamento);


                    SqlCommand cmd2 = new SqlCommand(
                                      "select COUNT([# NC]) AS conteo from [No_Conformidades] "
                                      , conexion);


                    SqlCommand cmd3 = new SqlCommand(
                  "select COUNT(*) AS conteo from [No_Conformidades] where " +
                  "  (Status ='Verificando')" +
                  "and (Departamento = @Departamento)"
                  , conexion);
                    cmd3.Parameters.AddWithValue("Responsable", Nombre);
                    cmd3.Parameters.AddWithValue("Departamento", Departamento);


                    SqlCommand cmd4 = new SqlCommand(
               "select COUNT(*) AS conteo from [Op_Mejora] "
               , conexion);


                    SqlCommand cmd5 = new SqlCommand(
                                                    "select COUNT(*) AS conteo from [Op_Mejora] where  " +
                                                    "  (Status ='Abierta')" +
                                                    "and (Departamento = @Departamento)"
                                                    , conexion);

                    cmd5.Parameters.AddWithValue("Departamento", Departamento);
                    SqlCommand cmd6 = new SqlCommand(
                                        "select COUNT(*) AS conteo from [Op_Mejora] where  " +
                                        "  (Status ='Cerrada') " +
                                        "and (Departamento = @Departamento)"
                                        , conexion);

                    cmd6.Parameters.AddWithValue("Departamento", Departamento);


                    SqlCommand cmd7 = new SqlCommand(
                                        "select COUNT(*) AS conteo from [No_Conformidades] where  " +
                                        "  (Status ='Abierta')" +
                                        "and (Departamento = 'General')"
                                        , conexion);



                    SqlCommand cmd8 = new SqlCommand(
                                        "select COUNT(*) AS conteo from [No_Conformidades] where (Departamento = 'General')  and (Status ='Cerrada')"
                                        , conexion);


                    SqlCommand cmd9 = new SqlCommand(
                                        "select COUNT(*) AS conteo from [No_Conformidades] where (Departamento = 'General')  and  (Status ='Verificando')"
                                        , conexion);





                    Int32 rows_count = Convert.ToInt32(cmd.ExecuteScalar());
                    Int32 rows_count1 = Convert.ToInt32(cmd1.ExecuteScalar());
                    Int32 rows_count2 = Convert.ToInt32(cmd3.ExecuteScalar());
                    Int32 rows_count3 = Convert.ToInt32(cmd5.ExecuteScalar());
                    Int32 rows_count4 = Convert.ToInt32(cmd6.ExecuteScalar());
                    Int32 rows_count5 = Convert.ToInt32(cmd7.ExecuteScalar());
                    Int32 rows_count6 = Convert.ToInt32(cmd8.ExecuteScalar());
                    Int32 rows_count7 = Convert.ToInt32(cmd9.ExecuteScalar());

                    NumeroConfo = Convert.ToInt32(cmd2.ExecuteScalar());
                    NumeroOport = Convert.ToInt32(cmd4.ExecuteScalar());

                    cmd.Dispose();
                    cmd1.Dispose();
                    cmd2.Dispose();
                    cmd3.Dispose();
                    cmd4.Dispose();
                    cmd5.Dispose();
                    cmd6.Dispose();
                    cmd7.Dispose();
                    cmd8.Dispose();
                    cmd9.Dispose();

                    conexion.Close();

                    NumeroConformidad = NumeroConfo.ToString();
                   
                    txt_Ncag.Text = rows_count5.ToString();
                    txt_Ncvg.Text = rows_count7.ToString();
                    txt_Nccg.Text = rows_count6.ToString();
                    
                }
                catch (Exception d)
                {
                    MessageBox.Show(d.Message);
                }
                finally
                {

                }


            }
        }

        private void menu3_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            String selec = e.Node.Text;


            CentralGeneral.Controls.Clear();
            if (selec == "Administración")
            {
                Formulario = "Administración";
                if (!CentralGeneral.Controls.Contains(IT.Administracion.Instance))
                {
                    CBR_ADMIN.IT.Administracion.Instance.Nombre = Nombre;
                    CBR_ADMIN.IT.Administracion.Instance.Apellido = Apellido;
                    CentralGeneral.Controls.Add(CBR_ADMIN.IT.Administracion.Instance);
                    CBR_ADMIN.IT.Administracion.Instance.Dock = DockStyle.Fill;
                    CBR_ADMIN.IT.Administracion.Instance.BringToFront();
                }
                else
                {
                    CBR_ADMIN.IT.Administracion.Instance.BringToFront();
                }
            }
            else if (selec == "Aplicativo")
            {
                Formulario = "Aplicativo";
                if (!CentralGeneral.Controls.Contains(IT.Aplicativo.Instance))
                {
                    CBR_ADMIN.IT.Aplicativo.Instance.Nombre = Nombre;
                    CBR_ADMIN.IT.Aplicativo.Instance.Apellido = Apellido;

                    CentralGeneral.Controls.Add(IT.Aplicativo.Instance);
                    IT.Aplicativo.Instance.Dock = DockStyle.Fill;
                    IT.Aplicativo.Instance.BringToFront();
                }
                else
                {
                    IT.Administracion.Instance.BringToFront();
                }
            }
            else if (selec == "Optimización")
            {
                Formulario = "Optimización";
                if (!CentralGeneral.Controls.Contains(IT.Optimizacion.Instance))
                {
                    CBR_ADMIN.IT.Optimizacion.Instance.Nombre = Nombre;
                    CBR_ADMIN.IT.Optimizacion.Instance.Apellido = Apellido;

                    CentralGeneral.Controls.Add(CBR_ADMIN.IT.Optimizacion.Instance);
                    CBR_ADMIN.IT.Optimizacion.Instance.Dock = DockStyle.Fill;
                    CBR_ADMIN.IT.Optimizacion.Instance.BringToFront();
                }
                else
                {
                    CBR_ADMIN.IT.Optimizacion.Instance.BringToFront();
                }
            }
            else if (selec == "Otros")
            {
                Formulario = "Otros";
                if (!CentralGeneral.Controls.Contains(IT.Otros.Instance))
                {
                    CBR_ADMIN.IT.Otros.Instance.Nombre = Nombre;
                    CBR_ADMIN.IT.Otros.Instance.Apellido = Apellido;
                    CentralGeneral.Controls.Add(CBR_ADMIN.IT.Otros.Instance);
                    CBR_ADMIN.IT.Otros.Instance.Dock = DockStyle.Fill;
                    CBR_ADMIN.IT.Otros.Instance.BringToFront();
                }
                else
                {
                    CBR_ADMIN.IT.Otros.Instance.BringToFront();
                }
            }
            else if (selec == "Servicios")
            {
                Formulario = "Servicios";
                if (!CentralGeneral.Controls.Contains(IT.Servicio.Instance))
                {
                    CBR_ADMIN.IT.Servicio.Instance.Nombre = Nombre;
                    CBR_ADMIN.IT.Servicio.Instance.Apellido = Apellido;
                    CentralGeneral.Controls.Add(CBR_ADMIN.IT.Servicio.Instance);
                    CBR_ADMIN.IT.Servicio.Instance.Dock = DockStyle.Fill;
                    CBR_ADMIN.IT.Servicio.Instance.BringToFront();
                }
                else
                {
                    CBR_ADMIN.IT.Servicio.Instance.BringToFront();
                }
            }
            else if (selec == "Soporte")
            {
                Formulario = "Soporte";
                if (!CentralGeneral.Controls.Contains(IT.Soporte.Instance))
                {
                    IT.Soporte.Instance.Nombre = Nombre;
                    IT.Soporte.Instance.Apellido = Apellido;
                  
                    CentralGeneral.Controls.Add(IT.Soporte.Instance);
                    IT.Soporte.Instance.Dock = DockStyle.Fill;
                    IT.Soporte.Instance.BringToFront();
                }
                else
                {
                   IT.Soporte.Instance.BringToFront();
                }
            }


        }

        private void menu7_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {

            String selec = e.Node.Text;

            CentralGeneral.Controls.Clear();
            if (selec == "Alta de Usuarios")
            {
                Formulario = "Alta de Usuarios";
                if (!CentralGeneral.Controls.Contains(Alta_usuarios.Instance))
                {
                    Ventana = "Pantalla: Seguimiento de No conformidad";

                    CentralGeneral.Controls.Add(Alta_usuarios.Instance);
                    Alta_usuarios.Instance.Dock = DockStyle.Fill;
                    Alta_usuarios.Instance.BringToFront();


                }
                else
                {
                    Alta_usuarios.Instance.BringToFront();
                    Ventana = "Pantalla: Seguimiento de No conformidad";
                }
            }
            else if (selec == "Baja de Usuarios")
            {
                Formulario = "Baja de Usuarios";
                if (!CentralGeneral.Controls.Contains(Baja_usuarios.Instance))
                {
                    Ventana = "Pantalla: Seguimiento de No conformidad";

                    CentralGeneral.Controls.Add(Baja_usuarios.Instance);
                    Baja_usuarios.Instance.Dock = DockStyle.Fill;
                    Baja_usuarios.Instance.BringToFront();


                }
                else
                {
                    Baja_usuarios.Instance.BringToFront();
                    Ventana = "Pantalla: Seguimiento de No conformidad";
                }

            }
            else if (selec == "Modificar Usuarios")
            {
                Formulario = "Modificar Usuarios";
                if (!CentralGeneral.Controls.Contains(Config_usuarios.Instance))
                {


                    CentralGeneral.Controls.Add(Config_usuarios.Instance);
                    Config_usuarios.Instance.Dock = DockStyle.Fill;
                    Config_usuarios.Instance.BringToFront();


                }
                else
                {
                    Config_usuarios.Instance.BringToFront();

                }

            }
            else if (selec == "Roles de Usuarios")
            {
                MessageBox.Show("Apartado en construccion");
            }
            else if (selec == "Cambio de Contraseña")
            {
                Formulario = "Cambio de Contraseña";
                if (!CentralGeneral.Controls.Contains(Sistema.Password.Instance))
                {
       


                    CBR_ADMIN.Sistema.Password.Instance.Nombre = Nombre;
                    Sistema.Password.Instance.Apellido = Apellido;


                    CentralGeneral.Controls.Add(Sistema.Password.Instance);
                    Sistema.Password.Instance.Dock = DockStyle.Fill;
                    Sistema.Password.Instance.BringToFront();



                }
                else
                {
                    Consulta_OportunidadesMejora_General.Instance.BringToFront();
                    Ventana = "Pantalla: Detalle No conformidad";
                }

            }


        }



        private void btn_PedidoInterno_Click(object sender, EventArgs e)
        {
            Process.Start(@"G:\SGC\Formatos\Ventas\FVT.01 Pedido Interno.xlsx");
        }

        private void btn_Cotizacion_Click(object sender, EventArgs e)
        {
            DialogResult Resultado;
            Resultado = MessageBox.Show("Seleccione el tipo de Cotizacion", "Confirmación", MessageBoxButtons.OKCancel);
            if (Resultado == DialogResult.OK)
            {
                Process.Start(@"G:\SGC\Formatos\Ventas\FVT.07 Cotización PTAR COMPACTA WEA®_1.docx");


            }
            else if (Resultado == DialogResult.Cancel)
            {
                Process.Start(@"G:\SGC\Formatos\Ventas\FVT.08 Cotización PTAR ALTO FLUJO WEA®_1.docx");
            }
        }

        private void btnGenerarPedido_Click(object sender, EventArgs e)
        {
            Process.Start(@"G:\SGC\Formatos\Ventas\FVT.04 Pedido del Cliente.xlsx");
        }

        private void btn_AltaCliente_Click(object sender, EventArgs e)
        {
            Process.Start(@"G:\SGC\Formatos\Ventas\FVT.17 Alta de cliente COCOA.xlsx");
        }

        private void btn_ListadeMaterial_Click(object sender, EventArgs e)
        {
            Process.Start(@"G:\SGC\Formatos\Proyectos\FCP.07 Lista de Materiales y Requisición_6.xlsx");
        }

        private void btn_Requisicion_Click(object sender, EventArgs e)
        {
            Process.Start(@"G:\SGC\Formatos\Compras\FCM.01 Rev.0 Requisición de Material o Servicio.xlsx");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CBR_ADMIN.Administracion.Avance genera = new CBR_ADMIN.Administracion.Avance();
            genera.Show();
        }

        private void btnSincronizar_Click(object sender, EventArgs e)
        {
            try
            {
                ////////////////////////////////////SE ABRE LA CONEXION/////////////////////////////////////////////////////////////////////////////////
                SqlConnection conexion = new SqlConnection(ObtenerCadena());
                conexion.Open();
                ////////////////////////////////////SE EJECUTA EL COMANDO HACIA LA VISTA Y SE HACE LA VALIDACION//////////////////////////////////////
                SqlCommand cmd = new SqlCommand(
                                                "select COUNT(*) AS conteo from [No_Conformidades] where  " +
                                                " (Status ='Abierta')" +
                                                "and (Departamento = @Departamento)"
                                                , conexion);
                cmd.Parameters.AddWithValue("Responsable", Nombre);
                cmd.Parameters.AddWithValue("Departamento", Departamento);
                SqlCommand cmd1 = new SqlCommand(
                                    "    select COUNT(*) AS conteo from[No_Conformidades] where(Departamento = @Departamento)  and(Status = 'Cerrada') or(Status = 'Verificando')"
                                    , conexion);

                cmd1.Parameters.AddWithValue("Responsable", Nombre);
                cmd1.Parameters.AddWithValue("Departamento", Departamento);



                SqlCommand cmd2 = new SqlCommand(
                                  "select COUNT([# NC]) AS conteo from [No_Conformidades] "
                                  , conexion);
                SqlCommand cmd3 = new SqlCommand(
                              "select COUNT(*) AS conteo from [No_Conformidades] where " +
                              "  (Status ='Verificando')" +
                              "and (Departamento = @Departamento)"
                              , conexion);

                cmd3.Parameters.AddWithValue("Departamento", Departamento);
                SqlCommand cmd4 = new SqlCommand(
                              "select COUNT(*) AS conteo from [Op_Mejora]  "
                              , conexion);


                SqlCommand cmd5 = new SqlCommand(
                                                "select COUNT(*) AS conteo from [Op_Mejora] where  " +
                                                "  (Status ='Abierta')" +
                                                "and (Departamento = @Departamento)"
                                                , conexion);

                cmd5.Parameters.AddWithValue("Departamento", Departamento);
                SqlCommand cmd6 = new SqlCommand(
                                    "select COUNT(*) AS conteo from [Op_Mejora] where  " +
                                    "  (Status ='Cerrada') " +
                                    "and (Departamento = @Departamento)"
                                    , conexion);

                cmd6.Parameters.AddWithValue("Departamento", Departamento);
                cmd3.Parameters.AddWithValue("Responsable", Nombre);


                Int32 rows_count = Convert.ToInt32(cmd.ExecuteScalar());
                Int32 rows_count1 = Convert.ToInt32(cmd1.ExecuteScalar());
                Int32 rows_count2 = Convert.ToInt32(cmd3.ExecuteScalar());
                Int32 rows_count3 = Convert.ToInt32(cmd5.ExecuteScalar());
                Int32 rows_count4 = Convert.ToInt32(cmd6.ExecuteScalar());
                NumeroOport = Convert.ToInt32(cmd3.ExecuteScalar());
                NumeroConfo = Convert.ToInt32(cmd4.ExecuteScalar());
                cmd.Dispose();
                cmd1.Dispose();
                cmd2.Dispose();
                cmd3.Dispose();
                cmd4.Dispose();
                conexion.Close();
                NumeroConformidad = NumeroConfo.ToString();
                txt_NC_Abiertas.Text = rows_count.ToString();
                txt_Nc_Concluidas.Text = rows_count1.ToString();
                txt_NC_Verificacion.Text = rows_count2.ToString();
                txt_Op_Abiertas.Text = rows_count3.ToString();
                txt_Op_Cerradas.Text = rows_count4.ToString();
            }
            catch (Exception d)
            {
                MessageBox.Show(d.Message);
            }
            finally
            {

            }
        }

        private void btnBuscador_Click_1(object sender, EventArgs e)
        {
            CBR_ADMIN.frmBuscador genera = new CBR_ADMIN.frmBuscador();
            genera.Show();
            flanco = "1";
        }

        private void tableLayoutPanel7_MouseMove(object sender, MouseEventArgs e)
        {
            if (flanco == "1")
            {
                string valor = GeneralDatos.Nodo;
                if (valor == null || valor == "") { }
                else
                {
                    BuscarRutaGeneral(valor);

                    // this.folio_ProyectosTableAdapter.FillBy(folio_Proyectos._Folio_Proyectos, valor);
                    flanco = "0";
                }
            }
            else { }
        }

        private void ayuda_Click(object sender, EventArgs e)
        {if (Formulario == "") { MessageBox.Show("No ha abierto un formulario"); }
            else
            {
                Ayuda traer = new Ayuda();

                traer.Formulario = Formulario;
                traer.Show();
            }
        }


        private void btn_CerrarFormulario_Click(object sender, EventArgs e)
        {
            CentralGeneral.Controls.Clear();
            Formulario = "";
        }

        private void btn_Captura_Click(object sender, EventArgs e)
        {
           
                try
                {
                    //Comprobamos si la ventana está maximizada, si lo está
                
                    if (this.WindowState == FormWindowState.Maximized)
                    {
                        this.WindowState = FormWindowState.Maximized;
                    }
         
                   

                    //esperamos unos milisegundos 
              
                    System.Threading.Thread.Sleep(250);

                    //obtenemos la resolución de pantalla
                    Rectangle tamanoEscritorio =
                        Screen.GetBounds(this.ClientRectangle);

                //creamos un Bitmap del tamaño de nuestra pantalla
               objBitmap = new Bitmap(tamanoEscritorio.Width,
                        tamanoEscritorio.Height);
                    //creamos el gráifco en base al Bitmap objBitmap 
                    Graphics objGrafico = Graphics.FromImage(objBitmap);
                    //transferimos la captura al objeto objGrafico en 
                    //base a las medidas del bitmap
                    objGrafico.CopyFromScreen(0, 0, 0, 0, objBitmap.Size);
                    //liberamos el gráfico de memoria                            
                    objGrafico.Flush();

                }
                catch (Exception objError)
                {
                    MessageBox.Show(objError.ToString(), "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    this.Show();
                }


            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "JPEG|*.jpeg";
            dialog.Title = "Save Test As Jpeg";
            dialog.ShowDialog();

            if (dialog.FileName != "" && objBitmap != null)
            {
                objBitmap.Save(dialog.FileName);
            }

        }


    }
}

