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

    public class MainContactController : Controller
    {
        private readonly IContact _contact;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly AppDbContext _context;

        public MainContactController(IContact contact, IWebHostEnvironment webHostEnvironment, AppDbContext context)
        {
            _contact = contact;
            _webHostEnvironment = webHostEnvironment;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
