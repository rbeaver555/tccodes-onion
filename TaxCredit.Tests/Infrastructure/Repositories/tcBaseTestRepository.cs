//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Linq.Expressions;
//using System.Data.Entity;
//using TaxCredit.Core.Models;
//using TaxCredit.Core.Interfaces;
//using TaxCredit.Core.DomainServices;
//using TaxCredit.Core.Interfaces.Repositories;
//using TaxCredit.Infrastructure.Data;

//namespace TaxCredit.Tests.Infrastructure.Repositories
//{

//    namespace TaxCredit.Infrastructure.Repositories
//    {
//        public class tcBaseTestRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
//        {
//            protected EliteTaxCreditEntities _dataContext;
//            protected DbSet<TEntity> dbSet;


//            public DbSet<TEntity> InternalCollection
//            {
//                get
//                {
//                    return dbSet;
//                }
//            }

//            public tcBaseTestRepository(EliteTaxCreditEntities _dataContext)
//            {
//                this._dataContext = _dataContext;
//                this.dbSet = _dataContext.Set<TEntity>();
//            }

//            public tcBaseTestRepository()
//            {
//                this._dataContext = new EliteTaxCreditEntities();
//                this.dbSet = _dataContext.Set<TEntity>();
//            }

//            public virtual IEnumerable<TEntity> Get(
//                Expression<Func<TEntity, bool>> filter = null,
//                Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
//                string includeProperties = "")
//            {
//                IQueryable<TEntity> query = dbSet;

//                if (filter != null)
//                {
//                    query = query.Where(filter);
//                }

//                foreach (var includeProperty in includeProperties.Split
//                    (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
//                {
//                    query = query.Include(includeProperty);
//                }

//                if (orderBy != null)
//                {
//                    return orderBy(query).ToList();
//                }
//                else
//                {
//                    return query.ToList();
//                }
//            }

//            public virtual TEntity GetByID(object id)
//            {
//                return dbSet.Find(id);
//            }

//            public virtual void Insert(TEntity entity)
//            {
//                dbSet.Add(entity);
//            }

//            public virtual void Delete(object id)
//            {
//                TEntity entityToDelete = dbSet.Find(id);
//                Delete(entityToDelete);
//            }

//            public virtual void Delete(TEntity entityToDelete)
//            {
//                if (_dataContext.Entry(entityToDelete).State == EntityState.Detached)
//                {
//                    dbSet.Attach(entityToDelete);
//                }
//                dbSet.Remove(entityToDelete);
//            }

//            public virtual void Update(TEntity entityToUpdate)
//            {
//                dbSet.Attach(entityToUpdate);
//                _dataContext.Entry(entityToUpdate).State = EntityState.Modified;
//            }

//        }
//    }

//}
