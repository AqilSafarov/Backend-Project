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
    public class PartnerController : Controller
    {
        private readonly IPartner _partner;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly AppDbContext _context;

        public PartnerController(IPartner partner, IWebHostEnvironment webHostEnvironment, AppDbContext context)
        {
            _partner = partner;
            _webHostEnvironment = webHostEnvironment;
            _context = context;
        }
        public IActionResult Index(int page=1)
        {
            ViewBag.Active = "Partner";
            List<Models.Partner> partner1 = _partner.GetPartner();
            decimal dataPage = 3;
            decimal pageCount = Math.Ceiling(partner1.Count / dataPage);

            List<Models.Partner> partner2 = partner1.OrderByDescending(o => o.Id).Skip(Convert.ToInt32((page - 1) * dataPage)).Take((int)dataPage).ToList();
            ViewBag.CurrentPage = page;
            ViewBag.PageCount = pageCount;
            ViewBag.DataPage = dataPage;
            ViewBag.DataCount = partner1.Count;
            return View(partner2);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Models.Partner model)
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



                _partner.CreatePartner(model);



                return RedirectToAction("Index");
            }


            return View(model);
        }
        public IActionResult Update(int? partnerId)
        {
            if (partnerId == null && partnerId <= 0)
            {
                return NotFound();
            }
            Models.Partner partner = _partner.FindPartner(partnerId);
            return View(partner);
        }

        [HttpPost]
        public IActionResult Update(Models.Partner model)
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

                    model.Image = fileName;
                }
                _partner.UpdatePartner(model);


                return RedirectToAction("Index");
            }

            return View(model);

        }
        public IActionResult Delete(int partnerId)
        {
            _partner.DeletePartner(partnerId);

            return RedirectToAction("Index");
        }
    }
}
