using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver;
using TestZigzagApi.Data.Entities;
using TestZigzagApi.Data.Repositories.Interfaces;

namespace TestZigzagApi.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly IMongoCollection<T> mongoCollection;

        public Repository(IMongoCollection<T> mongoCollection)
        {
            this.mongoCollection = mongoCollection;
        }

        public async Task<List<T>> GetByFilter(Expression<Func<T, bool>> condition)
        {
            return await this.mongoCollection.Find(condition).ToListAsync();
        }

        public async Task<List<TValue>> GetFieldValue<TValue>(Expression<Func<T, bool>> condition, Expression<Func<T, TValue>> fieldExpression)
        {
            return await this.mongoCollection.Find(condition).Project(fieldExpression).ToListAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            await this.mongoCollection.DeleteOneAsync(f => f.Id == id);
        }

        public async Task<T> CreateAsync(T entity)
        {
            await this.mongoCollection.InsertOneAsync(entity);

            return entity;
        }
        
        public async Task<List<T>> GetAllAsync()
        {
            return await this.mongoCollection.Find(x => true).ToListAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            await this.mongoCollection.ReplaceOneAsync(x => x.Id == entity.Id, entity);

            return entity;
        }
    }
}