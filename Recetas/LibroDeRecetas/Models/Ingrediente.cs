using System;

namespace LibroDeRecetas.Models
{
    public abstract class Ingrediente
    {
        public string Descripcion { get; set; }
        public UnidadDeMedida UdM { get; set; }

        //Constructor
        public Ingrediente() { }

        public Ingrediente (string descripcion, UnidadDeMedida udM)
        {
            this.Descripcion = descripcion;
            this.UdM = udM;
        }

        public virtual void AgregarIngrediente(Ingrediente ingrediente)
        {
            throw new NotImplementedException();
        }

        public virtual void EliminarIngrediente(Ingrediente ingrediente)
        {
            throw new NotImplementedException();
        }
    }
}
