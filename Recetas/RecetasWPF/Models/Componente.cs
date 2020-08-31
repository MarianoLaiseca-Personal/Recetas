using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasWPF.Models
{
    public class Componente
    {
        public int ComponenteID { get; set; }
        public int RecetaID { get; set; }
        public int IngredienteID { get; set; }
        public IComponente Comp { get; set; }
        public decimal CantidadNecesaria { get; set; }
        public int UnidadDeMedidaID { get; set; }
        public UnidadDeMedida UM { get; set; }

        public string Mostrar()
        {
            return Comp.Mostrar();
        }
    }
}
