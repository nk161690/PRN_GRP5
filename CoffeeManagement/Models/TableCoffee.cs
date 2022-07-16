using System;
using System.Collections.Generic;

#nullable disable

namespace CoffeeManagement.Models
{
    public partial class TableCoffee
    {
        public TableCoffee()
        {
            Bills = new HashSet<Bill>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }

        public TableCoffee(int id, string name, string status)
        {
            Id = id;
            Name = name;
            Status = status;
        }

        public virtual ICollection<Bill> Bills { get; set; }
    }
}
