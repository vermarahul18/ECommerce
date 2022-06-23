using ECommerce.Context.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Logic
{
    public interface IProductLogic
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProductById(Guid id);
    }
}
