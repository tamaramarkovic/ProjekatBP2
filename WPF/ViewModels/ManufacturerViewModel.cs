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
    class ManufacturerViewModel : BindableBase
    {
        private ObservableCollection<Manufacturer> manufacturers;
        private Manufacturer selectedManufacturer;
        private ManufacturerView view;
        private ManufacturerDAO manufacturerDAO = new ManufacturerDAO();

        public ICommand AddComm { get; set; }
        public ICommand ModifyComm { get; set; }
        public ICommand RemoveComm { get; set; }

        public ObservableCollection<Manufacturer> Manufacturers { get => manufacturers; set { manufacturers = value; OnPropertyChanged("Manufacturers"); } }

        public Manufacturer SelectedManufacturer { get => selectedManufacturer; set { selectedManufacturer = value; OnPropertyChanged("SelectedManufacturer"); } }

        public ManufacturerViewModel(ManufacturerView view)
        {
            this.view = view;

            AddComm = new Command(this.Add);
            ModifyComm = new Command(this.Modify);
            RemoveComm = new Command(this.Remove);

            SelectedManufacturer = new Manufacturer();
            Manufacturers = new ObservableCollection<Manufacturer>();

            Load();
        }

        public void Add()
        {
            AddManufacturerView newWindow = new AddManufacturerView();
            newWindow.DataContext = new AddManufacturerViewModel(newWindow);
            newWindow.ShowDialog();
            Load();
        }

        public void Modify()
        {
            ModifyManufacturerView newWindow = new ModifyManufacturerView();
            newWindow.DataContext = new ModifyManufacturerViewModel(newWindow, SelectedManufacturer);
            newWindow.ShowDialog();
            Load();
            SelectedManufacturer = new Manufacturer();
        }

        public void Remove()
        {
            manufacturerDAO.Delete(SelectedManufacturer.ManufacturerId);
            Load();
            SelectedManufacturer = new Manufacturer();
        }

        public void Load()
        {
            Manufacturers = new ObservableCollection<Manufacturer>();

            foreach (Manufacturer item in manufacturerDAO.GetList())
            {
                Manufacturers.Add(item);
            }
        }
    }
}
