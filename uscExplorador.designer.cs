
namespace CBR_ADMIN
{
    partial class uscExplorador
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

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uscExplorador));
            this.lsbExplorador = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.txtRuta = new System.Windows.Forms.TextBox();
            this.lblTipoArchivo = new System.Windows.Forms.Label();
            this.lblDatoTipo = new System.Windows.Forms.Label();
            this.lblDatoNombre = new System.Windows.Forms.Label();
            this.lblNombreArchivo = new System.Windows.Forms.Label();
            this.btnIr = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblDatoTamaño = new System.Windows.Forms.Label();
            this.lblTamañoArchivo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.btnCasa = new System.Windows.Forms.Button();
            this.Ano = new System.Windows.Forms.ComboBox();
            this.panel11 = new System.Windows.Forms.Panel();
            this.label24 = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.Proyecto = new System.Windows.Forms.ComboBox();
            this.panel10 = new System.Windows.Forms.Panel();
            this.label19 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.proye_solicita = new System.Windows.Forms.ComboBox();
            this.button7 = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.carpeta = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.folio_Proyectos = new CBR_ADMIN.Folio_Proyectos();
            this.folioProyectosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.folio_ProyectosTableAdapter = new CBR_ADMIN.Folio_ProyectosTableAdapters.Folio_ProyectosTableAdapter();
            this.pictureBox3 = new System.Windows.Forms.Button();
            this.registro_acceso = new CBR_ADMIN.Registro_acceso();
            this.registroAccesosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.registro_AccesosTableAdapter = new CBR_ADMIN.Registro_accesoTableAdapters.Registro_AccesosTableAdapter();
            this.registro_usuarios_monitor = new CBR_ADMIN.Registro_usuarios_monitor();
            this.registroAccesosmonitorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.registro_Accesos_monitorTableAdapter = new CBR_ADMIN.Registro_usuarios_monitorTableAdapters.Registro_Accesos_monitorTableAdapter();
            this.label4 = new System.Windows.Forms.Label();
            this.tipo2 = new System.Windows.Forms.ComboBox();
            this.Depa = new System.Windows.Forms.ComboBox();
            this.label52 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.folio_Proyectos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.folioProyectosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.registro_acceso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.registroAccesosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.registro_usuarios_monitor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.registroAccesosmonitorBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lsbExplorador
            // 
            this.lsbExplorador.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsbExplorador.HideSelection = false;
            this.lsbExplorador.LargeImageList = this.imageList1;
            this.lsbExplorador.Location = new System.Drawing.Point(3, 175);
            this.lsbExplorador.Name = "lsbExplorador";
            this.lsbExplorador.Size = new System.Drawing.Size(851, 362);
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
            // txtRuta
            // 
            this.txtRuta.Location = new System.Drawing.Point(49, 5);
            this.txtRuta.Name = "txtRuta";
            this.txtRuta.Size = new System.Drawing.Size(380, 20);
            this.txtRuta.TabIndex = 19;
            // 
            // lblTipoArchivo
            // 
            this.lblTipoArchivo.AutoSize = true;
            this.lblTipoArchivo.Location = new System.Drawing.Point(725, 13);
            this.lblTipoArchivo.Name = "lblTipoArchivo";
            this.lblTipoArchivo.Size = new System.Drawing.Size(31, 13);
            this.lblTipoArchivo.TabIndex = 18;
            this.lblTipoArchivo.Text = "Tipo:";
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
            // lblDatoNombre
            // 
            this.lblDatoNombre.AutoSize = true;
            this.lblDatoNombre.Location = new System.Drawing.Point(136, 13);
            this.lblDatoNombre.Name = "lblDatoNombre";
            this.lblDatoNombre.Size = new System.Drawing.Size(13, 13);
            this.lblDatoNombre.TabIndex = 16;
            this.lblDatoNombre.Text = "--";
            // 
            // lblNombreArchivo
            // 
            this.lblNombreArchivo.AutoSize = true;
            this.lblNombreArchivo.Location = new System.Drawing.Point(28, 13);
            this.lblNombreArchivo.Name = "lblNombreArchivo";
            this.lblNombreArchivo.Size = new System.Drawing.Size(102, 13);
            this.lblNombreArchivo.TabIndex = 15;
            this.lblNombreArchivo.Text = "Nombre del archivo:";
            // 
            // btnIr
            // 
            this.btnIr.Location = new System.Drawing.Point(460, 4);
            this.btnIr.Name = "btnIr";
            this.btnIr.Size = new System.Drawing.Size(75, 23);
            this.btnIr.TabIndex = 14;
            this.btnIr.Text = "Ir";
            this.btnIr.UseVisualStyleBackColor = true;
            this.btnIr.Click += new System.EventHandler(this.btnIr_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lsbExplorador, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.473373F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 54.43787F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(857, 676);
            this.tableLayoutPanel1.TabIndex = 22;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
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
            this.panel2.Location = new System.Drawing.Point(3, 543);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(851, 130);
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
            this.lblTamañoArchivo.Location = new System.Drawing.Point(725, 35);
            this.lblTamañoArchivo.Name = "lblTamañoArchivo";
            this.lblTamañoArchivo.Size = new System.Drawing.Size(49, 13);
            this.lblTamañoArchivo.TabIndex = 19;
            this.lblTamañoArchivo.Text = "Tamaño:";
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::CBR_ADMIN.Properties.Resources.BarraConSombraChica;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.Depa);
            this.panel1.Controls.Add(this.label52);
            this.panel1.Controls.Add(this.tipo2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label25);
            this.panel1.Controls.Add(this.btnCasa);
            this.panel1.Controls.Add(this.Ano);
            this.panel1.Controls.Add(this.panel11);
            this.panel1.Controls.Add(this.label24);
            this.panel1.Controls.Add(this.btnVolver);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.Proyecto);
            this.panel1.Controls.Add(this.panel10);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.proye_solicita);
            this.panel1.Controls.Add(this.button7);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.carpeta);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(10, 5);
            this.panel1.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(837, 125);
            this.panel1.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(113, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 17);
            this.label3.TabIndex = 78;
            this.label3.Text = "Atrás";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(46, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 17);
            this.label2.TabIndex = 77;
            this.label2.Text = "Raíz";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(418, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 34);
            this.label1.TabIndex = 76;
            this.label1.Text = "Enviar\r\nSolicitud\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(549, 45);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(34, 17);
            this.label25.TabIndex = 74;
            this.label25.Text = "Año:";
            // 
            // btnCasa
            // 
            this.btnCasa.BackgroundImage = global::CBR_ADMIN.Properties.Resources.icons8_home_48;
            this.btnCasa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCasa.FlatAppearance.BorderSize = 0;
            this.btnCasa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCasa.Location = new System.Drawing.Point(39, 24);
            this.btnCasa.Name = "btnCasa";
            this.btnCasa.Size = new System.Drawing.Size(45, 45);
            this.btnCasa.TabIndex = 56;
            this.btnCasa.UseVisualStyleBackColor = true;
            this.btnCasa.Click += new System.EventHandler(this.btnCasa_Click);
            // 
            // Ano
            // 
            this.Ano.DataSource = this.folioProyectosBindingSource;
            this.Ano.DisplayMember = "Ano";
            this.Ano.FormattingEnabled = true;
            this.Ano.Location = new System.Drawing.Point(596, 43);
            this.Ano.Name = "Ano";
            this.Ano.Size = new System.Drawing.Size(121, 21);
            this.Ano.TabIndex = 75;
            this.Ano.ValueMember = "Ano";
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.LightGray;
            this.panel11.Location = new System.Drawing.Point(179, 18);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(1, 100);
            this.panel11.TabIndex = 57;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(521, 18);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(62, 17);
            this.label24.TabIndex = 72;
            this.label24.Text = "Proyecto:";
            // 
            // btnVolver
            // 
            this.btnVolver.BackgroundImage = global::CBR_ADMIN.Properties.Resources.icons8_left_48;
            this.btnVolver.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnVolver.FlatAppearance.BorderSize = 0;
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.Location = new System.Drawing.Point(109, 24);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(45, 45);
            this.btnVolver.TabIndex = 55;
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(57, 98);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 17);
            this.label13.TabIndex = 59;
            this.label13.Text = "Navegación";
            // 
            // Proyecto
            // 
            this.Proyecto.DataSource = this.folioProyectosBindingSource;
            this.Proyecto.DisplayMember = "Nombre2";
            this.Proyecto.FormattingEnabled = true;
            this.Proyecto.Location = new System.Drawing.Point(596, 16);
            this.Proyecto.Name = "Proyecto";
            this.Proyecto.Size = new System.Drawing.Size(121, 21);
            this.Proyecto.TabIndex = 73;
            this.Proyecto.ValueMember = "Nombre";
            this.Proyecto.SelectedIndexChanged += new System.EventHandler(this.buscador_SelectedIndexChanged);
            this.Proyecto.Click += new System.EventHandler(this.buscador_Click);
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.LightGray;
            this.panel10.Location = new System.Drawing.Point(496, 18);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(1, 100);
            this.panel10.TabIndex = 61;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(762, 52);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(42, 17);
            this.label19.TabIndex = 71;
            this.label19.Text = "Índice";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(269, 98);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(133, 17);
            this.label14.TabIndex = 62;
            this.label14.Text = "Solicitar Actualización";
            // 
            // proye_solicita
            // 
            this.proye_solicita.DataSource = this.folioProyectosBindingSource;
            this.proye_solicita.DisplayMember = "Nombre2";
            this.proye_solicita.FormattingEnabled = true;
            this.proye_solicita.Location = new System.Drawing.Point(272, 3);
            this.proye_solicita.Name = "proye_solicita";
            this.proye_solicita.Size = new System.Drawing.Size(121, 21);
            this.proye_solicita.TabIndex = 63;
            this.proye_solicita.ValueMember = "Nombre2";
            // 
            // button7
            // 
            this.button7.BackgroundImage = global::CBR_ADMIN.Properties.Resources.icons8_scroll_48;
            this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Location = new System.Drawing.Point(759, 3);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(45, 45);
            this.button7.TabIndex = 70;
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(197, 5);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(62, 17);
            this.label15.TabIndex = 60;
            this.label15.Text = "Proyecto:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(616, 98);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(101, 17);
            this.label18.TabIndex = 69;
            this.label18.Text = "Buscar Proyecto";
            // 
            // button6
            // 
            this.button6.BackgroundImage = global::CBR_ADMIN.Properties.Resources.icons8_ok_48;
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Location = new System.Drawing.Point(424, 18);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(45, 45);
            this.button6.TabIndex = 68;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(197, 64);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(57, 17);
            this.label17.TabIndex = 65;
            this.label17.Text = "Carpeta:";
            // 
            // carpeta
            // 
            this.carpeta.FormattingEnabled = true;
            this.carpeta.Location = new System.Drawing.Point(272, 62);
            this.carpeta.Name = "carpeta";
            this.carpeta.Size = new System.Drawing.Size(121, 21);
            this.carpeta.TabIndex = 66;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnIr);
            this.panel3.Controls.Add(this.txtRuta);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 135);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(857, 37);
            this.panel3.TabIndex = 24;
            // 
            // folio_Proyectos
            // 
            this.folio_Proyectos.DataSetName = "Folio_Proyectos";
            this.folio_Proyectos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // folioProyectosBindingSource
            // 
            this.folioProyectosBindingSource.DataMember = "Folio_Proyectos";
            this.folioProyectosBindingSource.DataSource = this.folio_Proyectos;
            // 
            // folio_ProyectosTableAdapter
            // 
            this.folio_ProyectosTableAdapter.ClearBeforeFill = true;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.FlatAppearance.BorderSize = 0;
            this.pictureBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pictureBox3.Location = new System.Drawing.Point(763, 73);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(27, 27);
            this.pictureBox3.TabIndex = 90;
            this.pictureBox3.UseVisualStyleBackColor = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // registro_acceso
            // 
            this.registro_acceso.DataSetName = "Registro_acceso";
            this.registro_acceso.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // registroAccesosBindingSource
            // 
            this.registroAccesosBindingSource.DataMember = "Registro_Accesos";
            this.registroAccesosBindingSource.DataSource = this.registro_acceso;
            // 
            // registro_AccesosTableAdapter
            // 
            this.registro_AccesosTableAdapter.ClearBeforeFill = true;
            // 
            // registro_usuarios_monitor
            // 
            this.registro_usuarios_monitor.DataSetName = "Registro_usuarios_monitor";
            this.registro_usuarios_monitor.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // registroAccesosmonitorBindingSource
            // 
            this.registroAccesosmonitorBindingSource.DataMember = "Registro_Accesos_monitor";
            this.registroAccesosmonitorBindingSource.DataSource = this.registro_usuarios_monitor;
            // 
            // registro_Accesos_monitorTableAdapter
            // 
            this.registro_Accesos_monitorTableAdapter.ClearBeforeFill = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(549, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 17);
            this.label4.TabIndex = 91;
            this.label4.Text = "Tipo:";
            // 
            // tipo2
            // 
            this.tipo2.DataSource = this.folioProyectosBindingSource;
            this.tipo2.DisplayMember = "tipo2";
            this.tipo2.Enabled = false;
            this.tipo2.FormattingEnabled = true;
            this.tipo2.Location = new System.Drawing.Point(596, 77);
            this.tipo2.Name = "tipo2";
            this.tipo2.Size = new System.Drawing.Size(121, 21);
            this.tipo2.TabIndex = 93;
            this.tipo2.ValueMember = "tipo2";
            // 
            // Depa
            // 
            this.Depa.BackColor = System.Drawing.Color.White;
            this.Depa.DisplayMember = "Departamento";
            this.Depa.FormattingEnabled = true;
            this.Depa.Location = new System.Drawing.Point(272, 37);
            this.Depa.Name = "Depa";
            this.Depa.Size = new System.Drawing.Size(121, 21);
            this.Depa.TabIndex = 111;
            this.Depa.ValueMember = "Departamento";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.BackColor = System.Drawing.Color.Transparent;
            this.label52.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label52.Location = new System.Drawing.Point(182, 38);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(84, 13);
            this.label52.TabIndex = 110;
            this.label52.Text = "Departamento:";
            // 
            // uscExplorador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "uscExplorador";
            this.Size = new System.Drawing.Size(857, 676);
            this.Load += new System.EventHandler(this.Explorador_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.folio_Proyectos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.folioProyectosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.registro_acceso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.registroAccesosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.registro_usuarios_monitor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.registroAccesosmonitorBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

            
        private System.Windows.Forms.ListView lsbExplorador;
        private System.Windows.Forms.TextBox txtRuta;
        private System.Windows.Forms.Label lblTipoArchivo;
        private System.Windows.Forms.Label lblDatoTipo;
        private System.Windows.Forms.Label lblDatoNombre;
        private System.Windows.Forms.Label lblNombreArchivo;
        private System.Windows.Forms.Button btnIr;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDatoTamaño;
        private System.Windows.Forms.Label lblTamañoArchivo;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Button btnCasa;
        private System.Windows.Forms.ComboBox Ano;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox Proyecto;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox proye_solicita;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox carpeta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.BindingSource folioProyectosBindingSource;
        private Folio_Proyectos folio_Proyectos;
        private Folio_ProyectosTableAdapters.Folio_ProyectosTableAdapter folio_ProyectosTableAdapter;
        private System.Windows.Forms.Button pictureBox3;
        private System.Windows.Forms.BindingSource registroAccesosBindingSource;
        private Registro_acceso registro_acceso;
        private Registro_accesoTableAdapters.Registro_AccesosTableAdapter registro_AccesosTableAdapter;
        private System.Windows.Forms.BindingSource registroAccesosmonitorBindingSource;
        private Registro_usuarios_monitor registro_usuarios_monitor;
        private Registro_usuarios_monitorTableAdapters.Registro_Accesos_monitorTableAdapter registro_Accesos_monitorTableAdapter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox tipo2;
        private System.Windows.Forms.ComboBox Depa;
        private System.Windows.Forms.Label label52;
    }
}
