using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CBR_ADMIN
{
    public partial class uscTrabajo : UserControl
    {
        private static uscTrabajo _instance;
        public static uscTrabajo Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uscTrabajo();
                return _instance;
            }
        }
        private string ruta = @"G:\SGC\Formatos";
        private Boolean esArchivo = false;
        private string nombreSeleccionado = "";

        public uscTrabajo()
        {
            InitializeComponent();
        }

        private void uscTrabajo_Load(object sender, EventArgs e)
        {
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            txtRuta.Text = ruta;
            cargarArchivosYDirecterios();
        }

        public void cargarArchivosYDirecterios()
        {
            DirectoryInfo listaDeArchivos;
            string rutaTemporal = "";
            FileAttributes atributos;
            try
            {
                if (esArchivo)
                {
                    rutaTemporal = ruta + "\\" + nombreSeleccionado;
                    atributos = File.GetAttributes(rutaTemporal);
                    FileInfo detalles = new FileInfo(rutaTemporal); //La ruta del archivo se manda al FileInfo para conseguir su datos//Consigue los atributos del archivo, para que con esto comparar mas adelante si es un archivo o directorio
                    Process.Start(rutaTemporal);
                }
                else
                {
                    atributos = File.GetAttributes(ruta);  //Consigue los atributos del directorio, para comprobar mas adelante
                }

                if ((atributos & FileAttributes.Directory) == FileAttributes.Directory) //Revisa si es un directorio
                {
                    listaDeArchivos = new DirectoryInfo(ruta);
                    FileInfo[] archivos = listaDeArchivos.GetFiles(); // OBTIENE TODOS LOS ARCHIVOS
                    DirectoryInfo[] directorios = listaDeArchivos.GetDirectories(); //OBTIENE TODOS LOS DIRECTORIOS

                    lsbExplorador.Clear();


                    var filtradodirec = directorios.Where(f => !f.Attributes.HasFlag(FileAttributes.Hidden));

                    foreach (var f in filtradodirec)
                    {

                        lsbExplorador.Items.Add(f.ToString(), 1);
                    }

                    var filtradoarchivos = archivos.Where(f => !f.Attributes.HasFlag(FileAttributes.Hidden));

                    foreach (var f in filtradoarchivos)
                    {

                        String extension = f.Extension.ToUpper();
                        int index = 0;

                        switch (extension)
                        {
                            case ".DOC":
                            case ".DOCX":
                                index = 2;
                                break;
                            case ".EXE":
                                index = 3;
                                break;
                            case ".PDF":
                                index = 4;
                                break;
                            case ".XLSX":
                            case ".XLS":
                                index = 5;
                                break;
                            case ".JPG":
                            case ".JPEG":
                                index = 6;
                                break;
                            case ".PNG":
                                index = 7;
                                break;
                            case ".TXT":
                                index = 8;
                                break;
                            case ".RAR":
                                index = 9;
                                break;
                            case ".ZIP":
                                index = 10;
                                break;
                            case ".PPT":
                            case ".PPTX":
                                index = 11;
                                break;
                            default:
                                index = 0;
                                break;
                        }

                        lsbExplorador.Items.Add(f.ToString(), index);
                    }

                }
                else
                {
                    lblDatoNombre.Text = this.nombreSeleccionado;
                }
            }
            catch (Exception e)
            {

            }
        }

        public void cargarArchivos() //Si se coloca algo en la ruta nuevo en el enlace nos dirige ahi
        {
            ruta = txtRuta.Text;
            cargarArchivosYDirecterios();
            esArchivo = false;
        }

        private void btnIr_Click(object sender, EventArgs e) //Si se ha click realiza el evento cargarArchivos
        {
            cargarArchivos();
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e) //Seleccionado un objeto
        {
            nombreSeleccionado = e.Item.Text;

            FileAttributes atributos = File.GetAttributes(ruta + @"\" + nombreSeleccionado); //Con esto el archivo/directorio seleccionado se consiguen sus atributos para saber si es un directorio o archivo

            if ((atributos & FileAttributes.Directory) == FileAttributes.Directory) //Se revisa
            {
                esArchivo = false;                       //Si es cierto, no es un archivo es un directorio y se pone en la ruta
                txtRuta.Text = ruta + @"\" + nombreSeleccionado;
            }
            else
            {
                esArchivo = true; //Si es falso, es un archivo
                String rutaTemporal = ruta + "\\" + nombreSeleccionado;
                FileInfo detalles = new FileInfo(rutaTemporal); //La ruta del archivo se manda al FileInfo para conseguir su datos
                lblDatoNombre.Text = detalles.Name;  //Consigue el nombre
                lblDatoTipo.Text = detalles.Extension; //Consigue el tipo
                lblDatoTamaño.Text = BytesAString(detalles.Length);

            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e) //Si se realiza doble click manda al archivo seleccionado, misma funcion que el boton ir, pero en los directorios
        {
            cargarArchivos();
        }

        private void btnCasa_Click(object sender, EventArgs e)
        {
            txtRuta.Text = @"G:\SGC\Formatos";
            cargarArchivos();

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {

            String rutaAnterior = txtRuta.Text;
            if (rutaAnterior != @"G:\SGC\Formatos")
            {
                rutaAnterior = rutaAnterior.Substring(0, rutaAnterior.LastIndexOf(@"\"));
                esArchivo = false;
                txtRuta.Text = rutaAnterior;
                cargarArchivos();
            }
        }

        static String BytesAString(long contBytes) //Metodo para convertir en lo conseguido en file length
        {
            string[] tamaño = { "B", "KB", "MB", "GB", "TB", "PB", "EB" }; //Longs run out around EB
            if (contBytes == 0)
                return "0" + tamaño[0]; //Si es cero retorna 0 B
            long bytes = Math.Abs(contBytes);
            int lugar = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024))); //Determina a cual tamaño ira
            double num = Math.Round(bytes / Math.Pow(1024, lugar), 1);
            return (Math.Sign(contBytes) * num).ToString() + tamaño[lugar];
        }
    }

}