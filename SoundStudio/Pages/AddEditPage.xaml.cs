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
        public Applications current_app = null;
        public AddEditPage(Applications x)
        {
            InitializeComponent();
            if(App.CurrentUser.role == 1)
            {
                txtClient.Visibility = Visibility.Hidden;
                cbClients.Visibility = Visibility.Hidden;
                txtStatus.Visibility = Visibility.Hidden;
                cbStatuses.Visibility = Visibility.Hidden;
            }
            current_app = x;
            InfoLoad();
            ComboBoxesLoad(x);
        }

        public AddEditPage()
        {
            InitializeComponent();
            txtIdApp.Visibility = Visibility.Hidden;
            if(App.CurrentUser.role == 1)
            {
                txtClient.Visibility = Visibility.Hidden;
                cbClients.Visibility = Visibility.Hidden;
                txtStatus.Visibility = Visibility.Hidden;
                cbStatuses.Visibility = Visibility.Hidden;
            }
            InfoLoad();
        }

        public void InfoLoad()
        {
            cbClients.ItemsSource = App.Context.Users.Select(c => c.login).ToList();
            cbTypes.ItemsSource = App.Context.ApplicationTypes.Select(c => c.app_type).ToList();
            cbStatuses.ItemsSource = App.Context.ApplicationStatuses.Select(c => c.app_status).ToList();            
        }

        public void ComboBoxesLoad(Applications x)
        {            
            var app = App.Context.Applications.Where(a => a.id_app == x.id_app).FirstOrDefault();
            var client = App.Context.Users.Where(c => c.id_user == app.client).FirstOrDefault();
            var type = App.Context.ApplicationTypes.Where(c => c.id_apptype == app.app_type).FirstOrDefault();
            var status = App.Context.ApplicationStatuses.Where(c => c.id_appstatus == app.app_status).FirstOrDefault();

            txtIdAppNum.Text = "№" + app.id_app.ToString();
            cbClients.SelectedIndex = client.id_user - 1;
            cbTypes.SelectedIndex = type.id_apptype - 1;
            txtQuantuty.Text = app.quantity.ToString();
            cbStatuses.SelectedIndex = status.id_appstatus - 1;            
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (cbTypes.Text != "")
            {
                if (Int32.TryParse(txtQuantuty.Text, out int x))
                {
                    int id_client, id_status;
                    if (App.CurrentUser.role == 1)
                    {
                        id_client = App.CurrentUser.id_user;
                        id_status = 1;
                    }
                    else
                    {
                        var user = App.Context.Users.Where(u => u.login == cbClients.Text).FirstOrDefault();
                        id_client = user.id_user;
                        var status = App.Context.ApplicationStatuses.Where(s => s.app_status == cbStatuses.Text).FirstOrDefault();
                        id_status = status.id_appstatus;
                    }
                    var type = App.Context.ApplicationTypes.Where(t => t.app_type == cbTypes.Text).FirstOrDefault();
                    int id_type = type.id_apptype;
                    var new_app = new Applications
                    {
                        client = id_client,
                        app_type = id_type,
                        quantity = Int32.Parse(txtQuantuty.Text),
                        app_status = id_status
                    };
                    if (txtIdAppNum.Text.ToString() == "")
                    {                        
                        App.Context.Applications.Add(new_app);
                        App.Context.SaveChanges();
                        MessageBox.Show("Заявка успешно добавлена");
                    }
                    else
                    {
                        current_app.client = id_client;
                        current_app.app_type = id_type;
                        current_app.quantity = Int32.Parse(txtQuantuty.Text);
                        current_app.app_status = id_status;
                        App.Context.SaveChanges();
                        MessageBox.Show("Данные по заявке успешно обновлены");

                    }
                    NavigationService.Navigate(new Homepage());
                }
                else
                {
                    MessageBox.Show("В поле 'Количество' введено не число");
                }
            }
            else
            {
                MessageBox.Show("В поле 'Услуга' ничего не выбрано");
            }

        }
    }
}
