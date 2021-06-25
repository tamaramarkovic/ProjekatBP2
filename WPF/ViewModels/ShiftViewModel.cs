using ProjekatBP2;
using ProjekatBP2.DAO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF.View;

namespace WPF.ViewModels
{
    class ShiftViewModel : BindableBase
    {
        private ObservableCollection<Shift> shifts;
        private Shift selectedShift;
        private ShiftView view;
        private ShiftDAO shiftDAO = new ShiftDAO();

        public ICommand AddComm { get; set; }
        public ICommand ModifyComm { get; set; }
        public ICommand RemoveComm { get; set; }

        public ObservableCollection<Shift> Shifts { get => shifts; set { shifts = value; OnPropertyChanged("Shifts"); } }

        public Shift SelectedShift { get => selectedShift; set { selectedShift = value; OnPropertyChanged("SelectedShift"); } }

        public ShiftViewModel(ShiftView view)
        {
            this.view = view;

            AddComm = new Command(this.Add);
            ModifyComm = new Command(this.Modify);
            RemoveComm = new Command(this.Remove);

            SelectedShift = new Shift();
            Shifts = new ObservableCollection<Shift>();

            Load();
        }

        public void Add()
        {
            AddShiftView newWindow = new AddShiftView();
            newWindow.DataContext = new AddShiftViewModel(newWindow);
            newWindow.ShowDialog();
            Load();
        }

        public void Modify()
        {
            ModifyShiftView newWindow = new ModifyShiftView();
            newWindow.DataContext = new ModifyShiftViewModel(newWindow, SelectedShift);
            newWindow.ShowDialog();
            Load();
            SelectedShift = new Shift();
        }

        public void Remove()
        {
            shiftDAO.Delete(SelectedShift.ShiftId);
            Load();
            SelectedShift = new Shift();
        }

        public void Load()
        {
            Shifts = new ObservableCollection<Shift>();

            foreach (Shift item in shiftDAO.GetList())
            {
                Shifts.Add(item);
            }
        }
    }
}
