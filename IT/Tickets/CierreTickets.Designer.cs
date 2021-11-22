namespace CBR_ADMIN.IT.Tickets
{
    partial class CierreTickets
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CierreTickets));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.fecha = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.uwin = new System.Windows.Forms.Label();
            this.hora = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.principal = new System.Windows.Forms.Panel();
            this.Key_tick = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CB_Status = new System.Windows.Forms.ComboBox();
            this.actualizar = new System.Windows.Forms.Button();
            this.DG_Tickets = new System.Windows.Forms.DataGridView();
            this.ticketDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoriaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apellidoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.detalleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.administracionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prioridadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ticketsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cbr_Tikets = new CBR_ADMIN.Cbr_Tikets();
            this.Usuario = new System.Windows.Forms.Label();
            this.Estado = new System.Windows.Forms.Button();
            this.ticketsTableAdapter = new CBR_ADMIN.Cbr_TiketsTableAdapters.TicketsTableAdapter();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.principal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG_Tickets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ticketsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbr_Tikets)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.11814F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.88186F));
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.principal, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.491059F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.50894F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1122, 599);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(2, 2);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(108, 37);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.fecha);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(182, 2);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(938, 52);
            this.panel2.TabIndex = 2;
            // 
            // fecha
            // 
            this.fecha.AutoSize = true;
            this.fecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fecha.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.fecha.Location = new System.Drawing.Point(467, 15);
            this.fecha.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.fecha.Name = "fecha";
            this.fecha.Size = new System.Drawing.Size(21, 20);
            this.fecha.TabIndex = 1;
            this.fecha.Text = "--";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(70, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(314, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Plataforma de soluciones informaticas";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.uwin);
            this.panel3.Controls.Add(this.hora);
            this.panel3.Controls.Add(this.label31);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(2, 58);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(176, 539);
            this.panel3.TabIndex = 3;
            // 
            // uwin
            // 
            this.uwin.AutoSize = true;
            this.uwin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uwin.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.uwin.Location = new System.Drawing.Point(2, 505);
            this.uwin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.uwin.Name = "uwin";
            this.uwin.Size = new System.Drawing.Size(20, 17);
            this.uwin.TabIndex = 30;
            this.uwin.Text = "--";
            // 
            // hora
            // 
            this.hora.AutoSize = true;
            this.hora.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hora.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.hora.Location = new System.Drawing.Point(46, 7);
            this.hora.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.hora.Name = "hora";
            this.hora.Size = new System.Drawing.Size(21, 20);
            this.hora.TabIndex = 1;
            this.hora.Text = "--";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label31.Location = new System.Drawing.Point(0, 461);
            this.label31.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(146, 18);
            this.label31.TabIndex = 29;
            this.label31.Text = "Usuario Windows:";
            // 
            // principal
            // 
            this.principal.AutoScroll = true;
            this.principal.AutoSize = true;
            this.principal.Controls.Add(this.Key_tick);
            this.principal.Controls.Add(this.label3);
            this.principal.Controls.Add(this.label2);
            this.principal.Controls.Add(this.CB_Status);
            this.principal.Controls.Add(this.actualizar);
            this.principal.Controls.Add(this.DG_Tickets);
            this.principal.Controls.Add(this.Usuario);
            this.principal.Controls.Add(this.Estado);
            this.principal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.principal.Location = new System.Drawing.Point(182, 58);
            this.principal.Margin = new System.Windows.Forms.Padding(2);
            this.principal.Name = "principal";
            this.principal.Size = new System.Drawing.Size(938, 539);
            this.principal.TabIndex = 4;
            // 
            // Key_tick
            // 
            this.Key_tick.AutoSize = true;
            this.Key_tick.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Key_tick.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.Key_tick.Location = new System.Drawing.Point(843, 350);
            this.Key_tick.Name = "Key_tick";
            this.Key_tick.Size = new System.Drawing.Size(14, 20);
            this.Key_tick.TabIndex = 49;
            this.Key_tick.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(826, 315);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 20);
            this.label3.TabIndex = 40;
            this.label3.Text = "N° Ticket";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(522, 280);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 20);
            this.label2.TabIndex = 39;
            this.label2.Text = "Status";
            // 
            // CB_Status
            // 
            this.CB_Status.FormattingEnabled = true;
            this.CB_Status.Items.AddRange(new object[] {
            "Iniciada",
            "Cerrada"});
            this.CB_Status.Location = new System.Drawing.Point(501, 302);
            this.CB_Status.Name = "CB_Status";
            this.CB_Status.Size = new System.Drawing.Size(132, 21);
            this.CB_Status.TabIndex = 38;
            // 
            // actualizar
            // 
            this.actualizar.BackColor = System.Drawing.Color.SlateGray;
            this.actualizar.FlatAppearance.BorderSize = 0;
            this.actualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.actualizar.Location = new System.Drawing.Point(268, 350);
            this.actualizar.Margin = new System.Windows.Forms.Padding(2);
            this.actualizar.Name = "actualizar";
            this.actualizar.Size = new System.Drawing.Size(177, 47);
            this.actualizar.TabIndex = 37;
            this.actualizar.Text = "Actualizar Tabla";
            this.actualizar.UseVisualStyleBackColor = false;
            this.actualizar.Click += new System.EventHandler(this.actualizar_Click);
            // 
            // DG_Tickets
            // 
            this.DG_Tickets.AutoGenerateColumns = false;
            this.DG_Tickets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG_Tickets.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ticketDataGridViewTextBoxColumn,
            this.categoriaDataGridViewTextBoxColumn,
            this.nombreDataGridViewTextBoxColumn,
            this.apellidoDataGridViewTextBoxColumn,
            this.detalleDataGridViewTextBoxColumn,
            this.administracionDataGridViewTextBoxColumn,
            this.prioridadDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn});
            this.DG_Tickets.DataSource = this.ticketsBindingSource;
            this.DG_Tickets.Location = new System.Drawing.Point(0, 0);
            this.DG_Tickets.Name = "DG_Tickets";
            this.DG_Tickets.Size = new System.Drawing.Size(934, 263);
            this.DG_Tickets.TabIndex = 36;
            this.DG_Tickets.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_genera_CellClick);
            this.DG_Tickets.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_genera_CellValueChanged);
            // 
            // ticketDataGridViewTextBoxColumn
            // 
            this.ticketDataGridViewTextBoxColumn.DataPropertyName = "Ticket";
            this.ticketDataGridViewTextBoxColumn.HeaderText = "Ticket";
            this.ticketDataGridViewTextBoxColumn.Name = "ticketDataGridViewTextBoxColumn";
            // 
            // categoriaDataGridViewTextBoxColumn
            // 
            this.categoriaDataGridViewTextBoxColumn.DataPropertyName = "Categoria";
            this.categoriaDataGridViewTextBoxColumn.HeaderText = "Categoria";
            this.categoriaDataGridViewTextBoxColumn.Name = "categoriaDataGridViewTextBoxColumn";
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            this.nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
            this.nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            // 
            // apellidoDataGridViewTextBoxColumn
            // 
            this.apellidoDataGridViewTextBoxColumn.DataPropertyName = "Apellido";
            this.apellidoDataGridViewTextBoxColumn.HeaderText = "Apellido";
            this.apellidoDataGridViewTextBoxColumn.Name = "apellidoDataGridViewTextBoxColumn";
            // 
            // detalleDataGridViewTextBoxColumn
            // 
            this.detalleDataGridViewTextBoxColumn.DataPropertyName = "Detalle";
            this.detalleDataGridViewTextBoxColumn.HeaderText = "Detalle";
            this.detalleDataGridViewTextBoxColumn.Name = "detalleDataGridViewTextBoxColumn";
            // 
            // administracionDataGridViewTextBoxColumn
            // 
            this.administracionDataGridViewTextBoxColumn.DataPropertyName = "Administracion";
            this.administracionDataGridViewTextBoxColumn.HeaderText = "Administracion";
            this.administracionDataGridViewTextBoxColumn.Name = "administracionDataGridViewTextBoxColumn";
            // 
            // prioridadDataGridViewTextBoxColumn
            // 
            this.prioridadDataGridViewTextBoxColumn.DataPropertyName = "Prioridad";
            this.prioridadDataGridViewTextBoxColumn.HeaderText = "Prioridad";
            this.prioridadDataGridViewTextBoxColumn.Name = "prioridadDataGridViewTextBoxColumn";
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            this.statusDataGridViewTextBoxColumn.HeaderText = "Status";
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            // 
            // ticketsBindingSource
            // 
            this.ticketsBindingSource.DataMember = "Tickets";
            this.ticketsBindingSource.DataSource = this.cbr_Tikets;
            // 
            // cbr_Tikets
            // 
            this.cbr_Tikets.DataSetName = "Cbr_Tikets";
            this.cbr_Tikets.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.cbr_Tikets.Initialized += new System.EventHandler(this.timer1_Tick);
            // 
            // Usuario
            // 
            this.Usuario.AutoSize = true;
            this.Usuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Usuario.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Usuario.Location = new System.Drawing.Point(623, 486);
            this.Usuario.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Usuario.Name = "Usuario";
            this.Usuario.Size = new System.Drawing.Size(20, 17);
            this.Usuario.TabIndex = 35;
            this.Usuario.Text = "--";
            // 
            // Estado
            // 
            this.Estado.BackColor = System.Drawing.Color.SlateGray;
            this.Estado.FlatAppearance.BorderSize = 0;
            this.Estado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Estado.Location = new System.Drawing.Point(478, 350);
            this.Estado.Margin = new System.Windows.Forms.Padding(2);
            this.Estado.Name = "Estado";
            this.Estado.Size = new System.Drawing.Size(177, 47);
            this.Estado.TabIndex = 10;
            this.Estado.Text = "Actualizar Estado";
            this.Estado.UseVisualStyleBackColor = false;
            this.Estado.Click += new System.EventHandler(this.Estado_Click);
            // 
            // ticketsTableAdapter
            // 
            this.ticketsTableAdapter.ClearBeforeFill = true;
            // 
            // CierreTickets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "CierreTickets";
            this.Size = new System.Drawing.Size(1122, 599);
            this.Load += new System.EventHandler(this.CierreTickets_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.principal.ResumeLayout(false);
            this.principal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG_Tickets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ticketsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbr_Tikets)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label fecha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label uwin;
        private System.Windows.Forms.Label hora;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Panel principal;
        private System.Windows.Forms.Label Usuario;
        private System.Windows.Forms.Button Estado;
        private System.Windows.Forms.Button actualizar;
        private System.Windows.Forms.DataGridView DG_Tickets;
        private System.Windows.Forms.DataGridViewTextBoxColumn ticketDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoriaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellidoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn detalleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn administracionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prioridadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource ticketsBindingSource;
        private Cbr_Tikets cbr_Tikets;
        private Cbr_TiketsTableAdapters.TicketsTableAdapter ticketsTableAdapter;
        private System.Windows.Forms.ComboBox CB_Status;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Key_tick;
        private System.Windows.Forms.Timer timer1;
    }
}
