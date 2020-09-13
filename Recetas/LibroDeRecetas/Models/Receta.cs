using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibroDeRecetas.Models
{
    class Receta : Ingrediente
    {
        public int RecetaID { get; set; }
        public decimal CantidadStandard { get; set; }
        public List<Componente> Componentes { get; set; }

        public Receta(string descripcion, decimal cantidadStandard, UnidadDeMedida udm)
            : base(descripcion, udm)
        {
            this.Descripcion = descripcion;
            this.CantidadStandard = cantidadStandard;
            this.UdM = udm;
            this.Componentes = new List<Componente>();
        }

        public void AgregarComponente (Componente componente)
        {
            this.Componentes.Add(componente);
        }

        public void EliminarComponente(Componente componente)
        {
            this.Componentes.Remove(componente);
        }
    }
}
