using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce_MVC_Core.Data;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Ecommerce_MVC_Core.Models.Admin
{
    public class Category:BaseEntity
    {
        public string Image_Path { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public ICollection<Product> Product { get; set; }

    }

    public class CategoryMap
    {
        public CategoryMap(EntityTypeBuilder<Category> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.Property(x => x.Image_Path);
            entityTypeBuilder.Property(x => x.Name);
            entityTypeBuilder.Property(x => x.Active);
        }
    }
}
