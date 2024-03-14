using Microsoft.Extensions.Logging;
using SWD_Order.Repo.Entity;
using SWD_Order.Repo.Entity.NewFolder;
using SWD_Order.Repo.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD_Order.Repo.Repository
{
    public class ProductAddRepository :  GenericRepository<ProductAdd>, IProductAddRepository
    {
        public ProductAddRepository(WPF_MachineContext context) : base(context)
        {
        }

        
    }
}
