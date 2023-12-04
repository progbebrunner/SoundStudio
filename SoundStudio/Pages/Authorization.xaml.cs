using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using SoundStudio.Windows;
using SoundStudio.Pages;

namespace SoundStudio
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void txtLogin_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtError.Text = "";
        }
        private void txtPsw_PasswordChanged(object sender, RoutedEventArgs e)
        {
            txtError.Text = "";
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var user_log = App.Context.Users.Where(u => u.login == txtLogin.Text.Trim()).ToList();

                if (user_log.Count == 1)
                {
                    if (user_log[0].password.ToString() == txtPsw.Password.ToString())
                    {

                        if (user_log[0].role == 2)
                        {
                            AdminWindow adminWindow = new AdminWindow();
                            adminWindow.Show();
                        }
                        else
                        {
                            if (user_log[0].role.ToString().Trim() == "")
                            {
                                GuestWindow gWindow = new GuestWindow();
                                gWindow.Show();
                            }
                            else
                            {
                                GuestWindow gWindow = new GuestWindow();
                                gWindow.Show();
                            }
                        }
                        Window.GetWindow(this).Close();
                        NavigationService.GetNavigationService(new Homepage());
                    }
                    else
                    {
                        txtError.Text = "Неправильный пароль. Попробуйте снова.";
                    }
                }
                else
                {
                    txtError.Text = "Неправильный логин. Попробуйте снова.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
    }

        private void btnLoginGuest_Click(object sender, RoutedEventArgs e)
        {

        }

        
    }
}
