namespace CBR_ADMIN.Administracion
{
    partial class Genera_AM
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
            this.Generar = new System.Windows.Forms.Button();
            this.CB_Proceso = new System.Windows.Forms.ComboBox();
            this.procesosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cBR_Procesos = new CBR_ADMIN.CBR_Procesos();
            this.Descrip = new System.Windows.Forms.RichTextBox();
            this.FechaReporte = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.procesosTableAdapter = new CBR_ADMIN.CBR_ProcesosTableAdapters.ProcesosTableAdapter();
            this.CB_Dep = new System.Windows.Forms.ComboBox();
            this.departamentosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cBR_Departamento = new CBR_ADMIN.CBR_Departamento();
            this.departamentosTableAdapter = new CBR_ADMIN.CBR_DepartamentoTableAdapters.DepartamentosTableAdapter();
            this.cBR_No_Oportunidad = new CBR_ADMIN.CBR_No_Oportunidad();
            this.cBR_No_Accion_Usuarios = new CBR_ADMIN.CBR_No_Accion_Usuarios();
            this.noAccionusuarioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.no_Accion_usuarioTableAdapter = new CBR_ADMIN.CBR_No_Accion_UsuariosTableAdapters.No_Accion_usuarioTableAdapter();
            this.CB_Apell1 = new System.Windows.Forms.ComboBox();
            this.CB_Nomb1 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.opMejoraBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.op_MejoraTableAdapter = new CBR_ADMIN.CBR_No_OportunidadTableAdapters.Op_MejoraTableAdapter();
            this.cBR_Login_Dep = new CBR_ADMIN.CBR_Login_Dep();
            this.loginDepartamentosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.login_DepartamentosTableAdapter = new CBR_ADMIN.CBR_Login_DepTableAdapters.Login_DepartamentosTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.procesosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cBR_Procesos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.departamentosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cBR_Departamento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cBR_No_Oportunidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cBR_No_Accion_Usuarios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.noAccionusuarioBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.opMejoraBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cBR_Login_Dep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginDepartamentosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // Generar
            // 
            this.Generar.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.Generar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Generar.Location = new System.Drawing.Point(419, 329);
            this.Generar.Name = "Generar";
            this.Generar.Size = new System.Drawing.Size(126, 29);
            this.Generar.TabIndex = 41;
            this.Generar.Text = "Generar";
            this.Generar.UseVisualStyleBackColor = false;
            this.Generar.Click += new System.EventHandler(this.Generar_Click);
            // 
            // CB_Proceso
            // 
            this.CB_Proceso.DataSource = this.procesosBindingSource;
            this.CB_Proceso.DisplayMember = "Proceso";
            this.CB_Proceso.FormattingEnabled = true;
            this.CB_Proceso.Location = new System.Drawing.Point(172, 281);
            this.CB_Proceso.Margin = new System.Windows.Forms.Padding(2);
            this.CB_Proceso.Name = "CB_Proceso";
            this.CB_Proceso.Size = new System.Drawing.Size(113, 21);
            this.CB_Proceso.TabIndex = 33;
            this.CB_Proceso.ValueMember = "Proceso";
            // 
            // procesosBindingSource
            // 
            this.procesosBindingSource.DataMember = "Procesos";
            this.procesosBindingSource.DataSource = this.cBR_Procesos;
            // 
            // cBR_Procesos
            // 
            this.cBR_Procesos.DataSetName = "CBR_Procesos";
            this.cBR_Procesos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Descrip
            // 
            this.Descrip.Location = new System.Drawing.Point(182, 88);
            this.Descrip.Margin = new System.Windows.Forms.Padding(2);
            this.Descrip.Name = "Descrip";
            this.Descrip.Size = new System.Drawing.Size(198, 93);
            this.Descrip.TabIndex = 31;
            this.Descrip.Text = "";
            // 
            // FechaReporte
            // 
            this.FechaReporte.CustomFormat = "##-##-##";
            this.FechaReporte.Location = new System.Drawing.Point(532, 96);
            this.FechaReporte.Margin = new System.Windows.Forms.Padding(2);
            this.FechaReporte.Name = "FechaReporte";
            this.FechaReporte.Size = new System.Drawing.Size(154, 20);
            this.FechaReporte.TabIndex = 29;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label6.Location = new System.Drawing.Point(153, 249);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(163, 18);
            this.label6.TabIndex = 27;
            this.label6.Text = "Proceso que reporta";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(189, 64);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(233, 18);
            this.label2.TabIndex = 23;
            this.label2.Text = "Descripcion de la oportunidad";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(313, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(320, 24);
            this.label1.TabIndex = 22;
            this.label1.Text = "Generacion de Accion de Mejora";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(582, 63);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 18);
            this.label3.TabIndex = 24;
            this.label3.Text = "Fecha:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // procesosTableAdapter
            // 
            this.procesosTableAdapter.ClearBeforeFill = true;
            // 
            // CB_Dep
            // 
            this.CB_Dep.DataSource = this.departamentosBindingSource;
            this.CB_Dep.DisplayMember = "Departamento";
            this.CB_Dep.FormattingEnabled = true;
            this.CB_Dep.Location = new System.Drawing.Point(585, 281);
            this.CB_Dep.Margin = new System.Windows.Forms.Padding(2);
            this.CB_Dep.Name = "CB_Dep";
            this.CB_Dep.Size = new System.Drawing.Size(113, 21);
            this.CB_Dep.TabIndex = 43;
            this.CB_Dep.ValueMember = "Departamento";
            // 
            // departamentosBindingSource
            // 
            this.departamentosBindingSource.DataMember = "Departamentos";
            this.departamentosBindingSource.DataSource = this.cBR_Departamento;
            // 
            // cBR_Departamento
            // 
            this.cBR_Departamento.DataSetName = "CBR_Departamento";
            this.cBR_Departamento.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // departamentosTableAdapter
            // 
            this.departamentosTableAdapter.ClearBeforeFill = true;
            // 
            // cBR_No_Oportunidad
            // 
            this.cBR_No_Oportunidad.DataSetName = "CBR_No_Oportunidad";
            this.cBR_No_Oportunidad.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cBR_No_Accion_Usuarios
            // 
            this.cBR_No_Accion_Usuarios.DataSetName = "CBR_No_Accion_Usuarios";
            this.cBR_No_Accion_Usuarios.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // noAccionusuarioBindingSource
            // 
            this.noAccionusuarioBindingSource.DataMember = "No_Accion_usuario";
            this.noAccionusuarioBindingSource.DataSource = this.cBR_No_Accion_Usuarios;
            // 
            // no_Accion_usuarioTableAdapter
            // 
            this.no_Accion_usuarioTableAdapter.ClearBeforeFill = true;
            // 
            // CB_Apell1
            // 
            this.CB_Apell1.DataSource = this.loginDepartamentosBindingSource;
            this.CB_Apell1.DisplayMember = "Apellido";
            this.CB_Apell1.FormattingEnabled = true;
            this.CB_Apell1.Location = new System.Drawing.Point(489, 281);
            this.CB_Apell1.Margin = new System.Windows.Forms.Padding(2);
            this.CB_Apell1.Name = "CB_Apell1";
            this.CB_Apell1.Size = new System.Drawing.Size(92, 21);
            this.CB_Apell1.TabIndex = 65;
            this.CB_Apell1.ValueMember = "Apellido";
            // 
            // CB_Nomb1
            // 
            this.CB_Nomb1.DataSource = this.loginDepartamentosBindingSource;
            this.CB_Nomb1.DisplayMember = "Nombre";
            this.CB_Nomb1.FormattingEnabled = true;
            this.CB_Nomb1.Location = new System.Drawing.Point(393, 281);
            this.CB_Nomb1.Margin = new System.Windows.Forms.Padding(2);
            this.CB_Nomb1.Name = "CB_Nomb1";
            this.CB_Nomb1.Size = new System.Drawing.Size(92, 21);
            this.CB_Nomb1.TabIndex = 64;
            this.CB_Nomb1.ValueMember = "Nombre";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label7.Location = new System.Drawing.Point(494, 247);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 18);
            this.label7.TabIndex = 63;
            this.label7.Text = "Apellido";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label11.Location = new System.Drawing.Point(403, 247);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 18);
            this.label11.TabIndex = 62;
            this.label11.Text = "Nombre";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(384, 221);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(281, 18);
            this.label4.TabIndex = 61;
            this.label4.Text = "Usuario Responsable/Departamento";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // opMejoraBindingSource
            // 
            this.opMejoraBindingSource.DataMember = "Op_Mejora";
            this.opMejoraBindingSource.DataSource = this.cBR_No_Oportunidad;
            // 
            // op_MejoraTableAdapter
            // 
            this.op_MejoraTableAdapter.ClearBeforeFill = true;
            // 
            // cBR_Login_Dep
            // 
            this.cBR_Login_Dep.DataSetName = "CBR_Login_Dep";
            this.cBR_Login_Dep.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // loginDepartamentosBindingSource
            // 
            this.loginDepartamentosBindingSource.DataMember = "Login_Departamentos";
            this.loginDepartamentosBindingSource.DataSource = this.cBR_Login_Dep;
            // 
            // login_DepartamentosTableAdapter
            // 
            this.login_DepartamentosTableAdapter.ClearBeforeFill = true;
            // 
            // Genera_AM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.CB_Apell1);
            this.Controls.Add(this.CB_Nomb1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CB_Dep);
            this.Controls.Add(this.Generar);
            this.Controls.Add(this.CB_Proceso);
            this.Controls.Add(this.Descrip);
            this.Controls.Add(this.FechaReporte);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Genera_AM";
            this.Size = new System.Drawing.Size(910, 576);
            this.Load += new System.EventHandler(this.Genera_AM_Load);
            ((System.ComponentModel.ISupportInitialize)(this.procesosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cBR_Procesos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.departamentosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cBR_Departamento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cBR_No_Oportunidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cBR_No_Accion_Usuarios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.noAccionusuarioBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.opMejoraBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cBR_Login_Dep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginDepartamentosBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Generar;
        private System.Windows.Forms.ComboBox CB_Proceso;
        private System.Windows.Forms.RichTextBox Descrip;
        private System.Windows.Forms.DateTimePicker FechaReporte;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingSource procesosBindingSource;
        private CBR_Procesos cBR_Procesos;
        private CBR_ProcesosTableAdapters.ProcesosTableAdapter procesosTableAdapter;

        private System.Windows.Forms.ComboBox CB_Dep;
        private System.Windows.Forms.BindingSource departamentosBindingSource;
        private CBR_Departamento cBR_Departamento;
        private CBR_DepartamentoTableAdapters.DepartamentosTableAdapter departamentosTableAdapter;
        private CBR_No_Oportunidad cBR_No_Oportunidad;
        private CBR_No_Accion_Usuarios cBR_No_Accion_Usuarios;
        private System.Windows.Forms.BindingSource noAccionusuarioBindingSource;
        private CBR_No_Accion_UsuariosTableAdapters.No_Accion_usuarioTableAdapter no_Accion_usuarioTableAdapter;
        private System.Windows.Forms.BindingSource oportunidadesdeMejora2BindingSource;
        private System.Windows.Forms.ComboBox CB_Apell1;
        private System.Windows.Forms.ComboBox CB_Nomb1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.BindingSource opMejoraBindingSource;
        private CBR_No_OportunidadTableAdapters.Op_MejoraTableAdapter op_MejoraTableAdapter;
        private System.Windows.Forms.BindingSource loginDepartamentosBindingSource;
        private CBR_Login_Dep cBR_Login_Dep;
        private CBR_Login_DepTableAdapters.Login_DepartamentosTableAdapter login_DepartamentosTableAdapter;
    }
}
