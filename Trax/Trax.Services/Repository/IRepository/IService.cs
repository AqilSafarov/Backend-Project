using System;
using System.Collections.Generic;
using System.Text;

namespace Trax.Services.Repository.IRepository
{
    public interface IService
    {
        List<Models.Service> GetService();
        Models.Service GetService(int? id);
        Models.Service CreateService(Models.Service model);
        Models.Service UpdateService(Models.Service model);
        bool DeleteService(int id);
        Models.Service FindService(int? serviceId);

    }
}
