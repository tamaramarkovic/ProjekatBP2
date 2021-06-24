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
        public List<Shift> FindByDate(DateTime startTime, DateTime endTime)
        {
            using (var db = new BeautySalonContainer())
            {
                return (from s in db.ShiftSet where SqlMethods.Like(s.StartTime.ToString(), startTime.ToString()) &&
                        SqlMethods.Like(s.EndTime.ToString(), endTime.ToString()) select s).ToList();
            }
        }
    }
}
