using System;
using System.Collections.Generic;

namespace SWD_Order.Repo.Entity
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int OrderId { get; set; }
        public int? PaymentId { get; set; }
        public double? Total { get; set; }
        public int? Quantity { get; set; }
        public DateTime? DateCreated { get; set; }

        public virtual Payment? Payment { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
