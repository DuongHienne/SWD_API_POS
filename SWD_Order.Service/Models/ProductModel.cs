using SWD_Order.Repo.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD_Order.Service.Models
{
   
    public class ProductResponse
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public double? Price { get; set; }
        public int? Quantity { get; set; }
        public string? Description { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public bool? Status { get; set; }
        public string? CategoryName { get; set; }
        public List<ImageModel>? ListImages { get; set; } = new List<ImageModel>();

    }

    public class CategoryModel
    {
        public int Id { get; set; }
        public string? CategoryName { get; set; }
        public string? Description { get; set; }

        public List<ProductResponse> Products { get; set; } = new List<ProductResponse>();
    }

    public class ImageModel
    {
        public int? ProductId { get; set; }
        public string? ImagePath { get; set; }

    }
}
