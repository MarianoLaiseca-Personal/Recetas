using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RecetasWPF.Models;

namespace RecetasWPF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new RecetasDBContext())
            {
                db.TiposUnidadesDeMedida.Add(new UnidadDeMedida_Tipo { Descripcion = "Peso" });
                db.TiposUnidadesDeMedida.Add(new UnidadDeMedida_Tipo { Descripcion = "Volumen" });
                db.SaveChanges();
            }
            
            UnidadDeMedida_Tipo ut1 = new UnidadDeMedida_Tipo()
            {
                ID = 1,
                Descripcion = "Peso" };

            UnidadDeMedida_Tipo ut2 = new UnidadDeMedida_Tipo()
            {
                ID = 2,
                Descripcion = "Volumen" };

            UnidadDeMedida um1 = new UnidadDeMedida()
            {
                ID = 1,
                Descripcion = "Gramos",
                Abreviatura = "gr",
                umt = ut1,
                UnidadDeMedida_TipoID = ut1.ID };
            UnidadDeMedida um2 = new UnidadDeMedida()
            {
                ID = 2,
                Descripcion = "Mililitros",
                Abreviatura = "ml",
                umt = ut2,
                UnidadDeMedida_TipoID = ut2.ID };

            Ingrediente ing1 = new Ingrediente()
            {
                ID = 1,
                Descripcion = "Leche",
                UnidadDeMedidaID = um2.ID,
                UM_Base = um2
            };

            Ingrediente ing2 = new Ingrediente()
            {
                ID = 2,
                Descripcion = "Azucar",
                UnidadDeMedidaID = um1.ID,
                UM_Base = um1
            };

            Ingrediente ing3 = new Ingrediente()
            {
                ID = 3,
                Descripcion = "Arroz",
                UnidadDeMedidaID = um1.ID,
                UM_Base = um1
            };

            Ingrediente ing4 = new Ingrediente()
            {
                ID = 4,
                Descripcion = "Azucar Impalpable",
                UnidadDeMedidaID = um1.ID,
                UM_Base = um1
            };

            Receta rec1 = new Receta()
            {
                ID = 1,
                Descripcion = "Dulce de Leche",
                UnidadDeMedidaID = um1.ID,
                UM_Base = um1
            };
            rec1.AgregarComponente(new Componente()
            {
                ID = 1,
                Comp = ing1,
                CantidadNecesaria = 100,
                UnidadDeMedidaID = um2.ID,
                UM = um2
            });
            rec1.AgregarComponente(new Componente()
            {
                ID = 2,
                Comp = ing2,
                CantidadNecesaria = 200,
                UnidadDeMedidaID = um2.ID,
                UM = um2
            });
            Debug.WriteLine(rec1.Mostrar());

            /*
            Receta rec2 = new Receta()
            {
                ID = 2,
                Descripcion = "Arroz con Leche",
                UnidadDeMedidaID = um1.ID,
                UM_Base = um1
            };

            Receta rec3 = new Receta()
            {
                ID = 3,
                Descripcion = "Arroz con Leche con Dulce de Leche",
                UnidadDeMedidaID = um1.ID,
                UM_Base = um1
            };

            Receta rec4 = new Receta()
            {
                ID = 4,
                Descripcion = "Vauquita Casera",
                UnidadDeMedidaID = um1.ID,
                UM_Base = um1
            };
            */            
        }
    }
}
