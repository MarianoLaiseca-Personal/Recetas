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
        private TiposDeDialogo _TipoDialogo;
        private UnidadDeMedida _udm;

        public dlgUnidadDeMedida_ABM(TiposDeDialogo tipoDialogo, UnidadDeMedida udm)
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
            try
            {
                _udm.Descripcion = this.txtDescripcion.Text;
                _udm.Abreviatura = this.txtAbreviatura.Text;
                _udm.TipoUM = (TipoUnidadDeMedida)this.cmbTipo.SelectedItem;

                switch (_TipoDialogo)
                {
                    case TiposDeDialogo.Alta:
                        _udm.Activa = true;
                        ContextoDB.Entidad_Insertar(_udm);
                        break;
                    case TiposDeDialogo.Modificacion:
                        _udm.Activa = true;
                        ContextoDB.Entidad_Modificar(_udm);
                        break;
                    case TiposDeDialogo.Baja:
                        _udm.Activa = false;
                        ContextoDB.Entidad_Modificar(_udm);
                        break;
                    default:
                        break;
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la actualización. " + ex.Message);
            }
            
        }
    }
}
