using allApı.Domain.Commen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Category sınıfı, EntityBase sınıfından miras alıyor ve IEntityBase arayüzünü implemente ediyor.
// Bu sınıf bir kategori bilgisini temsil ediyor (örneğin ürün kategorisi).
// 3 tane property içeriyor: ParentId, Name ve Priority.
// "required" anahtar sözcüğü ile bu property’lerin nesne oluşturulurken mutlaka verilmesi gerektiği belirtilmiş.
// İki constructor var: 
// 1) Parametresiz constructor → boş bir Category nesnesi oluşturmak için.
// 2) Parametreli constructor → ParentId, Name ve Priority değerleri verilerek nesneyi initialize etmek için.

namespace allApı.Domain.Entities
{
   public class category: EntityBase,IEntityBase 
    {
        public category()
        {
            
        }
        public category(int parentId, string name, int priorty)
        {
            ParentId = parentId;
            Name = name;
            Priorty = priorty;
        }

        public required int ParentId { get; set; }
        public required string Name { get; set; }
        public required int Priorty { get; set; }
        public ICollection<Detail> Details { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
