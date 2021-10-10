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
    public class TeamController : Controller
    {
        private readonly ISubscribe _subscribe;
        private readonly IPosition _position;
        private readonly ITeamMember _teamMember;
        private readonly ISocialToTeamMember _socialToTeamMember;
        private readonly AppDbContext _context;
        private readonly ISocial _social;

        public TeamController(ISubscribe subscribe, IPosition position, ITeamMember teamMember, ISocialToTeamMember socialToTeamMember, AppDbContext context,ISocial social)
        {
            _subscribe = subscribe;
            _position = position;
            _teamMember = teamMember;
            _socialToTeamMember = socialToTeamMember;
            _context = context;
            _social = social;
        }
        public IActionResult Index()
        {
            VmTeamMem model = new VmTeamMem()
            {
                TeamMember = _teamMember.GetTeamMember(),
                SocialToTeamMember = _socialToTeamMember.GetSocialToTeamMember(),
                Social= _social.GetSocials(),
                Position=_position.GetPosition()

            };

            //List<TeamMember> teamMembers= _teamMember.GetTeamMember();
            return View(model);
        }
       
    }
}
