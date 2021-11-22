
namespace CBR_ADMIN.Sistema
{
    partial class Folio_Proyectos
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
            this.folio_Proyectos1 = new CBR_ADMIN.Folio_Proyectos();
            this.folioProyectosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.folio_ProyectosTableAdapter = new CBR_ADMIN.Folio_ProyectosTableAdapters.Folio_ProyectosTableAdapter();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.consecutivoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.normaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.capacidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.folioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.anoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codificadorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.folio_Proyectos1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.folioProyectosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // advancedDataGridView1
            // 
            this.advancedDataGridView1.AutoGenerateColumns = false;
            this.advancedDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advancedDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.consecutivoDataGridViewTextBoxColumn,
            this.normaDataGridViewTextBoxColumn,
            this.tipoDataGridViewTextBoxColumn,
            this.capacidadDataGridViewTextBoxColumn,
            this.fechaDataGridViewTextBoxColumn,
            this.folioDataGridViewTextBoxColumn,
            this.nombreDataGridViewTextBoxColumn,
            this.anoDataGridViewTextBoxColumn,
            this.tipo2DataGridViewTextBoxColumn,
            this.nombre2DataGridViewTextBoxColumn,
            this.codificadorDataGridViewTextBoxColumn});
            this.advancedDataGridView1.DataSource = this.folioProyectosBindingSource;
            this.advancedDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advancedDataGridView1.FilterAndSortEnabled = true;
            this.advancedDataGridView1.Location = new System.Drawing.Point(0, 0);
            this.advancedDataGridView1.Name = "advancedDataGridView1";
            this.advancedDataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.advancedDataGridView1.RowHeadersWidth = 51;
            this.advancedDataGridView1.RowTemplate.Height = 24;
            this.advancedDataGridView1.Size = new System.Drawing.Size(997, 707);
            this.advancedDataGridView1.TabIndex = 0;
            // 
            // folio_Proyectos1
            // 
            this.folio_Proyectos1.DataSetName = "Folio_Proyectos";
            this.folio_Proyectos1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // folioProyectosBindingSource
            // 
            this.folioProyectosBindingSource.DataMember = "Folio_Proyectos";
            this.folioProyectosBindingSource.DataSource = this.folio_Proyectos1;
            // 
            // folio_ProyectosTableAdapter
            // 
            this.folio_ProyectosTableAdapter.ClearBeforeFill = true;
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
            // consecutivoDataGridViewTextBoxColumn
            // 
            this.consecutivoDataGridViewTextBoxColumn.DataPropertyName = "Consecutivo";
            this.consecutivoDataGridViewTextBoxColumn.HeaderText = "Consecutivo";
            this.consecutivoDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.consecutivoDataGridViewTextBoxColumn.Name = "consecutivoDataGridViewTextBoxColumn";
            this.consecutivoDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.consecutivoDataGridViewTextBoxColumn.Width = 125;
            // 
            // normaDataGridViewTextBoxColumn
            // 
            this.normaDataGridViewTextBoxColumn.DataPropertyName = "Norma";
            this.normaDataGridViewTextBoxColumn.HeaderText = "Norma";
            this.normaDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.normaDataGridViewTextBoxColumn.Name = "normaDataGridViewTextBoxColumn";
            this.normaDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.normaDataGridViewTextBoxColumn.Width = 125;
            // 
            // tipoDataGridViewTextBoxColumn
            // 
            this.tipoDataGridViewTextBoxColumn.DataPropertyName = "Tipo";
            this.tipoDataGridViewTextBoxColumn.HeaderText = "Tipo";
            this.tipoDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.tipoDataGridViewTextBoxColumn.Name = "tipoDataGridViewTextBoxColumn";
            this.tipoDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.tipoDataGridViewTextBoxColumn.Width = 125;
            // 
            // capacidadDataGridViewTextBoxColumn
            // 
            this.capacidadDataGridViewTextBoxColumn.DataPropertyName = "Capacidad";
            this.capacidadDataGridViewTextBoxColumn.HeaderText = "Capacidad";
            this.capacidadDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.capacidadDataGridViewTextBoxColumn.Name = "capacidadDataGridViewTextBoxColumn";
            this.capacidadDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.capacidadDataGridViewTextBoxColumn.Width = 125;
            // 
            // fechaDataGridViewTextBoxColumn
            // 
            this.fechaDataGridViewTextBoxColumn.DataPropertyName = "Fecha";
            this.fechaDataGridViewTextBoxColumn.HeaderText = "Fecha";
            this.fechaDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.fechaDataGridViewTextBoxColumn.Name = "fechaDataGridViewTextBoxColumn";
            this.fechaDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.fechaDataGridViewTextBoxColumn.Width = 125;
            // 
            // folioDataGridViewTextBoxColumn
            // 
            this.folioDataGridViewTextBoxColumn.DataPropertyName = "Folio";
            this.folioDataGridViewTextBoxColumn.HeaderText = "Folio";
            this.folioDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.folioDataGridViewTextBoxColumn.Name = "folioDataGridViewTextBoxColumn";
            this.folioDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.folioDataGridViewTextBoxColumn.Width = 125;
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            this.nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
            this.nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            this.nombreDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            this.nombreDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.nombreDataGridViewTextBoxColumn.Width = 125;
            // 
            // anoDataGridViewTextBoxColumn
            // 
            this.anoDataGridViewTextBoxColumn.DataPropertyName = "Ano";
            this.anoDataGridViewTextBoxColumn.HeaderText = "Ano";
            this.anoDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.anoDataGridViewTextBoxColumn.Name = "anoDataGridViewTextBoxColumn";
            this.anoDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.anoDataGridViewTextBoxColumn.Width = 125;
            // 
            // tipo2DataGridViewTextBoxColumn
            // 
            this.tipo2DataGridViewTextBoxColumn.DataPropertyName = "tipo2";
            this.tipo2DataGridViewTextBoxColumn.HeaderText = "tipo2";
            this.tipo2DataGridViewTextBoxColumn.MinimumWidth = 22;
            this.tipo2DataGridViewTextBoxColumn.Name = "tipo2DataGridViewTextBoxColumn";
            this.tipo2DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.tipo2DataGridViewTextBoxColumn.Width = 125;
            // 
            // nombre2DataGridViewTextBoxColumn
            // 
            this.nombre2DataGridViewTextBoxColumn.DataPropertyName = "Nombre2";
            this.nombre2DataGridViewTextBoxColumn.HeaderText = "Nombre2";
            this.nombre2DataGridViewTextBoxColumn.MinimumWidth = 22;
            this.nombre2DataGridViewTextBoxColumn.Name = "nombre2DataGridViewTextBoxColumn";
            this.nombre2DataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.nombre2DataGridViewTextBoxColumn.Width = 125;
            // 
            // codificadorDataGridViewTextBoxColumn
            // 
            this.codificadorDataGridViewTextBoxColumn.DataPropertyName = "codificador";
            this.codificadorDataGridViewTextBoxColumn.HeaderText = "codificador";
            this.codificadorDataGridViewTextBoxColumn.MinimumWidth = 22;
            this.codificadorDataGridViewTextBoxColumn.Name = "codificadorDataGridViewTextBoxColumn";
            this.codificadorDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.codificadorDataGridViewTextBoxColumn.Width = 125;
            // 
            // Folio_Proyectos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 707);
            this.Controls.Add(this.advancedDataGridView1);
            this.Name = "Folio_Proyectos";
            this.Text = "Folio_Proyectos";
            this.Load += new System.EventHandler(this.Folio_Proyectos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.folio_Proyectos1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.folioProyectosBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Zuby.ADGV.AdvancedDataGridView advancedDataGridView1;
        private CBR_ADMIN.Folio_Proyectos folio_Proyectos1;
        private System.Windows.Forms.BindingSource folioProyectosBindingSource;
        private Folio_ProyectosTableAdapters.Folio_ProyectosTableAdapter folio_ProyectosTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn consecutivoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn normaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn capacidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn folioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn anoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codificadorDataGridViewTextBoxColumn;
    }
}