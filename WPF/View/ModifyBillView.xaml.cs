using ProjekatBP2;
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
using WPF.ViewModels;

namespace WPF.View
{
    /// <summary>
    /// Interaction logic for ModifyBillView.xaml
    /// </summary>
    public partial class ModifyBillView : Window
    {
        public ModifyBillView()
        {
            InitializeComponent();
        }

        private void ServicesList_MouseUp(object sender, MouseButtonEventArgs e)
        {
            List<Service> services = new List<Service>();

            foreach (Service item in ServicesList.SelectedItems)
            {
                services.Add(item);
            }

            ((ModifyBillViewModel)DataContext).SelectedServices = services;
        }
    }
}
