using System;

namespace LibroDeRecetas.Models
{
    public class Componente
    {
        public int ComponenteID { get; set; }
        public Ingrediente Ingrediente { get; set; }
        public decimal CantidadNecesaria { get; set; }
        public UnidadDeMedida UdM { get; set; }

        //Constructor
        public Componente(Ingrediente ingrediente, decimal cantidadNecesaria, UnidadDeMedida unidadDeMedida)
        {
            this.Ingrediente = ingrediente;
            this.CantidadNecesaria = cantidadNecesaria;
            this.UdM = unidadDeMedida;
        }
    }
}
