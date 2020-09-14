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
using Microsoft.AspNetCore.Hosting;
using System.Net.Http.Headers;
using System.IO;
using System.Data;

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

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {

            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult WebSite()
        {
            ViewBag.Category = _unitOfWork.Repository<Category>().GetAll().ToList();


            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult PageDetails(int Id)
        {
            ViewBag.Sections = _unitOfWork.Repository<Sections>().GetAllInclude(x => x.Sections_HTML).Where(x => x.PageId == Id).ToList();
            return View();
        }


        
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public JsonResult SaveSections(int SectionId, List<Section_HTML_JQViewModel> List)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Opps something wrong");
                    var result = new { Result = "Erro", Error = true, Id = 0 };
                    return Json(result);
                }
                else
                {
                    var section = _unitOfWork.Repository<Sections>().Find(x => x.Id == SectionId);
                    foreach (var item in List)
                    {
                        var section_HTML = _unitOfWork.Repository<Sections_HTML>().Find(x => x.Id == item.Id);

                        switch (section_HTML.InputType)
                        {
                            case 1:
                                var Input_replaced = item.Input.Replace("value=\"\"", $"value=\"{item.Tag_HTML_Value}\"");
                                section_HTML.Input = Input_replaced;
                                section_HTML.Tag_HTML_Value = item.Tag_HTML_Value;
                                break;
                            case 2:
                                if (item.ImageBase64 != null)
                                {
                                    UploadImagesfromBase64(section_HTML.ImagePath, section_HTML.Tag_HTML_Value, item.ImageBase64);
                                }
                                break;
                            default:
                                break;
                        }


                        _unitOfWork.Repository<Sections_HTML>().Update(section_HTML);

                    }

                    var result = new { Result = "Sucesso", Error = false };
                    return Json(result);
                }


            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
        public bool UploadImagesfromBase64(string path, string fileName, string Base64)
        {
            try
            {

                string FilePath = Path.Combine(_hosingEnv.WebRootPath, path);
                var file_ = Path.Combine(FilePath, fileName);
                //Check if directory exist
                if (!System.IO.Directory.Exists(path))
                {
                    System.IO.Directory.CreateDirectory(path); //Create directory if it doesn't exist
                }
                string imageName = fileName;

                string convert = Base64.Replace("data:image/png;base64,", String.Empty);
                convert = convert.Replace("data:image/jpg;base64,", String.Empty);
                convert = convert.Replace("data:image/jpeg;base64,", String.Empty);


                byte[] imageBytes = Convert.FromBase64String(convert);

                using (FileStream fs = System.IO.File.Create(file_))
                {

                    fs.Write(imageBytes);
                    fs.Flush();
                }

                System.IO.File.WriteAllBytes(file_, imageBytes);
            }

            catch (Exception ex)
            {
                throw;
            }
            return true;
        }


        [Authorize(Roles = "Admin")]
        public ActionResult LoadDataPages()
        {
            try
            {
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

                int pageSize = length != null ? Convert.ToInt32(length_) : 0;
                int skip = start != null ? Convert.ToInt32(start_) : 0;
                int recordsTotal = 0;

                // Getting all Customer data    
                var List = _unitOfWork.Repository<Pages>().GetAll().ToList();

                //Sorting    
                if (!(string.IsNullOrEmpty(sortcolumn_) && string.IsNullOrEmpty(sortcolumndir_)))
                {
                    List = List.OrderBy(x => x.Id).ToList();
                }
                //Search    
                //if (!string.IsNullOrEmpty(searchvalue_))
                //{
                //    ProductsStockList = ProductsStockList.Where(m => m.ProductName == searchvalue_);
                //}

                //total number of rows count     
                recordsTotal = List.Count();
                //Paging     
                var data = List.Skip(skip).Take(pageSize).ToList();
                //Returning Json Data    
                return Json(new { draw = draw_, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });

            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}