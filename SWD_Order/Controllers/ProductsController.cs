using Microsoft.AspNetCore.Mvc;
using SWD_Order.Repo.Entity;
using SWD_Order.Repo.Interface;
using SWD_Order.Service.Models;
using SWD_Order.Service.OrderService;
using SWD_Order.Service.ProductService;

namespace SWD_Order.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly WPF_MachineContext _DataContext;
        private readonly IProductService _productService;
        public ProductsController(IUnitOfWork unitOfWork, WPF_MachineContext context,
            IProductService productService)
        {
            _unitOfWork = unitOfWork;
            _DataContext = context;
            _productService = productService;
        }

        [HttpGet("ProductList")]
        public async Task<IActionResult> getProduct()
        {
            var user = await _productService.GetListProduct();
            return Ok(user);

        }
        [HttpGet("getProductID")]
        public async Task<IActionResult> getProductID(int productId)
        {
            var product = await _productService.getProductId(productId);
            return Ok(product);
        }
        [HttpPost("deleteProduct")]
        public async Task<IActionResult> deleteProduct(int productID)
        {
            var product = await _productService.DeleteProduct(productID);
            return Ok(product);
        }
        [HttpPost("UpdateProduct")]
        public async Task<IActionResult> updateproduct(UpdateProduct update, int productId)
        {
            var product =await _productService.UpdateProduct(update, productId);
            return Ok(product);
        }
        [HttpPost("addProduct")]
        public async Task<IActionResult> addProduct(AddProduct add)
        {
            _productService.AddProduct(add);
            return Ok("success");
        }
    }
}
