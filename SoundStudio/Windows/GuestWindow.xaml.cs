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
using SoundStudio.Pages;

namespace SoundStudio.Windows
{
    /// <summary>
    /// Логика взаимодействия для GuestWindow.xaml
    /// </summary>
    public partial class GuestWindow : Window
    {
        public GuestWindow(int x)
        {
            InitializeComponent();
            //if (FrameGuest.CanGoBack)
            //{
            //    btnBack.Visibility = Visibility.Visible;
            //}
            //else { btnBack.Visibility = Visibility.Collapsed; }
            if (FrameGuest.Content != null && FrameGuest.Content.ToString() == "SoundStudio.Pages.AddEditApps") 
            { 
                btnAdd.Visibility = Visibility.Hidden;
            }
            if (x == 0)
            {
                FrameGuest.Navigate(new Guestpage());
            }
            else if (x == 1)
            {
                FrameGuest.Navigate(new Homepage());
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if (FrameGuest.CanGoBack)
                FrameGuest.GoBack();
        }

        private void FrameGuest_ContentRendered(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            App.CurrentUser = null;
            AuthorizationWindow authorizationwindow = new AuthorizationWindow();
            authorizationwindow.Show();
            this.Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            FrameGuest.Navigate(new AddEditPage());
        }
    }
}
