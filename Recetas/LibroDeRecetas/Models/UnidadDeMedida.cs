namespace LibroDeRecetas.Models
{
    public enum TipoUnidadDeMedida
    {
        Peso,
        Volumen,
        Unidad,
        Otro
    }

    public class UnidadDeMedida
    {
        public int UnidadDeMedidaID { get; set; }
        public string Descripcion { get; set; }
        public TipoUnidadDeMedida TipoUM { get; set; }

        public UnidadDeMedida() { }

        public UnidadDeMedida(string descripcion, TipoUnidadDeMedida tum)
        {
            this.Descripcion = descripcion;
            this.TipoUM = tum;
        }
    }
}
