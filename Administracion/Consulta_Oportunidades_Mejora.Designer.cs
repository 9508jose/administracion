namespace CBR_ADMIN.Administracion
{
    partial class Consulta_Oportunidades_Mejora
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
            this.descripcionOportunidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaReporteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.procesoReportaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nAccionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaCompromisoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaCierreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.responsablesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resultadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.departamentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.opMejoraBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cBR_No_Oportunidad = new CBR_ADMIN.CBR_No_Oportunidad();
            this.op_MejoraTableAdapter = new CBR_ADMIN.CBR_No_OportunidadTableAdapters.Op_MejoraTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.opMejoraBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cBR_No_Oportunidad)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.descripcionOportunidadDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn,
            this.fechaReporteDataGridViewTextBoxColumn,
            this.procesoReportaDataGridViewTextBoxColumn,
            this.nAccionDataGridViewTextBoxColumn,
            this.descripcionDataGridViewTextBoxColumn,
            this.fechaCompromisoDataGridViewTextBoxColumn,
            this.fechaCierreDataGridViewTextBoxColumn,
            this.responsablesDataGridViewTextBoxColumn,
            this.resultadoDataGridViewTextBoxColumn,
            this.departamentoDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.opMejoraBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(910, 576);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // descripcionOportunidadDataGridViewTextBoxColumn
            // 
            this.descripcionOportunidadDataGridViewTextBoxColumn.DataPropertyName = "Descripcion_Oportunidad";
            this.descripcionOportunidadDataGridViewTextBoxColumn.HeaderText = "Descripcion_Oportunidad";
            this.descripcionOportunidadDataGridViewTextBoxColumn.Name = "descripcionOportunidadDataGridViewTextBoxColumn";
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
            // procesoReportaDataGridViewTextBoxColumn
            // 
            this.procesoReportaDataGridViewTextBoxColumn.DataPropertyName = "Proceso_Reporta";
            this.procesoReportaDataGridViewTextBoxColumn.HeaderText = "Proceso_Reporta";
            this.procesoReportaDataGridViewTextBoxColumn.Name = "procesoReportaDataGridViewTextBoxColumn";
            // 
            // nAccionDataGridViewTextBoxColumn
            // 
            this.nAccionDataGridViewTextBoxColumn.DataPropertyName = "#N_Accion";
            this.nAccionDataGridViewTextBoxColumn.HeaderText = "#N_Accion";
            this.nAccionDataGridViewTextBoxColumn.Name = "nAccionDataGridViewTextBoxColumn";
            // 
            // descripcionDataGridViewTextBoxColumn
            // 
            this.descripcionDataGridViewTextBoxColumn.DataPropertyName = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn.HeaderText = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn.Name = "descripcionDataGridViewTextBoxColumn";
            // 
            // fechaCompromisoDataGridViewTextBoxColumn
            // 
            this.fechaCompromisoDataGridViewTextBoxColumn.DataPropertyName = "FechaCompromiso";
            this.fechaCompromisoDataGridViewTextBoxColumn.HeaderText = "FechaCompromiso";
            this.fechaCompromisoDataGridViewTextBoxColumn.Name = "fechaCompromisoDataGridViewTextBoxColumn";
            // 
            // fechaCierreDataGridViewTextBoxColumn
            // 
            this.fechaCierreDataGridViewTextBoxColumn.DataPropertyName = "FechaCierre";
            this.fechaCierreDataGridViewTextBoxColumn.HeaderText = "FechaCierre";
            this.fechaCierreDataGridViewTextBoxColumn.Name = "fechaCierreDataGridViewTextBoxColumn";
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
            // departamentoDataGridViewTextBoxColumn
            // 
            this.departamentoDataGridViewTextBoxColumn.DataPropertyName = "Departamento";
            this.departamentoDataGridViewTextBoxColumn.HeaderText = "Departamento";
            this.departamentoDataGridViewTextBoxColumn.Name = "departamentoDataGridViewTextBoxColumn";
            // 
            // opMejoraBindingSource
            // 
            this.opMejoraBindingSource.DataMember = "Op_Mejora";
            this.opMejoraBindingSource.DataSource = this.cBR_No_Oportunidad;
            // 
            // cBR_No_Oportunidad
            // 
            this.cBR_No_Oportunidad.DataSetName = "CBR_No_Oportunidad";
            this.cBR_No_Oportunidad.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // op_MejoraTableAdapter
            // 
            this.op_MejoraTableAdapter.ClearBeforeFill = true;
            // 
            // Consulta_Oportunidades_Mejora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Name = "Consulta_Oportunidades_Mejora";
            this.Size = new System.Drawing.Size(910, 576);
            this.Load += new System.EventHandler(this.Consulta_Oportunidades_Mejora_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.opMejoraBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cBR_No_Oportunidad)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource opMejoraBindingSource;
        private CBR_No_Oportunidad cBR_No_Oportunidad;
        private CBR_No_OportunidadTableAdapters.Op_MejoraTableAdapter op_MejoraTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn nODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionOportunidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaReporteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn procesoReportaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nAccionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaCompromisoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaCierreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn responsablesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn resultadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn departamentoDataGridViewTextBoxColumn;
    }
}
