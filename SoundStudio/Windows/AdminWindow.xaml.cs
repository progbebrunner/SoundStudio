using SoundStudio.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
            if (FrameAdmin.CanGoBack)
            {
                btnBack.Visibility = Visibility.Visible;
            }
            else { btnBack.Visibility = Visibility.Collapsed; }
            if (FrameAdmin.Content.ToString() == "SoundStudio.Pages.AddEditApps")
            {
                btnAdd.Visibility = Visibility.Hidden;
            }
            FrameAdmin.Navigate(new Homepage());
        }

        private void FrameAdmin_ContentRendered(object sender, EventArgs e)
        {
            
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if (FrameAdmin.CanGoBack)
                FrameAdmin.GoBack();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            if(App.CurrentUser != null)
            {
                App.CurrentUser = null;
                AuthorizathionWindow authorizathionWindow = new AuthorizathionWindow();
                authorizathionWindow.Show();
                this.Close();
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            FrameAdmin.Navigate(new AddEditPage());
        }
    }
}
