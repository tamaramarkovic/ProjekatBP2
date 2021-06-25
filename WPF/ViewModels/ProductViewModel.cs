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
    class ProductViewModel : BindableBase
    {
        private ObservableCollection<Product> products;
        private Product selectedProduct;
        private ProductView view;
        private ProductDAO productDAO = new ProductDAO();

        public ICommand AddComm { get; set; }
        public ICommand ModifyComm { get; set; }
        public ICommand RemoveComm { get; set; }

        public ObservableCollection<Product> Products { get => products; set { products = value; OnPropertyChanged("Products"); } }

        public Product SelectedProduct { get => selectedProduct; set { selectedProduct = value; OnPropertyChanged("SelectedProduct"); } }

        public ProductViewModel(ProductView view)
        {
            this.view = view;

            AddComm = new Command(this.Add);
            ModifyComm = new Command(this.Modify);
            RemoveComm = new Command(this.Remove);

            SelectedProduct = new Product();
            Products = new ObservableCollection<Product>();

            Load();
        }

        public void Add()
        {
            AddProductView newWindow = new AddProductView();
            newWindow.DataContext = new AddProductViewModel(newWindow);
            newWindow.ShowDialog();
            Load();
        }

        public void Modify()
        {
            ModifyProductView newWindow = new ModifyProductView();
            newWindow.DataContext = new ModifyProductViewModel(newWindow, SelectedProduct);
            newWindow.ShowDialog();
            Load();
            SelectedProduct = new Product();
        }

        public void Remove()
        {
            productDAO.Delete(SelectedProduct.ProductId);
            Load();
            SelectedProduct = new Product();
        }

        public void Load()
        {
            Products = new ObservableCollection<Product>();

            foreach (Product item in productDAO.GetList())
            {
                Products.Add(item);
            }
        }
    }
}
