using System;
using System.Collections.Generic;
using System.Text;

namespace Trax.Services.Repository.IRepository
{
    public interface ICounters
    {
        List<Models.Counters> GetCounters();
        Models.Counters GetCounters(int? id);
        Models.Counters CreateCounters(Models.Counters model);
        Models.Counters UpdateCounters(Models.Counters model);
        bool DeleteCounters(int id);
    }
}
