using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce_MVC_Core.Code;
using Ecommerce_MVC_Core.Data;
using Microsoft.AspNetCore.Mvc;
using Ecommerce_MVC_Core.Models;
using Ecommerce_MVC_Core.Models.Admin;
using Ecommerce_MVC_Core.Repository;
using Ecommerce_MVC_Core.ViewModel;
using Ecommerce_MVC_Core.ViewModel.Public;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.IO;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Ecommerce_MVC_Core.Controllers
{

    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUsers> _userManager;

        public HomeController(
            UserManager<ApplicationUsers> userManager,
            IUnitOfWork unitOfWork
        )
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            try
            {
                HomePage homePage = new HomePage();
                //homePage.Categories = GetMainCategory();
                homePage.ProductList = new List<ProductListViewModel>();

                var Sections = _unitOfWork.Repository<Sections>().GetAll().Where(x => x.PageId == 1).ToList();
                var ListSections_HTML = _unitOfWork.Repository<Sections_HTML>().GetAll().Where(x => Sections.Select(Y => Y.Id).Contains(x.SectionId)).ToList();

                Dictionary<string, string> DicTags = new Dictionary<string, string>();

                foreach (var item in ListSections_HTML.ToList().Distinct())
                {
                    DicTags.Add(item.Tag_HTML, item.Tag_HTML_Value);

                }

                ViewBag.categories = _unitOfWork.Repository<Category>().GetAllInclude(x => x.Product).Where(x => x.Product.Where(t => t.Active).Any() && x.Active).ToList();
                ViewBag.products = GetProducts(true);

                ViewBag.Tags = DicTags;
                return View(homePage);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<ProductViewModel> GetProducts(bool Active)
        {
            try
            {
                List<ProductViewModel> productList = new List<ProductViewModel>();
                _unitOfWork.Repository<Product>().GetAllInclude(x => x.Category, ps => ps.ProductStock).Where(x => x.Active == Active && x.Category.Active).ToList().ForEach(x =>
                {
                    ProductViewModel product = new ProductViewModel
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Description = x.Description,
                        Price = x.Price,

                        FinalPrice = x.FinalPrice,
                        HaveStock = false,

                        IsNew = false,
                        CategoryId = x.CategoryId,
                        Discount = x.Discount,
                        CategoryName = x.Category.Name,
                        Active = x.Active,
                        AddedDate = x.AddedDate,
                        ModifiedDate = x.ModifiedDate,
                        ImagePath = x.ImagePath,
                        ImagePath2 = x.ImagePath2,
                        ImagePath3 = x.ImagePath3,


                    };
                    if (x.ProductStock.Any(t => t.HaveStock))
                    {
                        product.HaveStock = true;
                    }
                    int totalDias = (DateTime.Now.Date.Subtract(x.AddedDate.Date)).Days;
                    if (totalDias < 15)
                    {
                        product.IsNew = true;
                    }
                    productList.Add(product);
                });
                return productList;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public IActionResult Cart()
        {
            var Sections = _unitOfWork.Repository<Sections>().GetAll().ToList();
            var Country = _unitOfWork.Repository<Country>().GetAll().ToList();

            var ListSections_HTML = _unitOfWork.Repository<Sections_HTML>().GetAll().Where(x => Sections.Select(Y => Y.Id).Contains(x.SectionId)).ToList();

            Dictionary<string, string> DicTags = new Dictionary<string, string>();

            foreach (var item in ListSections_HTML.ToList().Distinct())
            {
                DicTags.Add(item.Tag_HTML, item.Tag_HTML_Value);

            }

            ViewBag.Tags = DicTags;
            ViewBag.Country = Country;

            return View();
        }




        public async Task<IActionResult> ProductDetails(int product)
        {
            try
            {
                var Sections = _unitOfWork.Repository<Sections>().GetAll().ToList();
                var ListSections_HTML = _unitOfWork.Repository<Sections_HTML>().GetAll().Where(x => Sections.Select(Y => Y.Id).Contains(x.SectionId)).ToList();

                Dictionary<string, string> DicTags = new Dictionary<string, string>();

                foreach (var item in ListSections_HTML.ToList().Distinct())
                {
                    DicTags.Add(item.Tag_HTML, item.Tag_HTML_Value);

                }

                ViewBag.Tags = DicTags;

                ProductViewModel pList = new ProductViewModel();

                var Product_ = _unitOfWork.Repository<Product>().GetAllInclude(ps => ps.ProductStock, c => c.Category).FirstOrDefault(x => x.Id == product && x.Category.Active);
                if (Product_ != null)
                {
                    if (Product_.Active)
                    {
                        var ProductStock = _unitOfWork.Repository<ProductStock>().GetAllInclude(x => x.Colors, s => s.ProductSize).Where(x => x.ProductId == product);

                        ViewBag.HaveStock = Product_.ProductStock.Any(t => t.HaveStock);
                        ViewBag.Sizes = GetSizesToProduct(product, ProductStock.ToList()).ToList();
                        ViewBag.Colors = ProductStock.Where(x => x.IsActive && x.HaveStock).Select(x => x.Colors).Distinct().ToList();

                        Product pro = await _unitOfWork.Repository<Product>().GetSingleIncludeAsync(x => x.Id == product, c => c.Category); ;
                        if (pro != null)
                        {
                            pList.Id = pro.Id;
                            pList.Name = pro.Name;
                            pList.Description = pro.Description;
                            pList.Price = pro.Price;
                            pList.ImagePath = pro.ImagePath;
                            pList.ImagePath2 = pro.ImagePath2;
                            pList.ImagePath3 = pro.ImagePath3;
                            pList.CategoryName = pro.Category.Name;
                            pList.CategoryName = pro.Category.Name;

                            pList.Discount = pro.Discount;
                            pList.CategoryId = pro.CategoryId;
                            pList.FinalPrice = (pro.Price - ((pro.Price * pro.Discount) / 100));
                        }

                        List<ProductViewModel> Related_Products_ = new List<ProductViewModel>();

                        //List<Product> Related_Products =  _unitOfWork.Repository<Product>().GetAllInclude(x=>x.ProductStock)?.Where( && x.Active ).ToList();

                        //foreach (var item in Related_Products)
                        //{
                        //    ProductViewModel Related_Product = new ProductViewModel();

                        //    Related_Product.Id = item.Id;
                        //    Related_Product.Name = item.Name;
                        //    Related_Product.Description = item.Description;
                        //    Related_Product.Price = item.Price;
                        //    Related_Product.ImagePath = item.ImagePath;


                        //    Related_Product.CategoryName = pro.Category.Name;
                        //    Related_Product.Discount = item.Discount;
                        //    Related_Product.FinalPrice = (item.Price - ((item.Price * item.Discount) / 100));
                        //    Related_Products_.Add(Related_Product);
                        //}

                        ViewBag.ListProducts = GetProducts(true)?.Where(x => x.CategoryId == pro.CategoryId).ToList();
                        return View(pList);
                    }
                    else
                    {
                        return View("~/Views/Shared/Error.cshtml");
                    }
                }
                else
                {
                    return View("~/Views/Shared/Error.cshtml");
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<ProductSizeListViewModel> GetSizesToProduct(int productId, List<ProductStock> ProductStock)
        {
            try
            {
                List<ProductSizeListViewModel> ProductSizeList = new List<ProductSizeListViewModel>();
                _unitOfWork.Repository<ProductSize>().GetAll().ToList().ForEach(x =>
                {
                    var Available_aux = true;
                    if (ProductStock.Any(X => X.SizeId == x.Id))
                    {
                        if (ProductStock.Any(X => X.SizeId == x.Id && X.HaveStock && X.IsActive))
                        {
                            Available_aux = false;
                        }

                        ProductSizeListViewModel ProductSize = new ProductSizeListViewModel
                        {
                            Id = x.Id,
                            Size = x.Size,
                            Available_ = Available_aux,
                        };
                        ProductSizeList.Add(ProductSize);
                    }


                });
                return ProductSizeList;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ColorsViewModel> GetAvailableColors(int productId, int size)
        {
            try
            {
                List<ColorsViewModel> ProductColorist = new List<ColorsViewModel>();
                var ProductStock = _unitOfWork.Repository<ProductStock>().GetAllInclude(y => y.Colors, s => s.ProductSize).Where(p => p.ProductId == productId);

                ProductStock.Where(x => x.IsActive && x.HaveStock).Select(x => x.Colors).Distinct().ToList().ForEach(x =>
                {
                    var Available_aux = true;

                    if (ProductStock.Any(ps => ps.SizeId == size && ps.HaveStock && ps.IsActive && ps.ColorId == x.Id))
                    {
                        Available_aux = false;
                    }
                    ColorsViewModel ProductColor = new ColorsViewModel
                    {
                        Id = x.Id,
                        Color = x.Color,
                        Available_ = Available_aux,
                    };
                    ProductColorist.Add(ProductColor);
                });
                return ProductColorist;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int GetAvailabilityToCount(int productId, int size, int Quantity, int color)
        {
            try
            {
                var ProductStock = _unitOfWork.Repository<ProductStock>().Find(p => p.ProductId == productId && p.SizeId == size && p.ColorId == color);
                var Product = _unitOfWork.Repository<Product>().Find(p => p.Id == productId);

                if (ProductStock == null || !ProductStock.IsActive || !Product.Active)
                {
                    return 0;

                    //TODO: FATAL ERROR
                    //return View("~/Views/Shared/Error.cshtml");
                }
                else
                {
                    var AvailabilityQuantity = ProductStock.InQuantity - ProductStock.MinQuantity;


                    if (Quantity <= AvailabilityQuantity)
                    {
                        return 0;
                    }
                    else
                    {
                        return AvailabilityQuantity;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }



        public IActionResult Category(int cat)
        {
            try
            {
                var Sections = _unitOfWork.Repository<Sections>().GetAll().ToList();
                var ListSections_HTML = _unitOfWork.Repository<Sections_HTML>().GetAll().Where(x => Sections.Select(Y => Y.Id).Contains(x.SectionId)).ToList();

                Dictionary<string, string> DicTags = new Dictionary<string, string>();

                foreach (var item in ListSections_HTML.ToList().Distinct())
                {
                    DicTags.Add(item.Tag_HTML, item.Tag_HTML_Value);

                }

                ViewBag.Tags = DicTags;

                var catAux = _unitOfWork.Repository<Category>().GetAllInclude(x => x.Product).Where(x => x.Product.Where(t => t.Active).Any()).FirstOrDefault(x => x.Id == cat);
                if (catAux == null)
                {
                    return View("~/Views/Shared/Error.cshtml");
                }

                List<CategoryViewModel> AllCategories = new List<CategoryViewModel>();

                var All_Categories = _unitOfWork.Repository<Category>().GetAllInclude(x => x.Product).Where(x => x.Product.Where(t => t.Active).Any());
                foreach (var item in All_Categories)
                {
                    CategoryViewModel cat_ = new CategoryViewModel();
                    cat_.Id = item.Id;
                    cat_.Image_Path = item.Image_Path;
                    cat_.Name = item.Name;
                    AllCategories.Add(cat_);
                }

                CategoryViewModel CategorySelect = new CategoryViewModel();
                CategorySelect.Id = catAux.Id;
                CategorySelect.Image_Path = catAux.Image_Path;
                CategorySelect.Name = catAux.Name;


                ViewBag.AllCategories = AllCategories;
                //ViewBag.MostExpensive = _unitOfWork.Repository<Product>().GetAll().OrderByDescending(x=>x.Price).FirstOrDefault().Price;
                //ViewBag.Colors = _unitOfWork.Repository<Colors>().GetAll().ToList();
                ViewBag.ProductsOffCat = GetProducts(true).Where(x => x.CategoryId == cat).ToList();
                ViewBag.ProductsOffCatCount = GetProducts(true).Where(x => x.CategoryId == cat).Count();



                return View(CategorySelect);

            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}
