using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trax.Services.Repository.IRepository;

namespace Trax.Services.Repository
{
    public class MobileApp : IMobileApp
    {
        private readonly AppDbContext _context;

        public MobileApp(AppDbContext context)
        {
            _context = context;
        }
        public Models.MobileApp CreateMobileApp(Models.MobileApp model)
        {
            _context.MobileApp.Add(model);
            _context.SaveChanges();
            return model;
        }

        public bool DeleteMobileApp(int id)
        {
            Models.MobileApp mobileApp = _context.MobileApp.Find(id);
            _context.MobileApp.Remove(mobileApp);
            if (_context.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public List<Models.MobileApp> GetMobileApp()
        {
            return _context.MobileApp.ToList();
        }
        public Models.MobileApp GetMobileApp(int id)
        {
            return _context.MobileApp.Find(id);
        }

        public Models.MobileApp UpdateMobileApp(Models.MobileApp model)
        {
            _context.MobileApp.Update(model);
            _context.SaveChanges();
            return model;
        }
    }
}
