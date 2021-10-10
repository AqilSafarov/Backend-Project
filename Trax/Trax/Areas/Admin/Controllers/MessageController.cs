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
    public class MessageController : Controller
    {
        private readonly IMessage _message;
        private readonly AppDbContext _context;

        public MessageController(IMessage message,AppDbContext context)
        {
            _message = message;
            _context = context;
        }
        public IActionResult Index(int page = 1)
        {
            ViewBag.Active = "Message";
            List<Models.Message> _message1 = _message.GetMessages();
            decimal dataPage = 3;
            decimal pageCount = Math.Ceiling(_message1.Count / dataPage);

            List<Models.Message> message2 = _message1.OrderByDescending(o => o.Id).Skip(Convert.ToInt32((page - 1) * dataPage)).Take((int)dataPage).ToList();
            ViewBag.CurrentPage = page;
            ViewBag.PageCount = pageCount;
            ViewBag.DataPage = dataPage;
            ViewBag.DataCount = _message1.Count;
            return View(message2);
        }
    }
}
