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
    class AddSectorViewModel : BindableBase
    {
        private Sector sector;
        private AddSectorView view;
        private string error;
        private SectorDAO sectorDAO = new SectorDAO();

        public ICommand AddComm { get; set; }

        public Sector Sector { get => sector; set { sector = value; OnPropertyChanged("Sector"); } }

        public string Error { get => error; set { error = value; OnPropertyChanged("Error"); } }

        public AddSectorViewModel(AddSectorView view)
        {
            this.view = view;

            Sector = new Sector();
            AddComm = new Command(this.AddSector);
        }

        public void AddSector()
        {
            Error = "";

            if (sector.SectorName == null || Sector.SectorName == "")
            {
                Error += "Name can not be empty!\n";
            }

            if (Error == "")
            {
                sectorDAO.Insert(Sector);

                view.Close();
            }
        }
    }
}
