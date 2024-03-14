using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SWD_Order.Repo.Entity;
using SWD_Order.Repo.Entity.NewFolder;
using SWD_Order.Repo.Interface;
using SWD_Order.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace SWD_Order.Service.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly WPF_MachineContext _context;

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper,WPF_MachineContext context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }
        public async Task<OrderResponeModel> CreateOrder(OrderModel orderModel)
        {

            var Items = new List<OrderDetail>();
            double? TotalPrice = 0;
            int? TotalQuantity = 0;
            foreach (var option in orderModel.items)
            {
                int productId = option.ProductId;
                
                var Quantity = option.Quantity;
                var product = _unitOfWork.ProductRepository.GetByID(productId);
                if (product == null)
                {
                    throw new Exception("Product not found");
                }
                var orderDetailModel = new OrderDetail
                {

                    ProductId = productId,
                 //   Price = Quantity *product.,
                    CreationDate = DateTime.UtcNow,
                    Quantity = Quantity
                };
                Items.Add(orderDetailModel);
                TotalPrice += orderDetailModel.Price;
                TotalQuantity += orderDetailModel.Quantity;

            }

            var oderModel = new Order
            {
                Total = TotalPrice,
                Quantity = TotalQuantity,
                DateCreated = DateTime.UtcNow,
                OrderDetails = Items
            };
            _unitOfWork.OrderRepository.Insert(oderModel);
            await _unitOfWork.Completed();

            var mapper = _mapper.Map<OrderResponeModel>(oderModel);
            return mapper; 




        }

        public async Task<List<GetOrderSuccess>> getSuccessOrder()
        {
            var order = await _context.OrderDetails.Include(x => x.Product)
                  .ThenInclude(x => x.Images).Where(x => x.Code == "1" && x.ProductId == x.Product.ProductId).ToListAsync();
            var mapper = _mapper.Map<List<GetOrderSuccess>>(order);
            return mapper;
        }

       
    }
}
