using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Trax.Services.Repository.IRepository;

namespace Trax.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles = "Admin, Moderator")]

    public class ExpertController : Controller
    {
        private readonly IExpert _expert;

        public ExpertController(IExpert expert)
        {
            _expert = expert;
        }
        public IActionResult Index(int page = 1)
        {
            ViewBag.Active = "Expert";
            List<Models.Expert> expert1 = _expert.GetExperts();
            decimal dataPage = 3;
            decimal pageCount = Math.Ceiling(expert1.Count / dataPage);

            List<Models.Expert> expert2 = expert1.OrderByDescending(o => o.Id).Skip(Convert.ToInt32((page - 1) * dataPage)).Take((int)dataPage).ToList();
            ViewBag.CurrentPage = page;
            ViewBag.PageCount = pageCount;
            ViewBag.DataPage = dataPage;
            ViewBag.DataCount = expert1.Count;
            return View(expert2);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Models.Expert model)
        {
            if (ModelState.IsValid)
            {
                _expert.CreateExpert(model);



                return RedirectToAction("Index");
            }


            return View(model);
        }
        public IActionResult Update(int? expertId)
        {
            if (expertId == null && expertId <= 0)
            {
                return NotFound();
            }
            Models.Expert expert = _expert.FindExpert(expertId);
            return View(expert);
        }
        [HttpPost]
        public IActionResult Update(Models.Expert model)
        {
            if (ModelState.IsValid)
            {
                _expert.UpdateExpert(model);


                return RedirectToAction("Index");
            }

            return View(model);

        }
        public IActionResult Delete(int expertId)
        {
            _expert.DeleteExpert(expertId);

            return RedirectToAction("Index");
        }

    }
}
