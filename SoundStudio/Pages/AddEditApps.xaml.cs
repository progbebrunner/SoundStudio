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

namespace SoundStudio.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        public AddEditPage()
        {
            InitializeComponent();
            if(App.CurrentUser.role == 1)
            {
                txtClient.Visibility = Visibility.Hidden;
                cbClients.Visibility = Visibility.Hidden;
                txtStatus.Visibility = Visibility.Hidden;
                cbStatuses.Visibility = Visibility.Hidden;
            }
            ComboBoxesLoad();
        }

        public void ComboBoxesLoad()
        {
            var clients = App.Context.Users.Select(c => c.login).ToList();
            var types = App.Context.ApplicationTypes.Select(c => c.app_type).ToList();
            var statuses = App.Context.ApplicationStatuses.Select(c => c.app_status).ToList();

            cbClients.ItemsSource = clients;
            cbTypes.ItemsSource = types;
            cbStatuses.ItemsSource = statuses;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
