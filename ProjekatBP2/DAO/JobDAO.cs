using System;
using System.Collections.Generic;
using System.Data.Linq.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatBP2.DAO
{
    public class JobDAO : BaseRepo<Job>
    {
        public List<HairStylist> GetHairStylists()
        {
            using (var db = new BeautySalonContainer())
            {
                return (from j in db.JobSet.Include("Shift").OfType<HairStylist>() select j).ToList();
            }
        }

        public List<Beautican> GetBeauticans()
        {
            using (var db = new BeautySalonContainer())
            {
                return (from j in db.JobSet.Include("Shift").OfType<Beautican>() select j).ToList();
            }
        }

        public List<Barber> GetBarbers()
        {
            using (var db = new BeautySalonContainer())
            {
                return (from j in db.JobSet.Include("Shift").OfType<Barber>() select j).ToList();
            }
        }

        public new void Delete(object id)
        {
            using (var db = new BeautySalonContainer())
            {
                Job entityToDelete = (from j in db.JobSet.Include("Shift").Include("Worker").Include("Owners") where j.JobId == (int)id select j).SingleOrDefault();
                db.Entry(entityToDelete).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}
