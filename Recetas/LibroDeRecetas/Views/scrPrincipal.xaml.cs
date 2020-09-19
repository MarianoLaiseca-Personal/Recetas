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

        private void MnuUnidadesDeMedida_Click(object sender, RoutedEventArgs e)
        {
            this.PresionoUnidadesDeMedida();
        }

        private void PresionoUnidadesDeMedida()
        {
            scrMant_UnidadesDeMedida scr = new scrMant_UnidadesDeMedida();

            try
            {
                scr.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


    }
}
