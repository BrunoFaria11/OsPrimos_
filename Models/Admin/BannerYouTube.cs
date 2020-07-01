using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce_MVC_Core.Data;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce_MVC_Core.Models.Admin
{
    public class BannerYouTube : BaseEntity
    {
        public int Id { get; set; }
        public string Image_Path { get; set; }
        public string LinkVideo { get; set; }
    }

    public class BannerYouTubeMap
    {
        public BannerYouTubeMap(EntityTypeBuilder<BannerYouTube> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.Property(x => x.Image_Path);
            entityTypeBuilder.Property(x => x.LinkVideo);
        }
    }
}
