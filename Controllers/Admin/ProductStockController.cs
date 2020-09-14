using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Ecommerce_MVC_Core.Data;
using Ecommerce_MVC_Core.Models.Admin;
using Ecommerce_MVC_Core.Repository;
using Ecommerce_MVC_Core.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nancy.ViewEngines;

namespace Ecommerce_MVC_Core.Controllers.Admin
{

    public class ProductStockController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductStockController(
            IUnitOfWork unitOfWork
        )
        {
            _unitOfWork = unitOfWork;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            try
            {
                ViewBag.HaveColor = _unitOfWork.Repository<Colors>().Any(x=>x.Id>0);
                ViewBag.HaveProducts = _unitOfWork.Repository<Colors>().Any(x => x.Id > 0);

                return View();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [HttpGet]
        public async Task<IActionResult> AddEditProductStock(int id)
        {
            try
            {
                ProductStockViewModel model = new ProductStockViewModel();
                ViewBag.Colors = _unitOfWork.Repository<Colors>().GetAll();
                ViewBag.Sizes = _unitOfWork.Repository<ProductSize>().GetAll();

                if (id > 0)
                {
                    ProductStock productStock = await _unitOfWork.Repository<ProductStock>().GetSingleIncludeAsync(x => x.Id == id);
                    model.Id = productStock.Id;
                    model.InQuantity = productStock.InQuantity;
                    model.MinQuantity = productStock.MinQuantity;
                    model.ProductId = productStock.ProductId;
                    model.SizeId = productStock.SizeId;
                    model.ColorId = productStock.ColorId;
                    model.IsActive = productStock.IsActive;
                    model.HaveStock = productStock.HaveStock;
                }
                return PartialView("~/Views/ProductStock/AddEditProductStock.cshtml", model);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public JsonResult GetSizes(string q, int catId)
        {
            try
            {
                var ProductSizeList = _unitOfWork.Repository<ProductSize>().GetAll().Select(x => new SelectListItem
                {
                    Text = x.Size,
                    Value = x.Id.ToString()
                }).ToList();

                if (!(string.IsNullOrEmpty(q) || string.IsNullOrWhiteSpace(q)))
                {
                    ProductSizeList = ProductSizeList.Where(x => x.Text.ToLower().StartsWith(q.ToLower())).ToList();
                }

                return Json(ProductSizeList);
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        [HttpPost]
        public JsonResult AddEditProductStock(int id, ProductStockViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Opps something wrong");
                    var result = new { Result = "Erro", Error = true, Id = 0 };
                    return Json(result);
                }
                if (id > 0)
                {
                    ProductStock productStock = _unitOfWork.Repository<ProductStock>().GetById(id);
                    productStock.InQuantity = model.InQuantity;
                    productStock.MinQuantity = model.MinQuantity;
                    productStock.ProductId = model.ProductId;
                    productStock.SizeId = model.SizeId;
                    productStock.ColorId = model.ColorId;
                    productStock.IsActive = model.IsActive;

                    if (model.InQuantity > model.MinQuantity)
                    {
                        productStock.HaveStock = true;
                    }
                    else
                    {
                        productStock.HaveStock = false;
                    }
                    _unitOfWork.Repository<ProductStock>().Update(productStock);
                    var result = new { Result = "Stock Atualizado com sucesso", Error = false, Id = productStock.Id };
                    return Json(result);
                }
                else
                {
                    if (_unitOfWork.Repository<ProductStock>().FindAll(x => x.ProductId == model.ProductId && x.ColorId == model.ColorId && x.SizeId == model.SizeId).Count() == 0)
                    {
                        ProductStock productStock = new ProductStock
                        {
                            InQuantity = model.InQuantity,
                            MinQuantity = model.MinQuantity,
                            ProductId = model.ProductId,
                            SizeId = model.SizeId,
                            ColorId = model.ColorId,
                            IsActive = true,
                        };
                        if (model.InQuantity > model.MinQuantity)
                        {
                            productStock.HaveStock = true;
                        }
                        else
                        {
                            productStock.HaveStock = false;
                        }
                        _unitOfWork.Repository<ProductStock>().Insert(productStock);
                        var result = new { Result = "Stock Atualizado com sucesso", Error = false, Id = productStock.Id };
                        return Json(result);
                    }
                    else
                    {
                        var result = new { Result = "Erro: Já existe um Produto para a cor e tamanho selecionado", Error=true,Id = 0 };
                        return Json(result);
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public ActionResult LoadData()
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
                var sortcolumn = Request.Form.TryGetValue("columns[" + aux_+ "][name]", out sortcolumn_);
                var sortcolumndir = Request.Form.TryGetValue("order[0][dir]", out sortcolumndir_);
                var searchvalue = Request.Form.TryGetValue("search[value]", out searchvalue_);


                //Paging Size (10,20,50,100)    
                int pageSize = length != null ? Convert.ToInt32(length_) : 0;
                int skip = start != null ? Convert.ToInt32(start_) : 0;
                int recordsTotal = 0;

                // Getting all Customer data    
                var ProductsStockList = GetProductsStock().ToList();

                //Sorting    
                if (!(string.IsNullOrEmpty(sortcolumn_) && string.IsNullOrEmpty(sortcolumndir_)))
                {
                    ProductsStockList = ProductsStockList.OrderBy(x=>x.ProductName).ToList() ;
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



        public List<ProductStockViewModel> GetProductsStock()
        {
            try
            {
                List<ProductStockViewModel> productList = new List<ProductStockViewModel>();
                _unitOfWork.Repository<ProductStock>().GetAllInclude(p => p.Product, c => c.Colors, s => s.ProductSize).ToList().ForEach(x =>
                {
                    ProductStockViewModel product = new ProductStockViewModel
                    {
                        Id = x.Id,
                        ModifiedDate = x.ModifiedDate,
                        AddedDate = x.AddedDate,
                        InQuantity = x.InQuantity,
                        ProductName = x.Product.Name,
                        Size = x.ProductSize.Size,
                        MinQuantity = x.MinQuantity,
                        Color = x.Colors.Color,
                        IsActive = x.IsActive,
                        HaveStock = x.HaveStock,
                        IamgeProduct = x.Product.ImagePath,


                    };
                    productList.Add(product);
                });
                return productList;
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        //AutoComplete for Product
        [HttpGet]
        public JsonResult GetProducts()
        {
            try
            {
                var productList = _unitOfWork.Repository<Product>().GetAll().Select(x => new { Text = x.Name, Value = x.Id }).ToList();
                return Json(productList);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}