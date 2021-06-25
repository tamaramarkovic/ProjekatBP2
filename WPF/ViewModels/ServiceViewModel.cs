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
    class ServiceViewModel : BindableBase
    {
        private ObservableCollection<Service> services;
        private Service selectedService;
        private ServiceView view;
        private ServiceDAO serviceDAO = new ServiceDAO();

        public ICommand AddComm { get; set; }
        public ICommand ModifyComm { get; set; }
        public ICommand RemoveComm { get; set; }

        public ObservableCollection<Service> Services { get => services; set { services = value; OnPropertyChanged("Services"); } }

        public Service SelectedService { get => selectedService; set { selectedService = value; OnPropertyChanged("SelectedService"); } }

        public ServiceViewModel(ServiceView view)
        {
            this.view = view;

            AddComm = new Command(this.Add);
            ModifyComm = new Command(this.Modify);
            RemoveComm = new Command(this.Remove);

            SelectedService = new Service();
            Services = new ObservableCollection<Service>();

            Load();
        }

        public void Add()
        {
            AddServiceView newWindow = new AddServiceView();
            newWindow.DataContext = new AddServiceViewModel(newWindow);
            newWindow.ShowDialog();
            Load();
        }

        public void Modify()
        {
            ModifyServiceView newWindow = new ModifyServiceView();
            newWindow.DataContext = new ModifyServiceViewModel(newWindow, SelectedService);
            newWindow.ShowDialog();
            Load();
            SelectedService = new Service();
        }

        public void Remove()
        {
            serviceDAO.Delete(SelectedService.ServiceId);
            Load();
            SelectedService = new Service();
        }

        public void Load()
        {
            Services = new ObservableCollection<Service>();

            foreach (Service item in serviceDAO.GetList())
            {
                Services.Add(item);
            }
        }
    }
}
