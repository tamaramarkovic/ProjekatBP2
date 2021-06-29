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
        public new void Delete(object id)
        {
            using (var db = new BeautySalonContainer())
            {
                Service entityToDelete = (from s in db.ServiceSet.Include("Bills") where s.ServiceId == (int)id select s).SingleOrDefault();
                db.Entry(entityToDelete).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}
