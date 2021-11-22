using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CBR_ADMIN.Sistema
{
    public partial class Proceso : Form
    {
        public Proceso()
        {
            InitializeComponent();
            timer1.Start();
        }
        int il=0;
        private void timer1_Tick(object sender, EventArgs e)
        {


            il += 1;
            switch (il)
            {
                case 1:
                    label2.Text = "Iniciando proceso de validacion...";
                    break;
                case 10:
                    label2.Text = "Proceso de validacion iniciado...";
                    break;
                case 20:
                    label2.Text = "Cargando directivas....";
                    break;
                case 40:
                    label2.Text = "Verificando archivos...";
                    break;
                case 80:
                    label2.Text = "Convalidando nuevos permisos...";
                    break;
                case 100:
                    label2.Text = "Preparando sistema para migración...";
                    break;
                case 200:
                    label2.Text = "Proceso iniciado porfavor espere..";
                    break;



            }

        }
    }
}
