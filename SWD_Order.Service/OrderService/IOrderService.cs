using SWD_Order.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD_Order.Service.OrderService
{
    public interface IOrderService
    {
        public Task<OrderResponeModel> CreateOrder(OrderModel orderModel);
        public Task<List<GetOrderSuccess>> getSuccessOrder();
    }
}
