using allApı.Domain.Entities;
using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Bu sınıfta Detail tablosu için seed data (başlangıç verisi) eklenmektedir.
// Faker kütüphanesi kullanılarak sahte başlık ve açıklamalar üretilir.
// Migration çalıştırıldığında veritabanı oluşturulurken bu veriler otomatik eklenir.
namespace allApı.Persistence.Configurations
{
    class DetailConfiguration: IEntityTypeConfiguration<Detail>
    {
        public void Configure(EntityTypeBuilder<Detail> builder)
        {
            Faker faker = new("tr");   // Türkçe dil desteğiyle Faker nesnesi oluşturuluyor

            Detail detail1 = new Detail
            {
                Id = 1,
                Title= faker.Lorem.Sentence(1),
                Description = faker.Lorem.Sentence(5),
                CategoryId = 1,
                CreatedDate= DateTime.Now,
                IsDeleted = false,
            };

            Detail detail2 = new Detail
            {
                Id = 2,
                Title = faker.Lorem.Sentence(2),
                Description = faker.Lorem.Sentence(5),
                CategoryId = 3,
                CreatedDate = DateTime.Now,
                IsDeleted = false,
            };
            Detail detail3 = new Detail
            {
                Id = 3,
                Title = faker.Lorem.Sentence(1),
                Description = faker.Lorem.Sentence(5),
                CategoryId = 4,
                CreatedDate = DateTime.Now,
                IsDeleted = true,
            };
            builder.HasData(detail1, detail2, detail3);
        }
    }
}
