using allApı.Application.Interfaces.Repositories;
using allApı.Persistence.Context;
using allApı.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace allApı.Persistence
{
   public static class Registration
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));


            ///read reposity yaptıktan sonra yazıldı  
            // Dependency Injection (DI) için repository'yi kaydediyoruz.
            // IServiceCollection üzerinden, her yerde IReadRepository<T> kullanıldığında
            // ASP.NET Core otomatik olarak readRepository<T> örneğini oluşturacak.

            // AddScoped:
            // - Scoped yaşam süresi demek, yani **her HTTP isteği (request) için tek bir instance** oluşturulur.
            // - Aynı request içinde birden fazla kez kullanılsa bile **aynı nesne paylaşılır**.
            // - Request bitince nesne bellekten atılır.
            services.AddScoped(typeof(IReadRepository<>), typeof(readRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(writeRepository<>));

        }
    }
}

 