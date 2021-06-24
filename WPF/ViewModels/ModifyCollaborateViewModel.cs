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
    class ModifyCollaborateViewModel : BindableBase
    {
        private ModifyCollaborateView view;
        private Collaborate collaborate;
        private string error;
        private CollaborateDAO collaborateDAO = new CollaborateDAO();
        private ManufacturerDAO manufacturerDAO = new ManufacturerDAO();
        private OwnerDAO ownerDAO = new OwnerDAO();

        public ICommand ModifyComm { get; set; }
        public Collaborate Collaborate { get => collaborate; set { collaborate = value; OnPropertyChanged("Collaborate"); } }
        public string Error { get => error; set { error = value; OnPropertyChanged("Error"); } }

        public ModifyCollaborateViewModel(ModifyCollaborateView view, Collaborate collaborate)
        {
            this.view = view;

            Collaborate = collaborate;

            ModifyComm = new Command(this.Modify);
        }

        public void Modify()
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
                collaborateDAO.Update(Collaborate);
            }

            view.Close();
        }
    }
}
