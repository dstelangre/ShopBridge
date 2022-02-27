using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopbridge_base.ViewModels
{
    public class ProductVM
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

    }
}
