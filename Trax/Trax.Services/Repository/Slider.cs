using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trax.Services.Repository.IRepository;

namespace Trax.Services.Repository
{
    public class Slider : ISlider
    {
        private readonly AppDbContext _context;

        public Slider(AppDbContext context)
        {
            _context = context;
        }
        public Models.Slider CreateSlider(Models.Slider model)
        {
            _context.Slider.Add(model);
            _context.SaveChanges();
            return model;
        }

        public bool DeleteSlider(int id)
        {
            Models.Slider Slider = _context.Slider.Find(id);
            _context.Slider.Remove(Slider);
            if (_context.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public List<Models.Slider> GetSlider()
        {
            return _context.Slider.ToList();
        }

        public Models.Slider GetSlider(int id)
        {
            return _context.Slider.Find(id);
        }

        public Models.Slider UpdateSlider(Models.Slider model)
        {
            _context.Slider.Update(model);
            _context.SaveChanges();
            return model;
        }
        public Models.Slider FindSlider(int? sliderId)
        {
            return _context.Slider.Find(sliderId);
        }
    }
}
