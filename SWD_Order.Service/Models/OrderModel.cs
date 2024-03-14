using SWD_Order.Repo.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD_Order.Service.Models
{
    public class OrderModel
    {
        public List<OderDetailModel> items { get; set; } = new List<OderDetailModel>();

    }

    public class OrderModelA
    {
        public List<OderDetailModel> items { get; set; } = new List<OderDetailModel>();
    }

    public class OderDetailModel { 
        public int ProductId { get; set; }
        
        public int? Quantity { get; set; }
    }

    public class OrderResponeModel
    {
        public int OrderId { get; set; }
        public float? Total { get; set; }
        public int? Quantity { get; set; }
        public DateTime? DateCreated { get; set; }

        public List<OrderDetailRespone> Items { get; set; } = new List<OrderDetailRespone>();
    }

    public class OrderDetailRespone
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public float? Price { get; set; }
        public string? Status { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? Quantity { get; set; }
        public string? Code { get; set; }
    }


    public class OrderResponeForGetAll
    {
        public int OrderId { get; set; }
        public float? Total { get; set; }
        public int? Quantity { get; set; }
        public DateTime? DateCreated { get; set; }

        public List<OrderDetailResponeForGetAll> Items { get; set; } = new List<OrderDetailResponeForGetAll>();
    }

    public class OrderDetailResponeForGetAll
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string? ImagePath { get; set; }
        public float? Price { get; set; }
        public string? Status { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? Quantity { get; set; }
        public string? Code { get; set; }
    }


}

