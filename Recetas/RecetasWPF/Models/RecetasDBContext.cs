using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace RecetasWPF.Models
{
    public class RecetasDBContext : DbContext
    {
        public RecetasDBContext() : base("RecetasDBContext")
        {
        }

        public DbSet<Objeto> Objetos { get; set; }
        public DbSet<UnidadDeMedida_Tipo> TiposUnidadesDeMedida { get; set; }
        public DbSet<UnidadDeMedida> UnidadesDeMedida { get; set; }
        public DbSet<Ingrediente> Ingredientes { get; set; }
        public DbSet<Receta> Recetas { get; set; }
        public DbSet<Componente> Componentes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
