using allApı.Domain.Entities;
using Bogus;//fake data (sahte veri) üretme kütüphanesi
using Bogus.DataSets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using allApı.Domain.Entities;
// Bu sınıf, Brand entity’si için konfigürasyon ayarlarını yapar. 
// Özellikle Name alanının uzunluğu sınırlandırılır ve 
// Faker kütüphanesi ile örnek veriler üretilip HasData ile seed edilir.
namespace allApı.Persistence.Configurations
{
  public  class BrandConfiguration: IEntityTypeConfiguration<Brand>
    {
        public void Configure (EntityTypeBuilder<Brand> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(256);

            Faker faker = new("tr");   // Türkçe dil desteğiyle Faker nesnesi oluşturuluyor

            Brand brand1 = new Brand
            {
                Id = 1,
                Name = faker.Commerce.Department(),// Faker ile rastgele departman/isim oluşturulur
                CreatedDate = DateTime.Now,
                IsDeleted = false
            };

            Brand brand2 = new Brand
            {
                Id = 1,
                Name = faker.Commerce.Department(),
                CreatedDate = DateTime.Now,
                IsDeleted = false
            };

            Brand brand3 = new Brand
            {
                Id = 1,
                Name = faker.Commerce.Department(),
                CreatedDate = DateTime.Now,
                IsDeleted = true
            };

            // HasData ile migration sırasında seed (başlangıç) verisi eklenir.
            // Veritabanı oluşturulduğunda bu markalar otomatik eklenir.
            builder.HasData(brand1 , brand2,brand3);
        }
    }
}
