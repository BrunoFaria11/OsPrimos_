using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Ecommerce_MVC_Core.Data;
using Ecommerce_MVC_Core.Models.Admin;
using Ecommerce_MVC_Core.Repository;
using Ecommerce_MVC_Core.ViewModel;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = "Admin")]
        public IActionResult Index(bool Active = true)
        {
            try
            {
                //Get List of All Products
                ViewBag.Active = Active;
                ViewBag.AnyCat = _unitOfWork.Repository<Category>().Any(x=>x.Id > 0 );

                return View();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public IActionResult GetById(int id)
        {
            try
            {
                var productByID = _unitOfWork.Repository<Product>().GetById(id);

                return View(productByID);
            }
            catch (Exception)
            {
                throw;
            }     
        }

        [HttpGet]
        public IActionResult AddEditProduct(int id)
        {
            try
            {
                ProductViewModel product = new ProductViewModel();
                if (id > 0)
                {

                    var productByID = _unitOfWork.Repository<Product>().GetById(id);
                    product.Id = productByID.Id;
                    product.Name = productByID.Name;
                    product.Description = productByID.Description;
                    product.Price = productByID.Price;
                    product.CategoryId = productByID.CategoryId;
                    product.Discount = productByID.Discount;
                    product.Active = productByID.Active;

                    product.ImagePath = productByID.ImagePath;
                    product.ImagePath2 = productByID.ImagePath2;
                    product.ImagePath3 = productByID.ImagePath3;
                }

                return PartialView("~/Views/Product/_AddEditProduct.cshtml", product);

            }
            catch (Exception)
            {
                throw;
            }
        }


        public ActionResult LoadData(bool Active)
        {
            try
            {
                //Creating instance of DatabaseContext class  
                var draw_ = new Microsoft.Extensions.Primitives.StringValues();
                var start_ = new Microsoft.Extensions.Primitives.StringValues();
                var length_ = new Microsoft.Extensions.Primitives.StringValues();
                var aux = new Microsoft.Extensions.Primitives.StringValues();
                var sortcolumndir_ = new Microsoft.Extensions.Primitives.StringValues();
                var searchvalue_ = new Microsoft.Extensions.Primitives.StringValues();
                var sortcolumn_ = new Microsoft.Extensions.Primitives.StringValues();


                var draw = Request.Form.TryGetValue("draw", out draw_);
                var start = Request.Form.TryGetValue("start", out start_);
                var length = Request.Form.TryGetValue("length", out length_);
                var aux_ = Request.Form.TryGetValue("order[0][column]", out aux);
                var sortcolumn = Request.Form.TryGetValue("columns[" + aux_ + "][name]", out sortcolumn_);
                var sortcolumndir = Request.Form.TryGetValue("order[0][dir]", out sortcolumndir_);
                var searchvalue = Request.Form.TryGetValue("search[value]", out searchvalue_);


                //Paging Size (10,20,50,100)    
                int pageSize = length != null ? Convert.ToInt32(length_) : 0;
                int skip = start != null ? Convert.ToInt32(start_) : 0;
                int recordsTotal = 0;

                // Getting all Customer data    
                var ProductsStockList = GetProducts(Active).ToList();

                //Sorting    
                if (!(string.IsNullOrEmpty(sortcolumn_) && string.IsNullOrEmpty(sortcolumndir_)))
                {
                    ProductsStockList = ProductsStockList.OrderBy(x => x.Name).ToList();
                }
                //Search    
                //if (!string.IsNullOrEmpty(searchvalue_))
                //{
                //    ProductsStockList = ProductsStockList.Where(m => m.ProductName == searchvalue_);
                //}

                //total number of rows count     
                recordsTotal = ProductsStockList.Count();
                //Paging     
                var data = ProductsStockList.Skip(skip).Take(pageSize).ToList();
                //Returning Json Data    
                return Json(new { draw = draw_, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });

            }
            catch (Exception)
            {
                throw;
            }

        }


        [HttpPost]
        public JsonResult AddEditProduct(int id, ProductViewModel model)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    var result = new { Result = "Erro", Error = true, Id = 0 };
                    return Json(result);
                }

                if (id > 0)
                {
                    Product product = _unitOfWork.Repository<Product>().GetById(id);
                    if (product != null)
                    {
                        product.Name = model.Name;
                        product.Description = model.Description;
                        product.Price = model.Price;
                        product.CategoryId = model.CategoryId;
                        product.Discount = model.Discount;
          
                        product.Active = model.Active;
                        if (model.Discount > 0)
                        {
                            product.FinalPrice = (model.Price - ((model.Price * model.Discount) / 100));
                        }
                        else
                        {
                            product.FinalPrice = model.Price;
                        }
                        _unitOfWork.Repository<Product>().Update(product);
                    }
                    var result = new { Result = "Produto Atualizado com sucesso", Error = false, Id = product.Id };
                    return Json(result);
                }
                else
                {
                    Product product = new Product
                    {
                        Name = model.Name,
                        Description = model.Description,
                        Price = model.Price,
                        CategoryId = model.CategoryId,
                        Discount = model.Discount,
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Active = true,
                        FinalPrice = model.Price,
                    };
                    if (model.Discount > 0)
                    {
                        product.FinalPrice = (model.Price - ((model.Price * model.Discount) / 100));
                    }  
                    var addProduct = _unitOfWork.Repository<Product>().Insert(product);

                    string FilePath = Path.Combine(_hosingEnv.WebRootPath, $"css\\Images\\Products\\Products_{addProduct.Id}");
                    System.IO.Directory.CreateDirectory(FilePath);

                    var result = new { Result = "Produto Inserido com sucesso", Error = false, Id = product.Id };
                    return Json(result);
                }
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
                _unitOfWork.Repository<Product>().GetAllInclude(x => x.Category).Where(x => x.Active == Active).ToList().ForEach(x =>
                {
                    ProductViewModel product = new ProductViewModel
                    {
                        Id = x.Id,

                        Name = x.Name,
                        Description = x.Description,
                        Price = x.Price,
                        FinalPrice = x.FinalPrice,

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
                    productList.Add(product);
                });
                return productList;
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public string UploadImages()
        {
            string result = string.Empty;
            try
            {
                long size = 0;
                var file = Request.Form.Files;

                var getLastProduct = new Product();

                var idProduct = Request.Form["idProduct"].ToString();


                if (idProduct != "" && idProduct != "0")
                {
                    getLastProduct = _unitOfWork.Repository<Product>().GetById(Convert.ToInt32(idProduct));
                }
                string FilePath = Path.Combine(_hosingEnv.WebRootPath, $"uploads\\Products\\Products_{getLastProduct.Id}");

                bool exists = System.IO.Directory.Exists(FilePath);

                if (!exists)
                    System.IO.Directory.CreateDirectory(FilePath);



                if (getLastProduct != null)
                {
                    foreach (var item in file)
                    {
                        var image = ContentDispositionHeaderValue.Parse(item.ContentDisposition).Name.Trim('"');
                        var filename = $"ProductImage_{getLastProduct.Id }_{ image }";
                        var file_ = Path.Combine(FilePath, filename + ".jpg");

                        size += item.Length;

                        using (FileStream fs = System.IO.File.Create(file_))
                        {
                            item.CopyTo(fs);
                            fs.Flush();
                        }

                        switch (image)
                        {
                            case "image1":
                                getLastProduct.ImagePath = $"/uploads/Products/Products_{getLastProduct.Id}/{filename}.jpg";
                                break;
                            case "image2":
                                getLastProduct.ImagePath2 = $"/uploads/Products/Products_{getLastProduct.Id}/{filename}.jpg";
                                break;
                            case "image3":
                                getLastProduct.ImagePath3 = $"/uploads/Products/Products_{getLastProduct.Id}/{filename}.jpg";
                                break;
                            default:
                                break;
                        }
                        _unitOfWork.Repository<Product>().Update(getLastProduct);

                    }


                }
            }

            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }



    }
}