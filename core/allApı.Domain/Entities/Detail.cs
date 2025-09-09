using allApı.Domain.Commen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Detail sınıfı, EntityBase sınıfından miras alıyor.
// Bu sınıf bir "detay" bilgisini temsil ediyor (örneğin ürün veya içerik detayı).
// Title, Description ve CategoryId adında required (zorunlu) özellikleri var.
// Ayrıca Category sınıfı ile ilişki kurulmuş (Navigation Property).
// İki constructor içeriyor:
// 1) Parametresiz constructor → boş bir Detail nesnesi oluşturmak için.
// 2) Parametreli constructor → Title, Description ve CategoryId verilerek nesneyi initialize etmek için.
namespace allApı.Domain.Entities
{
    
   public class Detail: EntityBase
    
    {
        public Detail()
        {
            
        }
        public Detail(string title, string description, int categoryId)
        {
            Title = title;
            Description = description;
            CategoryId = categoryId;
        }
        public  string Title { get; set; }
        public  string Description { get; set; }
        public  int CategoryId { get; set; }
        public category Category{ get; set; }
    }
}
