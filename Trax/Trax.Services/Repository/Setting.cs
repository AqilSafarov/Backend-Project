using Trax.Services.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trax.Services.Repository
{
    public class Setting : ISetting
    {
        private readonly AppDbContext _context;

        public Setting(AppDbContext context)
        {
            _context = context;
        }

        public bool CheckSetting(Models.Setting model)
        {
            throw new NotImplementedException();
        }

        public Models.Setting CreateSetting(Models.Setting model)
        {
            _context.Setting.Add(model);
            _context.SaveChanges();
            return model;
        }

        public bool DeleteSetting(int id)
        {
            Models.Setting setting = _context.Setting.Find(id);
            _context.Setting.Remove(setting);
            if (_context.SaveChanges() > 0)
                return true;
            return false;
        }

        public Models.Setting GetSetting()
        {
            return _context.Setting.FirstOrDefault();
        }

        public Models.Setting UpdateSetting(Models.Setting model)
        {
            _context.Setting.Update(model);
            _context.SaveChanges();
            return model;
        }
        public Models.Setting FindSetting(int? settingId)
        {
            return _context.Setting.Find(settingId);
        }
    }
}
