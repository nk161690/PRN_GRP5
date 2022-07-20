using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace CoffeeManagement.Models
{
    public partial class BillInfo
    {
        public int Id { get; set; }
        public int BillId { get; set; }
        public int FoodId { get; set; }
        [Range(0,1000)]
        public int Amount { get; set; }
        public int Status { get; set; }

        public BillInfo(int billId, int foodId, int amount, int status)
        {
            BillId = billId;
            FoodId = foodId;
            Amount = amount;
            Status = status;
        }
        public virtual Bill Bill { get; set; }
        public virtual Food Food { get; set; }
    }
}
