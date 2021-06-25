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

        public ICommand ModifyComm { get; set; }
        public Manufacturer Manufacturer { get => manufacturer; set { manufacturer = value; OnPropertyChanged("Manufacturer"); } }
        public string Error { get => error; set { error = value; OnPropertyChanged("Error"); } }

        public ModifyManufacturerViewModel(ModifyManufacturerView view, Manufacturer manufacturer)
        {
            this.view = view;

            Manufacturer = manufacturer;

            ModifyComm = new Command(this.Modify);
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
