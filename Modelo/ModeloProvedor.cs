using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ModeloProvedor
    {
        public int ID_Proveedor { get; set; }
        public string RFC { get; set; }
        public string RazonSocial { get; set; }
        public string NumeroPrograma { get; set; }
        public string Planta { get; set; }
        public int Activo { get; set; }
    }
}
