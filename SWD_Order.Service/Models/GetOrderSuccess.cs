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
        public double? TotalPrice { get; set; }
        public string? Status { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? TotalQuantity { get; set; }
        public byte[] ImageData { get; set; }
        public List<ProductDetail> orderDetail { get; set; }
    }
    public class imageOrder
    {

        public string? ImagePath { get; set; }
    }
    public class ProductN
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public double? Price { get; set; }
        public int? Quantity { get; set; }

    }

    public class GetOrderDetail
    {
        public int? OrderId { get; set; }
        public double? TotalPrice { get; set; }
        public string? Status { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? TotalQuantity { get; set; }
        public string? Method { get; set; }
        public List<ProductDetail> Product { get; set; }
    }

    public class ProductDetail
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public double? Price { get; set; }
        public int? Quantity { get; set; }
        public byte[] Image { get; set; }
    }

}
