
namespace CBR_ADMIN
{
    partial class uscTrabajo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uscTrabajo));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblDatoTamaño = new System.Windows.Forms.Label();
            this.lblTamañoArchivo = new System.Windows.Forms.Label();
            this.lblTipoArchivo = new System.Windows.Forms.Label();
            this.lblNombreArchivo = new System.Windows.Forms.Label();
            this.lblDatoNombre = new System.Windows.Forms.Label();
            this.lblDatoTipo = new System.Windows.Forms.Label();
            this.lsbExplorador = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.btnIr = new System.Windows.Forms.Button();
            this.btnCasa = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.txtRuta = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lsbExplorador, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.46499F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.53501F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(857, 676);
            this.tableLayoutPanel1.TabIndex = 23;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.lblDatoTamaño);
            this.panel2.Controls.Add(this.lblTamañoArchivo);
            this.panel2.Controls.Add(this.lblTipoArchivo);
            this.panel2.Controls.Add(this.lblNombreArchivo);
            this.panel2.Controls.Add(this.lblDatoNombre);
            this.panel2.Controls.Add(this.lblDatoTipo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 608);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(851, 65);
            this.panel2.TabIndex = 23;
            // 
            // lblDatoTamaño
            // 
            this.lblDatoTamaño.AutoSize = true;
            this.lblDatoTamaño.Location = new System.Drawing.Point(784, 35);
            this.lblDatoTamaño.Name = "lblDatoTamaño";
            this.lblDatoTamaño.Size = new System.Drawing.Size(13, 13);
            this.lblDatoTamaño.TabIndex = 20;
            this.lblDatoTamaño.Text = "--";
            // 
            // lblTamañoArchivo
            // 
            this.lblTamañoArchivo.AutoSize = true;
            this.lblTamañoArchivo.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTamañoArchivo.Location = new System.Drawing.Point(725, 35);
            this.lblTamañoArchivo.Name = "lblTamañoArchivo";
            this.lblTamañoArchivo.Size = new System.Drawing.Size(50, 13);
            this.lblTamañoArchivo.TabIndex = 19;
            this.lblTamañoArchivo.Text = "Tamaño:";
            // 
            // lblTipoArchivo
            // 
            this.lblTipoArchivo.AutoSize = true;
            this.lblTipoArchivo.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoArchivo.Location = new System.Drawing.Point(725, 13);
            this.lblTipoArchivo.Name = "lblTipoArchivo";
            this.lblTipoArchivo.Size = new System.Drawing.Size(33, 13);
            this.lblTipoArchivo.TabIndex = 18;
            this.lblTipoArchivo.Text = "Tipo:";
            // 
            // lblNombreArchivo
            // 
            this.lblNombreArchivo.AutoSize = true;
            this.lblNombreArchivo.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreArchivo.Location = new System.Drawing.Point(20, 13);
            this.lblNombreArchivo.Name = "lblNombreArchivo";
            this.lblNombreArchivo.Size = new System.Drawing.Size(111, 13);
            this.lblNombreArchivo.TabIndex = 15;
            this.lblNombreArchivo.Text = "Nombre del archivo:";
            // 
            // lblDatoNombre
            // 
            this.lblDatoNombre.AutoSize = true;
            this.lblDatoNombre.Location = new System.Drawing.Point(136, 13);
            this.lblDatoNombre.Name = "lblDatoNombre";
            this.lblDatoNombre.Size = new System.Drawing.Size(13, 13);
            this.lblDatoNombre.TabIndex = 16;
            this.lblDatoNombre.Text = "--";
            // 
            // lblDatoTipo
            // 
            this.lblDatoTipo.AutoSize = true;
            this.lblDatoTipo.Location = new System.Drawing.Point(784, 13);
            this.lblDatoTipo.Name = "lblDatoTipo";
            this.lblDatoTipo.Size = new System.Drawing.Size(13, 13);
            this.lblDatoTipo.TabIndex = 17;
            this.lblDatoTipo.Text = "--";
            // 
            // lsbExplorador
            // 
            this.lsbExplorador.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsbExplorador.HideSelection = false;
            this.lsbExplorador.LargeImageList = this.imageList1;
            this.lsbExplorador.Location = new System.Drawing.Point(3, 78);
            this.lsbExplorador.Name = "lsbExplorador";
            this.lsbExplorador.Size = new System.Drawing.Size(851, 524);
            this.lsbExplorador.TabIndex = 20;
            this.lsbExplorador.UseCompatibleStateImageBehavior = false;
            this.lsbExplorador.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView1_ItemSelectionChanged);
            this.lsbExplorador.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "archivo.png");
            this.imageList1.Images.SetKeyName(1, "icons8-folder-64.png");
            this.imageList1.Images.SetKeyName(2, "doc.png");
            this.imageList1.Images.SetKeyName(3, "exe.png");
            this.imageList1.Images.SetKeyName(4, "pdf.png");
            this.imageList1.Images.SetKeyName(5, "xls.png");
            this.imageList1.Images.SetKeyName(6, "jpg.png");
            this.imageList1.Images.SetKeyName(7, "png.png");
            this.imageList1.Images.SetKeyName(8, "txt.png");
            this.imageList1.Images.SetKeyName(9, "RAR.png");
            this.imageList1.Images.SetKeyName(10, "ZIP.png");
            this.imageList1.Images.SetKeyName(11, "ppt.png");
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel3.BackgroundImage = global::CBR_ADMIN.Properties.Resources.BarraConSombraChica;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.btnIr);
            this.panel3.Controls.Add(this.btnCasa);
            this.panel3.Controls.Add(this.btnVolver);
            this.panel3.Controls.Add(this.txtRuta);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(857, 75);
            this.panel3.TabIndex = 24;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(325, 12);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(218, 17);
            this.label13.TabIndex = 60;
            this.label13.Text = "Formatos/Instrucciones de Trabajo";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnIr
            // 
            this.btnIr.AutoSize = true;
            this.btnIr.BackColor = System.Drawing.Color.Transparent;
            this.btnIr.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnIr.BackgroundImage")));
            this.btnIr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnIr.FlatAppearance.BorderSize = 0;
            this.btnIr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIr.Location = new System.Drawing.Point(731, 19);
            this.btnIr.Name = "btnIr";
            this.btnIr.Size = new System.Drawing.Size(45, 45);
            this.btnIr.TabIndex = 58;
            this.btnIr.UseVisualStyleBackColor = false;
            this.btnIr.Click += new System.EventHandler(this.btnIr_Click);
            // 
            // btnCasa
            // 
            this.btnCasa.AutoSize = true;
            this.btnCasa.BackColor = System.Drawing.Color.Transparent;
            this.btnCasa.BackgroundImage = global::CBR_ADMIN.Properties.Resources.icons8_home_48;
            this.btnCasa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCasa.FlatAppearance.BorderSize = 0;
            this.btnCasa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCasa.Location = new System.Drawing.Point(21, 19);
            this.btnCasa.Name = "btnCasa";
            this.btnCasa.Size = new System.Drawing.Size(45, 45);
            this.btnCasa.TabIndex = 57;
            this.btnCasa.UseVisualStyleBackColor = false;
            this.btnCasa.Click += new System.EventHandler(this.btnCasa_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.AutoSize = true;
            this.btnVolver.BackColor = System.Drawing.Color.Transparent;
            this.btnVolver.BackgroundImage = global::CBR_ADMIN.Properties.Resources.icons8_left_48;
            this.btnVolver.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnVolver.FlatAppearance.BorderSize = 0;
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.Location = new System.Drawing.Point(72, 19);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(45, 45);
            this.btnVolver.TabIndex = 56;
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // txtRuta
            // 
            this.txtRuta.Location = new System.Drawing.Point(143, 32);
            this.txtRuta.Name = "txtRuta";
            this.txtRuta.Size = new System.Drawing.Size(550, 20);
            this.txtRuta.TabIndex = 19;
            // 
            // uscTrabajo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "uscTrabajo";
            this.Size = new System.Drawing.Size(857, 676);
            this.Load += new System.EventHandler(this.uscTrabajo_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblDatoTamaño;
        private System.Windows.Forms.Label lblTamañoArchivo;
        private System.Windows.Forms.Label lblTipoArchivo;
        private System.Windows.Forms.Label lblNombreArchivo;
        private System.Windows.Forms.Label lblDatoNombre;
        private System.Windows.Forms.Label lblDatoTipo;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ListView lsbExplorador;
        private System.Windows.Forms.Button btnIr;
        private System.Windows.Forms.Button btnCasa;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.TextBox txtRuta;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ImageList imageList1;
    }
}
