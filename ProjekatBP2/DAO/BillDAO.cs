using System;
using System.Collections.Generic;
using System.Data.Linq.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatBP2.DAO
{
    public class BillDAO : BaseRepo<Bill>
    {
        public List<Bill> FindByDate(DateTime date)
        {
            using (var db = new BeautySalonContainer())
            {
                return (from b in db.BillSet where SqlMethods.Equals(b.Date, date) select b).ToList();
            }
        }

        public void AddService(Bill bill, double price)
        {
            Service service = new Service();
            service.Price = price;

            bill.Services.Add(service);

            Update(bill);
        }

        public List<Service> GetServices(Bill bill)
        {
            using (var db = new BeautySalonContainer())
            {
                return (from b in db.BillSet where SqlMethods.Equals(b.BillId, bill.BillId) select b.Services).SingleOrDefault().ToList();
            }
        }
    }
}
