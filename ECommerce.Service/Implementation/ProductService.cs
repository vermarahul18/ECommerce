using AutoMapper;
using ECommerce.Logic;
using ECommerce.Models.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Service.Implementation
{
    public class ProductService:IProductService
    {
        private readonly IProductLogic _productLogic;
        private readonly IMapper _mapper;

        public ProductService(IProductLogic productLogic,IMapper mapper)
        {
            _productLogic = productLogic;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductsDto>> GetProducts()
        {
            var products = await _productLogic.GetProducts();
            // convert product to product dto
            var productsdto = _mapper.Map<IEnumerable<ProductsDto>>(products);
            return productsdto;
        }

        public async Task<ProductsDto> GetProductById(Guid? id)
        {
            if (id == null)
                throw new Exception("Id is required");

            var product =await _productLogic.GetProductById((Guid)id);
            return _mapper.Map<ProductsDto>(product);
        }
    }
}
