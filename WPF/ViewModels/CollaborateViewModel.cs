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
    class CollaborateViewModel : BindableBase
    {
        private ObservableCollection<Collaborate> collaborations;
        private Collaborate selectedCollaborate;
        private CollaborateView view;
        private CollaborateDAO collaborateDAO = new CollaborateDAO();

        public ICommand AddComm { get; set; }
        public ICommand ModifyComm { get; set; }
        public ICommand RemoveComm { get; set; }

        public ObservableCollection<Collaborate> Collaborations { get => collaborations; set { collaborations = value; OnPropertyChanged("Collaborations"); } }

        public Collaborate SelectedCollaborate { get => selectedCollaborate; set { selectedCollaborate = value; OnPropertyChanged("SelectedCollaborate"); } }

        public CollaborateViewModel(CollaborateView view)
        {
            this.view = view;

            AddComm = new Command(this.Add);
            ModifyComm = new Command(this.Modify);
            RemoveComm = new Command(this.Remove);

            SelectedCollaborate = new Collaborate();
            Collaborations = new ObservableCollection<Collaborate>();

            Load();
        }

        public void Add()
        {
            AddCollaborateView newWindow = new AddCollaborateView();
            newWindow.DataContext = new AddCollaborateViewModel(newWindow);
            newWindow.ShowDialog();
            Load();
        }

        public void Modify()
        {
            ModifyCollaborateView newWindow = new ModifyCollaborateView();
            newWindow.DataContext = new ModifyCollaborateViewModel(newWindow, SelectedCollaborate);
            newWindow.ShowDialog();
            Load();
            SelectedCollaborate = new Collaborate();
        }

        public void Remove()
        {
            collaborateDAO.Delete(SelectedCollaborate.CollaborateId);
            Load();
            SelectedCollaborate = new Collaborate();
        }

        public void Load()
        {
            Collaborations = new ObservableCollection<Collaborate>();

            foreach (Collaborate item in collaborateDAO.GetList())
            {
                collaborations.Add(item);
            }
        }
    }
}
