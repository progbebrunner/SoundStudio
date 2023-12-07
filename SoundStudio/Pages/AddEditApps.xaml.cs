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
        public AddEditPage(int x)
        {
            InitializeComponent();
            if(App.CurrentUser.role == 1)
            {
                txtClient.Visibility = Visibility.Hidden;
                cbClients.Visibility = Visibility.Hidden;
                txtStatus.Visibility = Visibility.Hidden;
                cbStatuses.Visibility = Visibility.Hidden;
            }
            ComboBoxesLoad(x);
        }



        public void ComboBoxesLoad(int x)
        {            
            var app = App.Context.Applications.Where(a => a.id_app == x).FirstOrDefault();
            var clients = App.Context.Users.Select(c => c.login).ToList();
            var types = App.Context.ApplicationTypes.Select(c => c.app_type).ToList();
            var statuses = App.Context.ApplicationStatuses.Select(c => c.app_status).ToList();

            txtIdAppNum.Text = "№" + app.id_app.ToString();
            cbClients.ItemsSource = clients;
            cbTypes.ItemsSource = types;
            cbStatuses.ItemsSource = statuses;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var type = App.Context.ApplicationTypes.Where(t => t.app_type== txtType.Text).FirstOrDefault();
            var status = App.Context.ApplicationStatuses.Where(s => s.app_status == txtStatus.Text).FirstOrDefault();
            var apps = App.Context.Applications.Where(a => a.client == App.CurrentUser.id_user && a.app_type == type.id_apptype && a.app_status == status.id_appstatus) .ToList();
            if(apps.Count() > 0)
            {
                MessageBox.Show("Такая заявка уже существуюет");
            }
            else
            {

            }
        }
    }
}
