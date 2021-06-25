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
    class SectorViewModel : BindableBase
    {
        private ObservableCollection<Sector> sectors;
        private Sector selectedSector;
        private SectorView view;
        private SectorDAO sectorDAO = new SectorDAO();

        public ICommand AddComm { get; set; }
        public ICommand ModifyComm { get; set; }
        public ICommand RemoveComm { get; set; }

        public ObservableCollection<Sector> Sectors { get => sectors; set { sectors = value; OnPropertyChanged("Sectors"); } }

        public Sector SelectedSector { get => selectedSector; set { selectedSector = value; OnPropertyChanged("SelectedSector"); } }

        public SectorViewModel(SectorView view)
        {
            this.view = view;

            AddComm = new Command(this.Add);
            ModifyComm = new Command(this.Modify);
            RemoveComm = new Command(this.Remove);

            SelectedSector = new Sector();
            Sectors = new ObservableCollection<Sector>();

            Load();
        }

        public void Add()
        {
            AddSectorView newWindow = new AddSectorView();
            newWindow.DataContext = new AddSectorViewModel(newWindow);
            newWindow.ShowDialog();
            Load();
        }

        public void Modify()
        {
            ModifySectorView newWindow = new ModifySectorView();
            newWindow.DataContext = new ModifySectorViewModel(newWindow, SelectedSector);
            newWindow.ShowDialog();
            Load();
            SelectedSector = new Sector();
        }

        public void Remove()
        {
            sectorDAO.Delete(SelectedSector.SectorId);
            Load();
            SelectedSector = new Sector();
        }

        public void Load()
        {
            Sectors = new ObservableCollection<Sector>();

            foreach (Sector item in sectorDAO.GetList())
            {
                Sectors.Add(item);
            }
        }
    }
}
