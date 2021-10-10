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
    [Area("Admin"), Authorize(Roles = "Admin,Moderator")]

    public class SliderController : Controller
    {
        private readonly ISlider _slider;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly AppDbContext _context;

        public SliderController(ISlider slider, IWebHostEnvironment webHostEnvironment, AppDbContext context)
        {
            _slider = slider;
            _webHostEnvironment = webHostEnvironment;
            _context = context;
        }
        public IActionResult Index(int page = 1)
        {
            ViewBag.Active = "Slider";
            List<Models.Slider> slider1 = _slider.GetSlider();
            decimal dataPage = 5;
            decimal pageCount = Math.Ceiling(slider1.Count / dataPage);

            List<Models.Slider> slider2 = slider1.OrderByDescending(o => o.Id).Skip(Convert.ToInt32((page - 1) * dataPage)).Take((int)dataPage).ToList();
            ViewBag.CurrentPage = page;
            ViewBag.PageCount = pageCount;
            ViewBag.DataPage = dataPage;
            ViewBag.DataCount = slider1.Count;
            return View(slider2);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Slider model)
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

                    model.ImageBg = fileName;
                }



                _slider.CreateSlider(model);



                return RedirectToAction("Index");
            }


            return View(model);
        }
        public IActionResult Update(int? sliderId)
        {
            if (sliderId == null && sliderId <= 0)
            {
                return NotFound();
            }
            Models.Slider slider = _slider.FindSlider(sliderId);
            return View(slider);
        }
        [HttpPost]
        public IActionResult Update(Models.Slider model)
        {
            if (ModelState.IsValid)
            {
                if (model.ImageFile != null)
                {
                    if (!((model.ImageFile.ContentType == "image/png")))
                    {
                        ModelState.AddModelError("", "You can upload only png file");
                        return View(model);
                    }
                    if (model.ImageFile.Length > 2097152)
                    {
                        ModelState.AddModelError("", "You can only upload 2mb file");
                        return View(model);
                    }
                    string fileName = Guid.NewGuid() + "-" + DateTime.Now.ToString("ddMMyyyyHHmmss") + "-" + model.ImageFile.FileName;
                    string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        model.ImageFile.CopyTo(stream);
                    }

                    model.ImageBg = fileName;
                }
                _slider.UpdateSlider(model);


                return RedirectToAction("Index");
            }

            return View(model);

        }
        public IActionResult Delete(int sliderId)
        {
            _slider.DeleteSlider(sliderId);

            return RedirectToAction("Index");
        }


    }
}
