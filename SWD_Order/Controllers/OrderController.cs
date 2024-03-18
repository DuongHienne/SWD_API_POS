using Microsoft.AspNetCore.Mvc;
using SWD_Order.Repo.Entity;
using SWD_Order.Repo.Entity.NewFolder;
using SWD_Order.Repo.Interface;
using SWD_Order.Repo.Repository;
using SWD_Order.Service.Models;
using SWD_Order.Service.OrderService;
using SWD_Order.Service.ProductService;

namespace SWD_Order.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly WPF_MachineContext _DataContext;
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;
        public OrderController(IUnitOfWork unitOfWork, WPF_MachineContext context, 
            IOrderService orderService, IProductService productService)
        {
            _unitOfWork = unitOfWork;
            _DataContext = context;
            _orderService = orderService;
            _productService = productService;
        }

        [HttpGet("Order_Successfully")]
        public async Task<IActionResult> OrderSuccess()
        {
            var user = await _orderService.getSuccessOrder("IMG_20240227_083154.jpg");
            return Ok(user);

        }

        [HttpGet("Order_Detail")]
        public async Task<IActionResult> OrderDetail(int orderId)
        {
            var user = await _orderService.getOrderDetail(orderId);
            return Ok(user);

        }

        [HttpPost("CreateOrder")]
        public async Task<IActionResult> CreateOrder(OrderModel model)
        {
            var order = await _orderService.CreateOrder(model);
            return Ok(order);
        }
    }
}
