using System;
using System.Linq;
using System.Linq.Expressions;
using EasterneAdventuresApi.Core.Models;

namespace EasterneAdventuresApi.Core.Interfaces
{
    public interface IRepository<T> where T : BaseModel
    {
        T GetSingle(Expression<Func<T, bool>> whereCondition);

        void Add(T entity);
        void Update(T entity);

        void Delete(T entity);

        IQueryable<T> Query(Expression<Func<T, bool>> whereCondition);
        IQueryable<T> Query();
		bool Any(Expression<Func<T, bool>> whereCondition = null);


		long Count(Expression<Func<T, bool>> whereCondition = null);
    }
}

