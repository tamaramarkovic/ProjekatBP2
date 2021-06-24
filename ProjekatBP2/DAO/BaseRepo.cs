using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatBP2.DAO
{
    public abstract class BaseRepo<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public BaseRepo() { }

        public void Delete(object id)
        {
            using (var db = new BeautySalonContainer())
            {
                TEntity entityToDelete = db.Set<TEntity>().Find(id);
                db.Entry(entityToDelete).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public TEntity FindById(object id)
        {
            using (var db = new BeautySalonContainer())
            {
                return db.Set<TEntity>().Find(id);
            }
        }

        public List<TEntity> GetList()
        {
            using (var db = new BeautySalonContainer())
            {
                return db.Set<TEntity>().ToList();
            }
        }

        public void Insert(TEntity entity)
        {
            using (var db = new BeautySalonContainer())
            {
                db.Set<TEntity>().Add(entity);
                db.SaveChanges();
            }
        }

        public void Update(TEntity entity)
        {
            using (var db = new BeautySalonContainer())
            {
                db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
