using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce_MVC_Core.Data;

namespace Ecommerce_MVC_Core.ViewModel
{
    public class BrandViewModel : BaseEntity
    {
        [Required]
        public int Id { get; set; }
        public int Order { get; set; }
        public string Image_Path { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
    }

    public class BrandListViewModel
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public string Image_Path { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
    }

    
}
