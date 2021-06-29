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
    class ModifyBeauticanViewModel : BindableBase
    {
        private ModifyBeauticanView view;
        private Beautican beautican;
        private string error;
        private JobDAO jobDAO = new JobDAO();
        private ShiftDAO shiftDAO = new ShiftDAO();
        private List<Shift> shifts = new List<Shift>();
        private List<Shift> selectedShifts = new List<Shift>();

        public ICommand ModifyComm { get; set; }
        public Beautican Beautican { get => beautican; set { beautican = value; OnPropertyChanged("Beautican"); } }
        public string Error { get => error; set { error = value; OnPropertyChanged("Error"); } }

        public List<Shift> Shifts { get => shifts; set { shifts = value; OnPropertyChanged("Shifts"); } }
        public List<Shift> SelectedShifts { get => selectedShifts; set { selectedShifts = value; OnPropertyChanged("SelectedShifts"); } }

        public ModifyBeauticanViewModel(ModifyBeauticanView view, Beautican beautican)
        {
            this.view = view;

            Beautican = beautican;

            ModifyComm = new Command(this.Modify);

            Shifts = shiftDAO.GetList();
        }

        public void Modify()
        {
            Error = "";

            if (beautican.JobName == null || beautican.JobName == "")
            {
                Error += "Job name can not be empty or 0!\n";
            }

            if (SelectedShifts.Count == 0)
            {
                Error += "Must select at least 1 shift!\n";
            }

            if (Error == "")
            {
                beautican.Shift = selectedShifts;

                foreach (var shift in beautican.Shift)
                {
                    shift.JobJobId = beautican.JobId;
                    shiftDAO.Update(shift);
                }

                jobDAO.Update(Beautican);

                view.Close();
            }
        }
    }
}
