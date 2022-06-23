using ECommerce.Context.Entities;
using ECommerce.repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Logic.Implementation
{
    public class ProductLogic:IProductLogic
    {
        private readonly IProductRepository _productRepository;

        public ProductLogic(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var products = await _productRepository.GetAllAsync();
            return products;
        }

        public async Task<Product> GetProductById(Guid id)
        {
            var product = await _productRepository.GetAsync(x=>x.Id==id);
            return product;
        }
    }
}
