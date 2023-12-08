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
using SoundStudio.Windows;

namespace SoundStudio.Pages
{
    /// <summary>
    /// Логика взаимодействия для Homepage.xaml
    /// </summary>
    public partial class Homepage : Page
    {
        public Homepage()
        {
            InitializeComponent();
            AppsLoad();
        }

        public void AppsLoad()
        {
            if (App.CurrentUser.id_user == 2)
            {
                var apps = App.Context.Applications.ToList();
                LVApps.ItemsSource = null;
                LVApps.ItemsSource = apps;
            }
            else
            {
                var apps = App.Context.Applications.Where(a => a.client == App.CurrentUser.id_user) .ToList();
                LVApps.ItemsSource = null;
                LVApps.ItemsSource = apps;
            }
            
            if (LVApps.Items.Count == 0)
            {
                txtError.Visibility= Visibility.Visible;
                txtError.Text = "Заявок нет";
            }
            
        }

        private void cmEdit_Click(object sender, RoutedEventArgs e)
        {            
            var app_id = (sender as MenuItem);
            MessageBox.Show(app_id.DataContext.ToString());

            //NavigationService.Navigate(new AddEditPage());
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var app = button.DataContext as Applications;
            NavigationService.Navigate(new AddEditPage(app));
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var currentApp = button.DataContext as Applications;
            if (MessageBox.Show($"Вы точно хотите удалить эту заявку?",
                "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                App.Context.Applications.Remove(currentApp);
                App.Context.SaveChanges();
                MessageBox.Show("Заявка была удалена");
            }
        }
    }
}
