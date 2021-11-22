using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controlador;

namespace CBR_ADMIN.Administracion
{
    public partial class CargaNCmasivo : UserControl
    {
        private static CargaNCmasivo _instance;
        public static CargaNCmasivo Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new CargaNCmasivo();
                return _instance;
            }
        }
        public CargaNCmasivo()
        {
            InitializeComponent();
        }

        private void Btn_cargaExcelNPExla_Click(object sender, EventArgs e)
        {
            try
            {
                string loadfile = "";

                //creamos un objeto OpenDialog que es un cuadro de dialogo para buscar archivos
                OpenFileDialog dialog = new OpenFileDialog();

                dialog.Filter = "Archivos de Excel (*.xls;*.xlsx)|*.xls;*.xlsx"; //le indicamos el tipo de filtro en este caso que busque
                                                                                 //solo los archivos excel
                dialog.Title = "Seleccione el archivo de Excel";//le damos un titulo a la ventana
                dialog.FileName = string.Empty;//inicializamos con vacio el nombre del archivo

                //si al seleccionar el archivo damos Ok
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    loadfile = dialog.FileName;
                    String Hoja = "";
                    CargarFromExcel cargarE = new CargarFromExcel();
                    Hoja = "Sheet1"; //la variable hoja tendra el valor del textbox donde colocamos el nombre de la hoja
                    cargarE.LLenarGrid(DG_NC_Temporal, loadfile, Hoja); //se manda a llamar al metodo
                    DG_NC_Temporal.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; //se ajustan las columnas al ancho del DataGridview para que no quede espacio en blanco (opcional)
                    //CREAMOS UN DATATABLE Y LO LLEMANOS CON EL DATASOURCE DE GRID PARA MANDARLO A LA BASE DE DATOS
                    DataTable datatable = (DataTable)(DG_NC_Temporal.DataSource);
                    CargarToSQL_General CargarToSQL = new CargarToSQL_General();
                    //OBTENEMOS LA INFORMACION          
                    DG_NC_Temporal.DataSource = CargarToSQL.CargaNC(datatable);
                    MessageBox.Show("Informacion Cargada Correctamente");
                    this.no_ConformidadesTableAdapter.Fill(this.cBR_No_Conf.No_Conformidades);

                }
                else
                {
                    MessageBox.Show("Cancelado");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);

            }
        }
    }
}
