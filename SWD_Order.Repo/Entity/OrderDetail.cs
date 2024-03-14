using System;
using System.Collections.Generic;

namespace SWD_Order.Repo.Entity
{
    public partial class OrderDetail
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public int? ProductId { get; set; }
        public double? Price { get; set; }
        public string? Status { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? Quantity { get; set; }
        public string? Code { get; set; }

        public virtual Order? Order { get; set; }
        public virtual Product? Product { get; set; }
    }
}
