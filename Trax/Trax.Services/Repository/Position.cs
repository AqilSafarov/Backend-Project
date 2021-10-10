using Trax.Services.Repository.IRepository;
using Trax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trax.Services.Repository
{
    public class Position : IPosition
    {
        private readonly AppDbContext _context;

        public Position(AppDbContext context)
        {
            _context = context;
        }

        public Models.Position CreatePosition(Models.Position model)
        {
            _context.Position.Add(model);
            _context.SaveChanges();
            return model;
        }

        public bool DeletePosition(int id)
        {
            Models.Position position = _context.Position.Find(id);
            _context.Position.Remove(position);
            if (_context.SaveChanges() > 0)
            {
                return true;
            }

            return false;
        }

        public Models.Position GetPosition()
        {
            return _context.Position.FirstOrDefault();
        }

        public List<Models.Position> GetPositions()
        {
            return _context.Position.ToList();
        }

        public Models.Position UpdatePosition(Models.Position model)
        {
            _context.Position.Update(model);
            _context.SaveChanges();
            return model;
        }
        public Models.Position GetPosition(int? id)
        {
            return _context.Position.Find(id);
        }
    }
}
