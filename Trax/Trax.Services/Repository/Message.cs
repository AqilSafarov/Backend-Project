using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trax.Services.Repository.IRepository;

namespace Trax.Services.Repository
{
    public class Message : IMessage
    {
        private readonly AppDbContext _context;

        public Message(AppDbContext context)
        {
            _context = context;
        }
        public Models.Message CreateMessage(Models.Message model)
        {
            _context.Message.Add(model);
            _context.SaveChanges();
            return model;
        }

        public bool DeleteMessage(int id)
        {
            Models.Message message = _context.Message.Find(id);
            _context.Message.Remove(message);
            if (_context.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        

        public Models.Message GetMessage()
        {
            return _context.Message.FirstOrDefault();
        }
        public bool GetMessage(string email)
        {
            return _context.Message.Any(e => e.Email == email);

        }

        public Models.Message UpdateMessage(Models.Message model)
        {

            _context.Message.Update(model);
            _context.SaveChanges();
            return model;
        }

        public List<Models.Message> GetMessages()
        {
            return _context.Message.ToList();
        }
    }
}
