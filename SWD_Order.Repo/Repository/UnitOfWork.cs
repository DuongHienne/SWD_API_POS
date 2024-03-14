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
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WPF_MachineContext _context;
        
        public IProductRepository ProductRepository { get; private set; }
        public IOrderRepository OrderRepository { get; private set; }
        public ICategoryRepository CategoryRepository { get; private set; }

        public IImageRepository ImageRepository { get; private set; }
        //public IProductAddRepository ProductAddRepository { get; private set; }

        public UnitOfWork(WPF_MachineContext context)
        {
            _context = context;
          
            ProductRepository = new ProductRepository(_context); 
            OrderRepository = new OrderRepository(_context);
            CategoryRepository = new CategoryRepository(_context);
            ImageRepository = new ImageRepository(_context);
            //ProductAddRepository = new ProductAddRepository(_context);
        }

        public Task<int> Completed()
        {
            return _context.SaveChangesAsync();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

