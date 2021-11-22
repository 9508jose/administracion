using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CBR_ADMIN.Sistema
{
    public partial class Actualiza_lideres : UserControl
    {
        private static Actualiza_lideres _instance;
        public static Actualiza_lideres Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Actualiza_lideres();
                return _instance;
            }
        }
        public Actualiza_lideres()
        {
            InitializeComponent();
        }

        private void Actualiza_lideres_Load(object sender, EventArgs e)
        {
            this.lideresTableAdapter.FillBy(this.liderLP.Lideres);
            this.lideresTableAdapter1.FillBy(this.liderLobra.Lideres);
            this.lideresTableAdapter2.FillBy(this.liderEq.Lideres);
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LP1_Click(object sender, EventArgs e)
        {
            this.lideresTableAdapter.lider1_LP(nombrelp1.Text);
            this.lideresTableAdapter.FillBy(this.liderLP.Lideres);
            this.lideresTableAdapter1.FillBy(this.liderLobra.Lideres);
            this.lideresTableAdapter2.FillBy(this.liderEq.Lideres);
        }

        private void LP2_Click(object sender, EventArgs e)
        {
            this.lideresTableAdapter.lider2_LP(nombrelp2.Text);
            this.lideresTableAdapter.FillBy(this.liderLP.Lideres);
            this.lideresTableAdapter1.FillBy(this.liderLobra.Lideres);
            this.lideresTableAdapter2.FillBy(this.liderEq.Lideres);
        }

        private void LP3_Click(object sender, EventArgs e)
        {
            this.lideresTableAdapter.lider3_LP(nombrelp3.Text);
            this.lideresTableAdapter.FillBy(this.liderLP.Lideres);
            this.lideresTableAdapter1.FillBy(this.liderLobra.Lideres);
            this.lideresTableAdapter2.FillBy(this.liderEq.Lideres);
        }

        private void LP4_Click(object sender, EventArgs e)
        {
            this.lideresTableAdapter.lider4_LP(nombrelp4.Text);
            this.lideresTableAdapter.FillBy(this.liderLP.Lideres);
            this.lideresTableAdapter1.FillBy(this.liderLobra.Lideres);
            this.lideresTableAdapter2.FillBy(this.liderEq.Lideres);
        }

        private void Lobra1_Click(object sender, EventArgs e)
        {
            this.lideresTableAdapter1.lider1_Lobra(nombrelobra1.Text);
            this.lideresTableAdapter.FillBy(this.liderLP.Lideres);
            this.lideresTableAdapter1.FillBy(this.liderLobra.Lideres);
            this.lideresTableAdapter2.FillBy(this.liderEq.Lideres);
        }

        private void Lobra2_Click(object sender, EventArgs e)
        {
            this.lideresTableAdapter1.lider2_Lobra(nombrelobra2.Text);
            this.lideresTableAdapter.FillBy(this.liderLP.Lideres);
            this.lideresTableAdapter1.FillBy(this.liderLobra.Lideres);
            this.lideresTableAdapter2.FillBy(this.liderEq.Lideres);
        }

        private void Lobra3_Click(object sender, EventArgs e)
        {
            this.lideresTableAdapter1.lider3_Lobra(nombrelobra3.Text);
            this.lideresTableAdapter.FillBy(this.liderLP.Lideres);
            this.lideresTableAdapter1.FillBy(this.liderLobra.Lideres);
            this.lideresTableAdapter2.FillBy(this.liderEq.Lideres);
        }

        private void Lobra4_Click(object sender, EventArgs e)
        {
            this.lideresTableAdapter1.lider4_Lobra(nombrelobra4.Text);
            this.lideresTableAdapter.FillBy(this.liderLP.Lideres);
            this.lideresTableAdapter1.FillBy(this.liderLobra.Lideres);
            this.lideresTableAdapter2.FillBy(this.liderEq.Lideres);

        }

        private void Leq1_Click(object sender, EventArgs e)
        {
            this.lideresTableAdapter2.lider_Eq1(nombreleq1.Text);
            this.lideresTableAdapter.FillBy(this.liderLP.Lideres);
            this.lideresTableAdapter1.FillBy(this.liderLobra.Lideres);
            this.lideresTableAdapter2.FillBy(this.liderEq.Lideres);
        }

        private void Leq2_Click(object sender, EventArgs e)
        {
            this.lideresTableAdapter2.lider_Eq2(nombreLeq2.Text);
            this.lideresTableAdapter.FillBy(this.liderLP.Lideres);
            this.lideresTableAdapter1.FillBy(this.liderLobra.Lideres);
            this.lideresTableAdapter2.FillBy(this.liderEq.Lideres);
        }

        private void leq3_Click(object sender, EventArgs e)
        {
            this.lideresTableAdapter2.lider_Eq3(nombreLq3.Text);
            this.lideresTableAdapter.FillBy(this.liderLP.Lideres);
            this.lideresTableAdapter1.FillBy(this.liderLobra.Lideres);
            this.lideresTableAdapter2.FillBy(this.liderEq.Lideres);
        }

        private void leq4_Click(object sender, EventArgs e)
        {
            this.lideresTableAdapter2.lider_Eq4(nombreLq4.Text);
            this.lideresTableAdapter.FillBy(this.liderLP.Lideres);
            this.lideresTableAdapter1.FillBy(this.liderLobra.Lideres);
            this.lideresTableAdapter2.FillBy(this.liderEq.Lideres);
        }
    }
}
