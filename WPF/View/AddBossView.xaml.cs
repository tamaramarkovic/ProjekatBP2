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
    /// Interaction logic for AddBossView.xaml
    /// </summary>
    public partial class AddBossView : Window
    {
        public AddBossView()
        {
            InitializeComponent();
        }

        private void WorkersList_MouseUp(object sender, MouseButtonEventArgs e)
        {
            List<Worker> workers = new List<Worker>();

            foreach (Worker item in WorkersList.SelectedItems)
            {
                workers.Add(item);
            }

            ((AddBossViewModel)DataContext).SelectedWorkers = workers;
        }
    }
}
