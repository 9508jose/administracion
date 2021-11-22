namespace CBR_ADMIN.Administracion
{
    partial class Consulta_No_Conf
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
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
            this.noConformidadesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cBR_No_Conf = new CBR_ADMIN.CBR_No_Conf();
            this.no_ConformidadesTableAdapter = new CBR_ADMIN.CBR_No_ConfTableAdapters.No_ConformidadesTableAdapter();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.noConformidadesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cBR_No_Conf)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.departamentoDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.noConformidadesBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(866, 499);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            // 
            // nCDataGridViewTextBoxColumn
            // 
            this.nCDataGridViewTextBoxColumn.DataPropertyName = "# NC";
            this.nCDataGridViewTextBoxColumn.HeaderText = "# NC";
            this.nCDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nCDataGridViewTextBoxColumn.Name = "nCDataGridViewTextBoxColumn";
            this.nCDataGridViewTextBoxColumn.Width = 125;
            // 
            // tipoDeNoConformidadDataGridViewTextBoxColumn
            // 
            this.tipoDeNoConformidadDataGridViewTextBoxColumn.DataPropertyName = "Tipo de no conformidad";
            this.tipoDeNoConformidadDataGridViewTextBoxColumn.HeaderText = "Tipo de no conformidad";
            this.tipoDeNoConformidadDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.tipoDeNoConformidadDataGridViewTextBoxColumn.Name = "tipoDeNoConformidadDataGridViewTextBoxColumn";
            this.tipoDeNoConformidadDataGridViewTextBoxColumn.Width = 125;
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            this.statusDataGridViewTextBoxColumn.HeaderText = "Status";
            this.statusDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            this.statusDataGridViewTextBoxColumn.Width = 125;
            // 
            // fechaReporteDataGridViewTextBoxColumn
            // 
            this.fechaReporteDataGridViewTextBoxColumn.DataPropertyName = "FechaReporte";
            this.fechaReporteDataGridViewTextBoxColumn.HeaderText = "FechaReporte";
            this.fechaReporteDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.fechaReporteDataGridViewTextBoxColumn.Name = "fechaReporteDataGridViewTextBoxColumn";
            this.fechaReporteDataGridViewTextBoxColumn.Width = 125;
            // 
            // personaReportaDataGridViewTextBoxColumn
            // 
            this.personaReportaDataGridViewTextBoxColumn.DataPropertyName = "Persona_Reporta";
            this.personaReportaDataGridViewTextBoxColumn.HeaderText = "Persona_Reporta";
            this.personaReportaDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.personaReportaDataGridViewTextBoxColumn.Name = "personaReportaDataGridViewTextBoxColumn";
            this.personaReportaDataGridViewTextBoxColumn.Width = 125;
            // 
            // descripcionNCDataGridViewTextBoxColumn
            // 
            this.descripcionNCDataGridViewTextBoxColumn.DataPropertyName = "Descripcion_NC";
            this.descripcionNCDataGridViewTextBoxColumn.HeaderText = "Descripcion_NC";
            this.descripcionNCDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.descripcionNCDataGridViewTextBoxColumn.Name = "descripcionNCDataGridViewTextBoxColumn";
            this.descripcionNCDataGridViewTextBoxColumn.Width = 125;
            // 
            // descripcionCRDataGridViewTextBoxColumn
            // 
            this.descripcionCRDataGridViewTextBoxColumn.DataPropertyName = "Descripcion_CR";
            this.descripcionCRDataGridViewTextBoxColumn.HeaderText = "Descripcion_CR";
            this.descripcionCRDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.descripcionCRDataGridViewTextBoxColumn.Name = "descripcionCRDataGridViewTextBoxColumn";
            this.descripcionCRDataGridViewTextBoxColumn.Width = 125;
            // 
            // fechaCompromisoDataGridViewTextBoxColumn
            // 
            this.fechaCompromisoDataGridViewTextBoxColumn.DataPropertyName = "FechaCompromiso";
            this.fechaCompromisoDataGridViewTextBoxColumn.HeaderText = "FechaCompromiso";
            this.fechaCompromisoDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.fechaCompromisoDataGridViewTextBoxColumn.Name = "fechaCompromisoDataGridViewTextBoxColumn";
            this.fechaCompromisoDataGridViewTextBoxColumn.Width = 125;
            // 
            // responsablesDataGridViewTextBoxColumn
            // 
            this.responsablesDataGridViewTextBoxColumn.DataPropertyName = "Responsables";
            this.responsablesDataGridViewTextBoxColumn.HeaderText = "Responsables";
            this.responsablesDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.responsablesDataGridViewTextBoxColumn.Name = "responsablesDataGridViewTextBoxColumn";
            this.responsablesDataGridViewTextBoxColumn.Width = 125;
            // 
            // resultadoDataGridViewTextBoxColumn
            // 
            this.resultadoDataGridViewTextBoxColumn.DataPropertyName = "Resultado";
            this.resultadoDataGridViewTextBoxColumn.HeaderText = "Resultado";
            this.resultadoDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.resultadoDataGridViewTextBoxColumn.Name = "resultadoDataGridViewTextBoxColumn";
            this.resultadoDataGridViewTextBoxColumn.Width = 125;
            // 
            // personaACDataGridViewTextBoxColumn
            // 
            this.personaACDataGridViewTextBoxColumn.DataPropertyName = "PersonaAC";
            this.personaACDataGridViewTextBoxColumn.HeaderText = "PersonaAC";
            this.personaACDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.personaACDataGridViewTextBoxColumn.Name = "personaACDataGridViewTextBoxColumn";
            this.personaACDataGridViewTextBoxColumn.Width = 125;
            // 
            // categoriaCausaDataGridViewTextBoxColumn
            // 
            this.categoriaCausaDataGridViewTextBoxColumn.DataPropertyName = "CategoriaCausa";
            this.categoriaCausaDataGridViewTextBoxColumn.HeaderText = "CategoriaCausa";
            this.categoriaCausaDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.categoriaCausaDataGridViewTextBoxColumn.Name = "categoriaCausaDataGridViewTextBoxColumn";
            this.categoriaCausaDataGridViewTextBoxColumn.Width = 125;
            // 
            // análisiscausasDataGridViewTextBoxColumn
            // 
            this.análisiscausasDataGridViewTextBoxColumn.DataPropertyName = "Análisis_causas";
            this.análisiscausasDataGridViewTextBoxColumn.HeaderText = "Análisis_causas";
            this.análisiscausasDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.análisiscausasDataGridViewTextBoxColumn.Name = "análisiscausasDataGridViewTextBoxColumn";
            this.análisiscausasDataGridViewTextBoxColumn.Width = 125;
            // 
            // repprocesosDataGridViewTextBoxColumn
            // 
            this.repprocesosDataGridViewTextBoxColumn.DataPropertyName = "Rep_procesos";
            this.repprocesosDataGridViewTextBoxColumn.HeaderText = "Rep_procesos";
            this.repprocesosDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.repprocesosDataGridViewTextBoxColumn.Name = "repprocesosDataGridViewTextBoxColumn";
            this.repprocesosDataGridViewTextBoxColumn.Width = 125;
            // 
            // procesoorigenDataGridViewTextBoxColumn
            // 
            this.procesoorigenDataGridViewTextBoxColumn.DataPropertyName = "Proceso_origen";
            this.procesoorigenDataGridViewTextBoxColumn.HeaderText = "Proceso_origen";
            this.procesoorigenDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.procesoorigenDataGridViewTextBoxColumn.Name = "procesoorigenDataGridViewTextBoxColumn";
            this.procesoorigenDataGridViewTextBoxColumn.Width = 125;
            // 
            // descripcionACDataGridViewTextBoxColumn
            // 
            this.descripcionACDataGridViewTextBoxColumn.DataPropertyName = "DescripcionAC";
            this.descripcionACDataGridViewTextBoxColumn.HeaderText = "DescripcionAC";
            this.descripcionACDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.descripcionACDataGridViewTextBoxColumn.Name = "descripcionACDataGridViewTextBoxColumn";
            this.descripcionACDataGridViewTextBoxColumn.Width = 125;
            // 
            // docModificarDataGridViewTextBoxColumn
            // 
            this.docModificarDataGridViewTextBoxColumn.DataPropertyName = "Doc_Modificar";
            this.docModificarDataGridViewTextBoxColumn.HeaderText = "Doc_Modificar";
            this.docModificarDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.docModificarDataGridViewTextBoxColumn.Name = "docModificarDataGridViewTextBoxColumn";
            this.docModificarDataGridViewTextBoxColumn.Width = 125;
            // 
            // fechaCompromisoACDataGridViewTextBoxColumn
            // 
            this.fechaCompromisoACDataGridViewTextBoxColumn.DataPropertyName = "FechaCompromisoAC";
            this.fechaCompromisoACDataGridViewTextBoxColumn.HeaderText = "FechaCompromisoAC";
            this.fechaCompromisoACDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.fechaCompromisoACDataGridViewTextBoxColumn.Name = "fechaCompromisoACDataGridViewTextBoxColumn";
            this.fechaCompromisoACDataGridViewTextBoxColumn.Width = 125;
            // 
            // fechaCierreACDataGridViewTextBoxColumn
            // 
            this.fechaCierreACDataGridViewTextBoxColumn.DataPropertyName = "FechaCierreAC";
            this.fechaCierreACDataGridViewTextBoxColumn.HeaderText = "FechaCierreAC";
            this.fechaCierreACDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.fechaCierreACDataGridViewTextBoxColumn.Name = "fechaCierreACDataGridViewTextBoxColumn";
            this.fechaCierreACDataGridViewTextBoxColumn.Width = 125;
            // 
            // responsableACDataGridViewTextBoxColumn
            // 
            this.responsableACDataGridViewTextBoxColumn.DataPropertyName = "ResponsableAC";
            this.responsableACDataGridViewTextBoxColumn.HeaderText = "ResponsableAC";
            this.responsableACDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.responsableACDataGridViewTextBoxColumn.Name = "responsableACDataGridViewTextBoxColumn";
            this.responsableACDataGridViewTextBoxColumn.Width = 125;
            // 
            // resultadoACDataGridViewTextBoxColumn
            // 
            this.resultadoACDataGridViewTextBoxColumn.DataPropertyName = "ResultadoAC";
            this.resultadoACDataGridViewTextBoxColumn.HeaderText = "ResultadoAC";
            this.resultadoACDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.resultadoACDataGridViewTextBoxColumn.Name = "resultadoACDataGridViewTextBoxColumn";
            this.resultadoACDataGridViewTextBoxColumn.Width = 125;
            // 
            // fechaVerifiacionDataGridViewTextBoxColumn
            // 
            this.fechaVerifiacionDataGridViewTextBoxColumn.DataPropertyName = "Fecha_Verifiacion";
            this.fechaVerifiacionDataGridViewTextBoxColumn.HeaderText = "Fecha_Verifiacion";
            this.fechaVerifiacionDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.fechaVerifiacionDataGridViewTextBoxColumn.Name = "fechaVerifiacionDataGridViewTextBoxColumn";
            this.fechaVerifiacionDataGridViewTextBoxColumn.Width = 125;
            // 
            // eliminacionCausaDataGridViewTextBoxColumn
            // 
            this.eliminacionCausaDataGridViewTextBoxColumn.DataPropertyName = "Eliminacion_Causa";
            this.eliminacionCausaDataGridViewTextBoxColumn.HeaderText = "Eliminacion_Causa";
            this.eliminacionCausaDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.eliminacionCausaDataGridViewTextBoxColumn.Name = "eliminacionCausaDataGridViewTextBoxColumn";
            this.eliminacionCausaDataGridViewTextBoxColumn.Width = 125;
            // 
            // aCEficazDataGridViewTextBoxColumn
            // 
            this.aCEficazDataGridViewTextBoxColumn.DataPropertyName = "AC_Eficaz";
            this.aCEficazDataGridViewTextBoxColumn.HeaderText = "AC_Eficaz";
            this.aCEficazDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.aCEficazDataGridViewTextBoxColumn.Name = "aCEficazDataGridViewTextBoxColumn";
            this.aCEficazDataGridViewTextBoxColumn.Width = 125;
            // 
            // departamentoDataGridViewTextBoxColumn
            // 
            this.departamentoDataGridViewTextBoxColumn.DataPropertyName = "Departamento";
            this.departamentoDataGridViewTextBoxColumn.HeaderText = "Departamento";
            this.departamentoDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.departamentoDataGridViewTextBoxColumn.Name = "departamentoDataGridViewTextBoxColumn";
            this.departamentoDataGridViewTextBoxColumn.Width = 125;
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
            // no_ConformidadesTableAdapter
            // 
            this.no_ConformidadesTableAdapter.ClearBeforeFill = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(872, 504);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // Consulta_No_Conf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Consulta_No_Conf";
            this.Size = new System.Drawing.Size(872, 504);
            this.Load += new System.EventHandler(this.Consulta_No_Conf_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.noConformidadesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cBR_No_Conf)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn cierreACDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn responsableACDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn resultadoACDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaVerifiacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eliminacionCausaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aCEficazDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn departamentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource noConformidadesBindingSource;
        private CBR_No_Conf cBR_No_Conf;
        private CBR_No_ConfTableAdapters.No_ConformidadesTableAdapter no_ConformidadesTableAdapter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
