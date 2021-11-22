using CBR_ADMIN.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CBR_ADMIN.Sistema
{
    public partial class Crea_Propuesta : Form
    {
        public string consecutivo;
        int consecutivo1;
        String Tipo1, fecha;
        string valor;
        public Crea_Propuesta()
        {
            InitializeComponent();
        }

        private void Folio_TextChanged(object sender, EventArgs e)
        {

        }
        public static string ObtenerCadena()
        {
            return Settings.Default.CBR_IngenieriaConnectionString;/*Este codigo obtiene los datos de la cadena de conexion declarada en los settings de la aplicacion*/


        }
        SqlConnection conexion = new SqlConnection(ObtenerCadena());
        public void obtenienconsecutivo()
        {


            try
            {
                fecha = DateTime.Today.ToString("yyyy");
                ////////////////////////////////////SE ABRE LA CONEXION/////////////////////////////////////////////////////////////////////////////////
                SqlConnection conexion = new SqlConnection(ObtenerCadena());

                conexion.Open();

                ////////////////////////////////////SE EJECUTA EL COMANDO HACIA LA VISTA Y SE HACE LA VALIDACION//////////////////////////////////////
                SqlCommand cmd = new SqlCommand(
                                                "select " +
                                                "[Consecutivo] " +


                                                "from [Folio_Prospectos] " +
                                                  " where Ano =@Ano" +
                                                "order by Consecutivo"

                                                , conexion);

                cmd.Parameters.AddWithValue("Ano", fecha);
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
                MessageBox.Show("Sin registros en el año, consecutivo iniciado");
                consecutivo1 = consecutivo1 + 1;
            }
            finally
            {

            }
        }

    



        private void Crea_Propuesta_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'cBR_Prospectos.Folio_Prospectos' Puede moverla o quitarla según sea necesario.
            this.folio_ProspectosTableAdapter.Fill(this.cBR_Prospectos.Folio_Prospectos);
            label7.Visible = false;
            label8.Visible = false;
            comboBox2.Visible = false;
            comboBox3.Visible = false;
            comboBox4.Visible = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string consecutivo2;
            valor = comboBox1.Text;
            if (valor == "No")
            {
                label7.Visible = false;
                label8.Visible = false;
                label3.Visible = true;
                NombreProyecto.Visible = true;
                comboBox3.Visible = false;
                comboBox2.Visible = false;
                comboBox4.Visible = false;
                fecha = DateTime.Today.ToString("yy");
                if (Tipo.Text == "Propuesta Tecnica") { Tipo1 = "PT"; }
                if (Tipo.Text == "Propuesta Economica") { Tipo1 = "PE"; }
                if (Tipo.Text == "Propuesta Tecnica Economica") { Tipo1 = "PTE"; }
                obtenienconsecutivo();
            
                if (consecutivo1 <= 9) { consecutivo2 = "00" + consecutivo1; }
                else if (consecutivo1 > 9) {
                    consecutivo2 = "0" + consecutivo1;
                }

           //     Folio.Text = Tipo1 + "-" + consecutivo2 + "-" + fecha;
            }
            if (valor == "Si")
            {
                label7.Visible = true;
                label8.Visible = true;
                comboBox2.Visible = true;
                comboBox3.Visible = true;
                comboBox4.Visible = true;
                label3.Visible = false;
                NombreProyecto.Visible = false;
            }
        }



        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            fecha = DateTime.Today.ToString("yy");
            if (Tipo.Text == "Propuesta Tecnica") { Tipo1 = "PT"; }
            if (Tipo.Text == "Propuesta Economica") { Tipo1 = "PE"; }
            if (Tipo.Text == "Propuesta Tecnica Economica") { Tipo1 = "PTE"; }
            obtenienconsecutivo();
            Folio.Text = Tipo1 + "-" + consecutivo1 + "-" + fecha + "-" + comboBox2.Text;
        }



        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Close();
        }

        private void Guardar_Click(object sender, EventArgs e)
        {



            DialogResult Resultado;
            Resultado = MessageBox.Show("Está seguro que desea crear el proyecto " + NombreProyecto.Text, "Confirmación", MessageBoxButtons.YesNo);
        
                string año = DateTime.Now.ToString("yyyy");
            if (NombreProyecto.Text.Trim() != "" || Folio.Text.Trim() != "" || Tipo.Text.Trim() != "")

            {
                if (Resultado == DialogResult.Yes)
                {
                    var path="";
                    valor = comboBox1.Text;
                    if (valor == "No")
                    {  path = @"G:\SGC-PROYECTOS-CBR\SGC\" + año + @"\Proyectos-Industrial-Potabiliza\Propuesta\" + NombreProyecto.Text; }
                    if (valor == "Si")
                    { path = @"G:\SGC-PROYECTOS-CBR\SGC\" + comboBox4.Text + @"\Proyectos-Industrial-Potabiliza\Propuesta\"+comboBox3.Text+"\\" + Proyecto.Text; }




                    if (!System.IO.Directory.Exists(path))
                    {

                        System.IO.Directory.CreateDirectory(path);
                        DateTime Fechaf = DateTime.Now;

                        this.folio_ProspectosTableAdapter.Inserta(consecutivo1, norma.Text, Tipo.Text, Fechaf, Folio.Text, Proyecto.Text, año, path);
                        this.Hide();
                        Close();
                        MessageBox.Show("Proyecto creado correctamente");
                    }
                }
                else if (NombreProyecto.Text.Trim() == "" || Folio.Text.Trim() == "" || Tipo.Text.Trim() == "")
                {
                    MessageBox.Show("No se pueden dejar espacios en blanco");
                }
            }
             }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Proyecto.Text = comboBox3.Text+"-"+comboBox2.Text;
        }

        private void NombreProyecto_TextChanged(object sender, EventArgs e)
        {
            Proyecto.Text = NombreProyecto.Text;
        }
    }
}
