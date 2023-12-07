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
                txtError.Text = "Ничего не найдено";
            }
            
        }

        private void cmDelete_Click(object sender, RoutedEventArgs e)
        {
            var x = sender as StackPanel;
            
            int id_app = 1;
            var apps = App.Context.Applications.ToList();
            var currentApp = apps.Where(a => a.id_app == id_app).FirstOrDefault();
            if (MessageBox.Show($"Вы точно хотите удалить альбом?",
                "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                App.Context.Applications.Remove(currentApp);
                App.Context.SaveChanges();
                MessageBox.Show("Альбом был удален");
            }
        }

        private void cmEdit_Click(object sender, RoutedEventArgs e)
        {
            
            //NavigationService.Navigate(new AddEditPage());
        }
    }
}
