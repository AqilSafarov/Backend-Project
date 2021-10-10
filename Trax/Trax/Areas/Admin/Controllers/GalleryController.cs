using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
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

    public class GalleryController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IGallery _gallery;
        private readonly IGalleryCategory _galleryCategory;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public GalleryController(AppDbContext context, UserManager<IdentityUser> userManager,
                                SignInManager<IdentityUser> signInManager, IGallery gallery, IGalleryCategory galleryCategory, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _gallery = gallery;
            _galleryCategory = galleryCategory;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index(int page = 1)
        {
            ViewBag.Active = "Gallery";
            List<Models.Gallery> gallery1 = _gallery.GetGallery();
            decimal dataPage = 3;
            decimal pageCount = Math.Ceiling(gallery1.Count / dataPage);

            List<Models.Gallery> gallery2 = gallery1.OrderByDescending(o => o.Id).Skip(Convert.ToInt32((page - 1) * dataPage)).Take((int)dataPage).ToList();
            ViewBag.CurrentPage = page;
            ViewBag.PageCount = pageCount;
            ViewBag.DataPage = dataPage;
            ViewBag.DataCount = gallery1.Count;
            return View(gallery2);
        }
        public IActionResult Create()
        {
            ViewBag.GalleryCategory = _galleryCategory.GetGalleryCategory();

            return View();
        }
        [HttpPost]
        public IActionResult Create(Gallery model)
        {

            if (ModelState.IsValid)
            {

                if (model.ImageFile != null)
                {
                    if (!(model.ImageFile.ContentType == "image/png" || model.ImageFile.ContentType == "image/jpeg" || model.ImageFile.ContentType == "image/gif"))
                    {
                        ModelState.AddModelError("", "You can only upload jpeg, png, and gif");
                        ViewBag.GalleryCategory = _galleryCategory.GetGalleryCategory();


                        return View(model);
                    }

                    if (model.ImageFile.Length > 2097152)
                    {
                        ModelState.AddModelError("", "You can only upload max 2 Mb size images");
                        ViewBag.GalleryCategory = _galleryCategory.GetGalleryCategory();


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



                _gallery.CreateGallery(model);



                return RedirectToAction("Index");
            }


            return View(model);
        }

        public IActionResult Update(int? galleryId)
        {
            if (galleryId == null && galleryId <= 0)
            {
                return NotFound();
            }


            Gallery gallery = _gallery.GetGallery(galleryId);
            ViewBag.GalleryCategory = _galleryCategory.GetGalleryCategory();

            return View(gallery);
        }

        [HttpPost]
        public IActionResult Update(Gallery model)
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
                _gallery.UpdateGallery(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult Delete(int galleryId)
        {
            _gallery.DeleteGallery(galleryId);

            return RedirectToAction("Index");
        }
    }
}
