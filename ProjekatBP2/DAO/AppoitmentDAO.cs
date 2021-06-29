using System;
using System.Collections.Generic;
using System.Data.Linq.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatBP2.DAO
{
    public class AppoitmentDAO : BaseRepo<Appoitment>
    {
        public new void Delete(object id)
        {
            using (var db = new BeautySalonContainer())
            {
                Appoitment entityToDelete = (from a in db.AppoitmentSet.Include("Workers") where a.AppoitmentId == (int)id select a).SingleOrDefault();
                db.Entry(entityToDelete).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}
