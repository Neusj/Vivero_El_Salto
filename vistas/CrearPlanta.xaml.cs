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
    /// Lógica de interacción para CrearPlanta.xaml
    /// </summary>
    public partial class CrearPlanta : Window
    {
        string password_to_decryp = EncryptionHelper.password_to_decryp;

        public CrearPlanta()
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

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {

            string nombreComun = NombreComunTextBox.Text;
            string nombreCientifico = NombreCientificoTextBox.Text;
            string tipoPlanta = GetSelectedTipoPlanta();
            string descripcion = DescripcionTextBox.Text;
            string tiempoRiegoStr = TiempoRiegoTextBox.Text;
            string cantidadAguaStr = CantidadAguaTextBox.Text;
            string epoca = GetSelectedEpoca();
            bool esVenenosa = EsVenenosaCheckBox.IsChecked.Value ? true : false;
            bool esAutoctona = EsAutoctonaCheckBox.IsChecked.Value ? true : false;

            int cantidadAgua = int.Parse(cantidadAguaStr);
            int tiempoRiego = int.Parse(tiempoRiegoStr);

            string description = string.IsNullOrEmpty(descripcion) ? "Sin información.-" : descripcion;

            Planta nuevaPlanta = new Planta
            {
                NombreComun = EncryptionHelper.Encrypt(nombreComun, this.password_to_decryp),
                NombreCientifico = EncryptionHelper.Encrypt(nombreCientifico, this.password_to_decryp),
                TipoPlanta = tipoPlanta,
                Descripcion = EncryptionHelper.Encrypt(description, this.password_to_decryp),
                TiempoRiego = tiempoRiego,
                CantidadAgua = cantidadAgua,
                Epoca = epoca,
                EsVenenosa = esVenenosa,
                EsAutoctona = esAutoctona
            };

            bool result = nuevaPlanta.Create();
            if (result)
            {
                MessageBoxResult newEquipoResult = new MessageBoxResult();
                newEquipoResult = MessageBox.Show("¿Desea crear otro equipo?", "Crear otro equipo", MessageBoxButton.YesNo, MessageBoxImage.Question);
                
                if (newEquipoResult == MessageBoxResult.Yes)
                {
                    NombreComunTextBox.Text = "";
                    NombreCientificoTextBox.Text = "";
                    TiempoRiegoTextBox.Text = "";
                    CantidadAguaTextBox.Text = "";
                    DescripcionTextBox.Text = "";
                    HerbaceaRadioButton.IsChecked = false;
                    MatorralRadioButton.IsChecked = false;
                    ArbustoRadioButton.IsChecked = false;
                    ArbolRadioButton.IsChecked = false;
                    VeranoRadioButton.IsChecked = false;
                    InviernoRadioButton.IsChecked = false;
                    OtonoRadioButton.IsChecked = false;
                    PrimaveraRadioButton.IsChecked = false;
                    EsAutoctonaCheckBox.IsChecked = false;
                    EsVenenosaCheckBox.IsChecked = false;

                    MessageBox.Show("Planta guardada exitosamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);

                }
                else
                {
                    MessageBox.Show("Planta guardada exitosamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Error al crear planta");

            }


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
