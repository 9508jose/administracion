using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using CBR_ADMIN;

namespace CapturaPantalla
{
    public partial class formCapturarPantalla : Form
    {
        public Bitmap objBitmap;
        public formCapturarPantalla()
        {
            InitializeComponent();
        }



        private void bSelDestino_Click(object sender, EventArgs e)
        {
            string formatoImagen = "";
            formatoImagen = lsFormatoImagen.Text;

            if (formatoImagen != "")
            {
                dlGuardarImagen.Title = "Selección de carpeta y fichero de " +
                    "imagen donde se guardará la captura";
                dlGuardarImagen.Filter = "Imágenes " + formatoImagen +
                    " (*." + formatoImagen.ToLower() + ")|*." + 
                    formatoImagen.ToLower() +
                    "|Todos los ficheros (*.*)|*.*";
                dlGuardarImagen.DefaultExt = formatoImagen.ToLower();
                dlGuardarImagen.FilterIndex = 1;
                if (dlGuardarImagen.ShowDialog() == DialogResult.OK)
                {
                    txtUbicacionCaptura.Text = dlGuardarImagen.FileName;
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar el formato para la imagen.", 
                    "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lsFormatoImagen.Focus();
            }
        }

        private void btGuardar_Click(object sender, EventArgs e)
        {
            if (imgCaptura.Image != null)
            {
                string formatoImagen = "";
                formatoImagen = lsFormatoImagen.Text;
                if (formatoImagen != "")
                {
                    if (txtUbicacionCaptura.Text != "")
                    {
                        //guardarmos la imagen en el formato indicado por el usuario
                        if (System.IO.Directory.Exists(
                            System.IO.Path.GetDirectoryName(txtUbicacionCaptura.Text)))
                        {
                            if (formatoImagen == "PNG")
                            {
                                imgCaptura.Image.Save(txtUbicacionCaptura.Text, 
                                    ImageFormat.Png);
                            }
                            if (formatoImagen == "BMP")
                            {
                                imgCaptura.Image.Save(txtUbicacionCaptura.Text, 
                                    ImageFormat.Bmp);
                            }
                            if (formatoImagen == "JPEG")
                            {
                                imgCaptura.Image.Save(txtUbicacionCaptura.Text, 
                                    ImageFormat.Jpeg);
                            }
                            if (formatoImagen == "TIFF")
                            {
                                imgCaptura.Image.Save(txtUbicacionCaptura.Text, 
                                    ImageFormat.Tiff);
                            }
                            if (formatoImagen == "WMF")
                            {
                                imgCaptura.Image.Save(txtUbicacionCaptura.Text, 
                                    ImageFormat.Wmf);
                            }
                     
                        }
                        else
                        {
                            MessageBox.Show("La carpeta de destino de la imagen " +
                                "capturada debe existir.", "Atención",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            bSelDestino.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe indicar una carpeta y nombre de fichero " +
                            "para guardar la imagen capturada.", "Atención",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        bSelDestino.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar el formato para la imagen. ", 
                        "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    lsFormatoImagen.Focus();
                }
            }
            else
            {
                MessageBox.Show("Debe capturar previamente una imagen.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
              
            }
        }


        private void lsFormatoImagen_SelectedValueChanged(object sender, 
            EventArgs e)
        {
            //si el usuario cambia el formato de la imagen destino
            //y ya hay algo escrito en txtUbicacionCaptura, 
            //cambiaremos la extensión del fichero por la 
            //seleccionada en el formato
            string ficheroCaptura = "";
            ficheroCaptura = txtUbicacionCaptura.Text;
            if (ficheroCaptura != "")
            {
                ficheroCaptura = System.IO.Path.GetDirectoryName(ficheroCaptura) + 
                    System.IO.Path.DirectorySeparatorChar + 
                    System.IO.Path.GetFileNameWithoutExtension(ficheroCaptura) + 
                    "." + lsFormatoImagen.Text.ToLower();
                txtUbicacionCaptura.Text = ficheroCaptura;
            }
        }

        private void formCapturarPantalla_Load(object sender, EventArgs e)
        {
            imgCaptura.SizeMode = PictureBoxSizeMode.StretchImage;
            imgCaptura.Image = objBitmap;
            imgCaptura.Visible = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            General21.ActiveForm.Close();
          
        }
    }
}
