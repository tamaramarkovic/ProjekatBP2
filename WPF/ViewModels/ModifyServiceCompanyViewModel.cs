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

        public ICommand ModifyComm { get; set; }
        public ServiceCompany ServiceCompany { get => serviceCompany; set { serviceCompany = value; OnPropertyChanged("ServiceCompany"); } }
        public string Error { get => error; set { error = value; OnPropertyChanged("Error"); } }

        public ModifyServiceCompanyViewModel(ModifyServiceCompanyView view, ServiceCompany serviceCompany)
        {
            this.view = view;

            ServiceCompany = serviceCompany;

            ModifyComm = new Command(this.Modify);
        }

        public void Modify()
        {
            Error = "";

            if (serviceCompany.CompanyName == null || serviceCompany.CompanyName == "")
            {
                Error += "Name can not be empty!\n";
            }

            if (Error == "")
            {
                serviceCompanyDAO.Update(ServiceCompany);

                view.Close();
            }
        }
    }
}
