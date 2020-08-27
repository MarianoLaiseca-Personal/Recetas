using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasWPF.Models
{
    public class UnidadDeMedida
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }
        public string Abreviatura { get; set; }
        public int UnidadDeMedida_TipoID { get; set; }
        public UnidadDeMedida_Tipo umt { get; set; }
    }
}
