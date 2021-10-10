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
    public class ProcessController : Controller
    {
        private readonly IProcess _process;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProcessController(IProcess process, IWebHostEnvironment webHostEnvironment)
        {
            _process = process;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index(int page = 1)
        {
            ViewBag.Active = "Process";
            List<Models.Process> process1 = _process.GetProcess();
            decimal dataPage = 3;
            decimal pageCount = Math.Ceiling(process1.Count / dataPage);

            List<Models.Process> process2 = process1.OrderByDescending(o => o.Id).Skip(Convert.ToInt32((page - 1) * dataPage)).Take((int)dataPage).ToList();
            ViewBag.CurrentPage = page;
            ViewBag.PageCount = pageCount;
            ViewBag.DataPage = dataPage;
            ViewBag.DataCount = process1.Count;
            return View(process2);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Models.Process model)
        {
            if (ModelState.IsValid)
            {
                _process.CreateProcess(model);

                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Update(int processId)
        {
            if ( processId <= 0)
            {
                return NotFound();
            }
            Models.Process process = _process.GetProcessParam(processId);
            return View(process);
        }

        [HttpPost]
        public IActionResult Update(Models.Process model)
        {
            if (ModelState.IsValid)
            {
                _process.UpdateProcess(model);

                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Duzgun duzelt!");
            return View();

        }

        public IActionResult Delete(int processId)
        {
            _process.DeleteProcess(processId);
            return RedirectToAction("Index");
        }
    }
}
