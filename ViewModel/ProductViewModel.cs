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
    public class ProductViewModel
    {
        public ProductViewModel()
        {
            //Images = new List<IFormFile>();
            //CategoryList = new List<SelectListItem>();
            //BrandList = new List<SelectListItem>();
            //UnitList = new List<SelectListItem>();
        }
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public int Quantity { get; set; }
        public string ImagePath { get; set; }
        public string ImagePath2 { get; set; }
        public string ImagePath3 { get; set; }
        public bool Active { get; set; }
       public int CategoryId { get; set; }

        //public ICollection<ProductColors> ProductColors { get; set; }
    }

    public class ProductListViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public int Quantity { get; set; }
        public string ImagePath { get; set; }
        public string ImagePath2 { get; set; }
        public string ImagePath3 { get; set; }
        public bool Active { get; set; }
    }

    //public class ProductImageListByProduct
    //{
    //    public string Path { get; set; }
    //    public List<ProductImageListViewModel> ProuctImages { get; set; }
    //}
}
