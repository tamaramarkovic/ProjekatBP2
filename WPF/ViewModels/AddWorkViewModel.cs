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
    class AddWorkViewModel : BindableBase
    {
        private Work work;
        private AddWorkView view;
        private string error;
        private WorkDAO workDAO = new WorkDAO();

        public ICommand AddComm { get; set; }

        public Work Work { get => work; set { work = value; OnPropertyChanged("Work"); } }

        public string Error { get => error; set { error = value; OnPropertyChanged("Error"); } }

        public AddWorkViewModel(AddWorkView view)
        {
            this.view = view;

            Work = new Work();
            AddComm = new Command(this.AddWork);
        }

        public void AddWork()
        {
            Error = "";

            if (work.WorkName == null || work.WorkName == "")
            {
                Error += "Name can not be empty!\n";
            }

            if (Error == "")
            {
                workDAO.Insert(Work);

                view.Close();
            }
        }
    }
}
