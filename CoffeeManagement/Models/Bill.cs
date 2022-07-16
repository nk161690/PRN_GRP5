using System;
using System.Collections.Generic;

#nullable disable

namespace CoffeeManagement.Models
{
    public partial class Bill
    {
        public Bill()
        {
            BillInfos = new HashSet<BillInfo>();
        }

        public Bill(int tableId, int discount, int? totalPrice, int status, string name)
        {
            TableId = tableId;
            Discount = discount;
            TotalPrice = totalPrice;
            Status = status;
            Name = name;
        }

        public Bill(int id, int tableId, int discount, int? totalPrice, int status, string name)
        {
            Id = id;
            TableId = tableId;
            Discount = discount;
            TotalPrice = totalPrice;
            Status = status;
            Name = name;
        }

        public int Id { get; set; }
        public int TableId { get; set; }
        public int Discount { get; set; }
        public int? TotalPrice { get; set; }
        public int Status { get; set; }
        public string Name { get; set; }

        public virtual TableCoffee Table { get; set; }
        public virtual ICollection<BillInfo> BillInfos { get; set; }
    }
}
