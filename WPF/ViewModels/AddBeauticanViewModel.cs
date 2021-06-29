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
    class AddBeauticanViewModel : BindableBase
    {
        private Beautican beautican;
        private AddBeauticanView view;
        private string error;
        private JobDAO jobDAO = new JobDAO();
        private ShiftDAO shiftDAO = new ShiftDAO();
        private List<Shift> shifts = new List<Shift>();
        private List<Shift> selectedShifts = new List<Shift>();

        public ICommand AddComm { get; set; }

        public Beautican Beautican { get => beautican; set { beautican = value; OnPropertyChanged("Beautican"); } }

        public string Error { get => error; set { error = value; OnPropertyChanged("Error"); } }

        public List<Shift> Shifts { get => shifts; set { shifts = value; OnPropertyChanged("Shifts"); } }

        public List<Shift> SelectedShifts { get => selectedShifts; set { selectedShifts = value; OnPropertyChanged("SelectedShifts"); } }

        public AddBeauticanViewModel(AddBeauticanView view)
        {
            this.view = view;

            Beautican = new Beautican();
            AddComm = new Command(this.AddBeautican);

            Shifts = shiftDAO.GetList();
        }

        public void AddBeautican()
        {
            Error = "";

            if (beautican.JobName == null || beautican.JobName == "")
            {
                Error += "Job name can not be empty!\n";
            }

            if (SelectedShifts.Count == 0)
            {
                Error += "Must select at least 1 shift!\n";
            }

            if (Error == "")
            {
                beautican.Shift = SelectedShifts;

                jobDAO.Insert(Beautican);

                view.Close();
            }
        }
    }
}
