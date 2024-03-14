using SWD_Order.Repo.Entity;
using SWD_Order.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD_Order.Service.ProductService
{
    public interface IProductService
    {
        public Task<List<ProductResponse>> GetListProduct();
        public Task<ModelsPro> getProductId(int ProductId);
        public Task<bool> DeleteProduct(int productID);
        public Task<bool> UpdateProduct(UpdateProduct update, int productID);
        public void AddProduct(AddProduct addProduct);
    }
}
