using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SWD_Order.Repo.Entity;
using SWD_Order.Repo.Entity.NewFolder;
using SWD_Order.Repo.Interface;
using SWD_Order.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        public async Task<List<GetOrderSuccess>> getSuccessOrder(string imageName)
        {

            var query = from o in _context.Orders
                        join od in _context.OrderDetails on o.OrderId equals od.OrderId
                        join p in _context.Products on od.ProductId equals p.ProductId
                        where od.Code == "1"
                        select new { od, p, o };

            // Tạo URL công khai của tệp từ Firebase Storage


            // Tạo URL trực tiếp đến tệp ảnh trên Firebase Storage
            string storageUrl = "https://firebasestorage.googleapis.com/v0/b/posscan-55171.appspot.com/o/imgage%2FIMG_20240227_083154.jpg?alt=media&token=610906da-cc08-4db7-bdad-809ddb8ab0ba";


            // Tạo yêu cầu HTTP để tải xuống tệp
            //WebClient webClient = new WebClient();
            //byte[] imageData = webClient.DownloadData(storageUrl);

            // Trả về tệp dưới dạng phản hồi



            var result = await query.Select(x => new GetOrderSuccess()
            {
                OrderId = x.o.OrderId,
                TotalQuantity = x.o.Quantity,
                TotalPrice = x.o.Total,
                orderDetail = 
                    new ProductDetail()
                    {
                    ProductId = x.p.ProductId,
                    Price = x.p.Price,
                    ProductName = x.p.ProductName,
                    Quantity = x.od.Quantity,
                    Image = storageUrl

                    }
              
            }).ToListAsync();

            var order = result.GroupBy(x => x.OrderId)
                           .Select(group => group.First())
                           .ToList();

            return order;
        }

        public async Task<GetOrderDetail> getOrderDetail(int orderId)
        {
            var query = from od in _context.OrderDetails
                        join p in _context.Products on od.ProductId equals p.ProductId
                        join o in _context.Orders on od.OrderId equals o.OrderId
                        join pay in _context.Payments on o.PaymentId equals pay.PaymentId
                        where o.OrderId == orderId
                        select new { od, p, o, pay };

            var orderDetail = await query.Select(x => new GetOrderDetail()
            {
                OrderId = orderId,
                TotalPrice = x.o.Total,
                TotalQuantity = x.o.Quantity,
                CreationDate = x.o.DateCreated,
                Method = x.pay.Method,
                Product = new List<ProductDetail>()
                {
                    new ProductDetail()
                    {
                        ProductId = x.p.ProductId,
                        ProductName = x.p.ProductName,
                        Price = x.p.Price,
                        Quantity = x.od.Quantity
                    }
                }
            }).FirstOrDefaultAsync();

            return orderDetail;

        }



    }
}
