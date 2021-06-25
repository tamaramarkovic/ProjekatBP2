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
    class ModifyWorkViewModel : BindableBase
    {
        private ModifyWorkView view;
        private Work work;
        private string error;
        private WorkDAO workDAO = new WorkDAO();

        public ICommand ModifyComm { get; set; }
        public Work Work { get => work; set { work = value; OnPropertyChanged("Work"); } }
        public string Error { get => error; set { error = value; OnPropertyChanged("Error"); } }

        public ModifyWorkViewModel(ModifyWorkView view, Work work)
        {
            this.view = view;

            Work = work;

            ModifyComm = new Command(this.Modify);
        }

        public void Modify()
        {
            Error = "";

            if (work.WorkName == null || work.WorkName == "")
            {
                Error += "Name can not be empty!\n";
            }

            if (Error == "")
            {
                workDAO.Update(Work);
                view.Close();
            }
        }
    }
}
