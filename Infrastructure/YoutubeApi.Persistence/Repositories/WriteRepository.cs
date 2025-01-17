using Microsoft.EntityFrameworkCore;
using YoutubeApi.Application.Interfaces.Repositories;
using YoutubeApi.Domain.Common;
using YoutubeApi.Persistence.Context;


namespace YoutubeApi.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : class, IEntityBase, new()
    {
        private readonly AppDbContext _dbContext;
        public WriteRepository(AppDbContext DbContext)
        {
            _dbContext = DbContext;
        }

        private DbSet<T> Table { get => _dbContext.Set<T>(); }


        public async Task AddAsync(T entity)
        {
            await Table.AddAsync(entity);
        }

        public async Task AddRangeAsync(IList<T> entities)
        {
            await Table.AddRangeAsync(entities);
        }

        public async Task HardDeleteAsync(T entity)
        {
            //remove'nin asyc'nu olmadığı için biz yazdık.
            await Task.Run(() => Table.Remove(entity));
        }

        public async Task<T> UpdateAsync(T entity)
        {
            //update'nin asyc'nu olmadığı için biz yazdık.
            await Task.Run(() => Table.Update(entity));

            return entity;
        }
    }
}
