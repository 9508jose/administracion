namespace CBR_ADMIN.Sistema
{
    partial class Password
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Password));
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Guardar = new System.Windows.Forms.Button();
            this.cBR_Login_Dep = new CBR_ADMIN.CBR_Login_Dep();
            this.loginDepartamentosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.login_DepartamentosTableAdapter = new CBR_ADMIN.CBR_Login_DepTableAdapters.Login_DepartamentosTableAdapter();
            this.Contraseña1 = new System.Windows.Forms.TextBox();
            this.Contraseña2 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.cBR_Login_Dep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginDepartamentosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(343, 80);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(360, 37);
            this.label9.TabIndex = 4;
            this.label9.Text = "Cambio de contraseña";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(380, 215);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(286, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "Ingrese su nueva contraseña:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label2.Location = new System.Drawing.Point(383, 325);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(281, 24);
            this.label2.TabIndex = 6;
            this.label2.Text = "Repita su  nueva contraseña:";
            // 
            // Guardar
            // 
            this.Guardar.BackColor = System.Drawing.Color.SlateGray;
            this.Guardar.FlatAppearance.BorderSize = 0;
            this.Guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Guardar.Location = new System.Drawing.Point(435, 459);
            this.Guardar.Margin = new System.Windows.Forms.Padding(2);
            this.Guardar.Name = "Guardar";
            this.Guardar.Size = new System.Drawing.Size(177, 47);
            this.Guardar.TabIndex = 12;
            this.Guardar.Text = "Guardar";
            this.Guardar.UseVisualStyleBackColor = false;
            this.Guardar.Click += new System.EventHandler(this.Guardar_Click);
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
            // Contraseña1
            // 
            this.Contraseña1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.Contraseña1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Contraseña1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Contraseña1.ForeColor = System.Drawing.SystemColors.Info;
            this.Contraseña1.Location = new System.Drawing.Point(433, 264);
            this.Contraseña1.Margin = new System.Windows.Forms.Padding(2);
            this.Contraseña1.Name = "Contraseña1";
            this.Contraseña1.PasswordChar = '*';
            this.Contraseña1.Size = new System.Drawing.Size(181, 22);
            this.Contraseña1.TabIndex = 29;
            this.Contraseña1.Text = "Contraseña";
            this.Contraseña1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Contraseña1.Click += new System.EventHandler(this.Contraseña1_Click);
            // 
            // Contraseña2
            // 
            this.Contraseña2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(80)))));
            this.Contraseña2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Contraseña2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Contraseña2.ForeColor = System.Drawing.SystemColors.Info;
            this.Contraseña2.Location = new System.Drawing.Point(433, 379);
            this.Contraseña2.Margin = new System.Windows.Forms.Padding(2);
            this.Contraseña2.Name = "Contraseña2";
            this.Contraseña2.PasswordChar = '*';
            this.Contraseña2.Size = new System.Drawing.Size(181, 22);
            this.Contraseña2.TabIndex = 30;
            this.Contraseña2.Text = "Contraseña";
            this.Contraseña2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Contraseña2.Click += new System.EventHandler(this.Contraseña2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(341, 117);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(364, 414);
            this.pictureBox1.TabIndex = 31;
            this.pictureBox1.TabStop = false;
            // 
            // Password
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Controls.Add(this.Contraseña2);
            this.Controls.Add(this.Contraseña1);
            this.Controls.Add(this.Guardar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Password";
            this.Size = new System.Drawing.Size(1037, 534);
            ((System.ComponentModel.ISupportInitialize)(this.cBR_Login_Dep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginDepartamentosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Guardar;
        private CBR_Login_Dep cBR_Login_Dep;
        private System.Windows.Forms.BindingSource loginDepartamentosBindingSource;
        private CBR_Login_DepTableAdapters.Login_DepartamentosTableAdapter login_DepartamentosTableAdapter;
        private System.Windows.Forms.TextBox Contraseña1;
        private System.Windows.Forms.TextBox Contraseña2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
