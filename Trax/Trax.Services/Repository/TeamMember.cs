using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trax.Services.Repository.IRepository;

namespace Trax.Services.Repository
{
    public class TeamMember : ITeamMember
    {
        private readonly AppDbContext _context;

        public TeamMember(AppDbContext context)
        {
            _context = context;
        }
        public Models.TeamMember CreateTeamMember(Models.TeamMember model)
        {
            _context.TeamMember.Add(model);
            _context.SaveChanges();
            return model;
        }

        public bool DeleteTeamMember(int id)
        {
            Models.TeamMember TeamMember = _context.TeamMember.Find(id);
            _context.TeamMember.Remove(TeamMember);
            if (_context.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public List<Models.TeamMember> GetTeamMember()
        {
            return _context.TeamMember.Include(c => c.SocialToTeamMembers).ThenInclude(s => s.Social)
                                                .Include(c => c.Position)
                                                .ToList();
        }

        public Models.TeamMember GetTeamMember(int? id)
        {
            return _context.TeamMember.Include(c => c.SocialToTeamMembers).ThenInclude(s => s.Social)
                                                .Include(c => c.Position)
                                                .FirstOrDefault(p => p.Id == id);
        }

        public Models.TeamMember UpdateTeamMember(Models.TeamMember model)
        {
            _context.TeamMember.Update(model);
            _context.SaveChanges();
            return model;
        }
        public Models.TeamMember Save(Models.TeamMember model)
        {
            _context.SaveChanges();
            return model;
        }

    }
}
