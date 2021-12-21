using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TestZigzagApi.Data.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        Task<List<T>> GetByFilter(Expression<Func<T, bool>> condition);

        Task<List<TValue>> GetFieldValue<TValue>(Expression<Func<T, bool>> condition, Expression<Func<T, TValue>> fieldExpression);

        Task DeleteAsync(Guid id);

        Task<T> CreateAsync(T entity);

        Task<List<T>> GetAllAsync();

        Task<T> UpdateAsync(T entity);
    }
}