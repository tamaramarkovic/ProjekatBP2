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
    class AddCollaborateViewModel : BindableBase
    {
        private Collaborate collaborate;
        private AddCollaborateView view;
        private string error;
        private CollaborateDAO collaborateDAO = new CollaborateDAO();
        private ManufacturerDAO manufacturerDAO = new ManufacturerDAO();
        private OwnerDAO ownerDAO = new OwnerDAO();

        public ICommand AddComm { get; set; }

        public Collaborate Collaborate { get => collaborate; set { collaborate = value; OnPropertyChanged("Collaborate"); } }

        public string Error { get => error; set { error = value; OnPropertyChanged("Error"); } }

        public AddCollaborateViewModel(AddCollaborateView view)
        {
            this.view = view;

            Collaborate = new Collaborate();
            AddComm = new Command(this.AddCollaborate);
        }

        public void AddCollaborate()
        {
            Error = "";

            if (collaborate.ManufacturerManufacturerId1 == 0)
            {
                Error += "Manufacturer ID can not be empty or 0!\n";
            }

            if (collaborate.OwnerOwnerId == 0)
            {
                Error += "Owner ID can not be empty or 0!\n";
            }

            if (manufacturerDAO.FindById(collaborate.ManufacturerManufacturerId1) == null)
            {
                Error += "Manufacturer does not exsist!\n";
            }

            if (ownerDAO.FindById(collaborate.OwnerOwnerId) == null)
            {
                Error += "Owner does not exsist!\n";
            }

            if (Error == "")
            {
                collaborateDAO.Insert(Collaborate);

                view.Close();
            }
        }
    }
}
