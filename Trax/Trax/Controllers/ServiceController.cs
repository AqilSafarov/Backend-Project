using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trax.Models;
using Trax.Services;
using Trax.Services.Repository.IRepository;
using Trax.ViewModels;

namespace Trax.Controllers
{
    public class ServiceController : Controller
    {
        private readonly ISubscribe _subscribe;
        private readonly AppDbContext _context;
        private readonly IService _service;
        private readonly IServiceCategory _serviceCategory;
        private readonly IServiceImage _serviceImage;
        private readonly ISetting _setting;
        private readonly IAccordion _accordion;
        private readonly IConsultation _consultation;

        public ServiceController(ISubscribe subscribe,AppDbContext context,IService service,IServiceCategory serviceCategory,IServiceImage serviceImage,ISetting setting,IAccordion accordion,IConsultation consultation)
        {
            _subscribe = subscribe;
            _context = context;
            _service = service;
            _serviceCategory = serviceCategory;
            _serviceImage = serviceImage;
            _setting = setting;
            _accordion = accordion;
            _consultation = consultation;
        }
        public IActionResult Index()
        {
            VmService model = new VmService()
            {
                ServiceCategory = _serviceCategory.GetServiceCategory(),
                ServiceImage = _serviceImage.GetServiceImage(),
                Service = _service.GetService(),


            };
            return View(model);
        }
        public IActionResult Details(int? serviceId)
        {
            VmServiceTwo model = new VmServiceTwo()
            {
                Service = _service.GetService(serviceId),
                ServiceCategory = _serviceCategory.GetServiceCategory(),
                Setting = _setting.GetSetting(),
                ServiceImage = _serviceImage.GetServiceImage(),
                Accordion=_accordion.GetAccordion(),
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Consultation(VmServiceTwo model)
        {
            if (ModelState.IsValid)
            {
                model.Consultation.CreatedDate = DateTime.Now;
                _consultation.CreateConsultation(model.Consultation);
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index", "Service");
        }

    }
}
