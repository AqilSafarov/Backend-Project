using Trax.Models;
using Trax.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trax.Services.Repository.IRepository;
using Trax.ViewModels;

namespace Trax.ViewComponents
{
    public class VcExpert : ViewComponent
    { private readonly ISubscribe _subscribe;
        private readonly IPosition _position;
        private readonly ITeamMember _teamMember;
        private readonly ISocialToTeamMember _socialToTeamMember;
        private readonly AppDbContext _context;
        private readonly ISocial _social;
        private readonly IExpert _expert;

        public VcExpert(ISubscribe subscribe, IPosition position, ITeamMember teamMember, ISocialToTeamMember socialToTeamMember, AppDbContext context,ISocial social,IExpert expert)
        {
            _subscribe = subscribe;
            _position = position;
            _teamMember = teamMember;
            _socialToTeamMember = socialToTeamMember;
            _context = context;
            _social = social;
            _expert = expert;
        }
        public IViewComponentResult Invoke()
        {
            VmTeamMem model = new VmTeamMem()
            {
                Expert = _expert.GetExpert(),
                TeamMember = _teamMember.GetTeamMember(),
                SocialToTeamMember = _socialToTeamMember.GetSocialToTeamMember(),
                Social = _social.GetSocials(),
                Position = _position.GetPosition()

            };

            return View(model);
        }
    }
}
