using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD_Order.Service.Models
{
    public class ModelsPro
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public double? Price { get; set; }
        public int? Quantity { get; set; }
        public string? Description { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public bool? Status { get; set; }
        public string? CategoryName { get; set; }
        public List<ModelsIg> image { get; set; } = new List<ModelsIg>();
    }
    public class ModelsIg
    {
        public int? ProductId { get; set; }
        public string? ImagePath { get; set; }
    }
}
