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
        public List<Work> FindByName(string name)
        {
            using (var db = new BeautySalonContainer())
            {
                return (from w in db.WorkSet where SqlMethods.Like(w.WorkName, "%" + name + "%") select w).ToList();
            }
        }

        public bool CanDelete(int workId)
        {
            using (var db = new BeautySalonContainer())
            {
                var work = (from w in db.WorkSet.Include("ServiceCompany.Work") where w.WorkId == workId select w).SingleOrDefault();

                foreach (var company in work.ServiceCompany)
                {
                    if (company.Work.Count == 1)
                    {
                        return false;
                    }
                }

                return true;
            }
        }

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
