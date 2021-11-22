
namespace CBR_ADMIN.Sistema
{
    partial class Crea_Rehabilitacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Crea_Rehabilitacion));
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.folioProyectosBindingSource = new System.Windows.Forms.BindingSource(this.components);
      
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.Proyecto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Folio = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.norma = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Cancelar = new System.Windows.Forms.Button();
            this.Guardar = new System.Windows.Forms.Button();
            this.NombreProyecto = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.folio_ProyectosTableAdapter = new CBR_ADMIN.Folio_ProyectosTableAdapters.Folio_ProyectosTableAdapter();
            this.cBR_Folio_Rehabilitacion = new CBR_ADMIN.CBR_Folio_Rehabilitacion();
            this.folioRehabilitacionesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.folio_RehabilitacionesTableAdapter = new CBR_ADMIN.CBR_Folio_RehabilitacionTableAdapters.Folio_RehabilitacionesTableAdapter();
            this.Tipo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.folioProyectosBindingSource)).BeginInit();

            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cBR_Folio_Rehabilitacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.folioRehabilitacionesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label8.Location = new System.Drawing.Point(96, 320);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(348, 24);
            this.label8.TabIndex = 117;
            this.label8.Text = "Seleccione el Nombre del Proyecto:";
            // 
            // comboBox3
            // 
            this.comboBox3.DataSource = this.folioProyectosBindingSource;
            this.comboBox3.DisplayMember = "Nombre2";
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(474, 320);
            this.comboBox3.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(278, 24);
            this.comboBox3.TabIndex = 116;
            this.comboBox3.ValueMember = "Nombre2";
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged_1);
            // 
            // folioProyectosBindingSource
            // 
            this.folioProyectosBindingSource.DataMember = "Folio_Proyectos";

            // 
            // folio_Proyectos

            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(81, 278);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(362, 24);
            this.label5.TabIndex = 113;
            this.label5.Text = "¿Es rehabilitacion de planta de CBR?:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Si",
            "No"});
            this.comboBox1.Location = new System.Drawing.Point(474, 278);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(59, 24);
            this.comboBox1.TabIndex = 112;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Proyecto
            // 
            this.Proyecto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.Proyecto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Proyecto.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Proyecto.ForeColor = System.Drawing.SystemColors.Window;
            this.Proyecto.Location = new System.Drawing.Point(131, 430);
            this.Proyecto.Margin = new System.Windows.Forms.Padding(4);
            this.Proyecto.Name = "Proyecto";
            this.Proyecto.Size = new System.Drawing.Size(645, 30);
            this.Proyecto.TabIndex = 111;
            this.Proyecto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(342, 44);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(386, 36);
            this.label1.TabIndex = 100;
            this.label1.Text = "Administracion y servicios";
            // 
            // Folio
            // 
            this.Folio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.Folio.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Folio.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Folio.ForeColor = System.Drawing.SystemColors.Window;
            this.Folio.Location = new System.Drawing.Point(147, 383);
            this.Folio.Margin = new System.Windows.Forms.Padding(4);
            this.Folio.Name = "Folio";
            this.Folio.Size = new System.Drawing.Size(645, 30);
            this.Folio.TabIndex = 110;
            this.Folio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
 
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(160, 216);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(279, 24);
            this.label6.TabIndex = 109;
            this.label6.Text = "Seleccione el tipo de norma:";
            // 
            // norma
            // 
            this.norma.FormattingEnabled = true;
            this.norma.Items.AddRange(new object[] {
            "3",
            "2",
            "1"});
            this.norma.Location = new System.Drawing.Point(474, 216);
            this.norma.Margin = new System.Windows.Forms.Padding(4);
            this.norma.Name = "norma";
            this.norma.Size = new System.Drawing.Size(59, 24);
            this.norma.TabIndex = 108;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(162, 186);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(276, 24);
            this.label4.TabIndex = 107;
            this.label4.Text = "Seleccione el tipo de planta:";
            // 
            // Cancelar
            // 
            this.Cancelar.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.Cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cancelar.Location = new System.Drawing.Point(452, 553);
            this.Cancelar.Margin = new System.Windows.Forms.Padding(4);
            this.Cancelar.Name = "Cancelar";
            this.Cancelar.Size = new System.Drawing.Size(168, 36);
            this.Cancelar.TabIndex = 105;
            this.Cancelar.Text = "Cancelar";
            this.Cancelar.UseVisualStyleBackColor = false;
            // 
            // Guardar
            // 
            this.Guardar.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.Guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Guardar.Location = new System.Drawing.Point(257, 553);
            this.Guardar.Margin = new System.Windows.Forms.Padding(4);
            this.Guardar.Name = "Guardar";
            this.Guardar.Size = new System.Drawing.Size(168, 36);
            this.Guardar.TabIndex = 104;
            this.Guardar.Text = "Guardar";
            this.Guardar.UseVisualStyleBackColor = false;
            this.Guardar.Click += new System.EventHandler(this.Guardar_Click_1);
            // 
            // NombreProyecto
            // 
            this.NombreProyecto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NombreProyecto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NombreProyecto.Location = new System.Drawing.Point(328, 506);
            this.NombreProyecto.Margin = new System.Windows.Forms.Padding(4);
            this.NombreProyecto.Name = "NombreProyecto";
            this.NombreProyecto.Size = new System.Drawing.Size(228, 27);
            this.NombreProyecto.TabIndex = 103;
            this.NombreProyecto.TextChanged += new System.EventHandler(this.NombreProyecto_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(226, 467);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(385, 29);
            this.label3.TabIndex = 102;
            this.label3.Text = "Ingrese el nombre del proyecto:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(387, 98);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(297, 31);
            this.label2.TabIndex = 101;
            this.label2.Text = "Creador de propuesta";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(131, 34);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(235, 111);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 99;
            this.pictureBox1.TabStop = false;
            // 
            // folio_ProyectosTableAdapter
            // 
            this.folio_ProyectosTableAdapter.ClearBeforeFill = true;
            // 
            // cBR_Folio_Rehabilitacion
            // 
            this.cBR_Folio_Rehabilitacion.DataSetName = "CBR_Folio_Rehabilitacion";
            this.cBR_Folio_Rehabilitacion.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // folioRehabilitacionesBindingSource
            // 
            this.folioRehabilitacionesBindingSource.DataMember = "Folio_Rehabilitaciones";
            this.folioRehabilitacionesBindingSource.DataSource = this.cBR_Folio_Rehabilitacion;
            // 
            // folio_RehabilitacionesTableAdapter
            // 
            this.folio_RehabilitacionesTableAdapter.ClearBeforeFill = true;
            // 
            // Tipo
            // 
            this.Tipo.FormattingEnabled = true;
            this.Tipo.Items.AddRange(new object[] {
            "",
            "Proyecto Compacta",
            "Proyecto Alto Flujo",
            "Proyecto Industrial y Potabiliza",
            "Proyectos INOX"});
            this.Tipo.Location = new System.Drawing.Point(474, 184);
            this.Tipo.Margin = new System.Windows.Forms.Padding(4);
            this.Tipo.Name = "Tipo";
            this.Tipo.Size = new System.Drawing.Size(239, 24);
            this.Tipo.TabIndex = 118;
            this.Tipo.SelectedIndexChanged += new System.EventHandler(this.Tipo_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(617, 240);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 24);
            this.label7.TabIndex = 119;
            this.label7.Text = "Capacidad:";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(598, 278);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(154, 27);
            this.textBox1.TabIndex = 120;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Crea_Rehabilitacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(889, 622);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Tipo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.Proyecto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Folio);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.norma);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Cancelar);
            this.Controls.Add(this.Guardar);
            this.Controls.Add(this.NombreProyecto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Crea_Rehabilitacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crea_Rehabilitacion";
            this.Load += new System.EventHandler(this.Crea_Rehabilitacion_Load);
    
    
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cBR_Folio_Rehabilitacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.folioRehabilitacionesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox Proyecto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Folio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox norma;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Cancelar;
        private System.Windows.Forms.Button Guardar;
        private System.Windows.Forms.TextBox NombreProyecto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Folio_Proyectos folio_Proyectos;
        private System.Windows.Forms.BindingSource folioProyectosBindingSource;
        private Folio_ProyectosTableAdapters.Folio_ProyectosTableAdapter folio_ProyectosTableAdapter;
        private CBR_Folio_Rehabilitacion cBR_Folio_Rehabilitacion;
        private System.Windows.Forms.BindingSource folioRehabilitacionesBindingSource;
        private CBR_Folio_RehabilitacionTableAdapters.Folio_RehabilitacionesTableAdapter folio_RehabilitacionesTableAdapter;
        private System.Windows.Forms.ComboBox Tipo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox1;
    }
}