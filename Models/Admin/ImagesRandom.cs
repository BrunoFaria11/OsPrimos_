using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce_MVC_Core.Data;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce_MVC_Core.Models.Admin
{
    public class ImagesRandom : BaseEntity
    {
        public int Id { get; set; }
        public string Image_Path { get; set; }
    }

    public class ImagesRandomMap
    {
        public ImagesRandomMap(EntityTypeBuilder<ImagesRandom> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.Property(x => x.Image_Path);
        }
    }
}
