using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce_MVC_Core.Data;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce_MVC_Core.Models.Admin
{
    public class Banner: BaseEntity
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public string Image_Path { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }



    }

    public class BannerMap
    {
        public BannerMap(EntityTypeBuilder<Banner> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.Property(x => x.Order);
            entityTypeBuilder.Property(x => x.Image_Path);
            entityTypeBuilder.Property(x => x.Title);
            entityTypeBuilder.Property(x => x.SubTitle);
        }
    }
}
