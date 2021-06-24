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
                return (from j in db.JobSet.OfType<HairStylist>() select j).ToList();
            }
        }

        public List<Beautican> GetBeauticans()
        {
            using (var db = new BeautySalonContainer())
            {
                return (from j in db.JobSet.OfType<Beautican>() select j).ToList();
            }
        }

        public List<Barber> GetBarbers()
        {
            using (var db = new BeautySalonContainer())
            {
                return (from j in db.JobSet.OfType<Barber>() select j).ToList();
            }
        }
    }
}
