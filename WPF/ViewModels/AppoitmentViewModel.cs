using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.View;
using ProjekatBP2;
using System.Windows.Input;
using ProjekatBP2.DAO;

namespace WPF.ViewModels
{
    class AppoitmentViewModel : BindableBase
    {
        private ObservableCollection<Appoitment> appoitments;
        private Appoitment selectedAppoitment;
        private AppoitmentView view;
        private AppoitmentDAO appDAO = new AppoitmentDAO();

        public ICommand AddComm { get; set; }
        public ICommand ModifyComm { get; set; }
        public ICommand RemoveComm { get; set; }

        public ObservableCollection<Appoitment> Appoitments { get => appoitments; set { appoitments = value; OnPropertyChanged("Appoitments"); } }

        public Appoitment SelectedAppoitment { get => selectedAppoitment; set { selectedAppoitment = value; OnPropertyChanged("SelectedAppoitment"); } }

        public AppoitmentViewModel(AppoitmentView view)
        {
            this.view = view;

            AddComm = new Command(this.Add);
            ModifyComm = new Command(this.Modify);
            RemoveComm = new Command(this.Remove);

            SelectedAppoitment = new Appoitment();
            Appoitments = new ObservableCollection<Appoitment>();

            Load();
        }

        public void Add()
        {
            AddApoitmentView newWindow = new AddApoitmentView();
            newWindow.DataContext = new AddApoitmentViewModel(newWindow);
            newWindow.ShowDialog();
            Load();
        }

        public void Modify()
        {
            ModifyAppoitmentView newWindow = new ModifyAppoitmentView();
            newWindow.DataContext = new ModifyAppoitmentViewModel(newWindow, SelectedAppoitment);
            newWindow.ShowDialog();
            Load();
            SelectedAppoitment = new Appoitment();
        }

        public void Remove()
        {
            appDAO.Delete(selectedAppoitment.AppoitmentId);
            Load();
            selectedAppoitment = new Appoitment();
        }

        public void Load()
        {
            Appoitments = new ObservableCollection<Appoitment>();

            foreach (Appoitment item in appDAO.GetList())
            {
                Appoitments.Add(item);
            }
        }
    }
}
