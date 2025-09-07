using allApı.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Bu sınıf Category tablosu için seed data (başlangıç verileri) ekler.
// Örnek kategoriler ve onların alt kategorileri oluşturulmuştur.
// Migration çalıştırıldığında veritabanı oluşturulurken bu kategoriler otomatik eklenir.
namespace allApı.Persistence.Configurations
{
    class categoryConfiguration : IEntityTypeConfiguration<category>
    {
        public void Configure(EntityTypeBuilder<category> builder)
        {
            category category1 = new category
            {
                Id = 1,
                Name = "Elektrik",
                Priorty = 1,
                ParentId = 0,
                IsDeleted = false,
                CreatedDate = DateTime.Now

            };

            category category2 = new category
            {
                Id = 2,
                Name = "moda",
                Priorty = 2,
                ParentId = 0,
                IsDeleted = false,
                CreatedDate = DateTime.Now

            };

            category parent1 = new category
            {
                Id = 3,
                Name = "Bilgisayar",
                Priorty = 1,
                ParentId = 1,
                IsDeleted = false,
                CreatedDate = DateTime.Now

            };

            category parent2 = new category
            {
                Id = 4,
                Name = "Kadın",
                Priorty = 1,
                ParentId = 2,
                IsDeleted = false,
                CreatedDate = DateTime.Now

            };
            builder.HasData(category1, category2, parent1, parent2);
        }
    }
}
