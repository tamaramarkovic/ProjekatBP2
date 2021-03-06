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
    class AddWorkerViewModel : BindableBase
    {
        private Worker worker;
        private AddWorkerView view;
        private string error;
        private WorkerDAO workerDAO = new WorkerDAO();
        private JobDAO jobDAO = new JobDAO();
        private BossDAO bossDAO = new BossDAO();

        public ICommand AddComm { get; set; }

        public Worker Worker { get => worker; set { worker = value; OnPropertyChanged("Worker"); } }

        public string Error { get => error; set { error = value; OnPropertyChanged("Error"); } }

        public AddWorkerViewModel(AddWorkerView view)
        {
            this.view = view;

            Worker = new Worker();
            AddComm = new Command(this.AddWorker);
        }

        public void AddWorker()
        {
            Error = "";

            if (worker.WorkerName == "" || worker.WorkerName == null)
            {
                Error += "Name can not be empty!\n";
            }

            if (worker.WorkerSurname == "" || worker.WorkerSurname == null)
            {
                Error += "Surname can not be empty or 0!\n";
            }

            if (worker.Salary == 0)
            {
                Error += "Salary can not be empty or 0!\n";
            }

            if (worker.WorkerDOB == null)
            {
                Error += "Date of birth can not be empty!\n";
            }

            if (worker.UMCN == "" || worker.UMCN == null || worker.UMCN == "0")
            {
                Error += "UMCN can not be empty or 0!\n";
            }

            if (worker.JobJobId == 0)
            {
                Error += "Job can not be empty!\n";
            }

            if (jobDAO.FindById(worker.JobJobId) == null)
            {
                Error += "Job does not exsist!\n";
            }

            if (Error == "")
            {
                workerDAO.Insert(Worker);

                view.Close();
            }
        }
    }
}
