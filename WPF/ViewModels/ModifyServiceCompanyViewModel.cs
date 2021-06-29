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
    class ModifyServiceCompanyViewModel : BindableBase
    {
        private ModifyServiceCompanyView view;
        private ServiceCompany serviceCompany;
        private string error;
        private ServiceCompanyDAO serviceCompanyDAO = new ServiceCompanyDAO();

        private List<Work> selectedWorks = new List<Work>();
        private WorkDAO workDAO = new WorkDAO();
        private List<Work> works = new List<Work>();


        public ICommand ModifyComm { get; set; }
        public ServiceCompany ServiceCompany { get => serviceCompany; set { serviceCompany = value; OnPropertyChanged("ServiceCompany"); } }
        public string Error { get => error; set { error = value; OnPropertyChanged("Error"); } }

        public List<Work> SelectedWorks { get => selectedWorks; set { selectedWorks = value; OnPropertyChanged("SelectedWorks"); } }

        public List<Work> Works { get => works; set { works = value; OnPropertyChanged("Works"); } }

        public ModifyServiceCompanyViewModel(ModifyServiceCompanyView view, ServiceCompany serviceCompany)
        {
            this.view = view;

            ServiceCompany = serviceCompany;

            ModifyComm = new Command(this.Modify);

            Works = workDAO.GetList();
        }

        public void Modify()
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
                serviceCompany.Work = selectedWorks;

                serviceCompanyDAO.Update(ServiceCompany);

                view.Close();
            }
        }
    }
}
