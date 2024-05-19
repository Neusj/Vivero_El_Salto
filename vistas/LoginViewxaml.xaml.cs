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

namespace ViveroElSalto.clases
{

    public partial class LoginViewxaml : Window
    {
        string password_to_decryp = EncryptionHelper.password_to_decryp;
        MainWindow mainWindow = null;
        public LoginViewxaml(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.mainWindow.Hide();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            IPersistenteLogin loginService = new PersitenteLogin();
            var user = loginService.getById(1);

            string decryptedPass = EncryptionHelper.Decrypt(user.Password, this.password_to_decryp);


            if (user.Username == username && password == decryptedPass)
            {
                this.mainWindow.UpdateAdministratorName(user.Username); // envío de user name a pantalla principal
                this.mainWindow.Show();
                this.Close();
            }
            else
            {
                ErrorMessage.Text = "Datos incorrectos, intente de nuevo.";
            }
        }
    }
}
