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
    class ModifySectorViewModel : BindableBase
    {
        private ModifySectorView view;
        private Sector sector;
        private string error;
        private SectorDAO sectorDAO = new SectorDAO();

        public ICommand ModifyComm { get; set; }
        public Sector Sector { get => sector; set { sector = value; OnPropertyChanged("Sector"); } }
        public string Error { get => error; set { error = value; OnPropertyChanged("Error"); } }

        public ModifySectorViewModel(ModifySectorView view, Sector sector)
        {
            this.view = view;

            Sector = sector;

            ModifyComm = new Command(this.Modify);
        }

        public void Modify()
        {
            Error = "";

            if (sector.SectorName == "")
            {
                Error += "Name can not be empty!\n";
            }

            if (Error == "")
            {
                sectorDAO.Update(Sector);
            }

            view.Close();
        }
    }
}
