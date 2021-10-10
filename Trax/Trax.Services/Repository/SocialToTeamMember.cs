using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trax.Services.Repository.IRepository;

namespace Trax.Services.Repository
{
    public class SocialToTeamMember : ISocialToTeamMember
    {

        private readonly AppDbContext _context;

        public SocialToTeamMember(AppDbContext context)
        {
            _context = context;
        }
        public Models.SocialToTeamMember CreateSocialToTeamMember(Models.SocialToTeamMember model)
        {
            _context.SocialToTeamMember.Add(model);
            _context.SaveChanges();
            return model;
        }

        public bool DeleteSocialToTeamMember(int id)
        {
            Models.SocialToTeamMember SocialToTeamMember = _context.SocialToTeamMember.Find(id);
            _context.SocialToTeamMember.Remove(SocialToTeamMember);
            if (_context.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public List<Models.SocialToTeamMember> GetSocialToTeamMember()
        {
            return _context.SocialToTeamMember.ToList();
        }

        public Models.SocialToTeamMember GetSocialToTeamMember(int id)
        {
            return _context.SocialToTeamMember.Find(id);
        }

        public Models.SocialToTeamMember UpdateSocialToTeamMember(Models.SocialToTeamMember model)
        {
            _context.SocialToTeamMember.Update(model);
            _context.SaveChanges();
            return model;
        }
        public List<Models.SocialToTeamMember> OldMember(Models.TeamMember model)
        {
            return _context.SocialToTeamMember.Where(s => s.TeamMemberId == model.Id).ToList();
        }
        public void Remover(List<Models.SocialToTeamMember> model)
        {
            _context.SocialToTeamMember.RemoveRange(model);
        }
    }
}
