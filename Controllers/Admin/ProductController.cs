using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce_MVC_Core.Data;
using Ecommerce_MVC_Core.Models.Admin;
using Ecommerce_MVC_Core.Repository;
using Ecommerce_MVC_Core.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ecommerce_MVC_Core.Controllers.Admin
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHostingEnvironment _hosingEnv;
        public ProductController(
            IUnitOfWork unitOfWork,
            IHostingEnvironment hosingEnv
        )
        {
            _hosingEnv = hosingEnv;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index(string search)
        {  
            //Get List of All Products
            var allProducts =  _unitOfWork.Repository<Product>().GetAll();
                       
            return View(allProducts);
        }

         public IActionResult GetById(int id)
        {  
            
            //Get Product By ID
            var productByID =  _unitOfWork.Repository<Product>().GetById(id);
            
            return View(productByID);
        }

        public IActionResult AddProduct(ProductViewModel model)
        {  
            
            Product product = new Product
                {
                    Name = "Pila",
                    Description = "Pila",
                    Price = 200,
                    AddedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                };

            //Insert product (need to pass object with data received)
            var addProduct = _unitOfWork.Repository<Product>().Insert(product);

            return RedirectToAction(nameof(Index));
        }


        public IActionResult EditProduct(ProductViewModel model)
        {  

            //Update product
            Product product =  _unitOfWork.Repository<Product>().GetById(1);

            product.Name = model.Name;
            product.Description = model.Description;
            product.Price = model.Price;
            product.AddedDate = DateTime.Now;
            product.ModifiedDate = DateTime.Now;
            
            _unitOfWork.Repository<Product>().Update(product);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult DeleteProduct(int id)
        {  
            
            //Delete product
            var productByID =  _unitOfWork.Repository<Product>().GetById(id);
            _unitOfWork.Repository<Product>().Delete(productByID);

            return RedirectToAction(nameof(Index));
        }

        // [HttpGet]
        // public async Task<IActionResult> AddEditProduct(int id)
        // {
        //     ProductViewModel model = new ProductViewModel();
        //     model.BrandList = _unitOfWork.Repository<Brand>().GetAll().Select(x => new SelectListItem
        //     {
        //         Text = x.Name,
        //         Value = x.Id.ToString()
        //     }).ToList();

        //     model.CategoryList = _unitOfWork.Repository<Category>().GetAll().Select(x => new SelectListItem
        //     {
        //         Text = x.Name,
        //         Value = x.Id.ToString()
        //     }).ToList();

        //     model.UnitList = _unitOfWork.Repository<Unit>().GetAll().Select(x => new SelectListItem
        //     {
        //         Text = x.Name,
        //         Value = x.Id.ToString()
        //     }).ToList();

        //     if (id > 0)
        //     {
        //         Product product =await _unitOfWork.Repository<Product>().GetByIdAsync(id);
        //         model.Name = product.Name;
        //         // model.Code = product.Code;
        //         // model.Tag = product.Tag;
        //         // model.CategoryId = product.CategoryId;
        //         // model.BrandId = product.BrandId;
        //         // model.UnitId = product.UnitId;
        //         model.Description = product.Description;
        //         model.Price = product.Price;
        //         // model.Discount = product.Discount;
        //     }

        //     return PartialView("_AddEditProduct", model);
        // }

        // [HttpPost]
        // public async Task<IActionResult> AddEditProduct(int id, ProductViewModel model)
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         ModelState.AddModelError("","Something Wrong");
        //         return View("_AddEditProduct", model);
        //     }
        //     if (id>0)
        //     {
        //         Product product = await _unitOfWork.Repository<Product>().GetByIdAsync(id);
        //         if (product!=null)
        //         {
        //             product.Name = model.Name;
        //             // product.Code = model.Code;
        //             // product.Tag = model.Tag;
        //             // product.CategoryId = model.CategoryId;
        //             // product.BrandId = model.BrandId;
        //             // product.UnitId = model.UnitId;
        //             product.Description = model.Description;
        //             product.Price = model.Price;
        //             // product.Discount = model.Discount;

        //             product.ModifiedDate = DateTime.Now;
        //             await _unitOfWork.Repository<Product>().UpdateAsync(product);
        //         }
                
        //     }
        //     else
        //     {
        //         Product product = new Product
        //         {
        //             Name = model.Name,
        //             // Code = model.Code,
        //             // Tag = model.Tag,
        //             // CategoryId = model.CategoryId,
        //             // BrandId = model.BrandId,
        //             // UnitId = model.UnitId,
        //             Description = model.Description,
        //             Price = model.Price,
        //             // Discount = model.Discount,
        //             AddedDate = DateTime.Now,
        //             ModifiedDate = DateTime.Now
        //         };
        //         await _unitOfWork.Repository<Product>().InsertAsync(product);
        //         if (model.Images.Count()>0)
        //         {
        //             await UploadProductImages(model.Images, product.Name, product.Id);
        //         }

        //         if (model.Manual!=null)
        //         {
        //             await UploadProductManual(model.Manual,product.Id,product.Name);
        //         }
        //     }
        //     return RedirectToAction(nameof(Index));
        // }


        // private async Task UploadProductImages(IList<IFormFile> list,string productName,int productId)
        // {
        //     foreach (var file in list)
        //     {
        //         if (file != null && (file.ContentType == "image/png" || file.ContentType == "image/jpg" || file.ContentType == "image/jpeg"))
        //         {
        //             var productImage=new ProductImage
        //             {
        //                 AddedDate = DateTime.Now,
        //                 ModifiedDate = DateTime.Now,
        //                 ProductId = productId,
        //                 Title = productName
        //             };
        //             var uploads = Path.Combine(_hosingEnv.WebRootPath, "uploads/ProductImages");
        //             var fileName = Path.Combine(uploads, productName + "_" + Guid.NewGuid().ToString().Substring(0, Guid.NewGuid().ToString().IndexOf("-", StringComparison.Ordinal)) + ".png");
        //             //Model
        //             productImage.ImagePath = Path.GetFileName(fileName);
                    
        //             await _unitOfWork.Repository<ProductImage>().InsertAsync(productImage);

        //             using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
        //             {
        //                 await file.CopyToAsync(fileStream);
        //             }
        //         }
        //     }
        // }

        // public async Task UploadProductManual(IFormFile file,int productId,string productName)
        // {
        //     var pManual=new ProductManual
        //     {
        //         AddedDate = DateTime.Now,
        //         ModifiedDate = DateTime.Now,
        //         ProductId = productId
        //     };

        //     if (file != null && file.ContentType == "application/pdf")
        //     {

        //         var uploads = Path.Combine(_hosingEnv.WebRootPath, "uploads/ProductManuals");
        //         var fileName = Path.Combine(uploads, productName + "_" + productId + ".pdf");
        //         pManual.ManualName = Path.GetFileName(fileName);
        //         await _unitOfWork.Repository<ProductManual>().InsertAsync(pManual);
        //         using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
        //         {
        //             await file.CopyToAsync(fileStream);
        //         }

        //         //await model.ImageFile.CopyToAsync(new FileStream(fileName,FileMode.Create));
        //     }
        // }

        // [HttpGet]
        // public async Task<IActionResult> DeleteProduct(int id)
        // {
        //     Product product = await _unitOfWork.Repository<Product>().GetByIdAsync(id);

        //     return PartialView("_DeleteProduct", product?.Name);
        // }

        // [HttpPost]
        // public async Task<IActionResult> DeleteProduct(int id, IFormCollection form)
        // {
        //     Product product = await _unitOfWork.Repository<Product>().GetByIdAsync(id);
        //     if (product != null)
        //     {
        //         await _unitOfWork.Repository<Product>().DeleteAsync(product);
        //     }
        //     return RedirectToAction(nameof(Index));
        // }

        // public IActionResult ListImageView(int id)
        // {
        //     ProductImageListByProduct productImage=new ProductImageListByProduct();
        //     //productImage.ProuctImages = GetProdutcsImages(id);
        //     productImage.Path = productImage.ProuctImages.Max(x => x.ImagePath);

        //     //return PartialView("_ShowImageByProduct", productImage);
        //     return View();
        // }

        // public PartialViewResult GetProdutcsImages(int id)
        // {
        //     List<ProductImageListViewModel> productImageList = new List<ProductImageListViewModel>();
        //     ViewBag.productName =  _unitOfWork.Repository<Product>().GetById(id).Name;
        //      _unitOfWork.Repository<ProductImage>().GetAll().Where(x => x.ProductId == id).ToList().ForEach(x =>
        //     {
        //         ProductImageListViewModel pImage = new ProductImageListViewModel
        //         {
        //             Id = x.Id,
        //             ProductId = x.ProductId,
        //             ImagePath = x.ImagePath,
        //             Title = x.Title,
        //             ProductName =  _unitOfWork.Repository<Product>().GetById(id).Name
        //         };
        //         productImageList.Add(pImage);
        //     });
        //     return PartialView("_ShowImageByProduct", productImageList);
            
        // }
    }
}