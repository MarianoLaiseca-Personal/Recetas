using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasWPF.Models
{
    public class Receta : IComponente
    {
        public int RecetaID { get; set; }
        public string Descripcion { get; set; }
        public int UnidadDeMedidaID { get; set; }
        public UnidadDeMedida UM_Base { get; set; }

        private List<Componente> _componentes = new List<Componente>();

        public void AgregarComponente(Componente c)
        {
            _componentes.Add(c);
        }

        public void EliminarComponente(Componente c)
        {
            _componentes.Remove(c);
        }

        public string Mostrar()
        {
            string rtaMostrarReceta = "";

            rtaMostrarReceta = "Receta: " + this.RecetaID.ToString() + " - " + this.Descripcion + Environment.NewLine;
            foreach (var c in _componentes)
            {
                rtaMostrarReceta = rtaMostrarReceta + c.Mostrar() + Environment.NewLine;
            }

            return rtaMostrarReceta;
        }
    }
}
