using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using Core.DataAccess.SqlServer.EntityFramework;

namespace Northwind.DAL
{
    public class Repository<TEntity>:RepositoryBase<TEntity,NorthwindDbContext>,IRepository<TEntity>
        where TEntity:class,new()
    {
        public Repository():base(SingletonContext.Context)
        {

        }
    }
}
