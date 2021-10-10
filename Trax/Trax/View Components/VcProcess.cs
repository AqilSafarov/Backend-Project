using Trax.Models;
using Trax.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trax.Services.Repository.IRepository;
using Trax.ViewModels;

namespace Trax.ViewComponents
{
    public class VcProcess: ViewComponent
    {
        private readonly IProcess _process;
        private readonly IProcessType _processType;

        public VcProcess(AppDbContext context,IProcess process,IProcessType processType)
        {
            _process = process;
            _processType = processType;
        }
        public IViewComponentResult Invoke()
        {
           VmProcess model = new VmProcess() { 
             Process=_process.GetProcessSingle(),
             ProcessType=_processType.GetProcessType(),
           };
            return View(model);
        }
    }
}
