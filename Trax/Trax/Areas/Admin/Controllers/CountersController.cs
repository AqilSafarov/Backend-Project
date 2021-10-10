using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Trax.Services;
using Trax.Services.Repository.IRepository;

namespace Trax.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles = "Admin, Moderator")]

    public class CountersController : Controller
    {
        private readonly ICounters _counters;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly AppDbContext _context;

        public CountersController(ICounters counters, IWebHostEnvironment webHostEnvironment, AppDbContext context)
        {
            _counters = counters;
            _webHostEnvironment = webHostEnvironment;
            _context = context;
        }
        public IActionResult Index(int page=1)
        {
            ViewBag.Active = "Counters";
            List<Models.Counters> counters1 = _counters.GetCounters();
            decimal dataPage = 5;
            decimal pageCount = Math.Ceiling(counters1.Count / dataPage);

            List<Models.Counters> counters2 = counters1.OrderByDescending(o => o.Id).Skip(Convert.ToInt32((page - 1) * dataPage)).Take((int)dataPage).ToList();
            ViewBag.CurrentPage = page;
            ViewBag.PageCount = pageCount;
            ViewBag.DataPage = dataPage;
            ViewBag.DataCount = counters1.Count;
            return View(counters2);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Models.Counters model)
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



                _counters.CreateCounters(model);



                return RedirectToAction("Index");
            }


            return View(model);
        }
        public IActionResult Update(int? countersId)
        {
            if (countersId == null && countersId <= 0)
            {
                return NotFound();
            }


            Models.Counters counters = _counters.GetCounters(countersId);

            return View(counters);
        }

        [HttpPost]
        public IActionResult Update(Models.Counters model)
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
                _counters.UpdateCounters(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult Delete(int countersId)
        {
            _counters.DeleteCounters(countersId);

            return RedirectToAction("Index");
        }


    }
}
