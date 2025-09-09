﻿using allApı.Domain.Commen;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace allApı.Application.Interfaces.Repositories
{
    //Bu IReadRepository<T> arayüzü (interface), veritabanından
    //okuma (read) işlemlerini soyutlamak için kullanılıyor.
    //Yani veri çekme işleri için ortak bir nokta sağlıyor.
    public interface  IReadRepository<T> where T : class, IEntityBase,new()
    {
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            bool enableTracking =false);

        Task<IList<T>> GetAllByPagingAsync(Expression<Func<T, bool>>? predicate = null,
           Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
           Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
           bool enableTracking = false, int currentPage=1, int pageSize=3);//mevcut sayfadaki ilk 3 veriyi alıyor

        Task<IList<T>> GetAsync(Expression<Func<T, bool>> predicate ,
           Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
           bool enableTracking = false);


        IQueryable<T> Find(Expression<Func<T, bool>> predicate, bool enableTracking = false);

        Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null);
    }
}
//GetAllAsync(x=>x.include (x=>x.Bramd).theninclude)