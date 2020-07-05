using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce_MVC_Core.Models.Admin;
using Ecommerce_MVC_Core.Repository;
using Ecommerce_MVC_Core.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nancy.Json;
using Newtonsoft.Json.Linq;

namespace Ecommerce_MVC_Core.Controllers.Admin
{

    public class BannerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHostingEnvironment _hosingEnv;
        public BannerController(
            IUnitOfWork unitOfWork,
            IHostingEnvironment hosingEnv
        )
        {
            _hosingEnv = hosingEnv;
            _unitOfWork = unitOfWork;
        }



        [HttpGet]
        public async Task<IActionResult> EditBanner()
        {
            var Order = 1;
            BannerViewModel model = new BannerViewModel();

            if (Order > 0)
            {
                Banner banner = await _unitOfWork.Repository<Banner>().FindAsync(x => x.Order == Order);
                if (banner != null)
                {
                    model.Title = banner.Title;
                    model.SubTitle = banner.SubTitle;

                }

            }
            return PartialView("~/Views/Banner/_EditBanner.cshtml", model);
        }



        [HttpPost]
        public  JsonResult EditBanner(int id,  BannerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json("error");
            }

            var Order = 1;
            if (Order > 0)
            {
                Banner banner =  _unitOfWork.Repository<Banner>().Find(x => x.Order == Order);
                if (banner != null)
                {
                    banner.Title = model.Title;
                    banner.SubTitle = model.SubTitle;

                     _unitOfWork.Repository<Banner>().Update(banner);
                }
            }
            else
            {
                return Json("error");
            }
            return Json("   Texto do benner editado com sucesso");
        }

    }
}