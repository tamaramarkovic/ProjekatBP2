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

        public ICommand ModifyComm { get; set; }
        public Bill Bill { get => bill; set { bill = value; OnPropertyChanged("Bill"); } }
        public string Error { get => error; set { error = value; OnPropertyChanged("Error"); } }

        public ModifyBillViewModel(ModifyBillView view, Bill bill)
        {
            this.view = view;

            Bill = bill;

            ModifyComm = new Command(this.Modify);
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

            if (Error == "")
            {
                billDAO.Update(Bill);

                view.Close();
            }
        }
    }
}
