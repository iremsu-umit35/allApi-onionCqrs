using allApı.Domain.Commen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace allApı.Application.Interfaces.Repositories
{
   public interface IWriteRepository <T> where T : class, IEntityBase, new()
    {
        Task AddAsync(T entity);//Yeni bir entity ekler (ör. yeni kullanıcı eklemek). etkilenen kayıt sayısını veya yeni kaydın Id’sini döner.
        Task AddRangeAsync(T entities);//Aynı anda birden fazla entity eklemek için kullanılır.
        Task<T> UpdateAsync(T entity);//Var olan bir entity’yi günceller (ör. kullanıcı adını değiştirmek).
        Task HardDeleteAsync(T entity);//Hard delete: kaydı veritabanından tamamen siler.id ile siliniyor

    }
}
 