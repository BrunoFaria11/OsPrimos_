using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce_MVC_Core.Data;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce_MVC_Core.Models.Admin
{
    public class ProductSize : BaseEntity
    {
        public string Size { get; set; }

        public ICollection<ProductStock> ProductStock { get; set; }
    }

    public class ProductSizeMap
    {
        public ProductSizeMap(EntityTypeBuilder<ProductSize> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.Property(x => x.Size).HasMaxLength(100);

        }
    }
}
