﻿using System;
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
    public partial class Notificacion1 : Form
    {
        public Notificacion1()
        {
            InitializeComponent();
        }

        private void Notificacion1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
        int cont = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1) this.Opacity += 0.05;
            cont += 1;
            if (cont == 1)
            {
                timer1.Stop();
                timer2.Start();

            }

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.Opacity -= 0.1;
            if (this.Opacity == 0)
            {
                timer1.Stop();
                this.Close();

            }
        }
    }
}