using CBR_ADMIN.Properties;
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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CBR_ADMIN.Sistema
{
    public partial class Crea_proyecto : Form
    { 
        private static Crea_proyecto _instance;
        public static Crea_proyecto Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Crea_proyecto();
                return _instance;
            }
        }
        public string Nombre, contraseña,consecutivo,cap,llave,Proyecto;
        int consecutivo1;
        String Email1, Email2, Email3, Email4, Email5, Email6, Email7, Email8, Email9, Email10;
        public Crea_proyecto()
        {
            InitializeComponent();
        }
        public static string ObtenerCadena()
        {
            return Settings.Default.CBR_IngenieriaConnectionString;/*Este codigo obtiene los datos de la cadena de conexion declarada en los settings de la aplicacion*/
       

        }
        string fecha,tipopt,capacidad;
        string codificador;
        public void acceder(string usuario, string contrasena)
        {
           
                if (NombreProyecto.Text.Trim() != "" && Folio.Text.Trim() != "-----" && Tipo.Text.Trim() != "")

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
                                                    "[Contraseña] " +

                                                    "from [Acceso_Carpetas] " +
                                                    "where [Usuario]=@usuario " +
                                                    "and [Contraseña]=@contraseña "
                                                    , conexion);
                    cmd.Parameters.AddWithValue("usuario", Nombre);
                    cmd.Parameters.AddWithValue("contraseña", contraseña);

                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.SelectCommand.CommandTimeout = 36000;
                    DataTable dt = new DataTable();
                    sda.Fill(dt);



                    conexion.Dispose();


                    if (dt.Rows.Count > 0)
                    {
                        string año = DateTime.Now.ToString("yyyy");
                     
                        //MessageBox.Show("Si tiene acceso a esta planta");
                        // this.Close();
                        codificador = LP.SelectedValue.ToString() + "-" + Lobra.SelectedValue.ToString() + "-" + Lins.SelectedValue.ToString();
                        string Nombre = dt.Rows[0][0].ToString();
                        string Apellido = dt.Rows[0][1].ToString();
                        string Usuario = dt.Rows[0][3].ToString();
                        string Permisos = dt.Rows[0][2].ToString();
                        if (Permisos == "Total" || Permisos == "especial")
                        {
                            int consecutivofin = Convert.ToInt32(consecutivo);
                            consecutivofin = consecutivofin + 1;
                            int capacidad = Convert.ToInt32(cap);
                          
                            DateTime Fechaf = DateTime.Now;
                            if (Tipo.Text == "Proyecto Industrial y Potabiliza")
                            {

                                DialogResult Resultado;
                                Resultado = MessageBox.Show("Está seguro que desea crear el proyecto " + NombreProyecto.Text, "Confirmación", MessageBoxButtons.YesNo);
                                if (NombreProyecto.Text.Trim() != "" || Folio.Text.Trim() != "" || Tipo.Text.Trim() != "")

                                {
                                    NewMethod(consecutivofin, capacidad, Fechaf);

                                    if (Resultado == DialogResult.Yes)
                                    {
                                   
                                        var path = @"G:\SGC-PROYECTOS-CBR\SGC\"+año+@"\Proyectos-Industrial-Potabiliza\" + Folio.Text + "-" + NombreProyecto.Text;

                                        if (!System.IO.Directory.Exists(path))
                                        {

                                           System.IO.Directory.CreateDirectory(path);
                                            string strCmdText;
                                            strCmdText = "/C Robocopy G:\\SGC\\2020\\CodificadoresLideres-Indus-Pot\\" + codificador + " " +"\""+"G:\\SGC-PROYECTOS-CBR\\SGC\\"+año+"\\Proyectos-Industrial-Potabiliza\\" + Folio.Text + "-" + NombreProyecto.Text + "\"" + " " + " /E /SEC";
                                            Process cop = System.Diagnostics.Process.Start("CMD.exe", strCmdText);
                                            cop.WaitForExit();
                                            string strCmdText2;
                                            strCmdText2 = "/C Robocopy G:\\SGC\\2020\\Indus-Pot" + " " + "\""+"G:\\SGC-PROYECTOS-CBR\\SGC\\"+año+"\\Proyectos-Industrial-Potabiliza\\" + Folio.Text + "-" + NombreProyecto.Text + "\"" + " " + " /E /SEC";
                                            Process cop2 = System.Diagnostics.Process.Start("CMD.exe", strCmdText2);
                                            cop2.WaitForExit();
                                            this.Hide();
                                            enviamasivo1(Folio.Text);
                                            enviamasivo2(Folio.Text);
                                            enviamasivo3(Folio.Text);
                                            enviamasivo4(Folio.Text);
                                            enviamasivo5(Folio.Text);
                                            enviamasivo6(Folio.Text);
                                            enviamasivo7(Folio.Text);
                                            enviamasivo8(Folio.Text);
                                            enviamasivo9(Folio.Text);
                                            enviamasivo10(Folio.Text);
                                            MessageBox.Show("Proyecto creado correctamente");
                                        }
                                        else if (NombreProyecto.Text.Trim() == "" || Folio.Text.Trim() == "" || Tipo.Text.Trim() == "")
                                        {
                                            MessageBox.Show("Ya existe un proyecto con ese nombre ingrese otro nombre");
                                        }



                                    }
                                    else if (Resultado == DialogResult.No)
                                    {


                                        MessageBox.Show("Operacion Cancelada");
                                        this.Hide();
                                        Close();
                                    }
                                }
                                else { MessageBox.Show("No puede dejar campos vacios"); }
                            }
                            else if (Tipo.Text == "Proyecto Alto Flujo")
                            {

                                DialogResult Resultado;
                                Resultado = MessageBox.Show("Está seguro que desea crear el proyecto " + NombreProyecto.Text, "Confirmación", MessageBoxButtons.YesNo);
                                if (NombreProyecto.Text.Trim() != "" || Folio.Text.Trim() != "" || Tipo.Text.Trim() != "")

                                {
                                    if (Resultado == DialogResult.Yes)
                                    {
                                        NewMethod(consecutivofin, capacidad, Fechaf);
                                        var path = @"G:\SGC-PROYECTOS-CBR\SGC\"+año+@"\Proyectos-Alto-Flujo\" + Folio.Text + "-" + NombreProyecto.Text;

                                        if (!System.IO.Directory.Exists(path))
                                        {
                                         
                                            System.IO.Directory.CreateDirectory(path);
                                            string strCmdText;
                                            strCmdText = "/C Robocopy G:\\SGC\\2020\\CodificadoresLideres-Af-Comp\\" + codificador + " " + "\""+"G:\\SGC-PROYECTOS-CBR\\SGC\\"+año+"\\Proyectos-Alto-Flujo\\" + Folio.Text + "-" + NombreProyecto.Text + "\"" + " " + " /E /SEC";
                                            Process cop = System.Diagnostics.Process.Start("CMD.exe", strCmdText);
                                            cop.WaitForExit();
                                            string strCmdText2;
                                            strCmdText2 = "/C Robocopy G:\\SGC\\2020\\Af-Comp" + " " + "\""+"G:\\SGC-PROYECTOS-CBR\\SGC\\"+año+"\\Proyectos-Alto-Flujo\\" + Folio.Text + "-" + NombreProyecto.Text + "\"" + " " + " /E /SEC";
                                            Process cop2 = System.Diagnostics.Process.Start("CMD.exe", strCmdText2);
                                            cop2.WaitForExit();

                                            this.Hide();
                                            enviamasivo1(Folio.Text);
                                            enviamasivo2(Folio.Text);
                                            enviamasivo3(Folio.Text);
                                            enviamasivo4(Folio.Text);
                                            enviamasivo5(Folio.Text);
                                            enviamasivo6(Folio.Text);
                                            enviamasivo7(Folio.Text);
                                            enviamasivo8(Folio.Text);
                                            enviamasivo9(Folio.Text);
                                            enviamasivo10(Folio.Text);
                                            MessageBox.Show("Proyecto creado correctamente");
                                        }
                                        else if (NombreProyecto.Text.Trim() == "" || Folio.Text.Trim() == "" || Tipo.Text.Trim() == "")
                                        {
                                            MessageBox.Show("Ya existe un proyecto con ese nombre ingrese otro nombre");
                                        }



                                    }
                                    else if (Resultado == DialogResult.No)
                                    {


                                        MessageBox.Show("Operacion Cancelada");
                                        this.Hide();
                                        Close();
                                    }
                                }
                                else { MessageBox.Show("No puede dejar campos vacios"); }
                            }
                            else if (Tipo.Text == "Proyecto Compacta")
                            {

                                DialogResult Resultado;
                                Resultado = MessageBox.Show("Está seguro que desea crear el proyecto " + NombreProyecto.Text, "Confirmación", MessageBoxButtons.YesNo);
                                if (NombreProyecto.Text.Trim() != "" || Folio.Text.Trim() != "" || Tipo.Text.Trim() != "")

                                {
                                    if (Resultado == DialogResult.Yes)
                                    {
                                        NewMethod(consecutivofin, capacidad, Fechaf);
                                        var path = @"G:\SGC-PROYECTOS-CBR\SGC\"+año+@"\Proyectos-Compacta\" + Folio.Text + "-" + NombreProyecto.Text;

                                        if (!System.IO.Directory.Exists(path))
                                        {
                                            System.IO.Directory.CreateDirectory(path);
                                            string strCmdText;
                                            strCmdText = "/C Robocopy G:\\SGC\\2020\\CodificadoresLideres-Af-Comp\\" + codificador + " " + "\""+"G:\\SGC-PROYECTOS-CBR\\SGC\\"+año+"\\Proyectos-Compacta\\" + Folio.Text + "-" + NombreProyecto.Text + "\"" + " " + " /E /SEC";
                                            string strCmdText2;
                                            strCmdText2 = "/C Robocopy G:\\SGC\\2020\\Af-Comp" + " " + "\""+"G:\\SGC-PROYECTOS-CBR\\SGC\\"+año+"\\Proyectos-Compacta\\" + Folio.Text + "-" + NombreProyecto.Text + "\"" + " " + " /E /SEC";
                                            Process cop= System.Diagnostics.Process.Start("CMD.exe", strCmdText);
                                            cop.WaitForExit();
                                            Process cop2= System.Diagnostics.Process.Start("CMD.exe", strCmdText2);
                                            cop2.WaitForExit();

                                            this.Hide();
                                            enviamasivo1(Folio.Text);
                                            enviamasivo2(Folio.Text);
                                            enviamasivo3(Folio.Text);
                                            enviamasivo4(Folio.Text);
                                            enviamasivo5(Folio.Text);
                                            enviamasivo6(Folio.Text);
                                            enviamasivo7(Folio.Text);
                                            enviamasivo8(Folio.Text);
                                            enviamasivo9(Folio.Text);
                                            enviamasivo10(Folio.Text);
                                            MessageBox.Show("Proyecto creado correctamente");
                                        }
                                        else 
                                        {
                                            MessageBox.Show("Ya existe un proyecto con ese nombre ingrese otro nombre");
                                        }



                                    }
                                    else if (Resultado == DialogResult.No)
                                    {


                                        MessageBox.Show("Operacion Cancelada");
                                        this.Hide();
                                        Close();
                                    }
                                }
                                else { MessageBox.Show("No puede dejar campos vacios"); }
                            }
                            else if (Tipo.Text == "Proyectos INOX")
                            {

                                DialogResult Resultado;
                                Resultado = MessageBox.Show("Está seguro que desea crear el proyecto " + NombreProyecto.Text, "Confirmación", MessageBoxButtons.YesNo);
                                if (NombreProyecto.Text.Trim() != "" || Folio.Text.Trim() != "" || Tipo.Text.Trim() != "")

                                {
                                    if (Resultado == DialogResult.Yes)
                                    {
                                        NewMethod(consecutivofin, capacidad, Fechaf);
                                        var path = @"G:\SGC-PROYECTOS-CBR\SGC\"+año+@"\Proyectos-Inox\" + Folio.Text + "-" + NombreProyecto.Text;

                                        if (!System.IO.Directory.Exists(path))
                                        {
                                            System.IO.Directory.CreateDirectory(path);
                                            string strCmdText;
                                            strCmdText = "/C Robocopy G:\\SGC\\2020\\Proyecto-INOX "+" " + "\""+"G:\\SGC-PROYECTOS-CBR\\SGC\\"+año+"\\Proyectos-Inox\\" + Folio.Text + "-" + NombreProyecto.Text + "\"" + " " + " /E /SEC";

                                            System.Diagnostics.Process.Start("CMD.exe", strCmdText);
                                            this.Hide();
                                            enviamasivo1(Folio.Text);
                                            enviamasivo2(Folio.Text);
                                            enviamasivo3(Folio.Text);
                                            enviamasivo4(Folio.Text);
                                            enviamasivo5(Folio.Text);
                                            enviamasivo6(Folio.Text);
                                            enviamasivo7(Folio.Text);
                                            enviamasivo8(Folio.Text);
                                            enviamasivo9(Folio.Text);
                                            enviamasivo10(Folio.Text);
                                            MessageBox.Show("Proyecto creado correctamente");
                                         
                                        }
                                        else if (NombreProyecto.Text.Trim() == "" || Folio.Text.Trim() == "" || Tipo.Text.Trim() == "")
                                        {
                                            MessageBox.Show("Ya existe un proyecto con ese nombre ingrese otro nombre");
                                        }



                                    }
                                    else if (Resultado == DialogResult.No)
                                    {


                                        MessageBox.Show("Operacion Cancelada");
                                        this.Hide();
                                        Close();
                                    }
                                }
                                else { MessageBox.Show("No puede dejar campos vacios"); }
                            }
                          
                        }
                        else
                        {
                            MessageBox.Show("Sin  acceso");
                        }



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

           else 

            {
                MessageBox.Show("faltan campos por llenar");
            }
            }

        private void NewMethod(int consecutivofin, int capacidad, DateTime Fechaf)
        {
            string nombrepro = Folio.Text + "-" + NombreProyecto.Text;
            fecha = DateTime.Today.ToString("yyyy");
            string tipo2="";
            if (Tipo.Text == "Proyecto Compacta") { tipo2 = "Proyectos-Compacta"; }
            else if (Tipo.Text == "Proyecto Alto Flujo") { tipo2 = "Proyectos-Alto-Flujo"; }
            else if (Tipo.Text == "Proyecto Industrial y Potabiliza") { tipo2 = "Proyectos-Industrial-Potabiliza"; }
            else if (Tipo.Text == "Proyectos INOX") { tipo2 = "Proyectos-Inox"; }

            this.folio_ProyectosTableAdapter.Inserta_consecutivo(consecutivofin, norma.Text, tipopt, capacidad, Fechaf, Folio.Text, nombrepro, fecha, tipo2,NombreProyecto.Text, codificador);

        }

        SqlConnection conexion = new SqlConnection(ObtenerCadena());
        public void obtenienconsecutivo()
        {


            try
            {

                ////////////////////////////////////SE ABRE LA CONEXION/////////////////////////////////////////////////////////////////////////////////
                SqlConnection conexion = new SqlConnection(ObtenerCadena());

                conexion.Open();

                ////////////////////////////////////SE EJECUTA EL COMANDO HACIA LA VISTA Y SE HACE LA VALIDACION//////////////////////////////////////
                SqlCommand cmd = new SqlCommand(
                                                "select " +
                                                "[Consecutivo] " +


                                                "from [Folio_Proyectos] " +
                                                "order by Consecutivo" 
                                               
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
                  

                    consecutivo = dt.Rows[d][0].ToString();
                    consecutivo1 = Convert.ToInt32(consecutivo);
                    consecutivo1 = consecutivo1 + 1;    


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
        public void Obtieneverificador()
        {


            try
            {

                ////////////////////////////////////SE ABRE LA CONEXION/////////////////////////////////////////////////////////////////////////////////
                SqlConnection conexion = new SqlConnection(ObtenerCadena());

                conexion.Open();

                ////////////////////////////////////SE EJECUTA EL COMANDO HACIA LA VISTA Y SE HACE LA VALIDACION//////////////////////////////////////
                SqlCommand cmd = new SqlCommand(
                                                "select " +
                                                "[Llave], " +

                                                  "[Proyecto] " +
                                                "from [Verificacion_Proyecto] " +
                                                "Where [Proyecto]=@proyecto"

                                                , conexion);

                cmd.Parameters.AddWithValue("proyecto", NombreProyecto.Text);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.SelectCommand.CommandTimeout = 36000;
                DataTable dt = new DataTable();
                sda.Fill(dt);



                conexion.Dispose();


                if (dt.Rows.Count > 0)
                {

                    //MessageBox.Show("Si tiene acceso a esta planta");
                    // this.Close();
                


                    llave = dt.Rows[0][0].ToString();
                    Proyecto = dt.Rows[0][1].ToString();
                    if (Codigo.Text == llave) {
                         acceder(Nombre, contraseña);
                        verificacion_ProyectoTableAdapter.Elimina(Proyecto);
                       }
                    else { MessageBox.Show("La verificacion si existe pero el codigo de verificacion es incorrecto intente de nuevo o consulte al administrador"); }


                }
                ////////////////////////////////////SI EL USUARIO, CONTRASENA O PLANTA ESTA MAL//////////////////////////////////////////////////////////////////////////
                else
                {


                    MessageBox.Show("Sin datos de verificacion para este proyeto ingresado");
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
        private void norma_SelectedIndexChanged(object sender, EventArgs e)
        {
            obtenienconsecutivo();
            Folio.Text = consecutivo1 + "-" + norma.Text;
        }

        private void Portatiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            obtenienconsecutivo();
            fecha = DateTime.Today.ToString("ddMMyy");
            Folio.Text = consecutivo1 + "-" + norma.Text + tipopt + Portatiles.Text + "-"+fecha;
            cap = Portatiles.Text;
        }

        private void Compactas_SelectedIndexChanged(object sender, EventArgs e)
        {
            obtenienconsecutivo();
            fecha = DateTime.Today.ToString("ddMMyy");
            Folio.Text = consecutivo1 + "-" + norma.Text + tipopt + Compactas.Text + "-"+fecha;
            cap = Compactas.Text;
        }

   



        private void AltoFlujo_SelectedIndexChanged(object sender, EventArgs e)
        {
            obtenienconsecutivo();
            fecha = DateTime.Today.ToString("ddMMyy");
            Folio.Text = consecutivo1 + "-" + norma.Text + tipopt + AltoFlujo.Text + "-"+fecha;
            cap = AltoFlujo.Text;
        }

        private void Tipo_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (Tipo.Text == "Proyecto Industrial y Potabiliza")
            { Portatiles.Visible = false;
                Compactas.Visible = false;
                AltoFlujo.Visible = false;
                Indus.Visible = true;
                tipopt = "E";
                capacidad = "";
                cap = "";
                label7.Visible = true;
                label8.Visible = true;
                label9.Visible = true;
                LP.Visible = true;
                Lobra.Visible = true;
                Lins.Visible = true;
          
                Folio.Text = consecutivo1.ToString();

            }
            else if (Tipo.Text == "Proyecto Alto Flujo")
            { Portatiles.Visible = false;
                Compactas.Visible = false;
                AltoFlujo.Visible = true;
                tipopt = "AF"; capacidad = AltoFlujo.Text;
                label7.Visible = true;
                label8.Visible = true;
                label9.Visible = true;
                LP.Visible = true;
                Lobra.Visible = true;
                Lins.Visible = true;
                Indus.Visible = false;

                Folio.Text = consecutivo1.ToString();

            }
            else if (Tipo.Text == "Proyecto Compacta")
            { Portatiles.Visible = false;
                Compactas.Visible = true;
                       AltoFlujo.Visible = false;
                tipopt = "C"; capacidad = Compactas.Text;
                label7.Visible = true;
                label8.Visible = true;
                label9.Visible = true;
                LP.Visible = true;
                Lobra.Visible = true;
                Lins.Visible = true;
                Indus.Visible = false;

                Folio.Text = consecutivo1.ToString();

            }
            else if (Tipo.Text == "Proyectos INOX")
            { Portatiles.Visible = true;
                Compactas.Visible = false;
                AltoFlujo.Visible = false;
              
                tipopt = "P"; capacidad = Portatiles.Text;
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                LP.Visible = false;
                Lobra.Visible = false;
                Lins.Visible = false;
                Indus.Visible = false;

                Folio.Text = consecutivo1.ToString();

            }
            else if (Tipo.Text == "")
            {
                Portatiles.Visible = false;
                Compactas.Visible = false;
                AltoFlujo.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                LP.Visible = false;
                Lobra.Visible = false;
                Lins.Visible = false;
                Indus.Visible = false;

            }
            obtenienconsecutivo();

            Folio.Text = consecutivo1.ToString();

        }

        private void Indus_SelectedIndexChanged(object sender, EventArgs e)
        {
            obtenienconsecutivo();
            fecha = DateTime.Today.ToString("ddMMyy");
            Folio.Text = consecutivo1 + "-" + norma.Text + tipopt + AltoFlujo.Text + "-" + fecha;
            cap = Indus.Text;
        }

        private void Folio_TextChanged(object sender, EventArgs e)
        {

        }

        private void LP_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Crea_proyecto_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'verificador.Verificacion_Proyecto' Puede moverla o quitarla según sea necesario.
            this.verificacion_ProyectoTableAdapter.Fill(this.verificador.Verificacion_Proyecto);
            // TODO: esta línea de código carga datos en la tabla 'folio_Proyectos._Folio_Proyectos' Puede moverla o quitarla según sea necesario.

            // TODO: esta línea de código carga datos en la tabla 'liderEq.Lideres' Puede moverla o quitarla según sea necesario.
            this.lideresTableAdapter2.FillBy(this.liderEq.Lideres);
            // TODO: esta línea de código carga datos en la tabla 'liderLP.Lideres' Puede moverla o quitarla según sea necesario.
            this.lideresTableAdapter.FillBy(this.liderLP.Lideres);
            // TODO: esta línea de código carga datos en la tabla 'liderLobra.Lideres' Puede moverla o quitarla según sea necesario.
            this.lideresTableAdapter1.FillBy(this.liderLobra.Lideres);
            

       
            
            // TODO: esta línea de código carga datos en la tabla 'iNOX._INOX' Puede moverla o quitarla según sea necesario.
            this.iNOXTableAdapter.Fill(this.iNOX._INOX);
            // TODO: esta línea de código carga datos en la tabla 'compacta._Compacta' Puede moverla o quitarla según sea necesario.
            this.compactaTableAdapter.Fill(this.compacta._Compacta);
            // TODO: esta línea de código carga datos en la tabla 'altoflujo1._Alto_Flujo' Puede moverla o quitarla según sea necesario.
            this.alto_FlujoTableAdapter.Fill(this.altoflujo1._Alto_Flujo);
            string fecha;
            // TODO: esta línea de código carga datos en la tabla 'folio_Proyectos._Folio_Proyectos' Puede moverla o quitarla según sea necesario.

            fecha = DateTime.Today.ToString("ddMMyy");

            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            LP.Visible = false;
            Lobra.Visible = false;
            Lins.Visible = false;
            Indus.Visible = false;
          
        }


        private void Guardar_Click(object sender, EventArgs e)
        {
            Obtieneverificador();
        

         

        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Close();
        }
        /// direccion
        public void enviamasivo1(string Departamento)
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
                cmd.Parameters.AddWithValue("Departamento", "Direccion");



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
                  
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
             
                    message.Subject = "Actualizacion de  Carpeta";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
             
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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

                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                 
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
               
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
        /// Asistente de direccion
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
                cmd.Parameters.AddWithValue("Departamento", "Asistente de direccion");



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
                  
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
      
                    message.Subject = "Actualizacion de  Carpeta";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
              
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
;
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
          
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
    
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
     
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
         
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
        /// ventas
        public void enviamasivo3(string Departamento)
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
                cmd.Parameters.AddWithValue("Departamento", "Ventas");



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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Actualizacion de  Carpeta";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
        /// proyectos
        public void enviamasivo4(string Departamento)
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
                cmd.Parameters.AddWithValue("Departamento", "Proyectos");



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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Actualizacion de  Carpeta";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
        /// produccion
        public void enviamasivo5(string Departamento)
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
                cmd.Parameters.AddWithValue("Departamento", "Produccion");



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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Actualizacion de  Carpeta";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
        /// atencion a clientes
        public void enviamasivo6(string Departamento)
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
                cmd.Parameters.AddWithValue("Departamento", "Atencion a Clientes");



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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Actualizacion de  Carpeta";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
        ///Construccion e Instalaciones
        public void enviamasivo7(string Departamento)
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
                cmd.Parameters.AddWithValue("Departamento", "Construccion e Instalaciones");



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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Actualizacion de  Carpeta";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
        ///Construccion e Instalaciones
        public void enviamasivo8(string Departamento)
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
                cmd.Parameters.AddWithValue("Departamento", "Operacion y Mantenimiento");



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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Actualizacion de  Carpeta";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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

        ///Construccion e Instalaciones
        public void enviamasivo9(string Departamento)
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
                cmd.Parameters.AddWithValue("Departamento", "Infraestructura");



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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Actualizacion de  Carpeta";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
        ///Construccion e Instalaciones
        public void enviamasivo10(string Departamento)
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
                cmd.Parameters.AddWithValue("Departamento", "Administracion");



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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Actualizacion de  Carpeta";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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
                    message.Subject = "Alta de proyecto";
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(getEmbeddedImage2("C:/Program Files/Default Company Name/Cbr App/logo_cbr.png"));
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


        private AlternateView getEmbeddedImage2(String filePath)
        {



            // below line was corrected to include the mediatype so it displays in all 
            // mail clients. previous solution only displays in Gmail the inline images 
            LinkedResource res = new LinkedResource(filePath, MediaTypeNames.Image.Jpeg);
            res.ContentId = Guid.NewGuid().ToString();
            String Body = "<DIV><H5>Se ha generado el proyecto: </HEAD></DIV></H>" +NombreProyecto.Text; ;
            Body += "<DIV><H5>Con folio: </HEAD></DIV></H>" + Folio.Text; ;
            Body += "<DIV>Ingrese ala plataforma para darle seguimiento</DIV>";




            string htmlBody = "" + Body + "" + @"<img src='cid:" + res.ContentId + @"'/> ";
            AlternateView alternateView = AlternateView.CreateAlternateViewFromString(htmlBody,
             null, MediaTypeNames.Text.Html);
            alternateView.LinkedResources.Add(res);
            return alternateView;
        }
    }
}
