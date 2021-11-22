namespace CBR_ADMIN.Sistema
{
    partial class Reestablecimiento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Reestablecimiento));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.email = new System.Windows.Forms.ComboBox();
            this.loginDepartamentosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cBR_Login_Dep = new CBR_ADMIN.CBR_Login_Dep();
            this.login_DepartamentosTableAdapter = new CBR_ADMIN.CBR_Login_DepTableAdapters.Login_DepartamentosTableAdapter();
            this.loginRestablecimientoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cBR_Reestablece = new CBR_ADMIN.CBR_Reestablece();
            this.restablecimientoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.restablecimientoTableAdapter = new CBR_ADMIN.CBR_ReestableceTableAdapters.RestablecimientoTableAdapter();
            this.label3 = new System.Windows.Forms.Label();
            this.llave = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.loginDepartamentosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cBR_Login_Dep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginRestablecimientoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cBR_Reestablece)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.restablecimientoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(48, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(294, 71);
            this.label1.TabIndex = 30;
            this.label1.Text = "Reestablecimiento de contraseña";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(19, 80);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(294, 71);
            this.label2.TabIndex = 31;
            this.label2.Text = "Ingrese su correo electronico:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(75, 169);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(170, 25);
            this.button1.TabIndex = 33;
            this.button1.Text = "Enviar correo de recuperacion";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // email
            // 
            this.email.DataSource = this.loginDepartamentosBindingSource;
            this.email.DisplayMember = "Email";
            this.email.FormattingEnabled = true;
            this.email.Location = new System.Drawing.Point(58, 130);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(244, 21);
            this.email.TabIndex = 34;
            this.email.ValueMember = "Email";
            // 
            // loginDepartamentosBindingSource
            // 
            this.loginDepartamentosBindingSource.DataMember = "Login_Departamentos";
            this.loginDepartamentosBindingSource.DataSource = this.cBR_Login_Dep;
            // 
            // cBR_Login_Dep
            // 
            this.cBR_Login_Dep.DataSetName = "CBR_Login_Dep";
            this.cBR_Login_Dep.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // login_DepartamentosTableAdapter
            // 
            this.login_DepartamentosTableAdapter.ClearBeforeFill = true;
            // 
            // cBR_Reestablece
            // 
            this.cBR_Reestablece.DataSetName = "CBR_Reestablece";
            this.cBR_Reestablece.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // restablecimientoBindingSource
            // 
            this.restablecimientoBindingSource.DataMember = "Restablecimiento";
            this.restablecimientoBindingSource.DataSource = this.cBR_Reestablece;
            // 
            // restablecimientoTableAdapter
            // 
            this.restablecimientoTableAdapter.ClearBeforeFill = true;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(23, 197);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(294, 34);
            this.label3.TabIndex = 35;
            this.label3.Text = "Ingrese codigo de verificacion";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // llave
            // 
            this.llave.Location = new System.Drawing.Point(104, 248);
            this.llave.Name = "llave";
            this.llave.Size = new System.Drawing.Size(121, 20);
            this.llave.TabIndex = 36;
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(104, 309);
            this.Password.Name = "Password";
            this.Password.PasswordChar = '*';
            this.Password.Size = new System.Drawing.Size(121, 20);
            this.Password.TabIndex = 37;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(23, 271);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(294, 35);
            this.label4.TabIndex = 38;
            this.label4.Text = "Ingrese Nueva Contraseña";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(104, 353);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(121, 25);
            this.button2.TabIndex = 39;
            this.button2.Text = "Guardar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.Color.Transparent;
            this.checkBox1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.checkBox1.Location = new System.Drawing.Point(237, 312);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(61, 17);
            this.checkBox1.TabIndex = 40;
            this.checkBox1.Text = "Mostrar";
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(309, 353);
            this.pictureBox6.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(26, 25);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 41;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.Click += new System.EventHandler(this.pictureBox6_Click);
            // 
            // Reestablecimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(366, 390);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.llave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.email);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Reestablecimiento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reestablecimiento";
            this.Load += new System.EventHandler(this.Reestablecimiento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.loginDepartamentosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cBR_Login_Dep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginRestablecimientoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cBR_Reestablece)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.restablecimientoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox email;
        private CBR_Login_Dep cBR_Login_Dep;
        private System.Windows.Forms.BindingSource loginDepartamentosBindingSource;
        private CBR_Login_DepTableAdapters.Login_DepartamentosTableAdapter login_DepartamentosTableAdapter;

        private System.Windows.Forms.BindingSource loginRestablecimientoBindingSource;
        private CBR_Reestablece cBR_Reestablece;
        private System.Windows.Forms.BindingSource restablecimientoBindingSource;
        private CBR_ReestableceTableAdapters.RestablecimientoTableAdapter restablecimientoTableAdapter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox llave;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.PictureBox pictureBox6;
    }
}