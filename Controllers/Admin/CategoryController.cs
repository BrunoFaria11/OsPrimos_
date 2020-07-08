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
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace Ecommerce_MVC_Core.Controllers.Admin
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHostingEnvironment _hosingEnv;

        public CategoryController(
            IUnitOfWork unitOfWork,
            IHostingEnvironment hosingEnv

        )
        {
            _unitOfWork = unitOfWork;
            _hosingEnv = hosingEnv;

        }


        [HttpGet]
        public async Task<IActionResult> AddEditCategory(int id)
        {
            CategoryViewModel model = new CategoryViewModel();
            var totalCategory = await _unitOfWork.Repository<Category>().CountAsync();
            if (id > 0)
            {
                Category category = await _unitOfWork.Repository<Category>().GetByIdAsync(id);
                if (category != null)
                {
                    model.Id = category.Id;
                    model.Name = category.Name;
                    model.Image_Path = category.Image_Path;
                }
            }
            return PartialView("_AddEditCategory", model);
        }

        [HttpPost]
        public JsonResult AddEditCategory(int id, CategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {

                return Json(new { Result = "error" });
            }

            Category category = _unitOfWork.Repository<Category>().GetById(id);
            category = new Category
            {
                Id = model.Id,

                Name = model.Name,
                AddedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };
            _unitOfWork.Repository<Category>().addOrUpdate(id > 0 ? EntityState.Modified : EntityState.Added, category);
            var result = new { Result = "Categoria inserida com sucesso", Id = category.Id };
            return Json(result);
        }

        public string UploadImages()
        {
            string result = string.Empty;
            try
            {
                long size = 0;
                var file = Request.Form.Files;
                var getLastCat = new Category();
                var idCat = ContentDispositionHeaderValue.Parse(file[0].ContentDisposition).Name.Trim('"');
                if (idCat != "" && idCat != "0")
                {
                    getLastCat = _unitOfWork.Repository<Category>().GetById(Convert.ToInt32(idCat));
                }
                else
                {
                    getLastCat = _unitOfWork.Repository<Category>().Find(x => x.Image_Path == "" || x.Image_Path == null);
                }
                if (getLastCat != null)
                {
                    var filename = "catImage_" + getLastCat.Id;
                    string FilePath = Path.Combine(_hosingEnv.WebRootPath, "css\\Images\\Categories");
                    var file_ = Path.Combine(FilePath, filename + ".jpg");

                    size += file[0].Length;

                    using (FileStream fs = System.IO.File.Create(file_))
                    {
                        file[0].CopyTo(fs);
                        fs.Flush();
                    }
                    getLastCat.Image_Path = $"/css/Images/Categories/{filename}.jpg";
                    _unitOfWork.Repository<Category>().Update(getLastCat);
                }
            }

            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Category category = await _unitOfWork.Repository<Category>().GetByIdAsync(id);

            return PartialView("_DeleteCategory", category?.Name);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, IFormCollection form)
        {
            var category = await _unitOfWork.Repository<Category>().GetByIdAsync(id);
            if (category != null)
            {
                await _unitOfWork.Repository<Category>().DeleteAsync(category);

            }
            return RedirectToAction("Index");
        }
    }
}