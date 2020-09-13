using System.Windows;
using System.Configuration;
using LiteDB;
using LibroDeRecetas.Models;


namespace LibroDeRecetas
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _db;

        public MainWindow()
        {
            InitializeComponent();


            _db = Properties.Settings.Default.BaseLiteDB;
        }

        private void CmdPrueba1_Click(object sender, RoutedEventArgs e)
        {
            //Borra todas las tablas
            using (var db = new LiteDatabase(_db))
            {
                // Get a collection (or create, if doesn't exist)
                var unidadesDeMedida = db.GetCollection<UnidadDeMedida>("UnidadDeMedida");
                var ingredientesSimples = db.GetCollection<IngredienteSimple>("IngredienteSimple");
                var recetas = db.GetCollection<Receta>("Receta");
                var componentes = db.GetCollection<Componente>("Componente");

                unidadesDeMedida.DeleteAll();
                ingredientesSimples.DeleteAll();
                recetas.DeleteAll();
                componentes.DeleteAll();
            }

            using (var db = new LiteDatabase(_db))
            {
                //Unidades de Medida
                UnidadDeMedida udm_gramos = new UnidadDeMedida("Gramos", TipoUnidadDeMedida.Peso);
                UnidadDeMedida udm_kilos = new UnidadDeMedida("Kilos", TipoUnidadDeMedida.Peso);
                UnidadDeMedida udm_cc = new UnidadDeMedida("Centimetros Cubicos", TipoUnidadDeMedida.Volumen);

                // Get a collection (or create, if doesn't exist)
                var unidadesDeMedida = db.GetCollection<UnidadDeMedida>("UnidadDeMedida");

                unidadesDeMedida.Insert(udm_gramos);
                unidadesDeMedida.Insert(udm_kilos);
                unidadesDeMedida.Insert(udm_cc);


                //Ingredientes Simples
                IngredienteSimple ing_leche = new IngredienteSimple("Leche", udm_cc);
                IngredienteSimple ing_azucar = new IngredienteSimple("Azucar", udm_gramos);
                IngredienteSimple ing_azimp = new IngredienteSimple("Azucar Impalpable", udm_gramos);
                IngredienteSimple ing_panr = new IngredienteSimple("Pan Rallado", udm_kilos);

                var ingredientesSimples = db.GetCollection<IngredienteSimple>("IngredienteSimple");
                ingredientesSimples.Insert(ing_leche);
                ingredientesSimples.Insert(ing_azucar);
                ingredientesSimples.Insert(ing_azimp);
                ingredientesSimples.Insert(ing_panr);

                //Recetas
                var componentes = db.GetCollection<Componente>("Componente");
                var recetas = db.GetCollection<Receta>("Receta");

                Receta rec_ddl = new Receta("Dulce De Leche", 1, udm_kilos);
                Componente comp_leche = new Componente(ing_leche, 1000, udm_cc);
                Componente comp_azucar = new Componente(ing_azucar, 1, udm_kilos);
                componentes.Insert(comp_leche);
                componentes.Insert(comp_azucar);
                rec_ddl.AgregarComponente(comp_leche);
                rec_ddl.AgregarComponente(comp_azucar);
                recetas.Insert(rec_ddl);

                Receta rec_vau = new Receta("Vauquita", 800, udm_gramos);
                Componente comp_azimp = new Componente(ing_azimp, 100, udm_gramos);
                Componente comp_ddl = new Componente(rec_ddl, 1, udm_kilos);
                componentes.Insert(comp_azimp);
                componentes.Insert(comp_ddl);

                rec_vau.AgregarComponente(comp_azimp);
                rec_vau.AgregarComponente(comp_ddl);
                recetas.Insert(rec_vau);
            }

            MessageBox.Show("Hola");
        }

        private void CmdPrueba2_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new LiteDatabase(_db))
            {
                // Get a collection (or create, if doesn't exist)
                var col = db.GetCollection<UnidadDeMedida>("UnidadDeMedida");

                UnidadDeMedida um = col.FindById(2);

                if (um != null)
                {
                    um.Descripcion = "Kilogramos";
                    col.Update(um);

                    var colIS = db.GetCollection<IngredienteSimple>("IngredienteSimple");
                    IngredienteSimple pr = colIS.FindById(4);

                    colIS.Update(pr);
                }              

                MessageBox.Show("Termino");
            }
        }

        private void CmdPrueba3_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new LiteDatabase(@"C:\Temp\MyData.db"))
            {
                //Unidades de Medida
                UnidadDeMedida udm1 = new UnidadDeMedida("udm1", TipoUnidadDeMedida.Peso);

                // Get a collection (or create, if doesn't exist)
                var unidadesDeMedida = db.GetCollection<UnidadDeMedida>("UnidadDeMedida");

                unidadesDeMedida.Insert(udm1);

                //Ingredientes Simples
                IngredienteSimple ing1 = new IngredienteSimple("Ingrediente", udm1);

                var ingredientesSimples = db.GetCollection<IngredienteSimple>("IngredienteSimple");
                ingredientesSimples.Insert(ing1);


                UnidadDeMedida um = unidadesDeMedida.FindById(1);
                um.Descripcion="udm1111";
                unidadesDeMedida.Update(um);
            }
        }
    }
}
