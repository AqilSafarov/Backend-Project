using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    [Area("Admin")]
    public class ServiceController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IService _service;
        private readonly IServiceCategory _serviceCategory;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ServiceController(AppDbContext context, UserManager<IdentityUser> userManager,
                                SignInManager<IdentityUser> signInManager,IService service,IServiceCategory serviceCategory, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _service = service;
            _serviceCategory = serviceCategory;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index(int page = 1)
        {
            ViewBag.Active = "Service";
            List<Models.Service> service1 = _service.GetService();
            decimal dataPage = 3;
            decimal pageCount = Math.Ceiling(service1.Count / dataPage);

            List<Models.Service> service2 = service1.OrderByDescending(o => o.Id).Skip(Convert.ToInt32((page - 1) * dataPage)).Take((int)dataPage).ToList();
            ViewBag.CurrentPage = page;
            ViewBag.PageCount = pageCount;
            ViewBag.DataPage = dataPage;
            ViewBag.DataCount = service1.Count;
            return View(service2);
        }

        public IActionResult Create()
        {
            ViewBag.ServiceCategory = _serviceCategory.GetServiceCategory();

            return View();
        }
        [HttpPost]
        public IActionResult Create(Service model)
        {

            if (ModelState.IsValid)
            {

                if (model.ImageFile != null)
                {
                    if (!(model.ImageFile.ContentType == "image/png" || model.ImageFile.ContentType == "image/jpeg" || model.ImageFile.ContentType == "image/gif"))
                    {
                        ModelState.AddModelError("", "You can only upload jpeg, png, and gif");
                        ViewBag.ServiceCategory = _serviceCategory.GetServiceCategory();


                        return View(model);
                    }

                    if (model.ImageFile.Length > 2097152)
                    {
                        ModelState.AddModelError("", "You can only upload max 2 Mb size images");
                        ViewBag.ServiceCategory = _serviceCategory.GetServiceCategory();


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



                _service.CreateService(model);



                return RedirectToAction("Index");
            }


            return View(model);
        }
        public IActionResult Update(int? serviceId)
        {
            if (serviceId == null && serviceId <= 0)
            {
                return NotFound();

            }
            Service service = _service.FindService(serviceId);
            ViewBag.ServiceCategory = _serviceCategory.GetServiceCategory();

            return View(service);
        }


        [HttpPost]
        public IActionResult Update(Models.Service model)
        {
            if (ModelState.IsValid)
            {
                if (model.ImageFile != null)
                {
                    if (!((model.ImageFile.ContentType == "image/png")))
                    {
                        ModelState.AddModelError("", "You can upload only png file");
                        ViewBag.ServiceCategory = _serviceCategory.GetServiceCategory();

                        return View(model);
                    }
                    if (model.ImageFile.Length > 2097152)
                    {
                        ModelState.AddModelError("", "You can only upload 2mb file");
                        ViewBag.ServiceCategory = _serviceCategory.GetServiceCategory();

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
                _service.UpdateService(model);


                return RedirectToAction("Index");
            }

            return View(model);

        }
        public IActionResult Delete(int serviceId)
        {
            _service.DeleteService(serviceId);

            return RedirectToAction("Index");
        }
    }
}
