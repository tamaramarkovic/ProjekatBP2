using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatBP2.DAO
{
    public class CollaborateDAO : BaseRepo<Collaborate>
    {
        public void SuppliesProduct(Collaborate collaborate, string name)
        {
            Product product = new Product();
            product.ProductName = name;

            collaborate.Products.Add(product);

            Update(collaborate);
        }

        public void ManufacturerGer(Collaborate collaborate, string name)
        {
            Manufacturer manufacturer = new Manufacturer();
            manufacturer.ManufacturerName = name;

            collaborate.Manufacturers = manufacturer;

            Update(collaborate);
        }

        public bool CanDelete(int collaborateId)
        {
            using (var db = new BeautySalonContainer())
            {
                var collaborate = (from c in db.CollaborateSet.Include("Product.Collaborate").Include("Manufacturer") where c.CollaborateId == collaborateId select c).SingleOrDefault();

                foreach (var product in collaborate.Products)
                {
                    if (product.Collaborations.Count == 1)
                    {
                        return false;
                    }
                }

                if (collaborate.Manufacturers != null)
                {
                    if (collaborate.Manufacturers.Collaborate.Count == 1)
                    {
                        return false;
                    }
                }

                return true;

            }
        }

        public new void Delete(object id)
        {
            using (var db = new BeautySalonContainer())
            {
                Collaborate entityToDelete = (from c in db.CollaborateSet.Include("Products").Include("Manufacturers").Include("Owners")
                                              where c.CollaborateId == (int)id select c).SingleOrDefault();
                db.Entry(entityToDelete).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}
