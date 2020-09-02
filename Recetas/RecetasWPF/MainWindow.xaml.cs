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

            //try
            //{
            //    using (var db = new RecetasDBContext())
            //    {
            //        db.Objetos.Add(new Objeto { Campo1 = "Texto de Ejemplo 2" });
            //        db.SaveChanges();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //    throw;
            //}


            try
            {
                UnidadDeMedida_Tipo ut1 = new UnidadDeMedida_Tipo()
                {
                    Descripcion = "Peso"
                };

                UnidadDeMedida_Tipo ut2 = new UnidadDeMedida_Tipo()
                {
                    Descripcion = "Volumen"
                };

                UnidadDeMedida um1 = new UnidadDeMedida()
                {
                    Descripcion = "Gramos",
                    Abreviatura = "gr",
                    umt = ut1,
                    UnidadDeMedida_TipoID = ut1.UnidadDeMedida_TipoID
                };
                UnidadDeMedida um2 = new UnidadDeMedida()
                {
                    Descripcion = "Mililitros",
                    Abreviatura = "ml",
                    umt = ut2,
                    UnidadDeMedida_TipoID = ut2.UnidadDeMedida_TipoID
                };

                Ingrediente ing1 = new Ingrediente()
                {
                    Descripcion = "Leche",
                    UnidadDeMedidaID = um2.UnidadDeMedidaID,
                    UM_Base = um2
                };

                Ingrediente ing2 = new Ingrediente()
                {
                    Descripcion = "Azucar",
                    UnidadDeMedidaID = um1.UnidadDeMedidaID,
                    UM_Base = um1
                };

                Ingrediente ing3 = new Ingrediente()
                {
                    Descripcion = "Arroz",
                    UnidadDeMedidaID = um1.UnidadDeMedidaID,
                    UM_Base = um1
                };

                Ingrediente ing4 = new Ingrediente()
                {
                    Descripcion = "Azucar Impalpable",
                    UnidadDeMedidaID = um1.UnidadDeMedidaID,
                    UM_Base = um1
                };

                Receta rec1 = new Receta()
                {
                    Descripcion = "Dulce de Leche",
                    UnidadDeMedidaID = um1.UnidadDeMedidaID,
                    UM_Base = um1
                };

                Componente comp1 = new Componente
                {
                    Comp = ing1,
                    CantidadNecesaria = 100,
                    UnidadDeMedidaID = um2.UnidadDeMedidaID,
                    UM = um2
                };
                rec1.AgregarComponente(comp1);

                Componente comp2 = new Componente
                {
                    Comp = ing2,
                    CantidadNecesaria = 200,
                    UnidadDeMedidaID = um2.UnidadDeMedidaID,
                    UM = um2
                };
                rec1.AgregarComponente(comp2);

                using (var db = new RecetasDBContext())
                {
                    db.TiposUnidadesDeMedida.Add(ut1);
                    db.TiposUnidadesDeMedida.Add(ut2);
                    db.UnidadesDeMedida.Add(um1);
                    db.UnidadesDeMedida.Add(um2);
                    db.Ingredientes.Add(ing1);
                    db.Ingredientes.Add(ing2);
                    db.Ingredientes.Add(ing3);
                    db.Ingredientes.Add(ing4);
                    db.Componentes.Add(comp1);
                    db.Componentes.Add(comp2);
                    db.Recetas.Add(rec1);
                    db.SaveChanges();
                }
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                throw;
            }
        }
    }
}
