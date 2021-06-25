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
    class AddManufacturerViewModel : BindableBase
    {
        private Manufacturer manufacturer;
        private AddManufacturerView view;
        private string error;
        private ManufacturerDAO manufacturerDAO = new ManufacturerDAO();

        public ICommand AddComm { get; set; }

        public Manufacturer Manufacturer { get => manufacturer; set { manufacturer = value; OnPropertyChanged("Manufacturer"); } }

        public string Error { get => error; set { error = value; OnPropertyChanged("Error"); } }

        public AddManufacturerViewModel(AddManufacturerView view)
        {
            this.view = view;

            Manufacturer = new Manufacturer();
            AddComm = new Command(this.AddManufacturer);
        }

        public void AddManufacturer()
        {
            Error = "";

            if (manufacturer.ManufacturerName == null || manufacturer.ManufacturerName == "")
            {
                Error += "Name can not be empty!\n";
            }

            if (Error == "")
            {
                manufacturerDAO.Insert(Manufacturer);

                view.Close();
            }
        }
    }
}
