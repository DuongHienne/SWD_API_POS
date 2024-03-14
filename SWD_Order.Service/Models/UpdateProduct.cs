using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD_Order.Service.Models
{
    public class UpdateProduct
    {
        public string? ProductName { get; set; }
        public double? Price { get; set; }
        public int? Quantity { get; set; }
     //   public string? Description { get; set; }
      //  public List<ImageUpdate> images { get; set; } = new List<ImageUpdate>();
    }
    public class ImageUpdate
    {
       
        public string? ImagePath { get; set; }
    }
}
