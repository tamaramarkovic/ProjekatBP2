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
    class AddBossViewModel : BindableBase
    {
        private Boss boss;
        private AddBossView view;
        private string error;
        private BossDAO bossDAO = new BossDAO();

        public ICommand AddComm { get; set; }

        public Boss Boss { get => boss; set { boss = value; OnPropertyChanged("Boss"); } }

        public string Error { get => error; set { error = value; OnPropertyChanged("Error"); } }

        public AddBossViewModel(AddBossView view)
        {
            this.view = view;

            Boss = new Boss();
            AddComm = new Command(this.AddBoss);
        }

        public void AddBoss()
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

            if (Error == "")
            {
                bossDAO.Insert(Boss);

                view.Close();
            }
        }
    }
}
