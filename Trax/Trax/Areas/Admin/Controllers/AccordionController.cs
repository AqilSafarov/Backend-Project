using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trax.Services;
using Trax.Services.Repository.IRepository;

namespace Trax.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles = "Admin, Moderator")]

    public class AccordionController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly AppDbContext _context;
        private readonly IAccordion _accrodion;

        public AccordionController( IWebHostEnvironment webHostEnvironment, AppDbContext context,IAccordion accrodion)
        {
            _webHostEnvironment = webHostEnvironment;
            _context = context;
            _accrodion = accrodion;
        }
        public IActionResult Index(int page = 1)
        {
            ViewBag.Active = "Accordion";
            List<Models.Accordion> accordion1 = _accrodion.GetAccordion();
            decimal dataPage = 3;
            decimal pageCount = Math.Ceiling(accordion1.Count / dataPage);

            List<Models.Accordion> accordion2 = accordion1.OrderByDescending(o => o.Id).Skip(Convert.ToInt32((page - 1) * dataPage)).Take((int)dataPage).ToList();
            ViewBag.CurrentPage = page;
            ViewBag.PageCount = pageCount;
            ViewBag.DataPage = dataPage;
            ViewBag.DataCount = accordion1.Count;
            return View(accordion2);
        }
    }
}
