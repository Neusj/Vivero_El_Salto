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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ViveroElSalto.vistas;

namespace ViveroElSalto
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            clases.LoginViewxaml loginWindow = new clases.LoginViewxaml(this);
            loginWindow.Show();
        }
        private void Agregar_Click(object sender, RoutedEventArgs e)
        {
            vistas.CrearPlanta agregarEquipo = new vistas.CrearPlanta();
            agregarEquipo.ShowDialog();
        }
        private void Listar_Click(object sender, RoutedEventArgs e)
        {
            ListarPlantas listarPlantas = new ListarPlantas();
            listarPlantas.ShowDialog();
        }

        public void UpdateAdministratorName(string administratorName)
        {
            // Mostrar el nombre del administrador en un TextBlock
            AdministratorNameTextBlock.Text = "Bienvenido " + administratorName;
        }
    }
}
