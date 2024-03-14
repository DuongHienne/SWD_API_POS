using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SWD_Order.Repo.Entity;
using SWD_Order.Repo.Interface;
using SWD_Order.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD_Order.Service.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly WPF_MachineContext _context;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper, WPF_MachineContext context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }

        public void AddProduct(AddProduct addProduct)
        {
            var mapper = _mapper.Map<Product>(addProduct);
            _context.Products.Add(mapper);
            _context.SaveChanges();

            int productID = mapper.ProductId;
            foreach(var product in addProduct.addImages)
            {
                var image = _context.Images.Any(x => x.ProductId == productID && x.ImagePath == product.ImagePath);
                if(image == null)
                {
                    var images = new Image()
                    {
                        ProductId = productID,
                        ImagePath = product.ImagePath
                    };
                    _context.Images.Add(images);
                }
            }
            _context.SaveChanges();
               
        }

        public async Task<bool> DeleteProduct(int productID)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.ProductId == productID);
            if (product != null)
            {

                product.Status = true;
                _context.SaveChanges();
                return true;
                
            }
            else { return false; }
           
        }

    
        public async Task<List<ProductResponse>> GetListProduct()
        {
            
            var products = await _unitOfWork.ProductRepository.Get(filter:x => x.Status == false, includeProperties: "Images");

            var result = _mapper.Map<List<ProductResponse>>(products);
            return result;
        }

        public async Task<ModelsPro> getProductId(int productId)
        {
            var product = await _unitOfWork.ProductRepository.GetByID(productId, filter: x => x.Status == false, includeExpression: x => x.Images);

            // Console.WriteLine($"Retrieved product: {product}");
            var productModel = _mapper.Map<ModelsPro>(product);
            ///Console.WriteLine($"Mapped productModel: {productModel}");
            return productModel;
            //var product = await _context.Products.Include(x => x.Images).FirstOrDefaultAsync(x => x.ProductId == productId);
            //var mapper = _mapper.Map<ModelsPro>(product);
            //return mapper;
        }

        public async Task<bool> UpdateProduct(UpdateProduct update,int productID)
        {
            var product = await _context.Products.FindAsync(productID);
            if(product != null)
            {
                var delete = _context.Images.Where(x => x.ProductId == productID);
               
                _mapper.Map(update, product);
              
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
