using System;
using System.Collections.Generic;
using System.Data.Linq.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatBP2.DAO
{
    public class ServiceCompanyDAO : BaseRepo<ServiceCompany>
    {
        public List<ServiceCompany> FindByName(string name)
        {
            using (var db = new BeautySalonContainer())
            {
                return (from sc in db.ServiceCompanySet where SqlMethods.Like(sc.CompanyName, "%" + name + "%") select sc).ToList();
            }
        }

        public new List<ServiceCompany> GetList()
        {
            using (var db = new BeautySalonContainer())
            {
                return (from sc in db.ServiceCompanySet.Include("Work") select sc).ToList();
            }
        }

        public void OfferWork(ServiceCompany serviceCompany, string name)
        {
            Work work = new Work();
            work.WorkName = name;

            serviceCompany.Work.Add(work);

            Update(serviceCompany);
        }

        public new void Delete(object id)
        {
            using (var db = new BeautySalonContainer())
            {
                ServiceCompany entityToDelete = (from sc in db.ServiceCompanySet.Include("Work").Include("Bosses") where sc.CompanyId == (int)id select sc).SingleOrDefault();
                db.Entry(entityToDelete).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}
