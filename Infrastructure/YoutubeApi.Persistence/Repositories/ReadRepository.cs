using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using YoutubeApi.Application.Interfaces.Repositories;
using YoutubeApi.Domain.Common;
using YoutubeApi.Persistence.Context;


namespace YoutubeApi.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : class, IEntityBase, new()
    {
        private readonly AppDbContext _appDbContext;
        public ReadRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        private DbSet<T> Table { get => _appDbContext.Set<T>(); }


        public async Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null)
        {
            IQueryable<T> queryable = Table;

            queryable = queryable.AsNoTracking();

            if (predicate is not null)
            {
                queryable = queryable.Where(predicate);
            }

            return await queryable.CountAsync();
        }


        public IQueryable<T> Find(Expression<Func<T, bool>> predicate, bool enableTracking = false)
        {
            IQueryable<T> queryable = Table;

            if (!enableTracking)
            {
                queryable = queryable.AsNoTracking();
            }

            if (predicate is not null)
            {
                queryable = queryable.Where(predicate);
            }

            return queryable;
        }


        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool enableTracking = false)
        {
            IQueryable<T> queryable = Table;

            if (!enableTracking)
            {
                queryable = queryable.AsNoTracking();
            }

            if (include is not null)
            {
                queryable = include(queryable);
            }

            if (predicate is not null)
            {
                queryable = queryable.Where(predicate);
            }

            if (orderBy is not null)
            {
                return await orderBy(queryable).ToListAsync();
            }
            else
            {
                return await queryable.ToListAsync();
            }
        }


        public async Task<IList<T>> GetAllByPagingAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool enableTracking = false, int currentPage = 1, int pageSize = 3)
        {
            IQueryable<T> queryable = Table;

            if (!enableTracking)
            {
                queryable = queryable.AsNoTracking();
            }

            if (include is not null)
            {
                queryable = include(queryable);
            }

            if (predicate is not null)
            {
                queryable = queryable.Where(predicate);
            }

            if (orderBy is not null)
            {
                return await orderBy(queryable).Skip((currentPage - 1) * pageSize).Take(pageSize).ToListAsync();
            }
            else
            {
                return await queryable.Skip((currentPage - 1) * pageSize).Take(pageSize).ToListAsync();
            }
        }


        public async Task<T> GetAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool enableTracking = false)
        {
            IQueryable<T> queryable = Table;

            if (!enableTracking)
            {
                queryable = queryable.AsNoTracking();
            }

            if (include is not null)
            {
                queryable = include(queryable);
            }

            if (predicate is not null)
            {
                queryable = queryable.Where(predicate);
            }

            return await queryable.FirstOrDefaultAsync();
        }
    }
}