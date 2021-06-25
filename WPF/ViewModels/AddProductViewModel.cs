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
    class AddProductViewModel : BindableBase
    {
        private Product product;
        private AddProductView view;
        private string error;
        private ProductDAO productDAO = new ProductDAO();

        public ICommand AddComm { get; set; }

        public Product Product { get => product; set { product = value; OnPropertyChanged("Product"); } }

        public string Error { get => error; set { error = value; OnPropertyChanged("Error"); } }

        public AddProductViewModel(AddProductView view)
        {
            this.view = view;

            Product = new Product();
            AddComm = new Command(this.AddProduct);
        }

        public void AddProduct()
        {
            Error = "";

            if (product.ProductName == null || product.ProductName == "")
            {
                Error += "Name can not be empty!\n";
            }

            if (Error == "")
            {
                productDAO.Insert(Product);

                view.Close();
            }
        }
    }
}
