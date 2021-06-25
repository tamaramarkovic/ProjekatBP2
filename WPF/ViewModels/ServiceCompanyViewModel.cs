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
    class ServiceCompanyViewModel : BindableBase
    {
        private ObservableCollection<ServiceCompany> serviceCompanies;
        private ServiceCompany selectedServiceCompany;
        private ServiceCompanyView view;
        private ServiceCompanyDAO serviceCompanyDAO = new ServiceCompanyDAO();

        public ICommand AddComm { get; set; }
        public ICommand ModifyComm { get; set; }
        public ICommand RemoveComm { get; set; }

        public ObservableCollection<ServiceCompany> ServiceCompanies { get => serviceCompanies; set { serviceCompanies = value; OnPropertyChanged("ServiceCompanies"); } }

        public ServiceCompany SelectedServiceCompany { get => selectedServiceCompany; set { selectedServiceCompany = value; OnPropertyChanged("SelectedServiceCompany"); } }

        public ServiceCompanyViewModel(ServiceCompanyView view)
        {
            this.view = view;

            AddComm = new Command(this.Add);
            ModifyComm = new Command(this.Modify);
            RemoveComm = new Command(this.Remove);

            SelectedServiceCompany = new ServiceCompany();
            ServiceCompanies = new ObservableCollection<ServiceCompany>();

            Load();
        }

        public void Add()
        {
            AddServiceCompanyView newWindow = new AddServiceCompanyView();
            newWindow.DataContext = new AddServiceCompanyViewModel(newWindow);
            newWindow.ShowDialog();
            Load();
        }

        public void Modify()
        {
            ModifyServiceCompanyView newWindow = new ModifyServiceCompanyView();
            newWindow.DataContext = new ModifyServiceCompanyViewModel(newWindow, selectedServiceCompany);
            newWindow.ShowDialog();
            Load();
            SelectedServiceCompany = new ServiceCompany();
        }

        public void Remove()
        {
            serviceCompanyDAO.Delete(SelectedServiceCompany.CompanyId);
            Load();
            SelectedServiceCompany = new ServiceCompany();
        }

        public void Load()
        {
            ServiceCompanies = new ObservableCollection<ServiceCompany>();

            foreach (ServiceCompany item in serviceCompanyDAO.GetList())
            {
                ServiceCompanies.Add(item);
            }
        }
    }
}
