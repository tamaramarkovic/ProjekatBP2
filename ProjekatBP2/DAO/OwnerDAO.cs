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
        public List<Owner> FindByName(string name)
        {
            using (var db = new BeautySalonContainer())
            {
                return (from o in db.OwnerSet where SqlMethods.Like(o.OwnerName, "%" + name + "%") select o).ToList();
            }
        }

        public bool CanDelete(int ownerId)
        {
            using (var db = new BeautySalonContainer())
            {
                var owner = (from o in db.OwnerSet.Include("Collaborate") where o.OwnerId == ownerId select o).SingleOrDefault();

                if (owner.Collaborate != null && owner.Collaborate.Count > 0)
                {
                    return false;
                }

                return true;
            }
        }

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
