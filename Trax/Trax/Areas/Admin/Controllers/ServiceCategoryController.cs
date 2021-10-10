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
    public class ServiceCategoryController : Controller
    {
        private readonly IServiceCategory _serviceCategory;

        public ServiceCategoryController(IServiceCategory serviceCategory)
        {
            _serviceCategory = serviceCategory;
        }
        public IActionResult Index(int page = 1)
        {
            ViewBag.Active = "Social";
            List<Models.ServiceCategory> serviceCategory1 = _serviceCategory.GetServiceCategory();
            decimal dataPage = 3;
            decimal pageCount = Math.Ceiling(serviceCategory1.Count / dataPage);

            List<Models.ServiceCategory> serviceCategory2 = serviceCategory1.OrderByDescending(o => o.Id).Skip(Convert.ToInt32((page - 1) * dataPage)).Take((int)dataPage).ToList();
            ViewBag.CurrentPage = page;
            ViewBag.PageCount = pageCount;
            ViewBag.DataPage = dataPage;
            ViewBag.DataCount = serviceCategory1.Count;
            return View(serviceCategory2);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Models.ServiceCategory model)
        {
            if (ModelState.IsValid)
            {
                _serviceCategory.CreateServiceCategory(model);

                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Update(int serviceCategoryId)
        {
            if (serviceCategoryId <= 0)
            {
                return NotFound();
            }
            Models.ServiceCategory serviceCategory = _serviceCategory.GetServiceCategory(serviceCategoryId);
            return View(serviceCategory);
        }

        [HttpPost]
        public IActionResult Update(Models.ServiceCategory model)
        {
            if (ModelState.IsValid)
            {
                _serviceCategory.UpdateServiceCategory(model);

                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Duzgun duzelt!");
            return View();

        }
        public IActionResult Delete(int servicecategoryId)
        {
            _serviceCategory.DeleteServiceCategory(servicecategoryId);

            return RedirectToAction("Index");
        }


    }
}
