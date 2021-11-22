
namespace CBR_ADMIN.Administracion
{
    partial class Consulta
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
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.table_Pdf = new CBR_ADMIN.Table_Pdf();
            this.guardaPDFBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.guardaPDFTableAdapter = new CBR_ADMIN.Table_PdfTableAdapters.GuardaPDFTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.table_Pdf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guardaPDFBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 23);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Archivos:";
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.guardaPDFBindingSource;
            this.comboBox1.DisplayMember = "Titulo";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(102, 23);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(365, 24);
            this.comboBox1.TabIndex = 10;
            this.comboBox1.ValueMember = "Titulo";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(226, 68);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(100, 28);
            this.btnBuscar.TabIndex = 11;
            this.btnBuscar.Text = "Seleccionar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // table_Pdf
            // 
            this.table_Pdf.DataSetName = "Table_Pdf";
            this.table_Pdf.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // guardaPDFBindingSource
            // 
            this.guardaPDFBindingSource.DataMember = "GuardaPDF";
            this.guardaPDFBindingSource.DataSource = this.table_Pdf;
            // 
            // guardaPDFTableAdapter
            // 
            this.guardaPDFTableAdapter.ClearBeforeFill = true;
            // 
            // Consulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 124);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label3);
            this.Name = "Consulta";
            this.Text = "Consulta";
            this.Load += new System.EventHandler(this.Consulta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.table_Pdf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guardaPDFBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnBuscar;
        private Table_Pdf table_Pdf;
        private System.Windows.Forms.BindingSource guardaPDFBindingSource;
        private Table_PdfTableAdapters.GuardaPDFTableAdapter guardaPDFTableAdapter;
    }
}