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
        public string Abreviatura { get; set; }
        public TipoUnidadDeMedida TipoUM { get; set; }
        public bool Activa { get; set; }

        public UnidadDeMedida() { }

        public UnidadDeMedida(string descripcion, string Abreviatura, TipoUnidadDeMedida tum, bool Activa)
        {
            this.Descripcion = descripcion;
            this.Abreviatura = Abreviatura;
            this.TipoUM = tum;
            this.Activa = Activa;
        }
    }
}
