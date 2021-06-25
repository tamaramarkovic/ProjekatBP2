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
    class AddServiceViewModel : BindableBase
    {
        private Service service;
        private AddServiceView view;
        private string error;
        private ServiceDAO serviceDAO = new ServiceDAO();

        public ICommand AddComm { get; set; }

        public Service Service { get => service; set { service = value; OnPropertyChanged("Service"); } }

        public string Error { get => error; set { error = value; OnPropertyChanged("Error"); } }

        public AddServiceViewModel(AddServiceView view)
        {
            this.view = view;

            Service = new Service();
            AddComm = new Command(this.AddService);
        }

        public void AddService()
        {
            Error = "";

            if (service.Price == 0)
            {
                Error += "Price can not be empty or 0!\n";
            }

            if (Error == "")
            {
                serviceDAO.Insert(Service);

                view.Close();
            }
        }
    }
}
