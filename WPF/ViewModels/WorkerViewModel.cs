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
    class WorkerViewModel : BindableBase
    {
        private ObservableCollection<Worker> workers;
        private Worker selectedWorker;
        private WorkerView view;
        private WorkerDAO workerDAO = new WorkerDAO();

        public ICommand AddComm { get; set; }
        public ICommand ModifyComm { get; set; }
        public ICommand RemoveComm { get; set; }

        public ObservableCollection<Worker> Workers { get => workers; set { workers = value; OnPropertyChanged("Workers"); } }

        public Worker SelectedWorker { get => selectedWorker; set { selectedWorker = value; OnPropertyChanged("SelectedWorker"); } }

        public WorkerViewModel(WorkerView view)
        {
            this.view = view;

            AddComm = new Command(this.Add);
            ModifyComm = new Command(this.Modify);
            RemoveComm = new Command(this.Remove);

            SelectedWorker = new Worker();
            Workers = new ObservableCollection<Worker>();

            Load();
        }

        public void Add()
        {
            AddWorkerView newWindow = new AddWorkerView();
            newWindow.DataContext = new AddWorkerViewModel(newWindow);
            newWindow.ShowDialog();
            Load();
        }

        public void Modify()
        {
            ModifyWorkerView newWindow = new ModifyWorkerView();
            newWindow.DataContext = new ModifyWorkerViewModel(newWindow, SelectedWorker);
            newWindow.ShowDialog();
            Load();
            SelectedWorker = new Worker();
        }

        public void Remove()
        {
            workerDAO.Delete(SelectedWorker.WorkerId);
            Load();
            SelectedWorker = new Worker();
        }

        public void Load()
        {
            Workers = new ObservableCollection<Worker>();

            foreach (Worker item in workerDAO.GetList())
            {
                Workers.Add(item);
            }
        }
    }
}
