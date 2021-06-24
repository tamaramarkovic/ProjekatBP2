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
    class ModifyAppoitmentViewModel : BindableBase
    {
        private ModifyAppoitmentView view;
        private Appoitment appoitment;
        private string error;
        private AppoitmentDAO appDAO = new AppoitmentDAO();
        
        public ICommand ModifyComm { get; set; }
        public Appoitment Appoitment { get => appoitment; set { appoitment = value; OnPropertyChanged("Appoitment"); } }
        public string Error { get => error; set { error = value; OnPropertyChanged("Error"); } }

        public ModifyAppoitmentViewModel(ModifyAppoitmentView view, Appoitment app)
        {
            this.view = view;

            Appoitment = app;

            ModifyComm = new Command(this.Modify);
        }

        public void Modify()
        {
            Error = "";

            if (Appoitment.NameOfClient == null || Appoitment.NameOfClient == "")
            {
                Error += "Name of client can not be empty!\n";
            }

            if (Appoitment.SurnameOfClient == null || Appoitment.SurnameOfClient == "")
            {
                Error += "Surname of client can not be empty!\n";
            }

            if (Error == "")
            {
                appDAO.Update(Appoitment);
                view.Close();
            }
        }
    }
}
