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
    class BillViewModel : BindableBase
    {
        private ObservableCollection<Bill> bills;
        private Bill selectedBill;
        private BillView view;
        private BillDAO billDAO = new BillDAO();

        public ICommand AddComm { get; set; }
        public ICommand ModifyComm { get; set; }
        public ICommand RemoveComm { get; set; }

        public ObservableCollection<Bill> Bills { get => bills; set { bills = value; OnPropertyChanged("Bills"); } }

        public Bill SelectedBill { get => selectedBill; set { selectedBill = value; OnPropertyChanged("SelectedBill"); } }

        public BillViewModel(BillView view)
        {
            this.view = view;

            AddComm = new Command(this.Add);
            ModifyComm = new Command(this.Modify);
            RemoveComm = new Command(this.Remove);

            SelectedBill = new Bill();
            Bills = new ObservableCollection<Bill>();

            Load();
        }

        public void Add()
        {
            AddBillView newWindow = new AddBillView();
            newWindow.DataContext = new AddBillViewModel(newWindow);
            newWindow.ShowDialog();
            Load();
        }

        public void Modify()
        {
            ModifyBillView newWindow = new ModifyBillView();
            newWindow.DataContext = new ModifyBillViewModel(newWindow, SelectedBill);
            newWindow.ShowDialog();
            Load();
            SelectedBill = new Bill();
        }

        public void Remove()
        {
            billDAO.Delete(SelectedBill.BillId);
            Load();
            SelectedBill = new Bill();
        }

        public void Load()
        {
            Bills = new ObservableCollection<Bill>();

            foreach (Bill item in billDAO.GetList())
            {
                Bills.Add(item);
            }
        }
    }
}
