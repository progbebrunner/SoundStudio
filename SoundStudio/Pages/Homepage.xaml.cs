using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            var types = App.Context.ApplicationTypes.Select(x => x.app_type).ToList();
            foreach (var type in types)
            {
                cbChooseType.Items.Add(type);
            }
            cbChooseType.SelectedIndex = 0;
            cbSortNumCl.SelectedIndex = 0;
        }

        public void AppsLoad()
        {
            
            txtError.Visibility = Visibility.Hidden;
            List<Applications> apps;
            if (App.CurrentUser.id_user == 2)
            {
                apps = App.Context.Applications.ToList();
            }
            else
            {
                apps = App.Context.Applications.Where(a => a.client == App.CurrentUser.id_user) .ToList();
            }
            switch (cbChooseType.SelectedIndex)
            {
                case 0:
                    apps = App.Context.Applications.ToList();
                    break;
                case 1:
                    apps = apps.Where(a => a.app_type == 1).ToList();
                    break;
                case 2:
                    apps = apps.Where(a => a.app_type == 2).ToList();
                    break;
                case 3:
                    apps = apps.Where(a => a.app_type == 3).ToList();
                    break;
                case 4:
                    apps = apps.Where(a => a.app_type == 4).ToList();
                    break;
                case 5:
                    apps = apps.Where(a => a.app_type == 5).ToList();
                    break;

            }
            switch (cbSortNumCl.SelectedIndex)
            {
                case 0:
                    apps = apps.OrderBy(a => a.id_app).ToList();
                    break;
                case 1:
                    apps = apps.OrderByDescending(a => a.id_app).ToList();
                    break;
                case 2:
                    apps = apps.OrderBy(a => a.client).ToList();
                    break;
                case 3:
                    apps = apps.OrderByDescending(a => a.client).ToList();
                    break;
            }
            apps = apps.Where(a => a.userName.ToLower().Contains(tbxSearch.Text.ToLower().Trim())).ToList();

            LVApps.ItemsSource = null;
            LVApps.ItemsSource = apps;

            if (LVApps.Items.Count == 0)
            {
                txtError.Visibility= Visibility.Visible;
                txtError.Text = "Заявок нет";
            }
            
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
            AppsLoad();
        }

        private void cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AppsLoad();
        }

        private void tbxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            AppsLoad();
        }
    }
}
