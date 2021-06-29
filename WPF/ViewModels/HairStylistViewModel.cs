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
    class HairStylistViewModel : BindableBase
    {
        private ObservableCollection<HairStylist> hairStylists;
        private HairStylist selectedHairStylist;
        private HairStylistView view;
        private JobDAO jobDAO = new JobDAO();
        private ShiftDAO shiftDAO = new ShiftDAO();

        public ICommand AddComm { get; set; }
        public ICommand ModifyComm { get; set; }
        public ICommand RemoveComm { get; set; }

        public ObservableCollection<HairStylist> HairStylists { get => hairStylists; set { hairStylists = value; OnPropertyChanged("HairStylists"); } }

        public HairStylist SelectedHairStylist { get => selectedHairStylist; set { selectedHairStylist = value; OnPropertyChanged("SelectedHairStylist"); } }

        public HairStylistViewModel(HairStylistView view)
        {
            this.view = view;

            AddComm = new Command(this.Add);
            ModifyComm = new Command(this.Modify);
            RemoveComm = new Command(this.Remove);

            SelectedHairStylist = new HairStylist();
            HairStylists = new ObservableCollection<HairStylist>();

            Load();
        }

        public void Add()
        {
            AddHairStylistView newWindow = new AddHairStylistView();
            newWindow.DataContext = new AddHairStylistViewModel(newWindow);
            newWindow.ShowDialog();
            Load();
        }

        public void Modify()
        {
            ModifyHairStylistView newWindow = new ModifyHairStylistView();
            newWindow.DataContext = new ModifyHairStylistViewModel(newWindow, SelectedHairStylist);
            newWindow.ShowDialog();
            Load();
            SelectedHairStylist = new HairStylist();
        }

        public void Remove()
        {
            jobDAO.Delete(SelectedHairStylist.JobId);
            Load();
            SelectedHairStylist = new HairStylist();
        }

        public void Load()
        {
            HairStylists = new ObservableCollection<HairStylist>();

            foreach (HairStylist item in jobDAO.GetHairStylists())
            {
                HairStylists.Add(item);
            }
        }
    }
}
