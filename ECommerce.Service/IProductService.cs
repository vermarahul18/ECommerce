using ECommerce.Models.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Service
{
    public interface IProductService
    {
        Task<IEnumerable<ProductsDto>> GetProducts();
        Task<ProductsDto> GetProductById(Guid? id);
    }
}
