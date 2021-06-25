using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF.View;

namespace WPF.ViewModels
{
    class MainWindowViewModel
    {
        public ICommand Appoitment { get; set; }
        public ICommand Bill { get; set; }
        public ICommand Boss { get; set; }
        public ICommand Collaborate { get; set; }
        public ICommand Job { get; set; }
        public ICommand Manufacturer { get; set; }
        public ICommand Owner { get; set; }
        public ICommand Product { get; set; }
        public ICommand Sector { get; set; }
        public ICommand ServiceCompany { get; set; }
        public ICommand Service { get; set; }
        public ICommand Shift { get; set; }
        public ICommand Work { get; set; }
        public ICommand Worker { get; set; }

        public MainWindowViewModel()
        {
            Appoitment = new Command(AllApoitments);
            Bill = new Command(AllBills);
            Boss = new Command(AllBosses);
            Collaborate = new Command(AllCollaborations);
            Manufacturer = new Command(AllManufacturers);
            Owner = new Command(AllOwners);
            Product = new Command(AllProducts);
            Sector = new Command(AllSectors);
            ServiceCompany = new Command(AllServiceCompanies);
            Service = new Command(AllServices);
            Shift = new Command(AllShifts);
            Work = new Command(AllWorks);
        }

        public void AllApoitments()
        {
            AppoitmentView appView = new AppoitmentView();
            appView.DataContext = new AppoitmentViewModel(appView);
            appView.ShowDialog();
        }

        public void AllBills()
        {
            BillView billView = new BillView();
            billView.DataContext = new BillViewModel(billView);
            billView.ShowDialog();
        }

        public void AllBosses()
        {
            BossView bossView = new BossView();
            bossView.DataContext = new BossViewModel(bossView);
            bossView.ShowDialog();
        }

        public void AllCollaborations()
        {
            CollaborateView collaborateView = new CollaborateView();
            collaborateView.DataContext = new CollaborateViewModel(collaborateView);
            collaborateView.ShowDialog();
        }

        public void AllManufacturers()
        {
            ManufacturerView manufacturerView = new ManufacturerView();
            manufacturerView.DataContext = new ManufacturerViewModel(manufacturerView);
            manufacturerView.ShowDialog();
        }

        public void AllOwners()
        {
            OwnerView ownerView = new OwnerView();
            ownerView.DataContext = new OwnerViewModel(ownerView);
            ownerView.ShowDialog();
        }

        public void AllProducts()
        {
            ProductView productView = new ProductView();
            productView.DataContext = new ProductViewModel(productView);
            productView.ShowDialog();
        }

        public void AllSectors()
        {
            SectorView sectorView = new SectorView();
            sectorView.DataContext = new SectorViewModel(sectorView);
            sectorView.ShowDialog();
        }

        public void AllServiceCompanies()
        {
            ServiceCompanyView serviceCompanyView = new ServiceCompanyView();
            serviceCompanyView.DataContext = new ServiceCompanyViewModel(serviceCompanyView);
            serviceCompanyView.ShowDialog();
        }

        public void AllServices()
        {
            ServiceView serviceView = new ServiceView();
            serviceView.DataContext = new ServiceViewModel(serviceView);
            serviceView.ShowDialog();
        }

        public void AllShifts()
        {
            ShiftView shiftView = new ShiftView();
            shiftView.DataContext = new ShiftViewModel(shiftView);
            shiftView.ShowDialog();
        }

        public void AllWorks()
        {
            WorkView workView = new WorkView();
            workView.DataContext = new WorkViewModel(workView);
            workView.ShowDialog();
        }
    }
}
