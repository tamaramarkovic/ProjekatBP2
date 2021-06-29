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
    class AddShiftViewModel : BindableBase
    {
        private Shift shift;
        private AddShiftView view;
        private string error;
        private ShiftDAO shiftDAO = new ShiftDAO();
        private JobDAO jobDAO = new JobDAO();

        public ICommand AddComm { get; set; }

        public Shift Shift { get => shift; set { shift = value; OnPropertyChanged("Shift"); } }

        public string Error { get => error; set { error = value; OnPropertyChanged("Error"); } }

        public AddShiftViewModel(AddShiftView view)
        {
            this.view = view;

            Shift = new Shift();
            AddComm = new Command(this.AddShift);
        }

        public void AddShift()
        {
            Error = "";

            if (shift.StartTime == null)
            {
                Error += "Start time can not be empty!\n";
            }

            if (shift.EndTime == null)
            {
                Error += "End time can not be empty!\n";
            }

            if (shift.JobJobId != null && jobDAO.FindById(Shift.JobJobId) == null)
            {
                Error += "Job does not exsist!\n";
            }

            if (Error == "")
            {
                shiftDAO.Insert(Shift);

                view.Close();
            }
        }
    }
}
