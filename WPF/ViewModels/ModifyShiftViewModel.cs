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
    class ModifyShiftViewModel : BindableBase
    {
        private ModifyShiftView view;
        private Shift shift;
        private string error;
        private ShiftDAO shiftDAO = new ShiftDAO();
        private JobDAO jobDAO = new JobDAO();

        public ICommand ModifyComm { get; set; }
        public Shift Shift { get => shift; set { shift = value; OnPropertyChanged("Shift"); } }
        public string Error { get => error; set { error = value; OnPropertyChanged("Error"); } }

        public ModifyShiftViewModel(ModifyShiftView view, Shift shift)
        {
            this.view = view;

            Shift = shift;

            ModifyComm = new Command(this.Modify);
        }

        public void Modify()
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

            if (shift.JobJobId == null || shift.JobJobId == 0)
            {
                Error += "Job ID can not be empty or 0!\n";
            }

            if (jobDAO.FindById(shift.JobJobId) == null)
            {
                Error += "Job does not exsist!\n";
            }

            if (Error == "")
            {
                shiftDAO.Update(Shift);

                view.Close();
            }
        }
    }
}
