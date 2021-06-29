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
    class BeauticanViewModel : BindableBase
    {
        private ObservableCollection<Beautican> beauticans;
        private Beautican selectedBeautican;
        private BeauticanView view;
        private JobDAO jobDAO = new JobDAO();

        public ICommand AddComm { get; set; }
        public ICommand ModifyComm { get; set; }
        public ICommand RemoveComm { get; set; }

        public ObservableCollection<Beautican> Beauticans { get => beauticans; set { beauticans = value; OnPropertyChanged("Beauticans"); } }

        public Beautican SelectedBeautican { get => selectedBeautican; set { selectedBeautican = value; OnPropertyChanged("SelectedBeautican"); } }

        public BeauticanViewModel(BeauticanView view)
        {
            this.view = view;

            AddComm = new Command(this.Add);
            ModifyComm = new Command(this.Modify);
            RemoveComm = new Command(this.Remove);

            SelectedBeautican = new Beautican();
            Beauticans = new ObservableCollection<Beautican>();

            Load();
        }

        public void Add()
        {
            AddBeauticanView newWindow = new AddBeauticanView();
            newWindow.DataContext = new AddBeauticanViewModel(newWindow);
            newWindow.ShowDialog();
            Load();
        }

        public void Modify()
        {
            ModifyBeauticanView newWindow = new ModifyBeauticanView();
            newWindow.DataContext = new ModifyBeauticanViewModel(newWindow, SelectedBeautican);
            newWindow.ShowDialog();
            Load();
            SelectedBeautican = new Beautican();
        }

        public void Remove()
        {
            jobDAO.Delete(SelectedBeautican.JobId);
            Load();
            SelectedBeautican = new Beautican();
        }

        public void Load()
        {
            Beauticans = new ObservableCollection<Beautican>();

            foreach (Beautican item in jobDAO.GetBeauticans())
            {
                Beauticans.Add(item);
            }
        }
    }
}
