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

        private CollaborateDAO collaborateDAO = new CollaborateDAO();
        private List<Collaborate> collaborations = new List<Collaborate>();
        private List<Collaborate> selectedCollaborations = new List<Collaborate>();

        public ICommand ModifyComm { get; set; }
        public Owner Owner { get => owner; set { owner = value; OnPropertyChanged("Owner"); } }
        public string Error { get => error; set { error = value; OnPropertyChanged("Error"); } }

        public List<Collaborate> Collaborations { get => collaborations; set { collaborations = value; OnPropertyChanged("Collaborations"); } }
        public List<Collaborate> SelectedCollaborations { get => selectedCollaborations; set { selectedCollaborations = value; OnPropertyChanged("SelectedCollaborations"); } }

        public ModifyOwnerViewModel(ModifyOwnerView view, Owner owner)
        {
            this.view = view;

            Owner = owner;

            ModifyComm = new Command(this.Modify);

            Collaborations = collaborateDAO.GetList();
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
