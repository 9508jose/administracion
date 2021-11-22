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
    public partial class Folio_Proyectos : Form
    {
        public Folio_Proyectos()
        {
            InitializeComponent();
        }

        private void Folio_Proyectos_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'folio_Proyectos1._Folio_Proyectos' Puede moverla o quitarla según sea necesario.
            this.folio_ProyectosTableAdapter.Fill(this.folio_Proyectos1._Folio_Proyectos);

        }
    }
}
