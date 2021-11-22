using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using CBR_ADMIN.Sistema;

namespace CBR_ADMIN.IT.Tickets
{
    public partial class CierreTickets : UserControl
    {
        private static CierreTickets _instance;
        public static CierreTickets Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new CierreTickets();
                return _instance;
            }
        }
        public CierreTickets()
        {
            InitializeComponent();
        }
        string tickets;

        private void actualizar_Click(object sender, EventArgs e)
        {
            this.ticketsTableAdapter.Fill(cbr_Tikets.Tickets);
        }

        private void Estado_Click(object sender, EventArgs e)
        {
            this.ticketsTableAdapter.Actualiza(CB_Status.Text, Key_tick.Text);
         MessageBox.Show("Estado Actualizado");
        }

        private void CierreTickets_Load(object sender, EventArgs e)
        {
            ThreadStart proceso = new ThreadStart(MostrarCuadroInicio); Thread hilo = new Thread(proceso);
            hilo.Start();


            timer1.Enabled = true;
            this.ticketsTableAdapter.Fill(cbr_Tikets.Tickets); hilo.Abort();

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            fecha.Text = DateTime.Now.ToLongDateString();
            hora.Text = DateTime.Now.ToString("hh:mm:ss");



        }
        private void MostrarCuadroInicio()
        {
            Loading Cargando = new Loading();
            Cargando.ShowDialog();

        }
        private void DG_genera_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex > 0)
                {
                    tickets = Convert.ToString(DG_Tickets.Rows[e.RowIndex].Cells[0].FormattedValue.ToString());
                    tickets = DG_Tickets.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                    Key_tick.Text = tickets.ToString();

                }
                else
                {
                    tickets = "0";
                    Key_tick.Text = tickets.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }

        private void DG_genera_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex > 0)
                {
                    tickets = Convert.ToString(DG_Tickets.Rows[e.RowIndex].Cells[0].FormattedValue.ToString());
                    tickets = DG_Tickets.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                    Key_tick.Text = tickets.ToString();

                }
                else
                {
                    tickets = "0";
                    Key_tick.Text = tickets.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }

    }
}
