using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatBP2.DAO
{
    public class CollaborateDAO : BaseRepo<Collaborate>
    {
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
