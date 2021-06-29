using System;
using System.Collections.Generic;
using System.Data.Linq.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatBP2.DAO
{
    public class SectorDAO : BaseRepo<Sector>
    {
        public new void Delete(object id)
        {
            using (var db = new BeautySalonContainer())
            {
                Sector entityToDelete = (from s in db.SectorSet.Include("Workers")
                                         where s.SectorId == (int)id select s).SingleOrDefault();
                db.Entry(entityToDelete).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}
