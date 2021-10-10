using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trax.Services;
using Trax.Services.Repository.IRepository;

namespace Trax.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles = "Admin,Moderator")]
    public class ConsultationController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IConsultation _consultation;

        public ConsultationController(IConsultation consultation,AppDbContext context)
        {
            _context = context;
            _consultation = consultation;
        }
        public IActionResult Index(int page = 1)
        {
            ViewBag.Active = "Message";
            List<Models.Consultation> _consultation1 = _consultation.GetConsultations();
            decimal dataPage = 3;
            decimal pageCount = Math.Ceiling(_consultation1.Count / dataPage);

            List<Models.Consultation> _consultation2 = _consultation1.OrderByDescending(o => o.Id).Skip(Convert.ToInt32((page - 1) * dataPage)).Take((int)dataPage).ToList();
            ViewBag.CurrentPage = page;
            ViewBag.PageCount = pageCount;
            ViewBag.DataPage = dataPage;
            ViewBag.DataCount = _consultation1.Count;
            return View(_consultation2);
        }
    }
}
