using System;
using System.Collections.Generic;

#nullable disable

namespace CoffeeManagement.Models
{
    public partial class BillInfo
    {
        public int Id { get; set; }
        public int BillId { get; set; }
        public int FoodId { get; set; }
        public int Amount { get; set; }

        public BillInfo(int billId, int foodId, int amount)
        {
            BillId = billId;
            FoodId = foodId;
            Amount = amount;
        }
        public virtual Bill Bill { get; set; }
        public virtual Food Food { get; set; }
    }
}
