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
    class BossViewModel : BindableBase
    {
        private ObservableCollection<Boss> bosses;
        private Boss selectedBoss;
        private BossView view;
        private BossDAO bossDAO = new BossDAO();

        public ICommand AddComm { get; set; }
        public ICommand ModifyComm { get; set; }
        public ICommand RemoveComm { get; set; }

        public ObservableCollection<Boss> Bosses { get => bosses; set { bosses = value; OnPropertyChanged("Bosses"); } }

        public Boss SelectedBoss { get => selectedBoss; set { selectedBoss = value; OnPropertyChanged("SelectedBoss"); } }

        public BossViewModel(BossView view)
        {
            this.view = view;

            AddComm = new Command(this.Add);
            ModifyComm = new Command(this.Modify);
            RemoveComm = new Command(this.Remove);

            SelectedBoss = new Boss();
            Bosses = new ObservableCollection<Boss>();

            Load();
        }

        public void Add()
        {
            AddBossView newWindow = new AddBossView();
            newWindow.DataContext = new AddBossViewModel(newWindow);
            newWindow.ShowDialog();
            Load();
        }

        public void Modify()
        {
            ModifyBossView newWindow = new ModifyBossView();
            newWindow.DataContext = new ModifyBossViewModel(newWindow, SelectedBoss);
            newWindow.ShowDialog();
            Load();
            SelectedBoss = new Boss();
        }

        public void Remove()
        {
            bossDAO.Delete(selectedBoss.BossId);
            Load();
            selectedBoss = new Boss();
        }

        public void Load()
        {
            Bosses = new ObservableCollection<Boss>();

            foreach (Boss item in bossDAO.GetList())
            {
                Bosses.Add(item);
            }
        }
    }
}
