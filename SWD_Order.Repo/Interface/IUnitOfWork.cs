using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD_Order.Repo.Interface
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }
        IOrderRepository OrderRepository { get; }
        //IProductAddRepository ProductAddRepository { get; }
        ICategoryRepository CategoryRepository { get; }

        IImageRepository ImageRepository { get; }
        Task<int> Completed();
    }
}
