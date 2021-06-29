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
        public new List<Bill> GetList()
        {
            using (var db = new BeautySalonContainer())
            {
                return (from b in db.BillSet.Include("Services") select b).ToList();
            }
        }

        public new void Delete(object id)
        {
            using (var db = new BeautySalonContainer())
            {
                Bill entityToDelete = (from b in db.BillSet.Include("Services") where b.BillId == (int)id select b).SingleOrDefault();
                db.Entry(entityToDelete).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}
