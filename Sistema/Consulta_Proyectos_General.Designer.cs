
namespace CBR_ADMIN.Sistema
{
    partial class Consulta_Proyectos_General
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.advancedDataGridView1 = new Zuby.ADGV.AdvancedDataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nOPROYECTOFOLIODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rAZONSOCIALOCLIENTEEMPRESADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nOMBREDELPROYECTOOOBRADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dESCRIPCIONOALCANCEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cAPACIDADDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uBICACIÓNESTADODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.folioProyectosGeneralBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.folio_general = new CBR_ADMIN.Folio_general();
            this.folio_Proyectos_GeneralTableAdapter = new CBR_ADMIN.Folio_generalTableAdapters.Folio_Proyectos_GeneralTableAdapter();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Clave = new System.Windows.Forms.TextBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.folioProyectosGeneralBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.folio_general)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // advancedDataGridView1
            // 
            this.advancedDataGridView1.AutoGenerateColumns = false;
            this.advancedDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advancedDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.nOPROYECTOFOLIODataGridViewTextBoxColumn,
            this.rAZONSOCIALOCLIENTEEMPRESADataGridViewTextBoxColumn,
            this.nOMBREDELPROYECTOOOBRADataGridViewTextBoxColumn,
            this.dESCRIPCIONOALCANCEDataGridViewTextBoxColumn,
            this.cAPACIDADDataGridViewTextBoxColumn,
            this.uBICACIÓNESTADODataGridViewTextBoxColumn});
            this.advancedDataGridView1.DataSource = this.folioProyectosGeneralBindingSource;
            this.advancedDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advancedDataGridView1.FilterAndSortEnabled = true;
            this.advancedDataGridView1.Location = new System.Drawing.Point(3, 132);
            this.advancedDataGridView1.Name = "advancedDataGridView1";
            this.advancedDataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.advancedDataGridView1.RowHeadersWidth = 51;
            this.advancedDataGridView1.Size = new System.Drawing.Size(887, 378);
            this.advancedDataGridView1.TabIndex = 0;
            this.advancedDataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.advancedDataGridView1_CellDoubleClick);
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.iDDataGridViewTextBoxColumn.Width = 125;
            // 
            // nOPROYECTOFOLIODataGridViewTextBoxColumn
            // 
            this.nOPROYECTOFOLIODataGridViewTextBoxColumn.DataPropertyName = "NO PROYECTO FOLIO";
            this.nOPROYECTOFOLIODataGridViewTextBoxColumn.HeaderText = "NO PROYECTO FOLIO";
            this.nOPROYECTOFOLIODataGridViewTextBoxColumn.MinimumWidth = 22;
            this.nOPROYECTOFOLIODataGridViewTextBoxColumn.Name = "nOPROYECTOFOLIODataGridViewTextBoxColumn";
            this.nOPROYECTOFOLIODataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.nOPROYECTOFOLIODataGridViewTextBoxColumn.Width = 125;
            // 
            // rAZONSOCIALOCLIENTEEMPRESADataGridViewTextBoxColumn
            // 
            this.rAZONSOCIALOCLIENTEEMPRESADataGridViewTextBoxColumn.DataPropertyName = "RAZON SOCIAL O CLIENTE (EMPRESA)";
            this.rAZONSOCIALOCLIENTEEMPRESADataGridViewTextBoxColumn.HeaderText = "RAZON SOCIAL O CLIENTE (EMPRESA)";
            this.rAZONSOCIALOCLIENTEEMPRESADataGridViewTextBoxColumn.MinimumWidth = 22;
            this.rAZONSOCIALOCLIENTEEMPRESADataGridViewTextBoxColumn.Name = "rAZONSOCIALOCLIENTEEMPRESADataGridViewTextBoxColumn";
            this.rAZONSOCIALOCLIENTEEMPRESADataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.rAZONSOCIALOCLIENTEEMPRESADataGridViewTextBoxColumn.Width = 125;
            // 
            // nOMBREDELPROYECTOOOBRADataGridViewTextBoxColumn
            // 
            this.nOMBREDELPROYECTOOOBRADataGridViewTextBoxColumn.DataPropertyName = "NOMBRE DEL PROYECTO O OBRA";
            this.nOMBREDELPROYECTOOOBRADataGridViewTextBoxColumn.HeaderText = "NOMBRE DEL PROYECTO O OBRA";
            this.nOMBREDELPROYECTOOOBRADataGridViewTextBoxColumn.MinimumWidth = 22;
            this.nOMBREDELPROYECTOOOBRADataGridViewTextBoxColumn.Name = "nOMBREDELPROYECTOOOBRADataGridViewTextBoxColumn";
            this.nOMBREDELPROYECTOOOBRADataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.nOMBREDELPROYECTOOOBRADataGridViewTextBoxColumn.Width = 125;
            // 
            // dESCRIPCIONOALCANCEDataGridViewTextBoxColumn
            // 
            this.dESCRIPCIONOALCANCEDataGridViewTextBoxColumn.DataPropertyName = "DESCRIPCION O ALCANCE";
            this.dESCRIPCIONOALCANCEDataGridViewTextBoxColumn.HeaderText = "DESCRIPCION O ALCANCE";
            this.dESCRIPCIONOALCANCEDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.dESCRIPCIONOALCANCEDataGridViewTextBoxColumn.Name = "dESCRIPCIONOALCANCEDataGridViewTextBoxColumn";
            this.dESCRIPCIONOALCANCEDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dESCRIPCIONOALCANCEDataGridViewTextBoxColumn.Width = 125;
            // 
            // cAPACIDADDataGridViewTextBoxColumn
            // 
            this.cAPACIDADDataGridViewTextBoxColumn.DataPropertyName = "CAPACIDAD";
            this.cAPACIDADDataGridViewTextBoxColumn.HeaderText = "CAPACIDAD";
            this.cAPACIDADDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.cAPACIDADDataGridViewTextBoxColumn.Name = "cAPACIDADDataGridViewTextBoxColumn";
            this.cAPACIDADDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.cAPACIDADDataGridViewTextBoxColumn.Width = 125;
            // 
            // uBICACIÓNESTADODataGridViewTextBoxColumn
            // 
            this.uBICACIÓNESTADODataGridViewTextBoxColumn.DataPropertyName = "UBICACIÓN, ESTADO";
            this.uBICACIÓNESTADODataGridViewTextBoxColumn.HeaderText = "UBICACIÓN, ESTADO";
            this.uBICACIÓNESTADODataGridViewTextBoxColumn.MinimumWidth = 22;
            this.uBICACIÓNESTADODataGridViewTextBoxColumn.Name = "uBICACIÓNESTADODataGridViewTextBoxColumn";
            this.uBICACIÓNESTADODataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.uBICACIÓNESTADODataGridViewTextBoxColumn.Width = 125;
            // 
            // folioProyectosGeneralBindingSource
            // 
            this.folioProyectosGeneralBindingSource.DataMember = "Folio_Proyectos_General";
            this.folioProyectosGeneralBindingSource.DataSource = this.folio_general;
            // 
            // folio_general
            // 
            this.folio_general.DataSetName = "Folio_general";
            this.folio_general.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // folio_Proyectos_GeneralTableAdapter
            // 
            this.folio_Proyectos_GeneralTableAdapter.ClearBeforeFill = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.advancedDataGridView1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 384F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(893, 513);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::CBR_ADMIN.Properties.Resources.BarraConSombraChica;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.btnBuscar);
            this.panel1.Controls.Add(this.comboBox2);
            this.panel1.Controls.Add(this.comboBox3);
            this.panel1.Controls.Add(this.Clave);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(887, 123);
            this.panel1.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.LightGray;
            this.panel6.Location = new System.Drawing.Point(209, 22);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1, 75);
            this.panel6.TabIndex = 68;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.Location = new System.Drawing.Point(428, 22);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1, 75);
            this.panel2.TabIndex = 69;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightGray;
            this.panel3.Location = new System.Drawing.Point(683, 22);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1, 75);
            this.panel3.TabIndex = 69;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(37, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 17);
            this.label1.TabIndex = 70;
            this.label1.Text = "Razon Social o Cliente";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(226, 14);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(185, 17);
            this.label2.TabIndex = 71;
            this.label2.Text = "Nombre del Proyecto o Obra";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(521, 14);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 72;
            this.label3.Text = "Ubicación";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.label6.Location = new System.Drawing.Point(724, 38);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 13);
            this.label6.TabIndex = 74;
            this.label6.Text = "Ingrese Palabra clave:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(705, 14);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 17);
            this.label4.TabIndex = 73;
            this.label4.Text = "Buscador palabras clave";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Clave
            // 
            this.Clave.Location = new System.Drawing.Point(716, 60);
            this.Clave.Margin = new System.Windows.Forms.Padding(2);
            this.Clave.Name = "Clave";
            this.Clave.Size = new System.Drawing.Size(132, 20);
            this.Clave.TabIndex = 75;
            // 
            // comboBox3
            // 
            this.comboBox3.DataSource = this.folioProyectosGeneralBindingSource;
            this.comboBox3.DisplayMember = "UBICACIÓN, ESTADO";
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(444, 59);
            this.comboBox3.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(223, 21);
            this.comboBox3.TabIndex = 76;
            this.comboBox3.ValueMember = "UBICACIÓN, ESTADO";
            // 
            // comboBox2
            // 
            this.comboBox2.DataSource = this.folioProyectosGeneralBindingSource;
            this.comboBox2.DisplayMember = "NOMBRE DEL PROYECTO O OBRA";
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(218, 59);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(201, 21);
            this.comboBox2.TabIndex = 77;
            this.comboBox2.ValueMember = "NOMBRE DEL PROYECTO O OBRA";
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.Transparent;
            this.btnBuscar.BackgroundImage = global::CBR_ADMIN.Properties.Resources.icons8_search_48;
            this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Location = new System.Drawing.Point(769, 85);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(27, 27);
            this.btnBuscar.TabIndex = 78;
            this.toolTip1.SetToolTip(this.btnBuscar, "Buscar");
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.folioProyectosGeneralBindingSource;
            this.comboBox1.DisplayMember = "RAZON SOCIAL O CLIENTE (EMPRESA)";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(23, 59);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(173, 21);
            this.comboBox1.TabIndex = 79;
            this.comboBox1.ValueMember = "RAZON SOCIAL O CLIENTE (EMPRESA)";
            // 
            // Consulta_Proyectos_General
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(893, 513);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Consulta_Proyectos_General";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta_Proyectos_General";
            this.Load += new System.EventHandler(this.Consulta_Proyectos_General_Load);
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.folioProyectosGeneralBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.folio_general)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Zuby.ADGV.AdvancedDataGridView advancedDataGridView1;
        private Folio_general folio_general;
        private System.Windows.Forms.BindingSource folioProyectosGeneralBindingSource;
        private Folio_generalTableAdapters.Folio_Proyectos_GeneralTableAdapter folio_Proyectos_GeneralTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nOPROYECTOFOLIODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rAZONSOCIALOCLIENTEEMPRESADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nOMBREDELPROYECTOOOBRADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dESCRIPCIONOALCANCEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cAPACIDADDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn uBICACIÓNESTADODataGridViewTextBoxColumn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.TextBox Clave;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}