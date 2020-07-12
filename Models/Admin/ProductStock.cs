using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce_MVC_Core.Data;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce_MVC_Core.Models.Admin
{
    public class ProductStock:BaseEntity
    {
        public int ColorId { get; set; }
        public int ProductId { get; set; }
        public int SizeId { get; set; }
        public int InQuantity { get; set; }
        public Colors Colors { get; set; }
        public ProductSize ProductSize { get; set; }

        public Product Product { get; set; }

    }

    public class ProductStockMap
    {
        public ProductStockMap(EntityTypeBuilder<ProductStock> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.Property(x => x.InQuantity);


            entityTypeBuilder.HasOne(x => x.Product).WithMany(x => x.ProductStock)
       .HasForeignKey(x => x.ProductId);

            entityTypeBuilder.HasOne(x => x.ProductSize).WithMany(x => x.ProductStock)
         .HasForeignKey(x => x.SizeId);

            entityTypeBuilder.HasOne(x => x.Colors).WithMany(x => x.ProductStock)
           .HasForeignKey(x => x.ColorId);

        }
    }
}
