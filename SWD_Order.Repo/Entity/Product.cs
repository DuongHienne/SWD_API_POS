using System;
using System.Collections.Generic;

namespace SWD_Order.Repo.Entity
{
    public partial class Product
    {
        public Product()
        {
            Images = new HashSet<Image>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public double? Price { get; set; }
        public int? Quantity { get; set; }
        public string? Description { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public bool? Status { get; set; }
        public int? ImageId { get; set; }
        public int? CategoryId { get; set; }

        public virtual Category? Category { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
