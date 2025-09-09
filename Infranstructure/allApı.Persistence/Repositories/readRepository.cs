using allApı.Application.Interfaces.Repositories;
using allApı.Domain.Commen;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace allApı.Persistence.Repositories
{
    public class readRepository<T> : IReadRepository<T> where T :class, IEntityBase, new()
    {
        private readonly DbContext dbContext;//EF Core’un DbContext nesnesini sınıfa alındı repository içinde veritabanı ile haberleşiyot
        public readRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        private DbSet<T> Table { get => dbContext.Set<T>(); } //hazır fonksiyon yaparak her seferinde yeni metod yazmıyoruz

        //veritabanından istediğin verileri filtreleyerek, sıralayarak,
        //ilişkili tabloları dahil ederek veya sadece okuyarak çekmek için
        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool enableTracking = false)
        {
            // 1️⃣ DbSet<T> üzerinden sorgu başlatılıyor (henüz çalıştırılmamış bir sorgu var)
            IQueryable<T> queryable = Table;

            // Eğer takip (tracking) kapalı ise, sorgu sadece okuma modunda çalışır (daha hızlı olur, belleğe yük bindirmez)
            if (!enableTracking)
                queryable = queryable.AsNoTracking();

            // 3 Eğer include verilmişse, yani ilişkili tablolar da dahil edilmek istenmişse, sorguya ekleniyor
            if (include is not null)
                queryable = include(queryable);

            // 4Eğer bir filtre (predicate) verilmişse, Where ile sorguya uygulanıyor
            if (predicate is not null)
                queryable = queryable.Where(predicate);

            // 5 Eğer sıralama fonksiyonu verilmişse, sıralama uygulanıyor ve listeye dönüştürülüyor
            if (orderBy is not null)
                return await orderBy(queryable).ToListAsync();

            // 6Eğer sıralama yoksa, sadece veriler listeye dönüştürülüp döndürülüyor
            return await queryable.ToListAsync();
        }


         public async Task<IList<T>> GetAllByPagingAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool enableTracking = false, int currentPage = 1, int pageSize = 3)
        {
            IQueryable<T> queryable = Table;

            if (!enableTracking)
                queryable = queryable.AsNoTracking();

            if (include is not null)
                queryable = include(queryable);

            if (predicate is not null)
                queryable = queryable.Where(predicate);

            if (orderBy is not null)
                return await orderBy(queryable).Skip((currentPage - 1) * pageSize).Take(pageSize).ToListAsync();

            return await queryable.Skip((currentPage - 1) * pageSize).Take(pageSize).ToListAsync();
        }

         public async Task<IList<T>> GetAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool enableTracking = false)
                {
            IQueryable<T> queryable = Table;

            // Eğer takip (tracking) kapalı ise, sadece okuma
            if (!enableTracking)
                queryable = queryable.AsNoTracking();

            // Include varsa ilişkili tabloları ekle
            if (include is not null)
                queryable = include(queryable);

            // Filtre uygula
            queryable = queryable.Where(predicate);

            // Liste olarak döndür
            return await queryable.ToListAsync();
        }


        public async Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null)
        {
            Table.AsNoTracking();
            if (predicate is not null) Table.Where(predicate);
            return await Table.CountAsync();
        }

        public  IQueryable<T> Find(Expression<Func<T, bool>> predicate , bool enableTracking = false)
        {
            IQueryable<T> queryable = Table;

            if (!enableTracking)
                queryable = queryable.AsNoTracking(); // AsNoTracking etkili olacak şekilde ata

            return queryable.Where(predicate); // IQueryable döndü 

        }





    }
}
