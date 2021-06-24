using System;
using System.Collections.Generic;
using System.Data.Linq.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatBP2.DAO
{
    public class BossDAO : BaseRepo<Boss>
    {
        public List<Boss> FindByName(string name)
        {
            using (var db = new BeautySalonContainer())
            {
                return (from b in db.BossSet where SqlMethods.Like(b.BossName, "%" + name + "%") select b).ToList();
            }
        }

        public void AddServiceCompany(Boss boss, string number, string name)
        {
            ServiceCompany serviceCompany = new ServiceCompany();
            serviceCompany.CompanyName = name;
            serviceCompany.PhoneNumber = number;

            boss.ServiceCompanies.Add(serviceCompany);

            Update(boss);
        }

        public List<ServiceCompany> GetServiceCompany(Boss boss)
        {
            using (var db = new BeautySalonContainer())
            {
                return (from b in db.BossSet where SqlMethods.Equals(b.BossBossId, boss.BossBossId) select b.ServiceCompanies).SingleOrDefault().ToList();
            }
        }

        public void SeniorBoss(Boss boss, string name, string surname)
        {
            Boss SuperBoss = new Boss();
            SuperBoss.BossName = name;
            SuperBoss.BossSurname = surname;

            boss.SuperBoss = SuperBoss;

            Update(SuperBoss);
        }
    }
}
