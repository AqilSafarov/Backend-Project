using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trax.Services.Repository.IRepository;

namespace Trax.Services.Repository
{
    public class MobileAppDetail : IMobileAppDetail
    {
        private readonly AppDbContext _context;

        public MobileAppDetail(AppDbContext context)
        {
            _context = context;
        }
        public Models.MobileAppDetail CreateMobileAppDetail(Models.MobileAppDetail model)
        {
            _context.MobileAppDetail.Add(model);
            _context.SaveChanges();
            return model;
        }

        public bool DeleteMobileAppDetail(int id)
        {
            Models.MobileAppDetail mobileAppDetail = _context.MobileAppDetail.Find(id);
            _context.MobileAppDetail.Remove(mobileAppDetail);
            if (_context.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public Models.MobileAppDetail GetMobileAppDetail(int id)
        {
            return _context.MobileAppDetail.Find(id);
        }

        public List<Models.MobileAppDetail> GetMobileAppDetail()
        {
            return _context.MobileAppDetail.ToList();
        }

        public Models.MobileAppDetail UpdateMobileAppDetail(Models.MobileAppDetail model)
        {
            _context.MobileAppDetail.Update(model);
            _context.SaveChanges();
            return model;
        }
    }
}
