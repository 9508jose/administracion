using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop;
using Microsoft.Office;
using System.Windows.Forms;

namespace Controlador
{
    public class ExportarExcel
    {

        public ExportarExcel()
        {

        }
        public void Exportar(string Hoja, string NombreHoja, DataGridView NombreGrid)
        {
          
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            // creating new WorkBook within Excel application  
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            // creating new Excelsheet in workbook  
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            // see the excel sheet behind the program  

            app.Visible = true;
            // get the reference of first sheet. By default its name is Sheet1.  
            // store its reference to worksheet  
            worksheet = workbook.Sheets[Hoja];
            worksheet = workbook.ActiveSheet;
            // changing the name of active sheet  
            worksheet.Name = NombreHoja;
            // storing header part in Excel  
            for (int i = 1; i < NombreGrid.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = NombreGrid.Columns[i - 1].HeaderText;
           
            }
            // storing Each row and column value to excel sheet  
            for (int i = 0; i < NombreGrid.Rows.Count - 1; i++)
            {
                for (int j = 0; j < NombreGrid.Columns.Count; j++)
                {
                    //worksheet.Cells[i + 2, j + 1] = NombreGrid.Rows[i].Cells[j].Value.ToString();
                    worksheet.Cells[i + 2, j + 1].NumberFormat = "@";
                    worksheet.Cells[i + 2, j + 1] = NombreGrid.Rows[i].Cells[j].Value.ToString();
                }
            }

          
            // save the application  
            //workbook.SaveAs("c:\\Consulta_NP_Origen.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            // Exit from the application  
            //app.Quit();
        }

    }
}
