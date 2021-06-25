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
    class AddOwnerViewModel : BindableBase
    {
        private Owner owner;
        private AddOwnerView view;
        private string error;
        private OwnerDAO ownerDAO = new OwnerDAO();

        public ICommand AddComm { get; set; }

        public Owner Owner { get => owner; set { owner = value; OnPropertyChanged("Owner"); } }

        public string Error { get => error; set { error = value; OnPropertyChanged("Error"); } }

        public AddOwnerViewModel(AddOwnerView view)
        {
            this.view = view;

            Owner = new Owner();
            AddComm = new Command(this.AddOwner);
        }

        public void AddOwner()
        {
            Error = "";

            if (owner.OwnerName == null || owner.OwnerName == "")
            {
                Error += "Name can not be empty!\n";
            }

            if (owner.OwnerSurname == null || owner.OwnerSurname == "")
            {
                Error += "Surname can not be empty!\n";
            }

            if (Error == "")
            {
                ownerDAO.Insert(Owner);

                view.Close();
            }
        }
    }
}
