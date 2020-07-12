using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce_MVC_Core.Data;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce_MVC_Core.Models.Admin
{
    public class Colors : BaseEntity
    {
        public string Color { get; set; }

        public ICollection<ProductStock> ProductStock { get; set; }
    }

    public class ColorsMap
    {
        public ColorsMap(EntityTypeBuilder<Colors> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.Property(x => x.Color).HasMaxLength(100);

        }
    }
}
