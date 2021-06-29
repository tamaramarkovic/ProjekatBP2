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
    class ModifyManufacturerViewModel : BindableBase
    {
        private ModifyManufacturerView view;
        private Manufacturer manufacturer;
        private string error;
        private ManufacturerDAO manufacturerDAO = new ManufacturerDAO();

        private CollaborateDAO collaborateDAO = new CollaborateDAO();
        private List<Collaborate> collaborations = new List<Collaborate>();
        private List<Collaborate> selectedCollaborations = new List<Collaborate>();

        public ICommand ModifyComm { get; set; }
        public Manufacturer Manufacturer { get => manufacturer; set { manufacturer = value; OnPropertyChanged("Manufacturer"); } }
        public string Error { get => error; set { error = value; OnPropertyChanged("Error"); } }

        public List<Collaborate> Collaborations { get => collaborations; set { collaborations = value; OnPropertyChanged("Collaborations"); } }
        public List<Collaborate> SelectedCollaborations { get => selectedCollaborations; set { selectedCollaborations = value; OnPropertyChanged("SelectedCollaborations"); } }

        public ModifyManufacturerViewModel(ModifyManufacturerView view, Manufacturer manufacturer)
        {
            this.view = view;

            Manufacturer = manufacturer;

            ModifyComm = new Command(this.Modify);

            Collaborations = collaborateDAO.GetList();
        }

        public void Modify()
        {
            Error = "";

            if (manufacturer.ManufacturerName == "")
            {
                Error += "Name can not be empty!\n";
            }

            if (Error == "")
            {
                manufacturerDAO.Update(Manufacturer);

                view.Close();
            }
        }
    }
}
