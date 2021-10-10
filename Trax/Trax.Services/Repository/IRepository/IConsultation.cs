using System;
using System.Collections.Generic;
using System.Text;

namespace Trax.Services.Repository.IRepository
{
    public interface IConsultation
    {
        List<Models.Consultation> GetConsultations();
        Models.Consultation GetConsultation(int id);
        Models.Consultation GetConsultation();

        Models.Consultation CreateConsultation(Models.Consultation model);
        Models.Consultation UpdateConsultation(Models.Consultation model);
        bool DeleteConsultation(int id);
    }
}
