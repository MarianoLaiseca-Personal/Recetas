using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasWPF.Models
{
    public class UnidadDeMedida
    {
        public int UnidadDeMedidaID { get; set; }
        public string Descripcion { get; set; }
        public string Abreviatura { get; set; }
        public int UnidadDeMedida_TipoID { get; set; }
        public UnidadDeMedida_Tipo UMT { get; set; }
        public string Tipo_Descripcion
        {
            get
            {
                if (string.IsNullOrEmpty(this.UMT.Descripcion))
                    return "";
                else
                    return this.UMT.Descripcion;
            }
        }
    }
}
