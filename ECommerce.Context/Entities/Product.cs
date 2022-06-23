using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ECommerce.Context.Entities
{
    public class Product : BaseEntity<Guid>
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
