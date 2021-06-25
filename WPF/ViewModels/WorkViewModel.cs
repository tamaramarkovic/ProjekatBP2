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
    class WorkViewModel : BindableBase
    {
        private ObservableCollection<Work> works;
        private Work selectedWork;
        private WorkView view;
        private WorkDAO workDAO = new WorkDAO();

        public ICommand AddComm { get; set; }
        public ICommand ModifyComm { get; set; }
        public ICommand RemoveComm { get; set; }

        public ObservableCollection<Work> Works { get => works; set { works = value; OnPropertyChanged("Works"); } }

        public Work SelectedWork { get => selectedWork; set { selectedWork = value; OnPropertyChanged("SelectedWork"); } }

        public WorkViewModel(WorkView view)
        {
            this.view = view;

            AddComm = new Command(this.Add);
            ModifyComm = new Command(this.Modify);
            RemoveComm = new Command(this.Remove);

            SelectedWork = new Work();
            Works = new ObservableCollection<Work>();

            Load();
        }

        public void Add()
        {
            AddWorkView newWindow = new AddWorkView();
            newWindow.DataContext = new AddWorkViewModel(newWindow);
            newWindow.ShowDialog();
            Load();
        }

        public void Modify()
        {
            ModifyWorkView newWindow = new ModifyWorkView();
            newWindow.DataContext = new ModifyWorkViewModel(newWindow, SelectedWork);
            newWindow.ShowDialog();
            Load();
            SelectedWork = new Work();
        }

        public void Remove()
        {
            workDAO.Delete(SelectedWork.WorkId);
            Load();
            SelectedWork = new Work();
        }

        public void Load()
        {
            Works = new ObservableCollection<Work>();

            foreach (Work item in workDAO.GetList())
            {
                Works.Add(item);
            }
        }
    }
}
