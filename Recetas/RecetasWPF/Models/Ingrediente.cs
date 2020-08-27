using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasWPF.Models
{
    public class Ingrediente : IComponente
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }
        public int UnidadDeMedidaID { get; set; }
        public UnidadDeMedida UM_Base { get; set; }

        public string Mostrar()
        {
            return this.ID.ToString() + " - " + this.Descripcion;
        }
    }
}
