using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trax.Services.Repository.IRepository;

namespace Trax.Services.Repository
{
    public class Consultation : IConsultation
    {
        private readonly AppDbContext _context;

        public Consultation(AppDbContext context)
        {
            _context = context;
        }

        public Models.Consultation CreateConsultation(Models.Consultation model)
        {
            _context.Consultation.Add(model);
            _context.SaveChanges();
            return model;
        }

        public bool CheckSetting(Models.Setting model)
        {
            if (!(_context.Setting.Any(x => x.Id > 0)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool DeleteConsultation(int id)
        {
            Models.Consultation consultation = _context.Consultation.Find(id);
            _context.Consultation.Remove(consultation);
            if (_context.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }


        public Models.Consultation GetConsultation(int id)
        {
            return _context.Consultation.Find(id);
        }
        public Models.Consultation GetConsultation()
        {
            return _context.Consultation.FirstOrDefault();
        }

      

        public Models.Consultation UpdateConsultation(Models.Consultation model)
        {
            _context.Consultation.Update(model);
            _context.SaveChanges();
            return model;
        }

        List<Models.Consultation> IConsultation.GetConsultations()
        {
            return _context.Consultation.ToList();

        }
    }
}
