using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trax.Services.Repository.IRepository;

namespace Trax.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles = "Moderator,Admin")]
    public class ProcessTypeController : Controller
    {
        private readonly IProcessType _prcocessType;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProcessTypeController(IProcessType prcocessType, IWebHostEnvironment webHostEnvironment)
        {
            _prcocessType = prcocessType;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index(int page = 1)
        {
            //ViewBag.Active = "ProcessType";
            //List<Models.ProcessType> processType1 = processType1.GetProcessType();
            //decimal dataPage = 3;
            //decimal pageCount = Math.Ceiling(processType1.Count / dataPage);

            //List<Models.ProcessType> processType2 = processType1.OrderByDescending(o => o.Id).Skip(Convert.ToInt32((page - 1) * dataPage)).Take((int)dataPage).ToList();
            //ViewBag.CurrentPage = page;
            //ViewBag.PageCount = pageCount;
            //ViewBag.DataPage = dataPage;
            //ViewBag.DataCount = processType1.Count;
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Models.ProcessType model)
        {
            if (ModelState.IsValid)
            {
                _prcocessType.CreateProcessType(model);

                return RedirectToAction("Index");
            }
            return View(model);
        }

        //public IActionResult Update(int? processTypeId)
        //{
        //    if (processTypeId == null && processTypeId <= 0)
        //    {
        //        return NotFound();
        //    }
        //    Models.ProcessType processType = _prcocessType.GetProcessType(processTypeId);
        //    return View(processType);
        //}

        [HttpPost]
        public IActionResult Update(Models.ProcessType model)
        {
            if (ModelState.IsValid)
            {
                _prcocessType.UpdateProcessType(model);

                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Duzgun duzelt!");
            return View();

        }

        public IActionResult Delete(int processTypeId)
        {
            _prcocessType.DeleteProcessType(processTypeId);
            return RedirectToAction("Index");
        }
    }
}
