using System;

namespace LibroDeRecetas.Models
{
    public class IngredienteSimple : Ingrediente
    {
        public  int IngredienteSimpleID { get; set; }

        public string UM_Abreviatura
        {
            get
            {
                return UdM.Abreviatura;
            }
        }

        public IngredienteSimple() { }

        public IngredienteSimple(string descripcion, UnidadDeMedida udm)
            : base(descripcion, udm)
        {

        }
    }
}
