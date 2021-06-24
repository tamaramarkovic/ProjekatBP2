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
        public List<Sector> FindByName(string name)
        {
            using (var db = new BeautySalonContainer())
            {
                return (from s in db.SectorSet where SqlMethods.Like(s.SectorName, "%" + name + "%") select s).ToList();
            }
        }
    }
}
