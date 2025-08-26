using allApı.Domain.Commen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Product sınıfı, EntityBase sınıfından miras alıyor.
// Bu sınıf bir ürünü temsil ediyor.
// Zorunlu (required) özellikleri: Title, Description, BrandId, Price ve Discount.
// BrandId ile Brand arasında ilişki kurulmuş (Foreign Key + Navigation Property).
namespace allApı.Domain.Entities
{
 public   class Product: EntityBase
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required int BrandId { get; set; }
        public required decimal Price { get; set; }
        public required decimal Discount { get; set; }
        public Brand Brand { get; set; }
        public ICollection<category> categories { get; set; }
    }
}
