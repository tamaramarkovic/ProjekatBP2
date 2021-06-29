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
    class AddServiceCompanyViewModel : BindableBase
    {
        private ServiceCompany serviceCompany;
        private AddServiceCompanyView view;
        private string error;
        private ServiceCompanyDAO serviceCompanyDAO = new ServiceCompanyDAO();
        
        private WorkDAO workDAO = new WorkDAO();
        private List<Work> works = new List<Work>();
        private List<Work> selectedWorks = new List<Work>();

        public ICommand AddComm { get; set; }

        public ServiceCompany ServiceCompany { get => serviceCompany; set { serviceCompany = value; OnPropertyChanged("ServiceCompany"); } }

        public string Error { get => error; set { error = value; OnPropertyChanged("Error"); } }

        public List<Work> Works { get => works; set { works = value; OnPropertyChanged("Works"); } }

        public List<Work> SelectedWorks { get => selectedWorks; set { selectedWorks = value; OnPropertyChanged("SelectedWorks"); } }

        public AddServiceCompanyViewModel(AddServiceCompanyView view)
        {
            this.view = view;

            ServiceCompany = new ServiceCompany();
            AddComm = new Command(this.AddServiceCompany);

            Works = workDAO.GetList();
        }

        public void AddServiceCompany()
        {
            Error = "";

            if (serviceCompany.CompanyName == null || serviceCompany.CompanyName == "")
            {
                Error += "Name can not be empty!\n";
            }

            if (SelectedWorks.Count == 0)
            {
                Error += "Must select at least 1 work!\n";
            }

            if (Error == "")
            {
                serviceCompany.Work = SelectedWorks;

                serviceCompanyDAO.Insert(ServiceCompany);

                view.Close();
            }
        }
    }
}
