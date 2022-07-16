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

        public Bill(int tableId, int discount, int? totalPrice, int status)
        {
            TableId = tableId;
            Discount = discount;
            TotalPrice = totalPrice;
            Status = status;
        }

        public Bill(int id, int tableId, int discount, int? totalPrice, int status)
        {
            Id = id;
            TableId = tableId;
            Discount = discount;
            TotalPrice = totalPrice;
            Status = status;
        }

        public int Id { get; set; }
        public int TableId { get; set; }
        public int Discount { get; set; }
        public int? TotalPrice { get; set; }
        public int Status { get; set; }

        public virtual TableCoffee Table { get; set; }
        public virtual ICollection<BillInfo> BillInfos { get; set; }
    }
}
