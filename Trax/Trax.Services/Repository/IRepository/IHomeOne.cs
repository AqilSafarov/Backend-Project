using System;
using System.Collections.Generic;
using System.Text;

namespace Trax.Services.Repository.IRepository
{
    public interface IHomeOne
    {
        List<Models.HomeOne> GetHomeOne();
        Models.HomeOne GetHomeOne(int? id);
        Models.HomeOne CreateHomeOne(Models.HomeOne model);
        Models.HomeOne UpdateHomeOne(Models.HomeOne model);
        bool DeleteHomeOne(int? id);
        Models.HomeOne FindHomeOne(int? homeone);

    }
}
