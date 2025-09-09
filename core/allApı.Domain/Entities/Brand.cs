using allApı.Domain.Commen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Bu sınıf bir markayı (örneğin ürün markası) temsil ediyor.
namespace allApı.Domain.Entities
{
   public class Brand: EntityBase
    {
        public Brand()
        {
            
        }
        public Brand(string name)
        {
            Name = name;
        }
        public  string Name { get; set; }
    }
}
