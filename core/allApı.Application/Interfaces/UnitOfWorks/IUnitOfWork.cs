using allApı.Application.Interfaces.Repositories;
using allApı.Domain.Commen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Unit of Work (iş birimi), bir işlem sürecinde yapılan tüm veritabanı
//değişikliklerini takip eden ve bu değişiklikleri tek bir işlem (transaction)
//olarak yöneten bir yazılım tasarım desenidir.
//1-Farklı repository’lerden yapılan işlemleri birleştirir.
//2 - Bu işlemleri toplu olarak veritabanına kaydeder (SaveChanges).
//3-Hatalı durumda tüm işlemleri geri almayı kolaylaştırır.
namespace allApı.Application.Interfaces.UnitOfWorks
{
  public  interface IUnitOfWork: IAsyncDisposable
    {
        IReadRepository<T> GetReadRepository<T>() where T : class, IEntityBase, new();
        IWriteRepository<T> GetWriteRepository<T>() where T : class, IEntityBase, new();
        Task<int> SaveAsync();//Yapılan değişiklikleri (write işlemlerini) veritabanına asenkron kaydeder.
        int Save(); //SaveAsync’in senkron (normal) versiyonu.


    }
}
