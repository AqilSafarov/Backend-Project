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
    [Area("Admin"), Authorize(Roles = "Admin,Moderator")]
    public class TeamMemberController : Controller
    {
        private readonly ITeamMember _teamMember;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ISocial _social;
        private readonly IPosition _position;
        private readonly ISocialToTeamMember _socialToTeamMember;

        public TeamMemberController(ITeamMember teamMember,IWebHostEnvironment webHostEnvironment, ISocial social, IPosition position, ISocialToTeamMember socialToTeamMember)
        {
            _teamMember = teamMember;
            _webHostEnvironment = webHostEnvironment;
            _social = social;
            _position = position;
            _socialToTeamMember = socialToTeamMember;
        }
        public IActionResult Index(int page=1)
        {
            ViewBag.Active = "TeamMember";
            List<Models.TeamMember> teammember1 = _teamMember.GetTeamMember(); 
            decimal dataPage = 3;
            decimal pageCount = Math.Ceiling(teammember1.Count / dataPage);

            List<Models.TeamMember> teammember2 = teammember1.OrderByDescending(o => o.Id).Skip(Convert.ToInt32((page - 1) * dataPage)).Take((int)dataPage).ToList();
            ViewBag.CurrentPage = page;
            ViewBag.PageCount = pageCount;
            ViewBag.DataPage = dataPage;
            ViewBag.DataCount = teammember1.Count;
            return View(teammember2);
        }

        public IActionResult Create()
        {
            ViewBag.Position = _position.GetPositions();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Models.TeamMember model)
        {
            if (ModelState.IsValid)
            {
                //List<Models.SocialToTeamMember> newSocialToTeamMembers = model.SocialToTeamMembers;
                if (model.ImageFile != null)
                {
                    if (!(model.ImageFile.ContentType == "image/png" || model.ImageFile.ContentType == "image/jpeg" || model.ImageFile.ContentType == "image/gif"))
                    {
                        ModelState.AddModelError("", "You can only upload jpeg, png, and gif");
                        ViewBag.Social = _social.GetSocials();
                        ViewBag.Position = _position.GetPositions();
                        return View(model);
                    }

                    if (model.ImageFile.Length > 2097152)
                    {
                        ModelState.AddModelError("", "You can only upload max 2 Mb size images");
                        ViewBag.Social = _social.GetSocials();
                        ViewBag.Position = _position.GetPositions();
                        return View(model);
                    }

                    string fileName = Guid.NewGuid() + "-" + DateTime.Now.ToString("ddMMyyyyHHmmss") + "-" + model.ImageFile.FileName;
                    string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        model.ImageFile.CopyTo(stream);
                    }

                    model.Image = fileName;
                }


                //model.SocialToTeamMembers = null;
                _teamMember.CreateTeamMember(model);
                //foreach (var item in newSocialToTeamMembers)
                //{
                //    if (item.SocialId > 0 && item.Social != null)
                //    {
                //        Models.SocialToTeamMember socialToTeamMember = new Models.SocialToTeamMember()
                //        {
                //            TeamMemberId = model.Id,
                //            SocialId = item.SocialId

                //        };
                //        _socialToTeamMember.CreateSocialToTeamMember(socialToTeamMember);
                //    }
                //}

                _teamMember.Save(model);
                return RedirectToAction("Index");
            }

            //ViewBag.Social = _social.GetSocials();
            ViewBag.Position = _position.GetPositions();
            return View(model);
        }

        public IActionResult Update(int? memberId)
        {
            if (memberId == null && memberId <= 0)
            {
                return NotFound();
            }
            //ViewBag.Social = _social.GetSocials();
            ViewBag.Position = _position.GetPositions();

            Models.TeamMember team = _teamMember.GetTeamMember(memberId);

            return View(team);
        }

        [HttpPost]
        public IActionResult Update(Models.TeamMember model)
        {
            if (ModelState.IsValid)
            {
                //List<Models.SocialToTeamMember> newSocialToTeamMembers = model.SocialToTeamMembers;
                //List<Models.SocialToTeamMember> OldSocialToTeamMembers = _socialToTeamMember.OldMember(model);
                if (model.ImageFile != null)
                {
                    if (!(model.ImageFile.ContentType == "image/png" || model.ImageFile.ContentType == "image/jpeg" || model.ImageFile.ContentType == "image/gif"))
                    {
                        ModelState.AddModelError("", "You can only upload jpeg, png, and gif");
                        ViewBag.Social = _social.GetSocials();
                        ViewBag.Position = _position.GetPositions();
                        return View(model);
                    }

                    if (model.ImageFile.Length > 2097152)
                    {
                        ModelState.AddModelError("", "You can only upload max 2 Mb size images");
                        ViewBag.Social = _social.GetSocials();
                        ViewBag.Position = _position.GetPositions();
                        return View(model);
                    }

                    string fileName = Guid.NewGuid() + "-" + DateTime.Now.ToString("ddMMyyyyHHmmss") + "-" + model.ImageFile.FileName;
                    string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        model.ImageFile.CopyTo(stream);
                    }

                    model.Image = fileName;
                }


                //model.SocialToTeamMembers = null;
                _teamMember.UpdateTeamMember(model);
                //_socialToTeamMember.Remover(OldSocialToTeamMembers);
                //foreach (var item in newSocialToTeamMembers)
                //{
                //    if (item.SocialId > 0 && item.Social != null)
                //    {
                //        Models.SocialToTeamMember socialToTeamMember = new Models.SocialToTeamMember()
                //        {
                //            TeamMemberId = model.Id,
                //            SocialId = item.SocialId

                //        };
                //        _socialToTeamMember.CreateSocialToTeamMember(socialToTeamMember);
                //    }
                //}

                _teamMember.Save(model);
                return RedirectToAction("Index");
            }

            //ViewBag.Social = _social.GetSocials();
            ViewBag.Position = _position.GetPositions();
            return View(model);
        }

        public IActionResult Delete(int memberId)
        {
            _teamMember.DeleteTeamMember(memberId);

            return RedirectToAction("Index");
        }

        public JsonResult GetTags()
        {
            List<Models.Social> socials = _social.GetSocials();
            return Json(socials);
        }
    }
}
