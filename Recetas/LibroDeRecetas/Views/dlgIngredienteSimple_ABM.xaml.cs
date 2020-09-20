using System;
using System.Linq;
using System.Windows;
using LibroDeRecetas.Models;
using LibroDeRecetas.Datos;

namespace LibroDeRecetas.Views
{
    public partial class dlgIngredienteSimple_ABM : Window
    {
        private TiposDeDialogo _TipoDialogo;
        private IngredienteSimple _ingsim;

        public dlgIngredienteSimple_ABM(TiposDeDialogo tipoDialogo, IngredienteSimple ingsim)
        {
            InitializeComponent();

            this._TipoDialogo = tipoDialogo;

            if (ingsim is null)
                ingsim = new IngredienteSimple();

            this._ingsim = ingsim;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cmbUM.ItemsSource = ContextoDB.Entidad_DevolverTodos<UnidadDeMedida>();
            cmbUM.DisplayMemberPath = "Descripcion";

            this.txtID.Text = _ingsim.IngredienteSimpleID.ToString();
            this.txtDescripcion.Text = _ingsim.Descripcion;
            this.cmbUM.Text = _ingsim.UdM.Descripcion;            
        }

        private void CmdAceptar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _ingsim.Descripcion = this.txtDescripcion.Text;
                _ingsim.UdM = (UnidadDeMedida)this.cmbUM.SelectedItem;

                switch (_TipoDialogo)
                {
                    case TiposDeDialogo.Alta:
                        _ingsim.Activo = true;
                        ContextoDB.Entidad_Insertar(_ingsim);
                        break;
                    case TiposDeDialogo.Modificacion:
                        _ingsim.Activo = true;
                        ContextoDB.Entidad_Modificar(_ingsim);
                        break;
                    case TiposDeDialogo.Baja:
                        _ingsim.Activo = false;
                        ContextoDB.Entidad_Modificar(_ingsim);
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
