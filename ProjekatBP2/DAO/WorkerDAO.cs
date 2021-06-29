using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatBP2.DAO
{
    public class WorkerDAO : BaseRepo<Worker>
    {
        public new void Delete(object id)
        {
            using (var db = new BeautySalonContainer())
            {
                Worker entityToDelete = (from w in db.WorkerSet.Include("Jobs").Include("Bill").Include("Sectors").Include("Appoitments")
                                         where w.WorkerId == (int)id select w).SingleOrDefault();
                db.Entry(entityToDelete).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public List<GetAllWorkerSalary_Result> GetAllWorkers(int salary)
        {
            List<GetAllWorkerSalary_Result> workers = new List<GetAllWorkerSalary_Result>();

            using (var db = new BeautySalonContainer())
            {
                try
                {
                    workers = db.GetAllWorkerSalary(salary).ToList();
                }
                catch
                {
                    workers = new List<GetAllWorkerSalary_Result>();
                }
            }

            return workers;
        }
    }
}
