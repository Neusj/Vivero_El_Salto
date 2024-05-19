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
    /// Lógica de interacción para ListarPlantas.xaml
    /// </summary>
    public partial class ListarPlantas : Window
    {
        PlantaCollection plantaCollection = new PlantaCollection();

        public ListarPlantas()
        {
            InitializeComponent();
            dgAllPlantas.ItemsSource = plantaCollection.ReadAll();
            dgAllPlantas.CanUserAddRows = false;
        }

        private void btnActualizaPlantaClick(object sender, RoutedEventArgs e)
        {
            var planta = (Planta)dgAllPlantas.SelectedItem;
            EditarPlanta actualizar = new EditarPlanta(planta, dgAllPlantas);
            actualizar.ShowDialog();

        }
        private void btnEliminaPlantaClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageResult = MessageBox.Show(
                "¿Está seguro de que desea eliminar esta planta?",
                "Confirmación",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question
            );
            if (messageResult == MessageBoxResult.Yes)
            {
                Planta planta = (Planta)dgAllPlantas.SelectedItem;
                bool deleteResult = planta.Delete(planta.Id);
                if (deleteResult)
                {
                    dgAllPlantas.ItemsSource = plantaCollection.ReadAll();
                    MessageBox.Show("El planta se eliminó correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Error al eliminar la planta.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
        }
    }
}
