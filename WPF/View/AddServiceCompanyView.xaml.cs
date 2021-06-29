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
    /// Interaction logic for AddServiceCompanyView.xaml
    /// </summary>
    public partial class AddServiceCompanyView : Window
    {
        public AddServiceCompanyView()
        {
            InitializeComponent();
        }

        private void WorksList_MouseUp(object sender, MouseButtonEventArgs e)
        {
            List<Work> works = new List<Work>();

            foreach (Work item in WorksList.SelectedItems)
            {
                works.Add(item);
            }

            ((AddServiceCompanyViewModel)DataContext).SelectedWorks = works;
        }
    }
}
