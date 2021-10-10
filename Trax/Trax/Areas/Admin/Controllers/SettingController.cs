using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
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

    public class SettingController : Controller
    {
        private readonly ISetting _setting;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public SettingController(ISetting setting, IWebHostEnvironment webHostEnvironment)
        {
            _setting = setting;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            ViewBag.Active = "Setting";
            return View(_setting.GetSetting());
        }
        
        public IActionResult Update(int? settingId)
        {
            if (settingId == null && settingId <= 0)
            {
                return NotFound();
            }
            Models.Setting setting = _setting.FindSetting(settingId);
            return View(setting);
        }
        [HttpPost]
        public IActionResult Update(Models.Setting model)
        {
            if (ModelState.IsValid)
            {
                if (model.ImageFile != null )
                {
                    if (!((model.ImageFile.ContentType == "image/png")))
                    {
                        ModelState.AddModelError("", "You can upload only png file");
                        return View(model);
                    }
                    if (model.ImageFile.Length > 2097152 )
                    {
                        ModelState.AddModelError("", "You can only upload 2mb file");
                        return View(model);
                    }
                    string fileName = Guid.NewGuid() + "-" + DateTime.Now.ToString("ddMMyyyyHHmmss") + "-" + model.ImageFile.FileName;
                    string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        model.ImageFile.CopyTo(stream);
                    }
                    
                    model.Logo = fileName;
                }
                _setting.UpdateSetting(model);


                return RedirectToAction("Index");
            }

            return View(model);

        }


    }
}
