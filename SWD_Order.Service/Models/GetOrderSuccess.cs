using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD_Order.Service.Models
{
    public class GetOrderSuccess
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public int? ProductId { get; set; }
        public double? Price { get; set; }
        public string? Status { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? Quantity { get; set; }
        public string? Code { get; set; }
        public List<imageOrder> imageOrders { get; set; } = new List<imageOrder>();
        public ProductN productN { get; set; }
    }
    public class imageOrder {

        public string? ImagePath { get; set; }
    }
    public class ProductN
    {
        public string? ProductName { get; set; }
    }

}
