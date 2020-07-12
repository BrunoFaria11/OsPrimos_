using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce_MVC_Core.ViewModel.Public;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ecommerce_MVC_Core.ViewModel
{
    public class ProductSizeViewModel
    {
        public ProductSizeViewModel()
        {
        
        }
        public int Id { get; set; }

        public string Size { get; set; }


        //public ICollection<ProductColors> ProductColors { get; set; }
    }

  
}
