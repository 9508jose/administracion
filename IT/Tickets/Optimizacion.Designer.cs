namespace CBR_ADMIN.IT
{
    partial class Optimizacion
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.uwin = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.principal = new System.Windows.Forms.Panel();
            this.label30 = new System.Windows.Forms.Label();
            this.Usuario = new System.Windows.Forms.Label();
            this.Generar = new System.Windows.Forms.Button();
            this.Detalles = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbr_Tikets = new CBR_ADMIN.Cbr_Tikets();
            this.ticketsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ticketsTableAdapter = new CBR_ADMIN.Cbr_TiketsTableAdapters.TicketsTableAdapter();
            this.tikets_Fecha = new CBR_ADMIN.Tikets_Fecha();
            this.tiketsfechaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tikets_fechaTableAdapter = new CBR_ADMIN.Tikets_FechaTableAdapters.Tikets_fechaTableAdapter();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.principal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbr_Tikets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ticketsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tikets_Fecha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tiketsfechaBindingSource)).BeginInit();
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(865, 561);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(141, 2);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(722, 49);
            this.panel2.TabIndex = 2;
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
            this.panel3.Controls.Add(this.label31);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(2, 55);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(135, 504);
            this.panel3.TabIndex = 3;
            // 
            // uwin
            // 
            this.uwin.AutoSize = true;
            this.uwin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uwin.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.uwin.Location = new System.Drawing.Point(2, 490);
            this.uwin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.uwin.Name = "uwin";
            this.uwin.Size = new System.Drawing.Size(20, 17);
            this.uwin.TabIndex = 30;
            this.uwin.Text = "--";
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
            this.principal.Controls.Add(this.label30);
            this.principal.Controls.Add(this.Usuario);
            this.principal.Controls.Add(this.Generar);
            this.principal.Controls.Add(this.Detalles);
            this.principal.Controls.Add(this.label4);
            this.principal.Controls.Add(this.label2);
            this.principal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.principal.Location = new System.Drawing.Point(141, 55);
            this.principal.Margin = new System.Windows.Forms.Padding(2);
            this.principal.Name = "principal";
            this.principal.Size = new System.Drawing.Size(722, 504);
            this.principal.TabIndex = 4;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label30.Location = new System.Drawing.Point(444, 461);
            this.label30.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(102, 20);
            this.label30.TabIndex = 38;
            this.label30.Text = "Bienvenido:";
            // 
            // Usuario
            // 
            this.Usuario.AutoSize = true;
            this.Usuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Usuario.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Usuario.Location = new System.Drawing.Point(553, 465);
            this.Usuario.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Usuario.Name = "Usuario";
            this.Usuario.Size = new System.Drawing.Size(20, 17);
            this.Usuario.TabIndex = 37;
            this.Usuario.Text = "--";
            // 
            // Generar
            // 
            this.Generar.BackColor = System.Drawing.Color.SlateGray;
            this.Generar.FlatAppearance.BorderSize = 0;
            this.Generar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Generar.Location = new System.Drawing.Point(238, 358);
            this.Generar.Margin = new System.Windows.Forms.Padding(2);
            this.Generar.Name = "Generar";
            this.Generar.Size = new System.Drawing.Size(177, 47);
            this.Generar.TabIndex = 6;
            this.Generar.Text = "Generar Tiket";
            this.Generar.UseVisualStyleBackColor = false;
            this.Generar.Click += new System.EventHandler(this.Generar_Click);
            // 
            // Detalles
            // 
            this.Detalles.BackColor = System.Drawing.SystemColors.GrayText;
            this.Detalles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Detalles.Location = new System.Drawing.Point(186, 214);
            this.Detalles.Margin = new System.Windows.Forms.Padding(2);
            this.Detalles.Name = "Detalles";
            this.Detalles.Size = new System.Drawing.Size(273, 133);
            this.Detalles.TabIndex = 5;
            this.Detalles.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(2, 122);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(413, 30);
            this.label4.TabIndex = 3;
            this.label4.Text = "Se levantara tiket para el mantenimiento a su \r\nequipo favor de indicar los probl" +
    "emas de lentitud que presenta:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(260, 24);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Optimizacion";
            // 
            // cbr_Tikets
            // 
            this.cbr_Tikets.DataSetName = "Cbr_Tikets";
            this.cbr_Tikets.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ticketsBindingSource
            // 
            this.ticketsBindingSource.DataMember = "Tickets";
            this.ticketsBindingSource.DataSource = this.cbr_Tikets;
            // 
            // ticketsTableAdapter
            // 
            this.ticketsTableAdapter.ClearBeforeFill = true;
            // 
            // tikets_Fecha
            // 
            this.tikets_Fecha.DataSetName = "Tikets_Fecha";
            this.tikets_Fecha.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tiketsfechaBindingSource
            // 
            this.tiketsfechaBindingSource.DataMember = "Tikets_fecha";
            this.tiketsfechaBindingSource.DataSource = this.tikets_Fecha;
            // 
            // tikets_fechaTableAdapter
            // 
            this.tikets_fechaTableAdapter.ClearBeforeFill = true;
            // 
            // Optimizacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Optimizacion";
            this.Size = new System.Drawing.Size(865, 561);
            this.Load += new System.EventHandler(this.Optmizacion_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.principal.ResumeLayout(false);
            this.principal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbr_Tikets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ticketsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tikets_Fecha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tiketsfechaBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label uwin;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Panel principal;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label Usuario;
        private System.Windows.Forms.Button Generar;
        private System.Windows.Forms.RichTextBox Detalles;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private Cbr_Tikets cbr_Tikets;
        private System.Windows.Forms.BindingSource ticketsBindingSource;
        private Cbr_TiketsTableAdapters.TicketsTableAdapter ticketsTableAdapter;
        private Tikets_Fecha tikets_Fecha;
        private System.Windows.Forms.BindingSource tiketsfechaBindingSource;
        private Tikets_FechaTableAdapters.Tikets_fechaTableAdapter tikets_fechaTableAdapter;
    }
}
