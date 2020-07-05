using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce_MVC_Core.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ecommerce_MVC_Core.ViewModel
{
    public class BannerViewModel : BaseEntity
    {
        [Required]

        public int Id { get; set; }
        public int Order { get; set; }
        public string Image_Path { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }


        public List<SelectListItem> Banners { get; set; }
        public List<CategoryViewModel> BannersMenus { get; set; }
    }

    public class BannerListViewModel
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public string Image_Path { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }

    }


}
