using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce_MVC_Core.Data;

namespace Ecommerce_MVC_Core.ViewModel
{
    public class ProductStockViewModel:BaseEntity
    {
        public int id { get; set; }

        public int ColorId { get; set; }
        public int ProductId { get; set; }
        public int SizeId { get; set; }
        public int InQuantity { get; set; }
        public ColorsViewModel Colors { get; set; }
        public ProductSizeViewModel ProductSize { get; set; }

        public ProductViewModel Product { get; set; }
    }

    public class ProductStockListViewModel : BaseEntity
    {
        public int id { get; set; }
        public string ProductName { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }

        public int InQuantity { get; set; }
    }
}
