using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using CBR_ADMIN.Sistema;

namespace CBR_ADMIN.Administracion
{
    public partial class Detalle : UserControl
    {


        private static Detalle _instance;
        public static Detalle Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Detalle();
                return _instance;
            }
        }

        public Detalle()
        {
            InitializeComponent();
        }

        private void Generar_Click(object sender, EventArgs e)
        {
          
      

            DialogResult Resultado;
            Resultado = MessageBox.Show("Está seguro que desea descargar Masico de No conformidades ", "Confirmación", MessageBoxButtons.YesNo);
            if (Resultado == DialogResult.Yes)
            {
                
                try
                {
                    SaveFileDialog Fichero = new SaveFileDialog();
                    Fichero.Filter = "Archivos de Excel (*.xls)|*.xls";
                    Fichero.Title = "Seleccione el archivo de Excel";//le damos un titulo a la ventana
                    Fichero.FileName = string.Empty;
                    if (Fichero.ShowDialog() == DialogResult.OK)
                    {
                        Microsoft.Office.Interop.Excel.Application aplicacion;
                        Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
                        Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
                        Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo2;
                        Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo3;
                        Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo4;
                        Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo5;
                        Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo6;
                        Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo7;
                        Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo8;
                        aplicacion = new Microsoft.Office.Interop.Excel.Application();
                        libros_trabajo = aplicacion.Workbooks.Add(Type.Missing);
                        // libros_trabajo1 = aplicacion.Workbooks.Add(Type.Missing);
                        hoja_trabajo = null;
                        hoja_trabajo2 = null;
                        hoja_trabajo3 = null;
                        hoja_trabajo4 = null;
                        hoja_trabajo5 = null;
                        hoja_trabajo6 = null;
                        hoja_trabajo7 = null;
                        hoja_trabajo = libros_trabajo.Sheets["Hoja1"];
                        hoja_trabajo = libros_trabajo.ActiveSheet;
                        hoja_trabajo2 = libros_trabajo.Sheets["Hoja1"];
                        libros_trabajo.Sheets.Add(hoja_trabajo2);
                        hoja_trabajo2 = libros_trabajo.ActiveSheet;
                        hoja_trabajo3 = libros_trabajo.Sheets["Hoja1"];
                        libros_trabajo.Sheets.Add(hoja_trabajo3);
                        hoja_trabajo3 = libros_trabajo.ActiveSheet;
                        hoja_trabajo4 = libros_trabajo.Sheets["Hoja1"];
                        libros_trabajo.Sheets.Add(hoja_trabajo4);
                        hoja_trabajo4 = libros_trabajo.ActiveSheet;
                        hoja_trabajo5 = libros_trabajo.Sheets["Hoja1"];
                        libros_trabajo.Sheets.Add(hoja_trabajo5);
                        hoja_trabajo5 = libros_trabajo.ActiveSheet;
                        hoja_trabajo6 = libros_trabajo.Sheets["Hoja1"];
                        libros_trabajo.Sheets.Add(hoja_trabajo6);
                        hoja_trabajo6 = libros_trabajo.ActiveSheet;
                        hoja_trabajo7 = libros_trabajo.Sheets["Hoja1"];
                        libros_trabajo.Sheets.Add(hoja_trabajo7);
                        hoja_trabajo7 = libros_trabajo.ActiveSheet;
                        hoja_trabajo8 = libros_trabajo.Sheets["Hoja1"];
                        libros_trabajo.Sheets.Add(hoja_trabajo8);
                        hoja_trabajo8 = libros_trabajo.ActiveSheet;


                        for (int i = 1; i < DG_Acumluado_CerradasMes.Columns.Count + 1; i++)
                        { hoja_trabajo.Cells[1, i] = DG_Acumluado_CerradasMes.Columns[i - 1].HeaderText; }
                        //////////////////////////////////////////////////////////////////////////////////////////////
                        for (int i = 0; i < DG_Acumluado_CerradasMes.Rows.Count - 1; i++)
                        {
                            for (int j = 0; j < DG_Acumluado_CerradasMes.Columns.Count; j++)
                            {
                                hoja_trabajo.Cells[i + 2, j + 1].NumberFormat = "@";
                                hoja_trabajo.Cells[i + 2, j + 1] = DG_Acumluado_CerradasMes.Rows[i].Cells[j].Value.ToString();
                            }
                        }
                        for (int i = 1; i < DG_Acumluado_CerradasMes.Columns.Count + 1; i++)
                        { hoja_trabajo.Cells[1, i] = DG_Acumluado_CerradasMes.Columns[i - 1].HeaderText; }

                        //////////////////////////////////////////////////////////////////////////////////////////////End tabla1


                        for (int i = 1; i < DG_Acumulado_AbiertasMes.Columns.Count + 1; i++)
                        { hoja_trabajo2.Cells[1, i] = DG_Acumulado_AbiertasMes.Columns[i - 1].HeaderText; }

                        //////////////////////////////////////////////////////////////////////////////////////////////
                        // storing Each row and column value to excel sheet  
                        for (int i = 0; i < DG_Acumulado_AbiertasMes.Rows.Count - 1; i++)
                        {
                            for (int j = 0; j < DG_Acumulado_AbiertasMes.Columns.Count; j++)
                            {
                                hoja_trabajo2.Cells[i + 2, j + 1].NumberFormat = "@";
                                hoja_trabajo2.Cells[i + 2, j + 1] = DG_Acumulado_AbiertasMes.Rows[i].Cells[j].Value.ToString();
                            }
                        }

                        for (int i = 1; i < DG_Acumulado_AbiertasMes.Columns.Count + 1; i++)
                        {
                            hoja_trabajo2.Cells[1, i] = DG_Acumulado_AbiertasMes.Columns[i - 1].HeaderText;
                        }
                        /////////////////////////////////////////////////////////////////////////////////////////////////End table2

                        for (int i = 1; i < DG_Acumulado_Año.Columns.Count + 1; i++)
                        { hoja_trabajo3.Cells[1, i] = DG_Acumulado_Año.Columns[i - 1].HeaderText; }

                        //////////////////////////////////////////////////////////////////////////////////////////////
                        // storing Each row and column value to excel sheet  
                        for (int i = 0; i < DG_Acumulado_Año.Rows.Count - 1; i++)
                        {
                            for (int j = 0; j < DG_Acumulado_Año.Columns.Count; j++)
                            {
                                hoja_trabajo3.Cells[i + 2, j + 1].NumberFormat = "@";
                                hoja_trabajo3.Cells[i + 2, j + 1] = DG_Acumulado_Año.Rows[i].Cells[j].Value.ToString();
                            }
                        }

                        for (int i = 1; i < DG_Acumulado_Año.Columns.Count + 1; i++)
                        {
                            hoja_trabajo3.Cells[1, i] = DG_Acumulado_Año.Columns[i - 1].HeaderText;
                        }
                        ///////////////////////////////////////////////////////////////////////////////////////////////////End table3
                        ///
                        for (int i = 1; i < DG_Diferencias.Columns.Count + 1; i++)
                        { hoja_trabajo4.Cells[1, i] = DG_Diferencias.Columns[i - 1].HeaderText; }

                        //////////////////////////////////////////////////////////////////////////////////////////////
                        // storing Each row and column value to excel sheet  
                        for (int i = 0; i < DG_Diferencias.Rows.Count - 1; i++)
                        {
                            for (int j = 0; j < DG_Diferencias.Columns.Count; j++)
                            {
                                hoja_trabajo4.Cells[i + 2, j + 1].NumberFormat = "@";
                                hoja_trabajo4.Cells[i + 2, j + 1] = DG_Diferencias.Rows[i].Cells[j].Value.ToString();
                            }
                        }

                        for (int i = 1; i < DG_Diferencias.Columns.Count + 1; i++)
                        {
                            hoja_trabajo4.Cells[1, i] = DG_Diferencias.Columns[i - 1].HeaderText;
                        }
                        ///////////////////////////////////////////////////////////////////////////////////////////////////End table4
                        ///
                        for (int i = 1; i < DG_Abiertas_Año.Columns.Count + 1; i++)
                        { hoja_trabajo5.Cells[1, i] = DG_Abiertas_Año.Columns[i - 1].HeaderText; }

                        //////////////////////////////////////////////////////////////////////////////////////////////
                        // storing Each row and column value to excel sheet  
                        for (int i = 0; i < DG_Abiertas_Año.Rows.Count - 1; i++)
                        {
                            for (int j = 0; j < DG_Abiertas_Año.Columns.Count; j++)
                            {
                                hoja_trabajo5.Cells[i + 2, j + 1].NumberFormat = "@";
                                hoja_trabajo5.Cells[i + 2, j + 1] = DG_Abiertas_Año.Rows[i].Cells[j].Value.ToString();
                            }
                        }

                        for (int i = 1; i < DG_Abiertas_Año.Columns.Count + 1; i++)
                        {
                            hoja_trabajo5.Cells[1, i] = DG_Abiertas_Año.Columns[i - 1].HeaderText;
                        }
                        ///////////////////////////////////////////////////////////////////////////////////////////////////End table5
                        ///
                        for (int i = 1; i < DG_Cerradas_Año.Columns.Count + 1; i++)
                        { hoja_trabajo6.Cells[1, i] = DG_Cerradas_Año.Columns[i - 1].HeaderText; }

                        //////////////////////////////////////////////////////////////////////////////////////////////
                        // storing Each row and column value to excel sheet  
                        for (int i = 0; i < DG_Cerradas_Año.Rows.Count - 1; i++)
                        {
                            for (int j = 0; j < DG_Cerradas_Año.Columns.Count; j++)
                            {
                                hoja_trabajo6.Cells[i + 2, j + 1].NumberFormat = "@";
                                hoja_trabajo6.Cells[i + 2, j + 1] = DG_Cerradas_Año.Rows[i].Cells[j].Value.ToString();
                            }
                        }

                        for (int i = 1; i < DG_Cerradas_Año.Columns.Count + 1; i++)
                        {
                            hoja_trabajo6.Cells[1, i] = DG_Cerradas_Año.Columns[i - 1].HeaderText;
                        }
                        ///////////////////////////////////////////////////////////////////////////////////////////////////End table6
                        ///

                        for (int i = 1; i < DG_Verificacion.Columns.Count + 1; i++)
                        { hoja_trabajo7.Cells[1, i] = DG_Verificacion.Columns[i - 1].HeaderText; }

                        //////////////////////////////////////////////////////////////////////////////////////////////
                        // storing Each row and column value to excel sheet  
                        for (int i = 0; i < DG_Verificacion.Rows.Count - 1; i++)
                        {
                            for (int j = 0; j < DG_Verificacion.Columns.Count; j++)
                            {
                                hoja_trabajo7.Cells[i + 2, j + 1].NumberFormat = "@";
                                hoja_trabajo7.Cells[i + 2, j + 1] = DG_Verificacion.Rows[i].Cells[j].Value.ToString();
                            }
                        }

                        for (int i = 1; i < DG_Verificacion.Columns.Count + 1; i++)
                        {
                            hoja_trabajo7.Cells[1, i] = DG_Verificacion.Columns[i - 1].HeaderText;
                        }
                        ///////////////////////////////////////////////////////////////////////////////////////////////////End table7

                        //hoja_trabajo2.Copy(Type.Missing);
                        //hoja_trabajo.Select();


                        //  hoja_trabajo2.Copy(Type.Missing);
                        //Microsoft.Office.Interop.Excel.Range envia1 = hoja_trabajo2.Range["A:B"];

                        //          hoja_trabajo.Paste(envia1);

                        //hoja_trabajo2.Cells[1, 1] = "Reporte Masivo";
                        Microsoft.Office.Interop.Excel.Range to = hoja_trabajo8.Range["C:F"];
                        Microsoft.Office.Interop.Excel.Range from = hoja_trabajo.Range["A:D"];
                        from.Copy(to);
                        Microsoft.Office.Interop.Excel.Range to2 = hoja_trabajo8.Range["G:J"];
                        Microsoft.Office.Interop.Excel.Range from2 = hoja_trabajo2.Range["A:D"];
                        from2.Copy(to2);
                        Microsoft.Office.Interop.Excel.Range to3 = hoja_trabajo8.Range["A:B"];
                        Microsoft.Office.Interop.Excel.Range from3 = hoja_trabajo3.Range["A:B"];
                        from3.Copy(to3);
                        Microsoft.Office.Interop.Excel.Range to4 = hoja_trabajo8.Range["K:M"];
                        Microsoft.Office.Interop.Excel.Range from4 = hoja_trabajo4.Range["A:C"];
                        from4.Copy(to4);
                        Microsoft.Office.Interop.Excel.Range to5 = hoja_trabajo8.Range["N:P"];
                        Microsoft.Office.Interop.Excel.Range from5 = hoja_trabajo5.Range["A:C"];
                        from5.Copy(to5);
                        Microsoft.Office.Interop.Excel.Range to6 = hoja_trabajo8.Range["Q:S"];
                        Microsoft.Office.Interop.Excel.Range from6 = hoja_trabajo6.Range["A:C"];
                        from6.Copy(to6);
                        Microsoft.Office.Interop.Excel.Range to7 = hoja_trabajo8.Range["T:V"];
                        Microsoft.Office.Interop.Excel.Range from7 = hoja_trabajo7.Range["A:C"];
                        from7.Copy(to7);

                        libros_trabajo.Worksheets[1].Name = "Acumulado Mes Abiertas";
                        libros_trabajo.Worksheets[2].Name = "Acumulado Por Año";
                        libros_trabajo.Worksheets[3].Name = "Diferencias";
                        libros_trabajo.Worksheets[4].Name = "Total Abiertas Año actual";
                        libros_trabajo.Worksheets[5].Name = "Total Cerradas Año actual";
                        libros_trabajo.Worksheets[6].Name = "En estado de Verifiacion";
                        libros_trabajo.Worksheets[7].Name = "Informe Detallado";
                        libros_trabajo.Worksheets[8].Name = "Acumulado Mes Cerradas";
                        libros_trabajo.SaveAs(Fichero.FileName,
                        Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);

                        libros_trabajo.Close(true);
                        aplicacion.Quit();
                   
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.ToString());
                }
            }
            else if (Resultado == DialogResult.No)
            {

                MessageBox.Show("Operacion Cancelada"); 
            }

           
        }
        //private void MostrarCuadroInicio()
        //{
        //    Loading Cargando = new Loading();
        //    Cargando.ShowDialog();

        //}

        private void Detalle_Load(object sender, EventArgs e)
        {
            //ThreadStart proceso = new ThreadStart(MostrarCuadroInicio);
            //Thread hilo = new Thread(proceso);

            //hilo.Start();     hilo.Join(200);
            this.nC_abiertas_AñoTableAdapter.Fill(cBR_NC_Acumulado_Año.NC_abiertas_Año);
            this.nC_abiertas_Departamento_MesTableAdapter.FillBy(cBR_NC_Abiertas_Mes.NC_abiertas_Departamento_Mes);
            this.nC_abiertas_Departamento__ActualTableAdapter.Fill(cBR_NC_abiertas_año_actual.NC_abiertas_Departamento__Actual);
            this.nC_cerradas_Departamento_MesTableAdapter.FillBy(cBR_NC_Cerradas_Mes.NC_cerradas_Departamento_Mes);
            this.nC_cerradas_Departamento__ActualTableAdapter.Fill(cBR_Nc_cerradas_año_actual.NC_cerradas_Departamento__Actual);
            this.nC_Diferencia_CerrarTableAdapter.Fill(cBR_Nc_Diferencia.NC_Diferencia_Cerrar);
            this.nC_Verificacion_DepartamentosTableAdapter.FillBy(cBR_Verificacion.NC_Verificacion_Departamentos);
            //hilo.Abort();

        }

    }
}
