using System;
using System.Linq;
using System.Windows;
using LibroDeRecetas.Models;
using LibroDeRecetas.Datos;

namespace LibroDeRecetas.Views
{
    /// <summary>
    /// Lógica de interacción para dlgUnidadDeMedida_ABM.xaml
    /// </summary>
    public partial class dlgUnidadDeMedida_ABM : Window
    {
        private string _TipoDialogo;
        private UnidadDeMedida _udm;

        public dlgUnidadDeMedida_ABM(string tipoDialogo, UnidadDeMedida udm)
        {
            InitializeComponent();

            this._TipoDialogo = tipoDialogo;

            if (udm is null)
                udm = new UnidadDeMedida();

            this._udm = udm;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cmbTipo.ItemsSource =  Enum.GetValues(typeof(TipoUnidadDeMedida)).Cast<TipoUnidadDeMedida>();

            this.txtID.Text = _udm.UnidadDeMedidaID.ToString();
            this.txtDescripcion.Text = _udm.Descripcion;
            this.txtAbreviatura.Text = _udm.Abreviatura;
            this.cmbTipo.Text = _udm.TipoUM.ToString();            
        }

        private void CmdAceptar_Click(object sender, RoutedEventArgs e)
        {
            _udm.Descripcion = this.txtDescripcion.Text;
            _udm.Abreviatura = this.txtAbreviatura.Text;
            _udm.TipoUM = (TipoUnidadDeMedida)this.cmbTipo.SelectedItem;
            _udm.Activa = true;

            if (_TipoDialogo == "Modificacion")
            {
                ContextoDB.UnidadDeMedida_Actualizar(_udm);
            }
        }
    }
}
