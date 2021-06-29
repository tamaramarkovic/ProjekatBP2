using System;
using System.Collections.Generic;
using System.Data.Linq.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatBP2.DAO
{
    public class ShiftDAO : BaseRepo<Shift>
    {
        public new void Delete(object id)
        {
            using (var db = new BeautySalonContainer())
            {
                Shift entityToDelete = (from s in db.ShiftSet.Include("Jobs") where s.ShiftId == (int)id select s).SingleOrDefault();
                db.Entry(entityToDelete).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}
