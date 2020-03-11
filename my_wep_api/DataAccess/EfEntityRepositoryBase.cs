using Microsoft.EntityFrameworkCore;
using my_wep_api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace my_wep_api.DataAccess
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext
    {
        protected TContext _resumeContext;

        public EfEntityRepositoryBase(TContext context)
        {
            _resumeContext = context;
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {

            return _resumeContext.Set<TEntity>().SingleOrDefault(filter);

        }
        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {

            return filter == null
                ? _resumeContext.Set<TEntity>().ToList()
                : _resumeContext.Set<TEntity>().Where(filter).ToList();
        }
        public void Add(TEntity entity)
        {

            var addedEntity = _resumeContext.Entry(entity);
            addedEntity.State = EntityState.Added;
            _resumeContext.SaveChanges();

            //https://youtu.be/PpqdsJDvcxY?list=PLdo4fOcmZ0oX7uTkjYwvCJDG2qhcSzwZ6&t=578
            //context.Add(entity);
            //context.SaveChanges();


        }
        public void Update(TEntity entity)
        {

            var updatedEntity = _resumeContext.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            _resumeContext.SaveChanges();
        }
        public void Delete(TEntity entity)
        {
            var deleteEntity = _resumeContext.Entry(entity);
            deleteEntity.State = EntityState.Deleted;
            _resumeContext.SaveChanges();
        }
    }
}
