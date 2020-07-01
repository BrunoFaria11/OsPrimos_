using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ecommerce_MVC_Core.ViewModel
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Image_Path { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
    }

    public class CategoryListViewModel
    {
        public int Id { get; set; }
        public string Image_Path { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
    }
}
