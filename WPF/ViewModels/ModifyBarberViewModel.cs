using ProjekatBP2;
using ProjekatBP2.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF.View;

namespace WPF.ViewModels
{
    class ModifyBarberViewModel : BindableBase
    {
        private ModifyBarberView view;
        private Barber barber;
        private string error;
        private JobDAO jobDAO = new JobDAO();

        private ShiftDAO shiftDAO = new ShiftDAO();
        private List<Shift> shifts = new List<Shift>();
        private List<Shift> selectedShifts = new List<Shift>();

        public ICommand ModifyComm { get; set; }
        public Barber Barber { get => barber; set { barber = value; OnPropertyChanged("Barber"); } }
        public string Error { get => error; set { error = value; OnPropertyChanged("Error"); } }
        public List<Shift> Shifts { get => shifts; set { shifts = value; OnPropertyChanged("Shifts"); } }
        public List<Shift> SelectedShifts { get => selectedShifts; set { selectedShifts = value; OnPropertyChanged("SelectedShifts"); } }

        public ModifyBarberViewModel(ModifyBarberView view, Barber barber)
        {
            this.view = view;

            Barber = barber;

            ModifyComm = new Command(this.Modify);

            Shifts = shiftDAO.GetList();
        }

        public void Modify()
        {
            Error = "";

            if (barber.JobName == null || barber.JobName == "")
            {
                Error += "Job name can not be empty or 0!\n";
            }

            if (SelectedShifts.Count == 0)
            {
                Error += "Must select at least 1 shift!\n";
            }

            if (Error == "")
            {
                barber.Shift = selectedShifts;

                foreach (var shift in barber.Shift)
                {
                    shift.JobJobId = barber.JobId;
                    shiftDAO.Update(shift);
                }

                jobDAO.Update(Barber);

                view.Close();
            }
        }
    }
}
