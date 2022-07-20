using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace CoffeeManagement.Models
{
    public partial class Food
    {
        public Food()
        {
            BillInfos = new HashSet<BillInfo>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        [Range(0, 999999)]
        public int Price { get; set; }

        public virtual CategoryFood Category { get; set; }
        public virtual ICollection<BillInfo> BillInfos { get; set; }
    }
}
