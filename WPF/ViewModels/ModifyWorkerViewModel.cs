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
    class ModifyWorkerViewModel : BindableBase
    {
        private ModifyWorkerView view;
        private Worker worker;
        private string error;
        private WorkerDAO workerDAO = new WorkerDAO();

        private JobDAO jobDAO = new JobDAO();
        private BossDAO bossDAO = new BossDAO();

        public ICommand ModifyComm { get; set; }
        public Worker Worker { get => worker; set { worker = value; OnPropertyChanged("Worker"); } }
        public string Error { get => error; set { error = value; OnPropertyChanged("Error"); } }

        public ModifyWorkerViewModel(ModifyWorkerView view, Worker worker)
        {
            this.view = view;

            Worker = worker;

            ModifyComm = new Command(this.Modify);
        }

        public void Modify()
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

            if (worker.UMCN == "" || worker.UMCN == null)
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
                workerDAO.Update(Worker);

                view.Close();
            }
        }
    }
}
