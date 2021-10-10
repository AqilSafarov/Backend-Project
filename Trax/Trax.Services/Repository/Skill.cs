using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trax.Services.Repository.IRepository;

namespace Trax.Services.Repository
{
    public class Skill : ISkill
    {
        private readonly AppDbContext _context;

        public Skill(AppDbContext context)
        {
            _context = context;
        }
        public Models.Skill CreateSkill(Models.Skill model)
        {
            _context.Skill.Add(model);
            _context.SaveChanges();
            return model;
        }

        public bool DeleteSkill(int id)
        {
            Models.Skill Skill = _context.Skill.Find(id);
            _context.Skill.Remove(Skill);
            if (_context.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public List<Models.Skill> GetSkill()
        {
            return _context.Skill.ToList();
        }

        public Models.Skill GetSkill(int id)
        {
            return _context.Skill.Find(id);
        }

        public Models.Skill UpdateSkill(Models.Skill model)
        {
            _context.Skill.Update(model);
            _context.SaveChanges();
            return model;
        }
    }
}
