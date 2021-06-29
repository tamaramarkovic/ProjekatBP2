using System;
using System.Collections.Generic;
using System.Data.Linq.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatBP2.DAO
{
    public class OwnerDAO : BaseRepo<Owner>
    {
        public new void Delete(object id)
        {
            using (var db = new BeautySalonContainer())
            {
                Owner entityToDelete = (from o in db.OwnerSet.Include("Jobs").Include("Collaborate")
                                        where o.OwnerId == (int)id select o).SingleOrDefault();
                db.Entry(entityToDelete).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}
