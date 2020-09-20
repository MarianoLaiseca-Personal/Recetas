using System;
using System.Windows;
using LibroDeRecetas.Datos;

namespace LibroDeRecetas.Views
{
    /// <summary>
    /// Lógica de interacción para scrPrincipal.xaml
    /// </summary>
    public partial class scrPrincipal : Window
    {
        public scrPrincipal()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ContextoDB.ConectarArchivoDeDatos();
        }

        private void MnuSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Application.Current.Shutdown();
        }

        private void MnuEntidadABM_Click(object sender, RoutedEventArgs e)
        {
            this.PresionoEntidadABM(sender);
        }

        private void PresionoEntidadABM(object sender)
        {
            //MessageBox.Show(sender.GetType().FullName);
            Window scr;
            string ent = "";

            switch (sender.GetType().Name)
            {
                case "MenuItem":
                    var mi = (System.Windows.Controls.MenuItem)sender;
                    ent = mi.Tag.ToString();
                    break;
                default:
                    break;
            }

            switch (ent)
            {
                case "UnidadDeMedida":
                    scr = new scrMant_UnidadesDeMedida();
                    break;
                case "IngredienteSimple":
                    scr = new scrMant_IngredienteSimple();
                    break;
                default:
                    scr = null;
                    break;
            }

            try
            {
                if (scr is null)
                    throw new Exception("Hay un error para abrir la ventana");

                scr.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
