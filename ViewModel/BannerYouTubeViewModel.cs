using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce_MVC_Core.Data;

namespace Ecommerce_MVC_Core.ViewModel
{
    public class BannerYouTubeViewModel : BaseEntity
    {
        [Required]

        public int Id { get; set; }
        public string Image_Path { get; set; }
        public string LinkVideo { get; set; }
    }

    public class BannerYouTubeListViewModel
    {
        public int Id { get; set; }
        public string Image_Path { get; set; }
        public string LinkVideo { get; set; }
    }

    
}
