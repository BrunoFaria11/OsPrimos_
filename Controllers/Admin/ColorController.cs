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

        public IActionResult Index()
        {
            //Get List of All Products
            var Colors = _unitOfWork.Repository<Colors>().GetAll();

            ViewBag.ProductSize = _unitOfWork.Repository<ProductSize>().GetAll();


            return View(Colors);
        }


        [HttpGet]
        public IActionResult AddColor()
        {
            ColorsViewModel Color = new ColorsViewModel();

            return PartialView("~/Views/Color/_AddColors.cshtml", Color);
        }

        [HttpPost]
        public JsonResult AddColor(ColorsViewModel model)
        {

            Colors Color = new Colors
            {
                Color = model.Color,
            };

            _unitOfWork.Repository<Colors>().Insert(Color);

            return Json("Cor Inserida com sucesso");
        }
    }
}