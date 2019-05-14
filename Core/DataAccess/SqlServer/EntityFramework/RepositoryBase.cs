using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.SqlServer.EntityFramework
{
    public class RepositoryBase<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class, new()
        where TContext : DbContext, new()
    {
        TContext _db;
        public RepositoryBase(TContext db)
        {
            _db =db;
        }
        public int Add(TEntity entity)
        {
            int ess = 0;
            //DBContext kullanım yöntemi farklı olarak..
            using (TContext db = new TContext())
            {
                db.Set<TEntity>().Add(entity);
                ess = db.SaveChanges();
            }
            return ess;
        }

        public int Delete(TEntity entity)
        {
            _db.Entry(entity).State = EntityState.Deleted;
            return _db.SaveChanges();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            if (filter != null)
            {
                return _db.Set<TEntity>().Where(filter).SingleOrDefault();
            }
            throw new Exception("filter parametresi null gönderilemez.");
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter != null ? _db.Set<TEntity>().Where(filter).ToList()
                 : _db.Set<TEntity>().ToList();
        }

        public IQueryable<TEntity> GetQuery(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter!=null? _db.Set<TEntity>().Where(filter).Select(t=> t): _db.Set<TEntity>().Select(t=> t);
        }

        public int Update(TEntity entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            return _db.SaveChanges();
        }
    }
}
