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

        public ICommand ModifyComm { get; set; }
        public Boss Boss { get => boss; set { boss = value; OnPropertyChanged("Boss"); } }
        public string Error { get => error; set { error = value; OnPropertyChanged("Error"); } }

        public ModifyBossViewModel(ModifyBossView view, Boss boss)
        {
            this.view = view;

            Boss = boss;

            ModifyComm = new Command(this.Modify);
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

            if (Error == "")
            {
                bossDAO.Update(boss);
                view.Close();
            }            
        }
    }
}
