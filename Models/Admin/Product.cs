using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce_MVC_Core.Data;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce_MVC_Core.Models.Admin
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }        
        public string Description { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public string ImagePath { get; set; }
        public string ImagePath2 { get; set; }
        public string ImagePath3 { get; set; }
        public bool Active { get; set; }
        public bool HaveStock { get; set; }
        public int CategoryId { get; set; }
        public double FinalPrice { get; set; }

        public Category Category { get; set; }

        public ICollection<ProductStock> ProductStock { get; set; }

    }


    public class ProductMap
    {
        public ProductMap(EntityTypeBuilder<Product> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.Property(x => x.Name).HasMaxLength(100);
            entityTypeBuilder.Property(x => x.Description);
            entityTypeBuilder.Property(x => x.Price);

            entityTypeBuilder.Property(x => x.Discount);
            entityTypeBuilder.Property(x => x.ImagePath);
            entityTypeBuilder.Property(x => x.ImagePath2);
            entityTypeBuilder.Property(x => x.ImagePath3);
            entityTypeBuilder.Property(x => x.Active);

            entityTypeBuilder.HasOne(x => x.Category).WithMany(x => x.Product).HasForeignKey(x => x.CategoryId);


        }
    }
}
