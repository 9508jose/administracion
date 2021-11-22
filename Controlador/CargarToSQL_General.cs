using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using Modelo;

namespace Controlador
{
   public class CargarToSQL_General
    {
        ConexionGeneral cnGeneral = null;
     
      
        public DataTable CargaNC(DataTable DataT)
        {
            DataTable dataS_Lista = new DataTable();
            String Query = "No_Conformidades_carga";
            String TipoTabla = "@No_Conformidades_Type";
           
            cnGeneral = new ConexionGeneral();
            try
            {
                dataS_Lista = cnGeneral.CargaTablaaSQL(DataT, Query, TipoTabla);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }

            return dataS_Lista;
        }
    }
}
