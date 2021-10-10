using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trax.Services.Repository.IRepository;

namespace Trax.Services.Repository
{

    public class Partner : IPartner
    {
        private readonly AppDbContext _context;

        public Partner(AppDbContext context)
        {
            _context = context;
        }
        public Models.Partner CreatePartner(Models.Partner model)
        {
           _context.Partner.Add(model);
            _context.SaveChanges();
            return model;
        }

        public bool DeletePartner(int id)
        {
            Models.Partner partner = _context.Partner.Find(id);
            _context.Partner.Remove(partner);
            if (_context.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public List<Models.Partner> GetPartner()
        {
            return _context.Partner.ToList();
        }

        public Models.Partner GetPartner(int id)
        {
            return _context.Partner.Find(id);
        }

        public Models.Partner UpdatePartner(Models.Partner model)
        {
            _context.Partner.Update(model);
            _context.SaveChanges();
            return model;
        }
        public Models.Partner FindPartner(int? partnerId)
        {
            return _context.Partner.Find(partnerId);
        }
    }
}
