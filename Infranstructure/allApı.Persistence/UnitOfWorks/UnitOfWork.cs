using allApı.Application.Interfaces.Repositories;
using allApı.Application.Interfaces.UnitOfWorks;
using allApı.Persistence.Context;
using allApı.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace allApı.Persistence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext dbContext;

        public UnitOfWork(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async ValueTask DisposeAsync() => await dbContext.DisposeAsync();


        public int Save() => dbContext.SaveChanges();


        public async Task<int> SaveAsync() => await dbContext.SaveChangesAsync();


        IReadRepository<T> IUnitOfWork.GetReadRepository<T>() => new readRepository<T>(dbContext);
       
        IWriteRepository<T> IUnitOfWork.GetWriteRepository<T>() => new writeRepository<T>(dbContext);
       
    }
}
