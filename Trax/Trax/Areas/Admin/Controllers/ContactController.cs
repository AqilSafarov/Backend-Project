using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trax.Models;
using Trax.Services;
using Trax.Services.Repository.IRepository;

namespace Trax.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles = "Admin, Moderator")]
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IContact _contact;

        public ContactController(AppDbContext context,IContact contact)
        {
            _context = context;
            _contact = contact;
        }
        public IActionResult Index(int page = 1)
        {
            ViewBag.Active = "Contact";
            List<Models.Contact> contact1 = _contact.GetContacts();
            decimal dataPage = 3;
            decimal pageCount = Math.Ceiling(contact1.Count / dataPage);

            List<Models.Contact> contact2 = contact1.OrderByDescending(o => o.Id).Skip(Convert.ToInt32((page - 1) * dataPage)).Take((int)dataPage).ToList();
            ViewBag.CurrentPage = page;
            ViewBag.PageCount = pageCount;
            ViewBag.DataPage = dataPage;
            ViewBag.DataCount = contact1.Count;
            return View(contact2);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Contact model)
        {

            if (ModelState.IsValid)
            {





                _contact.CreateContact(model);



                return RedirectToAction("Index");
            }


            return View(model);
        }

        public IActionResult Update(int? contactId)
        {
            if (contactId == null && contactId <= 0)
            {
                return NotFound();
            }
            Models.Contact contact = _contact.FindContact(contactId);
            return View(contact);
        }
          [HttpPost]
        public IActionResult Update(Models.Contact model)
        {
            if (ModelState.IsValid)
            {
                _contact.UpdateContact(model);
                return RedirectToAction("Index");
            }

            return View(model);

        }

    }
}
