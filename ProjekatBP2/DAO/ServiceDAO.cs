using System;
using System.Collections.Generic;
using System.Data.Linq.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatBP2.DAO
{
    public class ServiceDAO : BaseRepo<Service>
    {
        public List<Service> FindByPrice(double price)
        {
            using (var db = new BeautySalonContainer())
            {
                return (from s in db.ServiceSet where SqlMethods.Equals(s.Price, price) select s).ToList();
            }
        }

        public bool CanDelete(int serviceId)
        {
            using (var db = new BeautySalonContainer())
            {
                var service = (from s in db.ServiceSet.Include("Bill.Service") where s.ServiceId == serviceId select s).SingleOrDefault();

                foreach (var bill in service.Bills)
                {
                    if (bill.Services.Count == 1)
                    {
                        return false;
                    }
                }

                return true;
            }
        }
    }
}
