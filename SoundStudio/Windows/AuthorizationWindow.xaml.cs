using SoundStudio.Pages;
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

namespace SoundStudio.Windows
{
    /// <summary>
    /// Логика взаимодействия для authorizationwindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
            FrameAuthoriz.Navigate(new Authorization());
        }

        private void btnLoginGuest_Click(object sender, RoutedEventArgs e)
        {
            GuestWindow gWindow = new GuestWindow(0);
            gWindow.Show();
            GetWindow(this).Close();
        }
    }

}
