using allApı.Application.Interfaces.Repositories;
using allApı.Domain.Commen;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace allApı.Persistence.Repositories
{
    public class writeRepository<T> : IWriteRepository<T> where T : class, IEntityBase, new()
    {

        private readonly DbContext dbContext;//EF Core’un DbContext nesnesini sınıfa alındı repository içinde veritabanı ile haberleşiyot
        public writeRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        private DbSet<T> Table { get => dbContext.Set<T>(); } //hazır fonksiyon yaparak her seferinde yeni metod yazmıyoruz

        public async Task AddAsync(T entity)
        {
            await Table.AddAsync(entity);
        }

        public async Task AddRangeAsync(T entities)
        {
            await Table.AddRangeAsync(entities);
        }
         public async Task<T> UpdateAsync(T entity)
                {
            await Task.Run(() => Table.Update(entity));
            return entity;
                }
        public async Task HardDeleteAsync(T entity)
        {
            await Task.Run(() => Table.Remove(entity));

        }

       
       
    }
}
