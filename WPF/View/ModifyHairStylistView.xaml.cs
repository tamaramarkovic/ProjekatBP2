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
    /// Interaction logic for ModifyHairStylistView.xaml
    /// </summary>
    public partial class ModifyHairStylistView : Window
    {
        public ModifyHairStylistView()
        {
            InitializeComponent();
        }

        private void ShiftsList_MouseUp(object sender, MouseButtonEventArgs e)
        {
            List<Shift> shifts = new List<Shift>();

            foreach (Shift item in ShiftsList.SelectedItems)
            {
                shifts.Add(item);
            }

            ((ModifyHairStylistViewModel)DataContext).SelectedShifts = shifts;
        }
    }
}
