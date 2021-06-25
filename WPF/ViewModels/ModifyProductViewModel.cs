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
    class ModifyProductViewModel : BindableBase
    {
        private ModifyProductView view;
        private Product product;
        private string error;
        private ProductDAO productDAO = new ProductDAO();

        public ICommand ModifyComm { get; set; }
        public Product Product { get => product; set { product = value; OnPropertyChanged("Product"); } }
        public string Error { get => error; set { error = value; OnPropertyChanged("Error"); } }

        public ModifyProductViewModel(ModifyProductView view, Product product)
        {
            this.view = view;

            Product = product;

            ModifyComm = new Command(this.Modify);
        }

        public void Modify()
        {
            Error = "";

            if (product.ProductName == "")
            {
                Error += "Name can not be empty!\n";
            }

            if (Error == "")
            {
                productDAO.Update(Product);
            }

            view.Close();
        }
    }
}
