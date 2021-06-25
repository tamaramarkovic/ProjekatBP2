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
    class ModifyOwnerViewModel : BindableBase
    {
        private ModifyOwnerView view;
        private Owner owner;
        private string error;
        private OwnerDAO ownerDAO = new OwnerDAO();

        public ICommand ModifyComm { get; set; }
        public Owner Owner { get => owner; set { owner = value; OnPropertyChanged("Owner"); } }
        public string Error { get => error; set { error = value; OnPropertyChanged("Error"); } }

        public ModifyOwnerViewModel(ModifyOwnerView view, Owner owner)
        {
            this.view = view;

            Owner = owner;

            ModifyComm = new Command(this.Modify);
        }

        public void Modify()
        {
            Error = "";

            if (owner.OwnerName == "")
            {
                Error += "Name can not be empty!\n";
            }

            if (owner.OwnerSurname == "")
            {
                Error += "Surname can not be empty!\n";
            }

            if (Error == "")
            {
                ownerDAO.Update(Owner);

                view.Close();
            }
        }
    }
}
