using System;

namespace LibroDeRecetas.Models
{
    class IngredienteSimple : Ingrediente
    {
        public  int IngredienteSimpleID { get; set; }

        public IngredienteSimple() { }

        public IngredienteSimple(string descripcion, UnidadDeMedida udm)
            : base(descripcion, udm)
        {

        }
    }
}
