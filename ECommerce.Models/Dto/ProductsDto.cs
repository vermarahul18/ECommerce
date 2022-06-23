using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Models.Dto
{
    public class ProductsDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
