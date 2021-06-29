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
    class AddHairStylistViewModel : BindableBase
    {
        private HairStylist hairStylist;
        private AddHairStylistView view;
        private string error;
        private JobDAO jobDAO = new JobDAO();

        private ShiftDAO shiftDAO = new ShiftDAO();
        private List<Shift> shifts = new List<Shift>();
        private List<Shift> selectedShifts = new List<Shift>();

        public ICommand AddComm { get; set; }

        public HairStylist HairStylist { get => hairStylist; set { hairStylist = value; OnPropertyChanged("HairStylist"); } }

        public string Error { get => error; set { error = value; OnPropertyChanged("Error"); } }

        public List<Shift> Shifts { get => shifts; set { shifts = value; OnPropertyChanged("Shifts"); } }

        public List<Shift> SelectedShifts { get => selectedShifts; set { selectedShifts = value; OnPropertyChanged("SelectedShifts"); } }

        public AddHairStylistViewModel(AddHairStylistView view)
        {
            this.view = view;

            HairStylist = new HairStylist();
            AddComm = new Command(this.AddHairStylist);

            Shifts = shiftDAO.GetList();
        }

        public void AddHairStylist()
        {
            Error = "";

            if (hairStylist.JobName == null || hairStylist.JobName == "")
            {
                Error += "Job name can not be empty!\n";
            }

            if(SelectedShifts.Count == 0)
            {
                Error += "Must select at least 1 shift!\n";
            }

            if (Error == "")
            {
                hairStylist.Shift = selectedShifts;

                jobDAO.Insert(HairStylist);

                view.Close();
            }
        }
    }
}
