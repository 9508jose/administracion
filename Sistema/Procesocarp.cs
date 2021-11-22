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
    public partial class Procesocarp : Form
    {
        public string contador,total;

        private void Procesocarp_Load(object sender, EventArgs e)
        {
            label1.Text = contador + " de " + total + " carpetas cargadas...";
        }

        public Procesocarp()
        {
            InitializeComponent();
        }
    }
}
