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
    class ModifyBillViewModel : BindableBase
    {
        private ModifyBillView view;
        private Bill bill;
        private string error;
        private BillDAO billDAO = new BillDAO();
        private WorkerDAO workerDAO = new WorkerDAO();

        private ServiceDAO serviceDAO = new ServiceDAO();
        private List<Service> services = new List<Service>();
        private List<Service> selectedServices = new List<Service>();

        public ICommand ModifyComm { get; set; }
        public Bill Bill { get => bill; set { bill = value; OnPropertyChanged("Bill"); } }
        public string Error { get => error; set { error = value; OnPropertyChanged("Error"); } }

        public List<Service> Services { get => services; set { services = value; OnPropertyChanged("Services"); } }
        public List<Service> SelectedServices { get => selectedServices; set { selectedServices = value; OnPropertyChanged("SelectedServices"); } }

        public ModifyBillViewModel(ModifyBillView view, Bill bill)
        {
            this.view = view;

            Bill = bill;

            ModifyComm = new Command(this.Modify);

            Services = serviceDAO.GetList();
        }

        public void Modify()
        {
            Error = "";

            if (Bill.Date == null)
            {
                Error += "Date can not be empty!\n";
            }

            if (Bill.WorkerWorkerId == 0)
            {
                Error += "Worker ID can not be empty or 0!\n";
            }

            if (workerDAO.FindById(Bill.WorkerWorkerId) == null)
            {
                Error += "Worker does not exsist!\n";
            }

            if (SelectedServices.Count == 0)
            {
                Error += "Must select at least 1 service!\n";
            }

            if (Error == "")
            {
                bill.Services = selectedServices;

                foreach (var service in bill.Services)
                {
                    foreach (var bill in service.Bills)
                    {
                        bill.BillId = Bill.BillId;
                        serviceDAO.Update(service);
                    }

                    serviceDAO.Update(service);
                }

                billDAO.Update(Bill);

                view.Close();
            }
        }
    }
}
