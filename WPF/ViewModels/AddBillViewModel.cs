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
    class AddBillViewModel : BindableBase
    {
        private Bill bill;
        private AddBillView view;
        private string error;
        private BillDAO billDAO = new BillDAO();
        private WorkerDAO workerDAO = new WorkerDAO();

        public ICommand AddComm { get; set; }

        public Bill Bill { get => bill; set { bill = value; OnPropertyChanged("Bill"); } }

        public string Error { get => error; set { error = value; OnPropertyChanged("Error"); } }

        public AddBillViewModel(AddBillView view)
        {
            this.view = view;

            Bill = new Bill();
            AddComm = new Command(this.AddBill);
        }

        public void AddBill()
        {
            Error = "";

            if (bill.Date == null)
            {
                Error += "Date can not be empty!\n";
            }

            if (bill.WorkerWorkerId == 0)
            {
                Error += "Worker ID can not be empty or 0!\n";
            }

            if(workerDAO.FindById(Bill.WorkerWorkerId) == null)
            {
                Error += "Worker does not exsist!\n";
            }

            if (Error == "")
            {
                billDAO.Insert(Bill);

                view.Close();
            }
        }
    }
}
