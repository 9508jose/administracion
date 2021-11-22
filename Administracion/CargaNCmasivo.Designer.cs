namespace CBR_ADMIN.Administracion
{
    partial class CargaNCmasivo
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.Btn_cargaExcelNPExla = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.DG_NC_Carga = new System.Windows.Forms.DataGridView();
            this.nCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoDeNoConformidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaReporteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.personaReportaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionNCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionCRDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaCompromisoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.responsablesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resultadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.personaACDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoriaCausaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.análisiscausasDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.repprocesosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.procesoorigenDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionACDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docModificarDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaCompromisoACDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaCierreACDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.responsableACDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resultadoACDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaVerifiacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eliminacionCausaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aCEficazDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.departamentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noConformidadesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cBR_No_Conf = new CBR_ADMIN.CBR_No_Conf();
            this.DG_NC_Temporal = new System.Windows.Forms.DataGridView();
            this.no_ConformidadesTableAdapter = new CBR_ADMIN.CBR_No_ConfTableAdapters.No_ConformidadesTableAdapter();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DG_NC_Carga)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.noConformidadesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cBR_No_Conf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DG_NC_Temporal)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.378336F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.62167F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1125, 637);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.flowLayoutPanel2);
            this.panel1.Controls.Add(this.Btn_cargaExcelNPExla);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1119, 40);
            this.panel1.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.SteelBlue;
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 38);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(1119, 2);
            this.flowLayoutPanel2.TabIndex = 32;
            // 
            // Btn_cargaExcelNPExla
            // 
            this.Btn_cargaExcelNPExla.BackColor = System.Drawing.Color.SteelBlue;
            this.Btn_cargaExcelNPExla.FlatAppearance.BorderSize = 0;
            this.Btn_cargaExcelNPExla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_cargaExcelNPExla.ForeColor = System.Drawing.Color.Transparent;
            this.Btn_cargaExcelNPExla.Location = new System.Drawing.Point(4, 2);
            this.Btn_cargaExcelNPExla.Name = "Btn_cargaExcelNPExla";
            this.Btn_cargaExcelNPExla.Size = new System.Drawing.Size(141, 31);
            this.Btn_cargaExcelNPExla.TabIndex = 30;
            this.Btn_cargaExcelNPExla.Text = "Cargar Excel";
            this.Btn_cargaExcelNPExla.UseVisualStyleBackColor = false;
            this.Btn_cargaExcelNPExla.Click += new System.EventHandler(this.Btn_cargaExcelNPExla_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.DG_NC_Carga, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.DG_NC_Temporal, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 49);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1119, 585);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // DG_NC_Carga
            // 
            this.DG_NC_Carga.AutoGenerateColumns = false;
            this.DG_NC_Carga.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DG_NC_Carga.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG_NC_Carga.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nCDataGridViewTextBoxColumn,
            this.tipoDeNoConformidadDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn,
            this.fechaReporteDataGridViewTextBoxColumn,
            this.personaReportaDataGridViewTextBoxColumn,
            this.descripcionNCDataGridViewTextBoxColumn,
            this.descripcionCRDataGridViewTextBoxColumn,
            this.fechaCompromisoDataGridViewTextBoxColumn,
            this.responsablesDataGridViewTextBoxColumn,
            this.resultadoDataGridViewTextBoxColumn,
            this.personaACDataGridViewTextBoxColumn,
            this.categoriaCausaDataGridViewTextBoxColumn,
            this.análisiscausasDataGridViewTextBoxColumn,
            this.repprocesosDataGridViewTextBoxColumn,
            this.procesoorigenDataGridViewTextBoxColumn,
            this.descripcionACDataGridViewTextBoxColumn,
            this.docModificarDataGridViewTextBoxColumn,
            this.fechaCompromisoACDataGridViewTextBoxColumn,
            this.fechaCierreACDataGridViewTextBoxColumn,
            this.responsableACDataGridViewTextBoxColumn,
            this.resultadoACDataGridViewTextBoxColumn,
            this.fechaVerifiacionDataGridViewTextBoxColumn,
            this.eliminacionCausaDataGridViewTextBoxColumn,
            this.aCEficazDataGridViewTextBoxColumn,
            this.departamentoDataGridViewTextBoxColumn,
            this.iDDataGridViewTextBoxColumn});
            this.DG_NC_Carga.DataSource = this.noConformidadesBindingSource;
            this.DG_NC_Carga.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DG_NC_Carga.Location = new System.Drawing.Point(3, 295);
            this.DG_NC_Carga.Name = "DG_NC_Carga";
            this.DG_NC_Carga.Size = new System.Drawing.Size(1113, 287);
            this.DG_NC_Carga.TabIndex = 2;
            // 
            // nCDataGridViewTextBoxColumn
            // 
            this.nCDataGridViewTextBoxColumn.DataPropertyName = "# NC";
            this.nCDataGridViewTextBoxColumn.HeaderText = "# NC";
            this.nCDataGridViewTextBoxColumn.Name = "nCDataGridViewTextBoxColumn";
            // 
            // tipoDeNoConformidadDataGridViewTextBoxColumn
            // 
            this.tipoDeNoConformidadDataGridViewTextBoxColumn.DataPropertyName = "Tipo de no conformidad";
            this.tipoDeNoConformidadDataGridViewTextBoxColumn.HeaderText = "Tipo de no conformidad";
            this.tipoDeNoConformidadDataGridViewTextBoxColumn.Name = "tipoDeNoConformidadDataGridViewTextBoxColumn";
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            this.statusDataGridViewTextBoxColumn.HeaderText = "Status";
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            // 
            // fechaReporteDataGridViewTextBoxColumn
            // 
            this.fechaReporteDataGridViewTextBoxColumn.DataPropertyName = "FechaReporte";
            this.fechaReporteDataGridViewTextBoxColumn.HeaderText = "FechaReporte";
            this.fechaReporteDataGridViewTextBoxColumn.Name = "fechaReporteDataGridViewTextBoxColumn";
            // 
            // personaReportaDataGridViewTextBoxColumn
            // 
            this.personaReportaDataGridViewTextBoxColumn.DataPropertyName = "Persona_Reporta";
            this.personaReportaDataGridViewTextBoxColumn.HeaderText = "Persona_Reporta";
            this.personaReportaDataGridViewTextBoxColumn.Name = "personaReportaDataGridViewTextBoxColumn";
            // 
            // descripcionNCDataGridViewTextBoxColumn
            // 
            this.descripcionNCDataGridViewTextBoxColumn.DataPropertyName = "Descripcion_NC";
            this.descripcionNCDataGridViewTextBoxColumn.HeaderText = "Descripcion_NC";
            this.descripcionNCDataGridViewTextBoxColumn.Name = "descripcionNCDataGridViewTextBoxColumn";
            // 
            // descripcionCRDataGridViewTextBoxColumn
            // 
            this.descripcionCRDataGridViewTextBoxColumn.DataPropertyName = "Descripcion_CR";
            this.descripcionCRDataGridViewTextBoxColumn.HeaderText = "Descripcion_CR";
            this.descripcionCRDataGridViewTextBoxColumn.Name = "descripcionCRDataGridViewTextBoxColumn";
            // 
            // fechaCompromisoDataGridViewTextBoxColumn
            // 
            this.fechaCompromisoDataGridViewTextBoxColumn.DataPropertyName = "FechaCompromiso";
            this.fechaCompromisoDataGridViewTextBoxColumn.HeaderText = "FechaCompromiso";
            this.fechaCompromisoDataGridViewTextBoxColumn.Name = "fechaCompromisoDataGridViewTextBoxColumn";
            // 
            // responsablesDataGridViewTextBoxColumn
            // 
            this.responsablesDataGridViewTextBoxColumn.DataPropertyName = "Responsables";
            this.responsablesDataGridViewTextBoxColumn.HeaderText = "Responsables";
            this.responsablesDataGridViewTextBoxColumn.Name = "responsablesDataGridViewTextBoxColumn";
            // 
            // resultadoDataGridViewTextBoxColumn
            // 
            this.resultadoDataGridViewTextBoxColumn.DataPropertyName = "Resultado";
            this.resultadoDataGridViewTextBoxColumn.HeaderText = "Resultado";
            this.resultadoDataGridViewTextBoxColumn.Name = "resultadoDataGridViewTextBoxColumn";
            // 
            // personaACDataGridViewTextBoxColumn
            // 
            this.personaACDataGridViewTextBoxColumn.DataPropertyName = "PersonaAC";
            this.personaACDataGridViewTextBoxColumn.HeaderText = "PersonaAC";
            this.personaACDataGridViewTextBoxColumn.Name = "personaACDataGridViewTextBoxColumn";
            // 
            // categoriaCausaDataGridViewTextBoxColumn
            // 
            this.categoriaCausaDataGridViewTextBoxColumn.DataPropertyName = "CategoriaCausa";
            this.categoriaCausaDataGridViewTextBoxColumn.HeaderText = "CategoriaCausa";
            this.categoriaCausaDataGridViewTextBoxColumn.Name = "categoriaCausaDataGridViewTextBoxColumn";
            // 
            // análisiscausasDataGridViewTextBoxColumn
            // 
            this.análisiscausasDataGridViewTextBoxColumn.DataPropertyName = "Análisis_causas";
            this.análisiscausasDataGridViewTextBoxColumn.HeaderText = "Análisis_causas";
            this.análisiscausasDataGridViewTextBoxColumn.Name = "análisiscausasDataGridViewTextBoxColumn";
            // 
            // repprocesosDataGridViewTextBoxColumn
            // 
            this.repprocesosDataGridViewTextBoxColumn.DataPropertyName = "Rep_procesos";
            this.repprocesosDataGridViewTextBoxColumn.HeaderText = "Rep_procesos";
            this.repprocesosDataGridViewTextBoxColumn.Name = "repprocesosDataGridViewTextBoxColumn";
            // 
            // procesoorigenDataGridViewTextBoxColumn
            // 
            this.procesoorigenDataGridViewTextBoxColumn.DataPropertyName = "Proceso_origen";
            this.procesoorigenDataGridViewTextBoxColumn.HeaderText = "Proceso_origen";
            this.procesoorigenDataGridViewTextBoxColumn.Name = "procesoorigenDataGridViewTextBoxColumn";
            // 
            // descripcionACDataGridViewTextBoxColumn
            // 
            this.descripcionACDataGridViewTextBoxColumn.DataPropertyName = "DescripcionAC";
            this.descripcionACDataGridViewTextBoxColumn.HeaderText = "DescripcionAC";
            this.descripcionACDataGridViewTextBoxColumn.Name = "descripcionACDataGridViewTextBoxColumn";
            // 
            // docModificarDataGridViewTextBoxColumn
            // 
            this.docModificarDataGridViewTextBoxColumn.DataPropertyName = "Doc_Modificar";
            this.docModificarDataGridViewTextBoxColumn.HeaderText = "Doc_Modificar";
            this.docModificarDataGridViewTextBoxColumn.Name = "docModificarDataGridViewTextBoxColumn";
            // 
            // fechaCompromisoACDataGridViewTextBoxColumn
            // 
            this.fechaCompromisoACDataGridViewTextBoxColumn.DataPropertyName = "FechaCompromisoAC";
            this.fechaCompromisoACDataGridViewTextBoxColumn.HeaderText = "FechaCompromisoAC";
            this.fechaCompromisoACDataGridViewTextBoxColumn.Name = "fechaCompromisoACDataGridViewTextBoxColumn";
            // 
            // fechaCierreACDataGridViewTextBoxColumn
            // 
            this.fechaCierreACDataGridViewTextBoxColumn.DataPropertyName = "FechaCierreAC";
            this.fechaCierreACDataGridViewTextBoxColumn.HeaderText = "FechaCierreAC";
            this.fechaCierreACDataGridViewTextBoxColumn.Name = "fechaCierreACDataGridViewTextBoxColumn";
            // 
            // responsableACDataGridViewTextBoxColumn
            // 
            this.responsableACDataGridViewTextBoxColumn.DataPropertyName = "ResponsableAC";
            this.responsableACDataGridViewTextBoxColumn.HeaderText = "ResponsableAC";
            this.responsableACDataGridViewTextBoxColumn.Name = "responsableACDataGridViewTextBoxColumn";
            // 
            // resultadoACDataGridViewTextBoxColumn
            // 
            this.resultadoACDataGridViewTextBoxColumn.DataPropertyName = "ResultadoAC";
            this.resultadoACDataGridViewTextBoxColumn.HeaderText = "ResultadoAC";
            this.resultadoACDataGridViewTextBoxColumn.Name = "resultadoACDataGridViewTextBoxColumn";
            // 
            // fechaVerifiacionDataGridViewTextBoxColumn
            // 
            this.fechaVerifiacionDataGridViewTextBoxColumn.DataPropertyName = "Fecha_Verifiacion";
            this.fechaVerifiacionDataGridViewTextBoxColumn.HeaderText = "Fecha_Verifiacion";
            this.fechaVerifiacionDataGridViewTextBoxColumn.Name = "fechaVerifiacionDataGridViewTextBoxColumn";
            // 
            // eliminacionCausaDataGridViewTextBoxColumn
            // 
            this.eliminacionCausaDataGridViewTextBoxColumn.DataPropertyName = "Eliminacion_Causa";
            this.eliminacionCausaDataGridViewTextBoxColumn.HeaderText = "Eliminacion_Causa";
            this.eliminacionCausaDataGridViewTextBoxColumn.Name = "eliminacionCausaDataGridViewTextBoxColumn";
            // 
            // aCEficazDataGridViewTextBoxColumn
            // 
            this.aCEficazDataGridViewTextBoxColumn.DataPropertyName = "AC_Eficaz";
            this.aCEficazDataGridViewTextBoxColumn.HeaderText = "AC_Eficaz";
            this.aCEficazDataGridViewTextBoxColumn.Name = "aCEficazDataGridViewTextBoxColumn";
            // 
            // departamentoDataGridViewTextBoxColumn
            // 
            this.departamentoDataGridViewTextBoxColumn.DataPropertyName = "Departamento";
            this.departamentoDataGridViewTextBoxColumn.HeaderText = "Departamento";
            this.departamentoDataGridViewTextBoxColumn.Name = "departamentoDataGridViewTextBoxColumn";
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // noConformidadesBindingSource
            // 
            this.noConformidadesBindingSource.DataMember = "No_Conformidades";
            this.noConformidadesBindingSource.DataSource = this.cBR_No_Conf;
            // 
            // cBR_No_Conf
            // 
            this.cBR_No_Conf.DataSetName = "CBR_No_Conf";
            this.cBR_No_Conf.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // DG_NC_Temporal
            // 
            this.DG_NC_Temporal.AllowUserToAddRows = false;
            this.DG_NC_Temporal.AllowUserToDeleteRows = false;
            this.DG_NC_Temporal.AllowUserToOrderColumns = true;
            this.DG_NC_Temporal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG_NC_Temporal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DG_NC_Temporal.Location = new System.Drawing.Point(3, 3);
            this.DG_NC_Temporal.Name = "DG_NC_Temporal";
            this.DG_NC_Temporal.ReadOnly = true;
            this.DG_NC_Temporal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DG_NC_Temporal.Size = new System.Drawing.Size(1113, 286);
            this.DG_NC_Temporal.TabIndex = 3;
            // 
            // no_ConformidadesTableAdapter
            // 
            this.no_ConformidadesTableAdapter.ClearBeforeFill = true;
            // 
            // CargaNCmasivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "CargaNCmasivo";
            this.Size = new System.Drawing.Size(1125, 637);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DG_NC_Carga)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.noConformidadesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cBR_No_Conf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DG_NC_Temporal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button Btn_cargaExcelNPExla;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.DataGridView DG_NC_Carga;
        private System.Windows.Forms.DataGridViewTextBoxColumn nCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoDeNoConformidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaReporteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn personaReportaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionNCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionCRDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaCompromisoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn responsablesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn resultadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn personaACDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoriaCausaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn análisiscausasDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn repprocesosDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn procesoorigenDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionACDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn docModificarDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaCompromisoACDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaCierreACDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn responsableACDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn resultadoACDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaVerifiacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eliminacionCausaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aCEficazDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn departamentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource noConformidadesBindingSource;
        private CBR_No_Conf cBR_No_Conf;
        private CBR_No_ConfTableAdapters.No_ConformidadesTableAdapter no_ConformidadesTableAdapter;
        private System.Windows.Forms.DataGridView DG_NC_Temporal;
    }
}
