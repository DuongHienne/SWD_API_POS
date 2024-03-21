using SWD_Order.Repo.Entity;
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
        public Task<List<GetOrderSuccess>> getSuccessOrder(string imageName);

        public Task<GetOrderDetail> getOrderDetail(int id);

        public Task<List<Order>> getAllOrder();

        public Task<double> getTotalRevenue();

        public Task<double> getTotalMonthRevenue(DateTime startDate, DateTime endDate);

        //public Task<GetOrderSuccess> getRevenueWeek();
    }
}
