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
    class AddApoitmentViewModel : BindableBase
    {
        private Appoitment appoitment;
        private AddApoitmentView view;
        private string error;
        private AppoitmentDAO appDAO = new AppoitmentDAO();

        public ICommand AddComm { get; set; }

        public Appoitment Appoitment { get => appoitment; set { appoitment = value; OnPropertyChanged("Appoitment"); } }

        public string Error { get => error; set { error = value; OnPropertyChanged("Error"); } }

        public AddApoitmentViewModel(AddApoitmentView view)
        {
            this.view = view;

            Appoitment = new Appoitment();
            AddComm = new Command(this.AddApoitment);
        }

        public void AddApoitment()
        {
            Error = "";

            if (appoitment.NameOfClient == null || appoitment.NameOfClient == "")
            {
                Error += "Name of client can not be empty!\n";
            }

            if (appoitment.SurnameOfClient == null || appoitment.SurnameOfClient == "")
            {
                Error += "Surname of client can not be empty!\n";
            }

            if(Error == "")
            {
                appDAO.Insert(Appoitment);

                view.Close();
            }
        }
    }
}
