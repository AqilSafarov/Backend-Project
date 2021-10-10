using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Trax.Models;
using Trax.Services;
using Trax.Services.Repository.IRepository;

namespace Trax.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles = "Admin, Moderator")]
    public class HomeOneController : Controller
    {
        private readonly IHomeOne _homeOne;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly AppDbContext _context;

        public HomeOneController(IHomeOne homeOne, IWebHostEnvironment webHostEnvironment,AppDbContext context)
        {
            _homeOne = homeOne;
            _webHostEnvironment = webHostEnvironment;
            _context = context;
        }
        public IActionResult Index(int page = 1)
        {
            ViewBag.Active = "HomeOne";
            List<Models.HomeOne> homeOne1 = _homeOne.GetHomeOne();
            decimal dataPage = 3;
            decimal pageCount = Math.Ceiling(homeOne1.Count / dataPage);

            List<Models.HomeOne> homeOne2 = homeOne1.OrderByDescending(o => o.Id).Skip(Convert.ToInt32((page - 1) * dataPage)).Take((int)dataPage).ToList();
            ViewBag.CurrentPage = page;
            ViewBag.PageCount = pageCount;
            ViewBag.DataPage = dataPage;
            ViewBag.DataCount = homeOne1.Count;
            return View(homeOne2);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(HomeOne model)
        {

            if (ModelState.IsValid)
            {

                if (model.ImageFile != null)
                {
                    if (!(model.ImageFile.ContentType == "image/png" || model.ImageFile.ContentType == "image/jpeg" || model.ImageFile.ContentType == "image/gif"))
                    {
                        ModelState.AddModelError("", "You can only upload jpeg, png, and gif");

                        return View(model);
                    }

                    if (model.ImageFile.Length > 2097152)
                    {
                        ModelState.AddModelError("", "You can only upload max 2 Mb size images");

                        return View(model);
                    }

                    string fileName = Guid.NewGuid() + "-" + DateTime.Now.ToString("ddMMyyyyHHmmss") + "-" + model.ImageFile.FileName;
                    string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        model.ImageFile.CopyTo(stream);
                    }

                    model.Image = fileName;
                }



                _homeOne.CreateHomeOne(model);



                return RedirectToAction("Index");
            }


            return View(model);
        }

        public IActionResult Update(int? homeoneId)
        {
            if (homeoneId == null && homeoneId <= 0)
            {
                return NotFound();
            }


            HomeOne homeOne = _homeOne.GetHomeOne(homeoneId);
            ViewBag.HomeOne = _homeOne.GetHomeOne();

            return View(homeOne);
        }

        [HttpPost]
        public IActionResult Update(HomeOne model)
        {
            if (ModelState.IsValid)
            {
                if (model.ImageFile != null)
                {
                    if (!(model.ImageFile.ContentType == "image/png" || model.ImageFile.ContentType == "image/jpeg" || model.ImageFile.ContentType == "image/gif"))
                    {
                        ModelState.AddModelError("", "You can only upload jpeg, png, and gif");
                        return View(model);
                    }

                    if (model.ImageFile.Length > 2097152)
                    {
                        ModelState.AddModelError("", "You can only upload max 2 Mb size images");
                        return View(model);
                    }

                    string fileName = Guid.NewGuid() + "-" + DateTime.Now.ToString("ddMMyyyyHHmmss") + "-" + model.ImageFile.FileName;
                    string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        model.ImageFile.CopyTo(stream);
                    }

                    model.Image = fileName;
                }
                _homeOne.UpdateHomeOne(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult Delete(int? homeoneId)
        {
            _homeOne.DeleteHomeOne(homeoneId);

            return RedirectToAction("Index");
        }
        
    }
}
