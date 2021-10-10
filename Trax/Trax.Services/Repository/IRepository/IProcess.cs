using System;
using System.Collections.Generic;
using System.Text;

namespace Trax.Services.Repository.IRepository
{
   public interface IProcess
    {
        List<Models.Process> GetProcess();
        Models.Process GetProcessParam(int? id);
        Models.Process GetProcessSingle();

        Models.Process CreateProcess(Models.Process model);
        Models.Process UpdateProcess(Models.Process model);
        bool DeleteProcess(int? id);

    }
}
