using my_wep_api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace my_wep_api.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        T Get(Expression<Func<T, bool>> filter = null);//defalu parametre null yaptık

        List<T> GetList(Expression<Func<T, bool>> filter = null);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
