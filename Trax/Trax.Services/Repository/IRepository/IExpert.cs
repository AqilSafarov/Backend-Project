using System;
using System.Collections.Generic;
using System.Text;

namespace Trax.Services.Repository.IRepository
{
    public interface IExpert
    {
        Models.Expert GetExpert();
        Models.Expert CreateExpert(Models.Expert model);
        Models.Expert UpdateExpert(Models.Expert model);
        bool DeleteExpert(int id);
        Models.Expert FindExpert(int? expert);
        List<Models.Expert> GetExperts();

    }
}
