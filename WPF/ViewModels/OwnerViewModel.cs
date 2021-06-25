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
    class OwnerViewModel : BindableBase
    {
        private ObservableCollection<Owner> owners;
        private Owner selectedOwner;
        private OwnerView view;
        private OwnerDAO ownerDAO = new OwnerDAO();

        public ICommand AddComm { get; set; }
        public ICommand ModifyComm { get; set; }
        public ICommand RemoveComm { get; set; }

        public ObservableCollection<Owner> Owners { get => owners; set { owners = value; OnPropertyChanged("Owners"); } }

        public Owner SelectedOwner { get => selectedOwner; set { selectedOwner = value; OnPropertyChanged("SelectedOwner"); } }

        public OwnerViewModel(OwnerView view)
        {
            this.view = view;

            AddComm = new Command(this.Add);
            ModifyComm = new Command(this.Modify);
            RemoveComm = new Command(this.Remove);

            SelectedOwner = new Owner();
            Owners = new ObservableCollection<Owner>();

            Load();
        }

        public void Add()
        {
            AddOwnerView newWindow = new AddOwnerView();
            newWindow.DataContext = new AddOwnerViewModel(newWindow);
            newWindow.ShowDialog();
            Load();
        }

        public void Modify()
        {
            ModifyOwnerView newWindow = new ModifyOwnerView();
            newWindow.DataContext = new ModifyOwnerViewModel(newWindow, SelectedOwner);
            newWindow.ShowDialog();
            Load();
            SelectedOwner = new Owner();
        }

        public void Remove()
        {
            ownerDAO.Delete(SelectedOwner.OwnerId);
            Load();
            SelectedOwner = new Owner();
        }

        public void Load()
        {
            Owners = new ObservableCollection<Owner>();

            foreach (Owner item in ownerDAO.GetList())
            {
                Owners.Add(item);
            }
        }
    }
}
