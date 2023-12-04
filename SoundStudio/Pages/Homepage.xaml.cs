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
            var apps = App.Context.Applications.ToList();
            LVApps.ItemsSource = null;
            LVApps.ItemsSource = apps;
            if (LVApps.Items.Count == 0)
            {
                txtError.Text = "Ничего не найдено";
            }
        }
    }
}
