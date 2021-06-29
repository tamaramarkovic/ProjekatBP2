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
    class ModifyBossViewModel : BindableBase
    {
        private ModifyBossView view;
        private Boss boss;
        private string error;
        private BossDAO bossDAO = new BossDAO();

        private List<Worker> workers = new List<Worker>();
        private WorkerDAO workerDAO = new WorkerDAO();
        private List<Worker> selectedWorkers = new List<Worker>();

        public ICommand ModifyComm { get; set; }
        public Boss Boss { get => boss; set { boss = value; OnPropertyChanged("Boss"); } }
        public string Error { get => error; set { error = value; OnPropertyChanged("Error"); } }

        public List<Worker> Workers { get => workers; set { workers = value; OnPropertyChanged("Workers"); } }

        public List<Worker> SelectedWorkers { get => selectedWorkers; set { selectedWorkers = value; OnPropertyChanged("SelectedWorkers"); } }

        public ModifyBossViewModel(ModifyBossView view, Boss boss)
        {
            this.view = view;

            Boss = boss;

            ModifyComm = new Command(this.Modify);

            Workers = workerDAO.GetList();
        }

        public void Modify()
        {
            Error = "";

            if (boss.BossName == null || boss.BossName == "")
            {
                Error += "Name can not be empty!\n";
            }

            if (boss.BossSurname == null || boss.BossSurname == "")
            {
                Error += "Surname can not be empty!\n";
            }

            if (SelectedWorkers.Count == 0)
            {
                Error += "Must select at least 1 worker!\n";
            }

            if (Error == "")
            {
                boss.Workers = selectedWorkers;

                foreach (var worker in boss.Workers)
                {
                    worker.BossBossId = boss.BossId;
                    workerDAO.Update(worker);
                }

                bossDAO.Update(boss);
                view.Close();
            }            
        }
    }
}
