using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD_Order.Service.Models
{
    public class AddProduct
    {
        public string? ProductName { get; set; }
        public double? Price { get; set; }
        public int? Quantity { get; set; }
        public string? Description { get; set; }
        public DateTime? ExpirationDate = DateTime.Now;
        public bool? Status = false;
        public int? ImageId = 0;
        public int? CategoryId { get; set; }
        public List<AddImage> addImages { get; set; } = new List<AddImage>();
    }
    public class AddImage
    {
        public string? ImagePath { get; set; }
    }
}
