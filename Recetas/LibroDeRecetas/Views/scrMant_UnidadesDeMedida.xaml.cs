using System;
using System.Collections.Generic;
using System.Windows;
using LibroDeRecetas.Datos;
using LibroDeRecetas.Models;


namespace LibroDeRecetas.Views
{
    /// <summary>
    /// Lógica de interacción para scrMant_UnidadesDeMedida.xaml
    /// </summary>
    public partial class scrMant_UnidadesDeMedida : Window
    {
        public scrMant_UnidadesDeMedida()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.InicializarFormulario();
        }

        private void InicializarFormulario()
        {
            this.ActualizarGrilla();
        }

        private void ActualizarGrilla()
        {
            var udms = ContextoDB.UnidadDeMedida_DevolverTodas();
            this.dgvDatos.ItemsSource = udms;
        }

        private void MnuModificacion_Click(object sender, RoutedEventArgs e)
        {
            if (this.dgvDatos.SelectedItem != null)
            {
                UnidadDeMedida udm = (UnidadDeMedida)this.dgvDatos.SelectedItem;
                var dlg = new dlgUnidadDeMedida_ABM("Modificacion", udm);
                dlg.ShowDialog();
                ActualizarGrilla();
            }              
        }
    }
}
