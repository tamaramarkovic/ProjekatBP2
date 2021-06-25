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
    class ModifyServiceViewModel : BindableBase
    {
        private ModifyServiceView view;
        private Service service;
        private string error;
        private ServiceDAO serviceDAO = new ServiceDAO();

        public ICommand ModifyComm { get; set; }
        public Service Service { get => service; set { service = value; OnPropertyChanged("Service"); } }
        public string Error { get => error; set { error = value; OnPropertyChanged("Error"); } }

        public ModifyServiceViewModel(ModifyServiceView view, Service service)
        {
            this.view = view;

            Service = service;

            ModifyComm = new Command(this.Modify);
        }

        public void Modify()
        {
            Error = "";

            if (service.Price == 0)
            {
                Error += "Price can not be empty or 0!\n";
            }

            if (Error == "")
            {
                serviceDAO.Update(Service);

                view.Close();
            }
        }
    }
}
