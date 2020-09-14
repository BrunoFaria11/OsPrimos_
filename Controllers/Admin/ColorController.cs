using System;
using System.Collections.Generic;
using System.Drawing;
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
    public class ColorController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHostingEnvironment _hosingEnv;
        public ColorController(
            IUnitOfWork unitOfWork,
            IHostingEnvironment hosingEnv
        )
        {
            _hosingEnv = hosingEnv;
            _unitOfWork = unitOfWork;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            try
            {
                return View();

            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult AddColor()
        {
            try
            {
                ColorsViewModel Color = new ColorsViewModel();

                return PartialView("~/Views/Color/_AddColors.cshtml", Color);
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public JsonResult AddColor(ColorsViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var result = new { Result = "Erro", Error = true, Id = 0 };
                    return Json(result);

                }

                if (!_unitOfWork.Repository<Colors>().Any(x => x.Color == model.Color))
                {
                    Colors Color = new Colors
                    {
                        Color = model.Color,
                    };

                    _unitOfWork.Repository<Colors>().Insert(Color);
                    var result = new { Result = "Cor Inserida com sucesso", Error = false, Id = Color.Id };
                    return Json(result);
                }
                else
                {
                    var result = new { Result = "Erro: A cor inserida já existe", Error = true };
                    return Json(result);
                }       
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult AddSize()
        {
            try
            {
                ProductSizeViewModel Size = new ProductSizeViewModel();

                return PartialView("~/Views/ProductSize/_AddSize.cshtml", Size);
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public JsonResult AddSize(ProductSizeViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var result = new { Result = "Erro", Error = true, Id = 0 };
                    return Json(result);

                }

                if (!_unitOfWork.Repository<ProductSize>().Any(x => x.Size.ToUpper() == model.Size.ToUpper()))
                {
                    ProductSize Size = new ProductSize
                    {
                        AddedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,

                        Size = model.Size,
                    };

                    _unitOfWork.Repository<ProductSize>().Insert(Size);
                    var result = new { Result = "Tamanho Inserido com sucesso", Error = false, Id = Size.Id };
                    return Json(result);
                }
                else
                {
                    var result = new { Result = "Erro: O Tamanho inserido já existe", Error = true };
                    return Json(result);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        public ActionResult LoadDataColor()
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
                var ProductsStockList = GetColors().ToList();

                //Sorting    
                if (!(string.IsNullOrEmpty(sortcolumn_) && string.IsNullOrEmpty(sortcolumndir_)))
                {
                    ProductsStockList = ProductsStockList.OrderBy(x => x.Color).ToList();
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

        public ActionResult LoadDataSizes()
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
                var ProductsStockList = GetSizes().ToList();

                //Sorting    
                if (!(string.IsNullOrEmpty(sortcolumn_) && string.IsNullOrEmpty(sortcolumndir_)))
                {
                    ProductsStockList = ProductsStockList.ToList();
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

        public List<ColorsListViewModel> GetColors()
        {
            try
            {
                List<ColorsListViewModel> colorList = new List<ColorsListViewModel>();
                _unitOfWork.Repository<Colors>().GetAll().ToList().ForEach(x =>
                {
                    ColorsListViewModel color = new ColorsListViewModel
                    {
                        Id = x.Id,
                        Color = x.Color,
                    };
                    colorList.Add(color);
                });
                return colorList;
            }
            catch (Exception)
            {

                throw;
            }
         
        }

        public List<ProductSizeListViewModel> GetSizes()
        {
            try
            {
                List<ProductSizeListViewModel> ProductSizeList = new List<ProductSizeListViewModel>();
                _unitOfWork.Repository<ProductSize>().GetAll().ToList().ForEach(x =>
                {
                    ProductSizeListViewModel ProductSize = new ProductSizeListViewModel
                    {
                        Id = x.Id,
                        Size = x.Size,
                    };
                    ProductSizeList.Add(ProductSize);
                });
                return ProductSizeList;
            }
            catch (Exception)
            {

                throw;
            }
          
        }
    }
}