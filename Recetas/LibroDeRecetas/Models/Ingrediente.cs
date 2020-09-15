using System;
using LiteDB;
using LibroDeRecetas.Datos;

namespace LibroDeRecetas.Models
{
    public abstract class Ingrediente
    {
        public string Descripcion { get; set; }

        [BsonRef(ContextoDB.Coleccion_UnidadesDeMedida)]
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
