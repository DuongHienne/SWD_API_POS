using Microsoft.Extensions.Logging;
using SWD_Order.Repo.Entity;
using SWD_Order.Repo.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD_Order.Repo.Repository
{
    public class OrderRepository :  GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(WPF_MachineContext context) : base(context)
        {

        }

        
    }
}
