using System;
using System.Collections.Generic;
using System.Data.Linq.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatBP2.DAO
{
    public class WorkDAO : BaseRepo<Work>
    {
        public new void Delete(object id)
        {
            using (var db = new BeautySalonContainer())
            {
                ServiceCompany entityToDelete = (from sc in db.ServiceCompanySet.Include("ServiceCompany") where sc.CompanyId == (int)id select sc).SingleOrDefault();
                db.Entry(entityToDelete).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}
