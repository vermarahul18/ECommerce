using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Context.Entities
{
    public class BaseEntity<T>
    {
        public T Id { get; set; }
        public DateTime SysCreateDateTimeUtc { get; set; }
        public Guid? CreatedBy { get; set; }
    }
}
