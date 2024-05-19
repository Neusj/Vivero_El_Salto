using System;
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
using System.Windows.Shapes;
using ViveroElSalto.clases;

namespace ViveroElSalto.vistas
{
    /// <summary>
    /// Lógica de interacción para EditarPlanta.xaml
    /// </summary>
    public partial class EditarPlanta : Window
    {
        Planta _planta = new Planta();
        DataGrid _dgPlantas = new DataGrid();
        PlantaCollection plantaCollection = new PlantaCollection();

        public EditarPlanta(Planta planta, DataGrid dgAllPlantas)
        {
            InitializeComponent();

            NombreComunTextBox.TextChanged += OnFieldChanged;
            NombreCientificoTextBox.TextChanged += OnFieldChanged;
            TiempoRiegoTextBox.TextChanged += OnFieldChanged;
            CantidadAguaTextBox.TextChanged += OnFieldChanged;
            HerbaceaRadioButton.Checked += OnFieldChanged;
            MatorralRadioButton.Checked += OnFieldChanged;
            ArbustoRadioButton.Checked += OnFieldChanged;
            ArbolRadioButton.Checked += OnFieldChanged;
            VeranoRadioButton.Checked += OnFieldChanged;
            InviernoRadioButton.Checked += OnFieldChanged;
            OtonoRadioButton.Checked += OnFieldChanged;
            PrimaveraRadioButton.Checked += OnFieldChanged;

            // Deshabilitar el botón Guardar por defecto
            GuardarButton.IsEnabled = false;

            this._planta = planta;
            this._dgPlantas = dgAllPlantas;
            CargaDatosForm();
        }

        private void CargaDatosForm()
        {
            NombreComunTextBox.Text = this._planta.NombreComun;
            NombreCientificoTextBox.Text = this._planta.NombreCientifico;
            TiempoRiegoTextBox.Text = this._planta.TiempoRiego.ToString();
            CantidadAguaTextBox.Text = this._planta.CantidadAgua.ToString();
            DescripcionTextBox.Text = this._planta.Descripcion;
            EsAutoctonaCheckBox.IsChecked = this._planta.EsAutoctona;
            EsVenenosaCheckBox.IsChecked = this._planta.EsVenenosa;

            updateCheckBox();
        }

        private void updateCheckBox()
        {
            string tipoPlanta = this._planta.TipoPlanta;
            if (tipoPlanta == "Herbácea")
            {
                HerbaceaRadioButton.IsChecked = true;
            }
            else if (tipoPlanta == "Matorral")
            {
                MatorralRadioButton.IsChecked = true;

            }
            else if (tipoPlanta == "Arbusto")
            {
                ArbustoRadioButton.IsChecked = true;

            }
            else
            {
                ArbolRadioButton.IsChecked = true;
            }

            string epoca = this._planta.Epoca;
            if (epoca == "Verano")
            {
                VeranoRadioButton.IsChecked = true;
            }
            else if (epoca == "Invierno")
            {
                InviernoRadioButton.IsChecked = true;

            }
            else if (epoca == "Otoño")
            {
                OtonoRadioButton.IsChecked = true;

            }
            else
            {
                PrimaveraRadioButton.IsChecked = true;
            }
        }

        private void OnFieldChanged(object sender, RoutedEventArgs e)
        {
            ValidateFields();
        }

        private void ValidateFields()
        {
            string nombreComun = NombreComunTextBox.Text;
            string nombreCientifico = NombreCientificoTextBox.Text;
            string tipoPlanta = GetSelectedTipoPlanta();
            string descripcion = DescripcionTextBox.Text;
            string tiempoRiegoStr = TiempoRiegoTextBox.Text;
            string cantidadAguaStr = CantidadAguaTextBox.Text;
            string epoca = GetSelectedEpoca();

            string errorMessage = Validations.Validations.ValidateFields(
                nombreComun,
                nombreCientifico,
                tipoPlanta,
                descripcion,
                tiempoRiegoStr,
                cantidadAguaStr,
                epoca
            );

            ErrorMessageTextBlock.Text = errorMessage;

            // Habilitar el botón Guardar si no hay errores
            GuardarButton.IsEnabled = string.IsNullOrEmpty(errorMessage);
        }

        public void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            Planta planta_temp = new Planta();

            planta_temp.Id = this._planta.Id;
            planta_temp.NombreComun = EncryptionHelper.Encrypt(NombreComunTextBox.Text, EncryptionHelper.password_to_decryp);
            planta_temp.NombreCientifico = EncryptionHelper.Encrypt(NombreCientificoTextBox.Text, EncryptionHelper.password_to_decryp);
            planta_temp.TipoPlanta = GetSelectedTipoPlanta();
            planta_temp.Descripcion = EncryptionHelper.Encrypt(DescripcionTextBox.Text, EncryptionHelper.password_to_decryp);
            planta_temp.TiempoRiego = Convert.ToInt32(TiempoRiegoTextBox.Text);
            planta_temp.CantidadAgua = Convert.ToInt32(CantidadAguaTextBox.Text);
            planta_temp.Epoca = GetSelectedEpoca();
            planta_temp.EsVenenosa = EsVenenosaCheckBox.IsChecked.Value ? true : false; ;
            planta_temp.EsAutoctona = EsAutoctonaCheckBox.IsChecked.Value ? true : false; ;


            bool updateResult = planta_temp.Update();

            if (updateResult)
            {
                MessageBox.Show("La planta se actualizó correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                this._dgPlantas.ItemsSource = plantaCollection.ReadAll();

            }
            else
            {
                MessageBox.Show("Error al actualizar la planta.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            this.Close();
        }

        private string GetSelectedTipoPlanta()
        {
            if (HerbaceaRadioButton.IsChecked == true) return "Herbácea";
            if (MatorralRadioButton.IsChecked == true) return "Matorral";
            if (ArbustoRadioButton.IsChecked == true) return "Arbusto";
            if (ArbolRadioButton.IsChecked == true) return "Árbol";

            return null;
        }

        private string GetSelectedEpoca()
        {
            if (VeranoRadioButton.IsChecked == true) return "Verano";
            if (InviernoRadioButton.IsChecked == true) return "Invierno";
            if (OtonoRadioButton.IsChecked == true) return "Otoño";
            if (PrimaveraRadioButton.IsChecked == true) return "Primavera";
            return null;
        }


    }
}
