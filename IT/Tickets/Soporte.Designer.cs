namespace CBR_ADMIN.IT
{
    partial class Soporte
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Soporte));
            this.cbr_Tikets = new CBR_ADMIN.Cbr_Tikets();
            this.ticketsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ticketsTableAdapter = new CBR_ADMIN.Cbr_TiketsTableAdapters.TicketsTableAdapter();
            this.tikets_Fecha = new CBR_ADMIN.Tikets_Fecha();
            this.tiketsfechaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tikets_fechaTableAdapter = new CBR_ADMIN.Tikets_FechaTableAdapters.Tikets_fechaTableAdapter();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.uwin = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.principal = new System.Windows.Forms.Panel();
            this.Usuario = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Generar = new System.Windows.Forms.Button();
            this.Detalle = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cbr_Tikets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ticketsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tikets_Fecha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tiketsfechaBindingSource)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.principal.SuspendLayout();
            this.SuspendLayout();
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
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.principal, 1, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Name = "label1";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.uwin);
            this.panel3.Controls.Add(this.label31);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // uwin
            // 
            resources.ApplyResources(this.uwin, "uwin");
            this.uwin.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.uwin.Name = "uwin";
            // 
            // label31
            // 
            resources.ApplyResources(this.label31, "label31");
            this.label31.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label31.Name = "label31";
            // 
            // principal
            // 
            resources.ApplyResources(this.principal, "principal");
            this.principal.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.principal.Controls.Add(this.Usuario);
            this.principal.Controls.Add(this.label8);
            this.principal.Controls.Add(this.Generar);
            this.principal.Controls.Add(this.Detalle);
            this.principal.Controls.Add(this.label4);
            this.principal.Controls.Add(this.label2);
            this.principal.Name = "principal";
            // 
            // Usuario
            // 
            resources.ApplyResources(this.Usuario, "Usuario");
            this.Usuario.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Usuario.Name = "Usuario";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label8.Name = "label8";
            // 
            // Generar
            // 
            this.Generar.BackColor = System.Drawing.Color.SlateGray;
            this.Generar.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.Generar, "Generar");
            this.Generar.Name = "Generar";
            this.Generar.UseVisualStyleBackColor = false;
            this.Generar.Click += new System.EventHandler(this.Generar_Click);
            // 
            // Detalle
            // 
            this.Detalle.BackColor = System.Drawing.SystemColors.GrayText;
            this.Detalle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.Detalle, "Detalle");
            this.Detalle.Name = "Detalle";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Name = "label4";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Name = "label2";
            // 
            // Soporte
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Soporte";
            this.Load += new System.EventHandler(this.Soporte_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.cbr_Tikets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ticketsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tikets_Fecha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tiketsfechaBindingSource)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.principal.ResumeLayout(false);
            this.principal.PerformLayout();
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
        private System.Windows.Forms.Label Usuario;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button Generar;
        private System.Windows.Forms.RichTextBox Detalle;
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
