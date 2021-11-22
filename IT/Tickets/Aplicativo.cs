using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CBR_ADMIN.Sistema;
using System.Threading;

namespace CBR_ADMIN.IT
{
    public partial class Aplicativo : UserControl
    {
        private static Aplicativo _instance;
        public static Aplicativo Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Aplicativo();
                return _instance;
            }
        }

        public Aplicativo()
        {
            InitializeComponent();
        }

        public string Permiso;
        public string Nombre;
        public string Apellido;
        String Tik;
        String fecha2, fecha3, fecha4;
        String Hora2;


        private void MostrarCuadroInicio()
        {
            Loading Cargando = new Loading();
            Cargando.ShowDialog();

        }
        private void Aplicativo_Load(object sender, EventArgs e)
        {
            ThreadStart proceso = new ThreadStart(MostrarCuadroInicio); Thread hilo = new Thread(proceso);
            hilo.Start();

            // TODO: esta línea de código carga datos en la tabla 'cBR_Tikets.Tickets' Puede moverla o quitarla según sea necesario.
            this.ticketsTableAdapter.Fill(this.cbr_Tikets.Tickets);

            string UsuarioWindows = SystemInformation.UserName;
            uwin.Text = UsuarioWindows;
            Usuario.Text = Nombre;
            hilo.Abort();
        }



        private void generar_Click(object sender, EventArgs e)
        {
            fecha2 = DateTime.Now.ToString("MM");
            fecha3 = DateTime.Now.ToString("yy");
            Hora2 = DateTime.Now.ToString("hh");
            fecha4 = fecha2 + fecha3;
            Tik = Nombre.Substring(0, 2) + "AP" + fecha4 + "-" + Hora2;


            this.ticketsTableAdapter.Generar(Tik, "Aplicativo", Nombre, Apellido, detalles.Text, "NA", "3", "Sin iniciar");
            this.tikets_fechaTableAdapter.TikFech(Tik, DateTime.Now);
            DialogResult Resultado;

            Resultado = MessageBox.Show("Tiket Generado");
            Resultado = MessageBox.Show("Su Tiket es  " + Tik);
        }
    }
}

