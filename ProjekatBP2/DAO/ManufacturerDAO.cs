using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatBP2.DAO
{
    public class ManufacturerDAO : BaseRepo<Manufacturer>
    {
        public Manufacturer FindById(int manufacturerId)
        {
            using (var db = new BeautySalonContainer())
            {
                return db.ManufacturerSet.Find(manufacturerId);
            }
        }

        public new List<Manufacturer> GetList()
        {
            using (var db = new BeautySalonContainer())
            {
                return db.ManufacturerSet.ToList();
            }
        }

        public new void Insert(Manufacturer manufacturer)
        {
            using (var db = new BeautySalonContainer())
            {
                db.ManufacturerSet.Add(manufacturer);
                db.SaveChanges();
            }
        }

        public new void Delete(int manufacturerId)
        {
            using (var db = new BeautySalonContainer())
            {
                var manufacturer = db.ManufacturerSet.Find(manufacturerId);
                db.Entry(manufacturer).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public new void Update(Manufacturer manufacturer)
        {
            using (var db = new BeautySalonContainer())
            {
                db.Entry(manufacturer).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public bool CanDelete(int manufacturerId)
        {
            using (var db = new BeautySalonContainer())
            {
                var manufacturer = (from m in db.ManufacturerSet.Include("Collaborate") where m.ManufacturerId == manufacturerId select m).SingleOrDefault();

                if (manufacturer.Collaborate != null && manufacturer.Collaborate.Count > 0)
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
                Manufacturer entityToDelete = (from m in db.ManufacturerSet.Include("Collaborate")
                                               where m.ManufacturerId == (int)id select m).SingleOrDefault();
                db.Entry(entityToDelete).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}
