using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce_MVC_Core.Code;
using Ecommerce_MVC_Core.Data;
using Ecommerce_MVC_Core_Data_2.Models;
using Ecommerce_MVC_Core.Models.Admin;
using Ecommerce_MVC_Core.Repository;
using Ecommerce_MVC_Core.ViewModel;
using Ecommerce_MVC_Core.ViewModel.Public;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ecommerce_MVC_Core.Models;

using static Ecommerce_MVC_Core_Data_2.Data.Enum.Enum;

namespace Ecommerce_MVC_Core.Controllers
{
    public class OrderController : Controller
    {
        //private readonly IRepository<Category> _repoCategory;
        //private readonly IRepository<Product> _repoProduct;
        //private readonly IRepository<Brand> _repoBrand;
        //private readonly IRepository<Unit> _repoUnit;

        //private readonly IRepository<ProductStock> _repoProductStock;
        //private readonly IRepository<ProductImage> _repoProductImage;
        //private readonly IRepository<Orders> _repoOrders;
        //private readonly IRepository<OrderDetails> _repoOrderDetails;
        //private readonly IRepository<Country> _repoCountry;
        //private readonly IRepository<City> _repoCity;
        //private readonly IRepository<Location> _repoLocation;
        //private readonly IRepository<PaymentMethod> _repoPaymentMethod;
        private readonly UserManager<ApplicationUsers> _userManager;

        private readonly IUnitOfWork _unitOfWork;


        public OrderController(IUnitOfWork unitOfWork, UserManager<ApplicationUsers> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index(int TypeOrder)
        {

            ViewBag.TypeOrder = TypeOrder;
            return View();
        }

        public ActionResult LoadData(int TypeOrder)
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
                var OrdersList = GetOrders(TypeOrder).ToList();

                //Sorting    
                if (!(string.IsNullOrEmpty(sortcolumn_) && string.IsNullOrEmpty(sortcolumndir_)))
                {
                    OrdersList = OrdersList.OrderBy(x => x.Name).ToList();
                }
                //Search    
                //if (!string.IsNullOrEmpty(searchvalue_))
                //{
                //    ProductsStockList = ProductsStockList.Where(m => m.ProductName == searchvalue_);
                //}

                //total number of rows count     
                recordsTotal = OrdersList.Count();
                //Paging     
                var data = OrdersList.Skip(skip).Take(pageSize).ToList();
                //Returning Json Data    
                return Json(new { draw = draw_, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });

            }
            catch (Exception)
            {
                throw;
            }

        }

        public List<OrdersViewModel> GetOrders(int TypeOrder)
        {
            try
            {
                List<OrdersViewModel> orderList = new List<OrdersViewModel>();
                var Listdb = new List<Orders>();
                switch (TypeOrder)
                {
                    case 1:

                        Listdb = _unitOfWork.Repository<Orders>().GetAllInclude(u => u.Users).Where(x => x.StatusId == (int)StatusOrder.Created 
                        || (x.StatusId == (int)StatusOrder.Processed && x.PaymentMethodId == 2) 
                        || x.StatusId == (int)StatusOrder.NotPaid
                        || x.StatusId == (int)StatusOrder.Error).ToList();
                        break;
                    case 2:
                        Listdb = _unitOfWork.Repository<Orders>().GetAllInclude(u => u.Users).Where(x => x.StatusId == (int)StatusOrder.Paid).ToList();
                        break;
                    case 3:
                        Listdb = _unitOfWork.Repository<Orders>().GetAllInclude(u => u.Users).Where(x => x.StatusId == (int)StatusOrder.Sent).ToList();
                        break;
                    default:
                        //error
                        break;
                }
                Listdb.ForEach(x =>
                {
                    OrdersViewModel Order = new OrdersViewModel
                    {
                        Id = x.Id,
                        Number = x.Number,
                        Name = x.Users.FirstName + " " + x.Users.LastName,
                        Address = x.DeliveryAddress,
                        Email = x.Users.Email,
                        PhoneNumber = x.Users.PhoneNumber,
                        Total = x.Total,
                        ProductsNumber = x.ProductsNumber,
                        NIF = x.Users.NIF,                      
                        Status = x.StatusId,
                    };

                    switch (x.PaymentMethodId)
                    {
                        case 1:
                            Order.PaymentMethod = "Visa/MasterCard";
                            break;
                        case 2:
                            Order.PaymentMethod = "Referência Multibanco";
                            break;
                        default:
                            break;
                    }
                    orderList.Add(Order);
                });
                return orderList;
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost]
        public IActionResult NewOrder(NewOrderViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Something wrong");
                    return View(model);
                }

                bool ValidateOrder = this.ValidateOrder(model);
                if (true)
                {
                    var contry = _unitOfWork.Repository<Country>().Find(x => x.Id == Convert.ToInt32(model.CountryId));

                    Orders Neworder = new Orders
                    {
                        Number = "" + DateTime.Now.ToString("yyyyMMddss") + GenerateRandomNo() + "",
                        ProductsNumber = model.ProductsNumber,
                        DeliveryAddress = contry.CountryName + " " + model.City + " " + model.Address + " " + model.PostalCode,
                        Total = Convert.ToDouble(model.Total.Replace(".",",")),
                        StatusId = 1,
                        PaymentMethodId = model.PaymentMethodId,
                        AddedDate = DateTime.Now,
                        NotificationViewed = false,
                        Users = new ApplicationUsers
                        {
                            FirstName = model.FirstName,
                            LastName = model.LastName,
                            City = model.City,
                            PostalCode = model.PostalCode,
                            Address = model.Address,
                            Email = model.Email,
                            PhoneNumber = model.PhoneNumber,
                            NIF = model.NIF,
                        }
                    };

                    if (model.PaymentMethodId == 1)
                    {
                        Neworder.CardNumber = model.CardNumber.Replace(" ", "");
                        Neworder.DateValidation = model.MonthValidation + "/" + model.YearValidation;
                        Neworder.CVV = model.CVV;
                    }

                    var Products = model.ProductCountList;

                    List<OrderDetails> ListProducts = new List<OrderDetails>();
                    foreach (var product in Products)
                    {
                        var product_ = _unitOfWork.Repository<Product>().Find(x => x.Id == Convert.ToInt32(product.Key));
                        var size = model.ProductSizeList.Where(x => x.Key == product.Key).FirstOrDefault().Value;
                        var color = model.ProductColorList.Where(x => x.Key == product.Key).FirstOrDefault().Value;
                        var count = Convert.ToInt32(product.Value);
                        var Stockproduct_ = _unitOfWork.Repository<ProductStock>().GetAllInclude(s => s.ProductSize, c => c.Colors).Where(x => x.ProductId == Convert.ToInt32(product.Key) && x.ProductSize.Size == size && x.Colors.Color == color).FirstOrDefault();
                        ListProducts.Add(new OrderDetails
                        {
                            ColorId = Stockproduct_.ColorId,
                            SizeId = Stockproduct_.SizeId,
                            ProductId = product_.Id,
                            Quantity = count,
                            AddedDate = DateTime.Now,
                        });
                        Stockproduct_.InQuantity = Stockproduct_.InQuantity - 1;
                        if (Stockproduct_.InQuantity == Stockproduct_.MinQuantity)
                        {
                            Stockproduct_.HaveStock = false;
                        }
                        _unitOfWork.Repository<ProductStock>().Update(Stockproduct_);
                    }

                    Neworder.OrderDetails = ListProducts;
                    _unitOfWork.Repository<Orders>().Insert(Neworder);
                }
                else
                {
                    //TODO:FATALERROR
                }

                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {

                throw;
            }

        }


        [HttpPost]
        public JsonResult SendOrder(int Id)
        {
            try
            {
                if (Id > 0)
                {
                    var Order = _unitOfWork.Repository<Orders>().Find(x => x.Id == Id);
                    if (Order != null)
                    {
                        Order.StatusId = (int)StatusOrder.Sent;
                        _unitOfWork.Repository<Orders>().Update(Order);
                        _unitOfWork.Commit();
                        var result = new { Result = "Success", Error = false, Id = Id };
                        return Json(result);
                    }
                    else
                    {
                        var result = new { Result = "Error", Error = true, Id = Id };
                        return Json(result);
                    }
                }
                else
                {
                    var result = new { Result = "Error", Error = true, Id = Id };
                    return Json(result);
                }

            }
            catch (Exception)
            {
                var result = new { Result = "Error", Error = true, Id = Id };
                return Json(result);
            }

        }
        

        [HttpGet]
        public IActionResult Details(int id)
        {
            try
            {
                ViewBag.IdOrder = id;

                return PartialView("~/Views/Order/_SeeDetailsOrder.cshtml");

            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult LoadDataDetails(int OrderId)
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
                var OrdersList = GetOrderDetail(OrderId).ToList();

                //Sorting    
                if (!(string.IsNullOrEmpty(sortcolumn_) && string.IsNullOrEmpty(sortcolumndir_)))
                {
                    OrdersList = OrdersList.OrderBy(x => x.Product).ToList();
                }
                //Search    
                //if (!string.IsNullOrEmpty(searchvalue_))
                //{
                //    ProductsStockList = ProductsStockList.Where(m => m.ProductName == searchvalue_);
                //}

                //total number of rows count     
                recordsTotal = OrdersList.Count();
                //Paging     
                var data = OrdersList.ToList();
                //Returning Json Data    
                return Json(new { draw = draw_, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });

            }
            catch (Exception)
            {
                throw;
            }

        }
        public List<OrderDetailsViewModel> GetOrderDetail(int Id)
        {
            try
            {
                List<OrderDetailsViewModel> orderList = new List<OrderDetailsViewModel>();

                _unitOfWork.Repository<OrderDetails>().GetAllInclude(u => u.Product, s => s.ProductSize, X => X.Colors, c => c.Product.Category).Where(x => x.OrderId == Id).ToList().ForEach(x =>
                 {
                     OrderDetailsViewModel Order = new OrderDetailsViewModel
                     {
                         Product = x.Product.Name,
                         Color = x.Colors.Color,
                         Size = x.ProductSize.Size,
                         Category = x.Product.Category.Name,
                         Quantity = x.Quantity,
                         Price = x.Product.Price,
                     };
                     orderList.Add(Order);
                 });
                return orderList;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public int GenerateRandomNo()
        {
            int _min = 1000000;
            int _max = 9999999;
            Random _rdm = new Random();
            return _rdm.Next(_min, _max);
        }


        public bool ValidateOrder(NewOrderViewModel model)
        {
            #region VerifyProducts
            var Products = model.ProductCountList;
            foreach (var product in Products)
            {
                var product_ = _unitOfWork.Repository<Product>().Find(x => x.Id == Convert.ToInt32(product.Key));

                if (product_ == null)
                {
                    return false;
                }

                var size = model.ProductSizeList.Where(x => x.Key == product.Key).FirstOrDefault().Value;
                var color = model.ProductColorList.Where(x => x.Key == product.Key).FirstOrDefault().Value;
                var count = Convert.ToInt32(product.Value);

                var Stockproduct_ = _unitOfWork.Repository<ProductStock>().GetAllInclude(s => s.ProductSize, c => c.Colors).Where(x => x.ProductId == Convert.ToInt32(product.Key) && x.ProductSize.Size == size && x.Colors.Color == color).FirstOrDefault();
                var CountStock_ = Stockproduct_?.InQuantity - Stockproduct_?.MinQuantity;
                if (Stockproduct_ == null || CountStock_ <= count)
                {
                    return false;
                }
            }
            #endregion

            #region VerifyCountry
            var contry = _unitOfWork.Repository<Country>().Find(x => x.Id == Convert.ToInt32(model.CountryId));

            if (contry == null)
            {
                return false;
            }
            #endregion

            #region VerifyCard
            var PaymentMethod = _unitOfWork.Repository<PaymentMethod>().Find(x => x.Id == 1);
            if (PaymentMethod == null)
            {
                return false;
            }
            if (PaymentMethod.Id == 1)
            {
                if (model.CardNumber.Replace(" ", "").Length != 16 || model.CVV.Length != 3)
                {
                    return false;
                }
            }

            return true;


            #endregion
        }

    }
}