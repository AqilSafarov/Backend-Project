using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trax.Services.Repository.IRepository;

namespace Trax.Services.Repository
{

    public class Contact : IContact
    {
        private readonly AppDbContext _context;

        public Contact(AppDbContext context)
        {
            _context = context;
        }
        public Models.Contact CreateContact(Models.Contact model)
        {
            _context.Contact.Add(model);
            _context.SaveChanges();
            return model;
        }

        public bool DeleteContact(int id)
        {
            Models.Contact contact = _context.Contact.Find(id);
            _context.Contact.Remove(contact);
            if (_context.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

     

        public Models.Contact GetContact()
        {
            return _context.Contact.FirstOrDefault();

        }

       

        public Models.Contact UpdateContact(Models.Contact model)
        {
            _context.Contact.Update(model);
            _context.SaveChanges();
            return model;
        }
        public Models.Contact FindContact(int? contactId)
        {
            return _context.Contact.Find(contactId);
        }

        public List<Models.Contact> GetContacts()
        {
            return _context.Contact.ToList();
        }
    }
}
