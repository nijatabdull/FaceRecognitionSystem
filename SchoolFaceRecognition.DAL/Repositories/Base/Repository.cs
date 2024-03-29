﻿using Microsoft.EntityFrameworkCore;
using SchoolFaceRecognition.Core.Abstractions;
using SchoolFaceRecognition.DAL.AppDbContext;
using System.Linq.Expressions;

namespace SchoolFaceRecognition.DAL.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        protected readonly SchoolDbContext _schoolDbContext;

        public Repository(SchoolDbContext schoolDbContext)
        {
            _schoolDbContext = schoolDbContext;
        }

        public virtual async Task AddArrangeAsync(CancellationToken cancellationToken = default, params T[] entities)
        {
            await _schoolDbContext.AddRangeAsync(entities,cancellationToken);
        }

        public virtual async Task AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _schoolDbContext.AddAsync(entity, cancellationToken);
        }

        public virtual void DeleteArrange(CancellationToken cancellationToken = default, params T[] entities)
        {
            _schoolDbContext.RemoveRange(entities, cancellationToken);
        }

        public virtual void Delete(T entity)
        {
            _schoolDbContext.Remove(entity);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _schoolDbContext.Set<T>().ToListAsync(cancellationToken);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
        {
            return await _schoolDbContext.Set<T>().Where(expression).ToListAsync(cancellationToken);
        }

        public virtual void UpdateArrange(CancellationToken cancellationToken = default, params T[] entities)
        {
            _schoolDbContext.UpdateRange(entities, cancellationToken);
        }

        public virtual void Update(T entity)
        {
            _schoolDbContext.Update(entity);
        }

        public virtual async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
        {
             return await _schoolDbContext.Set<T>().FirstOrDefaultAsync(expression, cancellationToken);
        }
    }
}
