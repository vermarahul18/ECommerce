using ECommerce.Context.ECommDbContext;
using ECommerce.Context.Entities;
using ECommerce.repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.repository.Repository
{
    public class ProductRepository:BaseRepository<Product>,IProductRepository
    {
        private readonly StoreContext _storeContext;

        public ProductRepository(StoreContext storeContext):base(storeContext)
        {
            _storeContext = storeContext;
        }
    }
}
