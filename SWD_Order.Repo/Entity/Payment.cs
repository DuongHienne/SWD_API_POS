using System;
using System.Collections.Generic;

namespace SWD_Order.Repo.Entity
{
    public partial class Payment
    {
        public Payment()
        {
            Orders = new HashSet<Order>();
        }

        public int PaymentId { get; set; }
        public bool? Status { get; set; }
        public double? Amount { get; set; }
        public string? Method { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
