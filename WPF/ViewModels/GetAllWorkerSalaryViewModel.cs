using ProjekatBP2;
using ProjekatBP2.DAO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF.View;

namespace WPF.ViewModels
{
    public class GetAllWorkerSalaryViewModel : BindableBase
    {
        private ObservableCollection<GetAllWorkerSalary_Result> workers;
        private GetAllWorkerSalaryView view;
        private WorkerDAO workerDAO = new WorkerDAO();
        private int salary;

        public ICommand SearchComm { get; set; }

        public ObservableCollection<GetAllWorkerSalary_Result> Workers { get => workers; set { workers = value; OnPropertyChanged("Workers"); } }

        public int Salary { get => salary; set { salary = value; OnPropertyChanged("Salary"); } }

        public GetAllWorkerSalaryViewModel(GetAllWorkerSalaryView view)
        {
            this.view = view;

            SearchComm = new Command(this.Search);

            Workers = new ObservableCollection<GetAllWorkerSalary_Result>();
        }

        public void Search()
        {
            var result = workerDAO.GetAllWorkers(Salary);
            Workers = new ObservableCollection<GetAllWorkerSalary_Result>(result);
        }
    }
}
