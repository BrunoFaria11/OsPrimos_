using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Ecommerce_MVC_Core.Models.Admin;
using Ecommerce_MVC_Core.Repository;
using Ecommerce_MVC_Core.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;

namespace Ecommerce_MVC_Core.Controllers.Admin
{

    public class AdminController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHostingEnvironment _hosingEnv;
        public AdminController(
            IUnitOfWork unitOfWork,
            IHostingEnvironment hosingEnv
        )
        {
            _hosingEnv = hosingEnv;
            _unitOfWork = unitOfWork;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WebSite()
        {
            ViewBag.Category = _unitOfWork.Repository<Category>().GetAll().ToList();

            return View();
        }




        public string UploadImages()
        {
            string result = string.Empty;
            try
            {
                long size = 0;
                var file = Request.Form.Files;

                var filename = ContentDispositionHeaderValue.Parse(file[0].ContentDisposition).Name.Trim('"');
                string FilePath = Path.Combine(_hosingEnv.WebRootPath, "css/Images/");
                var file_ = Path.Combine(FilePath, filename + ".jpg");

                size += file[0].Length;

                using (FileStream fs = System.IO.File.Create(file_))
                {

                    file[0].CopyTo(fs);
                    fs.Flush();
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