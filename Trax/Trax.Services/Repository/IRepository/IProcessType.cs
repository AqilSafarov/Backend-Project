using System;
using System.Collections.Generic;
using System.Text;

namespace Trax.Services.Repository.IRepository
{
    public interface IProcessType
    {
        List<Models.ProcessType> GetProcessType();
        Models.ProcessType GetProcessType(int id);
        Models.ProcessType CreateProcessType(Models.ProcessType model);
        Models.ProcessType UpdateProcessType(Models.ProcessType model);
        bool DeleteProcessType(int id);
    }
}
