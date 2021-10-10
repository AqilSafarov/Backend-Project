using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trax.Services.Repository.IRepository;

namespace Trax.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles="Admin,Moderator")]
    public class GalleryCategoryController : Controller
    {
        private readonly IGalleryCategory _galleryCategory;

        public GalleryCategoryController(IGalleryCategory galleryCategory)
        {
            _galleryCategory = galleryCategory;
        }
        public IActionResult Index(int page = 1)
        {
            ViewBag.Active = "Social";
            List<Models.GalleryCategory> galleryCategory1 = _galleryCategory.GetGalleryCategory();
            decimal dataPage = 3;
            decimal pageCount = Math.Ceiling(galleryCategory1.Count / dataPage);

            List<Models.GalleryCategory> galleryCategory2 = galleryCategory1.OrderByDescending(o => o.Id).Skip(Convert.ToInt32((page - 1) * dataPage)).Take((int)dataPage).ToList();
            ViewBag.CurrentPage = page;
            ViewBag.PageCount = pageCount;
            ViewBag.DataPage = dataPage;
            ViewBag.DataCount = galleryCategory1.Count;
            return View(galleryCategory2);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Models.GalleryCategory model)
        {
            if (ModelState.IsValid)
            {
                _galleryCategory.CreateGalleryCategory(model);

                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult Update(int gallerycategoryId)
        {
            if (gallerycategoryId == null && gallerycategoryId <= 0)
            {
                return NotFound();
            }
            Models.GalleryCategory galleryCategory = _galleryCategory.GetGalleryCategory(gallerycategoryId);
            return View(galleryCategory);
        }

        [HttpPost]
        public IActionResult Update(Models.GalleryCategory model)
        {
            if (ModelState.IsValid)
            {
                _galleryCategory.UpdateGalleryCategory(model);

                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Duzgun duzelt!");
            return View();

        }
        public IActionResult Delete(int gallerycategoryId)
        {
            _galleryCategory.DeleteGalleryCategory(gallerycategoryId);

            return RedirectToAction("Index");
        }

    }
}
