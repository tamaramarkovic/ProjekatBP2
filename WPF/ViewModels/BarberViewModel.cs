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
    class BarberViewModel : BindableBase
    {
        private ObservableCollection<Barber> barbers;
        private Barber selectedBarber;
        private BarberView view;
        private JobDAO jobDAO = new JobDAO();

        public ICommand AddComm { get; set; }
        public ICommand ModifyComm { get; set; }
        public ICommand RemoveComm { get; set; }

        public ObservableCollection<Barber> Barbers { get => barbers; set { barbers = value; OnPropertyChanged("Barbers"); } }

        public Barber SelectedBarber { get => selectedBarber; set { selectedBarber = value; OnPropertyChanged("SelectedBarber"); } }

        public BarberViewModel(BarberView view)
        {
            this.view = view;

            AddComm = new Command(this.Add);
            ModifyComm = new Command(this.Modify);
            RemoveComm = new Command(this.Remove);

            SelectedBarber = new Barber();
            Barbers = new ObservableCollection<Barber>();

            Load();
        }

        public void Add()
        {
            AddBarberView newWindow = new AddBarberView();
            newWindow.DataContext = new AddBarberViewModel(newWindow);
            newWindow.ShowDialog();
            Load();
        }

        public void Modify()
        {
            ModifyBarberView newWindow = new ModifyBarberView();
            newWindow.DataContext = new ModifyBarberViewModel(newWindow, SelectedBarber);
            newWindow.ShowDialog();
            Load();
            SelectedBarber = new Barber();
        }

        public void Remove()
        {
            jobDAO.Delete(SelectedBarber.JobId);
            Load();
            SelectedBarber = new Barber();
        }

        public void Load()
        {
            Barbers = new ObservableCollection<Barber>();

            foreach (Barber item in jobDAO.GetBarbers())
            {
                Barbers.Add(item);
            }
        }
    }
}
