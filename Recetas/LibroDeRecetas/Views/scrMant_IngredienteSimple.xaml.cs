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
    public partial class scrMant_IngredienteSimple : Window
    {
        public scrMant_IngredienteSimple()
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
            var iss = ContextoDB.IngredienteSimple_DevolverTodos();
            this.dgvDatos.ItemsSource = iss;
        }

        private void MnuModificacion_Click(object sender, RoutedEventArgs e)
        {
            if (this.dgvDatos.SelectedItem != null)
            {
                IngredienteSimple ingredienteSimple = (IngredienteSimple)this.dgvDatos.SelectedItem;
                var dlg = new dlgIngredienteSimple_ABM(TiposDeDialogo.Modificacion, ingredienteSimple);
                dlg.ShowDialog();
                ActualizarGrilla();
            }              
        }

        private void MnuAlta_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new dlgIngredienteSimple_ABM(TiposDeDialogo.Alta, null);
            dlg.ShowDialog();
            ActualizarGrilla();
        }

        private void MnuBaja_Click(object sender, RoutedEventArgs e)
        {
            if (this.dgvDatos.SelectedItem != null)
            {
                IngredienteSimple ingredienteSimple = (IngredienteSimple)this.dgvDatos.SelectedItem;
                var dlg = new dlgIngredienteSimple_ABM(TiposDeDialogo.Modificacion, ingredienteSimple);
                dlg.ShowDialog();
                ActualizarGrilla();
            }
        }
    }
}
