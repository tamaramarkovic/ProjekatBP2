using System;
using System.Collections.Generic;
using System.Data.Linq.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatBP2.DAO
{
    public class BossDAO : BaseRepo<Boss>
    {
        public new List<Boss> GetList()
        {
            using (var db = new BeautySalonContainer())
            {
                return (from b in db.BossSet.Include("Workers") select b).ToList();
            }
        }

        public new void Delete(object id)
        {
            using (var db = new BeautySalonContainer())
            {
                Boss entityToDelete = (from b in db.BossSet.Include("Workers") where b.BossId == (int)id select b).SingleOrDefault();
                db.Entry(entityToDelete).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}
